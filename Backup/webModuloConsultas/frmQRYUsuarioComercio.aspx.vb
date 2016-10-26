Imports IBM.Data.DB2
Imports System.Text
Imports System.IO

Public Class frmQRYUsuarioComercio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bConsultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bConsultar.Click
        subConsultaUsuarioComercio()
    End Sub
    Protected Sub subConsultaUsuarioComercio(Optional ByVal bExportar As Boolean = False)

        'consultar en la base de datos
        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim cUsuario As ClsUsuarioSesion
        Dim iIdUsuario As Integer
        Dim sCR As String = ""
        Dim sDescError As String = ""
        Dim iCmcioId As Integer = 0

        cUsuario = Session(SES_USUARIO)
        iIdUsuario = cUsuario.getIdUsuario
        'iCmcioId = cUsuario.getIdComercio

        'parámetros de búsqueda
        Dim sLoginUsuario As String = ""
        Dim iIdUsuarioBusca As Integer = 0
        Dim sNombre As String = ""
        Dim sAPaterno As String = ""
        Dim sEmail As String = ""
        Dim iIdGrupo As Integer = 0

        sLoginUsuario = Me.txtLoginUsuario.Text
        sEmail = Me.txtEmail.Text
        sNombre = Me.txtNomUsuario.Text
        sAPaterno = Me.txtAPaterno.Text
        Dim ds As DataSet
        Dim cn As DB2Connection

        ShowError(lMensaje, "")

        cn = Session(SES_CONN)
        ds = cConsulta.spQRYUsuarioComercio(cn, iIdUsuarioBusca, sLoginUsuario, sNombre, sAPaterno, sEmail, iIdGrupo, iCmcioId, iIdUsuario, sCR, sDescError)

        If sCR = TODO_OK Then

            subFormatoGrid(Me.gridUsuario)

            'Me.gridUsuario.DataSource = ds
            'gridUsuario.DataBind()

            If ds.Tables(0).Rows.Count <= 0 Then
                ShowError(lMensaje, sNoHayRegistros)
            Else
                ShowError(lMensaje, Format(ds.Tables(0).Rows.Count, "###,###") & sRegistrosEncontrados)
            End If

            If bExportar Then
                ExportaGrid(ds)
            Else
                'enlaza la informacion
                Me.gridUsuario.DataSource = ds
                Me.gridUsuario.DataBind()

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
            b.DataField = "IDUSUARIO"
            b.HeaderText = "Id"
            b.ItemStyle.Width = 60
            b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            'b.DataFormatString = oColumna.getFormato
            GV.Columns.Add(b)
        Else
            h = New HyperLinkField
            h.HeaderText = "Id"
            h.DataTextField = "IDUSUARIO"
            h.DataNavigateUrlFields = {"IDUSUARIO"}
            h.DataNavigateUrlFormatString = FORM_MANT_USUARIO_COMERCIO & "?" & PARAM_ID_USUARIO & "={0}&" & PARAM_OPCION_EDITAR & "=" & OPC_VER
            h.ItemStyle.Width = 60
            h.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            GV.Columns.Add(h)

        End If
        
        b = New BoundField
        b.DataField = "LOGIN"
        b.HeaderText = "Login"
        b.ItemStyle.Width = 150
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "IDGRUPO"
        b.HeaderText = "IdGrupo"
        b.ItemStyle.Width = 60
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
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
        b.DataField = "CMCIO_ID"
        b.HeaderText = "Id Prov."
        b.ItemStyle.Width = 60
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "CMCIO_NOMBRE"
        b.HeaderText = "Id Proveedor"
        b.ItemStyle.Width = 150
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)


        b = New BoundField
        b.DataField = "NOMBRE"
        b.HeaderText = "Nombre"
        b.ItemStyle.Width = 150
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "APELLIDOP"
        b.HeaderText = "A. Paterno"
        b.ItemStyle.Width = 150
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "EMAIL"
        b.HeaderText = "Email"
        b.ItemStyle.Width = 150
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "ESTADO"
        b.HeaderText = "Estado"
        b.ItemStyle.Width = 60
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)


        If Not (bExportar) Then
            h = New HyperLinkField
            h.HeaderText = "Editar"
            h.DataTextField = "IDUSUARIO"
            h.DataNavigateUrlFields = {"IDUSUARIO"}
            h.DataNavigateUrlFormatString = FORM_MANT_USUARIO_COMERCIO & "?" & PARAM_ID_USUARIO & "={0}&" & PARAM_OPCION_EDITAR & "=" & OPC_EDITAR
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
        subConsultaUsuarioComercio(True)
    End Sub
End Class