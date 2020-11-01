using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class AreaDA
    {
        private SqlConnection con;
        private DataAccessLayer da;

        public AreaDA()
        {
            da = new DataAccessLayer();
            con = da.obtenerConexion();
        }

        public DataSet getAreas()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM AREA";

                adapter.SelectCommand = cmd;

                adapter.Fill(ds);

                da.Dispose();

                return ds;
            }
        }

    }
}
