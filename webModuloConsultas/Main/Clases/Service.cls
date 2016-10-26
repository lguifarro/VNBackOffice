Public Class Service
    Inherits System.Collections.CollectionBase
    Private id As String
    Private name As String

    Public Sub setId(ByVal sIdPar As String)
        id = sIdPar
    End Sub

    Public Function getId() As String
        Return id
    End Function

    Public Sub setName(ByVal sNamePar As String)
        name = sNamePar
    End Sub

    Public Function getName() As String
        Return name
    End Function

    Public Sub Add(ByVal oStepService As ServiceStep)
        List.Add(oStepService)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index no valido!")
        Else
            List.RemoveAt(index)
        End If
    End Sub

    Public ReadOnly Property getItem(ByVal index As Integer) As ServiceStep
        Get
            Return CType(List.Item(index), ServiceStep)
        End Get
    End Property

    Public ReadOnly Property getServiceStepByCommand(ByVal sCommand As String) As ServiceStep
        Get
            Dim oServiceStep As ServiceStep
            For i = 0 To List.Count - 1
                oServiceStep = List.Item(i)
                If String.Compare(oServiceStep.getCommand, sCommand) = 0 Then
                    Return CType(oServiceStep, ServiceStep)
                End If
            Next
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property getServiceStepById(ByVal id As String) As ServiceStep
        Get
            Dim oServiceStep As ServiceStep
            For i = 0 To List.Count - 1
                oServiceStep = List.Item(i)
                If String.Compare(oServiceStep.getId, id) = 0 Then
                    Return CType(oServiceStep, ServiceStep)
                End If
            Next
            Return Nothing
        End Get
    End Property
End Class
