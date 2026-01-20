using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter first Number");
        int first_number = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Second Number");
        int second_number = int.Parse(Console.ReadLine());

        SwapByRef(ref first_number, ref second_number);
        Console.WriteLine("After Swapping");
        Console.WriteLine($"First number is {first_number}, Scecond number is {second_number}");
        
        SwapByOut(first_number, second_number, out int a, out int b);
        Console.WriteLine("After Swapping");
        Console.WriteLine($"First number is {a}, Scecond number is {b}");

        
    }
    public static void SwapByRef(ref int num1, ref int num2)
    {
        int temp = num1;
        num1 = num2;
        num2 = temp;
    }

    public static void SwapByOut(int num1, int num2,out int num3,out int num4)
    {
        num3 = num2;
        num4 = num1;
    }
}