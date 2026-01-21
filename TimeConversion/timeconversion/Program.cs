class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the time in seconds: ");
        int seconds = int.Parse(Console.ReadLine());

        int hours = seconds / 60;
        int remainingSeconds = seconds % 60;
        //output the result in string format in m:ss
        Console.WriteLine($"Time: {hours}:{remainingSeconds:D2}");
    }
}