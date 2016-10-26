Imports IBM.Data.DB2

Module modForm
    'Public Sub subLoadCMBTipoAlarma(ByVal cn As SqlConnection, _
    '                                ByRef cmb As System.Web.UI.WebControls.DropDownList, _
    '                                ByVal iIdUsuario As Integer, _
    '                                ByRef sCR As String, _
    '                                ByRef sDescError As String)
    '    Dim ds As DataSet
    '    Dim cConsulta As New clsConsultaDB

    '    If VerificaConexion(cn) = iResultOK Then
    '        ds = cConsulta.spQRYTipoAlarma(cn, "", iIdUsuario, sCR, sDescError)
    '        cmb.DataSource = ds
    '        cmb.DataTextField = "DESCRIPCION"
    '        cmb.DataValueField = "CODTIPO"
    '        cmb.DataBind()
    '        'cmb.SelectedIndex = -1
    '    End If
    'End Sub
    Public Sub subLoadCMBDataSet(ByVal ds As DataSet, _
                                ByRef cmb As System.Web.UI.WebControls.DropDownList, _
                                ByVal sDataTextField As String, _
                                ByVal sDataValueField As String, _
                                Optional ByVal bClear As Boolean = True)

        If bClear Then cmb.Items.Clear()

        cmb.DataSource = ds
        cmb.DataTextField = sDataTextField
        cmb.DataValueField = sDataValueField
        cmb.DataBind()

    End Sub
    Public Sub subLoadCMBDataSetAllInt(ByVal ds As DataSet, _
                            ByRef cmb As System.Web.UI.WebControls.DropDownList, _
                            ByVal sDataTextField As String, _
                            ByVal sDataValueField As String, _
                            Optional ByVal bClear As Boolean = True, _
                            Optional ByVal bTodos As Boolean = False, _
                            Optional ByVal iValorTodos As Integer = 0)

        If bClear Then cmb.Items.Clear()

        Dim it As System.Web.UI.WebControls.ListItem
        If bTodos Then

            it = New System.Web.UI.WebControls.ListItem(sTodos, iValorTodos)
            cmb.Items.Add(it)
        End If

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            it = New System.Web.UI.WebControls.ListItem(ds.Tables(0).Rows(i)(sDataTextField), ds.Tables(0).Rows(i)(sDataValueField))
            cmb.Items.Add(it)
        Next

    End Sub
    Public Sub subLoadCMBDataSetAllStr(ByVal ds As DataSet, _
                            ByRef cmb As System.Web.UI.WebControls.DropDownList, _
                            ByVal sDataTextField As String, _
                            ByVal sDataValueField As String, _
                            Optional ByVal bClear As Boolean = True, _
                            Optional ByVal bTodos As Boolean = False, _
                            Optional ByVal sValorTodos As String = "")

        If bClear Then cmb.Items.Clear()

        Dim it As System.Web.UI.WebControls.ListItem
        If bTodos Then

            it = New System.Web.UI.WebControls.ListItem(sTodos, sValorTodos)
            cmb.Items.Add(it)
        End If

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            it = New System.Web.UI.WebControls.ListItem(ds.Tables(0).Rows(i)(sDataTextField), ds.Tables(0).Rows(i)(sDataValueField))
            cmb.Items.Add(it)
        Next

    End Sub
    Public Sub ShowError(ByRef lMensaje As System.Web.UI.WebControls.Label, _
                          ByVal sDescError As String, _
                          Optional ByVal bError As Boolean = False)

        lMensaje.Text = sDescError
        If bError Then
            lMensaje.ForeColor = Drawing.Color.Red
        Else
            lMensaje.ForeColor = Drawing.Color.Black
        End If


    End Sub

End Module
