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
    private string Conn = $"Server=localhost; Database=TecTrek; User=master; Password=masteruser!";
    public bool Login(string username, string password)
    {
        MySqlConnection connection = new MySqlConnection(Conn);
        
        try 
        {
            connection.Open(); 
            string Query = $"SELECT count(*) FROM client WHERE username='{username}' AND password='{password}'";
            MySqlCommand comm = new MySqlCommand(Query, connection);
            using (MySqlDataReader reader = comm.ExecuteReader())
            {
                if (reader.Read() && reader[0].ToString() == "1")
                {
                    return true;
                }
            }            
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
    public string Register(string name, string last_name, string gender, string email, string username, string password)
    {
        string username = this.username;
        string password = this.password;
        string name = "";
        string last_name = "";
        string email = "";
        MySqlConnection connection = new MySqlConnection(Conn);
        try 
        { 
            /* 
             * Change Query to use our stored procedure 
             * Maybe add confirmation mail by using the ms graph skd
             */
            string Query = $"call Register_Player({name, last_name, gender, email, username, password})";
            MySqlCommand comm = new MySqlCommand(Query, connection);
            connection.Open();
            using (MySqlDataReader reader = comm.ExecuteReader()){
                if (reader.Read()){
                    console.writeline(reader.ToString());
                    return reader.ToString();
                }
                else {
                    console.writeline("No data found");
                    return "No Data Found";
                
                }
            
            }
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