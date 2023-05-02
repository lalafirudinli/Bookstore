using System;
using System.Net;
using System.Reflection.Metadata;
using Bookstore.Core.Enums;
using Bookstore.Core.Models;
using Bookstore.Core.Models.Base;
using Microsoft.VisualBasic;

namespace Bookstore.Service.Services.Implementations
{
    public class MenuService
    {
        public bool IsAdmin = false;
        private AdminUser[] AdminUsers = { new AdminUser { Username = "Lala", Password = "Lello" }, new AdminUser { Username = "admin", Password = "admin" } };

         

        private BookWriterService BookWriterService = new BookWriterService();
        private BookService BookService = new BookService();

        public async Task<bool> Login()
        {
            Console.WriteLine("Add Username");
            string username = Console.ReadLine();
            Console.WriteLine("Add password");
            string password = Console.ReadLine();
            if (AdminUsers.Any(x => x.Username == username && x.Password == password))
            {
                IsAdmin = true;

            }
            else
            {
                Console.WriteLine("Username or password incorrect");
                IsAdmin = false;
            }
            return IsAdmin;
        }



        public async Task ShowMenuByAdmin() 
        {
            string sentence = "Welcome BOOK APP";

            foreach (var item in sentence)
            {
            Thread.Sleep(100);
            Console.WriteLine(item);

            }

            Console.WriteLine("0.Close App");
            Console.WriteLine("1.Create BookWriter");
            Console.WriteLine("2.Show BookWriter");
            Console.WriteLine("3.Show BookWriter by id");
            Console.WriteLine("4.Show BookWriter's books");
            Console.WriteLine("5.Update BookWriter");
            Console.WriteLine("6.Remove BookWriter");
            Console.WriteLine("7.Create Book");
            Console.WriteLine("8.Update Book  ");
            Console.WriteLine("9.Get Book by BookWriter");
            Console.WriteLine("10.Remove Book ");
            Console.WriteLine("11.Buy Book");

            string Request = Console.ReadLine();

            while (Request != "0")
            {
                switch (Request)
                {
                    case "1":
                        Console.Clear();
                        await CreateBookWriter();
                        break;
                    case "2":
                        Console.Clear();
                        await ShowBookWriters();
                        break;
                    case "3":
                        Console.Clear();
                        await ShowBookWriterById();
                        break;

                    case "4":
                        Console.Clear();
                        await ShowBookWriterbooks();
                        break;
                    case "5":
                        Console.Clear();
                        await UpdateBookWriter();
                        break;
                    case "6":
                        Console.Clear();
                        await RemoveBookWriter();
                        break;
                    case "7":
                        Console.Clear();
                        await CreateBook();
                        break;
                    case "8":
                        Console.Clear();
                        await UpdateBook();
                        break;
                    case "9":
                        Console.Clear();
                        await GetBookbyBookWriter();
                        break;
                    case "10":
                        Console.Clear();
                        await RemoveBook();
                        break;
                    case "11":
                        Console.Clear();
                        await BuyBook();
                        break;

                    default:
                        Console.WriteLine("Choose valid option");
                        break;
                }

                Console.WriteLine("0.Close App");
                Console.WriteLine("1.Create BookWriter");
                Console.WriteLine("2.Show BookWriter");
                Console.WriteLine("3.Show BookWriter by id");
                Console.WriteLine("4.Show BookWriter's books");
                Console.WriteLine("5.Update BookWriter");
                Console.WriteLine("6.Remove BookWriter");
                Console.WriteLine("7.Create Book");
                Console.WriteLine("8.Update Book  ");
                Console.WriteLine("9.Get Book by BookWriter");
                Console.WriteLine("10.Remove Book ");
                Console.WriteLine("11.Buy Book");

                Request = Console.ReadLine();
            }
        }
         
        public async Task ShowMenuByUser()
        {
            string sentence = "Welcome BOOK APP";
            Console.CursorSize = 100;

            foreach (var item in sentence)

            Console.WriteLine("0.Close App");     
            Console.WriteLine("1.Show BookWriter");
            Console.WriteLine("2.Show BookWriter by id");
            Console.WriteLine("3.Show BookWriter's books");
            Console.WriteLine("4.Get Book by BookWriter");    
            Console.WriteLine("5.Buy Book");

            string Request = Console.ReadLine();

            while (Request != "0")
            {
                switch (Request)
                {
                    case "1":
                        Console.Clear();
                        await ShowBookWriters();
                        break;
                    case "2":
                        Console.Clear();
                        await ShowBookWriterById();
                        break;
                    case "3":
                        Console.Clear();
                        await ShowBookWriterbooks();
                        break;
                    case "4":
                        Console.Clear();
                        await GetBookbyBookWriter();
                        break;
                    case "5":
                        Console.Clear();
                        await BuyBook();
                        break;

                    default:
                        Console.WriteLine("Choose valid option");
                        break;

                }

                Console.WriteLine("0.Close App");
                Console.WriteLine("1.Create BookWriter");
                Console.WriteLine("2.Show BookWriter");
                Console.WriteLine("3.Show BookWriter by id");
                Console.WriteLine("4.Show BookWriter's books");
                Console.WriteLine("5.Update BookWriter");
                Console.WriteLine("6.Remove BookWriter");
                Console.WriteLine("7.Create Book");
                Console.WriteLine("8.Update Book  ");
                Console.WriteLine("9.Get Book by BookWriter");
                Console.WriteLine("10.Remove Book ");
                Console.WriteLine("11.Buy Book");

                Request = Console.ReadLine();
            }
        }

        private async Task CreateBookWriter()
        {
            Console.WriteLine("Add name");
            string name = Console.ReadLine();

            Console.WriteLine("Add Surname");
            string surname = Console.ReadLine();

            Console.WriteLine("Add Age");
            int.TryParse(Console.ReadLine(), out int age);


            string message = await BookWriterService.CreateAsync(name, surname, age);
            Console.WriteLine(message);
        }

        private async Task ShowBookWriters()
        {
            await BookWriterService.GetAllAsync();
        }

        private async Task ShowBookWriterById()
        {

            Console.WriteLine("Add Writer Id");
            int.TryParse(Console.ReadLine(), out int Id);


            BookWriter bookWriter = await BookWriterService.GetAsync(Id);
            if (BookWriterService != null)

                Console.WriteLine(bookWriter);
        }
        
        private async Task ShowBookWriterbooks()
        {
            Console.WriteLine("Add Book writer Id");
            int.TryParse(Console.ReadLine(), out int id);

            List<Book> books = await BookWriterService.GetAllBooksAsync(id);

            if (books != null)
            {
                foreach (var item in books)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("---------");
                }
            }


        }

        private async Task UpdateBookWriter()
        {
            Console.WriteLine("Add Writer Id");
            int.TryParse(Console.ReadLine(), out int Id);

            Console.WriteLine("Add name");
            string name = Console.ReadLine();

            Console.WriteLine("Add Surname");
            string surname = Console.ReadLine();

            Console.WriteLine("Add Age");
            int.TryParse(Console.ReadLine(), out int age);

            string message = await BookWriterService.UpdateAsync(Id, name, surname, age);
            Console.WriteLine(message);
        }

        private async Task RemoveBookWriter()
        {
            Console.WriteLine("Add Writer Id");
            int.TryParse(Console.ReadLine(), out int Id);


            string message = await BookWriterService.DeleteAsync(Id);
            if (BookWriterService != null)

                Console.WriteLine(message);
        }

        private async Task CreateBook()
        {
            Console.WriteLine("Add Book id ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Add name");
            string name = Console.ReadLine();

            Console.WriteLine("Add price");
            int.TryParse(Console.ReadLine(), out int price);

            Console.WriteLine("Add discount price");
            int.TryParse(Console.ReadLine(), out int discount);

            Console.WriteLine("Add Category");
            string category = Console.ReadLine();

            Console.WriteLine("Instock ?");
            bool.TryParse(Console.ReadLine(), out bool Instock);

           

            BookCategory Category;

            Console.WriteLine("Choose category");

            foreach (var item in Enum.GetValues(typeof(BookCategory)))
            {
                Console.WriteLine((int)item + "." + item);
            }

            int.TryParse(Console.ReadLine(), out int categoryindex);

            var result = Enum.GetName(typeof(BookCategory), categoryindex);

            while (result==null)
            {
                Console.WriteLine("Choose valid category");
                int.TryParse(Console.ReadLine(), out categoryindex);
                result = Enum.GetName(typeof(BookCategory), categoryindex);
            }
            Category = (BookCategory)categoryindex;

            string message = await BookService.CreateAsync( id, name, price, discount, Category, Instock);
            Console.WriteLine(message);
        }

        private async Task UpdateBook()
        {
            Console.WriteLine("Add Book id ");
            int.TryParse(Console.ReadLine(), out int bookid);

            Console.WriteLine("Add Book Writer id ");
            int.TryParse(Console.ReadLine(), out int bwid);

            Console.WriteLine("Add name");
            string name = Console.ReadLine();

            Console.WriteLine("Add price");
            int.TryParse(Console.ReadLine(), out int price);

            Console.WriteLine("Add discount price");
            int.TryParse(Console.ReadLine(), out int discount);

            BookCategory category;
            Console.WriteLine("Choose category");

            foreach (var item in Enum.GetValues(typeof(BookCategory)))
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int categoryindex);
            bool result = Enum.IsDefined(typeof(BookCategory), categoryindex);

            while (!result)
            {
                Console.WriteLine("Choose valid Category");
                int.TryParse(Console.ReadLine(), out categoryindex);
            }
            category = (BookCategory)categoryindex;

            string message = await BookService.UpdateAsync(bookid,bwid,name, price,discount, category);

            Console.WriteLine(message);
        }

        private async Task GetBookbyBookWriter()
        {
            Console.WriteLine("Add Book id ");
            int.TryParse(Console.ReadLine(), out int bookId);

            Console.WriteLine("Add Book Writer id ");
            int.TryParse(Console.ReadLine(), out int bwid);

            Book book = await BookService.GetAsync(bwid,bookId);
            if(book!= null)
            {
                Console.WriteLine(book);
            }

        }

        private async Task RemoveBook()
        {
            Console.WriteLine("Add Book id ");
            int.TryParse(Console.ReadLine(), out int bookId);

            Console.WriteLine("Add Book Writer id ");
            int.TryParse(Console.ReadLine(), out int bwid);

            string message = await BookService.DeleteAsync(bwid, bookId);

            Console.WriteLine(message);
        }

        private async Task BuyBook()
        {
            Console.WriteLine("Add BookWriter Id");
            int.TryParse(Console.ReadLine(), out int bwId);
            Console.WriteLine("Add BookWriter BookId ");
            int.TryParse(Console.ReadLine(), out int bookId);
            bool.TryParse(Console.ReadLine(), out bool InStock);

            string message = await BookService.BuyBookAsync(bwId, bookId, InStock);

            Console.WriteLine(message);


        }

    }



	
}

