Public Class ClsListaFiltro

    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal oColumna As ClsFiltro)
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

    Public ReadOnly Property getItem(ByVal index As Integer) As ClsFiltro
        Get
            Return CType(List.Item(index), ClsFiltro)
        End Get
    End Property

    Public ReadOnly Property getFiltroById(ByVal idFiltro As String) As ClsFiltro
        Get
            Try
                Dim oFiltro As ClsFiltro
                For i = 0 To List.Count - 1
                    oFiltro = List.Item(i)
                    If oFiltro.getIdFiltro = idFiltro Then
                        Return CType(oFiltro, ClsFiltro)
                    End If
                Next
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property
    Public ReadOnly Property getFiltroByControlId(ByVal idFiltro As String) As ClsFiltro
        Get
            Try
                Dim oFiltro As ClsFiltro
                For i = 0 To List.Count - 1
                    oFiltro = List.Item(i)
                    If UCase(oFiltro.getIdControl) = UCase(idFiltro) Then
                        Return CType(oFiltro, ClsFiltro)
                    End If
                Next
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property
End Class
