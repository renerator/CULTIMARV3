using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoFactorMedicion
    {
        private int _IdTipoMedicion;
        private string _NombreMedicion; 
        private bool _Estado; 

        public int  IdTipoMedicion { get { return _IdTipoMedicion; } set { _IdTipoMedicion = value; } }
        public string NombreMedicion { get { return _NombreMedicion; } set { _NombreMedicion = value; } }
        public bool Estado { get { return _Estado; } set { _Estado = value; } }

    }
}