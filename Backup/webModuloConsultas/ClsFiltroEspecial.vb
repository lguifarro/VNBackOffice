Public Class ClsFiltroEspecial
    Inherits System.Collections.CollectionBase

    Private sIdFiltroEsp As String
    Private sNombreControl As String
    Private sTexto As String
    Private maxLen As Integer
    Private sFormato As String
    Private Ancho As Integer

    Public Sub setIdFiltroEsp(ByVal sNamePar As String)
        sIdFiltroEsp = sNamePar
    End Sub

    Public Function getIdFiltroEsp() As String
        If sIdFiltroEsp Is Nothing Then
            Return ""
        Else
            Return sIdFiltroEsp
        End If

    End Function

    Public Sub setNombreControl(ByVal sNamePar As String)
        sNombreControl = sNamePar
    End Sub

    Public Function getNombreControl() As String
        If sNombreControl Is Nothing Then
            Return ""
        Else
            Return sNombreControl
        End If
    End Function

    Public Sub setTexto(ByVal sNamePar As String)
        sTexto = sNamePar
    End Sub

    Public Function getTexto() As String
        If sTexto Is Nothing Then
            Return ""
        Else
            Return sTexto
        End If
    End Function

    Public Sub setFormato(ByVal sNamePar As String)
        sTexto = sFormato
    End Sub

    Public Function getFormato() As String
        If sFormato Is Nothing Then
            Return ""
        Else
            Return sFormato
        End If
    End Function

    Public Sub setAncho(ByVal iParam As Integer)
        Ancho = iParam
    End Sub
    Public Function getAncho() As Integer
        Return Ancho
    End Function

    Public Sub setMaxLen(ByVal iParam As Integer)
        maxLen = iParam
    End Sub
    Public Function getMaxLen() As Integer
        Return maxLen
    End Function
End Class
