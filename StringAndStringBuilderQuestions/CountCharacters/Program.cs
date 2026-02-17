class Program
{
    public static void Main(string[] args)
    {
        string word = "Hello 123!";
        int upper = 0, lower = 0, space = 0,digit = 0, special = 0;
        foreach (char c in word)
        {
            if(char.IsUpper(c))
            {
                upper++;
            }else if (char.IsLower(c))
            {
                lower++;
            }
            else if (char.IsDigit(c))
            {
                digit++;
            }
            else if (char.IsWhiteSpace(c))
            {
                space++;
            }
            else
            {
                special++;
            }
        }
        Console.WriteLine($"Upper: {upper} Lower: {lower} Digit: {digit} Space: {space} Special: {special}");
    }
}