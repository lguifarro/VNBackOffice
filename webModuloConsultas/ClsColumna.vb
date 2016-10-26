Public Class ClsColumna
    Inherits System.Collections.CollectionBase
    Private IdColumna As Integer
    Private sNombreCampo As String
    Private sTitulo As String
    Private sAlineado As String
    Private iAncho As Integer
    Private sFormato As String

    Public Sub setIdColumna(ByVal iIdParametro As Integer)
        IdColumna = iIdParametro
    End Sub

    Public Function getIdColumna() As Integer
        Return IdColumna

    End Function
    Public Sub setAncho(ByVal iIdParametro As Integer)
        iAncho = iIdParametro
    End Sub

    Public Function getAncho() As Integer
        Return iAncho

    End Function

    Public Sub setNombreCampo(ByVal sNamePar As String)
        sNombreCampo = sNamePar
    End Sub

    Public Function getNombreCampo() As String
        Return sNombreCampo
    End Function
    Public Sub setTitulo(ByVal sNamePar As String)
        sTitulo = sNamePar
    End Sub

    Public Function getTitulo() As String
        Return sTitulo
    End Function

    Public Sub setAlineado(ByVal sNamePar As String)
        sAlineado = sNamePar
    End Sub

    Public Function getAlineado() As String
        Return sAlineado
    End Function

    Public Sub setFormato(ByVal sNamePar As String)
        sFormato = sNamePar
    End Sub

    Public Function getFormato() As String
        If Not (sFormato Is Nothing) Then
            Return sFormato
        Else
            Return ""
        End If
    End Function

End Class
