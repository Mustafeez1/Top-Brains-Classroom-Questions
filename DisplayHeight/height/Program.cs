using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter heoight in centimeters(cm)");
        int height = int.Parse(Console.ReadLine());

        DisplayHeight(height);
    }
    public static void DisplayHeight(int height)
    {
        if(height < 150)
        {
            Console.WriteLine("Short");
        }
        else if (height >= 150 && height < 180)
        {
            Console.WriteLine("Average");
        }
        else
        {
            Console.WriteLine("Tall");
        }
    }
}