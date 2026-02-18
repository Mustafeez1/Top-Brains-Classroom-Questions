public class Program
{
    public static List<int> NumberList = new List<int>();

    public void AddNumbers(int numbers)
    {
       NumberList.Add(numbers);
    }
    public double GetGPAScored()
    {
        if(NumberList.Count == 0) return -1;
        double score = 0;
        foreach (var item in NumberList)
        {
            score += (item * 3);
        }
        score = score/(NumberList.Count * 3);
        return score;
    }
    public char GetGradeScored(double gpa)
    {
        if(gpa == 10.0)
        {
            return 'S';
        }else if(gpa >= 9.0 && gpa < 10.0)
        {
            return 'A';
        }else if(gpa >= 8.0 && gpa < 9.0)
        {
            return 'B';
        }
        else if(gpa >= 7.0 && gpa < 8.0)
        {
            return 'C';
        }else if(gpa >= 6.0 && gpa < 7.0)
        {
            return 'D';
        }
        return 'E';
    }
    public static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine("Enter the numbr of numbers");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Entre the number to add to the list.");
            program.AddNumbers(int.Parse(Console.ReadLine()));
        }

        double gpa = program.GetGPAScored();
        Console.WriteLine($"The gpa is: {gpa}");

        char grade = program.GetGradeScored(gpa);
        Console.WriteLine($"the grade is: {grade}");
    }
}