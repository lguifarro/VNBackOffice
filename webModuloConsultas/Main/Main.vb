Imports System.Xml

Module Main
    Public Const config = "config.xml"
    Public hostlist As HostList
    Public librarylist As LibraryList
    Public serviceList As ServiceList

    Sub loadConfig(ByVal iIdProv As Integer)
        Dim xml As XmlDocument
        Dim sIdProv As strinng = ""
        Try
            xml = New XmlDocument()
            xml.Load(config)

            loadHostList(xml)
            loadLibraryList(xml)
            loadServiceList(xml)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub loadHostList(ByRef xml As XmlDocument)
        Dim nodeList As XmlNodeList
        Dim node As XmlNode
        Dim host As Host
        Dim format As Format

        Try
            nodeList = xml.SelectNodes("/config/hosts/host[@state=1]")
            Console.WriteLine("Nodos por Leer: " & nodeList.Count & vbNewLine)

            hostlist = New HostList

            For Each node In nodeList
                host = New Host
                With node.Attributes

                    host.setId(.GetNamedItem("id").Value)
                    host.setIp(.GetNamedItem("ip").Value)
                    host.setName(.GetNamedItem("name").Value)
                    host.setIdFormat(.GetNamedItem("idFormat").Value)
                    host.setState(.GetNamedItem("state").Value)

                    format = getFormat(xml, .GetNamedItem("idFormat").Value)
                    host.setFormat(format)

                    If format Is Nothing Then
                        MsgBox("No trae nada el format.")
                    End If

                    Console.WriteLine("================================================")
                    Console.WriteLine("ID: " & .GetNamedItem("id").Value)
                    Console.WriteLine("Ip: " & .GetNamedItem("ip").Value)
                    Console.WriteLine("Name: " & .GetNamedItem("name").Value)
                    Console.WriteLine("idFormat: " & .GetNamedItem("idFormat").Value)
                    Console.WriteLine("state: " & .GetNamedItem("state").Value)
                    Console.WriteLine("================================================")
                    Console.Write(vbNewLine)
                End With
                hostlist.Add(host)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
        Finally
            Console.Read()
        End Try
    End Sub

    Function getFormat(ByRef xml As XmlDocument, ByVal idFormat As String) As Format
        Dim formatReturn As Format
        Dim Node As XmlNode
        Dim NodeChild As XmlNode
        Dim formatfield As FormatFiled

        Try
            formatReturn = New Format

            Node = xml.SelectSingleNode("/config/formats/format[@id='" + idFormat + "']")

            formatReturn.setId(Node.Attributes.GetNamedItem("id").Value)
            formatReturn.setName(Node.Attributes.GetNamedItem("name").Value)

            For Each NodeChild In Node.ChildNodes
                formatfield = New FormatFiled
                With NodeChild.Attributes
                    formatfield.setId(.GetNamedItem("id").Value)
                    formatfield.setName(.GetNamedItem("name").Value)
                    formatfield.setLen(.GetNamedItem("len").Value)
                    formatfield.setPos(.GetNamedItem("pos").Value)
                    formatfield.setTypes(.GetNamedItem("type").Value)
                    formatfield.setInclued(.GetNamedItem("included").Value)

                    Console.WriteLine("================================================")
                    Console.WriteLine("ID: " & .GetNamedItem("id").Value)
                    Console.WriteLine("name: " & .GetNamedItem("name").Value)
                    Console.WriteLine("len: " & .GetNamedItem("len").Value)
                    Console.WriteLine("pos: " & .GetNamedItem("pos").Value)
                    Console.WriteLine("type: " & .GetNamedItem("type").Value)
                    Console.WriteLine("included: " & .GetNamedItem("included").Value)
                    Console.WriteLine("================================================")
                    Console.Write(vbNewLine)

                End With
                formatReturn.Add(formatfield)
            Next

        Catch ex As Exception
            formatReturn = Nothing
        End Try

        Return formatReturn
    End Function

    Private Sub loadLibraryList(ByRef xml As XmlDocument)
        Dim nodeList As XmlNodeList
        Dim node As XmlNode
        Dim library As Library

        Try
            nodeList = xml.SelectNodes("/config/libraries/library")
            Console.WriteLine("Nodos Library por Leer: " & nodeList.Count & vbNewLine)

            librarylist = New LibraryList
            For Each node In nodeList
                library = New Library
                With node.Attributes
                    library.setId(.GetNamedItem("id").Value)
                    library.setName(.GetNamedItem("name").Value)
                    library.setClassName(.GetNamedItem("className").Value)
                    library.setMethodName(.GetNamedItem("methodName").Value)

                    Console.WriteLine("================================================")
                    Console.WriteLine("ID: " & .GetNamedItem("id").Value)
                    Console.WriteLine("Name: " & .GetNamedItem("name").Value)
                    Console.WriteLine("className: " & .GetNamedItem("className").Value)
                    Console.WriteLine("methodName: " & .GetNamedItem("methodName").Value)
                    Console.WriteLine("================================================")
                    Console.Write(vbNewLine)
                End With
                librarylist.Add(library)
            Next

        Catch ex As Exception
            Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
        Finally
            Console.Read()
        End Try
    End Sub

    Private Sub loadServiceList(ByVal xml As XmlDocument)
        Dim nodeList As XmlNodeList
        Dim node As XmlNode
        Dim service As Service
        Dim NodeChild As XmlNode
        Dim serviceStep As ServiceStep

        Try
            nodeList = xml.SelectNodes("/config/services/service")
            Console.WriteLine("Nodos Service por Leer: " & nodeList.Count & vbNewLine)

            ServiceList = New ServiceList
            For Each node In nodeList
                service = New Service
                With node.Attributes
                    service.setId(.GetNamedItem("id").Value)
                    service.setName(.GetNamedItem("name").Value)

                    For Each NodeChild In node.ChildNodes
                        serviceStep = New ServiceStep
                        With NodeChild.Attributes
                            serviceStep.setId(.GetNamedItem("id").Value)
                            serviceStep.setOK(.GetNamedItem("OK").Value)
                            serviceStep.setNOK(.GetNamedItem("NOK").Value)
                            serviceStep.setCommand(.GetNamedItem("command").Value)
                            serviceStep.setLibrary(.GetNamedItem("library").Value)
                            serviceStep.setName(.GetNamedItem("name").Value)

                            Console.WriteLine("================================================")
                            Console.WriteLine("ID: " & .GetNamedItem("id").Value)
                            Console.WriteLine("OK: " & .GetNamedItem("OK").Value)
                            Console.WriteLine("NOK: " & .GetNamedItem("NOK").Value)
                            Console.WriteLine("command: " & .GetNamedItem("command").Value)
                            Console.WriteLine("library: " & .GetNamedItem("library").Value)
                            Console.WriteLine("name: " & .GetNamedItem("name").Value)
                            Console.WriteLine("================================================")
                            Console.Write(vbNewLine)

                        End With
                        service.Add(serviceStep)
                    Next

                End With
                serviceList.Add(service)
            Next

        Catch ex As Exception
            Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
        Finally
            Console.Read()
        End Try
    End Sub

End Module
