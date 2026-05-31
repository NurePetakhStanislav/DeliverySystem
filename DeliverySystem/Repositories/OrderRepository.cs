using DeliverySystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Repositories
{
    internal class OrderRepository : BaseRepository
    {
        public List<Order> GetAllOrders()
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"SELECT * FROM Orders";

            using var cmd = new SqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();

            List<Order> list = new();
            while (reader.Read())
            {
                list.Add(new Order
                {
                    Id = (int)reader["Order_id"],
                    PaymentMethod = reader["Payment_method"].ToString(),
                    CourierId = reader["Courier_id"] == DBNull.Value
                        ? null
                        : (int)reader["Courier_id"],
                    FromStreetId = (int)reader["From_street_id"],
                    ToStreetId = (int)reader["To_street_id"],
                    OrderStatus = reader["Order_status"].ToString(),
                    CreatedAt = (DateTime)reader["Created_at"],
                    DeliveredAt = reader["Delivered_at"] == DBNull.Value
                        ? null
                        : (DateTime)reader["Delivered_at"],
                    ProductPrice = (decimal)reader["Product_price"],
                    DeliveryFee = (decimal)reader["Delivery_fee"],
                    RewardFee = (decimal)reader["Reward_fee"],
                    TotalPrice = (decimal)reader["Total_price"]
                });
            }

            return list;
        }
    }
}
