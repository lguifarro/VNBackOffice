Imports IBM.Data.DB2
Imports System.Text
Imports System.IO
Public Class frmQRYEmpServicioConsulta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If bValidaUsuarioSesion(enTipoUsuario.iEmpresa, Session) = False Then
            Response.Redirect(FORM_LOGIN)
        End If
        'If Session(SES_USUARIO) Is Nothing Then
        '    Response.Redirect(FORM_LOGIN)
        'End If

        If Not IsPostBack Then
            Dim cn As DB2Connection
            cn = Session(SES_CONN)

            Dim cUsuario As ClsUsuarioSesion
            cUsuario = Session(SES_USUARIO)
            Dim iIDUsuario As Integer
            iIDUsuario = cUsuario.getIdUsuario
            Dim iCmcioId As Integer
            iCmcioId = cUsuario.getIdComercio
            'carga el combo
            subLoadComboGrupoComercio(cn, iCmcioId, iIDUsuario)

            subLoadComboServicio(cn, iCmcioId, iIDUsuario)


            'para el boton de regreso
            'Me.bCancelar.Attributes.Add("onClick", scriptBACK)

        End If
    End Sub
    Public Sub subLoadComboGrupoComercio(ByVal cn As DB2Connection, ByVal iCmcioId As Integer, _
                ByVal iIdUsuario As Integer)

        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim ds As DataSet

        If VerificaConexion(cn, sDescError) = iResultOK Then
            ds = cConsulta.spQRYGrupoComercio(cn, 0, iCmcioId, "", "", 0, 0, iIdUsuario, sCR, sDescError)
            If sCR = TODO_OK Then
                subLoadCMBDataSetAllInt(ds, Me.cmbGrupo, "NOMBRE_GRUPO", "IDGRUPO", True, False, 0)
            End If

        End If

    End Sub
    Public Sub subLoadComboServicio(ByVal cn As DB2Connection, ByVal iCmcioId As Integer, _
            ByVal iIdUsuario As Integer)

        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim ds As DataSet

        If VerificaConexion(cn, sDescError) = iResultOK Then
            ds = cConsulta.spQRYServicioEmpresa(cn, 0, iCmcioId, "", iIdUsuario, sCR, sDescError)
            If sCR = TODO_OK Then
                subLoadCMBDataSetAllInt(ds, Me.cmbServicio, "SERVI_NOMBRE", "SERVI_CODIGO", True, False, 0)
            End If

        End If

    End Sub

    Protected Sub cmbGrupo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        Dim sIdEmpresa As String = ""

        Dim cn As DB2Connection
        cn = Session(SES_CONN)

        Dim cUsuario As ClsUsuarioSesion
        cUsuario = Session(SES_USUARIO)
        Dim iIDUsuario As Integer
        iIDUsuario = cUsuario.getIdUsuario
        Dim iidGrupo As Integer

        If Me.cmbGrupo.SelectedIndex >= 0 Then
            iidGrupo = Me.cmbGrupo.SelectedValue
            subConsultaServicioConsulta()

            'Else
            '    Me.cmbGrupo.Items.Clear()
            '    sIdEmpresa = ""
        End If

    End Sub
    Protected Sub subConsultaServicioConsulta(Optional ByVal bExportar As Boolean = False)

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
        If IsNumeric(Me.cmbGrupo.SelectedValue) Then iIdGrupoBusca = Me.cmbGrupo.SelectedValue

        Dim ds As DataSet
        Dim cn As DB2Connection

        ShowError(lMensaje, "")

        cn = Session(SES_CONN)
        ds = cConsulta.spQRYServicioConsulta(cn, iIdGrupoBusca, 0, "", 1, iIdUsuario, sCR, sDescError)

        If sCR = TODO_OK Then

            subFormatoGrid(Me.gridGrupo)

            Me.gridGrupo.DataSource = ds
            gridGrupo.DataBind()

            If ds.Tables(0).Rows.Count <= 0 Then
                ShowError(lMensaje, sNoHayRegistros)
            Else
                ShowError(lMensaje, Format(ds.Tables(0).Rows.Count, "###,###") & sRegistrosEncontrados)
            End If

        Else
            ShowError(lMensaje, sDescError, True)
        End If

    End Sub

    Protected Sub subFormatoGrid(ByRef GV As GridView, Optional ByVal bExportar As Boolean = False)

        Dim b As BoundField
        Dim h As HyperLinkField

        GV.Columns.Clear()

        'h = New HyperLinkField
        'h.HeaderText = "Id"
        'h.DataTextField = "IDGRUPO"
        'h.DataNavigateUrlFields = {"IDGRUPO"}
        'h.DataNavigateUrlFormatString = FORM_MANT_GRUPO_COMERCIO & "?" & PARAM_ID_GRUPO & "={0}&" & PARAM_OPCION_EDITAR & "=" & OPC_VER
        'h.ItemStyle.Width = 60
        'h.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'GV.Columns.Add(h)

        b = New BoundField
        b.DataField = "SERVI_CODIGO"
        b.HeaderText = "Id Servicio"
        b.ItemStyle.Width = 60
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)


        b = New BoundField
        b.DataField = "SERVI_NOMBRE"
        b.HeaderText = "Servicio"
        b.ItemStyle.Width = 250
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        'b = New BoundField
        'b.DataField = "DESC_GRUPO"
        'b.HeaderText = "Descripcion"
        'b.ItemStyle.Width = 150
        'b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        ''b.DataFormatString = oColumna.getFormato
        'GV.Columns.Add(b)



        'h = New HyperLinkField
        'h.HeaderText = "Editar"
        'h.DataTextField = "IDGRUPO"
        'h.DataNavigateUrlFields = {"IDGRUPO"}
        'h.DataNavigateUrlFormatString = FORM_MANT_GRUPO_COMERCIO & "?" & PARAM_ID_GRUPO & "={0}&" & PARAM_OPCION_EDITAR & "=" & OPC_EDITAR
        'h.DataTextFormatString = "<img src='" & imgCambioEstado & "' alt='{0}' border='0' />"
        'h.ItemStyle.Width = 60
        'h.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'GV.Columns.Add(h)

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

    Protected Sub bAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bAdd.Click
        Dim iIdGrupo As Integer = 0
        Dim iIdServicio As Integer = 0

        iIdGrupo = Me.cmbGrupo.SelectedValue
        iIdServicio = Me.cmbServicio.SelectedValue


        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim cUsuario As ClsUsuarioSesion
        Dim iIdUsuario As Integer
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim cn As DB2Connection
        cn = Session(SES_CONN)

        cUsuario = Session(SES_USUARIO)
        iIdUsuario = cUsuario.getIdUsuario

        cConsulta.spMANTUpdateServicioConsulta(cn, sOpcionAlta, iIdGrupo, iIdServicio, iIdUsuario, sCR, sDescError)

        subConsultaServicioConsulta()

    End Sub

    Protected Sub bRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bRemove.Click
        Dim iIdGrupo As Integer = 0
        Dim iIdServicio As Integer = 0

        iIdGrupo = Me.cmbGrupo.SelectedValue
        iIdServicio = Me.cmbServicio.SelectedValue


        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim cUsuario As ClsUsuarioSesion
        Dim iIdUsuario As Integer
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim cn As DB2Connection
        cn = Session(SES_CONN)

        cUsuario = Session(SES_USUARIO)
        iIdUsuario = cUsuario.getIdUsuario

        cConsulta.spMANTUpdateServicioConsulta(cn, sOpcionBaja, iIdGrupo, iIdServicio, iIdUsuario, sCR, sDescError)

        subConsultaServicioConsulta()
    End Sub
End Class