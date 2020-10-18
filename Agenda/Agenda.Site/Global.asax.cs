﻿using Agenda.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Agenda.Site
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //PARA GUARDAR EN VARIABLE DE APLICACION
            string path = "C:\\Users\\Agustin\\Desktop\\Agus\\EDSA Academy\\Ejercicios\\user.txt";
            //guardo en un string lo que tiene el archivo de text
            string lines = File.ReadAllText(path);

            //deserializar: el string del txt lo convierto en json y lo castea a un arreglo de usuarios
            List<Usuario> listCredenciales = JsonConvert.DeserializeObject<List<Usuario>>(lines);

            Application["Credenciales"] = listCredenciales;


            //GUARDAR UN CONTACTO
            List<Contacto> contactos = new List<Contacto>();

            //Contacto contacto = new Contacto
            //{
            //    Nombre = "Agustina",
            //    Apellido = "Notti",
            //    Pais = "Argentina"
            //};

            //contactos.Add(contacto);

            contactos.Add(new Contacto { NombreApellido = "Agustina Notti", Genero = "Femenino",  Pais = "Argentina", Localidad = "Tandil", Contacto_interno ="Si", Organizacion = "xxxxxxxx", Area = "RRHH", Fecha_ingreso = new DateTime(2019,11,02), Activo = "Si", Direccion = "xxxxxxx", Telefono_fijo = 1111111, Telefono_celular = 11111111, Email ="xxxxxxx", Skype = "xxxxxxxxxx" });
            contactos.Add(new Contacto { NombreApellido = "Agustin Meliendrez", Genero = "Masculino", Pais = "Argentina", Localidad = "Azul", Contacto_interno = "Si", Organizacion = "xxxxxxxx", Area = "Marketing", Fecha_ingreso = new DateTime(2018,08,02), Activo = "Si", Direccion = "xxxxxxx", Telefono_fijo = 222222, Telefono_celular = 222222, Email = "xxxxxxx", Skype = "xxxxxxxxxx" });
            contactos.Add(new Contacto { NombreApellido = "Gabi Monte", Genero = "Femenino", Pais = "Argentina", Localidad = "Rauch", Contacto_interno = "Si", Organizacion = "xxxxxxxx", Area = "Operaciones", Fecha_ingreso = new DateTime(2015, 08, 20), Activo = "No", Direccion = "xxxxxxx", Telefono_fijo = 222222, Telefono_celular = 222222, Email = "xxxxxxx", Skype = "xxxxxxxxxx" });

            Application["Contactos"] = contactos;


            //List<Entity.Usuario> lstExample = new List<Entity.Usuario>();
            //for (int i = 1; i < 11; i++)
            //{
            //    lstExample.Add
            //    (
            //        new Entity.Usuario 
            //        { 
            //            id = i,
            //            value = string.Concat("example", i.ToString()) 
            //        }
            //    );
            //}
            //Application["lstExample"] = lstExample;


        }
    }
}