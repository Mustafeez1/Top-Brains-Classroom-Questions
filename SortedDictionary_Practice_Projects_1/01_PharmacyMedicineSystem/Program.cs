using System;
// using Services;
// using Domain;
using System.Collections.Generic;
// namespace ConsoleApp
// {
    class Program
    {
        static void Main(string[] args)
        {
            Medicine medicine = new Medicine("101", "Khan", 1000, 2024);
            MedicineUtility service = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Update");
                
                Console.WriteLine("5. Exit");

                // TODO: Read user choice
                Console.WriteLine("Enter Choice");
                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:

                        service.GetAllMedicines();
                        break;
                    case 2:
                        medicine = new Medicine("102", "Musta", 1900, 2027);
                        service.AddMedicine(medicine);

                        // TODO: Add entity
                        break;
                    case 3:
                        service.UpdateMedicinePrice("102", 2300);
                        
                        // TODO: Update entity
                        break;
                    case 5:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
// }
