using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda.Site
{
    public partial class NuevoContacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarDropDownPaises();
                CargarComboGenero();
                CargarContactoInternoList();
                CargarAreaList();
                CargarActivoList();
            }

        }

        protected void GuardarContacto_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Contacto nuevoContacto = new Contacto()
                {
                    NombreApellido = NombreApellidoContacto.Text,
                    Genero = ComboGenero.SelectedValue,
                    Pais = Paises.SelectedValue,
                    Localidad = Localidad.Text,
                    Contacto_interno = ContactoInternoList.SelectedValue,
                    Organizacion = OrganizacionBox.Text,
                    Area = AreaList.SelectedValue,
                    Fecha_ingreso = DateTime.Now,
                    Activo = ActivoList.SelectedValue,
                    Direccion = DireccionContacto.Text,
                    Telefono_fijo = Int64.Parse(TelFijoContacto.Text),
                    Telefono_celular = Int64.Parse(CelContacto.Text),
                    Email = MailContacto.Text,
                    Skype = CuentaSkype.Text
                };

                List<Contacto> lista = (List<Contacto>)Application["Contactos"];

                lista.Add(nuevoContacto);

                Application["Contactos"] = lista;

                //LimpiarCampos();
                Response.Redirect("Consulta.aspx");
            }
        }

        protected void LimpiarCampos()
        {
            NombreApellidoContacto.Text = "";
            ComboGenero.SelectedValue = "-";
            Paises.SelectedValue = "Todos";
            Localidad.Text = "";
            ContactoInternoList.SelectedValue = "Todos";
            OrganizacionBox.Text = "";
            AreaList.SelectedValue = "Todos";
            ActivoList.SelectedValue = "Todos";
            DireccionContacto.Text = "";
            //TelFijoContacto = "";
            //CelContacto = "";
            MailContacto.Text = "";
            CuentaSkype.Text = "";
        }

        protected void Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consulta.aspx");
        }

        protected void CargarComboGenero()
        {
            ComboGenero.Items.Add(new ListItem("Femenino", "Femenino"));
            ComboGenero.Items.Add(new ListItem("Masculino", "Masculino"));

            ComboGenero.Items.Insert(0, new ListItem("-", "-"));
        }

        protected void CargarDropDownPaises()
        {
            Paises.Items.Add(new ListItem("Argentina", "Argentina"));
            Paises.Items.Add(new ListItem("Brasil", "Brasil"));
            Paises.Items.Add(new ListItem("Uruaguay", "Uruguay"));
            Paises.Items.Add(new ListItem("Paraguay", "Paraguay"));

            Paises.Items.Insert(0, new ListItem("Todos", "Todos"));
        }

        protected void CargarContactoInternoList()
        {
            ContactoInternoList.Items.Add(new ListItem("Si", "Si"));
            ContactoInternoList.Items.Add(new ListItem("No", "No"));

            ContactoInternoList.Items.Insert(0, new ListItem("Todos", "Todos"));
        }

        protected void CargarAreaList()
        {
            AreaList.Items.Add(new ListItem("Marketing", "Marketing"));
            AreaList.Items.Add(new ListItem("Finanzas", "Finanzas"));
            AreaList.Items.Add(new ListItem("RRHH", "RRHH"));
            AreaList.Items.Add(new ListItem("Operaciones", "Operaciones"));

            AreaList.Items.Insert(0, new ListItem("Todos", "Todos"));
        }

        protected void CargarActivoList()
        {
            ActivoList.Items.Add(new ListItem("Si", "Si"));
            ActivoList.Items.Add(new ListItem("No", "No"));

            ActivoList.Items.Insert(0, new ListItem("Todos", "Todos"));
        }
    }
}
