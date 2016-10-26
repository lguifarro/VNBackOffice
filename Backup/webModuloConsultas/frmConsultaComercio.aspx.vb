Imports IBM.Data.DB2
Imports System.Text
Imports System.IO

Imports System
Imports System.Threading
Public Class frmConsultaComercio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MsgBox("ENTRO")
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture

        If bValidaUsuarioSesion(enTipoUsuario.iComercio, Session) = False Then
            Response.Redirect(FORM_LOGIN_COM)
        End If
        'If Session(SES_USUARIO) Is Nothing Then
        '    Response.Redirect(FORM_LOGIN)
        'End If

        Dim iIdEmpresa As Integer
        Dim iIdGrupo As Integer
        Dim cUsuario As ClsUsuarioSesion
        Dim sMensaje As String = ""

        cUsuario = Session(SES_USUARIO)
        iIdGrupo = cUsuario.getidgrupo
        Session(SES_IDGRUPO) = iIdGrupo

        If Not IsPostBack Then

            subConsultaServicios()
            modConfig.loadConfigComercio(iIdEmpresa, sMensaje)

            If sMensaje <> "" Then
                Me.lMensaje.Text = sMensaje

                Me.bConsultar.Enabled = False

            Else
                Session(SES_LISTSERVICIO) = modConfig.cListServicios
                Session(SES_LISTCOLUMNAS) = modConfig.cListColumnas
                'Session(SES_FILTROS) = modConfig.cListFiltros
                'Session(SES_FILTROS_ESP) = modConfig.cListFiltrosEsp
                'Session(SES_QUERY) = modConfig.cListQuery
                'Session(SES_ESTADOS) = modConfig.cListEstados

                If Not (modConfig.cListServicios Is Nothing) Then
                    subLoadCmbServicios()
                End If

                'subLoadCmbEstados()
                'subLoadFiltrosEspeciales()

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
    Protected Sub subConsultaServicios()

        'Dim sMensaje As String = ""
        'Dim CN As DB2Connection
        'CN = Session(SES_CONN)

        'If CN.State = ConnectionState.Open Then

        '    Dim ds As New DataSet
        '    Dim da As New DB2DataAdapter
        '    Dim sSQL As String = ""

        '    'sSQL = subArmaQuery()
        '    sSQL = "SELECT SC.SERVI_CODIGO, S.SERVI_NOMBRE"
        '    sSQL = sSQL & " FROM SQMNUC.SERVICIO_CONSULTA SC, SQMNUC.SERVICIO S"
        '    sSQL = sSQL & " WHERE"
        '    sSQL = sSQL & " S.SERVI_CODIGO = SC.SERVI_CODIGO"
        '    sSQL = sSQL & " AND SC.IDGRUPO = 1 ORDER BY S.SERVI_CODIGO"

        '    If sSQL <> "" Then
        '        Dim com As New DB2Command


        '        com = New DB2Command(sSQL, CN)
        '        com.CommandType = CommandType.Text
        '        com.CommandTimeout = 60

        '        da.SelectCommand = com
        '        da.Fill(ds)

        '        'muestra la cantidad de registros
        '        If ds.Tables(0).Rows.Count <= 0 Then
        '            ShowError(lMensaje, "No se encontraron registros")
        '        Else
        '            'ShowError(lMensaje, Format(ds.Tables(0).Rows.Count, "###,###") & " registros encontrados")

        '            'CARGA LOS SERVICIOS EN LA CLISTA DE SERVICIOS
        '            loadServiceListComercio(ds, sMensaje, True)
        '        End If

        '        'enlaza la informacion
        '        'Me.cmbServicio.DataSource = ds
        '        'Me.cmbServicio.DataBind()

        '    End If

        'End If


        Dim sMensaje As String = ""
        Dim CN As DB2Connection
        CN = Session(SES_CONN)

        If CN.State = ConnectionState.Open Then

            Dim cConsulta As New ClsConsultas.ClsConsultaDB
            Dim cUsuario As ClsUsuarioSesion
            Dim ds As New DataSet

            Dim iIdUsuario As Integer
            Dim iIdGrupo As Integer = 0
            Dim sCR As String = ""
            Dim sDescError As String = ""
            cUsuario = Session(SES_USUARIO)
            iIdUsuario = cUsuario.getIdUsuario
            iIdGrupo = cUsuario.getIdGrupo
            'Dim iFlagAdmin As Integer = 0
            'Dim sLogin As String = ""
            'Dim sNombre As String = ""
            'Dim sApellidoP As String = ""
            'Dim sEmail As String = ""
            'Dim sEstado As String = ""
            'Dim dFechaInsert As Date
            'Dim dFechaUltActualiz As Date

            'cConsulta.spQRYDetalleUsuarioComercio(CN, iIdUsuario, iIdGrupo, iFlagAdmin, sLogin, sNombre, sApellidoP, sEmail, sEstado, dFechaInsert, dFechaUltActualiz, iIdUsuario, sCR, sDescError)

            ds = cConsulta.spQRYServicioConsulta(CN, iIdGrupo, 0, "", 1, iIdUsuario, sCR, sDescError)
            If sCR = TODO_OK Then

                'muestra la cantidad de registros
                If ds.Tables(0).Rows.Count <= 0 Then
                    ShowError(lMensaje, "No se encontraron registros")
                Else
                    'ShowError(lMensaje, Format(ds.Tables(0).Rows.Count, "###,###") & " registros encontrados")

                    'CARGA LOS SERVICIOS EN LA CLISTA DE SERVICIOS
                    loadListServicio(ds, sMensaje, True)
                End If

                'enlaza la informacion
                'Me.cmbServicio.DataSource = ds
                'Me.cmbServicio.DataBind()
            End If
        End If
    End Sub
    Protected Sub loadListServicio(ByVal ds As DataSet, ByRef sMensaje As String, Optional ByVal bTodos As Boolean = False)

        Dim service As ClsService
        Dim i As Integer
        Try

            modConfig.cListServicios = New ClsListaServicio
            If bTodos Then
                service = New ClsService
                service.setId(sCodTODOS)
                service.setName(sTodos)
                cListServicios.Add(service)
            End If
            For i = 0 To ds.Tables(0).Rows.Count - 1
                service = New ClsService

                'service.setId(ds.Tables(0).)
                'service.setName(.GetNamedItem("name").Value)
                service.setId(ds.Tables(0).Rows(i).Item("SERVI_CODIGO"))
                service.setName(ds.Tables(0).Rows(i).Item("SERVI_NOMBRE"))

                cListServicios.Add(service)
            Next

        Catch ex As Exception
            'Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
            sMensaje = ex.Message
        Finally
            'Console.Read()
        End Try
    End Sub

    Protected Function subArmaQuery() As String

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

        'ESTO SIEMPRE SE EJECUTA
        If Trim(sWhere) = "" Then
            sWhere = sWhere & " WHERE"
        Else
            sWhere = sWhere & " AND"
        End If
        sWhere = sWhere & " GC.IDGRUPO = " & CStr(cUsuario.getIdGrupo)

        'DEPENDIENDO DE LOS FILTROS INGRESADOS
        If Me.txtCodComercio.Text <> "" Then
            If Trim(sWhere) = "" Then
                sWhere = sWhere & " WHERE"
            Else
                sWhere = sWhere & " AND"
            End If
            sWhere = sWhere & " LOGPO_CMCIOPOS_CODIGO LIKE '" & Me.txtCodComercio.Text & "%'"
        End If

        If Me.txtNumTerminal.Text <> "" Then
            If Trim(sWhere) = "" Then
                sWhere = sWhere & " WHERE"
            Else
                sWhere = sWhere & " AND"
            End If
            sWhere = sWhere & " LOGPO_NRO_POS = '" & Me.txtCodComercio.Text & "'"
        End If

        If Me.txtFechaINI.Text <> "" Then
            If Trim(sWhere) = "" Then
                sWhere = sWhere & " WHERE"
            Else
                sWhere = sWhere & " AND"
            End If
            sWhere = sWhere & " LOGPO_FECHAYHORA >= TIMESTAMP_ISO('" & Format(CDate(Me.txtFechaINI.Text), "yyyy-MM-dd") & "')"
        End If
        If Me.txtFechaFin.Text <> "" Then
            If Trim(sWhere) = "" Then
                sWhere = sWhere & " WHERE"
            Else
                sWhere = sWhere & " AND"
            End If
            sWhere = sWhere & " LOGPO_FECHAYHORA <= TIMESTAMP_ISO('" & Format(CDate(Me.txtFechaFin.Text), "yyyy-MM-dd") & "') + 1 DAY"
        End If

        sValor = Me.cmbServicio.SelectedValue
        If sValor <> "" And sValor <> sCodTODOS Then
            If Trim(sWhere) = "" Then
                sWhere = sWhere & " WHERE"
            Else
                sWhere = sWhere & " AND"
            End If
            sWhere = sWhere & " LOGPO_SERVI_CODIGO = " & CStr(CInt(Me.cmbServicio.SelectedValue)) & ""
        End If


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

    Protected Sub bConsultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bConsultar.Click
        subConsultaTranComercio()
    End Sub
    Protected Sub subConsultaTranComercio(Optional ByVal bExportar As Boolean = False)

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

    
    Private Sub gridTran_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridTran.PageIndexChanging
        Dim grilla As GridView = CType(sender, GridView)
        With grilla
            .PageIndex = e.NewPageIndex()
        End With
        subConsultaTranComercio()
    End Sub

    
    Protected Sub bExportar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bExportar.Click
        subConsultaTranComercio(True)
    End Sub
End Class