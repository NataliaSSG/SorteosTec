using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace SorteosTec.Pages
{
    public class DatabaseModel : PageModel
    {
        private readonly string connectionString;

        public DatabaseModel(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Register
        public void InsertClient(string name, string lastName, string gender, string email, string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO client (name, last_name, gender, email, username, pw) " +
                            "VALUES (@name, @lastName, @gender, @email, @username, @password)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    command.ExecuteNonQuery();
                }
            }
        }

        //Index
        public bool CheckCredentials(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM client WHERE username = @username AND pw = @password";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
