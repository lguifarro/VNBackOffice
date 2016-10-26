Public Class ClsListaEmpresa

    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal oEmpresa As ClsEmpresa)
        List.Add(oEmpresa)
    End Sub

    Public Sub Remove(ByVal index As Integer, ByVal sMensajeResp As String)
        If index > Count - 1 Or index < 0 Then
            sMensajeResp = "Index no valido!"
        Else
            List.RemoveAt(index)
            sMensajeResp = ""
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As ClsEmpresa
        Get
            Return CType(List.Item(index), ClsEmpresa)
        End Get
    End Property

    Public ReadOnly Property getServiceById(ByVal idEmpresa As Integer) As ClsEmpresa
        Get
            Try
                Dim oEmpresa As ClsEmpresa
                For i = 0 To List.Count - 1
                    oEmpresa = List.Item(i)
                    If oEmpresa.getId = idEmpresa Then
                        Return CType(oEmpresa, ClsEmpresa)
                    End If
                Next
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property
End Class
