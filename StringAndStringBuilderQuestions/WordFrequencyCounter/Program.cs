class Program
{
    public static void Main(string[] args)
    {
        string word= "Hello hello world";
        var dict = new Dictionary<string, int>();
        foreach (var item in word.ToLower().Split(new[]{' ',',','!','.'}, StringSplitOptions.RemoveEmptyEntries))
        {
            dict[item] = dict.ContainsKey(item) ? dict[item] + 1: 1;
        }
        foreach (var item in dict)
        {
            Console.WriteLine($"Key: {item.Key} Value: {item.Value}");
        }
    }
}