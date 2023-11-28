using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SorteosTec.Pages
{
    public class TiendaModel : PageModel
    {

        [BindProperty]
        public int ProductId { get; set; }

        public void OnGet()
        {
            ProductId = 0;
            string username = HttpContext.Session.GetString("username");
            string role = HttpContext.Session.GetString("role");

            if (username == null || role == null) {
                Response.Redirect("/Index");
            }
        }

        public void OnPost()
        {
            string username = HttpContext.Session.GetString("username");
            string role = HttpContext.Session.GetString("role");

            if (username == null || role == null) {
                Response.Redirect("/Index");
            }
            
            Response.Redirect($"Compra?ProductId={ProductId}");
        }
    }
}
