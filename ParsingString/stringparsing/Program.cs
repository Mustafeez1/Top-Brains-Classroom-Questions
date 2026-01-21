class Program
{
    public static void Main(string[] args)
    {
        string[] tokens  = new string[5];
        for (int i = 0; i < tokens.Length; i++)
        {
            Console.WriteLine($"Enter the string at index{i}");
            tokens[i] = Console.ReadLine();
        }
        int total_sum = 0;
        foreach(var token in tokens)
        {
            if(int.TryParse(token, out int number))
            {
                total_sum += number;
            }
        }
        Console.WriteLine($"total sum is: {total_sum}");
    }
}