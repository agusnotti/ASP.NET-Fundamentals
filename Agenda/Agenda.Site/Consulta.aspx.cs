using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda.Site
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserName.Text = Convert.ToString(Request.Cookies["LoginCookieVar"]["User"]);
                CargarDropDownPaises();
                CargarContactoInternoList();
                CargarAreaList();
                CargarActivoList();
                //CargarFechaDesde();
                //CargarFechaHasta();
            }
        }

        protected void NuevoContacto_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoContacto.aspx");
        }

        protected void CargarFechaDesde()
        {
            FechaDesdeBox.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
        }

        protected void CargarFechaHasta()
        {
            FechaHastaBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
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

        protected void LimpiarCampos_Click(object sender, EventArgs e)
        {
            NombreApellido.Text = "";
            Paises.SelectedValue = "Todos";
            Localidad.Text = "";
            ContactoInternoList.SelectedValue = "Todos";
            OrganizacionBox.Text = "";
            AreaList.SelectedValue = "Todos";
            ActivoList.SelectedValue = "Todos";
            CargarFechaDesde();
            CargarFechaHasta();
        }

        protected void Consultar(Object sender, EventArgs e)
        {
            List<Contacto> contactos = (List<Contacto>)Application["Contactos"];

            List<Contacto> gridData = new List<Contacto>();

            foreach (Contacto contacto in contactos)
            {
                bool incluir = true;

                //filtro por nombre y apellido
                if (!string.IsNullOrEmpty(NombreApellido.Text))
                {
                    if (!contacto.NombreApellido.Equals(NombreApellido.Text))
                    {
                        incluir = false;
                    }
                }


                //filtro por paises
                if (!string.IsNullOrEmpty(Paises.SelectedValue) && Paises.SelectedValue != "Todos")
                {
                    if (!contacto.Pais.Equals(Paises.SelectedValue))
                    {
                        incluir = false;
                    }
                }

                //filtro por localidad
                if (!string.IsNullOrEmpty(Localidad.Text))
                {
                    if (!contacto.Localidad.Equals(Localidad.Text))
                    {
                        incluir = false;
                    }
                }

                //filtro por fecha de ingreso
                if (!string.IsNullOrEmpty(FechaDesdeBox.Text) && !string.IsNullOrEmpty(FechaHastaBox.Text))
                {
                    if ((contacto.Fecha_ingreso < Convert.ToDateTime(FechaDesdeBox.Text)) || (contacto.Fecha_ingreso > Convert.ToDateTime(FechaHastaBox.Text)))
                    {
                        incluir = false;
                    }
                }

                //filtro por contacto interno
                if (!string.IsNullOrEmpty(ContactoInternoList.SelectedValue) && ContactoInternoList.SelectedValue != "Todos")
                {
                    if (!contacto.Contacto_interno.Equals(ContactoInternoList.SelectedValue))
                    {
                        incluir = false;
                    }
                }

                //filtro por organizacion
                if (!string.IsNullOrEmpty(OrganizacionBox.Text))
                {
                    if (!contacto.Organizacion.Equals(OrganizacionBox.Text))
                    {
                        incluir = false;
                    }
                }

                //filtro por area
                if (!string.IsNullOrEmpty(AreaList.SelectedValue) && AreaList.SelectedValue != "Todos")
                {
                    if (!contacto.Area.Equals(AreaList.SelectedValue))
                    {
                        incluir = false;
                    }
                }

                //filtro por activo
                if (!string.IsNullOrEmpty(ActivoList.SelectedValue) && ActivoList.SelectedValue != "Todos")
                {
                    if (!contacto.Activo.Equals(ActivoList.SelectedValue))
                    {
                        incluir = false;
                    }
                }

                if (incluir)
                {
                    gridData.Add(contacto);
                }
            }

            GridViewConsulta.DataSource = gridData;
            GridViewConsulta.DataBind();

            // Elimina la hora en el GRID
            foreach (GridViewRow row in GridViewConsulta.Rows)
            {
                row.Cells[11].Text = row.Cells[11].Text.Split()[0];
            }
        }

 
        protected void GridViewConsulta_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "View":
                    //Obtenemos el índice del registro seleccionado
                    int indiceBuscar = Convert.ToInt32(e.CommandArgument);
                    //Obtenemos la fila del registro
                    GridViewRow rowBuscar = GridViewConsulta.Rows[indiceBuscar];

                    GridViewConsulta_View(rowBuscar);
                    break;

                case "Edit":
                    int indiceEditar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowEditar = GridViewConsulta.Rows[indiceEditar];

                    GridViewConsulta_Edit(rowEditar);
                    break;

                case "Delete":
                    int indiceEliminar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowEliminar = GridViewConsulta.Rows[indiceEliminar];

                    GridViewConsulta_Delete(rowEliminar);
                    break;

                case "Activate":
                    int indiceActivar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowActivar = GridViewConsulta.Rows[indiceActivar];

                    GridViewConsulta_Activate(rowActivar);
                    break;
            }
        }

        protected void GridViewConsulta_View(GridViewRow row)
        {
            //Funcionalidad View
        }

        protected void GridViewConsulta_Edit(GridViewRow row)
        {
            //Funcionalidad Edit
        }

        protected void GridViewConsulta_Delete(GridViewRow row)
        {
            //funcionalidad Delete


        }

        protected void GridViewConsulta_Activate(GridViewRow row)
        {
            //funcionalidad Activate
        }

    }   
}