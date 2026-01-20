using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number");
        int first = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second number");
        int second = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the third number");
        int third = int.Parse(Console.ReadLine());

        if(first > second && first > third)
        {
            Console.WriteLine($"{first} is larger than {second} & {third}");
        }
        else if(second > third && second > first)
        {
            Console.WriteLine($"{second} is larger than {first} & {third}");
        }
        else
        {
            Console.WriteLine($"{third} is larger than {first} & {second}");
        }
    }
}