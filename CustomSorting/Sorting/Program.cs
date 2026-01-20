using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>()
        {
            new Student { Name = "khan", Age = 21, Marks = 95 },
            new Student { Name = "Sabeer", Age = 22, Marks = 96 },
            new Student { Name = "Ashi", Age = 32, Marks = 97 }
        };


        for (int i = 0; i < students.Count - 1; i++)
        {
            for (int j = i + 1; j < students.Count; j++)
            {
                if (students[i].Marks < students[j].Marks ||
                   (students[i].Marks == students[j].Marks &&
                    students[i].Age > students[j].Age))
                {
                    Student temp = students[i];
                    students[i] = students[j];
                    students[j] = temp;
                }
            }
        }

        foreach (var s in students)
        {
            Console.WriteLine($"{s.Name} - Age: {s.Age}, Marks: {s.Marks}");
        }
    }
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}
