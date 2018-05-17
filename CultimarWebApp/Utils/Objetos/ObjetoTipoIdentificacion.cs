using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoTipoIdentificacion
    {
        private int _idTipoIdentificacion;
        private string _nombreIdentificacion;
        private bool _estado;

        public int IdIdentificacion
        {
            get { return _idTipoIdentificacion; }
            set { _idTipoIdentificacion = value; }
        }

        public string NombreIdentificacion
        {
            get { return _nombreIdentificacion; }
            set { _nombreIdentificacion = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}