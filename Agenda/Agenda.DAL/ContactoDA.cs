using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public class ContactoDA
    {
        private SqlConnection con;
        private DataAccessLayer da;

        public ContactoDA()
        {
            da = new DataAccessLayer();
            con = da.obtenerConexion();
        }


        public DataSet getContactosByID(int idContacto)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM contact WHERE contact.contactID = @contactID";
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@contactID", Value = idContacto, SqlDbType = SqlDbType.Int });

                adapter.SelectCommand = cmd;

                adapter.Fill(ds);

                return ds;
            }
        }

        public DataSet getListContactoByFilter(FiltroContacto filtroContacto)
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Contactos_GetByFilter";
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@name_lastname", Value = filtroContacto.nombreApellido, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@country", Value = filtroContacto.pais, SqlDbType = SqlDbType.Int });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@location", Value = filtroContacto.localidad, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@date_from", Value = filtroContacto.fecha_desde, SqlDbType = SqlDbType.DateTime });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@date_to", Value = filtroContacto.fecha_hasta, SqlDbType = SqlDbType.DateTime });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@internal_contact", Value = filtroContacto.contactoInterno, SqlDbType = SqlDbType.Bit });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@organization", Value = filtroContacto.organizacion, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@area", Value = filtroContacto.area, SqlDbType = SqlDbType.Int });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@active", Value = filtroContacto.activo, SqlDbType = SqlDbType.Bit });

                    //parametros del paginado
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = filtroContacto.paginacion == null ? null : filtroContacto.paginacion.pageSize, SqlDbType = SqlDbType.Int });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = filtroContacto.paginacion == null ? null : filtroContacto.paginacion.pageIndex, SqlDbType = SqlDbType.Int });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SortBy", Value = filtroContacto.paginacion == null ? null : filtroContacto.paginacion.sortBy, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Order", Value = filtroContacto.paginacion == null ? null : filtroContacto.paginacion.order, SqlDbType = SqlDbType.Int });


                    // Agrego esa query al adapter
                    adapter.SelectCommand = cmd;

                    // Ejecuto la query y agrego los datos al dataset
                    adapter.Fill(ds);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && filtroContacto.paginacion != null)
                    {
                        filtroContacto.paginacion.RecordsCount = Convert.ToInt32(ds.Tables[0].Rows[0]["total_records"]);
                    }

                    return ds;
                }
            }
            catch(Exception e)
            {
                return null;
            }
            
        }

        public bool Insert(Contacto contacto)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contacto_Insert";
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@name_lastname", Value = contacto.NombreApellido, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@genre", Value = contacto.Genero, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@country", Value = contacto.Pais.id, SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@location", Value = contacto.Localidad, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@internal_contact", Value = contacto.Contacto_interno.id, SqlDbType = SqlDbType.Bit });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@area", Value = contacto.Area.id, SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@active", Value = contacto.Activo.id, SqlDbType = SqlDbType.Bit });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@adress", Value = contacto.Direccion, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@phone", Value = contacto.Telefono_fijo, SqlDbType = SqlDbType.BigInt });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@cell", Value = contacto.Telefono_celular, SqlDbType = SqlDbType.BigInt });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@email", Value = contacto.Email, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@skype", Value = contacto.Skype, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@organization", Value = contacto.Organizacion, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@created_at", Value = contacto.Fecha_ingreso, SqlDbType = SqlDbType.DateTime });

                adapter.InsertCommand = cmd;

                int i = adapter.InsertCommand.ExecuteNonQuery();

                return i > 0;
            }
        }

        public bool Update(Contacto contacto)        
        {

            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contacto_update";
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@contactoID", Value = contacto.id, SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@name_lastname", Value = contacto.NombreApellido, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@genre", Value = contacto.Genero, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@country", Value = contacto.Pais.id, SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@location", Value = contacto.Localidad, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@internal_contact", Value = contacto.Contacto_interno.id, SqlDbType = SqlDbType.Bit });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@area", Value = contacto.Area.id, SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@active", Value = contacto.Activo.id, SqlDbType = SqlDbType.Bit });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@adress", Value = contacto.Direccion, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@phone", Value = contacto.Telefono_fijo, SqlDbType = SqlDbType.BigInt });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@cell", Value = contacto.Telefono_celular, SqlDbType = SqlDbType.BigInt });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@email", Value = contacto.Email, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@skype", Value = contacto.Skype, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@organization", Value = contacto.Organizacion, SqlDbType = SqlDbType.VarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@created_at", Value = contacto.Fecha_ingreso, SqlDbType = SqlDbType.DateTime });

                adapter.UpdateCommand = cmd;

                int i = adapter.UpdateCommand.ExecuteNonQuery();

                return i > 0;
            }
        }

        public bool Delete(int idContacto)
        {

            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Contacto_Delete";
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@contactID", Value = idContacto, SqlDbType = SqlDbType.Int });

                adapter.DeleteCommand = cmd;

                int i = adapter.DeleteCommand.ExecuteNonQuery();

                return i > 0;
            }
        }
    }
}
