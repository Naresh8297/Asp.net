using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace YourProjectNamespace.Data
{
    public class ProductRepository
    {
        private readonly IDbConnection _db;

        public ProductRepository(IDbConnection db)
        {
            _db = db;
        }

        public List<Product> GetAllProducts()
        {
            string query = "SELECT * FROM Products";
            return _db.Query<Product>(query).ToList();
        }

        public void AddProduct(Product product)
        {
            string query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
            _db.Execute(query, product);
        }

        public void UpdateProduct(Product product)
        {
            string query = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
            _db.Execute(query, product);
        }

        public void DeleteProduct(int productId)
        {
            string query = "DELETE FROM Products WHERE Id = @Id";
            _db.Execute(query, new { Id = productId });
        }
    }
}

