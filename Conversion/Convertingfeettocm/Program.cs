class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the value in feet");
        int value = int.Parse(Console.ReadLine());
        double result = (double)Math.Round(value *30.48, 2);
        Console.WriteLine($"{value} feet is equal to {result} cm");
    }
}