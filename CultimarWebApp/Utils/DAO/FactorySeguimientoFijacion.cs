using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    public class FactorySeguimientoFijacion
    {
       /// <summary>
       /// Listado Seguimiento Fijacion
       /// </summary>
       /// <param name="id">Id del parametro a seleccionar, si distinto -1 trae el registro unico, de lo contrario trae todos los registros</param>
       /// <returns>Lista del tipo ObjetoSeguimientoFijacion con los datos ingresados ordenados desde el ultimo registro ingresado</returns>
        public List<ObjetoSeguimientoFijacion> ListadoFijacion(int id)
        {
            var ListadoSeguimientoFijacion = new List<ObjetoSeguimientoFijacion>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("[SP_GET_LISTADOSEGUIMIENTOFIJACION]", new System.Collections.Hashtable(){
                                                                                                {"@id", id}
                                                                                            });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoSeguimientoFijacion();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdSeguimientoFijacion = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("IdCultivo");
                    resultadoListado.IdCultivo = validador != null ? data.Rows[i].Field<int>("IdCultivo") : -1;

                    validador = data.Rows[i].Field<object>("NombreCultivo");
                    resultadoListado.NombreCultivo = validador != null ? data.Rows[i].Field<string>("NombreCultivo") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("FechaRegistro");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<string>("FechaRegistro") : "1900-01-01";

                    validador = data.Rows[i].Field<object>("idLarvasCalibre");
                    resultadoListado.LarvasCalibre = validador != null ? data.Rows[i].Field<int>("idLarvasCalibre") : 0;

                    validador = data.Rows[i].Field<object>("NombreCalibreLarva");
                    resultadoListado.NombreCalibreLarva = validador != null ? data.Rows[i].Field<string>("NombreCalibreLarva") : "SIN ASIGNACION";

                    validador = data.Rows[i].Field<object>("LarvasCantidad");
                    resultadoListado.LarvasCantidad = validador != null ? data.Rows[i].Field<int>("LarvasCantidad") : 0;

                    validador = data.Rows[i].Field<object>("FijacionCantidad");
                    resultadoListado.FijacionCantidad = validador != null ? data.Rows[i].Field<int>("FijacionCantidad") : 0;

                    validador = data.Rows[i].Field<object>("idCalibreFijacion");
                    resultadoListado.FijacionCalibre = validador != null ? data.Rows[i].Field<int>("idCalibreFijacion") : 0;

                    validador = data.Rows[i].Field<object>("NombreCalibreFijacion");
                    resultadoListado.NombreCalibreFijacion = validador != null ? data.Rows[i].Field<string>("NombreCalibreFijacion") : "SIN ASIGNACION";

                    validador = data.Rows[i].Field<object>("idCalibreSemilla");
                    resultadoListado.SemillaCalibre = validador != null ? data.Rows[i].Field<int>("idCalibreSemilla") : 0;

                    validador = data.Rows[i].Field<object>("NombreCalibreSemilla");
                    resultadoListado.NombreCalibreSemilla = validador != null ? data.Rows[i].Field<string>("NombreCalibreSemilla") : "SIN ASIGNACION";

                    validador = data.Rows[i].Field<object>("CosechaCantidad");
                    resultadoListado.CosechaSemilla = validador != null ? data.Rows[i].Field<int>("CosechaCantidad") : 0;

                    validador = data.Rows[i].Field<object>("CosechaCantidad");
                    resultadoListado.CosechaCantidad = validador != null ? data.Rows[i].Field<int>("CosechaCantidad") : 0;

                    validador = data.Rows[i].Field<object>("NumeroEstanque");
                    resultadoListado.NumeroEstanque = validador != null ? data.Rows[i].Field<int>("NumeroEstanque") : 0;

                    validador = data.Rows[i].Field<object>("DensidadSiembra");
                    resultadoListado.DensidadSiembra = validador != null ? data.Rows[i].Field<int>("DensidadSiembra") : 0;

                    validador = data.Rows[i].Field<object>("FactoresMedicion");
                    resultadoListado.FactoresMedicion = validador != null ? data.Rows[i].Field<string>("FactoresMedicion") : "";

                    validador = data.Rows[i].Field<object>("FechaSistema");
                    resultadoListado.FechaSistema = validador != null ? data.Rows[i].Field<DateTime>("FechaSistema") : DateTime.Now;

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : true;

                    validador = data.Rows[i].Field<object>("IdMortalidad");
                    resultadoListado.IdMortalidad = validador != null ? data.Rows[i].Field<int>("IdMortalidad") : 0;

                    validador = data.Rows[i].Field<object>("CantidadMortalidad");
                    resultadoListado.CantidadMortalidad = validador != null ? data.Rows[i].Field<int>("CantidadMortalidad") : 0;

                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "SIN OBSERVACIONES PARA EL REGISTRO";

                    ListadoSeguimientoFijacion.Add(resultadoListado);
                }
            }
            return ListadoSeguimientoFijacion;
        }

        /// <summary>
        /// Metodo para grabar seguimiento larval
        /// </summary>

        public bool SetGrabasegimientoFijacion(int idUsuario, ObjetoSeguimientoFijacion seguimientofijacion)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoFijacion", new System.Collections.Hashtable()
                                                                                            {
                                                                                                { "@IdUsuario", idUsuario},
                                                                                                {"@IdSeguimientoFijacion", seguimientofijacion.IdSeguimientoFijacion},
                                                                                                {"@IdCultivo", seguimientofijacion.IdCultivo},
                                                                                                {"@FechaRegistro", seguimientofijacion.FechaRegistro},
                                                                                                {"@LarvasCalibre", seguimientofijacion.LarvasCalibre},
                                                                                                {"@LarvasCantidad", seguimientofijacion.LarvasCantidad},
                                                                                                {"@FijacionCantidad", seguimientofijacion.FijacionCantidad},
                                                                                                {"@FijacionCalibre", seguimientofijacion.FijacionCalibre},
                                                                                                {"@CosechaSemilla", seguimientofijacion.CosechaSemilla},
                                                                                                {"@SemillaCalibre", seguimientofijacion.SemillaCalibre},
                                                                                                {"@CosechaCantidad", seguimientofijacion.CosechaCantidad},
                                                                                                {"@NumeroEstanque", seguimientofijacion.NumeroEstanque},
                                                                                                {"@DensidadSiembra", seguimientofijacion.DensidadSiembra},
                                                                                                {"@IdMortalidad", seguimientofijacion.IdMortalidad},
                                                                                                {"@CantidadMortalidad", seguimientofijacion.CantidadMortalidad},
                                                                                                {"@FactoresMedicion", seguimientofijacion.FactoresMedicion},
                                                                                                {"@Observaciones", seguimientofijacion.Observaciones}
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