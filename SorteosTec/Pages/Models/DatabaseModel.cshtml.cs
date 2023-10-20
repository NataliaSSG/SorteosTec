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
        public string  InsertClient(string fullName, string gender, string email, string username, string password)
        {
            string name, lastName;
            splitName(fullName, out name, out lastName);
            string Query = $"call Register_Player({name},{lastName},{gender},{email},{username},{password})";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(Query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read)
                    {
                        console.WriteLine(reader[0].message);
                        return reader[0].message;
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);                
            } finally {
                connection.Close();
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

                string query = "SELECT count(*) FROM client WHERE username = @username AND pw = @password";

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
