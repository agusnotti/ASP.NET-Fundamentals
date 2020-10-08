using ConsoleApp1.Errores.LanzarError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejemplo.Prueba2 prueba2 = new Ejemplo.Prueba2(); //instancio la clase
            prueba2.ejemplo();

            prueba2.getSaludo();


            // Class1 es static, con metodos estaticos... no necesito instanciar. Se agrega en referencias


            try
            {
                Errores.LanzarError.LanzarError.lanzarError();
            }
            catch(Exception error)
            {
                Errores.CapturarError.Logger.guardarError(error.Message);
            }

        }
    }
}
