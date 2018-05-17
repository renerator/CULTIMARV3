using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    public class FactorySeguimientoLarval
    {

        /// <summary>
        /// Metodo para listar el seguimiento larval
        /// </summary>


        public List<ObjetoSeguimientoLarval> ListadoSeguimientoLarval(int id)
        {
            var ListadoSeguimientoLarval = new List<ObjetoSeguimientoLarval>();

            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOSEGUIMIENTOLARVAL", new System.Collections.Hashtable() { { "@id", id } });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoSeguimientoLarval();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.Id = validador != null ? data.Rows[i].Field<int>("Id") : 1;

                    validador = data.Rows[i].Field<object>("idRegistro");
                    resultadoListado.IdRegistro = validador != null ? data.Rows[i].Field<int>("idRegistro") : 1;
                    
                    validador = data.Rows[i].Field<object>("NombreCultivo");
                    resultadoListado.NombreRegistro = validador != null ? data.Rows[i].Field<string>("NombreCultivo") : "SIN ASIGNACION";

                    validador = data.Rows[i].Field<object>("CantidadDeLarvas");
                    resultadoListado.CantidadDeLarvas = validador != null ? data.Rows[i].Field<int>("CantidadDeLarvas") : 0;

                    validador = data.Rows[i].Field<object>("CosechaLarvas");
                    resultadoListado.CosechaLarvas = validador != null ? data.Rows[i].Field<double>("CosechaLarvas") : 0;

                    validador = data.Rows[i].Field<object>("idNumeroEstanqueOrigen");
                    resultadoListado.NumeroEstanque = validador != null ? data.Rows[i].Field<int>("idNumeroEstanqueOrigen") : 0;

                    validador = data.Rows[i].Field<object>("NombreContenedorOrigen");
                    resultadoListado.NombreEstanqueOrigen = validador != null ? data.Rows[i].Field<string>("NombreContenedorOrigen") : "SIN ASIGNACION";

                    validador = data.Rows[i].Field<object>("idNumeroEstanqueDestino");
                    resultadoListado.NumeroEstanqueDestino = validador != null ? data.Rows[i].Field<int>("idNumeroEstanqueDestino") : 0;

                    validador = data.Rows[i].Field<object>("NombreContenedorDestino");
                    resultadoListado.NombreEstanqueDestino = validador != null ? data.Rows[i].Field<string>("NombreContenedorDestino") : "SIN ASIGNACION";

                    validador = data.Rows[i].Field<object>("DensidadCultivo");
                    resultadoListado.DensidadCultivo = validador != null ? data.Rows[i].Field<double>("DensidadCultivo") : 0;

                    validador = data.Rows[i].Field<object>("FechaRegistro");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro") : DateTime.Today;

                    validador = data.Rows[i].Field<object>("FactoresMedicion");
                    resultadoListado.FactoresMedicion = validador != null ? data.Rows[i].Field<string>("FactoresMedicion") :"0";

                    validador = data.Rows[i].Field<object>("IdMortalidad");
                    resultadoListado.IdMortalidad= validador != null ? data.Rows[i].Field<int>("IdMortalidad") : 0;

                    validador = data.Rows[i].Field<object>("NombreMortalidad");
                    resultadoListado.NombreMortalidad = validador != null ? data.Rows[i].Field<string>("NombreMortalidad") : "SIN ASIGNACION";

                    validador = data.Rows[i].Field<object>("CantidadMortalidad");
                    resultadoListado.CantidadMortalidad = validador != null ? data.Rows[i].Field<int>("CantidadMortalidad") : 0;

                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "0";

                    validador = data.Rows[i].Field<object>("idCalibre");
                    resultadoListado.IdCalibre = validador != null ? data.Rows[i].Field<int>("IdCalibre") : 0;

                    ListadoSeguimientoLarval.Add(resultadoListado);
                }
            }
            return ListadoSeguimientoLarval;
        }

        /// <summary>
        /// Metodo para grabar seguimiento larval
        /// </summary>


        public bool SetGrabaSegimientoLarval(int idUsuario, ObjetoSeguimientoLarval seguimientolarval)
        {
            var respuesta = false;
            try
            {
                
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoLarval", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@IdUsuario", idUsuario},
                                                                                                {"@idRegistro", seguimientolarval.IdRegistro},
                                                                                                {"@p_Id", seguimientolarval.Id },
                                                                                                {"@p_CantidadDeLarvas", seguimientolarval.CantidadDeLarvas },
                                                                                                {"@p_CosechaLarvas", seguimientolarval.CosechaLarvas},
                                                                                                {"@p_DensidadCultivo", seguimientolarval.DensidadCultivo }, 
                                                                                                {"@p_FactoresMedicion", seguimientolarval.FactoresMedicion },
                                                                                                {"@p_IdMortalidad", seguimientolarval.IdMortalidad },
                                                                                                {"@idCalibre", seguimientolarval.IdCalibre },
                                                                                                {"@idEstanqueOrigen", seguimientolarval.NumeroEstanque },
                                                                                                {"@idEstanqueDestino", seguimientolarval.NumeroEstanqueDestino },
                                                                                                {"@cantidadMortalidad", seguimientolarval.CantidadMortalidad },
                                                                                                {"@observaciones", seguimientolarval.Observaciones }
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

        public bool setEditaSegimientoLarval(ObjetoSeguimientoLarval seguimientolarval)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoLarval", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@CantidadDeLarvas", seguimientolarval.CantidadDeLarvas },
                                                                                                {"@CosechaLarvas", seguimientolarval.CosechaLarvas },
                                                                                                {"@NumeroEstanque", seguimientolarval.NumeroEstanque },
                                                                                                {"@DensidadCultivo", seguimientolarval.DensidadCultivo },
                                                                                                {"@FechaRegistro", seguimientolarval.FechaRegistro },
                                                                                                {"@FactoresMedicion", seguimientolarval.FactoresMedicion },
                                                                                                {"@IdMortalidad", seguimientolarval.IdMortalidad },
                                                                                                {"A",seguimientolarval }
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

        public bool setEliminaSeguimientoLarval(int id)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoLarval", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"Id", id},


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