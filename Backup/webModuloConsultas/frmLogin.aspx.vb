Imports ClsConsultas

Public Class frmLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        subLimpiaSesion(Session)

    End Sub

    Protected Sub bAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bAceptar.Click
        Dim sUsuario As String = ""
        Dim sPassword As String = ""
        Dim iResp As Integer = 0

        Dim sIdUsuario As String = ""
        Dim iIdComercio As Integer
        Dim sNomComercio As String = ""
        Dim sCR As String = ""
        Dim sMensaje As String = ""
        Dim sCodComercio As String = ""


        If VerificaConexion(gCN, sMensaje) = iResultOK Then

            sCodComercio = Me.txtCodComercioLogin.Text
            sUsuario = Me.txtUsuarioLogin.Text
            sPassword = Me.txtPasswordLogin.Text

            Dim cConex As New ClsConsultas.ClsConsultaDB

            iResp = cConex.fLoginUsuario(gCN, sCodComercio, sUsuario, sPassword, sIdUsuario, iIdComercio, sNomComercio, sCR, sMensaje)
            If iResp = iResultOK Then

                If sCR = TODO_OK Then
                    Dim cUsuarioLogin As New ClsUsuarioSesion
                    cUsuarioLogin.sCreaSesion(sUsuario, "", "", "", iIdComercio, sCodComercio, sNomComercio, sIdUsuario)

                    ''GUARDA LOS DATOS DE LA SESION
                    Session(SES_USUARIO) = cUsuarioLogin
                    Session(SES_CONN) = gCN

                    Response.Redirect(FORM_CONSULTAS)

                Else

                    Me.lMensaje.Text = sMensaje
                End If
            Else

                Me.lMensaje.Text = sMensaje

            End If

            cConex = Nothing



        Else
            Me.lMensaje.Text = "NO SE PUDO CONECTAR CON BASE DE DATOS"
        End If


    End Sub
End Class