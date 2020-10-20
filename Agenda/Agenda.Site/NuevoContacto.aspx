<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoContacto.aspx.cs" Inherits="Agenda.Site.NuevoContacto" %>


<%--Incluimos el estilo para la pantalla--%>
<link href="Content/Consulta.css" rel="stylesheet" type="text/css"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 22%;
        }
    </style>
</head>
<body>

    <h1>Nuevo contacto</h1>
    <div class="Container">
        <form  runat="server">
            <table class="tabla_filtros">
                <tr class="tr_filtros">
                    <%-- Nombre y Apellido--%>
                    <td class="auto-style1">
                        <asp:Label ID="NombreApellido" runat="server" Text="Nombre y Apellido: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="NombreApellidoContacto" runat="server" CssClass="Consulta"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidatorNombreApellido" ValidationGroup="AgregarContactoGroup" runat="server" ErrorMessage="Ingrese un nombre y apellido" ForeColor="Red" ControlToValidate="NombreApellidoContacto"></asp:RequiredFieldValidator>
                    </td>
                    <%-- Genero --%>
                    <td>
                        <asp:Label ID="Genero" runat="server" Text="Genero: " CssClass="TextoConsulta"></asp:Label>
                        <asp:DropDownList ID="ComboGenero" runat="server" CssClass="Consulta"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="GeneroValidator" ValidationGroup="AgregarContactoGroup" runat="server" ErrorMessage="Seleccione genero" ForeColor="Red" ControlToValidate="ComboGenero" InitialValue="-"></asp:RequiredFieldValidator>
                    </td>
                    <%-- Pais --%>
                    <td>
                        <asp:Label ID="LabelPaises" runat="server" Text="Pais: " CssClass="TextoConsulta"></asp:Label>
                        <asp:DropDownList ID="Paises" runat="server" CssClass="Consulta"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="PaisValidator" ValidationGroup="AgregarContactoGroup" runat="server" ErrorMessage="Seleccione pais" ForeColor="Red" ControlToValidate="Paises" InitialValue="Todos"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr_filtros">
                    <%-- Localidad --%>
                    <td class="auto-style1">
                        <asp:Label ID="LabelLocalidad" runat="server" Text="Localidad: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="Localidad" runat="server" CssClass="Consulta"></asp:TextBox>
                    </td>
                    <%-- Contacto interno --%>
                    <td>
                        <asp:Label ID="LabelContactoInterno" runat="server" Text="Contacto interno: " CssClass="TextoConsulta"></asp:Label>
                        <asp:DropDownList ID="ContactoInternoList" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ContactoInternoValidato" ValidationGroup="AgregarContactoGroup" runat="server" ErrorMessage="Seleccione contacto interno" ForeColor="Red" ControlToValidate="ContactoInternoList" InitialValue="Todos"></asp:RequiredFieldValidator>

                    </td>
                    <%-- Organizacion --%>
                    <td class="auto-style1">
                        <asp:Label ID="OrganizacionLabel" runat="server" Text="Organizacion: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="OrganizacionBox" runat="server" CssClass="Consulta"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr_filtros">
                    <%-- area --%>
                    <td class="auto-style1">
                        <asp:Label ID="AreaLabel" runat="server" Text="Area: " CssClass="TextoConsulta"></asp:Label>
                        <asp:DropDownList ID="AreaList" runat="server"></asp:DropDownList>
                    </td>
                    <%-- activo --%>
                    <td>
                        <asp:Label ID="Activo" runat="server" Text="Activo: " CssClass="TextoConsulta"></asp:Label>
                        <asp:DropDownList ID="ActivoList" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ActivoValidator" ValidationGroup="AgregarContactoGroup" runat="server" ErrorMessage="Seleccione si el contacto esta activo" ForeColor="Red" ControlToValidate="ActivoList" InitialValue="Todos"></asp:RequiredFieldValidator>
                    </td>
                    <%-- Direccion --%>
                    <td class="auto-style1">
                        <asp:Label ID="Direccion" runat="server" Text="Direccion: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="DireccionContacto" runat="server" CssClass="Consulta"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr_filtros">
                    <%-- Tel fijo interno --%>
                    <td class="auto-style1">
                        <asp:Label ID="TelFijo" runat="server" Text="Telefono Fijo - interno: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="TelFijoContacto" Text="0" TextMode="Number" runat="server" CssClass="Consulta"></asp:TextBox>

                    </td>
                    <%-- Tel Celular --%>
                    <td>
                        <asp:Label ID="Celular" runat="server" Text="Telefono Celular: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="CelContacto" runat="server" Text="0"  TextMode="Number" CssClass="Consulta"></asp:TextBox>
                    </td>
                    <%-- Email --%>
                    <td>
                        <asp:Label ID="Mail" runat="server" Text="E-mail: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="MailContacto" runat="server"  CssClass="Consulta"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ErrorMessage="Formato invalido" ForeColor="Red" ControlToValidate="MailContacto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="EmailValidatorRequired" ValidationGroup="AgregarContactoGroup" runat="server" ErrorMessage="Ingrese el correo" ForeColor="Red" ControlToValidate="MailContacto"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr_filtros">
                    <%-- Skype --%>
                    <td class="auto-style1">
                        <asp:Label ID="Skype" runat="server" Text="Cuenta skype: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="CuentaSkype" runat="server"  CssClass="Consulta"></asp:TextBox>
                    </td>
                    <td></td>
                   <%-- <td>
                        <asp:Label ID="FechaIngreso" runat="server" Text="Fecha de ingreso: " CssClass="TextoConsulta"></asp:Label>
                        <asp:TextBox ID="FechaIngresoContacto" runat="server" TextMode="Date"  CssClass="Consulta"></asp:TextBox>
                    </td>--%>
                    <td></td>
                </tr>
            </table>
        
                <asp:Button ID="AgregarContacto" ValidationGroup="AgregarContactoGroup" runat="server" Text="Guardar" OnClick="GuardarContacto_Click"  CssClass="button"/>
                <asp:Button ID="Salir" runat="server" Text="Salir" OnClick="Salir_Click"  CssClass="buttonBlue" />
        </form>
    </div>
</body>
</html>
