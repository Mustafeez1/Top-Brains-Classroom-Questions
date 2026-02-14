using System;

namespace BookStoreApplication
{
    public class Book
    {
        // TODO: Create public properties
        // Id -> string
        public string BookId { get; set; }
        // Title -> string
        public string BookTitle { get; set; }
        // Author -> string (Optional)
        // public string BookAuthor { get; set; }
        // Price -> int
        public int BookPrice { get; set; }
        // Stock -> int
        public int Stock { get; set; }

        // Example:
        // public string Id { get; set; }
        public Book(string id, string title, int price, int stock){
            BookId = id;
            BookTitle = title;
            BookPrice = price;
            Stock = stock;
        }
    }
}
