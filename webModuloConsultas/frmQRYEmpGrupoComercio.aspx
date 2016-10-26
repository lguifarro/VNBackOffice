<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="frmQRYEmpGrupoComercio.aspx.vb" Inherits="webModuloConsultas.frmQRYEmpGrupoComercio" %>
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
                                <asp:Label ID="lNombreGrupo" runat="server" Text="Grupo" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtGrupo" runat="server" Text="" MaxLength="30" SkinID="CajaTextoSkin" width="120px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="styleLabelFiltro">
                                <asp:Label ID="lRUC" runat="server" Text="RUC" SkinID="labelTextSkin"></asp:Label>
                            </td>
                            <td class="styleCampoFiltro">
                                <asp:TextBox ID="txtRUC" runat="server" Text="" MaxLength="30" SkinID="CajaTextoSkin" width="180px"></asp:TextBox>
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
    </table>
<table width ="100%">
    <tr>
        <td>
            <asp:GridView ID="gridGrupo" runat="server" SkinID="gridviewSkin" 
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
