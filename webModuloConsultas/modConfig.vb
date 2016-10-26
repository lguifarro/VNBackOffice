Imports System.Xml

Module modConfig

    Public Const sConfigFile = "config"
    'Public hostlist As HostList
    'Public librarylist As LibraryList
    Public cListServicios As ClsListaServicio
    Public cListEmpresas As ClsListaEmpresa
    Public cListColumnas As ClsListaColumna
    Public cListQuery As ClsListaQuery
    Public cListFiltros As ClsListaFiltro
    Public cListEstados As ClsListaEstado
    Public cListFiltrosEsp As ClsListaFiltroEspecial

    Public Const sFormatoCampoFecha = "DT"
    Public Const sFormatoCampoNumeric = "N"
    Public Const sFormatoCampoAlfaNumeric = "AN"

    Public sQuery As String


    Sub loadConfig(ByVal iIdProv As Integer, Optional ByRef sMensaje As String = "")

        Dim xml As XmlDocument
        Dim sIdProv As String = ""
        Dim sNomFile As String = ""
        Dim sPath As String = ""

        sPath = System.Configuration.ConfigurationSettings.AppSettings("sPath")
        If Right(sPath, 1) <> "\" Then
            sPath = sPath & "\"
        End If

        sIdProv = Right("000" & CStr(iIdProv), 3)
        sNomFile = sPath & sConfigFile & sIdProv & ".xml"
        Try
            xml = New XmlDocument()
            xml.Load(sNomFile)

            loadServiceList(xml, sMensaje)
            loadcListColumnas(xml, sMensaje)
            loadQuery(xml, sMensaje)
            loadFiltros(xml, sMensaje)
            loadEstados(xml, sMensaje)
            loadFiltrosEsp(xml, sMensaje)

        Catch ex As Exception
            sMensaje = ex.Message
        End Try

    End Sub
    Sub loadConfigComercio(ByVal iIdProv As Integer, Optional ByRef sMensaje As String = "")

        Dim xml As XmlDocument
        Dim sIdProv As String = ""
        Dim sNomFile As String = ""
        Dim sPath As String = ""

        sPath = System.Configuration.ConfigurationSettings.AppSettings("sPath")
        If Right(sPath, 1) <> "\" Then
            sPath = sPath & "\"
        End If

        'sIdProv = Right("000" & CStr(iIdProv), 3)
        sNomFile = sPath & sConfigFile & "COM" & ".xml"
        Try
            xml = New XmlDocument()
            xml.Load(sNomFile)

            'loadServiceList(xml, sMensaje)
            loadcListColumnas(xml, sMensaje)
            loadQuery(xml, sMensaje)
            'loadFiltros(xml, sMensaje)
            'loadEstados(xml, sMensaje)
            'loadFiltrosEsp(xml, sMensaje)

        Catch ex As Exception
            sMensaje = ex.Message
        End Try

    End Sub
    Sub loadConfigVisanet(ByVal iIdProv As Integer, Optional ByRef sMensaje As String = "")

        Dim xml As XmlDocument
        Dim sIdProv As String = ""
        Dim sNomFile As String = ""
        Dim sPath As String = ""

        sPath = System.Configuration.ConfigurationSettings.AppSettings("sPath")
        If Right(sPath, 1) <> "\" Then
            sPath = sPath & "\"
        End If

        'sIdProv = Right("000" & CStr(iIdProv), 3)
        sNomFile = sPath & sConfigFile & "VIS" & ".xml"
        Try
            xml = New XmlDocument()
            xml.Load(sNomFile)

            'loadServiceList(xml, sMensaje)
            loadcListColumnas(xml, sMensaje)
            loadQuery(xml, sMensaje)
            'loadFiltros(xml, sMensaje)
            'loadEstados(xml, sMensaje)
            'loadFiltrosEsp(xml, sMensaje)

        Catch ex As Exception
            sMensaje = ex.Message
        End Try

    End Sub
    Private Sub loadServiceList(ByVal xml As XmlDocument, ByRef sMensaje As String)
        Dim nodeList As XmlNodeList
        Dim node As XmlNode

        Dim service As ClsService

        Try
            nodeList = xml.SelectNodes("/config/services/service")
            'Console.WriteLine("Nodos Service por Leer: " & nodeList.Count & vbNewLine)

            cListServicios = New ClsListaServicio
            For Each node In nodeList
                service = New ClsService

                With node.Attributes
                    service.setId(.GetNamedItem("id").Value)
                    service.setName(.GetNamedItem("name").Value)

                End With
                cListServicios.Add(service)
            Next

        Catch ex As Exception
            'Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
            sMensaje = ex.Message
        Finally
            'Console.Read()
        End Try
    End Sub

    Private Sub loadQuery(ByVal xml As XmlDocument, ByRef sMensaje As String)
        Dim nodeList As XmlNodeList
        Dim node As XmlNode

        Dim oQuery As ClsQuery
        Try
            nodeList = xml.SelectNodes("/config/queries/query")
            'Console.WriteLine("Nodos Service por Leer: " & nodeList.Count & vbNewLine)

            cListQuery = New ClsListaQuery
            For Each node In nodeList
                oQuery = New ClsQuery

                With node.Attributes
                    oQuery.setId(.GetNamedItem("id").Value)
                    oQuery.setQuery(.GetNamedItem("string").Value)

                End With
                cListQuery.Add(oQuery)
            Next

        Catch ex As Exception
            'Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
            sMensaje = ex.Message
        Finally
            'Console.Read()
        End Try
    End Sub

    Private Sub loadcListColumnas(ByVal xml As XmlDocument, ByRef sMensaje As String)
        Dim nodeList As XmlNodeList
        Dim node As XmlNode

        Dim columna As ClsColumna

        Try
            nodeList = xml.SelectNodes("/config/columnas/columna")
            'Console.WriteLine("Nodos Service por Leer: " & nodeList.Count & vbNewLine)

            cListColumnas = New ClsListaColumna
            For Each node In nodeList
                columna = New ClsColumna

                With node.Attributes
                    columna.setIdColumna(.GetNamedItem("id").Value)
                    columna.setAlineado(.GetNamedItem("alineado").Value)
                    columna.setNombreCampo(.GetNamedItem("datafield").Value)
                    columna.setTitulo(.GetNamedItem("titulo").Value)
                    columna.setAncho(.GetNamedItem("ancho").Value)
                    columna.setFormato(.GetNamedItem("format").Value)

                End With
                cListColumnas.Add(columna)
            Next

        Catch ex As Exception
            'Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
            sMensaje = ex.Message
        Finally
            'Console.Read()
        End Try
    End Sub

    Private Sub loadFiltros(ByVal xml As XmlDocument, ByRef sMensaje As String)
        Dim nodeList As XmlNodeList
        Dim node As XmlNode

        Dim oFiltro As ClsFiltro
        Try
            nodeList = xml.SelectNodes("/config/filtros/filtro")
            'Console.WriteLine("Nodos Service por Leer: " & nodeList.Count & vbNewLine)

            cListFiltros = New ClsListaFiltro
            For Each node In nodeList
                oFiltro = New ClsFiltro

                With node.Attributes
                    oFiltro.setField(.GetNamedItem("field").Value)
                    oFiltro.setIdControl(.GetNamedItem("controlid").Value)
                    oFiltro.setIdFiltro(.GetNamedItem("id").Value)
                    oFiltro.setOperador(.GetNamedItem("operador").Value)
                    oFiltro.setPrefijo(.GetNamedItem("prefijo").Value)
                    oFiltro.setSufijo(.GetNamedItem("sufijo").Value)
                    oFiltro.setFormato(.GetNamedItem("formato").Value)
                    oFiltro.setFormatString(.GetNamedItem("formatstring").Value)
                End With
                cListFiltros.Add(oFiltro)
            Next

        Catch ex As Exception
            'Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
            sMensaje = ex.Message
        Finally
            'Console.Read()
        End Try
    End Sub

    Private Sub loadEstados(ByVal xml As XmlDocument, ByRef sMensaje As String)
        Dim nodeList As XmlNodeList
        Dim node As XmlNode

        Dim oEstado As ClsEstado
        Try
            nodeList = xml.SelectNodes("/config/estados/estado")
            'Console.WriteLine("Nodos Service por Leer: " & nodeList.Count & vbNewLine)

            cListEstados = New ClsListaEstado
            For Each node In nodeList
                oEstado = New ClsEstado

                With node.Attributes
                    oEstado.setId(.GetNamedItem("id").Value)
                    oEstado.setCodRespuesta(.GetNamedItem("codrespuesta").Value)
                    oEstado.setName(.GetNamedItem("descripcion").Value)
                End With
                cListEstados.Add(oEstado)
            Next

        Catch ex As Exception
            'Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
            sMensaje = ex.Message
        Finally
            'Console.Read()
        End Try
    End Sub

    Private Sub loadFiltrosEsp(ByVal xml As XmlDocument, ByRef sMensaje As String)
        Dim nodeList As XmlNodeList
        Dim node As XmlNode

        Dim oFiltro As ClsFiltroEspecial
        Try
            nodeList = xml.SelectNodes("/config/filtrosespeciales/filtroesp")
            'Console.WriteLine("Nodos Service por Leer: " & nodeList.Count & vbNewLine)

            cListFiltrosEsp = New ClsListaFiltroEspecial
            For Each node In nodeList
                oFiltro = New ClsFiltroEspecial

                With node.Attributes
                    oFiltro.setIdFiltroEsp(.GetNamedItem("id").Value)
                    oFiltro.setAncho(.GetNamedItem("ancho").Value)
                    oFiltro.setFormato(.GetNamedItem("format").Value)
                    oFiltro.setMaxLen(.GetNamedItem("maxlen").Value)
                    oFiltro.setNombreControl(.GetNamedItem("controlid").Value)
                    oFiltro.setTexto(.GetNamedItem("text").Value)
                End With
                cListFiltrosEsp.Add(oFiltro)
            Next

        Catch ex As Exception
            'Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
            sMensaje = ex.Message
        Finally
            'Console.Read()
        End Try
    End Sub
End Module
