using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoMenu
    {
        private string _pieMenu;
        private string _clase;
        private string _titulo;
        private string _action;
        private string _controller;
        private int _idMenu;

        public string Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        public string PieMenu
        {
            get { return _pieMenu; }
            set { _pieMenu = value; }
        }
        public string Accion
        {
            get { return _action; }
            set { _action = value; }
        }
        public string Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        public int IdMenu
        {
            get { return _idMenu; }
            set { _idMenu = value; }
        }
    }
}