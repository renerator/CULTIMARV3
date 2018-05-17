using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoTipoMortalidad
    {
        private int _idTipoMortalidad;
        private string _nombreMortalidad;
        private bool _estado;

        public int IdMortalidad
        {
            get { return _idTipoMortalidad; }
            set { _idTipoMortalidad = value; }
        }

        public string NombreMortalidad
        {
            get { return _nombreMortalidad; }
            set { _nombreMortalidad = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}