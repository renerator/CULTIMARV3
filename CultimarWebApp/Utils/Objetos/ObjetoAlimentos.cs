using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoAlimentos
    {
        private int _idTipoAlimento;
        private string _nombreTipoAlimento;
        private string _descripcionTipoAlimento;
        private bool _estadoTipoAlimento;



        public int IdTipoAlimento
        {
            get { return _idTipoAlimento; }
            set { _idTipoAlimento = value; }
        }

        public string NombreTipoAlimento
        {
            get { return _nombreTipoAlimento; }
            set { _nombreTipoAlimento = value; }
        }

        public string DescripcionTipoAlimento
        {
            get { return _descripcionTipoAlimento; }
            set { _descripcionTipoAlimento = value; }
        }
        public bool EstadoTipoAlimento
        {
            get { return _estadoTipoAlimento; }
            set { _estadoTipoAlimento = value; }
        }


        private int _idAlimento;
        private string _nombreAlimento;
        private bool _estadoAlimento;

        public int IdAlimento
        {
            get { return _idAlimento; }
            set { _idAlimento = value; }
        }

        public string NombreAlimento
        {
            get { return _nombreAlimento; }
            set { _nombreAlimento = value; }
        }
        public bool EstadoAlimento
        {
            get { return _estadoAlimento; }
            set { _estadoAlimento = value; }
        }



    }
}