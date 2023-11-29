using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using SorteosTec.Pages.Models;
using System.Net;

namespace SorteosTec.Pages;

public class IndexModel : PageModel
{
    [BindProperty] //Incluimos el tag para que Index.cshtml sea capaz de acceder a las propiedades de UserDetailsModel
    public UserDetailsModel UserDetails {get; set;}

    //Objeto de base de datos
    private readonly ApiClient apiClient;
    
    public IndexModel( )
    {
        UserDetails = new UserDetailsModel(); //Objeto de la clase UserDetailsModel, para accdeer a sus propiedades

        //Base de datos
        apiClient = new ApiClient();
    }

    public void OnGet()
    {
    
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var client = await apiClient.LogIn(UserDetails.Username, UserDetails.Password);

            if (client != null) {
                HttpContext.Session.SetString("username", client.username);
                HttpContext.Session.SetString("role", client.role);
                HttpContext.Session.SetInt32("id", client.id_client);

                await apiClient.SetSessionData(client.username, client.role, client.id_client);

                if (client.role == "Admin") {
                    return RedirectToPage("/Dashboard");
                } 
                else if (client.role == "Cliente") {
                    return RedirectToPage("/Home");
                }
                else {
                    return Page();
                }
            } 
            else {
                return Page();
            }
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            ModelState.AddModelError(string.Empty, "Usuario y/o contraseña incorrectos");
            return Page();
        }
        catch (System.Exception)
        {
            ModelState.AddModelError(string.Empty, "Usuario y/o contraseña incorrectos");
            return Page();
        }
    }
}


