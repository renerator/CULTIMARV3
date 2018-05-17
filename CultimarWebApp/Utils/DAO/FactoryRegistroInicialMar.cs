using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CultimarWebApp.Utils.DAO
{
    internal class FactoryRegistroInicialMar
    {
        public List<ObjetoRegistroInicialMar> ListadoRegistroInicialMar(int id)
        {
            var lisMicroAlgas = new List<ObjetoRegistroInicialMar>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOREGISTROMAR", new System.Collections.Hashtable() {
                                                                                                    {"@IdRegistro",id }
                                                                                                });
            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoRegistroInicialMar();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdRegistro = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    //validador = data.Rows[i].Field<object>("idRegistroLarval");
                    //resultadoListado.IdRegistroLarval = validador != null ? data.Rows[i].Field<int>("idRegistroLarval") : -1;

                    validador = data.Rows[i].Field<object>("NombreCultivo");
                    resultadoListado.NombreCultivo = validador != null ? data.Rows[i].Field<string>("NombreCultivo") : "No Especificado";

                    validador = data.Rows[i].Field<object>("FechaIngreso");
                    resultadoListado.FechaIngreso = validador != null ? data.Rows[i].Field<DateTime>("FechaIngreso") : DateTime.Now.AddYears(-100);

                    validador = data.Rows[i].Field<object>("FechaFuturoDesobe");
                    resultadoListado.FechaFuturoDesdoble = validador != null ? data.Rows[i].Field<DateTime>("FechaFuturoDesobe") : DateTime.Now.AddYears(-100);

                    validador = data.Rows[i].Field<object>("CantidadOrigen");
                    resultadoListado.CantidadOrigen = validador != null ? data.Rows[i].Field<int>("CantidadOrigen") : 0;

                    validador = data.Rows[i].Field<object>("IdOrigen");
                    resultadoListado.IdOrigen = validador != null ? data.Rows[i].Field<int>("IdOrigen") : 0;

                    validador = data.Rows[i].Field<object>("NombreCalibre");
                    resultadoListado.NombreOrigen = validador != null ? data.Rows[i].Field<string>("NombreCalibre") : "No Especificado";

                    validador = data.Rows[i].Field<object>("IdTipoSistema");
                    resultadoListado.IdTipoSistema = validador != null ? data.Rows[i].Field<int>("IdTipoSistema") : 0;

                    validador = data.Rows[i].Field<object>("Cantidad");
                    resultadoListado.Cantidad = validador != null ? data.Rows[i].Field<int>("Cantidad") : 0;

                    validador = data.Rows[i].Field<object>("NombreSistema");
                    resultadoListado.NombreSistema = validador != null ? data.Rows[i].Field<string>("NombreSistema") : "No Especificado";


                    validador = data.Rows[i].Field<object>("IdMortalidad");
                    resultadoListado.IdMortalidad = validador != null ? data.Rows[i].Field<int>("IdMortalidad") : 0;

                    validador = data.Rows[i].Field<object>("idUbicacion");
                    resultadoListado.UbicacionOceanica = validador != null ? data.Rows[i].Field<int>("idUbicacion") : 0;

                    validador = data.Rows[i].Field<object>("NombreUbicacion");
                    resultadoListado.NombreUbicacion = validador != null ? data.Rows[i].Field<string>("NombreUbicacion") : "No Especificado";

                    validador = data.Rows[i].Field<object>("NombreMortalidad");
                    resultadoListado.NombreMortalidad = validador != null ? data.Rows[i].Field<string>("NombreMortalidad") : "No Especificado";

                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "No Especificado";

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    validador = data.Rows[i].Field<object>("CantidadMortalidad");
                    resultadoListado.CantidadMortalidad = validador != null ? data.Rows[i].Field<int>("CantidadMortalidad") : 0;



                    lisMicroAlgas.Add(resultadoListado);
                }
            }
            return lisMicroAlgas;
        }

        public bool SetGrabaRegistroInicialMar(int idUsuario, ObjetoRegistroInicialMar registroInicialMar)
        {
            
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABAREGISTROINGRESOMAR", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@IdRegistro",registroInicialMar.IdRegistro },
                                                                                                {"@nombreBatch", registroInicialMar.NombreBatch },
                                                                                                {"@IdUsuario", idUsuario },
                                                                                                {"@fechaIngreso", registroInicialMar.FechaIngreso },
                                                                                                {"@fechaFuturo", registroInicialMar.FechaFuturoDesdoble },
                                                                                                {"@cantidadOrigen", registroInicialMar.CantidadOrigen },
                                                                                                {"@calibreOrigen", registroInicialMar.CalibreOrigen },
                                                                                                {"@idOrigen", registroInicialMar.IdOrigen },
                                                                                                {"@Cantidad", registroInicialMar.Cantidad },
                                                                                                {"@idTipoSistema", registroInicialMar.IdTipoSistema },
                                                                                                {"@idTipoMortalidad", registroInicialMar.IdMortalidad },
                                                                                                {"@observaciones", registroInicialMar.Observaciones },
                                                                                                {"@idUbicacion", registroInicialMar.UbicacionOceanica },
                                                                                                {"@cantidadMortalidad", registroInicialMar.CantidadMortalidad }
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