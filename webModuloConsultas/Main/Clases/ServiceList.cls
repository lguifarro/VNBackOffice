Public Class ServiceList
    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal oService As Service)
        List.Add(oService)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index no valido!")
        Else
            List.RemoveAt(index)
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As Service
        Get
            Return CType(List.Item(index), Service)
        End Get
    End Property

    Public ReadOnly Property getServiceById(ByVal id As String) As Service
        Get
            Try
                Dim oService As Service
                For i = 0 To List.Count - 1
                    oService = List.Item(i)
                    If String.Compare(oService.getId, id) = 0 Then
                        Return CType(oService, Service)
                    End If
                Next
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try
            
        End Get
    End Property

End Class
