using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.BLL;
using Agenda.Entity;
using Newtonsoft.Json;

namespace Agenda.Site
{
    public partial class _Default : Page
    {
        //private void print(List<Usuario> listado)
        //{
        //    foreach (Usuario example in listado)
        //    {
        //        Response.Write(string.Concat("Id: ", example.id.ToString(), " Value: ", example.value));
        //        Response.Write("<BR/>");
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //instancio entidad usuario
            Usuario usuario = new Usuario { User = IDLogin.UserName, Pass = IDLogin.Password };

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            try
            {
                bool isAuthenticate = usuarioBLL.authenticateUser(usuario);

                if (isAuthenticate)
                {
                    Response.Cookies["LoginCookieVar"]["User"] = usuario.User;
                    Response.Cookies["LoginCookieVar"]["Password"] = usuario.Pass;
                    Response.Cookies["LoginCookieVar"]["UltimoAcceso"] = Convert.ToString(DateTime.Now);

                    Response.Redirect("Consulta.aspx");
                }
            }
            catch (Exception error)
            {
                Utils.Helpers.LogHelper.SaveError(error);
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }
    }
}