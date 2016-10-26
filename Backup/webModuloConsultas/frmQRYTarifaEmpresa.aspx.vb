Imports IBM.Data.DB2
Imports System.Text
Imports System.IO
Public Class frmQRYTarifaEmpresa
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

            cmbEmpresa.SelectedIndex = -1
            'para el boton de regreso
            'Me.bCancelar.Attributes.Add("onClick", scriptBACK)

            subConsultaTarifaEmpresa()

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
            subConsultaTarifaEmpresa()

            'Else
            '    Me.cmbGrupo.Items.Clear()
            '    sIdEmpresa = ""
        End If
    End Sub

    Protected Sub subConsultaTarifaEmpresa(Optional ByVal bExportar As Boolean = False)

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
        If IsNumeric(Me.cmbEmpresa.SelectedValue) Then iIdEmpresaBusca = Me.cmbEmpresa.SelectedValue

        Dim ds As DataSet
        Dim cn As DB2Connection

        ShowError(lMensaje, "")
        cn = Session(SES_CONN)

        'CONSULTA LA TARIFA BASE
        Dim sTipoCalculo As String = ""
        Dim sMoneda As String = ""
        Dim dFechaInsert As Date
        Dim dFechaUltActualiz As Date

        Me.rbMoneda.Items(indexSoles).Selected = False
        Me.rbMoneda.Items(indexDolares).Selected = False
        Me.rbTipoCalculo.Items(indexUnico).Selected = False
        Me.rbTipoCalculo.Items(indexVariable).Selected = False

        cConsulta.spQRYDetalleTarifaEmpresa(cn, iIdEmpresaBusca, sTipoCalculo, sMoneda, dFechaInsert, dFechaUltActualiz, iIdUsuario, sCR, sDescError)
        If sMoneda = sMonedaSol Then Me.rbMoneda.Items(indexSoles).Selected = True
        If sMoneda = sMonedaDol Then Me.rbMoneda.Items(indexDolares).Selected = True

        If sTipoCalculo = sTipoCalculoFijo Then Me.rbTipoCalculo.Items(indexUnico).Selected = True
        If sTipoCalculo = sTipoCalculoVariable Then Me.rbTipoCalculo.Items(indexVariable).Selected = True

        'CONSULTA LOS RANGOS DE TARIFAS
        ds = cConsulta.spQRYRangoTarifaEmpresa(cn, iIdEmpresaBusca, 0, iIdUsuario, sCR, sDescError)

        If sCR = TODO_OK Then

            subFormatoGrid(Me.gridTarifa)

            Me.gridTarifa.DataSource = ds
            gridTarifa.DataBind()

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
        b.DataField = "IDTARIFA"
        b.HeaderText = "Id"
        b.ItemStyle.Width = 60
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)


        b = New BoundField
        b.DataField = "TRX_DESDE"
        b.HeaderText = "Desde"
        b.ItemStyle.Width = 40
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "TRX_HASTA"
        b.HeaderText = "Hasta"
        b.ItemStyle.Width = 40
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
        'b.DataFormatString = oColumna.getFormato
        GV.Columns.Add(b)

        b = New BoundField
        b.DataField = "TARIFA"
        b.HeaderText = "Tarifa x Txn"
        b.ItemStyle.Width = 60
        b.ItemStyle.HorizontalAlign = HorizontalAlign.Right
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

    Protected Sub bGrabarTarifa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bGrabarTarifa.Click

        Dim cUsuario As ClsUsuarioSesion
        Dim iIdUsuario As Integer
        Dim sCR As String = ""
        Dim sDescError As String = ""

        cUsuario = Session(SES_USUARIO)
        iIdUsuario = cUsuario.getIdUsuario

        'parámetros de búsqueda
        Dim iIdEmpresaBusca As Integer = 0
        If IsNumeric(Me.cmbEmpresa.SelectedValue) Then iIdEmpresaBusca = Me.cmbEmpresa.SelectedValue

        Dim sMoneda As String = ""
        Dim sTipoCalculo As String = ""

        Dim cn As DB2Connection
        cn = Session(SES_CONN)

        sMoneda = Me.rbMoneda.SelectedValue
        sTipoCalculo = Me.rbTipoCalculo.SelectedValue

        Dim cConsulta As New ClsConsultas.ClsConsultaDB
        cConsulta.spMANTUpdateTarifaEmpresa(cn, iIdEmpresaBusca, sMoneda, sTipoCalculo, iIdUsuario, sCR, sDescError)

    End Sub

    Protected Sub bNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bNuevo.Click

        sublimpiacampos()

    End Sub
    Public Sub subLimpiaCampos()
        Me.lIdTarifa.Text = ""
        Me.txtHasta.Text = ""
        Me.txtTarifa.Text = ""
        Me.txtdesde.text = ""
    End Sub

    Public Function bValidaCampos(ByRef sMensajeRet As String) As Boolean
        Dim bValida As Boolean = True

        If Me.txtDesde.Text = "" Then
            bValida = False
            sMensajeRet = "Debe ingresar numero minimo de trx"
            txtDesde.Focus()
        End If
        If Me.txtHasta.Text = "" Then
            bValida = False
            sMensajeRet = "Debe ingresar numero maximo de trx"
            txtHasta.Focus()
        End If
        If Me.txttarifa.Text = "" Then
            bValida = False
            sMensajeRet = "Debe ingresar una tarifa"
            txtTarifa.Focus()
        End If

        If Not (IsNumeric(Me.txtDesde.Text)) Then
            bValida = False
            sMensajeRet = "El valor ingresado no es valido"
            txtDesde.Focus()
        End If
        If Not (IsNumeric(Me.txtHasta.Text)) Then
            bValida = False
            sMensajeRet = "El valor ingresado no es valido"
            txtHasta.Focus()
        End If
        If Not (IsNumeric(Me.txtTarifa.Text)) Then
            bValida = False
            sMensajeRet = "El valor ingresado no es valido"
            txtTarifa.Focus()
        End If

        Return bValida

    End Function

    Protected Sub bGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bGrabar.Click
        Dim sIdTarifaUpdate As String = ""
        Dim iIdTarifaUpdate As Integer

        sIdTarifaUpdate = Me.lIdTarifa.Text
        If IsNumeric(sIdTarifaUpdate) Then iIdTarifaUpdate = CInt(sIdTarifaUpdate)

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
            Dim lTrxDesde As Long = 0
            Dim lTrxHasta As Long = 0
            Dim dTarifa As Double = 0
            Dim iIdEmpresa As Integer = 0

            iIdEmpresa = Me.cmbEmpresa.SelectedValue
            lTrxDesde = CLng(Me.txtDesde.Text)
            lTrxHasta = CLng(Me.txtHasta.Text)
            dTarifa = CDbl(Me.txtTarifa.Text)

            If VerificaConexion(cn, sDescError) = iResultOK Then

                If Me.lIdTarifa.Text = "" Then
                    iResp = cConsulta.spmantInsertRangoTarifa(cn, iIdEmpresa, lTrxDesde, lTrxHasta, dTarifa, iIDUsuario, sCR, sDescError)
                Else
                    iResp = cConsulta.spMANTUpdateRangoTarifa(cn, iIdTarifaUpdate, iIdEmpresa, lTrxDesde, lTrxHasta, dTarifa, iIDUsuario, sCR, sDescError)
                End If

                subConsultaTarifaEmpresa()

                If iResp = iResultOK Then


                    If sCR = TODO_OK Then
                        'Response.Redirect(FORM_QRY_USUARIO_COMERCIO)
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
End Class