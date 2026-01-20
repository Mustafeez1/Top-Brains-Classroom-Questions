using System;
using System.Collections.Generic;
class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int, int> employees = new Dictionary<int, int>
        {
            {1, 20000},
            {4, 40000},
            {5, 15000}
        };

        int[] employeeId = {1, 4, 5};
        int total_salary = 0;
        foreach(var item in employeeId)
        {
            if (employees.ContainsKey(item))
            {
                total_salary += employees[item];
            }
        }
        Console.WriteLine($"{total_salary}");
 
    }

}