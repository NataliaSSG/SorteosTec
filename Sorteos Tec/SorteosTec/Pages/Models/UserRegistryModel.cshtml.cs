using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class UserRegistryModel
{
    [BindProperty]
    [Required(ErrorMessage = "Cree su nombre de usuario por favor")]
    public string Username { get; set; }
    
    [BindProperty]
    [Required(ErrorMessage = "Cree una contraseña por favor")]
    public string Password { get; set; }

    //Usamos una expresion regular para que los nombres siempre obedezcan el formato "nombre apellido"
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]+\s[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]+$", ErrorMessage = "El campo Nombre y Apellido debe tener el formato 'nombre apellido'")]
    [Required(ErrorMessage = "El campo Nombre y Apellido es obligatorio")]
    public string FullName { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Seleccione su género por favor")]
    public string Gender { get; set;}

    [BindProperty]
    [EmailAddress(ErrorMessage = "Inserte un correo válido por favor")]
    public string Email { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Inserte su fecha de nacimiento por favor")]
    [DataType(DataType.Date)]
    public DateTime DateofBirth { get; set; }
}
