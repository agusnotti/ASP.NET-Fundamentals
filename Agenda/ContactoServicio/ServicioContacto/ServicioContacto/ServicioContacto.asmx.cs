using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace ServicioContacto
{
    /// <summary>
    /// Descripción breve de ServicioContacto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioContacto : System.Web.Services.WebService
    {

        [WebMethod]
        public string ObtenerCuil(string nombreApellido, string genero)
        {
            Random _random = new Random();


            //try
            //{
                if (!string.IsNullOrEmpty(nombreApellido) && !string.IsNullOrEmpty(genero))
                {
                    int posicion1 = _random.Next(10, 99);
                    int posicion2 = _random.Next(10000000, 99999999);
                    int posicion3 = _random.Next(1, 9);

                    return posicion1.ToString() + "-" + posicion2.ToString() + "-" + posicion3.ToString();
                }
                else
                {
                    throw new SoapException("Contacto no encontrado", SoapException.ClientFaultCode);
                }
            //}
            //catch (Exception e)
            //{
            //    throw new SoapException("Contacto no encontrado", SoapException.ClientFaultCode);
            //}
        }
    }
}
