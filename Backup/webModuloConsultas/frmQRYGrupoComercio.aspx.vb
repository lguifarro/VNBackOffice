Imports IBM.Data.DB2
Imports System.Text
Imports System.IO
Public Class frmQRYGrupoComercio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bConsultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bConsultar.Click

        subConsultaGrupoComercio()

    End Sub

    Protected Sub subConsultaGrupoComercio(Optional ByVal bExportar As Boolean = False)

        'consultar en la base de datos
        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim cUsuario As ClsUsuarioSesion
        Dim iIdUsuario As Integer
        Dim sCR As String = ""
        Dim sDescError As String = ""

        cUsuario = Session(SES_USUARIO)
        iIdUsuario = cUsuario.getIdUsuario

        'parámetros de búsqueda
        Dim iIdGrupoBusca As Integer = 0
        Dim iCmcioId As Integer = 0
        Dim sRUC As String = ""
        Dim iRUC As Long
        Dim sCodGrupo As String = ""
        Dim sNomGrupo As String = ""
        Dim iFlagRUC As Integer = 0

        sNomGrupo = Me.txtGrupo.Text
        sRUC = Me.txtRUC.Text
        If IsNumeric(sRUC) Then iRUC = CLng(sRUC)

        Dim ds As DataSet
        Dim cn As DB2Connection

        ShowError(lMensaje, "")

        cn = Session(SES_CONN)
        ds = cConsulta.spQRYGrupoComercio(cn, iIdGrupoBusca, icmcioid, sCodGrupo, sNomGrupo, iRUC, iFlagRUC, iIdUsuario, sCR, sDescError)

        If sCR = TODO_OK Then

            subFormatoGrid(Me.gridGrupo)

            'Me.gridGrupo.DataSource = ds
            'gridGrupo.DataBind()

            If ds.Tables(0).Rows.Count <= 0 Then
                ShowError(lMensaje, sNoHayRegistros)
            Else
                ShowError(lMensaje, Format(ds.Tables(0).Rows.Count, "###,###") & sRegistrosEncontrados)
            End If

            If bExportar Then
                ExportaGrid(ds)
            Else
                'enlaza la informacion
                Me.gridGrupo.DataSource = ds
                Me.gridGrupo.DataBind()
            End If

        Else
            ShowError(lMensaje, sDescError, True)
        End If

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
    Protected Sub subFormatoGrid(ByRef GV As GridView, Optional ByVal bExportar As Boolean = False)

        Dim b As BoundField
        Dim h As HyperLinkField

        GV.Columns.Clear()

        If bExportar Then
            b = New BoundField
            b.DataField = "IDGRUPO"
            b.HeaderText = "Id"
            b.ItemStyle.Width = 60
            b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            'b.DataFormatString = oColumna.getFormato
            GV.Columns.Add(b)
        Else
            h = New HyperLinkField
            h.HeaderText = "Id"
            h.DataTextField = "IDGRUPO"
            h.DataNavigateUrlFields = {"IDGRUPO"}
            h.DataNavigateUrlFormatString = FORM_MANT_GRUPO_COMERCIO & "?" & PARAM_ID_GRUPO & "={0}&" & PARAM_OPCION_EDITAR & "=" & OPC_VER
            h.ItemStyle.Width = 60
            h.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            GV.Columns.Add(h)

        End If

        b = New BoundField
        b.DataField = "CMCIO_ID"
        b.HeaderText = "Id. Prov"
        b.ItemStyle.Width = 60
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "COD_GRUPO"
        b.HeaderText = "Cod. Grupo"
        b.ItemStyle.Width = 90
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "NOMBRE_GRUPO"
        b.HeaderText = "Grupo"
        b.ItemStyle.Width = 150
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "RUC"
        b.HeaderText = "Ruc"
        b.ItemStyle.Width = 150
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "DESC_GRUPO"
        b.HeaderText = "Descripcion"
        b.ItemStyle.Width = 150
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        If Not (bExportar) Then
            h = New HyperLinkField
            h.HeaderText = "Editar"
            h.DataTextField = "IDGRUPO"
            h.DataNavigateUrlFields = {"IDGRUPO"}
            h.DataNavigateUrlFormatString = FORM_MANT_GRUPO_COMERCIO & "?" & PARAM_ID_GRUPO & "={0}&" & PARAM_OPCION_EDITAR & "=" & OPC_EDITAR
            h.DataTextFormatString = "<img src='" & imgCambioEstado & "' alt='{0}' border='0' />"
            h.ItemStyle.Width = 60
            h.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            GV.Columns.Add(h)

        End If

        'h = New HyperLinkField
        'h.HeaderText = "Reset"
        'h.DataTextField = "IDUSUARIO"
        'h.DataNavigateUrlFields = {"IDUSUARIO"}
        'h.DataNavigateUrlFormatString = FORM_MANT_RESET_PASSWORD & "?" & PARAM_ID_USUARIO & "={0}"
        'h.DataTextFormatString = "<img src='" & imgResetPassword & "' alt='{0}' border='0' />"
        'h.ItemStyle.Width = 15
        'h.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'GV.Columns.Add(h)

        'ancho del grid
        Dim iAncho As Long
        For i = 1 To GV.Columns.Count - 1
            iAncho = iAncho + GV.Columns(i).ItemStyle.Width.Value
        Next
        iAncho = iAncho + 20
        GV.Width = iAncho


    End Sub

    Protected Sub bExportar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bExportar.Click
        subConsultaGrupoComercio(True)
    End Sub
End Class