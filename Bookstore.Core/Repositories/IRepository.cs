﻿using System;
using Bookstore.Core.Models.Base;

namespace Bookstore.Core.Repositories
{
	public interface IRepository<T> where T: BaseModel
	{
		public Task AddAsync(T model);

        public Task<T> GetAsync(Func<T, bool> expression);

		public Task<List<T>> GetAllAsync();
		  
		public Task RemoveAsync(T model);
	}
} 