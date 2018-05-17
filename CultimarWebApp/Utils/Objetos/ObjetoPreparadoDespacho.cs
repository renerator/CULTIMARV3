using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoPreparadoDespacho
    {
        private int _IdPreparoDespacho;
        private string _FechaEnvio;
        private string _FechaPreparado;
        private int _IdOrigen;
        private int _IdDestino;
        private double _PesoNeto;
        private double _PesoNetoEstimado;
        private double _PesoBruto;
        private string _Cantidad;
        private double _CantidadContada;
        private string _Calibre;
        private int _cantidadCajas;
        private double _CantidadTotal;
        private string _Cliente;
        private string _Ploidia;
        private string _numeroLote;
        private string _observaciones;
        private string _nombreOrigen;

        public int IdPreparoDespacho
        {
            get { return _IdPreparoDespacho; }
            set { _IdPreparoDespacho = value; }
        }
        //_CantidadTotal
        public double CantidadTotal
        {
            get { return _CantidadTotal; }
            set { _CantidadTotal = value; }
        }
        public string FechaEnvio
        {
            get { return _FechaEnvio; }
            set { _FechaEnvio = value; }
        }
        public string FechaPreparado
        {
            get { return _FechaPreparado; }
            set { _FechaPreparado = value; }
        }
        public int IdOrigen
        {
            get { return _IdOrigen; }
            set { _IdOrigen = value; }
        }
        public int IdDestino
        {
            get { return _IdDestino; }
            set { _IdDestino = value; }
        }
        public double PesoNeto
        {
            get { return _PesoNeto; }
            set { _PesoNeto = value; }
        }

        public double PesoNetoEstimado
        {
            get { return _PesoNetoEstimado; }
            set { _PesoNetoEstimado = value; }
        }

        public double PesoBruto
        {
            get { return _PesoBruto; }
            set { _PesoBruto = value; }
        }
        public string Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        //_CantidadContada
        public double CantidadContada
        {
            get { return _CantidadContada; }
            set { _CantidadContada = value; }
        }
        public string Calibre
        {
            get { return _Calibre; }
            set { _Calibre = value; }
        }
        //_cantidadCajas
        public int CantidadCajas
        {
            get { return _cantidadCajas; }
            set { _cantidadCajas = value; }
        }
        public string Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
        //_Ploidia
        public string Ploidia
        {
            get { return _Ploidia; }
            set { _Ploidia = value; }
        }
        //_numeroLote
        public string NumeroLote
        {
            get { return _numeroLote; }
            set { _numeroLote = value; }
        }
        //_observaciones
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        //_nombreOrigen
        public string NombreOrigen
        {
            get { return _nombreOrigen; }
            set { _nombreOrigen = value; }
        }
        private double _litrosContenedor;
        public double LitrosContenedor
        {
            get { return _litrosContenedor; }
            set { _litrosContenedor = value; }
        }


        private double _cantidadMuestra;
        public double CantidadMuestra
        {
            get { return _cantidadMuestra; }
            set { _cantidadMuestra = value; }
        }

        private double _VolumenMuestra;
        public double VolumenMuestra
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

    }
}