class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number: ");
        int number1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the first number: ");
        int number2 = int.Parse(Console.ReadLine());

        int result = GCD(number1, number2);
        Console.WriteLine($"gcd of two numbers is {result}");
    }
    public static int GCD(int number1, int number2)
    {

        int gcd = 0;
        bool result = true;
        while (result)
        {
            if(number1 % number2 == 0)
            {
                gcd = number2;
                result = false;
            }
            else
            {
                int temp = number2;
                number2 = number1 % number2;
                number1 = temp;
            }
        }
        return gcd;
    }
}