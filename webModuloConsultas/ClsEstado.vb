Public Class ClsEstado
    Inherits System.Collections.CollectionBase
    Private sIdEstado As String
    Private CodRespuesta As String
    Private Descripcion As String

    Public Sub setId(ByVal iIdParametro As String)
        sIdEstado = iIdParametro
    End Sub

    Public Function getId() As String
        If sIdEstado Is Nothing Then
            Return ""
        Else
            Return sIdEstado
        End If

    End Function

    Public Sub setName(ByVal sNamePar As String)
        Descripcion = sNamePar
    End Sub

    Public Function getName() As String
        If Descripcion Is Nothing Then
            Return ""
        Else
            Return Descripcion
        End If

    End Function

    Public Sub setCodRespuesta(ByVal sNamePar As String)
        CodRespuesta = sNamePar
    End Sub

    Public Function getCodRespuesta() As String
        If CodRespuesta Is Nothing Then
            Return ""
        Else
            Return CodRespuesta
        End If

    End Function


End Class
