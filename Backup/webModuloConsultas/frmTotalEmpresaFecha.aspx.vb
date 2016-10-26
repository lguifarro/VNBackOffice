Imports IBM.Data.DB2
Imports ClsConsultas
Imports System.IO

Public Class frmTotalEmpresaFecha
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If bValidaUsuarioSesion(enTipoUsuario.iEmpresa, Session) = False Then
            Response.Redirect(FORM_LOGIN)
        End If
        'If Session(SES_USUARIO) Is Nothing Then
        '    Response.Redirect(FORM_LOGIN)
        'End If

        Dim iIdEmpresa As Integer
        Dim cUsuario As ClsUsuarioSesion
        Dim sMensaje As String = ""

        cUsuario = Session(SES_USUARIO)
        iIdEmpresa = cUsuario.getIdComercio
        Session(SES_IDEMPRESA) = iIdEmpresa

        If Not IsPostBack Then
            subLoadCmbServicios()
            subLoadCmbEstados()

        End If

    End Sub

    Protected Sub subFormatoGrid(ByRef GV As GridView, Optional ByVal bExportar As Boolean = False)

        Dim b As BoundField

        GV.Columns.Clear()

        b = New BoundField
        b.DataField = "LOGPO_CMCIO_ID"
        b.HeaderText = "Id Empresa"
        b.HeaderStyle.Width = 90
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "NOMCOMERCIO"
        b.HeaderText = "Empresa"
        b.HeaderStyle.Width = 200
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "FECHA"
        b.HeaderText = "Fecha"
        b.HeaderStyle.Width = 120
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "NUMTRAN"
        b.HeaderText = "# Txn"
        b.HeaderStyle.Width = 80
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "IMPORTETOTAL"
        b.HeaderText = "Total"
        b.HeaderStyle.Width = 150
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Right
        b.DataFormatString = "{0:N2}"
        GV.Columns.Add(b)

        'ancho del grid
        Dim iAncho As Long
        For i = 1 To GV.Columns.Count - 1
            iAncho = iAncho + GV.Columns(i).HeaderStyle.Width.Value
        Next
        GV.Width = iAncho
    End Sub

    Protected Sub subLoadCmbServicios()
        Dim lista As ClsListaServicio
        Dim oServicio As ClsService

        lista = Session(SES_LISTSERVICIO)
        Dim i As Integer
        Dim iServicio As System.Web.UI.WebControls.ListItem
        For i = 0 To lista.Count - 1
            oServicio = lista.getItem(i)
            iServicio = New System.Web.UI.WebControls.ListItem
            iServicio.Text = oServicio.getName
            iServicio.Value = oServicio.getId

            Me.cmbServicio.Items.Add(iServicio)

        Next

    End Sub
    Protected Sub subLoadCmbEstados()
        Dim lista As ClsListaEstado
        Dim oEstado As ClsEstado

        lista = Session(SES_ESTADOS)
        Dim i As Integer
        Dim iEstado As System.Web.UI.WebControls.ListItem

        For i = 0 To lista.Count - 1
            oEstado = lista.getItem(i)
            iEstado = New System.Web.UI.WebControls.ListItem
            iEstado.Text = oEstado.getName
            iEstado.Value = oEstado.getCodRespuesta

            Me.cmbEstado.Items.Add(iEstado)

        Next

    End Sub

    Protected Sub bConsultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bConsultar.Click

        subConsultaTran()

    End Sub

    Public Sub ExportaGrid(ByVal ds As DataSet)
        'export the Gridview to an excel document called Data.xls
        'Dim DGaux As New DataGrid

        'DGaux.DataSource = DG.DataSource
        'DGaux.DataBind()

        'Response.Clear()
        'Response.AddHeader("content-disposition", "attachment;filename=Data.xls")
        'Response.Charset = ""
        'Response.ContentType = "application/vnd.xls"
        'Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter
        'Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)

        'DGaux.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString)
        'Response.End()

        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As StringWriter = New StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim form As New HtmlForm

        Dim GV As New GridView
        subFormatoGrid(GV, True)
        GV.AutoGenerateColumns = False
        GV.DataSource = ds
        GV.DataBind()

        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(GV)
        pagina.RenderControl(htw)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls")
        Response.Charset = "UTF-8"

        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()

        GV = Nothing

    End Sub

    Protected Sub bExportar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bExportar.Click

        subConsultaTran(True)

    End Sub

    Public Sub subConsultaTran(Optional ByVal bExportar As Boolean = False)


        'consultar en la base de datos
        Dim cConsulta As New ClsConsultas.ClsConsultaDB

        Dim cUsuario As ClsUsuarioSesion
        Dim iIdEmpresa As Integer

        cUsuario = Session(SES_USUARIO)
        iIdEmpresa = cUsuario.getIdComercio

        'parámetros de búsqueda
        Dim sFechaINI As String = ""
        Dim sFechaFIN As String = ""
        Dim dFechaINI As Date
        Dim dFechaFIN As Date
        Dim sServicio As String = ""
        Dim iIdServicio As Integer
        Dim sCR As String = ""

        ' validacion de datos
        If Not (bValidaCampos()) Then
            Exit Sub
        End If

        'seleccion de valores
        sCR = Me.cmbEstado.SelectedValue
        sServicio = Me.cmbServicio.SelectedValue

        If sCR = sCodTODOS Then sCR = ""
        If sServicio = sCodTODOS Then sServicio = "0"

        'captura de datos
        iIdServicio = CInt(sServicio)
        If Me.txtFechaINI.Text <> "" Then
            dFechaINI = CDate(Me.txtFechaINI.Text)
        Else
            dFechaINI = dMinFecha
        End If
        If Me.txtFechaFin.Text <> "" Then
            dFechaFIN = CDate(Me.txtFechaFin.Text)
        Else
            dFechaFIN = dMaxFecha
        End If

        Dim ds As DataSet
        Dim cn As DB2Connection

        cn = Session(SES_CONN)
        ds = cConsulta.spTotalEmpresaFecha(cn, iIdEmpresa, dFechaINI, dFechaFIN, iIdServicio, sCR)


        Me.subFormatoGrid(Me.gridTran)

        If bExportar Then
            ExportaGrid(ds)
        Else
            gridTran.DataSource = ds
            gridTran.DataBind()
        End If
        

        If ds.Tables(0).Rows.Count <= 0 Then
            ShowError(lMensaje, sNoHayRegistros)
        Else
            ShowError(lMensaje, Format(ds.Tables(0).Rows.Count, "###,###") & sRegistrosEncontrados)
        End If

    End Sub
    Public Function bValidaCampos() As Boolean

        If Me.txtFechaFin.Text <> "" And Not (IsDate(Me.txtFechaFin.Text)) Then
            ShowError(Me.lMensaje, "La fecha ingresada no es válida", True)
            txtFechaFin.Focus()
            bValidaCampos = False
            Exit Function
        End If

        If Me.txtFechaINI.Text <> "" And Not (IsDate(Me.txtFechaINI.Text)) Then
            ShowError(Me.lMensaje, "La fecha ingresada no es válida", True)
            txtFechaINI.Focus()
            bValidaCampos = False
            Exit Function
        End If

        bValidaCampos = True
    End Function
End Class