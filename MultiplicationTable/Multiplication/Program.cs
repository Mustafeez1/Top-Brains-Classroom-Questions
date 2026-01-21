class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number for multiplication table");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number upto for table");
        int upto = int.Parse(Console.ReadLine());

        int[] array = new int[upto];
        for(int i =0 ; i< upto; i++)
        {
            array[i] = number * (i+1);
        }
        foreach(var item in array)
        {
            Console.Write($"{item}" + " ");
        }
        Console.WriteLine();
    }
}