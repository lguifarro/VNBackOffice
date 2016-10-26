Public Class FormatFiled
    Private id As String
    Private name As String
    Private len As Integer
    Private pos As Integer
    Private types As String
    Private inclued As Integer

    Public Sub setId(ByVal idPar As String)
        id = idPar
    End Sub

    Public Sub setName(ByVal namePar As String)
        name = namePar
    End Sub

    Public Sub setLen(ByVal lenPar As String)
        len = lenPar
    End Sub

    Public Sub setPos(ByVal posPar As String)
        pos = posPar
    End Sub

    Public Sub setTypes(ByVal typesPar As String)
        types = typesPar
    End Sub

    Public Sub setInclued(ByVal incluedPar As String)
        inclued = incluedPar
    End Sub

    Public Function getId() As String
        Return id
    End Function

    Public Function getName() As String
        Return name
    End Function

    Public Function getLen() As String
        Return len
    End Function

    Public Function getPos() As String
        Return pos
    End Function

    Public Function getTypes() As String
        Return types
    End Function

    Public Function getInclued() As String
        Return inclued
    End Function

End Class
