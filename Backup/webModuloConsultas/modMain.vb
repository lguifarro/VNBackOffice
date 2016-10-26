Imports System.Text
Imports System.IO
Module modMain

    Public Enum enTipoUsuario
        iEmpresa = 1
        iComercio = 2
        iVisaNet = 3
    End Enum
    Public Const iResultOK As Integer = 0
    Public Const iResultError As Integer = -1
    Public Const iMaxRegistros As Integer = 10000

    Public Const sEstadoActivo As String = "A"
    Public Const sEstadoInactivo As String = "I"
    Public Const sFlagInactivo As String = "0"
    Public Const sFlagActivo As String = "1"
    Public Const sSexoMasculino As String = "M"
    Public Const sSexoFemenino As String = "F"

    Public Const sMonedaSol As String = "S"
    Public Const sMonedaDol As String = "D"
    Public Const sTipoCalculoFijo As String = "U"
    Public Const sTipoCalculoVariable As String = "V"

    Public Const sOpcionAlta As String = "A"
    Public Const sOpcionBaja As String = "R"
    Public Const sSeparador As String = " - "

    Public Const indexSoles As Integer = 0
    Public Const indexDolares As Integer = 1
    Public Const indexUnico As Integer = 0
    Public Const indexVariable As Integer = 1
    Public Const indexActivo As Integer = 0
    Public Const indexInactivo As Integer = 1
    Public Const indexMasculino As Integer = 0
    Public Const indexFemenino As Integer = 1
    Public Const indexCOMConsulta As Integer = 0
    Public Const indexCOMAdmin As Integer = 1

    Public Const sTodos As String = "TODOS"
    Public Const sMinFecha As String = "01/01/1990"
    Public Const sMaxFecha As String = "31/12/2020"
    Public Const dMinFecha As Date = #1/1/1990#
    Public Const dMaxFecha As Date = #12/31/2020#
    Public Const sTiempoRefreshDefault = "30"

    'variables de sesion
    Public Const SES_USUARIO As String = "UsuarioSesion"
    Public Const SES_CONN As String = "ConexionActiva"

    Public Const SES_IDEMPRESA As String = "IDEMPRESA"
    Public Const SES_IDGRUPO As String = "IDGRUPO"
    Public Const SES_LISTSERVICIO As String = "LISTSERVICIO"
    Public Const SES_LISTEMPRESA As String = "LISTEMPRESA"
    Public Const SES_LISTCOLUMNAS As String = "LISTCOLUMNAS"
    Public Const SES_QUERY As String = "QUERY"
    Public Const SES_FILTROS As String = "FLTROS"
    Public Const SES_ESTADOS As String = "ESTADOS"
    Public Const SES_FILTROS_ESP As String = "FLTROSESPECIALES"

    'formularios
    Public Const FORM_CONSULTAS As String = "~/frmConsulta.aspx"
    Public Const FORM_CONSULTAS_COM As String = "~/frmConsultaComercio.aspx"
    Public Const FORM_CONSULTAS_VIS As String = "~/frmConsultaVisanet.aspx"
    Public Const FORM_LOGIN As String = "~/frmLogin.aspx"
    Public Const FORM_LOGIN_COM As String = "~/frmLoginComercio.aspx"
    Public Const FORM_LOGIN_VIS As String = "~/frmLoginVisanet.aspx"
    Public Const FORM_MANT_USUARIO_VISANET As String = "frmMANTUsuarioVisanet.aspx"
    Public Const FORM_MANT_USUARIO_COMERCIO As String = "frmMANTUsuarioComercio.aspx"
    Public Const FORM_MANT_EMP_USUARIO_COMERCIO As String = "frmMANTEmpUsuarioComercio.aspx"
    Public Const FORM_MANT_COM_USUARIO_COMERCIO As String = "frmMANTComUsuarioComercio.aspx"
    Public Const FORM_MANT_TARIFA_EMPRESA As String = "frmMANTTarifaEmpresa.aspx"
    Public Const FORM_QRY_USUARIO_VISANET As String = "frmQRYUsuarioVisanet.aspx"
    Public Const FORM_QRY_USUARIO_COMERCIO As String = "frmQRYUsuarioComercio.aspx"
    Public Const FORM_QRY_EMP_USUARIO_COMERCIO As String = "frmQRYEmpUsuarioComercio.aspx"
    Public Const FORM_MANT_GRUPO_COMERCIO As String = "frmMANTGrupoComercio.aspx"
    Public Const FORM_MANT_EMP_GRUPO_COMERCIO As String = "frmMANTEmpGrupoComercio.aspx"
    Public Const FORM_QRY_GRUPO_COMERCIO As String = "frmQRYGrupoComercio.aspx"
    Public Const FORM_QRY_TARIFA_EMPRESA As String = "frmQRYTarifaEmpresa.aspx"
    Public Const FORM_QRY_EMP_GRUPO_COMERCIO As String = "frmQRYEmpGrupoComercio.aspx"
    Public Const FORM_QRY_COM_USUARIO_COMERCIO As String = "frmQRYComUsuarioComercio.aspx"
    'parametros
    Public Const PARAM_ID_USUARIO As String = "idusuario"
    Public Const PARAM_ID_GRUPO As String = "idgrupo"
    Public Const PARAM_OPCION_EDITAR As String = "opcedit"

    'opciones
    Public Const OPC_NUEVO As String = "opcnuevo"
    Public Const OPC_EDITAR As String = "opceditar"
    Public Const OPC_VER As String = "opcver"
    Public Const OPC_RESET_PWD As String = "resetpwd"
    Public Const OPC_TRUE As String = "true"
    Public Const OPC_FALSE As String = "false"
    Public Const OPC_CANCELAR As String = "Cancelar"
    Public Const PARAM_EDITAR As String = "editar"
    Public Const SOLO_ACTIVOS As String = "soloactivos"

    'imagenes
    Public Const imgTipoAlarma As String = "Imagenes/imgTipoAlarma.png"
    Public Const imgComentario As String = "Imagenes/imgComentario.png"
    Public Const imgUsuario As String = "Imagenes/imgUsuario.png"
    Public Const imgCambioEstado As String = "Imagenes/imgEdit.png"
    Public Const imgEliminar As String = "Imagenes/imgEliminar.png"
    Public Const imgDetalle As String = "Imagenes/imgDetalle.png"
    Public Const imgResetPassword As String = "Imagenes/imgPassword.png"
    Public Const imgNuevo As String = "Imagenes/imgNuevo.png"

    'formatos
    Public Const sFormatoFechaHora As String = "dd/MM/yyyy HH:mm:ss"
    Public Const sFormatoFecha As String = "dd/MM/yyyy"

    'otros
    Public Const sRegistrosEncontrados As String = " registros encontrados"
    Public Const sDemasiadosRegistros As String = "La busqueda ha devuelto demasiados registros, por favor refine la busqueda"
    Public Const sNoHayRegistros As String = "No se encontraron registros."

    Public Const scriptBACK = "javascript:history.go(-1); return false;"

    Public Const sCodTODOS = "999"



    Public Sub subLimpiaSesion(ByVal ses As System.Web.SessionState.HttpSessionState)
        ses(SES_USUARIO) = Nothing
        ses(SES_CONN) = Nothing

        ses(SES_LISTSERVICIO) = Nothing
        ses(SES_LISTEMPRESA) = Nothing
        ses(SES_LISTCOLUMNAS) = Nothing
        ses(SES_FILTROS) = Nothing
        ses(SES_FILTROS_ESP) = Nothing
        ses(SES_QUERY) = Nothing
        ses(SES_ESTADOS) = Nothing

    End Sub

    Public Function bValidaUsuarioSesion(ByVal iTipoUsuario As Integer, ByVal SES As System.Web.SessionState.HttpSessionState) As Boolean

        Dim cUsuario As ClsUsuarioSesion
        Dim sMensaje As String = ""


        If SES(SES_USUARIO) Is Nothing Then
            bValidaUsuarioSesion = False
        Else
            cUsuario = SES(SES_USUARIO)
            If iTipoUsuario = cUsuario.getTipoUsuario Then
                bValidaUsuarioSesion = True
            Else
                bValidaUsuarioSesion = False

            End If
        End If

    End Function
    Public Function bValidaUsuarioAdmin(ByVal SES As System.Web.SessionState.HttpSessionState) As Boolean

        Dim cUsuario As ClsUsuarioSesion
        Dim sMensaje As String = ""


        If SES(SES_USUARIO) Is Nothing Then
            bValidaUsuarioAdmin = False
        Else
            cUsuario = SES(SES_USUARIO)
            If cUsuario.getFlagAdmin = 1 Then
                bValidaUsuarioAdmin = True
            Else
                bValidaUsuarioAdmin = False

            End If
        End If

    End Function

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
