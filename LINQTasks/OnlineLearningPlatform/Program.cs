using System;
using System.Collections.Generic;
using System.Linq;

class DuplicateEnrollmentException : Exception
{
    public DuplicateEnrollmentException(string m) : base(m) { }
}

class CourseCapacityExceededException : Exception
{
    public CourseCapacityExceededException(string m) : base(m) { }
}

class AssignmentDeadlineException : Exception
{
    public AssignmentDeadlineException(string m) : base(m) { }
}


class Course
{
    public int Id;
    public string Title;
    public Instructor Instructor;
    public int Capacity;
    public double Rating;
}

class Student
{
    public int Id;
    public string Name;
}

class Instructor
{
    public int Id;
    public string Name;
}

class Enrollment
{
    public Student Student;
    public Course Course;
    public DateTime Date = DateTime.Now;
}

class Assignment
{
    public string Title;
    public DateTime Deadline;

    public void Submit(DateTime submitDate)
    {
        if (submitDate > Deadline)
            throw new AssignmentDeadlineException("Deadline passed");
    }
}


class Program
{
    static List<Course> courses = new();
    static List<Student> students = new();
    static List<Instructor> instructors = new();
    static List<Enrollment> enrollments = new();

    static void EnrollStudent(int studId, int courseId)
    {
        var s = students.First(x => x.Id == studId);
        var c = courses.First(x => x.Id == courseId);

        if (enrollments.Any(e => e.Student.Id == studId && e.Course.Id == courseId))
            throw new DuplicateEnrollmentException("Already enrolled");

        if (enrollments.Count(e => e.Course.Id == courseId) >= c.Capacity)
            throw new CourseCapacityExceededException("Course full");

        enrollments.Add(new Enrollment { Student = s, Course = c });
    }

    static void Reports()
    {
        Console.WriteLine("Courses with >50 students:");
        var bigCourses =  enrollments.GroupBy(k=>k.Course.Title).Where(k=>k.Count()>50);
        foreach (var c in bigCourses)
            Console.WriteLine(c.Key);

        Console.WriteLine("\nStudents in >3 courses:");
        var activeStudents = enrollments.GroupBy(k=>k.Student.Name).Where(k=>k.Count()> 3);
        foreach (var s in activeStudents)
            Console.WriteLine(s.Key);

        Console.WriteLine("\nMost popular course:");
        var popular = enrollments.GroupBy(k=>k.Course.Title).OrderByDescending(k=>k.Count()).FirstOrDefault();
        Console.WriteLine(popular?.Key);

        Console.WriteLine("\nAverage course rating:");
        Console.WriteLine(courses.Average(k=>k.Rating));

        Console.WriteLine("\nInstructor with highest enrollments:");
        var topInst =enrollments.GroupBy(k=>k.Course.Instructor.Name).OrderByDescending(k=>k.Count()).FirstOrDefault();
        Console.WriteLine(topInst?.Key);
    }

    static void Main()
    {
        try
        {
            
            instructors.Add(new Instructor { Id = 1, Name = "Ali" });
            instructors.Add(new Instructor { Id = 2, Name = "Raj" });

            courses.Add(new Course { Id = 1, Title = "C#", Instructor = instructors[0], Capacity = 100, Rating = 4.5 });
            courses.Add(new Course { Id = 2, Title = "Python", Instructor = instructors[1], Capacity = 80, Rating = 4.2 });

            students.Add(new Student { Id = 1, Name = "Riya" });
            students.Add(new Student { Id = 2, Name = "Rahul" });

            EnrollStudent(1, 1);
            EnrollStudent(2, 1);

            Reports();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}