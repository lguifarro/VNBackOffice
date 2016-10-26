Public Class Format
    Inherits System.Collections.CollectionBase
    Private id As String
    Private name As String

    Public Sub setId(ByVal idPar As String)
        id = idPar
    End Sub

    Public Function getId() As String
        Return id
    End Function

    Public Sub setName(ByVal namePar As String)
        name = namePar
    End Sub

    Public Function getName() As String
        Return name
    End Function

    Public Sub Add(ByVal formatField As formatFiled)
        List.Add(formatField)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index no valido!")
        Else
            List.RemoveAt(index)
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As formatFiled
        Get
            Return CType(List.Item(index), formatFiled)
        End Get
    End Property

    Public ReadOnly Property getFormatFieldById(ByVal id As String) As FormatFiled
        Get
            Dim formatFiled As FormatFiled
            For i = 0 To List.Count - 1
                formatFiled = List.Item(i)
                If String.Compare(formatFiled.getId, id) = 0 Then
                    Return CType(formatFiled, FormatFiled)
                End If
            Next
            Return Nothing
        End Get
    End Property
End Class
