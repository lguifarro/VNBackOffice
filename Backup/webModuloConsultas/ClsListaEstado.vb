Public Class ClsListaEstado

    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal oEstado As ClsEstado)
        List.Add(oEstado)
    End Sub

    Public Sub Remove(ByVal index As Integer, ByVal sMensajeResp As String)
        If index > Count - 1 Or index < 0 Then
            sMensajeResp = "Index no valido!"
        Else
            List.RemoveAt(index)
            sMensajeResp = ""
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As ClsEstado
        Get
            Return CType(List.Item(index), ClsEstado)
        End Get
    End Property

    Public ReadOnly Property getEstadoById(ByVal sIdEstado As String) As ClsEstado
        Get
            Try
                Dim oEstado As ClsEstado
                For i = 0 To List.Count - 1
                    oEstado = List.Item(i)
                    If oEstado.getId = sIdEstado Then
                        Return CType(oEstado, ClsEstado)
                    End If
                Next
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property
    
End Class
