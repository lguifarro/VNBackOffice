Public Class ServiceStep
    Private id As String
    Private name As String
    Private OK As String
    Private NOK As String
    Private command As String
    Private library As String

    Public Sub setId(ByVal idPar As String)
        id = idPar
    End Sub

    Public Sub setName(ByVal namePar As String)
        name = namePar
    End Sub

    Public Sub setOK(ByVal okPar As String)
        OK = okPar
    End Sub

    Public Sub setNOK(ByVal nokPar As String)
        NOK = nokPar
    End Sub

    Public Sub setCommand(ByVal commandPar As String)
        command = commandPar
    End Sub

    Public Sub setLibrary(ByVal libraryPar As String)
        library = libraryPar
    End Sub

    Public Function getId() As String
        Return id
    End Function

    Public Function getName() As String
        Return name
    End Function

    Public Function getOK() As String
        Return OK
    End Function

    Public Function getNOK() As String
        Return NOK
    End Function

    Public Function getCommand() As String
        Return command
    End Function

    Public Function getLibrary() As String
        Return library
    End Function

End Class
