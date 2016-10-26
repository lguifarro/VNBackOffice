Imports IBM.Data.DB2

Public Class frmMANTUsuarioVisanet
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If bValidaUsuarioSesion(enTipoUsuario.iVisaNet, Session) = False Then
            Response.Redirect(FORM_LOGIN_VIS)
        End If
        'If Session(SES_USUARIO) Is Nothing Then
        '    Response.Redirect(FORM_LOGIN_VIS)
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


            Dim idUsuarioConsulta As Long
            idUsuarioConsulta = CLng(Request.QueryString(PARAM_ID_USUARIO))

            'carga el combo
            ShowDetalleUsuario(cn, iIDUsuario, idUsuarioConsulta, sOpcion)

            'para el boton de regreso
            Me.bCancelar.Attributes.Add("onClick", scriptBACK)
        End If

    End Sub
    Public Sub ShowDetalleUsuario(ByVal cn As DB2Connection, _
                                  ByVal iIdUsuario As Long, _
                                  ByVal IdUsuarioConsulta As Integer, _
                                  Optional ByVal sOpcionEdit As String = OPC_VER)


        Dim sLogin As String = ""
        Dim sNombre As String = ""
        Dim sAPaterno As String = ""
        Dim sEmail As String = ""
        Dim sDNI As String = ""
        Dim sNivel As String = ""
        Dim iNivel As Integer = 0
        Dim sEstadoUsuario As String = ""
        Dim dFechaInsert As Date
        Dim dFechaUltActualiz As Date

        Dim sCR As String = ""
        Dim sDescError As String = ""

        Dim cConsulta As ClsConsultas.ClsConsultaDB

        Select Case sOpcionEdit
            Case OPC_EDITAR, OPC_VER

                cConsulta = New ClsConsultas.ClsConsultaDB

                cConsulta.spQRYDetalleUsuarioVisanet(cn, IdUsuarioConsulta, sLogin, sNombre, sAPaterno, sEmail, iNivel, _
                              sEstadoUsuario, _
                              dFechaInsert, dFechaUltActualiz, _
                             iIdUsuario, sCR, sDescError)


                Me.lIdUsuario.Text = CStr(IdUsuarioConsulta)

                If sCR = TODO_OK Then

                    Me.txtLogin.Text = Trim(sLogin)
                    Me.txtNombre.Text = Trim(sNombre)
                    Me.txtAPaterno.Text = Trim(sAPaterno)
                    Me.txtEmail.Text = Trim(sEmail)
                    Me.txtNivel.Text = Trim(CStr(iNivel))

                    'Dim j As Integer
                    'For j = 0 To Me.cmbTipoUsuario.Items.Count - 1
                    '    If Me.cmbTipoUsuario.Items(j).Value = sIdTipoUsuario Then
                    '        Me.cmbTipoUsuario.SelectedIndex = j

                    '    End If
                    'Next

                    If sEstadoUsuario = sEstadoActivo Then
                        Me.rbEstado.Items(indexActivo).Selected = True
                    Else
                        Me.rbEstado.Items(indexInactivo).Selected = True
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

        Me.txtLogin.Text = ""
        Me.txtNombre.Text = ""
        Me.txtAPaterno.Text = ""
        Me.txtEmail.Text = ""
        Me.txtNivel.Text = ""
        Me.txtPassword.Text = ""

        Me.rbEstado.Items(indexActivo).Selected = True

    End Sub

    Public Sub subHabilitaCampos(Optional ByVal sOpcionEdit As String = OPC_VER)

        Dim bEditar As Boolean

        Me.bActualizar.Visible = False
        Me.bNuevo.Visible = False

        Select Case sOpcionEdit
            Case OPC_VER
                bEditar = False

                Me.txtPassword.Enabled = False

            Case OPC_NUEVO
                bEditar = True

                Me.bNuevo.Visible = True
                Me.bNuevo.Enabled = True
                Me.txtPassword.Enabled = True
            Case OPC_EDITAR
                bEditar = True

                Me.bActualizar.Visible = True
                Me.bActualizar.Enabled = True
                Me.txtPassword.Enabled = False
            Case Else
                bEditar = False
        End Select

        Me.txtLogin.ReadOnly = Not (bEditar)
        Me.txtNombre.ReadOnly = Not (bEditar)
        Me.txtAPaterno.ReadOnly = Not (bEditar)
        Me.txtEmail.ReadOnly = Not (bEditar)
        Me.txtNivel.ReadOnly = Not (bEditar)

        Me.rbEstado.Enabled = bEditar

        Me.txtFechaInsert.ReadOnly = True
        Me.txtFechaUltActualiz.ReadOnly = True

    End Sub

    Protected Sub bActualizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bActualizar.Click
        Dim sIdUsuarioUpdate As String = ""
        Dim iIdUsuarioUpdate As Integer

        sIdUsuarioUpdate = Me.lIdUsuario.Text
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
            Dim iIdUsuarioConsulta As Integer
            Dim sLogin As String = ""
            Dim sNombre As String = ""
            Dim sAPaterno As String = ""
            Dim sEmail As String = ""
            Dim sEstado As String = ""
            Dim sNivel As String = ""
            Dim iNivel As Integer = 0
            
            iIdUsuarioConsulta = CInt(Me.lIdUsuario.Text)
            sLogin = txtLogin.Text
            sNombre = txtNombre.Text
            sAPaterno = txtAPaterno.Text
            sEmail = txtEmail.Text
            sEstado = Me.rbEstado.SelectedValue
            sNivel = txtNivel.Text
            If IsNumeric(sNivel) Then iNivel = CInt(sNivel)

            If VerificaConexion(cn, sDescError) = iResultOK Then
                iResp = cConsulta.spMANTUpdateUsuarioVisanet(cn, iIdUsuarioConsulta, sLogin, sNombre, sAPaterno, sEmail, iNivel, sEstado, iIDUsuario, sCR, sDescError)

                If iResp = iResultOK Then

                    If sCR = TODO_OK Then
                        Response.Redirect(FORM_QRY_USUARIO_COMERCIO)
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

        If Me.txtLogin.Text = "" Then
            bValida = False
            sMensajeRet = "Debe ingresar un login para el usuario"
            txtLogin.Focus()
        End If

        If Me.txtPassword.Enabled = True Then
            If Me.txtPassword.Text = "" Then
                bValida = False
                sMensajeRet = "Debe ingresar una contraseña para el usuario"
                txtPassword.Focus()
            End If

        End If
        If Me.txtNombre.Text = "" Then
            bValida = False
            sMensajeRet = "Debe ingresar un nombre para el usuario"
            txtNombre.Focus()
        End If

        If Me.txtAPaterno.Text = "" Then
            bValida = False
            sMensajeRet = "Debe ingresar un apellido para el usuario"
            txtAPaterno.Focus()
        End If

        If Me.txtEmail.Text = "" Then
            bValida = False
            sMensajeRet = "Debe ingresar un email para el usuario"
            txtEmail.Focus()
        End If

        If Not (IsNumeric(Me.txtNivel.Text = "")) Then
            bValida = False
            sMensajeRet = "Debe ingresar un nivel valido para el usuario"
            txtNivel.Focus()
        End If

        If (Me.rbEstado.Items(indexActivo).Selected = False) And (Me.rbEstado.Items(indexInactivo).Selected = False) Then
            bValida = False
            sMensajeRet = "Debe seleccionar un estado"
            rbEstado.Focus()
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
            Dim iIdCentroSeguridad As Integer

            Dim cConsulta As New ClsConsultas.ClsConsultaDB
            Dim sCR As String = ""
            Dim sDescError As String = ""
            Dim iResp As Integer

            Dim sLogin As String = ""
            Dim sNombre As String = ""
            Dim sAPaterno As String = ""
            Dim sEmail As String = ""
            Dim sEstado As String = ""
            Dim sNivel As String = ""
            Dim iNivel As Integer
            Dim sPassword As String

            sEstado = Me.rbEstado.SelectedValue
            sLogin = txtLogin.Text
            sNombre = txtNombre.Text
            sAPaterno = txtAPaterno.Text
            sEmail = txtEmail.Text
            sNivel = txtNivel.Text
            If IsNumeric(sNivel) Then iNivel = CInt(sNivel)
            sPassword = txtPassword.Text
            
            If VerificaConexion(cn, sDescError) = iResultOK Then

                iResp = cConsulta.spMANTInsertUsuarioVisanet(cn, sLogin, sPassword, sNombre, sAPaterno, sEmail, iNivel, sEstado, iIDUsuario, sCR, sDescError)
                
                If iResp = iResultOK Then

                    If sCR = TODO_OK Then
                        Response.Redirect(FORM_QRY_USUARIO_VISANET)
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