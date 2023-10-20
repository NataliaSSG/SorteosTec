using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// using MySql.Data.MySqlClient;

namespace SorteosTec.Pages;

public class IndexModel : PageModel
{
    [BindProperty] //Incluimos el tag para que Index.cshtml sea capaz de acceder a las propiedades de UserDetailsModel
    public UserDetailsModel UserDetails {get; set;}

    // public string Conn = $"Server={http://localhost:3306}; Database={DBName}; User={Username}; Password={Password}";
    // public bool Login()
    // {
    //     MySqlConnection connection = new MySqlConnection(Conn);
    //     try 
    //     { 
            
    //         connection.Open();
    //         return true;
    //     } catch (Exception ex)
    //     {

    //     }
    //     finally 
    //     {
    //         connection.Close();
            
    //     }
    // }

    public IndexModel( )
    {

        UserDetails = new UserDetailsModel(); //Objeto de la clase UserDetailsModel, para accdeer a sus propiedades
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Console.WriteLine($"Username: {UserDetails.Username}");
        Console.WriteLine($"Password: {UserDetails.Password}");

        bool containsUsername = UserDetails.testDict.ContainsKey(UserDetails.Username);
        if (containsUsername && UserDetails.testDict[UserDetails.Username] == UserDetails.Password)
        {
            return RedirectToPage("/Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
            return Page();
        }
    }
}
