using System;
using System.Collections.Generic;
namespace ORM_Dapper
{
	public interface IProductRepo
	{
		public IEnumerable<Product> GetAllProducts();

		public void CreateProduct(string name, double price, int categoryID);
	}
}

