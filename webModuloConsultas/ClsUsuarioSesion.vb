Public Class ClsUsuarioSesion

    Private iTipoUsuario As Integer
    Private sNomLoginUsuario As String
    Private sNombreUsuario As String
    Private sApellidoP As String
    Private sApellidoM As String
    'Private dFechaNac As Date
    'Private sDNI As String
    'Private sIdTipoUsuario As String
    Private IdComercio As Integer
    Private NombreComercio As String
    Private CodigoComercioNucleo As String
    Private IdGrupo As Integer
    Private NombreGrupo As String
    Private NivelUsuario As Integer
    Private sEmailUsuario As String
    Private FlagAdmin As Integer

    'Private sEstadoUsuario As String
    Private IdUsuario As Integer

    Public Function getIdUsuario() As Integer
        Return IdUsuario
    End Function
    Public Function getFlagAdmin() As Integer
        Return FlagAdmin
    End Function
    Public Function getLoginUsuario() As String
        Return sNomLoginUsuario
    End Function
    Public Function getIdComercio() As Integer
        Return IdComercio
    End Function
    Public Function getNombreComercio() As String
        Return NombreComercio
    End Function
    Public Function getNombreGrupo() As String
        Return NombreGrupo
    End Function
    Public Function getIdGrupo() As Integer
        Return IdGrupo
    End Function
    Public Function getNivelUsuario() As Integer
        Return NivelUsuario
    End Function
    Public Function getNombreUsuario() As String
        Return sNombreUsuario
    End Function
    Public Function getApPaternoUsuario() As String
        Return sApellidoP
    End Function
    Public Function getEmailUsuario() As String
        Return sEmailUsuario
    End Function
    Public Function getTipoUsuario() As Integer
        Return iTipoUsuario
    End Function
    Public Function sCreaSesion(ByVal sLogin As String, ByVal sNombre As String, ByVal sAP As String, ByVal sAM As String, _
                                ByVal iIdComercio As Integer, ByVal sCodComercio As String, ByVal sNomComercio As String, _
                                ByVal sIDUsuario As String) As Integer

        sNomLoginUsuario = sLogin
        sNombreUsuario = sNombre
        sApellidoP = sAP
        sApellidoM = sAM
        IdComercio = iIdComercio
        NombreComercio = sNomComercio
        CodigoComercioNucleo = sCodComercio
        IdUsuario = sIDUsuario

        iTipoUsuario = enTipoUsuario.iEmpresa
        Return 0

    End Function
    Public Function sCreaSesionComercio(ByVal sLogin As String, ByVal sNombre As String, ByVal sAP As String, _
                        ByVal iIDUsuario As Integer, ByVal iIdGrupo As Integer, ByVal sNombreGrupo As String, ByVal iFlagAdmin As Integer) As Integer

        sNomLoginUsuario = sLogin
        sNombreUsuario = sNombre
        sApellidoP = sAP
        IdUsuario = iIDUsuario
        IdGrupo = iIdGrupo
        NombreGrupo = sNombreGrupo
        FlagAdmin = iFlagAdmin

        iTipoUsuario = enTipoUsuario.iComercio
        Return 0

    End Function
    Public Function sCreaSesionVisaNet(ByVal sLogin As String, ByVal sNombre As String, ByVal sAP As String, _
                    ByVal iIDUsuario As Integer, ByVal iNivel As Integer, ByVal semail As String) As Integer

        sNomLoginUsuario = sLogin
        sNombreUsuario = sNombre
        sApellidoP = sAP
        IdUsuario = iIDUsuario
        NivelUsuario = iNivel

        sEmailUsuario = semail
        iTipoUsuario = enTipoUsuario.iVisaNet
        Return 0

    End Function
End Class
