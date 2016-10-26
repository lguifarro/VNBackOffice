Public Class ClsListaServicio

    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal oService As ClsService)
        List.Add(oService)
    End Sub

    Public Sub Remove(ByVal index As Integer, ByVal sMensajeResp As String)
        If index > Count - 1 Or index < 0 Then
            sMensajeResp = "Index no valido!"
        Else
            List.RemoveAt(index)
            sMensajeResp = ""
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As ClsService
        Get
            Return CType(List.Item(index), ClsService)
        End Get
    End Property

    Public ReadOnly Property getServiceById(ByVal idServicio As Integer) As ClsService
        Get
            Try
                Dim oService As ClsService
                For i = 0 To List.Count - 1
                    oService = List.Item(i)
                    If oService.getId = idServicio Then
                        Return CType(oService, ClsService)
                    End If
                Next
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property
End Class
