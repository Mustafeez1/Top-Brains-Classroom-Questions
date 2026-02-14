using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock
            Console.WriteLine("Enter book id");
            string id = Console.ReadLine();

            Console.WriteLine("Enter book title");
            string title = Console.ReadLine();

            Console.WriteLine("Enter book price");
            int price = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the stock value");
            int value = int.Parse(Console.ReadLine());


            Book book = new Book(id, title, price, value);

            BookUtility utility = new BookUtility(book);

            while (true)
            {
                // TODO:
                // Display menu:
                // 1 -> Display book details
                Console.WriteLine("1 -> Display book details");
                // 2 -> Update book price
                Console.WriteLine("2 -> Update book price");
                // 3 -> Update book stock
                Console.WriteLine("2 -> Update book stock");
                // 4 -> Exit
                Console.WriteLine("4 -> Exit");

                Console.WriteLine("Enter the choice");
                int choice = int.Parse(Console.ReadLine()); // TODO: Read user choice

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        // TODO:
                        // Read new price
                        Console.WriteLine("Enter new price");
                        int newPrice = int.Parse(Console.ReadLine());
                        // Call UpdateBookPrice()
                        utility.UpdateBookPrice(newPrice);
                        break;

                    case 3:
                        // TODO:
                        // Read new stock
                        Console.WriteLine("Enter new stock");
                        int stock = int.Parse(Console.ReadLine());
                        // Call UpdateBookStock()
                        utility.UpdateBookStock(stock);
                        break;

                    case 4:
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
}
