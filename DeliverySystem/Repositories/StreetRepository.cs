using DeliverySystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Repositories
{
    internal class StreetRepository : BaseRepository
    {
        public List<Street> GetAllStreets()
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"SELECT * FROM Streets";

            using var cmd = new SqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();

            var list = new List<Street>();
            while (reader.Read())
            {
                list.Add(new Street
                {
                    Id = (int)reader["Street_id"],
                    Name = reader["Name_street"].ToString()
                });
            }

            return list;
        }
    }
}
