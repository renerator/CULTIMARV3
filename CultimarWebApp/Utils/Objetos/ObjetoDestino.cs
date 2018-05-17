using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoDestino
    {
        private int _idDestino;
        private string _nombreDestino;
        private bool _estado;

        public int IdDestino
        {
            get { return _idDestino; }
            set { _idDestino = value; }
        }

        public string NombreDestino
        {
            get { return _nombreDestino; }
            set { _nombreDestino = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}