<%@ Page Title="Total de tranascciones por fecha" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="frmTotalEmpresaFecha.aspx.vb" Inherits="webModuloConsultas.frmTotalEmpresaFecha" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
                                <asp:Label ID="Label1" runat="server" Text="Desde" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtFechaINI" runat="server" Text="" MaxLength="10" SkinID="CajaTextoSkin" width="80px" format="dd/MM/yyyy"></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaINI_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFechaINI" PopupButtonID="imgFechaINI">
                                </asp:CalendarExtender>
                                <asp:ImageButton ID="imgFechaINI" runat="server" ImageUrl="~/Imagenes/imgCalendario.png" />
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="Label2" runat="server" Text="Hasta" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtFechaFin" runat="server" Text="" MaxLength="10" SkinID="CajaTextoSkin" width="80px" format="dd/MM/yyyy"></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtFechaFin" PopupButtonID="imgFechaFIN">
                                </asp:CalendarExtender>
                                <asp:ImageButton ID="imgFechaFIN" runat="server" ImageUrl="~/Imagenes/imgCalendario.png" />
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
                                <asp:DropDownList ID="cmbServicio" runat="server" SkinID="DropDownListSkin" Width="150px">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="Label4" runat="server" Text="Estado" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:DropDownList ID="cmbEstado" runat="server" SkinID="DropDownListSkin" Width="150px">
                                </asp:DropDownList>
                                
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
            <td align="center">
                <asp:GridView ID="gridTran" runat="server" SkinID="gridviewSkin"    
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                    GridLines="Vertical"  >
                </asp:GridView>
            </td>
            
        </tr>
    </table>
</asp:Content>
