using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoOrigen
    {
        private int _idOrigen;
        private string _nombreOrigen;
        private bool _estado;

        public int IdOrigen
        {
            get { return _idOrigen; }
            set { _idOrigen = value; }
        }

        public string NombreOrigen
        {
            get { return _nombreOrigen; }
            set { _nombreOrigen = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}