Public Class Host
    Private id As String
    Private ip As String
    Private name As String
    Private idFormat As String
    Private state As Integer
    Private format As Format

    Public Sub setId(ByVal idPar As String)
        id = idPar
    End Sub

    Public Sub setIp(ByVal ipPar As String)
        ip = ipPar
    End Sub

    Public Sub setName(ByVal namePar As String)
        name = namePar
    End Sub

    Public Sub setIdFormat(ByVal idFormatPar As String)
        idFormat = idFormatPar
    End Sub

    Public Sub setState(ByVal statePar As String)
        state = statePar
    End Sub

    Public Sub setFormat(ByVal formatPar As Format)
        format = formatPar
    End Sub

    Public Function getId() As String
        Return id
    End Function

    Public Function getIp() As String
        Return ip
    End Function

    Public Function getName() As String
        Return name
    End Function

    Public Function getIdFormat() As String
        Return idFormat
    End Function

    Public Function getState() As String
        Return state
    End Function

    Public Function getFormat() As Format
        Return format
    End Function

End Class
