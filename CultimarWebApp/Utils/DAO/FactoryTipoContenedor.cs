using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{


    internal class FactoryTipoContenedor
    {


        public List<ObjetoTipoContenedor> ListadoContenedorOrigen()
        {
            var ListadoContenedoresOrgigen= new List<ObjetoTipoContenedor>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_TipoContenedor", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"pTipo", "Origen"}
                                                                                              });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoTipoContenedor();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdContenedor = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreContenedor = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    ListadoContenedoresOrgigen.Add(resultadoListado);
                }
            }
            return ListadoContenedoresOrgigen;
        }


        public List<ObjetoTipoContenedor> ListadoContenedorDestino()
        {
            var ListadoContenedoresOrgigen = new List<ObjetoTipoContenedor>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_TipoContenedor", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"pTipo", "Destino"}
                                                                                              });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoTipoContenedor();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdContenedor = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.NombreContenedor = validador != null ? data.Rows[i].Field<string>("Nombre") : "NO ASIGNADO";

                    ListadoContenedoresOrgigen.Add(resultadoListado);
                }
            }
            return ListadoContenedoresOrgigen;
        }

 
 

    }
}