Public Class PrincipalVisanet
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If bValidaUsuarioSesion(enTipoUsuario.iVisaNet, Session) = False Then
            Response.Redirect(FORM_LOGIN_VIS)
            'End If

            'If Session(SES_USUARIO) Is Nothing Then
            '    Response.Redirect(FORM_LOGIN_COM)

        Else
            Dim cUsuario As ClsUsuarioSesion
            cUsuario = Session(SES_USUARIO)

            Me.lLogin.Text = "Bienvenido(a), " & cUsuario.getNombreUsuario & " " & cUsuario.getApPaternoUsuario

            If Not (IsPostBack) Then
                subLoadToolbar(Request.Url.Segments(Request.Url.Segments.Count - 1))
            End If

        End If

    End Sub

    Public Sub subLoadToolbar(ByVal sURL As String)

        Dim mIt As System.Web.UI.WebControls.MenuItem 'para el toolbar

        Dim ds As New DataSet
        Select Case sURL
            Case FORM_QRY_USUARIO_VISANET
                'añade el item
                mIt = New System.Web.UI.WebControls.MenuItem
                mIt.Text = "Nuevo" 'ds.Tables(0).Rows(i)("ITEMTEXTO")
                mIt.ImageUrl = imgNuevo 'ds.Tables(0).Rows(i)("IMAGEURL")
                mIt.NavigateUrl = FORM_MANT_USUARIO_VISANET & "?" & PARAM_OPCION_EDITAR & "=" & OPC_NUEVO '.Tables(0).Rows(i)("URLFORMDESTINO") & ds.Tables(0).Rows(i)("URLQUERYSTRING")
                mIt.ToolTip = "Creacion de un nuevo usuario" 'ds.Tables(0).Rows(i)("TOOLTIP")

                Me.mnuOpc.Items.Add(mIt)

            Case FORM_QRY_USUARIO_COMERCIO
                'añade el item
                mIt = New System.Web.UI.WebControls.MenuItem
                mIt.Text = "Nuevo" 'ds.Tables(0).Rows(i)("ITEMTEXTO")
                mIt.ImageUrl = imgNuevo 'ds.Tables(0).Rows(i)("IMAGEURL")
                mIt.NavigateUrl = FORM_MANT_USUARIO_COMERCIO & "?" & PARAM_OPCION_EDITAR & "=" & OPC_NUEVO '.Tables(0).Rows(i)("URLFORMDESTINO") & ds.Tables(0).Rows(i)("URLQUERYSTRING")
                mIt.ToolTip = "Creacion de un nuevo usuario" 'ds.Tables(0).Rows(i)("TOOLTIP")

                Me.mnuOpc.Items.Add(mIt)

            Case FORM_QRY_GRUPO_COMERCIO
                'añade el item
                mIt = New System.Web.UI.WebControls.MenuItem
                mIt.Text = "Nuevo" 'ds.Tables(0).Rows(i)("ITEMTEXTO")
                mIt.ImageUrl = imgNuevo 'ds.Tables(0).Rows(i)("IMAGEURL")
                mIt.NavigateUrl = FORM_MANT_GRUPO_COMERCIO & "?" & PARAM_OPCION_EDITAR & "=" & OPC_NUEVO '.Tables(0).Rows(i)("URLFORMDESTINO") & ds.Tables(0).Rows(i)("URLQUERYSTRING")
                mIt.ToolTip = "Creacion de un nuevo usuario" 'ds.Tables(0).Rows(i)("TOOLTIP")

                Me.mnuOpc.Items.Add(mIt)

            Case FORM_QRY_TARIFA_EMPRESA
                'añade el item
                mIt = New System.Web.UI.WebControls.MenuItem
                mIt.Text = "Nuevo" 'ds.Tables(0).Rows(i)("ITEMTEXTO")
                mIt.ImageUrl = imgNuevo 'ds.Tables(0).Rows(i)("IMAGEURL")
                mIt.NavigateUrl = FORM_MANT_TARIFA_EMPRESA & "?" & PARAM_OPCION_EDITAR & "=" & OPC_NUEVO '.Tables(0).Rows(i)("URLFORMDESTINO") & ds.Tables(0).Rows(i)("URLQUERYSTRING")
                mIt.ToolTip = "Creacion de una nueva tarifa" 'ds.Tables(0).Rows(i)("TOOLTIP")

                Me.mnuOpc.Items.Add(mIt)
        End Select


    End Sub
End Class