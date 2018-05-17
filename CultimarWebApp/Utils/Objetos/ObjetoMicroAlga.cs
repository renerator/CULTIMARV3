using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoMicroAlga
    {
        private int _idMicroAlga;
        private int _idSeguimientoMicroAlga;
        private int _idEspecie;
        private int _idOrigen;
        private int _idDestino;
        private string _nombreRegistroMicroAlga;
        private string _observaciones;
        private string _nombreEspecie;
        private DateTime _fechaSistema;
        private int _volumenSembrado;
        private int _numeroBolsa;
        private DateTime _fechaRegistro;
        private DateTime _fechaIngreso;
        private DateTime _fechaSalida;
        private bool _estado;

        private int _idTipoIdentificador;
        private string _nombreIdentificador;
        private int _idTipoContenedor;
        private string _nombreContenedor;
        private string _tipoContenedor;
        private bool _resultadoTCBS;
        private int _volumenCosechado;
        private int _concentracion;
        private int _puntuacion;
        private int _conteo;

        public int Puntuacion
        {
            get { return _puntuacion; }
            set { _puntuacion = value; }
        }
        public int IdDestino
        {
            get { return _idDestino; }
            set { _idDestino = value; }
        }

        public int IdOrigen
        {
            get { return _idOrigen; }
            set { _idOrigen = value; }
        }

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        public DateTime FechaSalida
        {
            get { return _fechaSalida; }
            set { _fechaSalida = value; }
        }


        public int IdMicroAlga
        {
            get { return _idMicroAlga; }
            set { _idMicroAlga = value; }
        }

        public int IdSeguimientoMicroAlga
        {
            get { return _idSeguimientoMicroAlga; }
            set { _idSeguimientoMicroAlga = value; }
        }


        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int IdEspecie {
            get { return _idEspecie; }
            set { _idEspecie = value; }
        }
        public string NombreEspecie {
            get { return _nombreEspecie; }
            set { _nombreEspecie = value; }
        }
        public string NombreRegistroMicroAlga
        {
            get { return _nombreRegistroMicroAlga; }
            set { _nombreRegistroMicroAlga = value; }
        }
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        public DateTime FechaSistema {
            get { return _fechaSistema; }
            set { _fechaSistema = value; }
        }
        public int VolumenSembrado
        {
            get { return _volumenSembrado; }
            set { _volumenSembrado = value; }
        }
        public int NumeroBolsa {
            get { return _numeroBolsa; }
            set { _numeroBolsa = value; }
        }
        public DateTime FechaRegistro {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }

        public int IdTipoIdentificador
        {
            get { return _idTipoIdentificador; }
            set { _idTipoIdentificador = value; }
        }
        public string NombreIdentificador
        {
            get { return _nombreIdentificador; }
            set { _nombreIdentificador = value; }
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
        public string TipoContenedor
        {
            get { return _tipoContenedor; }
            set { _tipoContenedor = value; }
        }
        

        public bool ResultadoTCBS
        {
            get { return _resultadoTCBS; }
            set { _resultadoTCBS = value; }
        }
        public int VolumenCosechado
        {
            get { return _volumenCosechado; }
            set { _volumenCosechado = value; }
        }
        public int Concentracion
        {
            get { return _concentracion; }
            set { _concentracion = value; }
        }
        public int Conteo
        {
            get { return _conteo; }
            set { _conteo = value; }
        }
    }
}