using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class DataAccessLayer : IDisposable
    {

        public SqlConnection connection;

        public DataAccessLayer()
        {
            connection = new SqlConnection();
        }

        public SqlConnection obtenerConexion()
        {

            try{
                connection.ConnectionString = "Data Source=localhost\\SQLExpress;" + "Initial Catalog=db_agenda;Integrated Security=true;";
                connection.Open();

                return connection;
            }
            catch(Exception e)
            {
                Utils.Helpers.LogHelper.SaveError(e);

                return null;
            }

        }
        public void Dispose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
