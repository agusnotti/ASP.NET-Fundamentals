using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class UserDA
    {
        private SqlConnection con;
        private DataAccessLayer da;

        public UserDA()
        {
            // Conexion con DB
            da = new DataAccessLayer();
            con = da.obtenerConexion();
        }

        public DataSet getUser(String username)
        {
            // Sirve de adaptador entre la DB y el Data set
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                // Esto es un esquema de la DB
                DataSet ds = new DataSet();

                try
                {
                    // Creo el comando/query de SQL
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM user_agenda WHERE user_agenda.username = @username";
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@username", Value = username, SqlDbType = SqlDbType.VarChar });

                    // Agrego esa query al adapter
                    adapter.SelectCommand = cmd;

                    // Ejecuto la query y agrego los datos al dataset
                    adapter.Fill(ds);

                    da.Dispose();
                }
                catch (Exception error)
                {
                    Utils.Helpers.LogHelper.SaveError(error);
                }

                return ds;
            }
        }
    }
}
