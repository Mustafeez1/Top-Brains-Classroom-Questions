class Program
{
    public static void Main(string[] args)
    {
        FoodManager manager = new FoodManager();
        var pizza = new FoodItem {Code = "F1", Name="Pizza", Price=500};
        var Burger = new FoodItem {Code = "F2", Name="Burger", Price=200};
        manager.AddMenuItem(pizza);
        manager.AddMenuItem(Burger);
        manager.PlaceOrder(101, pizza);
        manager.PlaceOrder(101, Burger);
        var expensive = manager.ExpensiveItems(300);

        Console.WriteLine("Expensive Items:");
        foreach (var f in expensive)
            Console.WriteLine(f.Name);
    }
}