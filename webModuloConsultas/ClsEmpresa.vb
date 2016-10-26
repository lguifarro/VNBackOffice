Public Class ClsEmpresa

    Inherits System.Collections.CollectionBase
    Private CmcioId As Integer
    Private sNombreComercio As String

    Public Sub setId(ByVal iIdParametro As Integer)
        CmcioId = iIdParametro
    End Sub

    Public Function getId() As Integer
        Return CmcioId
    End Function

    Public Sub setName(ByVal sNamePar As String)
        sNombreComercio = sNamePar
    End Sub

    Public Function getName() As String
        Return sNombreComercio
    End Function

End Class
