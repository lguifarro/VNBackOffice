Public Class ClsListaColumna

    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal oColumna As ClsColumna)
        List.Add(oColumna)
    End Sub

    Public Sub Remove(ByVal index As Integer, ByVal sMensajeResp As String)
        If index > Count - 1 Or index < 0 Then
            sMensajeResp = "Index no valido!"
        Else
            List.RemoveAt(index)
            sMensajeResp = ""
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As ClsColumna
        Get
            Return CType(List.Item(index), ClsColumna)
        End Get
    End Property

    Public ReadOnly Property getColumnaById(ByVal idColumna As Integer) As ClsColumna
        Get
            Try
                Dim oColumna As ClsColumna
                For i = 0 To List.Count - 1
                    oColumna = List.Item(i)
                    If oColumna.getIdColumna = idColumna Then
                        Return CType(oColumna, ClsColumna)
                    End If
                Next
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property
End Class
