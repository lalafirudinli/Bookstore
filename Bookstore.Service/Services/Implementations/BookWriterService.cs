using System;
using Bookstore.Core.Models;
using Bookstore.Data.Repositories.BookWriters;
using Bookstore.Service.Services.Interfaces;

namespace Bookstore.Service.Services.Implementations
{
    public class BookWriterService : IBookWriterService
    {
        private readonly BookWriterRepository _repository = new BookWriterRepository();


        public async Task<string> CreateAsync(string name, string surname, int age)
        {   
            if (string.IsNullOrWhiteSpace(name))
             return "Add valid name";

            if (string.IsNullOrWhiteSpace(surname))
                return "Add valid surname";

            if (age <= 0)
                return "Add valid age";

            BookWriter bookWriter = new BookWriter(name, surname, age);
            _repository.AddAsync(bookWriter);
            return "successfully created";
        }

        public async Task<string> DeleteAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(bw => bw.Id == id);

            if (bookWriter == null)
             return "Book writer not found ";

           await  _repository.RemoveAsync(bookWriter);
             return " success ";
        }

        public async Task GetAllAsync()
        {
            foreach(var item in await _repository.GetAllAsync())
            {
                Console.WriteLine( item);
            }
        }

        public async Task<List<Book>> GetAllBooksAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(bw => bw.Id == id);

            if (bookWriter == null)
            {
                Console.WriteLine("Book writer not found");
                return null;

            }
            return bookWriter.Books;    
        }

        public async Task<BookWriter> GetAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(bw => bw.Id == id);

            if (bookWriter == null)
            {
                Console.WriteLine("Book writer not found");
                return null;

            }
            return bookWriter;
        }

        public async Task<string> UpdateAsync(int id, string name, string surname, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid name";

            if (string.IsNullOrWhiteSpace(surname))
                return "Add valid surname";

            if (age <= 0)
                return "Add valid age";

            BookWriter bookWriter = await _repository.GetAsync(bw => bw.Id == id);

            if (bookWriter == null)
               return "Book writer not found";

            bookWriter.Name = name;
            bookWriter.SurName = surname;
            bookWriter.Age = age;


            return "Updated";
            
        }
            
    } 
}

