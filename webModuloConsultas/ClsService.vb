Public Class ClsService

    Inherits System.Collections.CollectionBase
    Private IdServicio As Integer
    Private sNombreServicio As String

    Public Sub setId(ByVal iIdParametro As Integer)
        IdServicio = iIdParametro
    End Sub

    Public Function getId() As Integer
        Return IdServicio
    End Function

    Public Sub setName(ByVal sNamePar As String)
        sNombreServicio = sNamePar
    End Sub

    Public Function getName() As String
        Return sNombreServicio
    End Function


End Class
