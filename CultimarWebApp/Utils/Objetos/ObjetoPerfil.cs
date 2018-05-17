using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoPerfil
    {

        private int _idPerfil;
        private string _nombrePerfil;
        private string _descripcionPerfil;

        public int IdPerfil
        {
            get { return _idPerfil; }
            set { _idPerfil = value; }
        }

        public string NombrePerfil
        {
            get { return _nombrePerfil; }
            set { _nombrePerfil = value; }
        }

        public string DescripcionPerfil
        {
            get { return _descripcionPerfil; }
            set { _descripcionPerfil = value; }
        }


    }
}