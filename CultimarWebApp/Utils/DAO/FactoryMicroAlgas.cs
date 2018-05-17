using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace CultimarWebApp.Utils.DAO
{
    internal class FactoryMicroAlgas
    {
        public List<ObjetoMicroAlga> ListadoMicroAlgas(int id)
        {
            var lisMicroAlgas = new List<ObjetoMicroAlga>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOMICROALGAS", new System.Collections.Hashtable() {
                                                                                                {"@id",id }
                                                                                             });
            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoMicroAlga();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdMicroAlga = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("IdEspecie");
                    resultadoListado.IdEspecie = validador != null ? data.Rows[i].Field<int>("IdEspecie") : -1;

                    validador = data.Rows[i].Field<object>("NombreEspecie");
                    resultadoListado.NombreEspecie = validador != null ? data.Rows[i].Field<string>("NombreEspecie") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("NombreMicroAlga");
                    resultadoListado.NombreRegistroMicroAlga = validador != null ? data.Rows[i].Field<string>("NombreMicroAlga") : "NO ASIGNADO";


                    validador = data.Rows[i].Field<object>("FechaSistema");
                    resultadoListado.FechaSistema = validador != null ? data.Rows[i].Field<DateTime>("FechaSistema") : DateTime.Now.AddYears(-100);

                    validador = data.Rows[i].Field<object>("VolumenSembrado");
                    resultadoListado.VolumenSembrado = validador != null ? data.Rows[i].Field<int>("VolumenSembrado") : -1;

                    validador = data.Rows[i].Field<object>("NumeroBolsa");
                    resultadoListado.NumeroBolsa = validador != null ? data.Rows[i].Field<int>("NumeroBolsa") : -1;

                    validador = data.Rows[i].Field<object>("FechaRegistro");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro") : DateTime.Now.AddYears(-100);

                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "SIN OBSERVACIONES PARA EL REGISTRO";


                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    lisMicroAlgas.Add(resultadoListado);
                }
            }
            return lisMicroAlgas;
        }

        public bool SetGrabaMicroAlga(int idUsuario, ObjetoMicroAlga microAlga)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABAMICROALGA", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@idUsuario",idUsuario },
                                                                                                {"@nombreRegistro", microAlga.NombreRegistroMicroAlga },
                                                                                                {"@id", microAlga.IdMicroAlga },
                                                                                                {"@idEspecie", microAlga.IdEspecie },
                                                                                                {"@volumenSembrado", microAlga.VolumenSembrado },
                                                                                                {"@numeroBolsa", microAlga.NumeroBolsa },
                                                                                                {"@fechaRegistro", microAlga.FechaRegistro },
                                                                                                {"@observaciones", microAlga.Observaciones }
                                                                                             });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }


        public bool SetGrabaSeguimientoMicroAlga(int idUsuario, ObjetoMicroAlga microAlga)
        {
            var respuesta = false;
            try
            {
                
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABASEGUIMIENTOMICROALGA", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@IdUsuario",idUsuario },
                                                                                                {"@Id", microAlga.IdSeguimientoMicroAlga},
                                                                                                {"@IdEspecie", microAlga.IdEspecie },
                                                                                                {"@idMicroAlga", microAlga.IdMicroAlga },
                                                                                                {"@FechaIngreso", microAlga.FechaIngreso },
                                                                                                {"@FechaSalida", microAlga.FechaSalida },
                                                                                                {"@IdOrigen", microAlga.IdOrigen },
                                                                                                {"@IdDestino", microAlga.IdDestino },
                                                                                                {"@ResultadoTCBS", microAlga.ResultadoTCBS },
                                                                                                {"@VolumenCosechado", microAlga.VolumenCosechado },
                                                                                                {"@Concentracion", microAlga.Concentracion },
                                                                                                {"@puntuacion", microAlga.Puntuacion },
                                                                                                {"@Observaciones", microAlga.Observaciones },
                                                                                                {"@Estado", microAlga.Estado }
                                                                                             });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }



        public List<ObjetoMicroAlga> ListadoSeguimientoMicroAlgas(int id)
        {
            var lisMicroAlgas = new List<ObjetoMicroAlga>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOSEGUIMIENTOMICROALGA", new System.Collections.Hashtable()
                                                                                                                {
                                                                                                                    {"@id",id }
                                                                                                                 }
                );

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoMicroAlga();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdSeguimientoMicroAlga = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("IdRegistroMicroAlga");
                    resultadoListado.IdMicroAlga = validador != null ? data.Rows[i].Field<int>("IdRegistroMicroAlga") : -1;

                    validador = data.Rows[i].Field<object>("IdEspecie");
                    resultadoListado.IdEspecie = validador != null ? data.Rows[i].Field<int>("IdEspecie") : -1;

                    validador = data.Rows[i].Field<object>("NombreEspecie");
                    resultadoListado.NombreEspecie = validador != null ? data.Rows[i].Field<string>("NombreEspecie") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("NombreMicroAlga");
                    resultadoListado.NombreRegistroMicroAlga = validador != null ? data.Rows[i].Field<string>("NombreMicroAlga") : "NO ASIGNADO";


                    validador = data.Rows[i].Field<object>("FechaIngreso");
                    resultadoListado.FechaIngreso = validador != null ? data.Rows[i].Field<DateTime>("FechaIngreso") : DateTime.Now.AddYears(-100);

                    validador = data.Rows[i].Field<object>("FechaSalida");
                    resultadoListado.FechaSalida = validador != null ? data.Rows[i].Field<DateTime>("FechaSalida") : DateTime.Now.AddYears(-100);


                    validador = data.Rows[i].Field<object>("IdOrigen");
                    resultadoListado.IdOrigen = validador != null ? data.Rows[i].Field<int>("IdOrigen") : -1;

                    validador = data.Rows[i].Field<object>("NombreOrigen");
                    resultadoListado.NombreIdentificador = validador != null ? data.Rows[i].Field<string>("NombreOrigen") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("IdDestino");
                    resultadoListado.IdDestino = validador != null ? data.Rows[i].Field<int>("IdDestino") : -1;

                    validador = data.Rows[i].Field<object>("NombreDestino");
                    resultadoListado.NombreContenedor = validador != null ? data.Rows[i].Field<string>("NombreDestino") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("ResultadoTCBS");
                    resultadoListado.ResultadoTCBS = validador != null ? data.Rows[i].Field<bool>("ResultadoTCBS") : false;
                    
                    validador = data.Rows[i].Field<object>("VolumenCosechado");
                    resultadoListado.VolumenCosechado = validador != null ? data.Rows[i].Field<int>("VolumenCosechado") : -1;

                    validador = data.Rows[i].Field<object>("Concentracion");
                    resultadoListado.Concentracion = validador != null ? data.Rows[i].Field<int>("Concentracion") : -1;
                    validador = data.Rows[i].Field<object>("Puntuacion");
                    resultadoListado.Puntuacion = validador != null ? data.Rows[i].Field<int>("Puntuacion") : 0;

                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "SIN OBSERVACIONES PARA EL REGISTRO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    lisMicroAlgas.Add(resultadoListado);
                }
            }
            return lisMicroAlgas;
        }
    }
}