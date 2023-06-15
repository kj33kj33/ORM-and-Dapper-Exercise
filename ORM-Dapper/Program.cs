using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection connection = new MySqlConnection(connString);

            var repo = new DapperProductRepo(connection);

            //repo.CreateProduct("Diablo IV", 59.99, 8);

            var products = repo.GetAllProducts();

            foreach(var product in products)
            {
                Console.WriteLine($"{product.Name} | {product.Price} | {product.ProductID}");
            }

            //repo.DeleteProduct(940);

            //repo.UpdateProductName(942, "Apple");
        }
    }
}
