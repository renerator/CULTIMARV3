using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoTipoSistema
    {
        private int _idTipoSistema;
        private string _nombreSistema;
        private bool _estado;

        public int IdTipoSistema
        {
            get { return _idTipoSistema; }
            set { _idTipoSistema = value; }
        }

        public string NombreSistema
        {
            get { return _nombreSistema; }
            set { _nombreSistema = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}