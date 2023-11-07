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
    private bool Parse_Mail(){
        //Parse email using regex by (text)@(text).(text)
        return true;
    }
    private void Parse_Date_Register(){
        //Add parse birthdate from dd-mm-yyyy and separate them 
    }
    public bool Register()
    {
        string username = this.username;
        string password = this.password;
        string name = "";
        string last_name = "";
        string email = "";
        MySqlConnection connection = new MySqlConnection(Conn);
        try 
        { 
            //Add parameters name, last name, gender, email, username, password. and read them from the register page
            //Call stored procedure that checks if user is not in the database so 
            /* 
             * Change Query to use our stored procedure 
             * Maybe add confirmation mail by using the ms graph skd
             */
            string Query = $"INSERT INTO client (username, password) VALUES ('{username}', '{password}')";
            MySqlCommand comm = new MySqlCommand(Query, connection);
            connection.Open();
            comm.ExecuteNonQuery();
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