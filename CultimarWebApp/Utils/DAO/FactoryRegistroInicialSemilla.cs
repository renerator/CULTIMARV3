using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    internal class FactoryRegistroInicialSemilla
    {
        /// <summary>
        /// LIstado Registro inicial de Semillas
        /// </summary>
        /// <param name="idRegistro">Id del registro ingresado, usado para los permisos de modificación</param>
        /// <returns>Lista del tipo objetoSeguimientoSemilla con los datos.</returns>
        public List<ObjetoSeguimientoSemilla> ListadoRegistroInicial(int idRegistro)
        {
            var listadoSemilla = new List<ObjetoSeguimientoSemilla>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOINICIALSEMILLAS", new System.Collections.Hashtable() { { "@idRegistro", idRegistro } });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoSeguimientoSemilla();


                    validador = data.Rows[i].Field<object>("idRegistro");
                    resultadoListado.IdRegistroInicialSemilla = validador != null ? data.Rows[i].Field<int>("idRegistro") : -1;

                    validador = data.Rows[i].Field<object>("idRegistroLarval");
                    resultadoListado.IdRegistroLarval = validador != null ? data.Rows[i].Field<int>("idRegistroLarval") : -1;


                    validador = data.Rows[i].Field<object>("idTipoContenedor");
                    resultadoListado.IdTipoContenedor = validador != null ? data.Rows[i].Field<int>("idTipoContenedor") : -1;

                    validador = data.Rows[i].Field<object>("NombreContenedor");
                    resultadoListado.NombreContenedor = validador != null ? data.Rows[i].Field<string>("NombreContenedor") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("NombreCultivo");
                    resultadoListado.NombreRegistroLarval = validador != null ? data.Rows[i].Field<string>("NombreCultivo") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("idCalibre");
                    resultadoListado.IdCalibre = validador != null ? data.Rows[i].Field<int>("idCalibre") : -1;

                    validador = data.Rows[i].Field<object>("NombreCalibre");
                    resultadoListado.NombreCalibreSemilla = validador != null ? data.Rows[i].Field<string>("NombreCalibre") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("FechaIngreso");
                    resultadoListado.FechaRegistroInicial = validador != null ? data.Rows[i].Field<DateTime>("FechaIngreso") : DateTime.Parse("01/01/2017");

                    validador = data.Rows[i].Field<object>("FechaDesdoble");
                    resultadoListado.FechaDesdobleInicial = validador != null ? data.Rows[i].Field<DateTime>("FechaDesdoble") : DateTime.Parse("01/01/2017");

                    validador = data.Rows[i].Field<object>("Ploidia");
                    resultadoListado.Ploidia = validador != null ? data.Rows[i].Field<string>("Ploidia") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("Muestreo");
                    resultadoListado.Muestreo = validador != null ? data.Rows[i].Field<string>("Muestreo") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "SIN OBSERVACIONES AL REGISTRO";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    validador = data.Rows[i].Field<object>("VolumenMuestra");
                    resultadoListado.VolumenMuestra = validador != null ? data.Rows[i].Field<int>("VolumenMuestra") : 0;

                    validador = data.Rows[i].Field<object>("CantidadLitros");
                    resultadoListado.CantidadLitros = validador != null ? data.Rows[i].Field<double>("CantidadLitros") : 0;


                    listadoSemilla.Add(resultadoListado);
                }
            }
            return listadoSemilla;
        }

        public bool SetGrabaRegistroInicialSemilla(int idUsuario, ObjetoSeguimientoSemilla registroinicial)
        {

            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABAREGISTROINICIALSEMILLA", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@idUsuario",idUsuario },
                                                                                                {"@idTipoContenedor", registroinicial.IdTipoContenedor },
                                                                                                {"@idRegistro", registroinicial.IdRegistroInicialSemilla },
                                                                                                {"@idRegistroLarval", registroinicial.IdRegistroLarval },
                                                                                                {"@idCalibre", registroinicial.IdCalibre },
                                                                                                {"@FechaIngreso", registroinicial.FechaRegistroInicial },
                                                                                                {"@FechaDesdoble", registroinicial.FechaDesdobleInicial },
                                                                                                {"@Ploidia", registroinicial.Ploidia },
                                                                                                {"@Muestreo", registroinicial.Muestreo },
                                                                                                {"@Observaciones", registroinicial.Observaciones },
                                                                                                {"@volumenMuestra",registroinicial.VolumenMuestra },
                                                                                                { "@cantidadLitros", registroinicial.CantidadLitros }
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