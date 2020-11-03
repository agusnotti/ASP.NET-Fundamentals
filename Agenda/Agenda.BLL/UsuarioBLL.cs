using Agenda.DAL;
using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BLL
{
    public class UsuarioBLL
    {

        public bool authenticateUser(Usuario usuario)
        {
           
            UserDA da = new UserDA();
            bool resultado = false;

            try
            {
                DataSet ds = da.getUser(usuario.User);
                DataTable tblUsuario = ds.Tables[0];

                DataRow user = tblUsuario.Rows[0];


                if(usuario.User == Convert.ToString(user["username"]) && usuario.Pass == Convert.ToString(user["password"])){
                    resultado = true;
                }
            }
            catch (Exception error)
            {
                Utils.Helpers.LogHelper.SaveError(error);
            }

            return resultado;
        }

    }
}
