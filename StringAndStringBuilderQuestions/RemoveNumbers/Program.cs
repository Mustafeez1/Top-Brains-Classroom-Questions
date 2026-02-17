using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        string word = "Mustafeez72777";
        StringBuilder sb = new StringBuilder();
        foreach (char k in word)
        {
            if (char.IsLetter(k))
            {
                sb.Append(k);
            }
        }
        Console.WriteLine($"New String: {sb}");
    }
}