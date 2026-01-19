using System.Text;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the first word");
        string first_word = Console.ReadLine().ToLower();

        Console.WriteLine("Enter the second word");
        string second_word = Console.ReadLine().ToLower();



        string vowels = "aeiou";

        StringBuilder updated_string = new StringBuilder();
        for(int i =0;i < first_word.Length; i++)
        {
            char character = char.ToLower(first_word[i]);
            bool consonant = false;

            if (!vowels.Contains(character))
            {
                for (int j = 0; j < second_word.Length; j++)
                {
                    if(character == second_word[j])
                    {
                        consonant = true;
                        break;
                    }
                }
            }

            if (!consonant)
            {
                updated_string.Append(first_word[i]);
            }
        }

        StringBuilder finalstring = new StringBuilder();
        finalstring.Append(updated_string[0]);
        for(int i = 1; i < updated_string.Length; i++)
        {
            if(updated_string[i] != updated_string[i - 1])
            {
                finalstring.Append(updated_string[i]);
            }
        }

        Console.WriteLine($"Final String is : {finalstring.ToString()}");
    }
}