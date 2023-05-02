
using Bookstore.Core.Enums;
using Bookstore.Core.Models;
using Bookstore.Data.Repositories.BookWriters;
using Bookstore.Service.Services.Interfaces;

namespace Bookstore.Service.Services.Implementations
{
    public class BookService : IBookService
    
    {
        private readonly BookWriterRepository _repository = new BookWriterRepository();
       

        public async Task<string> CreateAsync(int id,string name , double price, double discount, BookCategory category, bool InStock)
        {
            BookWriter bookWriter = await _repository.GetAsync(bw => bw.Id == id);

            if(bookWriter == null)
            {
                return "Invalid options";
            }

            if ( await ValidateBook(name, price, discount,category)!=null)
            {
                return (await ValidateBook(name, price, discount, category));
            }

            Book book = new Book(name, price, discount, category, bookWriter,true);

            bookWriter.Books.Add(book);
            return "Created";
            
        }

        public async Task<string> DeleteAsync(int bookId, int bwId)
        {
            BookWriter bookWriter = await _repository.GetAsync(bw => bw.Id == bwId);

            if (bookWriter == null)
                return "Book writer not found";

            Book book = bookWriter.Books.FirstOrDefault(book => book.Id == bookId);

            if (book == null)
                return "Book not found";

            bookWriter.Books.Remove(book);


            return "Deleted ";

        }

        public async Task<Book> GetAsync(int bookId, int bwId)
        {
            BookWriter bookWriter = await _repository.GetAsync(bw => bw.Id == bwId);

            if (bookWriter == null)
            {
                Console.WriteLine("Book writer not found");
                return null;
            }

            Book book = bookWriter.Books.FirstOrDefault(book => book.Id == bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return null;
            }

            return book;

        }

        public async Task<string> UpdateAsync(int bookId, int bwId, string name, double price, double discount,BookCategory category)
        {
            BookWriter bookWriter = await _repository.GetAsync(bw => bw.Id == bwId);

            if (bookWriter == null)
                return "Book writer not found";

            if (!string.IsNullOrEmpty( await ValidateBook(name , price , discount,category)))
            {
                return (await ValidateBook(name, price, discount,category));
            }

            Book book = bookWriter.Books.FirstOrDefault(book => book.Id == bookId);

            book.Name = name;
            book.Price = price;
            book.Discount = discount;



            return " Updated ";
        }

        public async Task<string> BuyBookAsync(int bwId, int bookId, bool InStock)
        {
            BookWriter bookWriter = await _repository.GetAsync(bw => bw.Id == bwId);

            if (bookWriter == null)
                return "Book Writer not found ";
            Book book = bookWriter.Books.FirstOrDefault(book => book.Id == bookId);

            if (book == null)
                return "Book is not found ";

            if (!book.BookInStock)
                return "Book is not instock";

            return "Successfully bought";

        }

        private async Task<string> ValidateBook(string name, double price, double discount, BookCategory category)
        { 
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid name";

            if (price <= 0)
                return "Add valid price";

            if (discount > price || discount <= 0)
                return "Add valid discount price";

            return " ";

        }

    }
}

