using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SorteosTec.Pages
{
	public class HomeModel : PageModel
    {
        public void OnGet()
        {
            string username = HttpContext.Session.GetString("username");
            string role = HttpContext.Session.GetString("role");

            if (username == null || role == null) {
                Response.Redirect("/Index");
            }
        }
    }
}
