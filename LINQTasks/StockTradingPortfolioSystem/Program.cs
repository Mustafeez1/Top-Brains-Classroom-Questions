using System;
using System.Collections.Generic;
using System.Linq;


class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string m) : base(m) { }
}


class Investor
{
    public int Id;
    public string Name;
}

class Stock
{
    public string Symbol;
    public double Price;
}

enum TransactionType
{
    Buy,
    Sell
}

class Transaction
{
    public Investor Investor;
    public Stock Stock;
    public int Quantity;
    public double Price;
    public DateTime Date;
    public TransactionType Type;
}


class Portfolio
{
    public Investor Investor;
    public List<Transaction> Transactions = new();

    public int SharesOwned(string symbol)
    {
        return Transactions
            .Where(t => t.Stock.Symbol == symbol)
            .Sum(t => t.Type == TransactionType.Buy ? t.Quantity : -t.Quantity);
    }

    public double NetProfitLoss()
    {
        return Transactions.Sum(t =>
            t.Type == TransactionType.Sell
            ? t.Price * t.Quantity
            : -t.Price * t.Quantity);
    }

    public double Risk() => Transactions.Count * 0.5;
}


class Program
{
    static List<Investor> investors = new();
    static List<Stock> stocks = new();
    static List<Transaction> transactions = new();
    static Dictionary<string, List<Transaction>> stockTxMap = new();

    static void AddTransaction(int invId, string symbol,
        int qty, double price, TransactionType type, DateTime date)
    {
        if (date > DateTime.Now)
            throw new InvalidTransactionException("Future date not allowed");

        var inv = investors.First(x => x.Id == invId);
        var stock = stocks.First(x => x.Symbol == symbol);

        var portfolio = new Portfolio
        {
            Investor = inv,
            Transactions = transactions.Where(t => t.Investor.Id == invId).ToList()
        };

        if (type == TransactionType.Sell &&
            portfolio.SharesOwned(symbol) < qty)
            throw new InvalidTransactionException("Not enough shares");

        var tx = new Transaction
        {
            Investor = inv,
            Stock = stock,
            Quantity = qty,
            Price = price,
            Date = date,
            Type = type
        };

        transactions.Add(tx);

        if (!stockTxMap.ContainsKey(symbol))
            stockTxMap[symbol] = new List<Transaction>();

        stockTxMap[symbol].Add(tx);
    }

    static void Reports()
    {
        Console.WriteLine("Most profitable investor:");
        var bestInvestor = investors
            .Select(i => new
            {
                Name = i.Name,
                Profit = new Portfolio
                {
                    Investor = i,
                    Transactions = transactions.Where(t => t.Investor.Id == i.Id).ToList()
                }.NetProfitLoss()
            })
            .OrderByDescending(x => x.Profit)
            .FirstOrDefault();
        Console.WriteLine(bestInvestor?.Name);

        Console.WriteLine("\nStock highest volume:");
        var highStock = transactions
            .GroupBy(t => t.Stock.Symbol)
            .OrderByDescending(g => g.Sum(x => x.Quantity))
            .FirstOrDefault();
        Console.WriteLine(highStock?.Key);

        Console.WriteLine("\nTransactions grouped by stock:");
        foreach (var g in transactions.GroupBy(t => t.Stock.Symbol))
            Console.WriteLine($"{g.Key}: {g.Count()}");

        Console.WriteLine("\nNet Profit/Loss Overall:");
        Console.WriteLine(transactions.Sum(t =>
            t.Type == TransactionType.Sell
            ? t.Price * t.Quantity
            : -t.Price * t.Quantity));

        Console.WriteLine("\nInvestors with negative returns:");
        foreach (var i in investors)
        {
            var pf = new Portfolio
            {
                Investor = i,
                Transactions = transactions.Where(t => t.Investor.Id == i.Id).ToList()
            };

            if (pf.NetProfitLoss() < 0)
                Console.WriteLine(i.Name);
        }
    }

    static void Main()
    {
        try
        {
            
            investors.Add(new Investor { Id = 1, Name = "Rahul" });
            investors.Add(new Investor { Id = 2, Name = "Riya" });

            stocks.Add(new Stock { Symbol = "TCS", Price = 3500 });
            stocks.Add(new Stock { Symbol = "INFY", Price = 1500 });

            AddTransaction(1, "TCS", 10, 3400, TransactionType.Buy, DateTime.Now);
            AddTransaction(1, "TCS", 5, 3600, TransactionType.Sell, DateTime.Now);

            Reports();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}