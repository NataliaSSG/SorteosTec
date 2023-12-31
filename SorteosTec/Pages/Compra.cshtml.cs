﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SorteosTec.Pages.Models;
using TecTrekAPI.Models;

namespace SorteosTec.Pages
{
	public class CompraModel : PageModel
    {
        string username, role; 
        int clientid;
        public int productId { get; set; }
        ApiClient apiClient = new ApiClient();

        public async Task OnGet()
        {
            productId = int.Parse(Request.Query["ProductId"]);
            Console.WriteLine(productId);

            ItemsModel item = await apiClient.GetItem(productId);
            Console.WriteLine(item.description);
            
            username = HttpContext.Session.GetString("username");
            role = HttpContext.Session.GetString("role");

            if (username == null || role == null) {
                Response.Redirect("/Index");
            }

            clientid = (int)HttpContext.Session.GetInt32("id");

            ViewData["Description"] = item.description;
            ViewData["RealPrice"] = item.item_real_price;
            ViewData["VirtualPrice"] = item.item_virtual_price;
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
