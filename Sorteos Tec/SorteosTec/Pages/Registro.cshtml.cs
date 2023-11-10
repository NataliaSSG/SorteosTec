using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SorteosTec.Pages
{
	public class RegistroModel : PageModel
    {
        [BindProperty]
        public UserRegistryModel UserRegistry { get; set; }
        private readonly DatabaseModel db;

        public RegistroModel(){
            UserRegistry = new UserRegistryModel();

            //Base de datos
            string sqlCredentials = "server=localhost;user=root;password=06022003;database=TecTrek";
            db = new DatabaseModel(sqlCredentials);
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() {
            int gender;
            string genderString = UserRegistry.Gender;

            //Asignar un valor numérico a cada género
            switch (genderString)
            {
                case "Masculino":
                    gender = 0;
                    break;

                case "Femenino":
                    gender = 1;
                    break;

                case "Otro":
                    gender = 2;
                    break;

                default:
                    throw new Exception("El género seleccionado no es válido");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                db.InsertClient(UserRegistry.FullName, gender, UserRegistry.Email, UserRegistry.Username, UserRegistry.Password, UserRegistry.DateofBirth);
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
