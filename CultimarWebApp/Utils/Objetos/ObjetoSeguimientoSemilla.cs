using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoSeguimientoSemilla
    {

        private int _idRegistroInicialSemilla;
        private int _idRegistroLarval;
        private string _nombreRegistroLarval;
        private int _idCalibre;
        private int _idTipoContenedor;
        private string _nombreContenedor;
        private string _nombreCalibreSemilla;
        private DateTime _fechaRegistroInicial;
        private DateTime _fechaDesdobleInicial;
        private string _ploidia;
        private string _muestreo;
        private string _observaciones;
        private string _zonaCultivo;

        private double _cantidadTotal;
        public double CantidadTotal
        {
            get { return _cantidadTotal; }
            set { _cantidadTotal = value; }
        }


        private double _litrosdecimalContenedor;
        public double LitrosdecimalContenedor
        {
            get { return _litrosdecimalContenedor; }
            set { _litrosdecimalContenedor = value; }
        }

        private double _cantidadLitros;
        public double CantidadLitros
        {
            get { return _cantidadLitros; }
            set { _cantidadLitros = value; }
        }
       

        private int _cantidadMortalidad;
        public int CantidadMortalidad
        {
            get { return _cantidadMortalidad; }
            set { _cantidadMortalidad = value; }
        }


        public string ZonaCultivo
        {
            get { return _zonaCultivo; }
            set { _zonaCultivo = value; }
        }

        public int IdTipoContenedor
        {
            get { return _idTipoContenedor; }
            set { _idTipoContenedor = value; }
        }

        public string NombreContenedor
        {
            get { return _nombreContenedor; }
            set { _nombreContenedor = value; }
        }

        private bool _estado;


        private int _IdSeguimientoSemilla;
        private int _IdTipoContenedorOrigen;
        private string _FechaRegistro;
        private DateTime _FechaRegistro1;
        private int _IdFactoresMedicion;
        private int _CantidadOrigen;
        private int _CalibreOrigen; 
        private int _IdTipoContenedorDestino;
        private int _CantidadCosechado;
        private int _CantidadCalibre;
        private bool _Estado;
        private string _Contenedororigen;
        private string _NombreContenedorDestino;
        private int _idOrigen;
        private int _IdDestino;
        private int _IdMortalidad;


        private int _litrosContenedor;
        public int LitrosContenedor
        {
            get { return _litrosContenedor; }
            set { _litrosContenedor = value; }
        }


        private int _cantidadMuestra;
        public int CantidadMuestra
        {
            get { return _cantidadMuestra; }
            set { _cantidadMuestra = value; }
        }

        private int _VolumenMuestra;
        public int VolumenMuestra
        {
            get { return _VolumenMuestra; }
            set { _VolumenMuestra = value; }
        }

        private double _VolumenTotal;
        public double VolumenTotal
        {
            get { return _VolumenTotal; }
            set { _VolumenTotal = value; }
        }




        private int _cantidadDestino;
        public int CantidadDestino
        {
            get { return _cantidadDestino; }
            set { _cantidadDestino = value; }
        }


        private string _nombreCalibreOrigen;
        public string NombreCalibreOrigen
        {
            get { return _nombreCalibreOrigen; }
            set { _nombreCalibreOrigen = value; }
        }

        private string _nombreCalibreDestino;
        public string NombreCalibreDestino
        {
            get { return _nombreCalibreDestino; }
            set { _nombreCalibreDestino = value; }
        }



        private string _factoresMedicion;

        public string FactoresMedicion
        {
            get { return _factoresMedicion; }
            set { _factoresMedicion = value; }
        }



        private string _nombreMortalidad;

        public string NombreMortalidad
        {
            get { return _nombreMortalidad; }
            set { _nombreMortalidad = value; }
        }


        public int IdMortalidad
        {
            get { return _IdMortalidad; }
            set { _IdMortalidad = value; }
        }

        public int IdDestino
        {
            get { return _IdDestino; }
            set { _IdDestino = value; }
        }


        public int IdOrigen
        {
            get { return _idOrigen; }
            set { _idOrigen = value; }
        }



        public int IdSeguimientoSemilla
        {
            get { return _IdSeguimientoSemilla; }
            set { _IdSeguimientoSemilla = value; }
        }

        public string NombreContenedorDestino
        {
            get { return _NombreContenedorDestino; }
            set { _NombreContenedorDestino = value; }
        }


        public string NombreContenedororigen
        {
            get { return _Contenedororigen; }
            set { _Contenedororigen = value; }
        }


        public int IdTipoContenedorOrigen
        {
            get { return _IdTipoContenedorOrigen; }
            set { _IdTipoContenedorOrigen = value; }
        }
        public string  FechaRegistro
        {
            get { return _FechaRegistro; }
            set { _FechaRegistro = value; }
        }
        public DateTime FechaRegistro1
        {
            get { return _FechaRegistro1; }
            set { _FechaRegistro1 = value; }
        }

        
        public int IdFactoresMedicion
        {
            get { return _IdFactoresMedicion; }
            set { _IdFactoresMedicion = value; }
        }
        public int CantidadOrigen
        {
            get { return _CantidadOrigen; }
            set { _CantidadOrigen = value; }
        }
        public int CalibreOrigen
        {
            get { return _CalibreOrigen; }
            set { _CalibreOrigen = value; }
        }
      
        public int IdTipoContenedorDestino
        {
            get { return _IdTipoContenedorDestino; }
            set { _IdTipoContenedorDestino = value; }
        }
        public int CantidadCosechado
        {
            get { return _CantidadCosechado; }
            set { _CantidadCosechado = value; }
        }
        public int CantidadCalibre
        {
            get { return _CantidadCalibre; }
            set { _CantidadCalibre = value; }
        }
       
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public int IdRegistroInicialSemilla { get { return _idRegistroInicialSemilla; } set { _idRegistroInicialSemilla = value; } }
        public int IdRegistroLarval { get { return _idRegistroLarval; } set { _idRegistroLarval = value; } }
        public string NombreRegistroLarval { get { return _nombreRegistroLarval; } set { _nombreRegistroLarval = value; } }
        public int IdCalibre { get { return _idCalibre; } set { _idCalibre = value; } }
        public string NombreCalibreSemilla { get { return _nombreCalibreSemilla; } set { _nombreCalibreSemilla = value; } }
        public DateTime FechaRegistroInicial { get { return _fechaRegistroInicial; } set { _fechaRegistroInicial = value; } }
        public DateTime FechaDesdobleInicial { get { return _fechaDesdobleInicial; } set { _fechaDesdobleInicial = value; } }
        public string Ploidia { get { return _ploidia; } set { _ploidia = value; } }
        public string Muestreo { get { return _muestreo; } set { _muestreo = value; } }
        public string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public bool Estado1 { get { return _estado; } set { _estado = value; } }
    }
}