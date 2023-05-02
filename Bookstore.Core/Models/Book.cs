
using Bookstore.Core.Enums;
using Bookstore.Core.Models.Base;

namespace Bookstore.Core.Models
{
	public class Book :BaseModel   
	{
        private static int _id;
        public double Price { get; set; }
        public double Discount { get; set; }
        public BookCategory Category { get; set; }
        public BookWriter BookWriter { get; }
        public bool BookInStock { get; set; }
       

        public Book(string name, double price, double discountprice, BookCategory category,BookWriter bookWriter, bool InStock)
        {
            _id++;
            Id = _id;

            Name = name;
            Price = price;
            Discount = discountprice; 
            Category = category;
            BookWriter = bookWriter;
            BookInStock = InStock;
        }

        public override string ToString()
        {
            if (Discount < Price) 
            {
                return $"There is  {Price - Discount}  discount, Name:{Name},Price: {Discount}, category:{Category}, bookwriter {BookWriter} , DateTime:{CreatDate}, update:{UpdatedDate},InStock :{BookInStock}";
            }
            return $"Name:{Name},Price: {Price}, category:{Category}, bookwriter {BookWriter} , DateTime:{CreatDate}, update:{UpdatedDate}, InStock :{BookInStock}";
        }
    }    
}

  