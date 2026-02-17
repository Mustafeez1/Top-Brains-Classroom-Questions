public class Program
{
    public static void Main(string[] args)
    {
        string word = "abc";
        bool found = false;
        for (int i = 1; i < word.Length; i++)
        {
            if(word[i] == word[i - 1])
            {
                found = true;
                break;
            }
        }
        if (found)
        {
            Console.WriteLine("Duplicate detected");
        }
        else
        {
            Console.WriteLine("No duplicates found");
        }
    }
}