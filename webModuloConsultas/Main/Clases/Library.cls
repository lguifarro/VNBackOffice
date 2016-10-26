Public Class Library
    Private id As String
    Private name As String
    Private className As String
    Private methodName As String

    Public Sub setId(ByVal idPar As String)
        id = idPar
    End Sub

    Public Sub setName(ByVal namePar As String)
        name = namePar
    End Sub

    Public Sub setClassName(ByVal classNamePar As String)
        className = classNamePar
    End Sub

    Public Sub setMethodName(ByVal methodNamePar As String)
        methodName = methodNamePar
    End Sub

    Public Function getId() As String
        Return id
    End Function

    Public Function getName() As String
        Return name
    End Function

    Public Function getClassName() As String
        Return className
    End Function

    Public Function getMethodName() As String
        Return methodName
    End Function

End Class
