Imports IBM.Data.DB2
Module modDB
    Public gCN As DB2Connection
    Public Const maxTOutQuery As Integer = 60

    Public Const TODO_OK = "00"
    'mensajes de error
    Public Const ERRCN_NO_DB As String = "No hay conexión con la base de datos"


    Public Function VerificaConexion(ByRef con As DB2Connection, ByRef sErrorResp As String) As Integer

        Try
            If con Is Nothing Then
                con = New DB2Connection

            End If

            If con.State = ConnectionState.Open Then
                VerificaConexion = 0
            Else
                CierraConexion(con)
                If Conexion(con, sErrorResp) <> 0 Then
                    VerificaConexion = -1
                Else
                    VerificaConexion = 0
                End If
            End If

            Exit Function
        Catch ex As Exception
            VerificaConexion = iResultError
            sErrorResp = ex.Message
        End Try


    End Function
    Public Sub CierraConexion(ByRef con As DB2Connection)
        On Error Resume Next

        con.Close()
        con = Nothing

    End Sub

    Public Function Conexion(ByRef con As DB2Connection, ByRef sErrorResp As String) As Integer

        Dim sCadenaConex As String
        Dim sError As String = ""

        sCadenaConex = sArmaCadenaConex()

        Try

            con = New DB2Connection(sCadenaConex)
            con.Open()
            'On Error GoTo TrataError
            'With con
            '    .ConnectionString = sCadenaConex
            '    .Open()
            'End With
            Conexion = 0

        Catch ex As Exception
            Conexion = -1

            sErrorResp = ex.Message
            sError = sErrorResp

        End Try


    End Function
    Public Function sArmaCadenaConex() As String
        sArmaCadenaConex = System.Configuration.ConfigurationSettings.AppSettings("sCadenaConex")
    End Function
End Module
