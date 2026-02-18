using System;
using System.Collections.Generic;
using System.Linq;


class OutOfStockException : Exception
{
    public OutOfStockException(string m) : base(m) { }
}

class OrderAlreadyShippedException : Exception
{
    public OrderAlreadyShippedException(string m) : base(m) { }
}

class CustomerBlacklistedException : Exception
{
    public CustomerBlacklistedException(string m) : base(m) { }
}


class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;
}

class Customer
{
    public int Id;
    public string Name;
    public bool IsBlacklisted;
}

class OrderItem
{
    public Product Product;
    public int Quantity;

    public double TotalPrice() => Product.Price * Quantity;
}

enum OrderStatus
{
    Pending,
    Shipped,
    Cancelled
}

class Order
{
    public int OrderId;
    public Customer Customer;
    public List<OrderItem> Items = new();
    public DateTime OrderDate = DateTime.Now;
    public OrderStatus Status = OrderStatus.Pending;

    public double TotalAmount() => Items.Sum(i => i.TotalPrice());
}


class Program
{
    static List<Product> products = new();
    static List<Customer> customers = new();
    static List<Order> orders = new();
    static Dictionary<int, Product> productMap = new();

    static void PlaceOrder(int custId, int prodId, int qty)
    {
        var cust = customers.First(c => c.Id == custId);
        if (cust.IsBlacklisted)
            throw new CustomerBlacklistedException("Customer blocked");

        var prod = productMap[prodId];
        if (prod.Stock < qty)
            throw new OutOfStockException("Stock insufficient");

        prod.Stock -= qty;

        var order = new Order
        {
            OrderId = orders.Count + 1,
            Customer = cust
        };

        order.Items.Add(new OrderItem { Product = prod, Quantity = qty });
        orders.Add(order);
    }

    static void CancelOrder(int id)
    {
        var order = orders.First(o => o.OrderId == id);

        if (order.Status == OrderStatus.Shipped)
            throw new OrderAlreadyShippedException("Cannot cancel shipped order");

        order.Status = OrderStatus.Cancelled;
    }

    static void Reports()
    {
        Console.WriteLine("\nOrders last 7 days:");
        foreach (var o in orders.Where(k=>k.OrderDate >= DateTime.Now.AddDays(-7)))
            Console.WriteLine(o.OrderId);

        Console.WriteLine("Total Revenue: " + orders.Sum(k => k.TotalAmount()));

        Console.WriteLine("Most Sold Product:");
        var best = orders.SelectMany(k => k.Items).GroupBy(x => x.Product.Name).OrderByDescending(g=>g.Sum(n=>n.Quantity)).FirstOrDefault();
        Console.WriteLine(best?.Key);

        Console.WriteLine("Top 5 Customers:");
        var topCust = orders.GroupBy(o => o.Customer.Name)
            .Select(g => new { Name = g.Key, Spend = g.Sum(o => o.TotalAmount()) })
            .OrderByDescending(x => x.Spend).Take(5);
        foreach (var c in topCust)
            Console.WriteLine(c.Name);

        Console.WriteLine("Orders by Status:");
        foreach (var g in orders.GroupBy(k => k.Status))
            Console.WriteLine($"{g.Key}: {g.Count()}");

        Console.WriteLine("Low Stock Products:");
        foreach (var p in products.Where(k=>k.Stock<10))
            Console.WriteLine(p.Name);
    }

    static void Main()
    {
        try
        {
            
            products.Add(new Product { Id = 1, Name = "Laptop", Price = 50000, Stock = 20 });
            products.Add(new Product { Id = 2, Name = "Phone", Price = 20000, Stock = 5 });
            foreach (var p in products) productMap[p.Id] = p;

            customers.Add(new Customer { Id = 1, Name = "Rahul" });
            customers.Add(new Customer { Id = 2, Name = "Riya", IsBlacklisted = true });

            PlaceOrder(1, 1, 2);
            Reports();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}