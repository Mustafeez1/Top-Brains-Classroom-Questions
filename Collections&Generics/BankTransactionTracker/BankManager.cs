public class BankManager
{
    private Dictionary<int, Account> _accounts = new Dictionary<int, Account>();
    private Queue<Transaction> _transactionQueue = new Queue<Transaction>();
    public void AddAccount(Account acc)
    {
        if (!_accounts.ContainsKey(acc.AccountNumber))
        {
            _accounts[acc.AccountNumber] = (acc);
            Console.WriteLine($"Account {acc.HolderName} has been added.");
        }
        else
        {
            Console.WriteLine($"Account {acc.HolderName} alreay exists");
        }
        
    }
     public void AddTransaction(int accNo, Transaction t)
    {
        // TODO
        if (_accounts.ContainsKey(accNo))
        {
            _accounts[accNo].Transactions.Add(t);
            _transactionQueue.Enqueue(t);
        }
    }
    public void ProcessNextTransaction()
    {/*
        // STEPS:

        // 1. Check queue empty:
        //    _transactionQueue.Count == 0

        // 2. If not empty:
        //    - Remove transaction using Dequeue()
        //    - Print processed message
        // */
        if(_transactionQueue.Count == 0)
        {
            return;
        }
        else
        {
            var item = _transactionQueue.Dequeue();
            Console.WriteLine("To next Transaction Proceed");
        }
    }
    public IEnumerable<Transaction> FindTransactions(Func<Transaction, bool> predicate)
    {
        /*
        STEPS:

        1. Get all accounts:
           _accounts.Values

        2. Flatten all transactions:
           SelectMany(a => a.Transactions)

        3. Apply filter:
           Where(predicate)

        4. Return result.
        */
        return _accounts.Values.SelectMany(k => k.Transactions).Where(predicate);
    }

}