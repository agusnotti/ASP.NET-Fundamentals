using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    namespace Ejemplo
    {
        class Prueba2
        {
            public void ejemplo()
            {
                System.Console.WriteLine("hola");
            }

            public string getSaludo()
            {
                return "hola";
            }
        }
    }

    namespace Errores
    {

        namespace CapturarError
        {

            public static class Logger
            {
                public static void guardarError(string error)
                {

                    string pathError = ConfigurationManager.AppSettings["pathError"];
                    string fecha = System.DateTime.Now.ToString("yyyyMMdd");
                    string hora = System.DateTime.Now.ToString("HH:mm:ss");
                    //string path = "E:\\Mi unidad\\EDSA Academy\\errores.txt";

                    StreamWriter sw = new StreamWriter(pathError, true);

                    sw.WriteLine($"{fecha} , {hora} - {error}");
                    sw.WriteLine("");

                    sw.Flush();
                    sw.Close();
                }
            } 

        }

        namespace LanzarError
        {
            public static class LanzarError
            {
                public static void lanzarError()
                {
                    throw new Exception("Error");
                }
            }

        }
    }


}
