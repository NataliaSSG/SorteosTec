using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SorteosTec.Models
{
    public class UserAddressModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Selecciona tu estado de procedencia por favor")]
        public string Estado { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Escribe tu municipio de procedencia por favor")]
        public string Municipio { get; set; }
    }
}

