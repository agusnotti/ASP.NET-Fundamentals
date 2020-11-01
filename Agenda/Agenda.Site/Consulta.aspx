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
            width: 30%;
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
        

                <asp:Button ID="LimpiarCampos" runat="server" Text="Limpiar Campos" OnClick="LimpiarCampos_Click"  CssClass="button"/>
                <asp:Button ID="BotonConsulta" runat="server" Text="Consultar" OnClick="Consultar"  CssClass="button"/>
                <asp:Button ID="AgregarContacto" runat="server" Text="Nuevo contacto" OnClick="NuevoContacto_Click"  CssClass="buttonBlue"/>


            <asp:GridView ID="GridViewConsulta" runat="server" Text="Texto" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"  onrowdeleting="ContactGridView_RowDeleting" 
                             HeaderStyle-CssClass="TextoConsulta" CssClass="grilla_contactos" Width="100%" GridLines="Horizontal" OnRowCommand="GridViewConsulta_RowCommand" >
                    <Columns>
                       <asp:BoundField DataField="id"/>
                       <asp:boundfield datafield="NombreApellido" headertext="Nombre y Apellido"/>
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
                       <asp:ButtonField  ButtonType="Image" ImageUrl="Images/play_pause.png" CommandName="Activate"/>
                    </Columns>

             </asp:GridView>
        </form>
    </div>

    
</body>
</html>
