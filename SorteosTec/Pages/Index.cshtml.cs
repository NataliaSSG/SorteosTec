using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SorteosTec.Pages;

public class IndexModel : PageModel
{
    [BindProperty] //Incluimos el tag para que Index.cshtml sea capaz de acceder a las propiedades de UserDetailsModel
    public UserDetailsModel UserDetails {get; set;}

    //Objeto de base de datos
    private readonly DatabaseModel db;
    

    public IndexModel( )
    {
        UserDetails = new UserDetailsModel(); //Objeto de la clase UserDetailsModel, para accdeer a sus propiedades

        //Base de datos
        string sqlCredentials = "server=localhost;user=root;password=06022003;database=TecTrek";
        db = new DatabaseModel(sqlCredentials);
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

        //Prints de prueba (Inicio de sesion con diccionario)
        // Console.WriteLine($"Username: {UserDetails.Username}");
        // Console.WriteLine($"Password: {UserDetails.Password}");

        bool containsUsername = UserDetails.testDict.ContainsKey(UserDetails.Username);

        //Los datos de inicio de sesion son correctos y estan en el diccionario??
        // if (containsUsername && UserDetails.testDict[UserDetails.Username] == UserDetails.Password)
        if (db.CheckCredentials(UserDetails.Username, UserDetails.Password))
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


