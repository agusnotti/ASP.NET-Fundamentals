using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BLL
{
    interface IContacto
    {
        Contacto GetContactoByID(int idContacto);
        List<Contacto> GetListContactoByFilter(FiltroContacto filtroContacto);
        void Insert(Contacto contacto);
        void Update(Contacto contacto);
        void Delete(int idContacto);
    }
}
