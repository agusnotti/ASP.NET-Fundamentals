<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="Agenda.Site.Consulta" %>

<%--Incluimos el estilo para la pantalla--%>
<link href="Content/Consulta.css" rel="stylesheet" type="text/css"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 39%;
        }

        .accionsFiltroButtons{
            text-align:right;
            display: inline-block;
            width: 39%;
        }


        .clearFiltroButton {
            text-align: left;
             display: inline-block;
             width: 35%;
        }

        .Button {
    Width: 200px;
    background-color: Green;
    Font-Size: Larger;
    color: white;
    border-radius: 4px
}

.buttonBlue {
    Width: 200px;
    background-color: darkblue;
    Font-Size: Larger;
    color: white;
    border-radius: 4px
}


    </style>
</head>
<body>

    <h1>Consulta de Agenda</h1>

    <h2>Bienvenido <asp:Label ID="UserName" runat="server" CssClass="Titulo"></asp:Label> </h2>


    <div class="Container">

        <form  runat="server">
            <table class="tabla_filtros">
                <tr class="tr_filtros">
                    <%-- Nombre y Apellido--%>
                    <td class="auto-style1">
                        <asp:Label ID="LabelNombreApellido" runat="server" Text="Nombre y Apellido: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="NombreApellido" runat="server" CssClass="Consulta"></asp:TextBox>
                    </td>
                    <%-- Pais --%>
                    <td>
                        <asp:Label ID="LabelPaises" runat="server" Text="Pais: " CssClass="TextoConsulta"></asp:Label>
                        <asp:DropDownList ID="Paises" runat="server" CssClass="Consulta"></asp:DropDownList>
                    </td>
                    <%-- Localidad --%>
                    <td>
                        <asp:Label ID="LabelLocalidad" runat="server" Text="Localidad: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="Localidad" runat="server" CssClass="Consulta"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr_filtros">
                    <%-- Fecha_desde --%>
                    <td class="auto-style1">
                        <asp:Label ID="FechaDesde" runat="server" Text="Fecha Ingreso desde: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="FechaDesdeBox" runat="server" TextMode="Date" CssClass="Consulta"></asp:TextBox>
                    </td>
                    <%-- Fecha_hasta --%>
                    <td>
                        <asp:Label ID="FechaHasta" runat="server" Text="Fecha Ingreso hasta: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="FechaHastaBox" runat="server" TextMode="Date" CssClass="Consulta"></asp:TextBox>
                    </td>
                    <%-- Contacto interno --%>
                    <td>
                        <asp:Label ID="LabelContactoInterno" runat="server" Text="Contacto interno: " CssClass="TextoConsulta"></asp:Label>
                        <asp:DropDownList ID="ContactoInternoList" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr class="tr_filtros">
                    <%-- Organizacion --%>
                    <td class="auto-style1">
                        <asp:Label ID="OrganizacionLabel" runat="server" Text="Organizacion: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="OrganizacionBox" runat="server" CssClass="Consulta"></asp:TextBox>
                    </td>
                    <%-- area --%>
                    <td>
                        <asp:Label ID="AreaLabel" runat="server" Text="Area: " CssClass="TextoConsulta"></asp:Label>
                        <asp:DropDownList ID="AreaList" runat="server"></asp:DropDownList>
                    </td>
                    <%-- activo --%>
                    <td>
                        <asp:Label ID="Activo" runat="server" Text="Activo: " CssClass="TextoConsulta"></asp:Label>
                        <asp:DropDownList ID="ActivoList" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>          

            <div class="container">
                <div class="clearFiltroButton">
                    <asp:ImageButton ImageUrl="Images/clearFilter.png" runat="server"  OnClick="LimpiarCampos_Click" Height="32px" Width="37px"/>
                </div>
                <div class="accionsFiltroButtons">
                        <asp:Button ID="BotonConsulta" runat="server" Text="Consultar" OnClick="Consultar"  CssClass="button"/>
                        <asp:Button ID="AgregarContacto" runat="server" Text="Nuevo contacto" OnClick="NuevoContacto_Click"  CssClass="buttonBlue"/>
                </div>
            </div>
            
                    
            
              
            <asp:GridView ID="GridViewConsulta" runat="server" Text="Texto" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center" 
                DataKeyNames="id" onrowdeleting="ContactGridView_RowDeleting" HeaderStyle-CssClass="TextoConsulta" CssClass="grilla_contactos"
                Width="100%" GridLines="Horizontal" OnRowCommand="GridViewConsulta_RowCommand"
                AllowPaging="True" PageSize="5" OnPageIndexChanging="changePagination">
                    <Columns>
                       <asp:boundfield datafield="NombreApellido" headertext="Nombre y Apellido"/>
                        <asp:boundfield datafield="Cuil" headertext="Cuil"/>
                       <asp:boundfield datafield="Genero" headertext="Genero"/>
                       <asp:boundfield datafield="Pais.nombre" headertext="Pais"/>
                       <asp:boundfield datafield="Localidad" headertext="Localidad"/>
                       <asp:boundfield datafield="Contacto_interno.valor" headertext="Contacto interno"/>
                       <asp:boundfield datafield="Organizacion" headertext="Organizacion"/>
                       <asp:boundfield datafield="Area.nombre" headertext="Area"/>
                       <asp:boundfield datafield="Fecha_ingreso" headertext="Fecha de ingreso"/>
                       <asp:boundfield datafield="Activo.valor" headertext="Activo"/>
                       <asp:boundfield datafield="Direccion" headertext="Direccion"/>
                       <asp:boundfield datafield="Telefono_fijo" headertext="Telefono"/>
                       <asp:boundfield datafield="Telefono_celular" headertext="Celular"/>
                       <asp:boundfield datafield="Email" headertext="Email"/>
                       <asp:boundfield datafield="Skype" headertext="Skype"/>

                       <asp:ButtonField  ButtonType="Image" ImageUrl="Images/zoom.png" CommandName="View"/>
                       <asp:ButtonField  ButtonType="Image" ImageUrl="Images/edit.png" CommandName="Edit"/>
                       <asp:ButtonField  ButtonType="Image" ImageUrl="Images/delete.png" CommandName="Delete"/>
                       <asp:ButtonField  ButtonType="Image" ImageUrl="Images/play_pause.png" CommandName="Activate"/>                    </Columns>

             </asp:GridView>
        </form>
    </div>

    
</body>
</html>
