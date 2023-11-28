﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using SorteosTec.Pages.Models;

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

    public async  Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var client = await apiClient.LogIn(UserDetails.Username, UserDetails.Password);

        if (client != null) {
            HttpContext.Session.SetString("username", client.username);
            HttpContext.Session.SetString("role", client.role);

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
}


