class Program
{
    public User ValidatePhoneNumber(string name, string number)
    {
        if(number != null && number.Length == 10)
        {
            return new User
            {
                Name = name,
                PhoneNumber = number
            };
        }
        throw new InvalidPhoneNumberException("Invalid Phone Number");
    }
    public static void Main(string[] args)
    {
        Program p = new Program();
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();

        Console.WriteLine("Enter phone numebr");
        string number= Console.ReadLine();
        try
        {
            User result = p.ValidatePhoneNumber(name, number);
            Console.WriteLine("User verified");
        }
        catch (InvalidPhoneNumberException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
class User
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}
class InvalidPhoneNumberException :Exception
{
    public InvalidPhoneNumberException(string msg):base(msg){}
}
