using System;
using MySql.Data.MySqlClient;

public class MySQLConn
{
    private string username;
    private string password;
    public void setUserName(string username)
    {
        this.username = username;
    }
    public void setPassword(string password)
    {
        this.password = password;
    }
    private string Conn = $"Server=http://localhost:3306; Database=DBName; User=master; Password=Password";
    public bool Login()
    {
        MySqlConnection connection = new MySqlConnection(Conn);
        try 
        { 
            string Query = $"SELECT * FROM client WHERE username='{username}' AND password='{password}'";
            MySqlCommand comm = new MySqlCommand(Query, connection);
            using (MySqlDataReader reader = comm.ExecuteReader())
            {
                if (reader.Read())
                {
                    return true;
                }
            }

            connection.Open();
        } catch (Exception ex)
        {
            return false;
        }
        finally 
        {
            connection.Close();
        }
        return true;
    }
}