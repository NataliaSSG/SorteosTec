using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

using System.Text.RegularExpressions;

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
        public void InsertClient(string fullName, int gender, string email, string username, string password, DateTime dob)
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

                // En caso de que el correo no coincida con una nomina del tec, admin se mantiene en falso
                string clientQuery = "INSERT INTO client (first_name, last_name, sexo, email, username, user_password, birth_date) " +
                            "VALUES (@name, @lastName, @gender, @email, @username, @password, @dob)";
                
                // En caso de que el correo coincida con una nomina del tec, admin se cambia a true
                string adminQuery = "INSERT INTO client (first_name, last_name, sexo, email, username, user_password, birth_date, admin) " +
                            "VALUES (@name, @lastName, @gender, @email, @username, @password, @dob, true)";

                //Expresion regular para validar si el correo coincide con la nomina del tec
                string pattern = @"^E0[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                Regex regex =  new Regex(pattern);


                if (regex.IsMatch(email)) {
                    using (MySqlCommand command = new MySqlCommand(adminQuery, connection)) {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@dob", dob);

                        command.ExecuteNonQuery();
                    }
                }
                else {
                    using (MySqlCommand command = new MySqlCommand(clientQuery, connection)) {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@dob", dob);

                        command.ExecuteNonQuery();
                    }
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

                string query = "SELECT * FROM client WHERE (username = @username OR email = @username) AND user_password = @password";

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

