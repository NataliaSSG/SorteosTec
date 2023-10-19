using System.ComponentModel.DataAnnotations;

public class UserDetailsModel 
{
    [Required(ErrorMessage = "Inserte su nombre de usuario por favor")]
    public string Username { get; set; }

     [Required(ErrorMessage = "Inserte su contraseña por favo")]
    public string Password { get; set; }
}
