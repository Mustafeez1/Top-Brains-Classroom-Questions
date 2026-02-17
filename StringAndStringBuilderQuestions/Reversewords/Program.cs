public class Program
{
    public static void Main(string[] args)
    {
        var word = "Hello World".Split(' ');
        Array.Reverse(word);
        Console.WriteLine(string.Join(' ',word));
    }
}