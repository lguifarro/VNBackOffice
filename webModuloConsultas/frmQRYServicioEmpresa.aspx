<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PrincipalVisanet.Master" CodeBehind="frmQRYServicioEmpresa.aspx.vb" Inherits="webModuloConsultas.frmQRYServicioEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
            width: 79px;
            text-align:left;
        }
        .styleCampoFiltro
        {
            width: 150px;
            text-align:left;
        }
        .style6
    {
        width: 79px;
    }
    .style7
    {
        width: 100px;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPrincipal" runat="server">
    <center>

    <table style="width: 100%;">
        <tr>
            <td>
            <asp:Panel ID="panFiltros" runat="server">
                <table>
                <tr>
                    <td class="styleCajaFiltro">
                      <table>

                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label1" runat="server" Text="SERVICIOS POR EMPRESA" 
                                    SkinID="labelTitulo" ></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lGrupo" runat="server" Text="Proveedor" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:DropDownList runat="server" ID="cmbEmpresa" 
                                    SkinID="DropDownListSkin" Width="200px" AutoPostBack="true">
                                </asp:DropDownList>                        
                            </td>
                        </tr>
                       <tr>
                            <td class="styleLabelFiltro">
                                &nbsp;
                            </td>
                            <td class="styleCampoFiltro">
                                &nbsp;
                            </td>
                        </tr>
                      </table> 
                    </td>
                    <td class="style6">
                    &nbsp;
                    </td>
                            
                        <td>
                            <table>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="Label2" runat="server" SkinID="labelTitulo" 
                                            Text="AGREGAR A LA LISTA"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="styleLabelFiltro">
                                        <asp:Label ID="Label3" runat="server" SkinID="labelTextSkin" Text="Servicio"></asp:Label>
                                    </td>
                                    <td class="styleCampoFiltro">
                                        <asp:DropDownList ID="cmbServicio" runat="server" AutoPostBack="true" 
                                            SkinID="DropDownListSkin" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan ="2">
                                        <table>
                                            <tr>
                                                <td style="width:100px; text-align:center">
                                                    <asp:Button ID="bAdd" runat="server" skinid="ButtonTextSkin" Text="Agregar" 
                                                        Width="60px" />
                                                </td>
                                                <td style="text-align:center" class="style7">
                                                    <asp:Button ID="bRemove" runat="server" skinid="ButtonTextSkin" Text="Quitar" 
                                                        Width="60px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    
                    </tr>
                </table> 
            

            </asp:Panel>

            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lMensaje" runat="server" SkinID="labelTextSkin"></asp:Label>
            </td>
            
        </tr>
    </table>


</center>

<table width ="100%">
    <tr>
        <td>
            <asp:GridView ID="gridServicio" runat="server" SkinID="gridviewSkin" 
                CellPadding="4" ForeColor="#333333" 
                GridLines="None" AllowPaging="True" PageSize="100" 
                EnableModelValidation="False"  >
                <PagerSettings FirstPageImageUrl="~/Imagenes/page-first-icon.png" 
                    LastPageImageUrl="~/Imagenes/page-last-icon.png" />
            </asp:GridView>
        </td>
    </tr>
</table>


</asp:Content>
