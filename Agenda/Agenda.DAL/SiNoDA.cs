﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class SiNoDA
    {
        private SqlConnection con;
        private DataAccessLayer da;

        public SiNoDA()
        {
            // Conexion con DB
            da = new DataAccessLayer();
            con = da.obtenerConexion();
        }


        //es un caché en memoria de datos recuperados de una base de datos
        public DataSet getSiNo()
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
                    cmd.CommandText = "SELECT * FROM yes_no";

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
