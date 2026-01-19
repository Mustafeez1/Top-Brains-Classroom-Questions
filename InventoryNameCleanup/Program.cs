using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter product name");
        string product_name = Console.ReadLine();

        StringBuilder updated_string = new StringBuilder();
        for(int i =0; i< product_name.Length; i++)
        {
            if(i == 0 || product_name[i] != product_name[i - 1])
            {
                updated_string.Append(product_name[i]);
            }
        }
        string cleaned = string.Join(" ", updated_string.ToString().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));

        StringBuilder title_case = new StringBuilder();
        title_case.Append(char.ToUpper(cleaned[0]));
        for (int i = 1; i < cleaned.Length; i++)
        {
            if(cleaned[i-1] == ' ')
            {
                title_case.Append(char.ToUpper(cleaned[i]));
            }
            else
            {
                title_case.Append(cleaned[i]);
            }
        }
        Console.WriteLine(title_case.ToString());
    }
}