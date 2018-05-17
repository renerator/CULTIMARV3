using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoDestinoDespacho
    {
        private int _idDestinoDespacho;
        private string _nombreDestinoDespacho;
        private bool _estado;

        public int IdDestinoDespacho
        {
            get { return _idDestinoDespacho; }
            set { _idDestinoDespacho = value; }
        }

        public string NombreDestinoDespacho
        {
            get { return _nombreDestinoDespacho; }
            set { _nombreDestinoDespacho = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

    }
}