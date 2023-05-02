using System;
using Bookstore.Core.Enums;
using Bookstore.Core.Models;

namespace Bookstore.Service.Services.Interfaces
{
    public interface IBookService
    {
        public Task<string> CreateAsync(int id, string name, double price, double discount, BookCategory category, bool InStock);
        public Task<string> DeleteAsync(int bookId, int bwId);
        public Task<string> UpdateAsync(int bookId, int bwId, string name, double price, double discount,BookCategory category);
        public Task<Book> GetAsync(int bookId, int bwId);
        public Task<string> BuyBookAsync(int bwId, int bookId, bool InStock);

    }
}

