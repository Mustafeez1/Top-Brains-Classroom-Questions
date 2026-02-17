using System.Linq;
using System.Collections.Generic;
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
        char max = dict.OrderByDescending(k=>k.Value).First().Key;
        Console.WriteLine($"The most frequent character: {max}");
    }
}