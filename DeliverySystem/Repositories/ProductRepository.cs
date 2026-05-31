using DeliverySystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Repositories
{
    internal class ProductRepository : BaseRepository
    {
        public List<Product> GetAllProducts()
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"SELECT * FROM Product";

            using var cmd = new SqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();

            var list = new List<Product>();
            while (reader.Read())
            {
                list.Add(new Product
                {
                    Id = (int)reader["Product_id"],
                    Name = reader["Name"].ToString(),
                    Price = (decimal)reader["Price"]
                });
            }

            return list;
        }
    }
}
