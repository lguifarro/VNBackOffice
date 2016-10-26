Imports IBM.Data.DB2
Imports System.Text
Imports System.IO

Imports System
Imports System.Threading


Public Class frmConsulta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'MsgBox("ENTRO")
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture

        If bValidaUsuarioSesion(enTipoUsuario.iEmpresa, Session) = False Then
            Response.Redirect(FORM_LOGIN)
        End If
        'If Session(SES_USUARIO) Is Nothing Then
        '    Response.Redirect(FORM_LOGIN)
        'End If

        Dim iIdEmpresa As Integer
        Dim cUsuario As ClsUsuarioSesion
        Dim sMensaje As String = ""

        cUsuario = Session(SES_USUARIO)
        iIdEmpresa = cUsuario.getIdComercio
        Session(SES_IDEMPRESA) = iIdEmpresa

        If Not IsPostBack Then

            modConfig.loadConfig(iIdEmpresa, sMensaje)

            If sMensaje <> "" Then
                Me.lMensaje.Text = sMensaje

                Me.bConsultar.Enabled = False

            Else
                Session(SES_LISTSERVICIO) = modConfig.cListServicios
                Session(SES_LISTCOLUMNAS) = modConfig.cListColumnas
                Session(SES_FILTROS) = modConfig.cListFiltros
                Session(SES_FILTROS_ESP) = modConfig.cListFiltrosEsp
                Session(SES_QUERY) = modConfig.cListQuery
                Session(SES_ESTADOS) = modConfig.cListEstados

                subLoadCmbServicios()
                subLoadCmbEstados()
                subLoadFiltrosEspeciales()

            End If

        End If
    End Sub

    Protected Sub subLoadCmbServicios()
        Dim lista As ClsListaServicio
        Dim oServicio As ClsService

        lista = Session(SES_LISTSERVICIO)
        Dim i As Integer
        Dim iServicio As System.Web.UI.WebControls.ListItem
        For i = 0 To lista.Count - 1
            oServicio = lista.getItem(i)
            iServicio = New System.Web.UI.WebControls.ListItem
            iServicio.Text = oServicio.getName
            iServicio.Value = oServicio.getId

            Me.cmbServicio.Items.Add(iServicio)

        Next

    End Sub
    Protected Sub subLoadCmbEstados()
        Dim lista As ClsListaEstado
        Dim oEstado As ClsEstado

        lista = Session(SES_ESTADOS)
        Dim i As Integer
        Dim iEstado As System.Web.UI.WebControls.ListItem

        For i = 0 To lista.Count - 1
            oEstado = lista.getItem(i)
            iEstado = New System.Web.UI.WebControls.ListItem
            iEstado.Text = oEstado.getName
            iEstado.Value = oEstado.getCodRespuesta

            Me.cmbEstado.Items.Add(iEstado)

        Next

    End Sub
    Protected Sub subConsultaTran(Optional ByVal bExportar As Boolean = False)

        ' validacion de datos
        If Not (bvalidacampos) Then
            Exit Sub
        End If

        Dim CN As DB2Connection
        CN = Session(SES_CONN)

        If CN.State = ConnectionState.Open Then

            Dim ds As New DataSet
            Dim da As New DB2DataAdapter
            Dim sSQL As String = ""

            sSQL = subArmaQuery()

            If sSQL <> "" Then
                Dim com As New DB2Command


                com = New DB2Command(sSQL, CN)
                com.CommandType = CommandType.Text
                com.CommandTimeout = 60

                da.SelectCommand = com
                da.Fill(ds)

                subFormatoGrid(Me.gridTran)

                'muestra la cantidad de registros
                If ds.Tables(0).Rows.Count <= 0 Then
                    ShowError(lMensaje, "No se encontraron registros")
                Else
                    ShowError(lMensaje, Format(ds.Tables(0).Rows.Count, "###,###") & " registros encontrados")
                End If

                If bExportar Then
                    ExportaGrid(ds)
                Else
                    'enlaza la informacion
                    Me.gridTran.DataSource = ds
                    Me.gridTran.DataBind()
                End If
            End If


        End If
    End Sub
    Public Function bValidaCampos() As Boolean

        If Me.txtCodComercio.Text <> "" And Not (IsNumeric(Me.txtCodComercio.Text)) Then
            ShowError(Me.lMensaje, "El código ingresado no es válido", True)
            txtCodComercio.Focus()
            bValidaCampos = False
            Exit Function
        End If

        If Me.txtNumTerminal.Text <> "" And Not (IsNumeric(Me.txtNumTerminal.Text)) Then
            ShowError(Me.lMensaje, "El terminal no es válido", True)
            txtNumTerminal.Focus()
            bValidaCampos = False
            Exit Function
        End If

        If Me.txtIdTran.Text <> "" And Not (IsNumeric(Me.txtIdTran.Text)) Then
            ShowError(Me.lMensaje, "El número de transacción no es válido", True)
            txtIdTran.Focus()
            bValidaCampos = False
            Exit Function
        End If

        If Me.txtFechaFin.Text <> "" And Not (IsDate(Me.txtFechaFin.Text)) Then
            ShowError(Me.lMensaje, "La fecha ingresada no es válida", True)
            txtFechaFin.Focus()
            bValidaCampos = False
            Exit Function
        End If

        If Me.txtFechaINI.Text <> "" And Not (IsDate(Me.txtFechaINI.Text)) Then
            ShowError(Me.lMensaje, "La fecha ingresada no es válida", True)
            txtFechaINI.Focus()
            bValidaCampos = False
            Exit Function
        End If

        bValidaCampos = True
    End Function

    Protected Sub subFormatoGrid(ByRef GV As GridView, Optional ByVal bExportar As Boolean = False)

        'formato del datagrid
        Dim listColumnas As ClsListaColumna
        listColumnas = Session(SES_LISTCOLUMNAS)

        Try
            Dim oColumna As ClsColumna
            Dim b As BoundField

            GV.Columns.Clear()

            For i = 0 To listColumnas.Count - 1
                oColumna = listColumnas.getItem(i)

                b = New BoundField
                b.DataField = oColumna.getNombreCampo
                b.HeaderText = oColumna.getTitulo
                b.HeaderStyle.Width = oColumna.getAncho

                Select Case oColumna.getAlineado
                    Case "izq"
                        b.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    Case "der"
                        b.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    Case Else
                        b.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                End Select

                If oColumna.getFormato <> "" Then
                    b.DataFormatString = oColumna.getFormato
                End If


                GV.Columns.Add(b)

            Next


        Catch ex As Exception

        End Try

        'ancho del grid
        Dim iAncho As Long
        For i = 1 To gridTran.Columns.Count - 1
            iAncho = iAncho + GV.Columns(i).HeaderStyle.Width.Value
        Next
        GV.Width = iAncho
    End Sub

    
    Protected Function subArmaQuery() As String
        Dim oFiltro As ClsFiltro

        Dim sWhere As String = ""
        Dim sOrder As String = ""
        Dim sSQL As String = ""
        Dim sFormatString As String = ""
        Dim sFormato As String = ""

        Dim qWhere As ClsQuery
        Dim qOrder As ClsQuery
        Dim sValor As String = ""
        Dim sId As String = ""
        Dim cUsuario As ClsUsuarioSesion

        Dim bFormatoOK As Boolean = False

        cUsuario = Session(SES_USUARIO)

        sSQL = modConfig.cListQuery.getQueryById("select").getQuery
        sSQL = sSQL & " "
        sSQL = sSQL & modConfig.cListQuery.getQueryById("from").getQuery

        'sWhere = modConfig.cListQuery.getQueryById("where").getQuery
        qWhere = modConfig.cListQuery.getQueryById("where")
        If qWhere Is Nothing Then
            sWhere = ""
        Else
            If qWhere.getQuery Is Nothing Then
                sWhere = ""
            Else
                sWhere = qWhere.getQuery
            End If
        End If


        If Trim(sWhere) = "" Then
            sWhere = sWhere & " WHERE"
        Else
            sWhere = sWhere & " AND"
        End If

        sWhere = sWhere & " LOGPO_CMCIO_ID = " & CStr(cUsuario.getIdComercio)

        For Each txtControl In Me.panFiltros.Controls
            If (TypeOf txtControl Is TextBox) Or (TypeOf txtControl Is DropDownList) Then

                sId = txtControl.id
                If (TypeOf txtControl Is TextBox) Then
                    sValor = txtControl.text
                ElseIf (TypeOf txtControl Is DropDownList) Then
                    Dim cmb As DropDownList = CType(txtControl, DropDownList)
                    sValor = cmb.SelectedValue

                End If

                If sValor <> "" And sValor <> scodTODOS Then

                    oFiltro = modConfig.cListFiltros.getFiltroByControlId(sId)
                    If Not (oFiltro Is Nothing) Then

                        sFormato = oFiltro.getFormato
                        If sFormato Is Nothing Then sFormato = ""

                        Select Case sFormato
                            Case sFormatoCampoFecha
                                If IsDate(sValor) Then bFormatoOK = True
                            Case sFormatoCampoAlfaNumeric
                                bFormatoOK = True
                            Case sFormatoCampoNumeric
                                If IsNumeric(sValor) Then bFormatoOK = True
                            Case Else
                                bFormatoOK = True
                        End Select

                        If Not bFormatoOK Then Return ""

                        If bFormatoOK Then
                            sWhere = sWhere & " AND"
                            sWhere = sWhere & " "
                            sWhere = sWhere & oFiltro.getField
                            sWhere = sWhere & " "
                            sWhere = sWhere & oFiltro.getOperador
                            sWhere = sWhere & " "
                            sWhere = sWhere & oFiltro.getPrefijo

                            sFormatString = oFiltro.getFormatString
                            If sFormatString Is Nothing Then sFormatString = ""
                            If sFormatString = "" Then
                                sWhere = sWhere & sValor
                            Else
                                'sWhere = sWhere & Format(txtControl.Text, sFormatString)
                                Select Case sFormato
                                    Case sFormatoCampoFecha
                                        sWhere = sWhere & Format(CDate(sValor), sFormatString)
                                    Case sFormatoCampoAlfaNumeric
                                        sWhere = sWhere & Format(sValor, sFormatString)
                                    Case sFormatoCampoNumeric
                                        sWhere = sWhere & Format(CLng(sValor), sFormatString)
                                    Case Else
                                        sWhere = sWhere & Format(sValor, sFormatString)
                                End Select
                            End If
                            sWhere = sWhere & oFiltro.getSufijo
                        End If


                    End If

                End If
            End If


        Next
        'ordenamiento
        qOrder = modConfig.cListQuery.getQueryById("order")
        If qOrder Is Nothing Then
            sOrder = ""
        Else
            If qOrder.getQuery Is Nothing Then
                sOrder = ""
            Else
                sOrder = qOrder.getQuery
            End If
        End If

        sSQL = sSQL & " " & sWhere & " " & sOrder

        Session(SES_QUERY) = sSQL

        Return sSQL

    End Function

    Protected Sub bConsultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bConsultar.Click
        subConsultaTran()
    End Sub

    Protected Sub subLoadFiltrosEspeciales()
        Dim lista As ClsListaFiltroEspecial
        Dim oFiltro As ClsFiltroEspecial

        lista = Session(SES_FILTROS_ESP)

        Dim i As Integer
        Dim sCadAux As String
        Dim iIntAux As Integer
        Dim txtControl As TextBox
        Dim lControl As Label

        For i = 0 To lista.Count - 1
            oFiltro = lista.getItem(i)

            For Each cCampo In Me.panFiltros.Controls
                If (TypeOf cCampo Is TextBox) Then
                    txtControl = cCampo

                    If UCase(txtControl.ID) = UCase(oFiltro.getNombreControl) Then
                        sCadAux = oFiltro.getTexto
                        txtControl.Text = sCadAux

                        iIntAux = oFiltro.getAncho
                        If iIntAux > 0 Then txtControl.Width = iIntAux

                        iIntAux = oFiltro.getMaxLen
                        If iIntAux > 0 Then txtControl.MaxLength = iIntAux

                        txtControl.Visible = True
                    End If


                ElseIf (TypeOf cCampo Is Label) Then
                    lControl = cCampo

                    If UCase(lControl.ID) = UCase(oFiltro.getNombreControl) Then
                        sCadAux = oFiltro.getTexto
                        lControl.Text = sCadAux

                        iIntAux = oFiltro.getAncho
                        If iIntAux > 0 Then lControl.Width = iIntAux

                        'iIntAux = oFiltro.getMaxLen
                        'If iIntAux > 0 Then lControl.MaxLength = iIntAux
                        lControl.Visible = True

                    End If

                End If

            Next
            

        Next

    End Sub

    Public Sub ExportaGrid(ByVal ds As DataSet)
        'export the Gridview to an excel document called Data.xls
        'Dim DGaux As New DataGrid

        'DGaux.DataSource = DG.DataSource
        'DGaux.DataBind()

        'Response.Clear()
        'Response.AddHeader("content-disposition", "attachment;filename=Data.xls")
        'Response.Charset = ""
        'Response.ContentType = "application/vnd.xls"
        'Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter
        'Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)

        'DGaux.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString)
        'Response.End()

        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As StringWriter = New StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim form As New HtmlForm

        Dim GV As New GridView
        subFormatoGrid(GV, True)
        GV.AutoGenerateColumns = False
        GV.DataSource = ds
        GV.DataBind()

        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(GV)
        pagina.RenderControl(htw)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls")
        Response.Charset = "UTF-8"

        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()

        GV = Nothing

    End Sub

    Protected Sub bExportar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bExportar.Click

        subConsultaTran(True)

    End Sub

    Private Sub gridTran_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridTran.PageIndexChanging

        Dim grilla As GridView = CType(sender, GridView)
        With grilla
            .PageIndex = e.NewPageIndex()
        End With
        subConsultaTran()
    End Sub

    Private Function fValidaCampos(ByRef sMensaje As String) As Boolean

        If (Me.txtCodComercio.Text <> "") And (Not (IsNumeric(Me.txtCodComercio.Text))) Then
            sMensaje = "El código de comercio debe ser numérico"
            Me.txtCodComercio.Focus()
            Return False
        End If

        If (Me.txtNumTerminal.Text <> "") And (Not (IsNumeric(Me.txtNumTerminal.Text))) Then
            sMensaje = "El número de terminal debe ser numérico"
            Me.txtNumTerminal.Focus()
            Return False
        End If

        Return True
    End Function
End Class