public class FoodManager
{
    private List<FoodItem> _menu = new List<FoodItem>();
    private Dictionary<int, List<FoodItem>> _orders = new Dictionary<int, List<FoodItem>>();
    private HashSet<string> _codes = new HashSet<string>();
    public void AddMenuItem(FoodItem item)
    {
        if (_codes.Contains(item.Code))
        {
            return;
        }
        _codes.Add(item.Code);
        _menu.Add(item);
        Console.WriteLine($"{item.Name} has been added");
    }
    public void PlaceOrder(int orderId, FoodItem item)
    {
        if (!_orders.ContainsKey(orderId))
        {
            _orders[orderId] = new List<FoodItem>();
           
        }
        _orders[orderId].Add(item);
        Console.WriteLine($"{item.Name} order placed");
    }
    public IEnumerable<FoodItem> ExpensiveItems(double price)
    {
        return _orders.Values.SelectMany(k => k).Where(m => m.Price> price);
    }
}