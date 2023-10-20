using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class UserDetailsModel 
{
    [BindProperty]
    [Required(ErrorMessage = "Inserte su nombre de usuario por favor")]
    public string Username { get; set; }
    
    [BindProperty]
    [Required(ErrorMessage = "Inserte su contraseña por favor")]
    public string Password { get; set; }

    public Dictionary<string, string> testDict { get; set; }

    public UserDetailsModel() //Inicializamos el diccionario dentro de el constructor de la clase
    {
        testDict = new Dictionary<string, string>()
        {
            {"root", "root"},
        };
    }
}
