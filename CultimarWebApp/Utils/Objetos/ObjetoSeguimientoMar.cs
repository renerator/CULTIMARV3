using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoSeguimientoMar
    {

        private int _cantidadMortalidad;
        public int CantidadMortalidad
        {
            get { return _cantidadMortalidad; }
            set { _cantidadMortalidad = value; }
        }



        private int _ubicacionOceanica;
        public int UbicacionOceanica
        {
            get { return _ubicacionOceanica; }
            set { _ubicacionOceanica = value; }
        }

        private int _cantidadMuestra;
        public int CantidadMuestra
        {
            get { return _cantidadMuestra; }
            set { _cantidadMuestra = value; }
        }

        private int _volumenMuestra;
        public int VolumenMuestra
        {
            get { return _volumenMuestra; }
            set { _volumenMuestra = value; }
        }

        private double _volumenTotal;
        public double VolumenTotal
        {
            get { return _volumenTotal; }
            set { _volumenTotal = value; }
        }

        private double _litrosContenedor;
        public double LitrosContenedor
        {
            get { return _litrosContenedor; }
            set { _litrosContenedor = value; }
        }
        private int _idSeguimiento;
        public int IdSeguimiento
        {
            get { return _idSeguimiento; }
            set { _idSeguimiento = value; }
        }

        private int _idRegistroInicial;
        public int IdRegistroInicial
        {
            get { return _idRegistroInicial; }
            set { _idRegistroInicial = value; }
        }

        private string _nombreCultivo;
        public string NombreCultivo
        {
            get { return _nombreCultivo; }
            set { _nombreCultivo = value; }
        }

        private int _idMortalidad;
        public int IdMortalidad
        {
            get { return _idMortalidad; }
            set { _idMortalidad = value; }
        }
        //nombreUbicacionOceanica

        private string _nombreUbicacionOceanica;
        public string NombreUbicacionOceanica
        {
            get { return _nombreUbicacionOceanica; }
            set { _nombreUbicacionOceanica = value; }
        }


        private string _nombreMortalidad;
        public string NombreMortalidad
        {
            get { return _nombreMortalidad; }
            set { _nombreMortalidad = value; }
        }


        private DateTime _fechaDesdoble;
        public DateTime FechaDesdoble
        {
            get { return _fechaDesdoble; }
            set { _fechaDesdoble = value; }
        }


        private double _cantidadOrigen;
        public double CantidadOrigen
        {
            get { return _cantidadOrigen; }
            set { _cantidadOrigen = value; }
        }

        private int _idCalibreOrigen;
        public int IdCalibreOrigen
        {
            get { return _idCalibreOrigen; }
            set { _idCalibreOrigen = value; }
        }

        private string _nombreCalibreOrigen;
        public string NombreCalibreOrigen
        {
            get { return _nombreCalibreOrigen; }
            set { _nombreCalibreOrigen = value; }
        }

        private int _idUbicacionOrigen;
        public int IdUbicacionOrigen
        {
            get { return _idUbicacionOrigen; }
            set { _idUbicacionOrigen = value; }
        }

        private string _nombreUbicacionOrigen;
        public string NombreUbicacionOrigen
        {
            get { return _nombreUbicacionOrigen; }
            set { _nombreUbicacionOrigen = value; }
        }

        private int _cantidadSistemaOrigen;
        public int CantidadSistemaOrigen
        {
            get { return _cantidadSistemaOrigen; }
            set { _cantidadSistemaOrigen = value; }
        }

        private int _idSistemaOrigen;
        public int IdSistemaOrigen
        {
            get { return _idSistemaOrigen; }
            set { _idSistemaOrigen = value; }
        }

        private string _nombreSistemaOrigen;
        public string NombreSistemaOrigen
        {
            get { return _nombreSistemaOrigen; }
            set { _nombreSistemaOrigen = value; }
        }

        private double _cantidadDestino;
        public double CantidadDestino
        {
            get { return _cantidadDestino; }
            set { _cantidadDestino = value; }
        }

        private int _idCalibreDestino;
        public int IdCalibreDestino
        {
            get { return _idCalibreDestino; }
            set { _idCalibreDestino = value; }
        }

        private string _nombreCalibreDestino;
        public string NombreCalibreDestino
        {
            get { return _nombreCalibreDestino; }
            set { _nombreCalibreDestino = value; }
        }


        private int _idUbicacionDestino;
        public int IdUbicacionDestino
        {
            get { return _idUbicacionDestino; }
            set { _idUbicacionDestino = value; }
        }

        private string _nombreUbicacionDestino;
        public string NombreUbicacionDestino
        {
            get { return _nombreUbicacionDestino; }
            set { _nombreUbicacionDestino = value; }
        }

        private int _cantidadSistemaDestino;
        public int CantidadSistemaDestino
        {
            get { return _cantidadSistemaDestino; }
            set { _cantidadSistemaDestino = value; }
        }

        private int _idSistemaDestino;
        public int IdSistemaDestino
        {
            get { return _idSistemaDestino; }
            set { _idSistemaDestino = value; }
        }

        private string _nombreSistemaDestino;
        public string NombreSistemaDestino
        {
            get { return _nombreSistemaDestino; }
            set { _nombreSistemaDestino = value; }
        }

        private string _observaciones;
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

    }
}