using System;
using System.Collections.Generic;
using System.Linq;


class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string msg) : base(msg) { }
}

class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string msg) : base(msg) { }
}

class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string msg) : base(msg) { }
}


abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public double Balance { get; protected set; }

    public List<string> Transactions = new List<string>();

    public BankAccount(string acc, string name, double bal)
    {
        AccountNumber = acc;
        CustomerName = name;
        Balance = bal;
    }

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
            throw new InvalidTransactionException("Invalid deposit amount");

        Balance += amount;
        Transactions.Add($"Deposited {amount}");
    }

    public virtual void Withdraw(double amount)
    {
        if (amount > Balance)
            throw new InsufficientBalanceException("Not enough balance");

        Balance -= amount;
        Transactions.Add($"Withdrawn {amount}");
    }

    public abstract double CalculateInterest();
}


class SavingsAccount : BankAccount
{
    double MinBalance = 1000;

    public SavingsAccount(string acc, string name, double bal)
        : base(acc, name, bal) { }

    public override void Withdraw(double amount)
    {
        if (Balance - amount < MinBalance)
            throw new MinimumBalanceException("Minimum balance required");

        base.Withdraw(amount);
    }

    public override double CalculateInterest() => Balance * 0.04;
}


class CurrentAccount : BankAccount
{
    double overdraft = 5000;

    public CurrentAccount(string acc, string name, double bal)
        : base(acc, name, bal) { }

    public override void Withdraw(double amount)
    {
        if (Balance + overdraft < amount)
            throw new InsufficientBalanceException("Overdraft limit exceeded");

        Balance -= amount;
        Transactions.Add($"Withdrawn {amount}");
    }

    public override double CalculateInterest() => 0;
}


class LoanAccount : BankAccount
{
    public LoanAccount(string acc, string name, double bal)
        : base(acc, name, bal) { }

    public override void Deposit(double amount)
    {
        throw new InvalidTransactionException("Cannot deposit in loan account");
    }

    public override double CalculateInterest() => Balance * 0.1;
}


class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();

    static void Transfer(string from, string to, double amt)
    {
        var acc1 = accounts.FirstOrDefault(a => a.AccountNumber == from);
        var acc2 = accounts.FirstOrDefault(a => a.AccountNumber == to);

        if (acc1 == null || acc2 == null)
            throw new Exception("Account not found");

        acc1.Withdraw(amt);
        acc2.Deposit(amt);

        acc1.Transactions.Add($"Transferred {amt} to {to}");
        acc2.Transactions.Add($"Received {amt} from {from}");
    }

    static void LINQReports()
    {
        Console.WriteLine("\n--- LINQ REPORTS ---");

        var rich = accounts.Where(k => k.Balance > 50000);
        Console.WriteLine("Balance > 50k:");
        foreach (var a in rich)
            Console.WriteLine(a.CustomerName);

        Console.WriteLine("Total Bank Balance: " + accounts.Sum(a => a.Balance));

        Console.WriteLine("Top 3 Accounts:");
        foreach (var a in accounts.OrderByDescending(k => k.Balance).Take(3))
            Console.WriteLine(a.CustomerName);

        Console.WriteLine("Grouped by Type:");
        var grp = accounts.GroupBy(a => a.GetType().Name);
        foreach (var g in grp)
            Console.WriteLine($"{g.Key} -> {g.Count()}");

        Console.WriteLine("Names starting with R:");
        foreach (var a in accounts.Where(k => k.CustomerName.StartsWith("R"))
            )
            Console.WriteLine(a.CustomerName);
    }

    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\n1.Create 2.Deposit 3.Withdraw 4.Transfer 5.Report 6.Exit");
                int ch = int.Parse(Console.ReadLine());

                if (ch == 1)
                {
                    Console.Write("Type (S/C/L): ");
                    var t = Console.ReadLine();

                    Console.Write("Acc No: ");
                    string acc = Console.ReadLine();

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Balance: ");
                    double bal = double.Parse(Console.ReadLine());

                    if (t == "S") accounts.Add(new SavingsAccount(acc, name, bal));
                    else if (t == "C") accounts.Add(new CurrentAccount(acc, name, bal));
                    else accounts.Add(new LoanAccount(acc, name, bal));
                }
                else if (ch == 2)
                {
                    Console.Write("Acc No: ");
                    var a = accounts.First(x => x.AccountNumber == Console.ReadLine());
                    Console.Write("Amount: ");
                    a.Deposit(double.Parse(Console.ReadLine()));
                }
                else if (ch == 3)
                {
                    Console.Write("Acc No: ");
                    var a = accounts.First(x => x.AccountNumber == Console.ReadLine());
                    Console.Write("Amount: ");
                    a.Withdraw(double.Parse(Console.ReadLine()));
                }
                else if (ch == 4)
                {
                    Console.Write("From: ");
                    string f = Console.ReadLine();
                    Console.Write("To: ");
                    string t = Console.ReadLine();
                    Console.Write("Amount: ");
                    Transfer(f, t, double.Parse(Console.ReadLine()));
                }
                else if (ch == 5)
                    LINQReports();
                else break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}