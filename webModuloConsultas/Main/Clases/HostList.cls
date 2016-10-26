Public Class HostList
    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal host As Host)
        List.Add(host)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index no valido!")
        Else
            List.RemoveAt(index)
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As Host
        Get
            Return CType(List.Item(index), Host)
        End Get
    End Property

    Public ReadOnly Property getHostById(ByVal id As String) As Host
        Get
            Dim host As Host
            For i = 0 To List.Count - 1
                host = List.Item(i)
                If String.Compare(host.getId, id) = 0 Then
                    Return CType(host, Host)
                End If
            Next
            Return Nothing
        End Get
    End Property
End Class
