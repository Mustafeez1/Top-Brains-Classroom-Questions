using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        string word = "aeiouKhan";
        StringBuilder sb = new StringBuilder();
        foreach (char item in word)
        {
            if(item != 'a' && item != 'e' && item != 'i' && item != 'o' && item != 'u')
            {
                sb.Append(item);
            }
        }
        Console.WriteLine($"removed string: {sb}");
    }
}