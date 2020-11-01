using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public class FiltroContacto
    {
        public int ? id { get; set; }
        public string nombreApellido { get; set; }
        public int ? pais { get; set; }
        public string localidad { get; set; }
        public DateTime ? fecha_desde { get; set; }
        public DateTime ? fecha_hasta { get; set; }
        public int ? contactoInterno { get; set; }
        public string organizacion { get; set; }
        public int ? area { get; set; }
        public int ? activo { get; set; }

        public Paginacion paginacion;
    }
}
