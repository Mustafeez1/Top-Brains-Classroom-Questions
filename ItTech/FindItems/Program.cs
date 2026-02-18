using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    public static SortedDictionary<string, long> _itemDetails = new SortedDictionary<string, long>()
    {
        {"Pen", 120},
        {"Pencil", 180},
        {"Notebook", 250},
        {"Eraser", 60}
    };
    public SortedDictionary<string, long> FindItemDetails(long soldCount)
    {
        var result = new SortedDictionary<string, long>();
        // var count = _itemDetails.Values.Where(k =>k.Value == soldCount);
        foreach (var item in _itemDetails)
        {
            if(item.Value == soldCount)
            {
                result[item.Key] = item.Value;
            }
        }
        return result;
    }
    public List<string> FindMinandMaxSoldItems()
    {
        List<string> result = new List<string>();
        var min = _itemDetails.OrderBy(k=>k.Value).First();
        var max = _itemDetails.OrderByDescending(k=>k.Value).First();
        result.Add(min.Key);
        result.Add(max.Key);
        return result;
    }
    public Dictionary<string, long> SortByCount()
    {
        return _itemDetails.OrderBy(k=>k.Value).ToDictionary(kv=>kv.Key, kv=>kv.Value);
        
    }
    public static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine("Enter sold count to search:" );
        long count = long.Parse(Console.ReadLine());

        var output = program.FindItemDetails(count);
        if(output.Count == 0)
        {
            Console.WriteLine("Invalid sold count");
        }
        else
        {
            foreach (var i in output)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }
        }
        var output1 = program.FindMinandMaxSoldItems();
        foreach (var item in output1)
        {
            Console.WriteLine($"{item}");
        }
        var output2 = program.SortByCount();
        foreach (var item in output2)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }

    }
}