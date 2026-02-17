class Program
{
    public static void Main(string[] args)
    {
        var stack = new Stack<char>();
        foreach (var item in "(a[b])")
        {
            if("({[".Contains(item)) {
                stack.Push(item);
            }
            else if (")}]".Contains(item))
            {
                if(stack.Count==0) return;
                stack.Pop();
            }
        }
        if(stack.Count == 0)
        {
            Console.WriteLine("Balanced");
        }
        else
        {
            Console.WriteLine("Imbalanced");
        }
    }
}