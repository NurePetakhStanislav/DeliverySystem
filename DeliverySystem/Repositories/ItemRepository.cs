using DeliverySystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Repositories
{
    internal class ItemRepository : BaseRepository
    {
        public List<Item> GetAllItems()
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"SELECT * FROM Items";

            using var cmd = new SqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();

            var list = new List<Item>();
            while (reader.Read())
            {
                list.Add(new Item
                {
                    Id = (int)reader["Items_id"],
                    OrderId = (int)reader["Order_id"],
                    ProductId = (int)reader["Product_id"],
                    Quantity = (int)reader["Quantity"]
                });
            }

            return list;
        }
    }
}
