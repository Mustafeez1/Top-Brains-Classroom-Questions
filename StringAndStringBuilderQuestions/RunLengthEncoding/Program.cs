using System.Text;
class Program
{
    public static void Main(string[] args)
    {
        string word = "aaabb";
        StringBuilder sb = new StringBuilder();
        int count = 1;
        for (int i = 1; i <= word.Length; i++)
        {
            if(i < word.Length && ( word[i] == word[i - 1]) )
            {
                count++;
            }
            else
            {
                sb.Append(word[i-1]).Append(count);
                count = 1;
            }
        }
        Console.WriteLine(sb);
    }
}