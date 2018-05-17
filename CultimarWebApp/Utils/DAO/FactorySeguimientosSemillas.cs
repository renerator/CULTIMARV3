using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{


    internal class FactorySeguimientosSemillas
    {
        /// <summary>
        /// Metodo Menu
        /// Segun el ID del seguimiento, carga a la base la momento de grabar un dato ya la tabla se auto incrementa.
        /// </summary>
        /// <param name="Id">ID del seguimiento usuadi</param>
        /// <returns>Lista se consumura desde la paginas de seguimiento de semilla segun perfil asociado</returns>
        public List<ObjetoSeguimientoSemilla> SeguimientoSemilla(int id)
        {
            var listadoSeguimientoSemilla = new List<ObjetoSeguimientoSemilla>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_ListaSguimientoSemilla", new System.Collections.Hashtable() { { "@id", id } });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoSeguimientoSemilla();


                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdSeguimientoSemilla = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("idRegistroLarval");
                    resultadoListado.IdRegistroLarval = validador != null ? data.Rows[i].Field<int>("idRegistroLarval") : -1;

                    validador = data.Rows[i].Field<object>("NombreCultivo");
                    resultadoListado.NombreRegistroLarval = validador != null ? data.Rows[i].Field<string>("NombreCultivo") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("idContenedorOrigen");
                    resultadoListado.IdTipoContenedorOrigen = validador != null ? data.Rows[i].Field<int>("idContenedorOrigen") : -1;

                    validador = data.Rows[i].Field<object>("ContenedorOrigen");
                    resultadoListado.NombreContenedororigen = validador != null ? data.Rows[i].Field<string>("ContenedorOrigen") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("FechaRegistro");
                    resultadoListado.FechaRegistro1 = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro") : DateTime.Parse("01/01/2017");

                    validador = data.Rows[i].Field<object>("idMortalidad");
                    resultadoListado.IdMortalidad = validador != null ? data.Rows[i].Field<int>("idMortalidad") : -1;

                    validador = data.Rows[i].Field<object>("NombreMortalidad");
                    resultadoListado.NombreMortalidad = validador != null ? data.Rows[i].Field<string>("NombreMortalidad") : "Sin Asignación";
                    
                    validador = data.Rows[i].Field<object>("CantidadMortalidad");
                    resultadoListado.CantidadMortalidad = validador != null ? data.Rows[i].Field<int>("CantidadMortalidad") : 0;


                    validador = data.Rows[i].Field<object>("FactoresMedicion");
                    resultadoListado.FactoresMedicion = validador != null ? data.Rows[i].Field<string>("FactoresMedicion") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("CantidadOrigen");
                    resultadoListado.CantidadOrigen = validador != null ? data.Rows[i].Field<int>("CantidadOrigen") : 0;

                    validador = data.Rows[i].Field<object>("idCalibreOrigen");
                    resultadoListado.IdOrigen = validador != null ? data.Rows[i].Field<int>("idCalibreOrigen") : 0;

                    validador = data.Rows[i].Field<object>("CalibreOrigen");
                    resultadoListado.NombreCalibreOrigen = validador != null ? data.Rows[i].Field<string>("CalibreOrigen") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("CantidadDestino");
                    resultadoListado.CantidadDestino = validador != null ? data.Rows[i].Field<int>("CantidadOrigen") : 0;

                    validador = data.Rows[i].Field<object>("IdCalibreDestino");
                    resultadoListado.IdDestino = validador != null ? data.Rows[i].Field<int>("IdCalibreDestino") : 0;

                    validador = data.Rows[i].Field<object>("CalibreDestino");
                    resultadoListado.NombreCalibreDestino = validador != null ? data.Rows[i].Field<string>("CalibreDestino") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("idContenedorDestino");
                    resultadoListado.IdTipoContenedorDestino = validador != null ? data.Rows[i].Field<int>("idContenedorDestino") : 0;

                    validador = data.Rows[i].Field<object>("ContenedorDestino");
                    resultadoListado.NombreContenedorDestino = validador != null ? data.Rows[i].Field<string>("ContenedorDestino") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("CantidadMuestra");
                    resultadoListado.CantidadMuestra = validador != null ? data.Rows[i].Field<int>("CantidadMuestra") : 0;

                    validador = data.Rows[i].Field<object>("VolumenMuestra");
                    resultadoListado.VolumenMuestra = validador != null ? data.Rows[i].Field<int>("VolumenMuestra") : 0;

                    validador = data.Rows[i].Field<object>("LitrosContenedor");
                    resultadoListado.LitrosdecimalContenedor = validador != null ? data.Rows[i].Field<double>("LitrosContenedor") : 0;


                    validador = data.Rows[i].Field<object>("VolumenTotal");
                    resultadoListado.VolumenTotal = validador != null ? data.Rows[i].Field<double>("VolumenTotal") : 0;

                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "Sin Asignación";

                    validador = data.Rows[i].Field<object>("ZonaCultivo");
                    resultadoListado.ZonaCultivo = validador != null ? data.Rows[i].Field<string>("ZonaCultivo") : "Sin Asignación";
                    
                    listadoSeguimientoSemilla.Add(resultadoListado);
                }
            }
            return listadoSeguimientoSemilla;
        }




        /// <summary>
        /// Metodo para grabar un nuevo usuario
        /// </summary>
        /// <param name="seguimiento semillas">Objeto del tipo SeguimientoSemilla con todos los datos</param>
        /// <returns>valor mayor a 1 si el grabado resulta OK, 0 si hay error. </returns>
        public bool SetGrabaSeuimientoSemillla(int idUsuario, ObjetoSeguimientoSemilla semilla)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoSemilla", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@IdUsuario", idUsuario},
                                                                                                {"@IdSeguimientoSemilla",semilla.IdSeguimientoSemilla},
                                                                                                {"@IdRegistroLarval",semilla.IdRegistroLarval},
                                                                                                {"@ZonaCultivo",semilla.ZonaCultivo},
                                                                                                {"@IdTipoContenedorOrigen",semilla.IdTipoContenedorOrigen},
                                                                                                {"@FechaRegistro1",semilla.FechaRegistro1},
                                                                                                {"@IdMortalidad",semilla.IdMortalidad},
                                                                                                {"@FactoresMedicion",semilla.FactoresMedicion},
                                                                                                {"@CantidadOrigen",semilla.CantidadOrigen},
                                                                                                {"@idOrigen",semilla.IdOrigen},
                                                                                                {"@CantidadDestino",semilla.CantidadDestino},
                                                                                                {"@IdDestino",semilla.IdDestino},
                                                                                                {"@IdTipoContenedorDestino",semilla.IdTipoContenedorDestino},
                                                                                                {"@CantidadMuestra",semilla.CantidadMuestra},
                                                                                                {"@VolumenMuestra",semilla.VolumenMuestra},
                                                                                                {"@VolumenTotal",semilla.VolumenTotal},
                                                                                                {"@LitrosContenedor",semilla.LitrosdecimalContenedor},
                                                                                                {"@Observaciones",semilla.Observaciones},
                                                                                                {"@cantidadMortalidad", semilla.CantidadMortalidad } });
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