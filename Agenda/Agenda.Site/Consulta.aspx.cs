using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            }
        }

        protected void CargarDropDownPaises()
        {
            Paises.Items.Add(new ListItem("Argentina", "1"));
            Paises.Items.Add(new ListItem("Brasil", "2"));
            Paises.Items.Add(new ListItem("Uruaguay", "3"));
            Paises.Items.Add(new ListItem("Paraguay", "4"));

            Paises.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void LimpiarCampos_Click(object sender, EventArgs e)
        {
            Nombre.Text = "";
            Apellido.Text = "";
            Paises.SelectedValue = "0";
        }

        protected void CargarContactoInternoList()
        {
            ContactoInternoList.Items.Add(new ListItem("Si", "1"));
            ContactoInternoList.Items.Add(new ListItem("No", "2"));

            ContactoInternoList.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void Consultar(Object sender, EventArgs e)
        {
            List<Contacto> contactos = (List<Contacto>)Application["Contactos"];

            List<Contacto> gridData = new List<Contacto>();

            foreach (Contacto contacto in contactos)
            {
                bool incluir = true;

                if (!string.IsNullOrEmpty(Nombre.Text))
                {
                    if (!contacto.Nombre.Equals(Nombre.Text))
                    {
                        incluir = false;
                    }
                }

                if (!string.IsNullOrEmpty(Apellido.Text))
                {
                    if (!contacto.Apellido.Equals(Apellido.Text))
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

            //foreach (GridViewRow row in GridViewConsulta.Rows)
            //{
            //    row.Cells[4].Text = row.Cells[4].Text.Remove(10, 11);
            //}
        }


        protected void GridViewConsulta_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Accion1":
                    //Obtenemos el índice del registro seleccionado
                    int indiceBuscar = Convert.ToInt32(e.CommandArgument);
                    //Obtenemos la fila del registro
                    GridViewRow rowBuscar = GridViewConsulta.Rows[indiceBuscar];

                    GridViewConsulta_Accion1(rowBuscar);
                    break;

                case "Accion2":
                    int indiceEditar = Convert.ToInt32(e.CommandArgument);
                    GridViewRow rowEditar = GridViewConsulta.Rows[indiceEditar];

                    GridViewConsulta_Accion2(rowEditar);
                    break;
            }
        }

        protected void GridViewConsulta_Accion1(GridViewRow row)
        {
            //Funcionalidad Acción 1
        }

        protected void GridViewConsulta_Accion2(GridViewRow row)
        {
            //Funcionalidad Acción 2
        }
    }
}