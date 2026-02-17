using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        string word = "Khan";
        StringBuilder toggleCase = new StringBuilder();
        foreach (char c in word)
        {
            toggleCase.Append(char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c));
        }
        Console.WriteLine($"Updated String: {toggleCase}");
    }
}