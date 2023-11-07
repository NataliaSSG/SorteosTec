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
        public void InsertClient(string fullName, string gender, string email, string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string name, lastName;

                splitName(fullName, out name, out lastName);

                connection.Open();

                // Revisamos si el usuario esta presente en la base de datos
                string queryUsername = "SELECT COUNT(*) FROM client WHERE username = @username";
                using (MySqlCommand commandUsername = new MySqlCommand(queryUsername, connection))
                {
                    commandUsername.Parameters.AddWithValue("@username", username);

                    int countUsername = Convert.ToInt32(commandUsername.ExecuteScalar());

                    if (countUsername > 0)
                    {
                        throw new Exception("El nombre de usuario ya está en uso");
                    }
                }

                // Revisamos si el correo esta presente en la base de datos
                string queryEmail = "SELECT COUNT(*) FROM client WHERE email = @email";
                using (MySqlCommand commandEmail = new MySqlCommand(queryEmail, connection))
                {
                    commandEmail.Parameters.AddWithValue("@email", email);

                    int countEmail = Convert.ToInt32(commandEmail.ExecuteScalar());

                    if (countEmail > 0)
                    {
                        throw new Exception("El correo electrónico ya está en uso");
                    }
                }

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

        private void splitName(string fullName, out string name, out string lastName) {
            string[] split = fullName.Split(' ');
            name = split[0];
            lastName = split[1];
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
