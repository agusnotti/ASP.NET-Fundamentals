using Agenda.DAL;
using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BLL
{
    public class ContactoBLL : IContacto
    {
        private ContactoDA da;

        public ContactoBLL()
        {
            da = new ContactoDA();
        }

        public Contacto GetContactoByID(int idContacto)
        {
            DataSet ds = da.getContactosByID(idContacto);

            DataTable tblContacto = ds.Tables[0];

            DataRow resultado = tblContacto.Rows[0];

            Contacto contacto = new Contacto();

            contacto.id = Convert.ToInt32(resultado["contactID"]);
            contacto.NombreApellido = Convert.ToString(resultado["name_lastname"]);
            contacto.Genero = Convert.ToString(resultado["genre"]);
            contacto.Pais = new Pais() { id = Convert.ToInt32(resultado["countryID"])};
            contacto.Localidad = Convert.ToString(resultado["location"]);
            contacto.Contacto_interno = new SiNo() { id = Convert.ToInt32(resultado["internal_contact"])};
            contacto.Area = new Area() { id = Convert.ToInt32(resultado["area"])};
            contacto.Activo= new SiNo() { id = Convert.ToInt32(resultado["active"])};
            contacto.Direccion = Convert.ToString(resultado["adress"]);
            contacto.Telefono_fijo = Convert.ToInt64(resultado["phone"]);
            contacto.Telefono_celular = Convert.ToInt64(resultado["cell"]);
            contacto.Email = Convert.ToString(resultado["email"]);
            contacto.Skype = Convert.ToString(resultado["skype"]);
            contacto.Organizacion = Convert.ToString(resultado["organization"]);
            contacto.Fecha_ingreso = Convert.ToDateTime(resultado["created_at"]);

            return contacto; 
        }

        public List<Contacto> GetListContactoByFilter(FiltroContacto filtroContacto)
        {
            DataSet ds = da.getListContactoByFilter(filtroContacto);

            List<Contacto> resultado = new List<Contacto>();

            DataTable tblContactos = ds.Tables[0];

            foreach (DataRow dr in tblContactos.Rows)
            {
                Contacto contacto = new Contacto();
                contacto.id = Convert.ToInt32(dr["contactID"]);
                contacto.NombreApellido = Convert.ToString(dr["name_lastname"]);
                contacto.Genero = Convert.ToString(dr["genre"]);
                contacto.Pais = new Pais() {id = Convert.ToInt32(dr["countryID"]), nombre = Convert.ToString(dr["country_name"])};
                contacto.Localidad = Convert.ToString(dr["location"]);
                contacto.Contacto_interno = new SiNo() { id = Convert.ToInt32(dr["internal_contactID"]), valor = Convert.ToString(dr["internal_contact_value"])};
                contacto.Area = new Area() { id = Convert.ToInt32(dr["areaID"]), nombre = Convert.ToString(dr["area_name"])};
                contacto.Activo = new SiNo() { id = Convert.ToInt32(dr["activeID"]), valor = Convert.ToString(dr["active_value"])};
                contacto.Direccion = Convert.ToString(dr["adress"]);
                contacto.Telefono_fijo = Convert.ToInt64(dr["phone"]);
                contacto.Telefono_celular = Convert.ToInt64(dr["cell"]);
                contacto.Email = Convert.ToString(dr["email"]);
                contacto.Skype = Convert.ToString(dr["skype"]);
                contacto.Organizacion = Convert.ToString(dr["organization"]);
                contacto.Fecha_ingreso = Convert.ToDateTime(dr["created_at"]);


                resultado.Add(contacto);
            }

            return resultado;
        }

        public void Insert(Contacto contacto)
        {
            da.Insert(contacto); //me devuelve un booleano
        }

        public void Update(Contacto contacto)
        {
            da.Update(contacto);
        }

        public void Delete(int idContacto)
        {
            da.Delete(idContacto);
        }

        public void Activate(int idContacto)
        {
            Contacto contacto = GetContactoByID(idContacto);
            if(contacto.Activo.id == 0)
            {
                contacto.Activo.id = 1;
            } else
            {
                contacto.Activo.id = 0;
            }

            da.Update(contacto);
        }
    }
}
