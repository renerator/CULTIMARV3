using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoTipoContenedor
    {
        private int _idTipoContenedor;
        private string _nombreContendor;
        private string _tipoContendor;
        private bool _estado;

        public int IdContenedor
        {
            get { return _idTipoContenedor; }
            set { _idTipoContenedor = value; }
        }

        public string NombreContenedor
        {
            get { return _nombreContendor; }
            set { _nombreContendor = value; }
        }

        public string TipoContenedor
        {
            get { return _tipoContendor; }
            set { _tipoContendor = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}