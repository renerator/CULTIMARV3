using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoPloidia
    {

        private int _IdPloidia;
        private string _nombrePloidia; 
        private bool _estado;



        public int IdPloidia
        {
            get { return _IdPloidia; }
            set { _IdPloidia = value; }
        }

        public string nombrePloidia
        {
            get { return _nombrePloidia; }
            set { _nombrePloidia = value; }
        }


        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


    }
}