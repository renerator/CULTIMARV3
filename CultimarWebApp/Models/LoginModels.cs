using CultimarWebApp.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CultimarWebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El Rut es requerido")]
        [DataType(DataType.Text)]
        //[RegularExpression(@"^([0-9]+-[0-9K])$", ErrorMessage = "El formato del Rut es inválido")]
        [Display(Name = "Rut Usuario")]
        public string Rut { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

    }
}