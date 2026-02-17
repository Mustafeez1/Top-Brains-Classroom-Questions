public class Account
{
    public int AccountNumber { get; set; }
    public string HolderName { get; set; }
    public double Balance { get; set; }
    public List<Transaction> Transactions = new List<Transaction>();
}