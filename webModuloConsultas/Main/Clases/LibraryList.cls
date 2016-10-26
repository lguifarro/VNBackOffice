Public Class LibraryList
    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal library As Library)
        List.Add(library)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index no valido!")
        Else
            List.RemoveAt(index)
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As Library
        Get
            Return CType(List.Item(index), Library)
        End Get
    End Property

    Public ReadOnly Property getLibraryById(ByVal id As String) As Library
        Get
            Dim olibrary As Library
            For i = 0 To List.Count - 1
                olibrary = List.Item(i)
                If String.Compare(olibrary.getId, id) = 0 Then
                    Return CType(olibrary, Library)
                End If
            Next
            Return Nothing
        End Get
    End Property
End Class
