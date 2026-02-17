class Program
{
    public static void Main(string[] args)
    {
        string mail = "John@gmail.com";
        int index= mail.IndexOf('@');
        Console.WriteLine(mail[0] + "***" + mail.Substring(index));
    }
}