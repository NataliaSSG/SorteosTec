using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SorteosTec.Pages.Models;

namespace SorteosTec.Pages
{
	public class CompraModel : PageModel
    {
        string username, role; 
        int id, productId;
        ApiClient apiClient = new ApiClient();
        public void OnGet()
        {
            username = HttpContext.Session.GetString("username");
            role = HttpContext.Session.GetString("role");
            int id = (int)HttpContext.Session.GetInt32("id");
            int productId = int.Parse(Request.Query["ProductId"]);

            if (username == null || role == null) {
                Response.Redirect("/Index");
            }
        }

        public void OnPost()
        {
            string username = HttpContext.Session.GetString("username");
            string role = HttpContext.Session.GetString("role");
            int id = (int)HttpContext.Session.GetInt32("id");

            if (username == null || role == null) {
                Response.Redirect("/Index");
            }
            
            apiClient.BuyProduct(id, productId);
            Response.Redirect("/Tienda");
        }

    }
}
