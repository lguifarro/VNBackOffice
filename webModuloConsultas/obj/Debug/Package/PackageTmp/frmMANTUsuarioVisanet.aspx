﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PrincipalVisanet.Master" CodeBehind="frmMANTUsuarioVisanet.aspx.vb" Inherits="webModuloConsultas.frmMANTUsuarioVisanet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style1
        {
            width: 490px;
        }
        .style2
        {
            width: 300px;
        }
        .styleCajaFiltro
        {
            width: 250px;
        }
        .styleLabelFiltro
        {
            width: 100px;
            text-align:left;
        }
        .styleCampoFiltro
        {
            width: 150px;
            text-align:left;
        }
        .style5
        {
            width: 300px;
            height: 50px;
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPrincipal" runat="server">

<center>
<table>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label1" runat="server" Text="DATOS DEL USUARIO" 
                    SkinID="labelTitulo" ></asp:Label>
            </td>

        </tr>
        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label2" runat="server" Text="Id de Usuario" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:Label ID="lIdUsuario" runat="server" SkinID="labelTitulo" ></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label3" runat="server" Text="Login" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:TextBox ID="txtLogin" runat="server" SkinID="CajaTextoSkin" Width="200px" MaxLength="30"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label10" runat="server" Text="Password" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:TextBox ID="txtPassword" runat="server" SkinID="CajaTextoSkin" 
                    Width="200px" MaxLength="30" TextMode="Password"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label4" runat="server" Text="Nombre" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:TextBox ID="txtNombre" runat="server" SkinID="CajaTextoSkin" Width="200px" MaxLength="50"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label5" runat="server" Text="Apellido paterno" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:TextBox ID="txtAPaterno" runat="server" SkinID="CajaTextoSkin" Width="200px" MaxLength="50"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label6" runat="server" Text="Email" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:TextBox ID="txtEmail" runat="server" SkinID="CajaTextoSkin" Width="200px" MaxLength="50"></asp:TextBox>
            </td>

        </tr>
        
        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label8" runat="server" Text="Nivel" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:TextBox ID="txtNivel" runat="server" SkinID="CajaTextoSkin" Width="90px" MaxLength="8"></asp:TextBox>
            </td>

        </tr>
<%--
        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label9" runat="server" Text="Id Tipo" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:DropDownList runat="server" ID="cmbTipoUsuario" 
                    SkinID="DropDownListSkin" Width="200px" >
                </asp:DropDownList>                        

            </td>

        </tr>
--%>
        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label16" runat="server" Text="Estado" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                    <asp:RadioButtonList ID="rbEstado" runat="server" SkinID="RadioButtonListSkin">
                    <asp:ListItem Selected="True" Value="A">Activo</asp:ListItem>
                    <asp:ListItem Value="I">Inactivo</asp:ListItem>
                
                </asp:RadioButtonList>
            </td>
        </tr>

        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label18" runat="server" Text="Fecha registro" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:TextBox ID="txtFechaInsert" runat="server" SkinID="CajaTextoSkin" Width="120px" MaxLength="12"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="styleLabelFiltro">
                <asp:Label ID="Label19" runat="server" Text="Ult. actualización" SkinID="labelTextSkin" ></asp:Label>
            </td>
            <td class="styleCampoFiltro">
                <asp:TextBox ID="txtFechaUltActualiz" runat="server" SkinID="CajaTextoSkin" Width="120px" MaxLength="12"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:Label ID="lMensaje" runat="server" SkinID="labelTextSkin"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="center">
                <asp:Button ID="bActualizar" runat="server" Text="Actualizar" 
                    skinid="ButtonTextSkin"/>
                <asp:Button ID="bNuevo" runat="server" Text="Guardar" 
                    skinid="ButtonTextSkin"/>
            </td>

            <td align="center" >
                <asp:Button ID="bCancelar" runat="server" Text="Regresar" 
                    skinid="ButtonTextSkin"/>
            </td>
        </tr>

</table>
</center>

</asp:Content>
