Public Class ClsListaQuery
    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal oQuery As ClsQuery)
        List.Add(oQuery)
    End Sub

    Public Sub Remove(ByVal index As Integer, ByVal sMensajeResp As String)
        If index > Count - 1 Or index < 0 Then
            sMensajeResp = "Index no valido!"
        Else
            List.RemoveAt(index)
            sMensajeResp = ""
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As ClsQuery
        Get
            Return CType(List.Item(index), ClsQuery)
        End Get
    End Property

    Public ReadOnly Property getQueryById(ByVal sIdQuery As String) As ClsQuery
        Get
            Try
                Dim oquery As ClsQuery
                For i = 0 To List.Count - 1
                    oquery = List.Item(i)
                    If oquery.getIdQuery = sIdQuery Then
                        Return CType(oquery, ClsQuery)
                    End If
                Next
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property
End Class
