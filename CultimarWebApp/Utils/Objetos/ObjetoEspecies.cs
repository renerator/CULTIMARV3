using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoEspecies
    {
        private int _idEspecies;
        private string _nombreEspecies;
        private bool _estado;

        public int IdEspecies
        {
            get { return _idEspecies; }
            set { _idEspecies = value; }
        }

        public string NombreEspecies
        {
            get { return _nombreEspecies; }
            set { _nombreEspecies = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}