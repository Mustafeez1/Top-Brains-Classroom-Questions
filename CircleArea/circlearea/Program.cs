using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the radius of the circle: ");
        double radius=Convert.ToDouble(Console.ReadLine());
        double area = Math.Round(Math.PI * radius * radius, 2);
        Console.WriteLine($"Area of the circle is: {area}");
    }
}