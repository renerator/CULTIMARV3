using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{

    internal class FactoryRegistroProduccion
    {



        /// <summary>
        /// Metodo Menu
        /// Segun el ID del seguimiento, carga a la base la momento de grabar un dato ya la tabla se auto incrementa.
        /// </summary>
        /// <param name="Id">ID del seguimiento usuadi</param>
        /// <returns>Lista se consumura desde la paginas de seguimiento de semilla segun perfil asociado</returns>
        public List<ObjetoRegistroProduccion> listadoRegistroProduccion(int id)
        {
            var listadoRegistoProduccion = new List<ObjetoRegistroProduccion>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_RegistroProduccion", new System.Collections.Hashtable() { { "@id", id } });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoRegistroProduccion();

                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdRegistroProduccion = validador != null ? data.Rows[i].Field<int>("Id") : 0;

                    validador = data.Rows[i].Field<object>("idTipoIdentificacion");
                    resultadoListado.IdTipoIdentificacion = validador != null ? data.Rows[i].Field<int>("idTipoIdentificacion") : 0;

                    validador = data.Rows[i].Field<object>("NombreCultivo");
                    resultadoListado.NombreRegistro = validador != null ? data.Rows[i].Field<string>("NombreCultivo") : "SIN ASIGNACION";


                    validador = data.Rows[i].Field<object>("CantidadProductoresMachos");
                    resultadoListado.CantidadProductoresMachos = validador != null ? data.Rows[i].Field<int>("CantidadProductoresMachos") : 0;

                    validador = data.Rows[i].Field<object>("CantidadProductoresHembras");
                    resultadoListado.CantidadProductoresHembras = validador != null ? data.Rows[i].Field<int>("CantidadProductoresHembras") : 0;

                    validador = data.Rows[i].Field<object>("FechaRegistro");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro")  : Convert.ToDateTime("01/01/2017");

                    validador = data.Rows[i].Field<object>("NumeroDesoveTemporada");
                    resultadoListado.NumeroDesoveTemporada = validador != null ? data.Rows[i].Field<int>("NumeroDesoveTemporada") : 0;

                    validador = data.Rows[i].Field<object>("CantidadFecundada");
                    resultadoListado.CantidadFecundada = validador != null ? data.Rows[i].Field<int>("CantidadFecundada") : 0;

                    validador = data.Rows[i].Field<object>("CantidadSembrada");
                    resultadoListado.CantidadSembrada = validador != null ? data.Rows[i].Field<int>("CantidadSembrada") : 0;

                    validador = data.Rows[i].Field<object>("FactoresMedicion");
                    resultadoListado.FactoresMedicion = validador != null ? data.Rows[i].Field<string>("FactoresMedicion") : "0";

                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "SON OBSERVACIONES AL REGISTRO";

                    validador = data.Rows[i].Field<object>("NumeroEstanquesUtilizado");
                    resultadoListado.NumeroEstanquesUtilizado = validador != null ? data.Rows[i].Field<int>("NumeroEstanquesUtilizado") : 0;

                    validador = data.Rows[i].Field<object>("EstanqueUtilizado");
                    resultadoListado.NombreEstanque = validador != null ? data.Rows[i].Field<string>("EstanqueUtilizado") : "SIN ASIGNACION";


                    validador = data.Rows[i].Field<object>("DensidadSiembra");
                    resultadoListado.DensidadSiembra = validador != null ? data.Rows[i].Field<double>("DensidadSiembra") : 0;

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    listadoRegistoProduccion.Add(resultadoListado);
                }
            }
            return listadoRegistoProduccion;
        }



        public bool SetGrabaRegistroProduccion(int idUsuario, ObjetoRegistroProduccion produccion)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_Set_GrabaProduccion", new System.Collections.Hashtable()
                                                                                            { {"@IdUsuario", idUsuario},
                                                                                              {"@idProduccion",produccion.IdRegistroProduccion},
                                                                                              {"@idTipoIdentificacion",produccion.IdTipoIdentificacion},
                                                                                                {"@p_CantidadProductoresMachos",produccion.CantidadProductoresMachos},
                                                                                                {"@p_CantidadProductoresHembras", produccion.CantidadProductoresHembras },
                                                                                                {"@p_CantidadFecundada", produccion.CantidadFecundada },
                                                                                                {"@p_NumeroDesoveTemporada  ", produccion.NumeroDesoveTemporada },
                                                                                                {"@p_CantidadSembrada", produccion.CantidadSembrada },
                                                                                                {"@p_FactoresMedicion", produccion.FactoresMedicion},
                                                                                                {"@p_NumeroEstanquesUtilizado", produccion.NumeroEstanquesUtilizado},
                                                                                                {"@p_DensidadSiembra", produccion.DensidadSiembra },
                                                                                                {"@Observaciones", produccion.Observaciones }});
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