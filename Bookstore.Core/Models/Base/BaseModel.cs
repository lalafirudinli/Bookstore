using System;
namespace Bookstore.Core.Models.Base
{
	public class BaseModel
	{
		public int Id { get; set; }
		public string Name { get; set;}
		public DateTime CreatDate { get; set; }
		public DateTime UpdatedDate { get; set; }
	}
}

