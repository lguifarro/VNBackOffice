Imports IBM.Data.DB2
Imports System.Text
Imports System.IO

Public Class frmMANTGrupoComercio
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

            Dim sOpcion As String = ""
            Try
                sOpcion = Request.QueryString(PARAM_OPCION_EDITAR)
            Catch ex As Exception
                sOpcion = OPC_VER
            End Try
            If IsNothing(sOpcion) Or sOpcion = "" Then sOpcion = OPC_VER

            Dim iIdGrupoConsulta As Long
            iIdGrupoConsulta = CLng(Request.QueryString(PARAM_ID_GRUPO))

            'carga el combo
            subLoadComboGrupoComercio(cn, iIDUsuario)
            ShowDetalleGrupoComercio(cn, iIDUsuario, iIdGrupoConsulta, sOpcion)

            'para el boton de regreso
            Me.bCancelar.Attributes.Add("onClick", scriptBACK)

        End If
    End Sub

    Public Sub subLoadComboGrupoComercio(ByVal cn As DB2Connection, _
            ByVal iIdUsuario As Integer)

        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim ds As DataSet

        If VerificaConexion(cn, sDescError) = iResultOK Then
            ds = cConsulta.spQRYEmpresa(cn, 0, "", "", 0, iIdUsuario, sCR, sDescError)
            If sCR = TODO_OK Then
                subLoadCMBDataSetAllInt(ds, Me.cmbEmpresa, "CMCIO_NOMBRE", "CMCIO_ID", True, True, 0)
            End If

        End If

    End Sub

    Public Sub ShowDetalleGrupoComercio(ByVal cn As DB2Connection, _
                                 ByVal iIdUsuario As Long, _
                                 ByVal iIdGrupoConsulta As Integer, _
                                 Optional ByVal sOpcionEdit As String = OPC_VER)


        Dim sCodGrupo As String = ""
        Dim sNombreGrupo As String = ""
        Dim sCmcioNombre As String = ""
        Dim iFlagRUC As Integer = 0
        Dim sRUC As String = ""
        Dim iRUC As Long = 0
        Dim sDescGrupo As String = ""
        Dim iCmcioId As Integer = 0

        Dim dFechaInsert As Date
        Dim dFechaUltActualiz As Date
        
        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim cConsulta As ClsConsultas.ClsConsultaDB

        Select Case sOpcionEdit
            Case OPC_EDITAR, OPC_VER

                cConsulta = New ClsConsultas.ClsConsultaDB

                cConsulta.spQRYDetalleGrupoComercio(cn, iIdGrupoConsulta, iCmcioId, sCodGrupo, sNombreGrupo, scmcionombre, sDescGrupo, iFlagRUC, iRUC, _
                              dFechaInsert, dFechaUltActualiz, _
                             iIdUsuario, sCR, sDescError)


                Me.lIdGrupo.Text = CStr(iIdGrupoConsulta)

                If sCR = TODO_OK Then

                    Me.txtCodGrupo.Text = sCodGrupo
                    Me.txtDescGrupo.Text = sDescGrupo
                    Me.txtNomGrupo.Text = sNombreGrupo
                    Me.txtRUC.Text = CStr(iRUC)

                    Dim j As Integer
                    For j = 0 To Me.cmbEmpresa.Items.Count - 1
                        If Me.cmbEmpresa.Items(j).Value = iCmcioId Then
                            Me.cmbEmpresa.SelectedIndex = j
                        End If
                    Next

                    If iFlagRUC = CInt(sFlagActivo) Then
                        Me.rbFlagRUC.Items(indexActivo).Selected = True
                    Else
                        Me.rbFlagRUC.Items(indexInactivo).Selected = True
                    End If

                    Me.txtFechaInsert.Text = Format(dFechaInsert, sFormatoFechaHora)
                    Me.txtFechaUltActualiz.Text = Format(dFechaUltActualiz, sFormatoFechaHora)

                    ShowError(Me.lMensaje, "")
                Else
                    ShowError(Me.lMensaje, sDescError, True)

                End If
            Case OPC_NUEVO

                sublimpiacampos()
        End Select

        subHabilitaCampos(sOpcionEdit)

    End Sub

    Public Sub subLimpiaCampos()

        Me.txtCodGrupo.Text = ""
        Me.txtDescGrupo.Text = ""
        Me.txtNomGrupo.Text = ""
        Me.txtRUC.Text = ""
        Me.cmbEmpresa.SelectedIndex = -1

    End Sub
    Public Sub subHabilitaCampos(Optional ByVal sOpcionEdit As String = OPC_VER)

        Dim bEditar As Boolean

        Me.bActualizar.Visible = False
        Me.bNuevo.Visible = False

        Select Case sOpcionEdit
            Case OPC_VER
                bEditar = False

            Case OPC_NUEVO
                bEditar = True

                Me.bNuevo.Visible = True
                Me.bNuevo.Enabled = True
            Case OPC_EDITAR
                bEditar = True

                Me.bActualizar.Visible = True
                Me.bActualizar.Enabled = True
            Case Else
                bEditar = False
        End Select

        Me.txtCodGrupo.ReadOnly = Not (bEditar)
        Me.txtDescGrupo.ReadOnly = Not (bEditar)
        Me.txtNomGrupo.ReadOnly = Not (bEditar)
        Me.txtRUC.ReadOnly = Not (bEditar)
        Me.cmbEmpresa.Enabled = bEditar

        Me.rbFlagRUC.Enabled = bEditar

        Me.txtFechaInsert.ReadOnly = True
        Me.txtFechaUltActualiz.ReadOnly = True

    End Sub

    Protected Sub bActualizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bActualizar.Click
        Dim sIdUsuarioUpdate As String = ""
        Dim iIdUsuarioUpdate As Integer

        sIdUsuarioUpdate = Me.lIdGrupo.Text
        If IsNumeric(sIdUsuarioUpdate) Then iIdUsuarioUpdate = CInt(sIdUsuarioUpdate)

        Dim sResp As String

        If Me.bValidaCampos(sResp) Then

            Dim cn As DB2Connection
            cn = Session(SES_CONN)

            Dim cUsuario As ClsUsuarioSesion
            cUsuario = Session(SES_USUARIO)
            Dim iIDUsuario As Integer
            iIDUsuario = cUsuario.getIdUsuario

            Dim cConsulta As New ClsConsultas.ClsConsultaDB
            Dim sCR As String = ""
            Dim sDescError As String = ""

            Dim iResp As Integer
            Dim iIdGrupoConsulta As Integer
            Dim sCodGrupo As String = ""
            Dim sNomGrupo As String = ""
            Dim sDescGrupo As String = ""
            Dim iFlagRUC As Integer
            Dim iRUC As Long
            Dim sRUC As String
            Dim iIdEmpresa As Integer = 0

            iIdGrupoConsulta = CInt(Me.lIdGrupo.Text)
            sCodGrupo = Me.txtCodGrupo.Text
            sNomGrupo = Me.txtNomGrupo.Text
            sDescGrupo = Me.txtDescGrupo.Text
            sRUC = Me.txtRUC.Text
            If IsNumeric(sRUC) Then iRUC = CLng(sRUC)

            iFlagRUC = Me.rbFlagRUC.SelectedValue
            iIdEmpresa = Me.cmbEmpresa.SelectedValue

            If VerificaConexion(cn, sDescError) = iResultOK Then
                iResp = cConsulta.spMANTUpdateGrupoComercio(cn, iIdGrupoConsulta, iIdEmpresa, sCodGrupo, sNomGrupo, sDescGrupo, iFlagRUC, iRUC, iIDUsuario, sCR, sDescError)

                If iResp = iResultOK Then

                    If sCR = TODO_OK Then
                        Response.Redirect(FORM_QRY_GRUPO_COMERCIO)
                    Else
                        modForm.ShowError(Me.lMensaje, sDescError, True)
                    End If

                Else
                    modForm.ShowError(Me.lMensaje, sDescError, True)

                End If

            End If
        Else
            modForm.ShowError(Me.lMensaje, sResp, True)

        End If

    End Sub
    Public Function bValidaCampos(ByRef sMensajeRet As String) As Boolean
        Dim bValida As Boolean = True

        If Me.cmbEmpresa.SelectedIndex < 1 Then
            bValida = False
            sMensajeRet = "Debe seleccionar un proveedor"
            cmbEmpresa.Focus()
        End If
        If Me.cmbEmpresa.SelectedValue = 0 Then
            bValida = False
            sMensajeRet = "Debe seleccionar un proveedor"
            cmbEmpresa.Focus()
        End If

        If Me.txtNomGrupo.Text = "" Then
            bValida = False
            sMensajeRet = "Debe ingresar un nombre para el grupo"
            txtNomGrupo.Focus()
        End If


        If (Me.rbFlagRUC.Items(indexActivo).Selected = False) And (Me.rbFlagRUC.Items(indexInactivo).Selected = False) Then
            bValida = False
            sMensajeRet = "Debe seleccionar un valor"
            rbFlagRUC.Focus()
        End If

        Return bValida

    End Function

    Protected Sub bNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bNuevo.Click


        Dim sResp As String
        If Me.bValidaCampos(sResp) Then
            Dim cn As DB2Connection
            cn = Session(SES_CONN)

            Dim cUsuario As ClsUsuarioSesion
            cUsuario = Session(SES_USUARIO)
            Dim iIDUsuario As Integer
            
            Dim cConsulta As New ClsConsultas.ClsConsultaDB
            Dim sCR As String = ""
            Dim sDescError As String = ""
            Dim iResp As Integer

            Dim iIdGrupo As Integer = 0
            Dim sCodGrupo As String = ""
            Dim sNomGrupo As String = ""
            Dim sDescGrupo As String = ""
            Dim iFlagRUC As Integer = 0
            Dim iRUC As Long = 0
            Dim sRUC As String = ""
            Dim iIdEmpresa As Integer = 0

            sCodGrupo = Me.txtCodGrupo.Text
            sNomGrupo = Me.txtNomGrupo.Text
            sDescGrupo = Me.txtDescGrupo.Text
            sRUC = Me.txtRUC.Text
            If IsNumeric(sRUC) Then iRUC = CLng(sRUC)

            iFlagRUC = Me.rbFlagRUC.SelectedValue
            iIdEmpresa = Me.cmbEmpresa.SelectedValue

            If VerificaConexion(cn, sDescError) = iResultOK Then

                iResp = cConsulta.spMANTInsertGrupoComercio(cn, iIdGrupo, iIdEmpresa, sCodGrupo, sNomGrupo, sDescGrupo, iFlagRUC, iRUC, iIDUsuario, sCR, sDescError)

                If iResp = iResultOK Then

                    If sCR = TODO_OK Then
                        Response.Redirect(FORM_QRY_GRUPO_COMERCIO)
                    Else
                        modForm.ShowError(Me.lMensaje, sDescError, True)
                    End If

                Else
                    modForm.ShowError(Me.lMensaje, sDescError, True)

                End If

            End If

        Else
            ShowError(Me.lMensaje, sResp, True)

        End If

    End Sub
End Class