﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public class Contacto
    {
        public int id { get; set; }
        public string NombreApellido { get; set; }
        public string Cuil { get; set; }
        public string Genero { get; set; }
        public Pais Pais { get; set; }
        public string Localidad { get; set; }
        public SiNo Contacto_interno { get; set; }
        public string Organizacion { get; set; }
        public Area Area{ get; set; }
        public DateTime Fecha_ingreso { get; set; }
        public SiNo Activo { get; set; }
        public string Direccion { get; set; }
        public long Telefono_fijo { get; set; }
        public long Telefono_celular { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
    }
}
