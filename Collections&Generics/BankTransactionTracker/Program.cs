class Program
{
    public static void Main(string[] args)
    {
        BankManager manager = new BankManager();
        Account account1 = new Account
        {
            AccountNumber = 101,
            HolderName = "Khan",
            Balance = 5000
        };
        Account account2 = new Account
        {
            AccountNumber = 102,
            HolderName = "Musta",
            Balance = 2900
        };
        manager.AddAccount(account1);
        manager.AddAccount(account2);
        Transaction transaction1 = new Transaction
        {
            TransactionId = 1, 
            Amount = 1000,
            Type="Credit",
            Date = DateTime.Now
        };
         Transaction transaction2 = new Transaction
        {
            TransactionId = 2, 
            Amount = 2000,
            Type="Debit",
            Date = DateTime.Now
        };
        manager.AddTransaction(101, transaction1);
        manager.AddTransaction(102, transaction2);
        manager.ProcessNextTransaction();
        var bigTransaction = manager.FindTransactions(t => t.Amount > 1500);
        Console.WriteLine("Large Transactions");
        foreach (var item in bigTransaction)
        {
            Console.WriteLine($"ID: {item.TransactionId} Amount: {item.Amount}");
        }
    }
}