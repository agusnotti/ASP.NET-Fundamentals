using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public class Paginacion
    {
        public int? pageSize { get; set; }
        public int? pageIndex { get; set; }
        public string sortBy { get; set; }
        public int? order { get; set; }
        public int? RecordsCount { get; set; }
    }
}
