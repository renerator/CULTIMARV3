using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoUbicacionOceanica
    {

        private int _idUbicacion;
        private string _nombreUbicacion;
        private bool _estado;

        public int IdUbicacion
        {
            get { return _idUbicacion; }
            set { _idUbicacion = value; }
        }

        public string NombreUbicacion
        {
            get { return _nombreUbicacion; }
            set { _nombreUbicacion = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


    }
}