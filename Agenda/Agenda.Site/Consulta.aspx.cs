using Agenda.BLL;
using Agenda.Entity;
using Agenda.Site.net.azurewebsites.appservicesareas;
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
                CargarFechaDesde();
                CargarFechaHasta();
                CargarFiltros();
            }
        }

        private void CargarFiltros()
        {
            
            FiltroContacto filtro = (FiltroContacto)Application["filtro"];

            if(filtro != null)
            {
                ContactoBLL contactoBLL = new ContactoBLL();

                List<Contacto> gridData = contactoBLL.GetListContactoByFilter(filtro);

                bindGrid(gridData);
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
            Areas areasService = new Areas();

            string[] arrayAreas = areasService.getAreas();

            //AreaBLL areaBLL = new AreaBLL();
            //List<Area> listaAreas = areaBLL.getAreas();

            for (int i = 0; i < arrayAreas.Length; i++)
            {
                AreaList.Items.Add(new ListItem(arrayAreas[i], Convert.ToString(i)));
            }

            AreaList.Items.Insert(0, new ListItem("Todos", "-1"));
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
                
                DateTime fechaHasta = Convert.ToDateTime(FechaHastaBox.Text);
                TimeSpan horaHasta = new TimeSpan(23, 59, 59);
                filtro.fecha_hasta = fechaHasta.Date + horaHasta;
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
            if (!string.IsNullOrEmpty(AreaList.SelectedValue) && AreaList.SelectedValue != "-1")
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
            AreaList.SelectedValue = "-1";
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
                    int idView = Convert.ToInt32(GridViewConsulta.DataKeys[indiceBuscar].Values[0]);

                    GridViewConsulta_View(idView);
                    break;

                case "Edit":
                    int indiceEditar = Convert.ToInt32(e.CommandArgument);
                    //obtiene el valor de la columa desde DataKeys usando el indice de la fila
                    int idEditar = Convert.ToInt32(GridViewConsulta.DataKeys[indiceEditar].Values[0]);

                    GridViewConsulta_Edit(idEditar);
                    break;

                case "Delete":
                    int indiceEliminar = Convert.ToInt32(e.CommandArgument);

                    //obtiene el valor de la columa desde DataKeys usando el indice de la fila
                    int idBorrar = Convert.ToInt32(GridViewConsulta.DataKeys[indiceEliminar].Values[0]);

                    GridViewConsulta_Delete(idBorrar);
                    break;

                case "Activate":
                    int indiceActivar = Convert.ToInt32(e.CommandArgument);
                    //obtiene el valor de la columa desde DataKeys usando el indice de la fila
                    int idActivar = Convert.ToInt32(GridViewConsulta.DataKeys[indiceActivar].Values[0]);

                    GridViewConsulta_Activate(idActivar);
                    break;
            }
        }

        protected void GridViewConsulta_View(int id)
        {
            ContactoBLL contactoBLL = new ContactoBLL();
            Contacto contacto = contactoBLL.GetContactoByID(id);

            Application["contacto"] = contacto;
            Application["accion"] = "ver";
            Response.Redirect("NuevoContacto.aspx");
        }

        protected void GridViewConsulta_Edit(int id)
        {
            ContactoBLL contactoBLL = new ContactoBLL();
            Contacto contacto = contactoBLL.GetContactoByID(id);

            Application["contacto"] = contacto;
            Application["accion"] = "editar";
            Response.Redirect("NuevoContacto.aspx");
        }

        protected void GridViewConsulta_Delete(int idContacto)
        {
            ContactoBLL contactoBLL = new ContactoBLL();
            contactoBLL.Delete(idContacto);

            FiltroContacto filtro = (FiltroContacto)Application["filtro"];

            List<Contacto> gridData = contactoBLL.GetListContactoByFilter(filtro);

            bindGrid(gridData);
        }

        protected void GridViewConsulta_Activate(int idContacto)
        {
            ContactoBLL contactoBLL = new ContactoBLL();
            contactoBLL.Activate(idContacto);

            FiltroContacto filtro = (FiltroContacto)Application["filtro"];

            List<Contacto> gridData = contactoBLL.GetListContactoByFilter(filtro);

            bindGrid(gridData);
        }

        private void bindGrid(List<Contacto> gridData)
        {
            Areas areasService = new Areas();

            string[] arrayAreas = areasService.getAreas();

            foreach (Contacto contacto in gridData)
            {
                contacto.Area.nombre = arrayAreas[contacto.Area.id];
            }


            GridViewConsulta.DataSource = gridData;
            GridViewConsulta.DataBind();

            
            foreach (GridViewRow row in GridViewConsulta.Rows)
            {
                //Elimina la hora en el GRID
                row.Cells[8].Text = row.Cells[8].Text.Split()[0];

                //mensaje de confirmacion delete
                row.Cells[17].Attributes.Add("onclick", "return confirm(\"¿Desea eliminar el contacto?\")");

                ImageButton imageButton = (ImageButton)row.Cells[18].Controls[0];
                
                if (row.Cells[9].Text == "Si")
                {
                    imageButton.ImageUrl = "Images/anular.png";
                    //mensaje de confirmacion inactivacion
                    row.Cells[18].Attributes.Add("onclick", "return confirm(\"¿Desea inactivar el contacto?\")");
                } else
                {
                    //mensaje de confirmacion de activacion
                    row.Cells[18].Attributes.Add("onclick", "return confirm(\"¿Desea activar el contacto?\")");
                }
            }
        }

        public void ContactGridView_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void changePagination(object sender, GridViewPageEventArgs e)
        {
            GridViewConsulta.PageIndex = e.NewPageIndex;
            Consultar(sender, e);
        }

    }   
}