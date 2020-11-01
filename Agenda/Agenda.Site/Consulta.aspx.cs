using Agenda.BLL;
using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Configuration;
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
                CargarPaisesList();
                CargarAreaList();
                CargarYesNoLists();
                //CargarFechaDesde();
                //CargarFechaHasta();
            }
        }

        protected void NuevoContacto_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoContacto.aspx");
        }


        //CARCA DE COMBOS
        protected void CargarFechaDesde()
        {
            FechaDesdeBox.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
        }

        protected void CargarFechaHasta()
        {
            FechaHastaBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void CargarPaisesList()
        {
            PaisBLL paisBLL = new PaisBLL();           

            List<Pais> listaPaises = paisBLL.getPaises();

            foreach (Pais pais in listaPaises)
            {
                Paises.Items.Add(new ListItem(pais.nombre, Convert.ToString(pais.id)));
            }

            Paises.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void CargarAreaList()
        {

            AreaBLL areaBLL = new AreaBLL();

            List<Area> listaAreas = areaBLL.getAreas();

            foreach(Area area in listaAreas)
            {
                AreaList.Items.Add(new ListItem(area.nombre, Convert.ToString(area.id)));
            }

            AreaList.Items.Insert(0, new ListItem("Todos", "0"));
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

            ContactoInternoList.Items.Insert(0, new ListItem("Todos", "-1"));
            ActivoList.Items.Insert(0, new ListItem("Todos", "-1"));

        }

        //CONSULTA CON FILTROS
        protected void Consultar(Object sender, EventArgs e)
        {
            ContactoBLL contactoBLL = new ContactoBLL();

            FiltroContacto filtro = getFiltro();    

            List<Contacto> gridData = contactoBLL.GetListContactoByFilter(filtro);

            bindGrid(gridData);
        }

        //OBTIENE LOS FILTROS PARA HACER LA CONSULTA
        private FiltroContacto getFiltro()
        {
            FiltroContacto filtro = new FiltroContacto();

            //filtro por nombre y apellido
            if (!string.IsNullOrEmpty(NombreApellido.Text))
            {
                filtro.nombreApellido = NombreApellido.Text;
            }


            //filtro por paises
            if (!string.IsNullOrEmpty(Paises.SelectedValue) && Paises.SelectedValue != "0")
            {
                filtro.pais = Convert.ToInt32(Paises.SelectedValue);
            }

            //filtro por localidad
            if (!string.IsNullOrEmpty(Localidad.Text))
            {
                filtro.localidad = Localidad.Text;
            }

            //filtro por fecha de ingreso
            if (!string.IsNullOrEmpty(FechaDesdeBox.Text))
            {
                filtro.fecha_desde = Convert.ToDateTime(FechaDesdeBox.Text);
            }

            if (!string.IsNullOrEmpty(FechaHastaBox.Text))
            {
                //FALTA ACOMODAR LA HORA A 23.59.59
                filtro.fecha_hasta = Convert.ToDateTime(FechaHastaBox.Text);
            }

            //filtro por contacto interno
            if (!string.IsNullOrEmpty(ContactoInternoList.SelectedValue) && ContactoInternoList.SelectedValue != "-1")
            {
                filtro.contactoInterno = Convert.ToInt32(ContactoInternoList.SelectedValue);
            }

            //filtro por organizacion
            if (!string.IsNullOrEmpty(OrganizacionBox.Text))
            {
                filtro.organizacion = OrganizacionBox.Text;
            }

            //filtro por area
            if (!string.IsNullOrEmpty(AreaList.SelectedValue) && AreaList.SelectedValue != "0")
            {
                filtro.area = Convert.ToInt32(AreaList.SelectedValue);
            }

            //filtro por activo
            if (!string.IsNullOrEmpty(ActivoList.SelectedValue) && ActivoList.SelectedValue != "-1")
            {
                filtro.activo = Convert.ToInt32(ActivoList.SelectedValue);
            }


            Application["filtro"] = filtro;

            return filtro;
        }


        //LIMPIA CAMPOS DE FILTROS
        protected void LimpiarCampos_Click(object sender, EventArgs e)
        {
            NombreApellido.Text = "";
            Paises.SelectedValue = "0";
            Localidad.Text = "";
            ContactoInternoList.SelectedValue = "-1";
            OrganizacionBox.Text = "";
            AreaList.SelectedValue = "0";
            ActivoList.SelectedValue = "-1";
            CargarFechaDesde();
            CargarFechaHasta();
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
                    int idContacto = Convert.ToInt32(rowEliminar.Cells[0].Text);

                    GridViewConsulta_Delete(idContacto);
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

        protected void GridViewConsulta_Delete(int idContacto)
        {
            ContactoBLL contactoBLL = new ContactoBLL();
            contactoBLL.Delete(idContacto);

            FiltroContacto filtro = (FiltroContacto)Application["filtro"];

            List<Contacto> gridData = contactoBLL.GetListContactoByFilter(filtro);

            bindGrid(gridData);


            //funcionalidad Delete


        }

        protected void GridViewConsulta_Activate(GridViewRow row)
        {
            //funcionalidad Activate
        }

        private void bindGrid(List<Contacto> gridData)
        {
            GridViewConsulta.DataSource = gridData;
            GridViewConsulta.DataBind();

            //Elimina la hora en el GRID
            foreach (GridViewRow row in GridViewConsulta.Rows)
            {
                row.Cells[8].Text = row.Cells[8].Text.Split()[0];
                row.Cells[0].Visible = false;
            }
        }

        public void ContactGridView_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
        }

    }   
}