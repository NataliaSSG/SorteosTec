using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SorteosTec.Models;
using SorteosTec.Pages.Models;

namespace SorteosTec.Pages
{
	public class RegistroModel : PageModel
    {
        [BindProperty]
        public UserRegistryModel UserRegistry { get; set; }
        
        [BindProperty]
        public UserAddressModel UserAddress { get; set; }

        private readonly ApiClient apiClient;

        public RegistroModel(){
            UserRegistry = new UserRegistryModel();
            UserAddress = new UserAddressModel();

            // API helper
            apiClient = new ApiClient(); 
        }

        public void OnGet()
        {
        }

        public async Task <IActionResult> OnPost() {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await apiClient.CreateClienteAndAddress(UserRegistry.FullName, UserRegistry.Gender, UserRegistry.Username, UserRegistry.Password, UserRegistry.DateofBirth, UserRegistry.Email, UserAddress.Estado, UserAddress.Municipio);
                Console.WriteLine("Client inserted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
