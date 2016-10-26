Public Class ClsFiltro
    Inherits System.Collections.CollectionBase

    Private sIdFiltro As String
    Private sIdControl As String
    Private sField As String
    Private sOperador As String
    Private sPrefijo As String
    Private sSufijo As String
    Private sFormato As String
    Private sFormatString As String

    Public Sub setIdFiltro(ByVal sNamePar As String)
        sIdFiltro = sNamePar
    End Sub

    Public Function getIdFiltro() As String
        Return sIdFiltro
    End Function

    Public Sub setIdControl(ByVal sNamePar As String)
        sIdControl = sNamePar
    End Sub

    Public Function getIdControl() As String
        Return sIdControl
    End Function

    Public Sub setField(ByVal sNamePar As String)
        sField = sNamePar
    End Sub

    Public Function getField() As String
        Return sField
    End Function

    Public Sub setOperador(ByVal sNamePar As String)
        sOperador = sNamePar
    End Sub

    Public Function getOperador() As String
        Return sOperador
    End Function

    Public Sub setPrefijo(ByVal sNamePar As String)
        sPrefijo = sNamePar
    End Sub

    Public Function getPrefijo() As String
        Return sPrefijo
    End Function

    Public Sub setSufijo(ByVal sNamePar As String)
        sSufijo = sNamePar
    End Sub

    Public Function getSufijo() As String
        Return sSufijo
    End Function

    Public Sub setFormato(ByVal sNamePar As String)
        sFOrmato = sNamePar
    End Sub

    Public Function getFormato() As String
        Return sFormato
    End Function

    Public Sub setFormatString(ByVal sNamePar As String)
        sFormatString = sNamePar
    End Sub

    Public Function getFormatString() As String
        Return sFormatString
    End Function
End Class
