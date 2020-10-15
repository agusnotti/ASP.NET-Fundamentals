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
            //Instancio mi business
            //IExampleBusiness business = new MemoryExampleBusiness((List<Example>)Application["lstExample"]);

            //Response.Write("Obtengo el registro con Id=3 y lo imprimio en pantalla:");
            //Response.Write("<BR/>");
            //Example example = business.GetExampleByID(new Example { id = 3 });
            //Response.Write(string.Concat("Id: ", example.id.ToString(), " Value: ", example.value));
            //Response.Write("<BR/>");
            //Response.Write("--------------------------------------");
            //Response.Write("<BR/>");



            //Response.Write("Actualizo el registro obtenido, lo recupero y lo imprimo en pantalla:");
            //Response.Write("<BR/>");
            //example.value = "test update Registro example3";
            //business.Update(example);
            //Example exampleUpdate = business.GetExampleByID(new Example { id = 3 });
            //Response.Write(string.Concat("Id: ", exampleUpdate.id.ToString(), " Value: ", exampleUpdate.value));
            //Response.Write("<BR/>");
            //Response.Write("--------------------------------------");
            //Response.Write("<BR/>");


            //Response.Write("Elimino el registro con Id=7:");
            //Response.Write("<BR/>");
            //business.Delete(new Example() { id = 7 });            
            //Response.Write("--------------------------------------");
            //Response.Write("<BR/>");


            //Response.Write("Inserto un nuevo registro y lo imprimo en pantalla:");
            //Response.Write("<BR/>");            
            //Example exampleInsert = business.Insert(new Example() { value =" Registro Nuevo" });
            //Response.Write(string.Concat("Id: ", exampleInsert.id.ToString(), " Value: ", exampleInsert.value));
            //Response.Write("<BR/>");
            //Response.Write("--------------------------------------");
            //Response.Write("<BR/>");



            //Response.Write("Imprimo en pantalla el listado de registros:");
            //Response.Write("<BR/>");
            //print(business.GetListExampleByFilter(new ExampleFilter()));
            //Response.Write("--------------------------------------");
            //Response.Write("<BR/>");

            //Response.Write("Imprimo en pantalla el listado de registros filtrados con el value Registro:");
            //Response.Write("<BR/>");
            //print(business.GetListExampleByFilter(new ExampleFilter() { value = "Registro" } ));
        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {

            //instancio entidad usuario
            Usuario usuario = new Usuario { User = IDLogin.UserName, Pass = IDLogin.Password };

            //traigo info de variable de aplicacion
            List<Usuario> credenciales = (List<Usuario>)Application["Credenciales"];

            foreach (Usuario credencial in credenciales)
            {
                if (credencial.User.Equals(usuario.User) && credencial.Pass.Equals(usuario.Pass))
                {
                    Response.Cookies["LoginCookieVar"]["User"] = usuario.User;
                    Response.Cookies["LoginCookieVar"]["Password"] = usuario.Pass;
                    Response.Cookies["LoginCookieVar"]["UltimoAcceso"] = Convert.ToString(DateTime.Now);

                    Response.Redirect("Consulta.aspx");
                }
            }



            //try
            //{
            //    throw new Exception("miError");
            //}
            //catch(Exception error)
            //{
            //    Utils.Helpers.LogHelper.SaveError(error);
            //}



        }
    }
}