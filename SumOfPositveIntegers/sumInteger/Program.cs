class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the length of the array");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];

        for(int i =0; i < length; i++)
        {
            Console.WriteLine($"Enter the value at index{i}");
            array[i] =int.Parse(Console.ReadLine());
        }

        int totalSum = 0;
        for (int i = 0; i < length; i++)
        {
            if(array[i] > 0)
            {
                totalSum += array[i];
            }
            else if(array[i] < 0)
            {
                continue;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine($"Sum is {totalSum}");

    }
}