using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    public class FactoryPreparadoDespacho
    {


        public List<ObjetoPreparadoDespacho> ListadoPreparadoDespechao(int id)
        {
            var ListadoPDespachoado = new List<ObjetoPreparadoDespacho>();

            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOPreparadoDespacho", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@id", id}
                                                                                            });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoPreparadoDespacho();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdPreparoDespacho = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("FechaEnvio");
                    resultadoListado.FechaEnvio = validador != null ? data.Rows[i].Field<string>("FechaEnvio") : "01-01-1900";

                    validador = data.Rows[i].Field<object>("FechaPreparado");
                    resultadoListado.FechaPreparado = validador != null ? data.Rows[i].Field<string>("FechaPreparado") : "01-01-1900";

                    validador = data.Rows[i].Field<object>("NombreOrigen");
                    resultadoListado.NombreOrigen = validador != null ? data.Rows[i].Field<string>("NombreOrigen") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("NumeroLote");
                    resultadoListado.NumeroLote = validador != null ? data.Rows[i].Field<string>("NumeroLote") : "Sin Asignación";

                    
                    validador = data.Rows[i].Field<object>("IdDestino");
                    resultadoListado.IdDestino = validador != null ? data.Rows[i].Field<int>("IdDestino") : 1;

                    validador = data.Rows[i].Field<object>("PesoNeto");
                    resultadoListado.PesoNeto = validador != null ? data.Rows[i].Field<double>("PesoNeto") : 0;

                    validador = data.Rows[i].Field<object>("PesoBruto");
                    resultadoListado.PesoBruto = validador != null ? data.Rows[i].Field<double>("PesoBruto") : 0;

                    validador = data.Rows[i].Field<object>("PesoNetoEstimado");
                    resultadoListado.PesoNetoEstimado = validador != null ? data.Rows[i].Field<double>("PesoNetoEstimado") : 0;

                    validador = data.Rows[i].Field<object>("Ploidia");
                    resultadoListado.Ploidia = validador != null ? data.Rows[i].Field<string>("Ploidia") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("NumeroCajas");
                    resultadoListado.CantidadCajas = validador != null ? data.Rows[i].Field<int>("NumeroCajas") : 0;

                    validador = data.Rows[i].Field<object>("Cantidad");
                    resultadoListado.Cantidad = validador != null ? data.Rows[i].Field<string>("Cantidad") :"";

                    validador = data.Rows[i].Field<object>("Calibre");
                    resultadoListado.Calibre = validador != null ? data.Rows[i].Field<string>("Calibre") : "";

                    validador = data.Rows[i].Field<object>("Cliente");
                    resultadoListado.Cliente = validador != null ? data.Rows[i].Field<string>("Cliente") : ".";

                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "SIN OBSERVACIONES PARA EL REGISTRO";

                    validador = data.Rows[i].Field<object>("CantidadMuestra");
                    resultadoListado.CantidadMuestra = validador != null ? data.Rows[i].Field<double>("CantidadMuestra") : 0;

                    validador = data.Rows[i].Field<object>("CantidadContada");
                    resultadoListado.CantidadContada = validador != null ? data.Rows[i].Field<double>("CantidadContada") : 0;


                    validador = data.Rows[i].Field<object>("VolumenMuestra");
                    resultadoListado.VolumenMuestra = validador != null ? data.Rows[i].Field<double>("VolumenMuestra") : 0;

                    validador = data.Rows[i].Field<object>("CantidadTotal");
                    resultadoListado.CantidadTotal = validador != null ? data.Rows[i].Field<double>("CantidadTotal") : 0;

                    validador = data.Rows[i].Field<object>("LitrosContenedor");
                    resultadoListado.LitrosContenedor = validador != null ? data.Rows[i].Field<double>("LitrosContenedor") : 0;


                    ListadoPDespachoado.Add(resultadoListado);
                }
            }
            return ListadoPDespachoado;
        }




        public bool SetGrabaPreparadoDespachl(int idUsuario, ObjetoPreparadoDespacho pdespacho)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_PreparadoDespacho", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@IdUsuario", idUsuario},
                                                                                                {"@p_Id", pdespacho.IdPreparoDespacho },
                                                                                                {"@p_FechaEnvio", pdespacho.FechaEnvio},
                                                                                                {"@p_FechaPreparado", pdespacho.FechaPreparado},
                                                                                                {"@nombreOrigen", pdespacho.NombreOrigen},
                                                                                                {"@numeroLote", pdespacho.NumeroLote},
                                                                                                {"@p_IdDestino", pdespacho.IdDestino},
                                                                                                {"@p_PesoNeto", pdespacho.PesoNeto},
                                                                                                {"@p_PesoBruto", pdespacho.PesoBruto},
                                                                                                {"@p_PesoEstimado", pdespacho.PesoNetoEstimado},
                                                                                                {"@ploidia", pdespacho.Ploidia},
                                                                                                {"@ncajas", pdespacho.CantidadCajas},
                                                                                                {"@p_Cantidad",pdespacho.Cantidad},
                                                                                                {"@p_Calibre", pdespacho.Calibre},
                                                                                                {"@p_Cliente", pdespacho.Cliente},
                                                                                                {"@VolumenMuestra", pdespacho.VolumenMuestra},
                                                                                                {"@CantidadMuestra", pdespacho.CantidadMuestra},
                                                                                                {"@CantidadContada", pdespacho.CantidadContada},
                                                                                                {"@CantidadTotal", pdespacho.CantidadTotal },
                                                                                                {"@LitrosContenedor", pdespacho.LitrosContenedor},
                                                                                                {"@Observaciones", pdespacho.Observaciones}

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




    }
}