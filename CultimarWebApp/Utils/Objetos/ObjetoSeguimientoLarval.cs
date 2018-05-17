using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoSeguimientoLarval
    {
        private int _id;
        private int _idRegistro;
        private int _idCalibre;
        private int _cantidadDeLarvas;
        private double _cosechaLarvas;
        private int _numeroEstanque;
        private int _cantidadMortalidad;
        private string _nombreEstanqueOrigen;
        private int _numeroEstanqueDestino;
        private string _nombreEstanqueDestino;
        private double _densidadCultivo;
        private DateTime _fechaRegistro;
        private string _factoresMedicion;
        private string _nombreMortalidad;
        private string _nombreRegistro;
        private bool _estado;
        private int _IdMortalidad;
        private string _IdFactor;
        private string _observaciones;

        public int IdRegistro
        {
            get { return _idRegistro; }
            set { _idRegistro = value; }
        }
        public int IdCalibre
        {
            get { return _idCalibre; }
            set { _idCalibre = value; }
        }
        public int CantidadMortalidad
        {
            get { return _cantidadMortalidad; }
            set { _cantidadMortalidad = value; }
        }


        public int NumeroEstanqueDestino
        {
            get { return _numeroEstanqueDestino; }
            set { _numeroEstanqueDestino = value; }
        }

        public string NombreEstanqueOrigen
        {
            get { return _nombreEstanqueOrigen; }
            set { _nombreEstanqueOrigen = value; }
        }

        public string NombreEstanqueDestino
        {
            get { return _nombreEstanqueDestino; }
            set { _nombreEstanqueDestino = value; }
        }

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        public string NombreRegistro
        {
            get { return _nombreRegistro; }
            set { _nombreRegistro = value; }
        }

        public string  IdFactor
        {
            get { return _IdFactor; }
            set { _IdFactor = value; }
        }


        public int IdMortalidad
        {
            get { return _IdMortalidad; }
            set { _IdMortalidad = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int CantidadDeLarvas
        {
            get { return _cantidadDeLarvas; }
            set { _cantidadDeLarvas = value; }
        }
        public double CosechaLarvas
        {
            get { return _cosechaLarvas; }
            set { _cosechaLarvas = value; }
        }
        public int NumeroEstanque
        {
            get { return _numeroEstanque; }
            set { _numeroEstanque = value; }
        }
        public double DensidadCultivo
        {
            get { return _densidadCultivo; }
            set { _densidadCultivo = value; }
        }
        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }
        public string FactoresMedicion
        {
            get { return _factoresMedicion; }
            set { _factoresMedicion = value; }
        }
        public string NombreMortalidad
        {
            get { return _nombreMortalidad; }
            set { _nombreMortalidad = value; }
        }
        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }




    }
}


