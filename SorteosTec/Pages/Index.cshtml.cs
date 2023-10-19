using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace SorteosTec.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }
    [BindProperty]
    public string Password { get; set; }
    public string Result {get; set;}
    public string Conn = $"Server={http://localhost:3306}; Database={DBName}; User={Username}; Password={Password}";
    public bool Login()
    {
        MySqlConnection connection = new MySqlConnection(Conn);
        try 
        { 
            
            connection.Open();
            return true;
        } catch (Exception ex)
        {

        }
        finally 
        {
            connection.Close();
            
        }
    }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}

