using Agenda.BLL;
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
                CargarPaisesList();
                CargarComboGenero();
                CargarYesNoLists();
                CargarAreaList();
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
                    Pais = new Pais() {id = Convert.ToInt32(Paises.SelectedValue)},
                    Localidad = Localidad.Text,
                    Contacto_interno = new SiNo() { id = Convert.ToInt32(ContactoInternoList.SelectedValue) },
                    Organizacion = OrganizacionBox.Text,
                    Area = new Area() { id = Convert.ToInt32(AreaList.SelectedValue) },
                    Fecha_ingreso = DateTime.Now,
                    Activo = new SiNo() { id = Convert.ToInt32(ActivoList.SelectedValue) },
                    Direccion = DireccionContacto.Text,
                    Telefono_fijo = Int64.Parse(TelFijoContacto.Text),
                    Telefono_celular = Int64.Parse(CelContacto.Text),
                    Email = MailContacto.Text,
                    Skype = CuentaSkype.Text
                };

                ContactoBLL contactoBLL = new ContactoBLL();
                contactoBLL.Insert(nuevoContacto);
                //LimpiarCampos();
                Response.Redirect("Consulta.aspx");
            }
        }

        protected void LimpiarCampos()
        {
            NombreApellidoContacto.Text = "";
            ComboGenero.SelectedValue = "-";
            Paises.SelectedValue = "0";
            Localidad.Text = "";
            ContactoInternoList.SelectedValue = "0";
            OrganizacionBox.Text = "";
            AreaList.SelectedValue = "0";
            ActivoList.SelectedValue = "0";
            DireccionContacto.Text = "";
            //TelFijoContacto = 0;
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

        }

        protected void CargarPaisesList()
        {
            PaisBLL paisBLL = new PaisBLL();

            List<Pais> listaPaises = paisBLL.getPaises();

            foreach (Pais pais in listaPaises)
            {
                Paises.Items.Add(new ListItem(pais.nombre, Convert.ToString(pais.id)));
            }
        }

        protected void CargarAreaList()
        {

            AreaBLL areaBLL = new AreaBLL();

            List<Area> listaAreas = areaBLL.getAreas();

            foreach (Area area in listaAreas)
            {
                AreaList.Items.Add(new ListItem(area.nombre, Convert.ToString(area.id)));
            }
        }

        protected void CargarYesNoLists()
        {

            SiNoBLL sinoBLL = new SiNoBLL();

            List<SiNo> listaSiNo = sinoBLL.getSiNoList();

            foreach (SiNo sino in listaSiNo)
            {
                ContactoInternoList.Items.Add(new ListItem(sino.valor, Convert.ToString(sino.id)));
                ActivoList.Items.Add(new ListItem(sino.valor, Convert.ToString(sino.id)));
            }

        }
    }
}
