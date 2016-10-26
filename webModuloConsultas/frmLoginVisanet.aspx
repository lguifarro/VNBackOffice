<%@ Page Title="Modulo de consultas VisaNet" Language="vb" AutoEventWireup="false" MasterPageFile="~/Login.Master" CodeBehind="frmLoginVisanet.aspx.vb" Inherits="webModuloConsultas.frmLoginVisanet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 120px;
        }
        .style2
        {
            width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>

        <table>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" Text="Usuario" class="labelLogin"  SkinID="labelTextSkin">
                    </asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtUsuarioLogin" runat="server" class="textBoxLogin" 
                        SkinID="CajaTextoSkin" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Contraseña" class="labelLogin" SkinID="labelTextSkin">
                    </asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtPasswordLogin" runat="server" class="textBoxLogin" 
                        SkinID="CajaTextoSkin" MaxLength="15" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lMensaje" runat="server" Text="" class="labelLogin">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="center">
                    <asp:Button ID="bAceptar" runat="server" Text="Aceptar" 
                        skinid="ButtonTextSkin" style="height: 21px"/>
                </td>
                <td class="style1"  align="center">
                    <asp:Button ID="bCancelar" runat="server" Text="Cancelar"  skinid="ButtonTextSkin"/>
                </td>
            </tr>
        </table>

</center>
</asp:Content>
