Public Class ClsQuery
    Inherits System.Collections.CollectionBase

    Private sIdQuery As String
    Private sQuery As String

    Public Sub setQuery(ByVal sNamePar As String)
        sQuery = sNamePar
    End Sub

    Public Function getQuery() As String
        If sQuery Is Nothing Then
            Return ""
        Else
            Return sQuery
        End If

    End Function
    Public Sub setId(ByVal sNamePar As String)
        sIdQuery = sNamePar
    End Sub

    Public Function getIdQuery() As String
        If sIdQuery Is Nothing Then
            Return ""
        Else
            Return sIdQuery
        End If
    End Function
End Class
