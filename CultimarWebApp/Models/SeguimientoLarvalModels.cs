using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Models
{
    public class SeguimientoLarvalModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cantidad De Larvas requerido")]
        [Display(Name = "Cantidad De Larvas")]
        public int CantidadDeLarvas { get; set; }

        [Required(ErrorMessage = "Larvas Calibre requerido")]
        [Display(Name = "Larvas Calibre")]
        public int CosechaLarvas { get; set; }

        [Required(ErrorMessage = "Numero Estanque requerido")]
        [Display(Name = "Numero Estanque")]
        public int NumeroEstanque { get; set; }

        [Required(ErrorMessage = "Densidad Cultivo requerido")]
        [Display(Name = "DensidadCultivo")]
        public int DensidadCultivo { get; set; }

        [Required(ErrorMessage = "Fecha Registro requerido")]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "Factores Medicion requerido")]
        [Display(Name = " Factores Medicion")]
        public string FactoresMedicion { get; set; }

        [Required(ErrorMessage = "Id Mortalidad requerido")]
        [Display(Name = "Id Mortalidad")]
        public int IdMortalidad { get; set; }

        [Required(ErrorMessage = "Estado requerido")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }




    }
}