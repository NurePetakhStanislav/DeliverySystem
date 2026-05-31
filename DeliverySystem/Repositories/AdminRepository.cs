using DeliverySystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Repositories
{
    internal class AdminRepository : BaseRepository
    {
        public void Register(string nickname, string password)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"
                INSERT INTO Admins (Nickname, Hash_password)
                VALUES (@nick, @pass)";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nick", nickname);

            string hashPassword = HashPassword(password);
            cmd.Parameters.AddWithValue("@pass", hashPassword);

            cmd.ExecuteNonQuery();
        }

        public static string HashPassword(string password)
        {
            return Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(password))
            );
        }

        public bool AdminExists()
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"
                SELECT COUNT(1)
                FROM Admins";

            using var cmd = new SqlCommand(query, conn);

            int count = (int)cmd.ExecuteScalar();

            return count > 0;
        }

        public Admin? GetAdmin(string nickname)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            string query = @"
                SELECT Admin_id, Nickname, Hash_password
                FROM Admins
                WHERE Nickname = @nick";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nick", nickname);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Admin
                {
                    Id = (int)reader["Admin_id"],
                    Nickname = reader["Nickname"].ToString(),
                    HashPassword = reader["Hash_password"].ToString()
                };
            }

            return null;
        }

        public bool Login(string nickname, string password)
        {
            var admin = GetAdmin(nickname);

            if (admin == null)
                return false;

            string hash = HashPassword(password);

            return admin.HashPassword == hash;
        }
    }
}
