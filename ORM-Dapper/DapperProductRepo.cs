using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
	public class DapperProductRepo : IProductRepo
	{
        private readonly IDbConnection _connection;
		public DapperProductRepo(IDbConnection connection)
		{
            _connection = connection;
		}

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID)"
                + "VALUES (@name, @price, @categoryID)",
                new { @name = name, @price = price, @categoryID = categoryID});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;").ToList();
        }

        public void UpdateProductName(int productID, string newName)
        {
            _connection.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productID;",
                new { newName = newName, productID = productID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID",
                new { productID = productID });
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID",
                new { productID = productID });
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID",
                new { productID = productID });
        }
    }
}

