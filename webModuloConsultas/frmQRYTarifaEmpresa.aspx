<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PrincipalVisanet.Master" CodeBehind="frmQRYTarifaEmpresa.aspx.vb" Inherits="webModuloConsultas.frmQRYTarifaEmpresa" %>
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
            width: 381px;
        }
        .style7
        {
            width: 167px;
            text-align: right;
        }
        .style8
        {
            width: 167px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPrincipal" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
            <asp:Panel ID="panFiltros" runat="server">
                <table>
                <tr>
                    <td class="styleCajaFiltro">
                      <table style="width: 419px">
                        <tr>
                            <td class="style7" align="right" >
                                <asp:Label ID="lGrupo" runat="server" Text="Proveedor" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:DropDownList runat="server" ID="cmbEmpresa" 
                                    SkinID="DropDownListSkin" Width="200px" AutoPostBack="true">
                                </asp:DropDownList>                        
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top" class="style8" >
                                <table>
                                    <tr>
                                        <td colspan="2" align="center">
                                        <asp:Label ID="Label7" runat="server" SkinID="labelTitulo" >Configuracion de tarifa</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Tipo de calculo" SkinID="labelTextSkin"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbTipoCalculo" runat="server" 
                                                SkinID="RadioButtonListSkin" Width="84px">
                                                <asp:ListItem Selected="True" Value="U">Unico</asp:ListItem>
                                                <asp:ListItem Value="V">Variable</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Moneda" SkinID="labelTextSkin"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbMoneda" runat="server" 
                                                SkinID="RadioButtonListSkin" Width="84px">
                                                <asp:ListItem Selected="True" Value="S">Soles</asp:ListItem>
                                                <asp:ListItem Value="D">Dolares</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="bGrabarTarifa" runat="server" Text="Grabar" 
                                            skinid="ButtonTextSkin" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="center" valign="top" >
                                <table>
                                    <tr>
                                        <td colspan="2" align="center">
                                        <asp:Label ID="Label8" runat="server" SkinID="labelTitulo" >Configuracion de rangos</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Id" SkinID="labelTextSkin"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lIdTarifa" runat="server" SkinID="labelTitulo" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Desde" SkinID="labelTextSkin"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesde" runat="server" SkinID="CajaTextoSkin" Width="60px" MaxLength="12"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Hasta" SkinID="labelTextSkin"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHasta" runat="server" SkinID="CajaTextoSkin" Width="60px" MaxLength="12"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Tarifa" SkinID="labelTextSkin"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTarifa" runat="server" SkinID="CajaTextoSkin" Width="60px" MaxLength="12"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td >
                                            <asp:Button ID="bNuevo" runat="server" Text="Nuevo" 
                                                    skinid="ButtonTextSkin" />
                                        </td>
                                        <td >
                                            <asp:Button ID="bGrabar" runat="server" Text="Grabar" 
                                                    skinid="ButtonTextSkin" />
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
<table width ="100%">
    <tr>
        <td class="style6">
            <asp:GridView ID="gridTarifa" runat="server" SkinID="gridviewSkin" 
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
