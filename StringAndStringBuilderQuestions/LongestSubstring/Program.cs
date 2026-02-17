class Program
{
    public static void Main(string[] args)
    {
        string word = "abcabcbb";
        var set = new HashSet<char>();
        int left = 0, max =0;
        for (int i = 0; i < word.Length; i++)
        {
            while(set.Contains(word[i])) set.Remove(word[left++]);

            set.Add(word[i]);
            max = Math.Max(max, i-left+1);
        }
        Console.WriteLine($"Maximum longest substring is of length: {max}");
    }
}