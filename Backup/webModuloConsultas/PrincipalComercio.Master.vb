Public Class PrincipalComercio
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim iResp As Boolean = False
        iResp = bValidaUsuarioSesion(enTipoUsuario.iComercio, Session)

        If iResp = False Then
            Response.Redirect(FORM_LOGIN_COM)
            'End If
            'If Session(SES_USUARIO) Is Nothing Then
            '    Response.Redirect(FORM_LOGIN_COM)

        Else
            Dim cUsuario As ClsUsuarioSesion
            cUsuario = Session(SES_USUARIO)

            Me.lLogin.Text = "Bienvenido, " & cUsuario.getLoginUsuario & " (" & cUsuario.getNombreComercio & ")"

            If Not (IsPostBack) Then

                subLoadMenu(cUsuario)

            End If
        End If
    End Sub

    Public Sub subLoadMenu(ByVal cUsuario As ClsUsuarioSesion)

        Dim mCab As System.Web.UI.WebControls.MenuItem 'para las cabeceras
        Dim mIt As System.Web.UI.WebControls.MenuItem 'para los items


        If cUsuario.getflagadmin = 1 Then
            mCab = New System.Web.UI.WebControls.MenuItem
            mCab.Value = "1"
            mCab.Text = "Mantenimiento"
            Me.menuPrincipal.Items.Add(mCab)

            ''añade el item
            mIt = New System.Web.UI.WebControls.MenuItem
            mIt.Value = "1"
            mIt.Text = "Usuarios"
            mIt.NavigateUrl = FORM_QRY_COM_USUARIO_COMERCIO
            mIt.ToolTip = "Usuarios del comercio"

            mCab.ChildItems.Add(mIt)
        End If

        

    End Sub
End Class