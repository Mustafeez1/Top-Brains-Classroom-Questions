class Program
{
    public static void Main(string[] args)
    {
        string a = "listen", b = "silent";
        var dict = new Dictionary<char, int>();
        foreach (var item in a)
        {
            if (dict.ContainsKey(item))
            {
                dict[item]++;
            }
            else
            {
                dict[item]=1;
            }
        }
        bool found = false;
        foreach (var item in b)
        {
            if (dict.ContainsKey(item))
            {
                dict[item]--;
            }
            else
            {
                found =true;
                break;
            }
        }
        if (found)
        {
            Console.WriteLine("Not an anagram");
        }
        else
        {
            Console.WriteLine("An anagram");
        }
    }
}