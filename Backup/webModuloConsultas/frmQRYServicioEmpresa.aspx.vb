﻿Imports IBM.Data.DB2
Imports System.Text
Imports System.IO
Public Class frmQRYServicioEmpresa
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
            subLoadComboEmpresa(cn, iIDUsuario)

            subLoadComboServicio(cn, iIDUsuario)


            'para el boton de regreso
            'Me.bCancelar.Attributes.Add("onClick", scriptBACK)

        End If
    End Sub
    Public Sub subLoadComboEmpresa(ByVal cn As DB2Connection, _
                ByVal iIdUsuario As Integer)

        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim ds As DataSet

        If VerificaConexion(cn, sDescError) = iResultOK Then
            ds = cConsulta.spQRYEmpresa(cn, 0, "", "", 0, iIdUsuario, sCR, sDescError)
            If sCR = TODO_OK Then
                subLoadCMBDataSetAllInt(ds, Me.cmbEmpresa, "CMCIO_NOMBRE", "CMCIO_ID", True, False, 0)
            End If

        End If

    End Sub
    Public Sub subLoadComboServicio(ByVal cn As DB2Connection, _
            ByVal iIdUsuario As Integer)

        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim ds As DataSet

        If VerificaConexion(cn, sDescError) = iResultOK Then
            ds = cConsulta.spQRYServicio(cn, 0, "", 1, iIdUsuario, sCR, sDescError)
            If sCR = TODO_OK Then
                subLoadCMBDataSetAllInt(ds, Me.cmbServicio, "SERVI_NOMBRE", "SERVI_CODIGO", True, False, 0)
            End If

        End If

    End Sub

    Protected Sub subConsultaServicioEmpresa(Optional ByVal bExportar As Boolean = False)

        'consultar en la base de datos
        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim cUsuario As ClsUsuarioSesion
        Dim iIdUsuario As Integer
        Dim sCR As String = ""
        Dim sDescError As String = ""

        cUsuario = Session(SES_USUARIO)
        iIdUsuario = cUsuario.getIdUsuario

        'parámetros de búsqueda
        Dim iIdEmpresaBusca As Integer = 0
        iIdEmpresaBusca = Me.cmbEmpresa.SelectedValue

        Dim ds As DataSet
        Dim cn As DB2Connection

        ShowError(lMensaje, "")

        cn = Session(SES_CONN)
        ds = cConsulta.spQRYServicioEmpresa(cn, 0, iIdEmpresaBusca, "", iIdUsuario, sCR, sDescError)

        If sCR = TODO_OK Then

            subFormatoGrid(Me.gridServicio)

            Me.gridServicio.DataSource = ds
            gridServicio.DataBind()

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
        Dim iIdEmpresa As Integer = 0
        Dim iIdServicio As Integer = 0

        iIdEmpresa = Me.cmbEmpresa.SelectedValue
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

        cConsulta.spMANTUpdateServicioEmpresa(cn, sOpcionAlta, iIdEmpresa, iIdServicio, iIdUsuario, sCR, sDescError)

        subConsultaServicioEmpresa()

    End Sub

    Protected Sub bRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bRemove.Click
        Dim iIdEmrpesa As Integer = 0
        Dim iIdServicio As Integer = 0

        iIdEmrpesa = Me.cmbEmpresa.SelectedValue
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

        cConsulta.spMANTUpdateServicioEmpresa(cn, sOpcionBaja, iIdEmrpesa, iIdServicio, iIdUsuario, sCR, sDescError)

        subConsultaServicioEmpresa()
    End Sub

    Protected Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        Dim sIdEmpresa As String = ""

        Dim cn As DB2Connection
        cn = Session(SES_CONN)

        Dim cUsuario As ClsUsuarioSesion
        cUsuario = Session(SES_USUARIO)
        Dim iIDUsuario As Integer
        iIDUsuario = cUsuario.getIdUsuario
        Dim iidGrupo As Integer

        If Me.cmbEmpresa.SelectedIndex >= 0 Then
            iidGrupo = Me.cmbEmpresa.SelectedValue
            subConsultaServicioEmpresa()

            'Else
            '    Me.cmbGrupo.Items.Clear()
            '    sIdEmpresa = ""
        End If
    End Sub
End Class