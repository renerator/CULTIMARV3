using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoUsuarios
    {
        private int _idUsuario;
        private int _idPerfil;
        private string _rutUsuario;
        private string _email;
        private string _pass;
        private string _nombreUsuario;
        private string _nombrePerfilUsuario;
        private bool _puedeModificar;
        private bool _activo;


        public bool PuedeModificar
        {
            get { return _puedeModificar; }
            set { _puedeModificar = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        public int IdPerfil
        {
            get { return _idPerfil; }
            set { _idPerfil = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string RutUsuario
        {
            get { return _rutUsuario; }
            set { _rutUsuario = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string NombrePerfilUsuario
        {
            get { return _nombrePerfilUsuario; }
            set { _nombrePerfilUsuario = value; }
        }


    }
}