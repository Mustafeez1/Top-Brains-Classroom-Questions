using System;
using System.Text;
class Program
{
    public static void Main()
    {
        string result = CleanseAndInvert("abcdef");
        if (result.Length == 0)
            {
                System.Console.WriteLine("invalid");
            }
        else
            {
                System.Console.WriteLine("Generated String is: "+result);
            }   
    }
    public static string CleanseAndInvert(string input)
    {
        StringBuilder newstring = new StringBuilder();
        if(string.IsNullOrEmpty(input) || input.Length<6) return string.Empty;
        foreach(char i in input)
        {
            if(!char.IsLetter(i)) return string.Empty;
            input.ToLower();
            if((int)i%2!=0){
                newstring.Append(i);
            }
        }
        char[] arr = new char[newstring.Length];
        arr = newstring.ToString().ToCharArray();
        Array.Reverse(arr);
        for(int i=0;i<arr.Length;i++)
        {
            if(i%2==0) arr[i]=char.ToUpper(arr[i]);
        }
        return new string(arr);
    }
}