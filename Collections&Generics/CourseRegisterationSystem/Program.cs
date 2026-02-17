class Program
{
    static void Main(string[] args)
    {
        CourseManager manager = new CourseManager();

        // Register students
        manager.RegisterStudent(1, "Ali", "CS");
        manager.RegisterStudent(2, "Sara", "IT");
        manager.RegisterStudent(3, "John", "CS");
        manager.RegisterStudent(4, "Mike", "CS");

        // Enroll students
        manager.EnrollCourse(1, "Math");
        manager.EnrollCourse(2, "Math");
        manager.EnrollCourse(3, "Math");
        manager.EnrollCourse(4, "Math"); // goes to waiting list

        // Display enrolled students
        var students = manager.GetStudentsInCourse("Math");

        Console.WriteLine("Enrolled Students:");
        foreach (var s in students)
        {
            Console.WriteLine($"{s.Name} - {s.Department}");
        }
    }
}