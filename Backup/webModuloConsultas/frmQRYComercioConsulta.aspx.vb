Imports IBM.Data.DB2
Imports System.Text
Imports System.IO

Public Class frmQRYComercioConsulta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If bValidaUsuarioSesion(enTipoUsuario.iVisaNet, Session) = False Then
            Response.Redirect(FORM_LOGIN_VIS)
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

            'carga el combo
            subLoadComboGrupoComercio(cn, iIDUsuario)

            subConsultaComercioConsulta()

            'para el boton de regreso
            'Me.bCancelar.Attributes.Add("onClick", scriptBACK)

        End If
    End Sub
    Public Sub subLoadComboGrupoComercio(ByVal cn As DB2Connection, _
                ByVal iIdUsuario As Integer)

        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim ds As DataSet

        If VerificaConexion(cn, sDescError) = iResultOK Then
            ds = cConsulta.spQRYGrupoComercio(cn, 0, 0, "", "", 0, 0, iIdUsuario, sCR, sDescError)
            If sCR = TODO_OK Then
                subLoadCMBDataSetAllInt(ds, Me.cmbGrupo, "NOMBRE_GRUPO", "IDGRUPO", True, False, 0)
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
            subConsultaComercioConsulta()

            'Else
            '    Me.cmbGrupo.Items.Clear()
            '    sIdEmpresa = ""
        End If

    End Sub

    Protected Sub subConsultaComercioConsulta(Optional ByVal bExportar As Boolean = False)

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
        If IsNumeric(Me.cmbGrupo.SelectedValue) Then
            iIdGrupoBusca = Me.cmbGrupo.SelectedValue
        Else
            iIdGrupoBusca = -1
        End If


        Dim ds As DataSet
        Dim cn As DB2Connection

        ShowError(lMensaje, "")

        cn = Session(SES_CONN)
        ds = cConsulta.spQRYComercioConsulta(cn, iIdGrupoBusca, "", iIdUsuario, sCR, sDescError)

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
        b.DataField = "CODCOMERCIO"
        b.HeaderText = "Codigo"
        b.ItemStyle.Width = 60
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)


        'b = New BoundField
        'b.DataField = "SERVI_NOMBRE"
        'b.HeaderText = "Servicio"
        'b.ItemStyle.Width = 250
        'b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
        ''b.DataFormatString = oColumna.getFormato
        'GV.Columns.Add(b)

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

        iIdGrupo = Me.cmbGrupo.SelectedValue

        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim cUsuario As ClsUsuarioSesion
        Dim iIdUsuario As Integer
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim cn As DB2Connection
        cn = Session(SES_CONN)

        cUsuario = Session(SES_USUARIO)
        iIdUsuario = cUsuario.getIdUsuario

        Dim sListaCodigos As String = ""
        sListaCodigos = Me.txtListaCodigos.Text
        Dim sCodigo As String
        Dim iPos As Integer = 0
        Dim sRespuesta As String = ""
        Dim sBusca As String = Chr(13) & Chr(10)
        Dim sLog As String = ""

        Do While Len(sListaCodigos) > 1
            iPos = InStr(sListaCodigos, sBusca)
            If iPos > 0 Then
                sCodigo = Left(sListaCodigos, iPos - 1)
                sListaCodigos = Mid(sListaCodigos, iPos + Len(sBusca))
            Else
                sCodigo = sListaCodigos
                sListaCodigos = ""
            End If

            If IsNumeric(sCodigo) Then
                cConsulta.spMANTUpdateComercioConsulta(cn, sOpcionAlta, iIdGrupo, sCodigo, iIdUsuario, sCR, sDescError)
            End If

            If sLog <> "" Then sLog = sLog & vbCrLf
            sLog = sLog & sDescError

            Me.txtLog.Text = sLog

        Loop
        subConsultaComercioConsulta()
    End Sub

    Protected Sub bRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bRemove.Click

        Dim iIdGrupo As Integer = 0

        iIdGrupo = Me.cmbGrupo.SelectedValue

        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim cUsuario As ClsUsuarioSesion
        Dim iIdUsuario As Integer
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim cn As DB2Connection
        cn = Session(SES_CONN)

        cUsuario = Session(SES_USUARIO)
        iIdUsuario = cUsuario.getIdUsuario

        Dim sListaCodigos As String = ""
        sListaCodigos = Me.txtListaCodigos.Text
        Dim sCodigo As String
        Dim iPos As Integer = 0
        Dim sRespuesta As String = ""
        Dim sBusca As String = Chr(13) & Chr(10)
        Dim sLog As String = ""

        Do While Len(sListaCodigos) > 1
            iPos = InStr(sListaCodigos, sBusca)
            If iPos > 0 Then
                sCodigo = Left(sListaCodigos, iPos - 1)
                sListaCodigos = Mid(sListaCodigos, iPos + Len(sBusca))
            Else
                sCodigo = sListaCodigos
                sListaCodigos = ""
            End If

            If IsNumeric(sCodigo) Then
                cConsulta.spMANTUpdateComercioConsulta(cn, sOpcionBaja, iIdGrupo, sCodigo, iIdUsuario, sCR, sDescError)
            End If

            If sLog <> "" Then sLog = sLog & vbCrLf
            sLog = sLog & sDescError

            Me.txtLog.Text = sLog

        Loop
        subConsultaComercioConsulta()
    End Sub
End Class