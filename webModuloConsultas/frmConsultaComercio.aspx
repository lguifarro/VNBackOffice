<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PrincipalComercio.Master" CodeBehind="frmConsultaComercio.aspx.vb" Inherits="webModuloConsultas.frmConsultaComercio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
            width: 79px;
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
<table style="width: 100%;">
        <tr>
            <td>
            <asp:Panel ID="panFiltros" runat="server">
                <table>
                <tr>
                    <td class="styleCajaFiltro">
                      <table>
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lCodComercio" runat="server" Text="Código" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtCodComercio" runat="server" Text="" MaxLength="9" SkinID="CajaTextoSkin" width="80px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lNumTerminal" runat="server" Text="Terminal" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtNumTerminal" runat="server" Text="" MaxLength="8" SkinID="CajaTextoSkin" width="80px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lIdTran" runat="server" Text="Id Tran" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtIdTran" runat="server" Text="" MaxLength="6" SkinID="CajaTextoSkin" width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="Label1" runat="server" Text="Desde" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtFechaINI" runat="server" Text="" MaxLength="10" SkinID="CajaTextoSkin" width="80px" format="dd/MM/yyyy"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaINI" runat="server" ImageUrl="~/Imagenes/imgCalendario.png" />
                                <cc1:CalendarExtender ID="txtFechaINI_CE" runat="server"
                                    TargetControlID="txtFechaINI" PopupButtonID="imgFechaINI">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="Label2" runat="server" Text="Hasta" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtFechaFin" runat="server" Text="" MaxLength="10" SkinID="CajaTextoSkin" width="80px" format="dd/MM/yyyy"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaFIN" runat="server" ImageUrl="~/Imagenes/imgCalendario.png" />
                                <cc1:CalendarExtender ID="txtFechaFIN_CE" runat="server"
                                    TargetControlID="txtFechaFIN" PopupButtonID="imgFechaFIN">
                                </cc1:CalendarExtender>

                            </td>
                        </tr>

                      </table> 
                    </td>

                    <td class="styleCajaFiltro">
                      <table>
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="Label3" runat="server" Text="Servicio" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:DropDownList ID="cmbServicio" runat="server" SkinID="DropDownListSkin" 
                                    Width="180px">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="Label4" runat="server" Text="Estado" SkinID="labelTextSkin" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:DropDownList ID="cmbEstado" runat="server" SkinID="DropDownListSkin" 
                                    Width="120px" Visible="False">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>

                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lDatosApp1" runat="server" SkinID="labelTextSkin" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtDatosApp1" runat="server" Text="" SkinID="CajaTextoSkin" 
                                    width="60px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lDatosApp2" runat="server" SkinID="labelTextSkin" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtDatosApp2" runat="server" Text="" SkinID="CajaTextoSkin" 
                                    width="60px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lDatosApp3" runat="server" SkinID="labelTextSkin" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtDatosApp3" runat="server" Text="" SkinID="CajaTextoSkin" 
                                    width="60px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>

                      </table> 
                    </td>


                    <td class="styleCajaFiltro">
                      <table>
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lDatosApp4" runat="server" SkinID="labelTextSkin" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtDatosApp4" runat="server" Text="" SkinID="CajaTextoSkin" 
                                    width="60px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lDatosApp5" runat="server" SkinID="labelTextSkin" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtDatosApp5" runat="server" Text="" SkinID="CajaTextoSkin" 
                                    width="60px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lDatosApp6" runat="server" SkinID="labelTextSkin" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtDatosApp6" runat="server" Text="" SkinID="CajaTextoSkin" 
                                    width="60px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lDatosApp7" runat="server" SkinID="labelTextSkin" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtDatosApp7" runat="server" Text="" SkinID="CajaTextoSkin" 
                                    width="60px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lDatosApp8" runat="server" SkinID="labelTextSkin" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtDatosApp8" runat="server" Text="" SkinID="CajaTextoSkin" 
                                    width="60px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>

                      </table> 
                    </td>
                    <td>
                    </td>

                </tr>
                </table> 
            

            </asp:Panel>

            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                    <td style="width:100px; text-align:center">
                        <asp:Button ID="bConsultar" runat="server" Text="Consultar" 
                            skinid="ButtonTextSkin" />
                    </td>
                    <td style="width:100px; text-align:center">
                        <asp:Button ID="bExportar" runat="server" Text="Exportar" 
                            skinid="ButtonTextSkin" />
                    </td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="lMensaje" runat="server" SkinID="labelTextSkin"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gridTran" runat="server" SkinID="gridviewSkin"    
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                    GridLines="Vertical" AllowPaging="True" PageSize="100"  >
                    <PagerSettings FirstPageImageUrl="~/Imagenes/page-first-icon.png" 
                        LastPageImageUrl="~/Imagenes/page-last-icon.png" />
                </asp:GridView>
            </td>
            
        </tr>
    </table>
</asp:Content>
