using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Helpers
{
    public static class LogHelper
    {
        public static void SaveError(Exception error)
        {

            string pathError = ConfigurationManager.AppSettings["pathError"];
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            //string path = "E:\\Mi unidad\\EDSA Academy\\errores.txt";

            StreamWriter sw = new StreamWriter(pathError, true);

            sw.WriteLine($"{fecha} , {hora} - {error.Message}");
            sw.WriteLine("");

            sw.Flush();
            sw.Close();
        }
    }
}
