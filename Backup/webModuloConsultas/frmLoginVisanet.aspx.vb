Public Class frmLoginVisanet
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        subLimpiaSesion(Session)

    End Sub

    Protected Sub bAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bAceptar.Click
        Dim sUsuario As String = ""
        Dim sPassword As String = ""
        Dim iResp As Integer = 0

        Dim iIdUsuario As Integer = 0
        Dim iNivelusuario As Integer = 0
        Dim iIdGrupo As Integer = 0
        Dim sNombreGrupo As String = ""
        Dim sNomComercio As String = ""
        Dim sCR As String = ""
        Dim sMensaje As String = ""
        Dim sCodComercio As String = ""
        Dim sErrorResp As String = ""
        Dim sNombreUsuario As String = ""
        Dim sApaternoUsuario As String = ""
        Dim sEmailUsuario As String = ""


        If VerificaConexion(gCN, sErrorResp) = iResultOK Then

            sUsuario = Me.txtUsuarioLogin.Text
            sPassword = Me.txtPasswordLogin.Text

            Dim cConex As New ClsConsultas.ClsConsultaDB

            iResp = cConex.fLoginVisanet(gCN, sUsuario, sPassword, iIdUsuario, iNivelusuario, sNombreUsuario, sApaternoUsuario, sEmailUsuario, sCR, sMensaje)
            If iResp = iResultOK Then

                If sCR = TODO_OK Then
                    Dim cUsuarioLogin As New ClsUsuarioSesion
                    cUsuarioLogin.sCreaSesionVisaNet(sUsuario, sNombreUsuario, sApaternoUsuario, iIdUsuario, iNivelusuario, sEmailUsuario)

                    ''GUARDA LOS DATOS DE LA SESION
                    Session(SES_USUARIO) = cUsuarioLogin
                    Session(SES_CONN) = gCN

                    Response.Redirect(FORM_CONSULTAS_VIS)

                Else

                    Me.lMensaje.Text = sMensaje
                End If
            Else

                Me.lMensaje.Text = sMensaje

            End If

            cConex = Nothing



        Else
            Me.lMensaje.Text = "NO SE PUDO CONECTAR CON BASE DE DATOS - " & sErrorResp
        End If
    End Sub
End Class