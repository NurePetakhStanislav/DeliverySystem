using DeliverySystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliverySystem.Repositories
{
    internal class RoadRepository : BaseRepository
    {
        public List<Road> GetAllRoads()
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"SELECT * FROM Roads";

            using var cmd = new SqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();

            var list = new List<Road>();
            while (reader.Read())
            {
                string factors = reader["Delivery_factors"] as string ?? "[]";
                var factorsList = JsonSerializer.Deserialize<List<string>>(factors)
                                  ?? new List<string>();

                var from = (int)reader["From_street_id"];
                var to = (int)reader["To_street_id"];
                var distance = (int)reader["Distance"];

                list.Add(new Road
                {
                    FromStreetId = from,
                    ToStreetId = to,
                    Distance = distance,
                    DeliveryFactors = factorsList
                });

                list.Add(new Road
                {
                    FromStreetId = to,
                    ToStreetId = from,
                    Distance = distance,
                    DeliveryFactors = factorsList
                });
            }

            return list;
        }
    }
}
