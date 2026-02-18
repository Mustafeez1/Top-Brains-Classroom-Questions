using System;
using System.Collections.Generic;
using System.Linq;


class DoctorNotAvailableException : Exception
{
    public DoctorNotAvailableException(string msg) : base(msg) { }
}

class InvalidAppointmentException : Exception
{
    public InvalidAppointmentException(string msg) : base(msg) { }
}

class PatientNotFoundException : Exception
{
    public PatientNotFoundException(string msg) : base(msg) { }
}

class DuplicateMedicalRecordException : Exception
{
    public DuplicateMedicalRecordException(string msg) : base(msg) { }
}

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}


class Doctor : Person
{
    public string Specialization { get; set; }
    public double ConsultationFee { get; set; }

    public virtual double CalculateBill(int patients)
        => ConsultationFee * patients;
}

class Patient : Person
{
    public string Disease { get; set; }
}


class Appointment
{
    public int Id { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}


class MedicalRecord
{
    public int Id { get; private set; }
    public Patient Patient { get; private set; }
    public string Diagnosis { get; private set; }

    public MedicalRecord(int id, Patient p, string d)
    {
        Id = id;
        Patient = p;
        Diagnosis = d;
    }
}


class Program
{
    static List<Doctor> doctors = new();
    static List<Patient> patients = new();
    static List<Appointment> appointments = new();
    static Dictionary<int, MedicalRecord> records = new();

    static void BookAppointment(int docId, int patId)
    {
        var doc = doctors.FirstOrDefault(d => d.Id == docId);
        if (doc == null)
            throw new DoctorNotAvailableException("Doctor not found");

        var pat = patients.FirstOrDefault(p => p.Id == patId);
        if (pat == null)
            throw new PatientNotFoundException("Patient not found");

        appointments.Add(new Appointment
        {
            Id = appointments.Count + 1,
            Doctor = doc,
            Patient = pat
        });
    }

    static void AddMedicalRecord(int id, int patId, string diag)
    {
        if (records.ContainsKey(id))
            throw new DuplicateMedicalRecordException("Duplicate record");

        var pat = patients.FirstOrDefault(p => p.Id == patId);
        if (pat == null)
            throw new PatientNotFoundException("Patient missing");

        records[id] = new MedicalRecord(id, pat, diag);
    }

    static void Reports()
    {
        Console.WriteLine("Doctors with >10 appointments:");
        var busyDocs = appointments.GroupBy(k=>k.Doctor.Name).Where(v=>v.Count()>10);
        foreach (var d in busyDocs)
            Console.WriteLine(d.Key);

        Console.WriteLine("\nPatients treated last 30 days:");
        var recent = appointments
            .Where(a => a.Date >= DateTime.Now.AddDays(-30))
            .Select(a => a.Patient.Name)
            .Distinct();
        foreach (var p in recent)
            Console.WriteLine(p);

        Console.WriteLine("\nAppointments grouped by doctor:");
        foreach (var g in appointments.GroupBy(k => k.Doctor.Name))
            Console.WriteLine($"{g.Key}: {g.Count()}");

        Console.WriteLine("\nTop 3 earning doctors:");
        var topDocs = appointments
            .GroupBy(a => a.Doctor)
            .Select(g => new
            {
                Doc = g.Key.Name,
                Earn = g.Key.CalculateBill(g.Count())
            })
            .OrderByDescending(x => x.Earn)
            .Take(3);
        foreach (var t in topDocs)
            Console.WriteLine(t.Doc);

        Console.WriteLine("\nPatients by disease:");
        foreach (var g in patients.GroupBy(k=>k.Disease))
            Console.WriteLine($"{g.Key}: {g.Count()}");

        Console.WriteLine("\nTotal Revenue:");
        double revenue = appointments.GroupBy(k=>k.Doctor).Sum(g=>g.Key.CalculateBill(g.Count()));
        Console.WriteLine(revenue);
    }

    static void Main()
    {
        try
        {
            
            doctors.Add(new Doctor { Id = 1, Name = "Dr.Raj", Specialization = "Cardio", ConsultationFee = 500 });
            doctors.Add(new Doctor { Id = 2, Name = "Dr.Ali", Specialization = "Neuro", ConsultationFee = 700 });

            patients.Add(new Patient { Id = 1, Name = "Rahul", Disease = "Fever" });
            patients.Add(new Patient { Id = 2, Name = "Riya", Disease = "Heart" });

            BookAppointment(1, 1);
            BookAppointment(2, 2);

            AddMedicalRecord(1, 1, "Viral Fever");

            Reports();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}