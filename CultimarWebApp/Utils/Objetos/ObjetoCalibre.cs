using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoCalibre
    {
        private int _idCalibre;
        private string _nombreCalibre;
        private string _descripcionCalibre;
        private bool _estado;



        public int IdCalibre
        {
            get { return _idCalibre; }
            set { _idCalibre = value; }
        }

        public string NombreCalibre
        {
            get { return _nombreCalibre; }
            set { _nombreCalibre = value; }
        }

        public string DescripcionCalibre
        {
            get { return _descripcionCalibre; }
            set { _descripcionCalibre = value; }
        }
        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}