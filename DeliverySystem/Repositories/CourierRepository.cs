using DeliverySystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Repositories
{
    internal class CourierRepository : BaseRepository
    {
        public List<Courier> GetAllCouriers()
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"SELECT * FROM Couriers";

            using var cmd = new SqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();

            var list = new List<Courier>();
            while (reader.Read())
            {
                list.Add(new Courier{
                    Id = (int)reader["Courier_id"],
                    FullName = $"{ reader["First_name"].ToString()} {reader["Last_name"].ToString()}",
                    Status = reader["Courier_status"].ToString(),
                    StreetId = (int)reader["Street_id"]
                });
            }

            var emptyCourier = new Courier
            {
                Id = -1,
                FullName = "-"
            };

            list.Insert(0, emptyCourier);

            return list;
        }

        public void UpdateStatus(int courierId, string status)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"
                UPDATE Couriers
                SET Courier_status = @status
                WHERE Courier_id = @id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@id", courierId);

            cmd.ExecuteNonQuery();
        }
    }
}
