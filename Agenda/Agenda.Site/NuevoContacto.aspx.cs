using Agenda.BLL;
using Agenda.Entity;
using Agenda.Site.net.azurewebsites.appservicesareas;
using Agenda.Site.net.azurewebsites.servicioagenda;
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
                CargarDatosContacto();
            }
        }

        private void CargarDatosContacto()
        {
            Contacto contacto = (Contacto)Application["contacto"];

            if(contacto != null)
            {
                string accion = (string) Application["accion"];
                
                cargarInputs(contacto);

                if (accion.Equals("editar")){
                    AgregarContacto.Attributes["id"] = Convert.ToString(contacto.id);
                    titulo.InnerText = "Editar Contacto";
                    AgregarContacto.Attributes.Add("onclick", "return confirm(\"¿Desea confirmar los cambios realizados al contacto?\")");

                } else if (accion.Equals("ver"))
                {
                    NombreApellidoContacto.Enabled = false;
                    ComboGenero.Enabled = false;
                    Paises.Enabled = false;
                    Localidad.Enabled = false;
                    ContactoInternoList.Enabled = false;
                    OrganizacionBox.Enabled = false;
                    AreaList.Enabled = false;
                    ActivoList.Enabled = false;
                    DireccionContacto.Enabled = false;
                    TelFijoContacto.Enabled = false;
                    CelContacto.Enabled = false;
                    MailContacto.Enabled = false;
                    CuentaSkype.Enabled = false;
                    AgregarContacto.Visible = false;

                    titulo.InnerText = "Ver Contacto";
                }
            }
            else
            {
                AgregarContacto.Attributes.Add("onclick", "return confirm(\"¿Desea dar de alta el nuevo contacto?\")");
            }

        }

        private void cargarInputs(Contacto contacto)
        {
            NombreApellidoContacto.Text = contacto.NombreApellido;
            ComboGenero.SelectedValue = contacto.Genero;
            Paises.SelectedValue = Convert.ToString(contacto.Pais.id);
            Localidad.Text = contacto.Localidad;
            ContactoInternoList.SelectedValue = Convert.ToString(contacto.Contacto_interno.id);
            OrganizacionBox.Text = contacto.Organizacion;
            AreaList.SelectedValue = Convert.ToString(contacto.Area.id);
            //Fecha_ingreso = DateTime.Now;
            ActivoList.SelectedValue = Convert.ToString(contacto.Activo.id);
            DireccionContacto.Text = contacto.Direccion;
            TelFijoContacto.Text = Convert.ToString(contacto.Telefono_fijo);
            CelContacto.Text = Convert.ToString(contacto.Telefono_celular);
            MailContacto.Text = contacto.Email;
            CuentaSkype.Text = contacto.Skype;
        }

        protected void GuardarContacto_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Contacto nuevoContacto = new Contacto()
                {
                    NombreApellido = NombreApellidoContacto.Text,
                    Genero = ComboGenero.SelectedValue,
                    Pais = new Pais() { id = Convert.ToInt32(Paises.SelectedValue) },
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
                string accion = (string)Application["accion"];

                if (accion == "editar")
                {
                    //le agrego el id a contacto
                    nuevoContacto.id = Convert.ToInt32(AgregarContacto.Attributes["id"]);
                    contactoBLL.Update(nuevoContacto);

                    redireccion();
                }
                else
                {
                    ServicioContacto servicioContacto = new ServicioContacto();
                    try
                    {
                        string cuil = servicioContacto.ObtenerCuil(nuevoContacto.NombreApellido, nuevoContacto.Genero);

                        nuevoContacto.Cuil = cuil;

                        contactoBLL.Insert(nuevoContacto);

                        redireccion();
                    } catch (Exception ex)
                    {
                        // mostrar mensaje de error en front end de no existe contacto
                    }
                }
            }
        }

        private void redireccion()
        {
            Application["accion"] = null;
            Application["contacto"] = null;
            Response.Redirect("Consulta.aspx");
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
            Application["accion"] = null;
            Application["contacto"] = null;
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
            Areas areasService = new Areas();
            string[] arrayAreas = areasService.getAreas();
   
            for (int i = 0; i < arrayAreas.Length; i++)
            {
                AreaList.Items.Add(new ListItem(arrayAreas[i], Convert.ToString(i)));
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
