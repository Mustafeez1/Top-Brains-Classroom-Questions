class Program
{
    public static void Main(string[] args)
    {
        string word = "banana";
        var dict = new Dictionary<char, int>();
        foreach (var item in word)
        {
            dict[item] = dict.ContainsKey(item) ? dict[item]+1 : 1;
        }
        char min = dict.OrderBy(k=>k.Value).First().Key;
        Console.WriteLine($"First non repeating character: {min}");
    }
}