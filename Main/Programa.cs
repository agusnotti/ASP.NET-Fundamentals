using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Programa
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ingrese un nombre: ");
            string nombre = Console.ReadLine(); //nombre que se ingresa por consola

            Console.WriteLine(clase01.Saludo.saludar(nombre));

            Console.ReadKey();
        }
    }
}
