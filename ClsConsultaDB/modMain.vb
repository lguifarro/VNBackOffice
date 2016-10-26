Imports System.Text
Imports System.IO

Module modMain

    Public Const iResultOK As Integer = 0
    Public Const iResultError As Integer = -1

    Public Sub subGuardaLog(ByVal sPath As String, ByVal sXMLResponse As String)

        Dim sYear As String = DateTime.Now.Year.ToString()
        Dim sMonth As String = Microsoft.VisualBasic.Right("00" & DateTime.Now.Month.ToString(), 2)
        Dim sDay As String = Microsoft.VisualBasic.Right("00" & DateTime.Now.Day.ToString(), 2)
        Dim sFechaFile As String = sYear & sMonth & sDay

        If IsNothing(sXMLResponse) Then sXMLResponse = "NULL"

        Dim w As StreamWriter

        Try
            w = File.AppendText(sPath & "LogAnalisis" & sFechaFile & ".txt")

            w.WriteLine("-------------------------------")
            w.WriteLine("Cadena recibida: ")
            w.WriteLine("{0}", DateTime.Now.ToLongTimeString)
            'w.WriteLine("  :")
            w.WriteLine(sXMLResponse)
            w.WriteLine("-------------------------------")
            ' Update the underlying file.
            w.Flush()
            ' Close the writer and underlying file.
            w.Close()

        Catch ex As Exception

        End Try

    End Sub
End Module
