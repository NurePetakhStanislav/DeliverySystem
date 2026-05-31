using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DeliverySystem.Repositories
{
    internal class BaseRepository
    {
        protected string connectionString = "Server=.\\SQLEXPRESS;Database=DeliverySystemDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public bool TestConnection()
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                return conn.State == ConnectionState.Open;
            }
            catch
            {
                return false;
            }
        }
    }
}
