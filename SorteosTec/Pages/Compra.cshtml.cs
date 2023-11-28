using System;
using System.Collections.Generic;
using System.Data;
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
        int clientid;
        public int productId { get; set; }
        ApiClient apiClient = new ApiClient();
        public void OnGet()
        {
            username = HttpContext.Session.GetString("username");
            role = HttpContext.Session.GetString("role");
            clientid = (int)HttpContext.Session.GetInt32("id");
            productId = int.Parse(Request.Query["ProductId"]);

            if (username == null || role == null) {
                Response.Redirect("/Index");
            }
        }

        public void OnPost()
        {
            username = HttpContext.Session.GetString("username");
            role = HttpContext.Session.GetString("role");
            clientid = (int)HttpContext.Session.GetInt32("id");
            productId = int.Parse(Request.Query["ProductId"]);
            if (username == null || role == null) {
                Response.Redirect("/Index");
            }
            
            apiClient.BuyProduct(clientid, productId);
            Response.Redirect("/Tienda");
        }

    }
}
