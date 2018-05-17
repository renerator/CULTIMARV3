using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CultimarWebApp.Utils
{
    public sealed class DBConector
    {
        /// <summary>
        /// Base de ejecucion del SP
        /// </summary>
        /// <param name="spName">Nombre del SP</param>
        /// <param name="sqlParametersIn">Parametros de entrada HASHTABLE</param>
        /// <returns>RESULTADO del SP ejecutado</returns>
        public DataTable EjecutarProcedimientoAlmacenado(string spName, System.Collections.Hashtable sqlParametersIn)
        {
            return this.ObtenerProcedimientoAlmacenado(spName, sqlParametersIn, null, null);
        }

        /// <summary>
        /// clase de obtencion del SP para su ejecucion
        /// </summary>
        /// <param name="spName">Nombre del SP</param>
        /// <param name="sqlParametersIn">Parametros de entrada Hastable</param>
        /// <param name="singleParameter">Parametros de entrada singulares</param>
        /// <param name="transaccion">identifica si se realiza la ejecucion con tipo transac</param>
        /// <returns>DataTable con los datos de la ejecucion del SP</returns>
        private DataTable ObtenerProcedimientoAlmacenado(string spName, System.Collections.Hashtable sqlParametersIn, SqlParameter singleParameter, SqlTransaction transaccion)
        {
            var sqlCommand = new SqlCommand(spName);
            var adapter = new SqlDataAdapter();
            var aData = new DataTable();
            if (sqlParametersIn != null && sqlParametersIn.Count > 0)
            {
                foreach (System.Collections.DictionaryEntry sqlParameter in sqlParametersIn)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.Key.ToString(), sqlParameter.Value));
                }
            }
            else if (singleParameter != null)
            {
                sqlCommand.Parameters.Add(singleParameter);
            }
            try
            {
                sqlCommand.Connection = new SqlConnection(DataSource.coneccionPrimaria);
                sqlCommand.Connection.Open();
                if (transaccion != null)
                {
                    sqlCommand.Transaction = transaccion;
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(aData);
                return aData;
            }
            catch
            {
                try
                {
                    sqlCommand.Connection = new SqlConnection(DataSource.coneccionPrimaria);
                    sqlCommand.Connection.Open();
                    if (transaccion != null)
                    {
                        sqlCommand.Transaction = transaccion;
                    }
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand = sqlCommand;
                    adapter.Fill(aData);
                    return aData;
                }
                catch (SqlException e)
                {
                    throw (new CapturaExcepciones(e));
                }
                catch (Exception e)
                {
                    throw (new CapturaExcepciones(e));
                }
            }
            finally
            {
                adapter = null;
                aData = null;
                sqlCommand.Connection.Close();
                sqlCommand = null;
            }

        }
    }
}
