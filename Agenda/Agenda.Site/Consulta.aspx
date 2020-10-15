<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="Agenda.Site.Consulta" %>

<%--Incluimos el estilo para la pantalla--%>
<link href="Content/Consulta.css" rel="stylesheet" type="text/css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <h1>Bienvenido <asp:Label ID="UserName" runat="server" CssClass="Titulo"></asp:Label> </h1>

    <form  runat="server">

        <table>
            <tr>
                <td>
                    <asp:Label ID="LabelNombre" runat="server" Text="Nombre: " CssClass="TextoConsulta"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Nombre" runat="server" CssClass="Consulta"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelApellido" runat="server" Text="Apellido: " CssClass="TextoConsulta"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Apellido" runat="server" CssClass="Consulta"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelPaises" runat="server" Text="Pais: " CssClass="TextoConsulta"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="Paises" runat="server" CssClass="Consulta"></asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="LabelLocalidad" runat="server" Text="Localidad: " CssClass="TextoConsulta"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Localidad" runat="server" CssClass="Consulta"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="FechaDesde" runat="server" Text="Fecha Ingreso desde: " CssClass="TextoConsulta"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="FechaDesdeBox" runat="server" CssClass="Consulta"></asp:TextBox>
                </td>
                <td>
                    <asp:Calendar ID="CalendarDesde" runat="server" CssClass="Consulta"></asp:Calendar>
                </td>
                <td>
                    <asp:Label ID="FechaHasta" runat="server" Text="Fecha Ingreso hasta: " CssClass="TextoConsulta"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="FechaHastaBox" runat="server" CssClass="Consulta"></asp:TextBox>
                </td>
                <td>
                    <asp:Calendar ID="CalendarHasta" runat="server" CssClass="Consulta"></asp:Calendar>
                </td>
                <td>
                    <asp:Label ID="LabelContactoInterno" runat="server" Text="Contacto interno: " CssClass="TextoConsulta"></asp:Label>
                </td>
                <td> 
                    <asp:DropDownList ID="ContactoInternoList" runat="server"></asp:DropDownList>
                </td>
            </tr>
        </table>
        

            <asp:Button ID="LimpiarCampos" runat="server" Text="Limpiar Campos" OnClick="LimpiarCampos_Click"  CssClass="button"/>
            <asp:Button ID="BotonConsulta" runat="server" Text="Consultar" OnClick="Consultar"  CssClass="button"/>


        <asp:GridView ID="GridViewConsulta" runat="server" Text="Texto" AutoGenerateColumns="true" RowStyle-HorizontalAlign="Center"
                         HeaderStyle-CssClass ="TextoConsulta" Width="100%" GridLines="Horizontal" OnRowCommand="GridViewConsulta_RowCommand">
                <Columns> 
                   <asp:ButtonField  ButtonType="Image" ImageUrl="Images/zoom.png" CommandName="Accion1"/>
                   <asp:ButtonField  ButtonType="Image" ImageUrl="Images/edit.png" CommandName="Accion2"/>
                </Columns>
         </asp:GridView>
    </form>

    
</body>
</html>
