using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CultimarWebApp.Models
{
    public class UsuariosModels
    {
        [Required(ErrorMessage = "El Rut es requerido")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^([0-9]+-[0-9K])$", ErrorMessage = "El formato del Rut es inválido")]
        [Display(Name = "Rut Usuario")]
        public string Rut { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Apellido")]
        public string ApellidoUsuario { get; set; }
    }
}