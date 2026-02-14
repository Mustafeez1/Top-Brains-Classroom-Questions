using System;

namespace BookStoreApplication
{
    public class BookUtility
    {
        private Book _book;

        public BookUtility(Book book)
        {
            // TODO: Assign book object
            _book = book;
        }

        public void GetBookDetails()
        {
            // TODO:
            // Print format:
            // Details: <BookId> <Title> <Price> <Stock>
            Console.WriteLine("Details ");
            Console.Write($"{_book.BookId}, {_book.BookTitle}, {_book.BookPrice}, {_book.Stock}");
            Console.WriteLine();
        }

        public void UpdateBookPrice(int newPrice)
        {
            // TODO:
            // Validate new price
            // Update price
            // Print: Updated Price: <newPrice>
            _book.BookPrice = newPrice;
            Console.WriteLine($"Updated Price: {_book.BookPrice}");
            
        }

        public void UpdateBookStock(int newStock)
        {
            // TODO:
            // Validate new stock
            // Update stock
            // Print: Updated Stock: <newStock>
            _book.Stock = newStock;
            Console.WriteLine($"Updated Stock: {_book.Stock}");
        }
    }
}
