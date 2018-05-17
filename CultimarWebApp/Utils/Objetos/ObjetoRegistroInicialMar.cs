using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoRegistroInicialMar
    {
        private int _idRegistro;
        private int _idRegistroLarval;
        private DateTime _fechaIngreso;
        private DateTime _fechaFuturoDesdoble;
        private int _cantidadOrigen;
        private int _cantidadMortalidad;
        private int _calibreOrigen;
        private int _idOrigen;
        private string _nombreOrigen;
        private string _nombreBatch;
        private int _cantidad;
        private int _idTipoSistema;
        private string _nombreSistema;
        private int _idMortalidad;
        private string _nombreMortalidad;
        private int _ubicacionOceanica;
        private string _nombreUbicacion;


        public string NombreUbicacion
        {
            get { return _nombreUbicacion; }
            set { _nombreUbicacion = value; }
        }

        public int UbicacionOceanica
        {
            get { return _ubicacionOceanica; }
            set { _ubicacionOceanica = value; }
        }


        public int CantidadMortalidad
        {
            get { return _cantidadMortalidad; }
            set { _cantidadMortalidad = value; }
        }

        public string NombreBatch
        {
            get { return _nombreBatch; }
            set { _nombreBatch = value; }
        }


        private bool _estado;
        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


        private string _nombreCultivo;
        public string NombreCultivo
        {
            get { return _nombreCultivo; }
            set { _nombreCultivo = value; }
        }


        private string _observaciones;
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        public int IdRegistroLarval
        {
            get { return _idRegistroLarval; }
            set { _idRegistroLarval = value; }
        }


        public int IdRegistro
        {
            get { return _idRegistro; }
            set { _idRegistro = value; }
        }
        public int IdMortalidad
        {
            get { return _idMortalidad; }
            set { _idMortalidad = value; }
        }

        public string NombreMortalidad
        {
            get { return _nombreMortalidad; }
            set { _nombreMortalidad = value; }
        }
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

        public int IdOrigen
        {
            get { return _idOrigen; }
            set { _idOrigen = value; }
        }
        public string NombreOrigen
        {
            get { return _nombreOrigen; }
            set { _nombreOrigen = value; }
        }

        public int CalibreOrigen
        {
            get { return _calibreOrigen; }
            set { _calibreOrigen = value; }
        }

        public int CantidadOrigen
        {
            get { return _cantidadOrigen; }
            set { _cantidadOrigen = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        public DateTime FechaFuturoDesdoble
        {
            get { return _fechaFuturoDesdoble; }
            set { _fechaFuturoDesdoble = value; }
        }

    }
}