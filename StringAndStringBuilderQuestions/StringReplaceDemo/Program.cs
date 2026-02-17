class Program
{
    public static void Main(string[] args)
    {
        string word = "Hello World";
        int index = word.ToLower().IndexOf("world");
        if(index >= 0)
        {
            word = word.Remove(index, 5).Insert(index, "Earth");
        }
        Console.WriteLine(word);
    }
}