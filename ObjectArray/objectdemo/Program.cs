using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the length of the array");
        object[] elements = {"abc", 'a', 1, 12, 33, 29, "khan"};
        int sum =0;
        foreach(object item in elements)
        {
            if(item is int val)
            {
                sum += val;
            }
        }
        Console.WriteLine($"Sum of the integers is {sum}");
    }
}