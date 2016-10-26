Imports IBM.Data.DB2

Public Class ClsConsultaDB

    Public Function fLoginUsuario(ByVal CN As DB2Connection, ByVal sCodComercio As String, _
                              ByVal sLogin As String, ByVal sPassword As String, _
                           ByRef sIdUsuario As String, ByRef iIdComercio As Integer, ByRef sNomComercio As String, _
                          ByRef sCR As String, ByRef sMensaje As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spLOGINWeb", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pCodComercioNucleo As New DB2Parameter("PCODCOMERCIO", IBM.Data.DB2.DB2Type.VarChar, lenCodComercioNucleo)
        pCodComercioNucleo.Value = sCodComercio
        pCodComercioNucleo.Direction = System.Data.ParameterDirection.Input

        Dim pLoginUsuario As New DB2Parameter("PUSUARIOLOGIN", IBM.Data.DB2.DB2Type.VarChar, lenUsuario)
        pLoginUsuario.Value = sLogin
        pLoginUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pPasswordUsuario As New DB2Parameter("PPASWORD", IBM.Data.DB2.DB2Type.VarChar, lenPassword)
        pPasswordUsuario.Value = sPassword
        pPasswordUsuario.Direction = System.Data.ParameterDirection.Input


        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenUsuario)
        pIdUsuario.Direction = System.Data.ParameterDirection.Output

        Dim pIdComercio As New DB2Parameter("PIDCOMERCIO", IBM.Data.DB2.DB2Type.Integer)
        pIdComercio.Direction = System.Data.ParameterDirection.Output

        Dim pNomComercio As New DB2Parameter("PNOMCOMERCIO", IBM.Data.DB2.DB2Type.VarChar, lenNomComercio)
        pNomComercio.Direction = System.Data.ParameterDirection.Output

        Dim pTipoUsuario As New DB2Parameter("PTIPOUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenTipoUsuario)
        pTipoUsuario.Direction = System.Data.ParameterDirection.Output

        Dim pCR As New DB2Parameter("CR", IBM.Data.DB2.DB2Type.VarChar, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pMensaje As New DB2Parameter("PMENSAJE", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pMensaje.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pCodComercioNucleo)
        com.Parameters.Add(pLoginUsuario)
        com.Parameters.Add(pPasswordUsuario)
        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pIdComercio)
        com.Parameters.Add(pNomComercio)
        com.Parameters.Add(pTipoUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pMensaje)

        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pIdUsuario.Value)) Then sIdUsuario = pIdUsuario.Value
        If Not (IsDBNull(pIdComercio.Value)) Then iIdComercio = pIdComercio.Value
        If Not (IsDBNull(pNomComercio.Value)) Then sNomComercio = pNomComercio.Value

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pMensaje.Value)) Then sMensaje = pMensaje.Value

        Return iResultOK

    End Function
    Public Function fLoginComercio(ByVal CN As DB2Connection, _
                              ByVal sLogin As String, ByVal sPassword As String, _
                           ByRef iIdUsuario As Integer, ByRef iIdGrupo As Integer, ByRef sNomGrupo As String, _
                          ByRef iFlagAdmin As Integer, ByRef sCR As String, ByRef sMensaje As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spLOGINWebComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pLoginUsuario As New DB2Parameter("PUSUARIOLOGIN", IBM.Data.DB2.DB2Type.VarChar, lenUsuario)
        pLoginUsuario.Value = sLogin
        pLoginUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pPasswordUsuario As New DB2Parameter("PPASWORD", IBM.Data.DB2.DB2Type.VarChar, lenPassword)
        pPasswordUsuario.Value = sPassword
        pPasswordUsuario.Direction = System.Data.ParameterDirection.Input


        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Output

        Dim pIdGrupo As New DB2Parameter("PIDGRUPO", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupo.Direction = System.Data.ParameterDirection.Output

        Dim pNomGrupo As New DB2Parameter("PNOMGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenNombreGrupo)
        pNomGrupo.Direction = System.Data.ParameterDirection.Output

        Dim pFlagAdmin As New DB2Parameter("PFLAGADMIN", IBM.Data.DB2.DB2Type.Integer)
        pFlagAdmin.Direction = System.Data.ParameterDirection.Output

        Dim pCR As New DB2Parameter("CR", IBM.Data.DB2.DB2Type.VarChar, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pMensaje As New DB2Parameter("PMENSAJE", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pMensaje.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pLoginUsuario)
        com.Parameters.Add(pPasswordUsuario)
        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pIdGrupo)
        com.Parameters.Add(pNomGrupo)
        com.Parameters.Add(pFlagAdmin)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pMensaje)

        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pIdUsuario.Value)) Then iIdUsuario = pIdUsuario.Value
        If Not (IsDBNull(pIdGrupo.Value)) Then iIdGrupo = pIdGrupo.Value
        If Not (IsDBNull(pNomGrupo.Value)) Then sNomGrupo = pNomGrupo.Value
        If Not (IsDBNull(pFlagAdmin.Value)) Then iflagadmin = pFlagAdmin.Value

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pMensaje.Value)) Then sMensaje = pMensaje.Value

        Return iResultOK

    End Function
    Public Function fLoginVisanet(ByVal CN As DB2Connection, _
                              ByVal sLogin As String, ByVal sPassword As String, _
                           ByRef iIdUsuario As Integer, ByRef iNivelUsuario As Integer, _
                           ByRef sNombreUsuario As String, ByRef sAPaterno As String, ByRef sEmail As String, _
                          ByRef sCR As String, ByRef sMensaje As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spLOGINWebVisanet", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pLoginUsuario As New DB2Parameter("PUSUARIOLOGIN", IBM.Data.DB2.DB2Type.VarChar, lenUsuario)
        pLoginUsuario.Value = sLogin
        pLoginUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pPasswordUsuario As New DB2Parameter("PPASWORD", IBM.Data.DB2.DB2Type.VarChar, lenPassword)
        pPasswordUsuario.Value = sPassword
        pPasswordUsuario.Direction = System.Data.ParameterDirection.Input


        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Output

        Dim pNivelUsuario As New DB2Parameter("PNIVEL", IBM.Data.DB2.DB2Type.Integer)
        pNivelUsuario.Direction = System.Data.ParameterDirection.Output

        Dim pNombreUsuario As New DB2Parameter("PNOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombre)
        pNombreUsuario.Direction = System.Data.ParameterDirection.Output

        Dim pAPaterno As New DB2Parameter("PAPATERNO", IBM.Data.DB2.DB2Type.VarChar, lenApellido)
        pAPaterno.Direction = System.Data.ParameterDirection.Output

        Dim pEmail As New DB2Parameter("PEMAIL", IBM.Data.DB2.DB2Type.VarChar, lenEmail)
        pEmail.Direction = System.Data.ParameterDirection.Output

        Dim pCR As New DB2Parameter("CR", IBM.Data.DB2.DB2Type.VarChar, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pMensaje As New DB2Parameter("PMENSAJE", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pMensaje.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pLoginUsuario)
        com.Parameters.Add(pPasswordUsuario)
        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pNivelUsuario)
        com.Parameters.Add(pNombreUsuario)
        com.Parameters.Add(pAPaterno)
        com.Parameters.Add(pEmail)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pMensaje)

        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pIdUsuario.Value)) Then iIdUsuario = pIdUsuario.Value
        If Not (IsDBNull(pNivelUsuario.Value)) Then iNivelUsuario = pNivelUsuario.Value
        If Not (IsDBNull(pNombreUsuario.Value)) Then sNombreUsuario = pNombreUsuario.Value
        If Not (IsDBNull(pAPaterno.Value)) Then sAPaterno = pAPaterno.Value
        If Not (IsDBNull(pEmail.Value)) Then sEmail = pEmail.Value

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pMensaje.Value)) Then sMensaje = pMensaje.Value

        Return iResultOK

    End Function

    Public Function spQRYUsuarioVisanet(ByVal CN As DB2Connection, _
                                     ByVal iIdUsuarioBusca As Integer, _
                                     ByVal sLogin As String, _
                                     ByVal sNombre As String, _
                                     ByVal sApellidoP As String, _
                                     ByVal sEmail As String, _
                                    ByVal iNivel As Integer, _
                                     ByVal iIdUsuario As Integer, _
                                    ByRef sCR As String, _
                                    ByRef sDescError As String) As DataSet


        Dim com As New DB2Command
        Dim ds As New DataSet

        com = New DB2Command("SQMNUC.spQRYUsuarioVisanet", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdUsuarioBusca As New DB2Parameter("PIDUSUARIOBUSCA", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuarioBusca.Direction = System.Data.ParameterDirection.Input
        pIdUsuarioBusca.Value = iIdUsuarioBusca

        Dim pLogin As New DB2Parameter("PLOGINUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenLogin)
        pLogin.Direction = System.Data.ParameterDirection.Input
        pLogin.Value = sLogin

        Dim pNombre As New DB2Parameter("PNOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombre)
        pNombre.Direction = System.Data.ParameterDirection.Input
        pNombre.Value = sNombre

        Dim pApellidoP As New DB2Parameter("PAPATERNO", IBM.Data.DB2.DB2Type.VarChar, lenApellido)
        pApellidoP.Direction = System.Data.ParameterDirection.Input
        pApellidoP.Value = sApellidoP

        Dim pEmail As New DB2Parameter("PEMAIL", IBM.Data.DB2.DB2Type.VarChar, lenEmail)
        pEmail.Direction = System.Data.ParameterDirection.Input
        pEmail.Value = sEmail

        Dim pNivel As New DB2Parameter("PNIVEL", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuarioBusca.Direction = System.Data.ParameterDirection.Input
        pIdUsuarioBusca.Value = iNivel

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PMENSAJE", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdUsuarioBusca)
        com.Parameters.Add(pLogin)
        com.Parameters.Add(pNombre)
        com.Parameters.Add(pApellidoP)
        com.Parameters.Add(pEmail)
        com.Parameters.Add(pNivel)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        Dim da As New DB2DataAdapter
        da.SelectCommand = com
        da.Fill(ds)

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return ds

    End Function

    Public Function spQRYUsuarioComercio(ByVal CN As DB2Connection, _
                                     ByVal iIdUsuarioBusca As Integer, _
                                     ByVal sLogin As String, _
                                     ByVal sNombre As String, _
                                     ByVal sApellidoP As String, _
                                     ByVal sEmail As String, _
                                    ByVal iGrupo As Integer, _
                                    ByVal iCmcioId As Integer, _
                                     ByVal iIdUsuario As Integer, _
                                    ByRef sCR As String, _
                                    ByRef sDescError As String) As DataSet


        Dim com As New DB2Command
        Dim ds As New DataSet

        com = New DB2Command("SQMNUC.spQRYUsuarioComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdUsuarioBusca As New DB2Parameter("PIDUSUARIOBUSCA", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuarioBusca.Direction = System.Data.ParameterDirection.Input
        pIdUsuarioBusca.Value = iIdUsuarioBusca

        Dim pLogin As New DB2Parameter("PLOGINUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenLogin)
        pLogin.Direction = System.Data.ParameterDirection.Input
        pLogin.Value = sLogin

        Dim pNombre As New DB2Parameter("PNOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombre)
        pNombre.Direction = System.Data.ParameterDirection.Input
        pNombre.Value = sNombre

        Dim pApellidoP As New DB2Parameter("PAPATERNO", IBM.Data.DB2.DB2Type.VarChar, lenApellido)
        pApellidoP.Direction = System.Data.ParameterDirection.Input
        pApellidoP.Value = sApellidoP

        Dim pEmail As New DB2Parameter("PEMAIL", IBM.Data.DB2.DB2Type.VarChar, lenEmail)
        pEmail.Direction = System.Data.ParameterDirection.Input
        pEmail.Value = sEmail

        Dim pIdGrupo As New DB2Parameter("PIDGRUPO", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupo.Direction = System.Data.ParameterDirection.Input
        pIdGrupo.Value = iGrupo

        Dim pCmcioId As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pCmcioId.Direction = System.Data.ParameterDirection.Input
        pCmcioId.Value = iCmcioId

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PMENSAJE", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdUsuarioBusca)
        com.Parameters.Add(pLogin)
        com.Parameters.Add(pNombre)
        com.Parameters.Add(pApellidoP)
        com.Parameters.Add(pEmail)
        com.Parameters.Add(pIdGrupo)
        com.Parameters.Add(pCmcioId)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        Dim da As New DB2DataAdapter
        da.SelectCommand = com
        da.Fill(ds)

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return ds

    End Function
    
    Public Function spQRYServicio(ByVal CN As DB2Connection, _
                                     ByVal iIdServicio As Integer, _
                                     ByVal sNomServicio As String, _
                                     ByVal iEstado As Integer, _
                                     ByVal iIdUsuario As Integer, _
                                    ByRef sCR As String, _
                                    ByRef sDescError As String) As DataSet


        Dim com As New DB2Command
        Dim ds As New DataSet

        com = New DB2Command("SQMNUC.spQRYServicio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdServicio As New DB2Parameter("PIDSERVICIO", IBM.Data.DB2.DB2Type.Integer)
        pIdServicio.Direction = System.Data.ParameterDirection.Input
        pIdServicio.Value = iIdServicio

        Dim pNomServicio As New DB2Parameter("PNOMSERVICIO", IBM.Data.DB2.DB2Type.VarChar, lenNomServicio)
        pNomServicio.Direction = System.Data.ParameterDirection.Input
        pNomServicio.Value = sNomServicio

        Dim pEstadoServicio As New DB2Parameter("PESTADOSERVICIO", IBM.Data.DB2.DB2Type.Integer)
        pEstadoServicio.Direction = System.Data.ParameterDirection.Input
        pEstadoServicio.Value = iEstado

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdServicio)
        com.Parameters.Add(pNomServicio)
        com.Parameters.Add(pEstadoServicio)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        Dim da As New DB2DataAdapter
        da.SelectCommand = com
        da.Fill(ds)

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return ds

    End Function
    Public Function spQRYServicioConsulta(ByVal CN As DB2Connection, _
                                     ByVal iIdGrupoConsulta As Integer, _
                                     ByVal iIdServicio As Integer, _
                                     ByVal sNomServicio As String, _
                                     ByVal iEstado As Integer, _
                                     ByVal iIdUsuario As Integer, _
                                    ByRef sCR As String, _
                                    ByRef sDescError As String) As DataSet


        Dim com As New DB2Command
        Dim ds As New DataSet

        com = New DB2Command("SQMNUC.spQRYServicioConsulta", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdUsuarioConsulta As New DB2Parameter("PIDGRUPOCONSULTA", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuarioConsulta.Direction = System.Data.ParameterDirection.Input
        pIdUsuarioConsulta.Value = iIdGrupoConsulta

        Dim pIdServicio As New DB2Parameter("PIDSERVICIO", IBM.Data.DB2.DB2Type.Integer)
        pIdServicio.Direction = System.Data.ParameterDirection.Input
        pIdServicio.Value = iIdServicio

        Dim pNomServicio As New DB2Parameter("PNOMSERVICIO", IBM.Data.DB2.DB2Type.VarChar, lenNomServicio)
        pNomServicio.Direction = System.Data.ParameterDirection.Input
        pNomServicio.Value = sNomServicio

        Dim pEstadoServicio As New DB2Parameter("PESTADOSERVICIO", IBM.Data.DB2.DB2Type.Integer)
        pEstadoServicio.Direction = System.Data.ParameterDirection.Input
        pEstadoServicio.Value = iEstado

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdUsuarioConsulta)
        com.Parameters.Add(pIdServicio)
        com.Parameters.Add(pNomServicio)
        com.Parameters.Add(pEstadoServicio)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        Dim da As New DB2DataAdapter
        da.SelectCommand = com
        da.Fill(ds)

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return ds

    End Function
    Public Function spQRYServicioEmpresa(ByVal CN As DB2Connection, _
                                     ByVal iIdServicio As Integer, _
                                     ByVal iCmcioId As Integer, _
                                     ByVal sNomServicio As String, _
                                     ByVal iIdUsuario As Integer, _
                                    ByRef sCR As String, _
                                    ByRef sDescError As String) As DataSet


        Dim com As New DB2Command
        Dim ds As New DataSet

        com = New DB2Command("SQMNUC.spQRYServicioEmpresa", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdServicio As New DB2Parameter("PIDSERVICIO", IBM.Data.DB2.DB2Type.Integer)
        pIdServicio.Direction = System.Data.ParameterDirection.Input
        pIdServicio.Value = iIdServicio

        Dim pIdEmpresa As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pIdEmpresa.Direction = System.Data.ParameterDirection.Input
        pIdEmpresa.Value = iCmcioId

        Dim pNomServicio As New DB2Parameter("PNOMSERVICIO", IBM.Data.DB2.DB2Type.VarChar, lenNomServicio)
        pNomServicio.Direction = System.Data.ParameterDirection.Input
        pNomServicio.Value = sNomServicio

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdServicio)
        com.Parameters.Add(pIdEmpresa)
        com.Parameters.Add(pNomServicio)
        
        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        Dim da As New DB2DataAdapter
        da.SelectCommand = com
        da.Fill(ds)

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return ds

    End Function
    Public Function spQRYRangoTarifaEmpresa(ByVal CN As DB2Connection, _
                                    ByVal iCmcioId As Integer, _
                                    ByVal iIdServicio As Integer, _
                                    ByVal iIdUsuario As Integer, _
                                   ByRef sCR As String, _
                                   ByRef sDescError As String) As DataSet


        Dim com As New DB2Command
        Dim ds As New DataSet
        Dim SSQL As String

        com = New DB2Command("SQMNUC.spQRYRangoTarifaEmpresa", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdEmpresa As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pIdEmpresa.Direction = System.Data.ParameterDirection.Input
        pIdEmpresa.Value = iCmcioId

        Dim pIdServicio As New DB2Parameter("PIDSERVICIO", IBM.Data.DB2.DB2Type.Integer)
        pIdServicio.Direction = System.Data.ParameterDirection.Input
        pIdServicio.Value = iIdServicio

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pSQL As New DB2Parameter("PSQL", IBM.Data.DB2.DB2Type.VarChar, 1000)
        pSQL.Direction = System.Data.ParameterDirection.Output

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdEmpresa)
        com.Parameters.Add(pIdServicio)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pSQL)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        Dim da As New DB2DataAdapter
        da.SelectCommand = com
        da.Fill(ds)

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value
        If Not (IsDBNull(pSQL.Value)) Then SSQL = pSQL.Value

        Return ds

    End Function
    Public Function spMANTUpdateTarifaEmpresa(ByVal CN As DB2Connection, _
                                    ByVal iCmcioId As Integer, _
                                    ByVal sMoneda As String, _
                                    ByVal sTipoCalculo As String, _
                                    ByVal iIdUsuario As Integer, _
                                   ByRef sCR As String, _
                                   ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        'Dim ds As New DataSet
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTUpdateTarifaEmpresa", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdEmpresa As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pIdEmpresa.Direction = System.Data.ParameterDirection.Input
        pIdEmpresa.Value = iCmcioId

        Dim pMoneda As New DB2Parameter("PMONEDA", IBM.Data.DB2.DB2Type.VarChar, lenMoneda)
        pMoneda.Direction = System.Data.ParameterDirection.Input
        pMoneda.Value = sMoneda

        Dim pTipoCalculo As New DB2Parameter("PTIPOCALCULO", IBM.Data.DB2.DB2Type.VarChar, lenTipoCalculo)
        pTipoCalculo.Direction = System.Data.ParameterDirection.Input
        pTipoCalculo.Value = sTipoCalculo

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdEmpresa)
        com.Parameters.Add(pMoneda)
        com.Parameters.Add(pTipoCalculo)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        'Dim da As New DB2DataAdapter
        'da.SelectCommand = com
        'da.Fill(ds)

        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResp

    End Function
    Public Function spMANTInsertRangoTarifa(ByVal CN As DB2Connection, _
                                    ByVal iCmcioId As Integer, _
                                    ByVal lDesde As Long, _
                                    ByVal lHasta As Long, _
                                    ByVal dTarifa As Double, _
                                    ByVal iIdUsuario As Integer, _
                                   ByRef sCR As String, _
                                   ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        'Dim ds As New DataSet
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTInsertRangoTarifa", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdEmpresa As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pIdEmpresa.Direction = System.Data.ParameterDirection.Input
        pIdEmpresa.Value = iCmcioId

        Dim pDesde As New DB2Parameter("PDESDE", IBM.Data.DB2.DB2Type.BigInt)
        pDesde.Direction = System.Data.ParameterDirection.Input
        pDesde.Value = lDesde

        Dim pHasta As New DB2Parameter("PHASTA", IBM.Data.DB2.DB2Type.BigInt)
        pHasta.Direction = System.Data.ParameterDirection.Input
        pHasta.Value = lHasta

        Dim pTarifa As New DB2Parameter("PTARIFA", IBM.Data.DB2.DB2Type.Double)
        pTarifa.Direction = System.Data.ParameterDirection.Input
        pTarifa.Value = dTarifa


        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdEmpresa)
        com.Parameters.Add(pDesde)
        com.Parameters.Add(pHasta)
        com.Parameters.Add(pTarifa)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        'Dim da As New DB2DataAdapter
        'da.SelectCommand = com
        'da.Fill(ds)

        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        If sCR = TODO_OK Then
            iResp = iResultOK
        Else
            iResp = iResultError
        End If
        Return iResp

    End Function
    Public Function spMANTUpdateRangoTarifa(ByVal CN As DB2Connection, _
                                    ByVal iIdTarifa As Integer, _
                                    ByVal iCmcioId As Integer, _
                                    ByVal lDesde As Long, _
                                    ByVal lHasta As Long, _
                                    ByVal dTarifa As Double, _
                                    ByVal iIdUsuario As Integer, _
                                   ByRef sCR As String, _
                                   ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        'Dim ds As New DataSet
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTInsertRangoTarifa", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdTarifa As New DB2Parameter("IDTARIFA", IBM.Data.DB2.DB2Type.Integer)
        pIdTarifa.Direction = System.Data.ParameterDirection.Input
        pIdTarifa.Value = iCmcioId

        Dim pIdEmpresa As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pIdEmpresa.Direction = System.Data.ParameterDirection.Input
        pIdEmpresa.Value = iCmcioId

        Dim pDesde As New DB2Parameter("PDESDE", IBM.Data.DB2.DB2Type.BigInt)
        pDesde.Direction = System.Data.ParameterDirection.Input
        pDesde.Value = iCmcioId

        Dim pHasta As New DB2Parameter("PHASTA", IBM.Data.DB2.DB2Type.BigInt)
        pHasta.Direction = System.Data.ParameterDirection.Input
        pHasta.Value = iCmcioId

        Dim pTarifa As New DB2Parameter("PTARIFA", IBM.Data.DB2.DB2Type.Double)
        pTarifa.Direction = System.Data.ParameterDirection.Input
        pTarifa.Value = dTarifa


        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdTarifa)
        com.Parameters.Add(pIdEmpresa)
        com.Parameters.Add(pDesde)
        com.Parameters.Add(pHasta)
        com.Parameters.Add(pTarifa)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        'Dim da As New DB2DataAdapter
        'da.SelectCommand = com
        'da.Fill(ds)

        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResp

    End Function
    Public Function spQRYComercioConsulta(ByVal CN As DB2Connection, _
                                     ByVal iIdGrupoConsulta As Integer, _
                                     ByVal sCodComercio As String, _
                                     ByVal iIdUsuario As Integer, _
                                    ByRef sCR As String, _
                                    ByRef sDescError As String) As DataSet


        Dim com As New DB2Command
        Dim ds As New DataSet

        com = New DB2Command("SQMNUC.spQRYComercioConsulta", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdGrupoConsulta As New DB2Parameter("PIDGRUPOCONSULTA", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupoConsulta.Direction = System.Data.ParameterDirection.Input
        pIdGrupoConsulta.Value = iIdGrupoConsulta

        Dim pCodComercio As New DB2Parameter("PCODCOMERCIO", IBM.Data.DB2.DB2Type.VarChar, lenCodComercio)
        pCodComercio.Direction = System.Data.ParameterDirection.Input
        pCodComercio.Value = sCodComercio

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdGrupoConsulta)
        com.Parameters.Add(pCodComercio)
        
        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        Dim da As New DB2DataAdapter
        da.SelectCommand = com
        da.Fill(ds)

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return ds

    End Function
    Public Function spQRYEmpresa(ByVal CN As DB2Connection, _
                                     ByVal iCmcioId As Integer, _
                                     ByVal sNomComercio As String, _
                                     ByVal sEstado As String, _
                                     ByVal iIdServicio As Integer, _
                                     ByVal iIdUsuario As Integer, _
                                    ByRef sCR As String, _
                                    ByRef sDescError As String) As DataSet


        Dim com As New DB2Command
        Dim ds As New DataSet

        com = New DB2Command("SQMNUC.spQRYEmpresa", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdComercio As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pIdComercio.Direction = System.Data.ParameterDirection.Input
        pIdComercio.Value = iCmcioId

        Dim pNomComercio As New DB2Parameter("PNOMCOMERCIO", IBM.Data.DB2.DB2Type.VarChar, lenNomComercio)
        pNomComercio.Direction = System.Data.ParameterDirection.Input
        pNomComercio.Value = sNomComercio

        Dim pEstadoComercio As New DB2Parameter("PESTADOCOMERCIO", IBM.Data.DB2.DB2Type.VarChar, lenEstado)
        pEstadoComercio.Direction = System.Data.ParameterDirection.Input
        pEstadoComercio.Value = sEstado

        Dim pIdServicio As New DB2Parameter("PIDSERVICIO", IBM.Data.DB2.DB2Type.Integer)
        pIdServicio.Direction = System.Data.ParameterDirection.Input
        pIdServicio.Value = iIdServicio

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdComercio)
        com.Parameters.Add(pNomComercio)
        com.Parameters.Add(pEstadoComercio)
        com.Parameters.Add(pIdServicio)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        Dim da As New DB2DataAdapter
        da.SelectCommand = com
        da.Fill(ds)

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return ds

    End Function
    Public Function spQRYGrupoComercio(ByVal CN As DB2Connection, _
                                     ByVal iidGrupo As Integer, _
                                     ByVal iCmcioId As Integer, _
                                     ByVal sCodGrupo As String, _
                                     ByVal sNomGrupo As String, _
                                     ByVal iRUC As Long, _
                                     ByVal iFlagRUC As Integer, _
                                     ByVal iIdUsuario As Integer, _
                                    ByRef sCR As String, _
                                    ByRef sDescError As String) As DataSet


        Dim com As New DB2Command
        Dim ds As New DataSet

        com = New DB2Command("SQMNUC.spQRYGrupoComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdGrupo As New DB2Parameter("PIDGRUPO", IBM.Data.DB2.DB2Type.BigInt)
        pIdGrupo.Direction = System.Data.ParameterDirection.Input
        pIdGrupo.Value = iidGrupo

        Dim pCmcioId As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pCmcioId.Direction = System.Data.ParameterDirection.Input
        pCmcioId.Value = iCmcioId

        Dim pCodGrupo As New DB2Parameter("PCODGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenCodGrupo)
        pCodGrupo.Direction = System.Data.ParameterDirection.Input
        pCodGrupo.Value = sCodGrupo

        Dim pNomGrupo As New DB2Parameter("PNOMGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenNomComercio)
        pNomGrupo.Direction = System.Data.ParameterDirection.Input
        pNomGrupo.Value = sNomGrupo

        Dim pFlagRuc As New DB2Parameter("PFLAGRUC", IBM.Data.DB2.DB2Type.Integer)
        pFlagRuc.Direction = System.Data.ParameterDirection.Input
        pFlagRuc.Value = iFlagRUC

        Dim pRUC As New DB2Parameter("PRUC", IBM.Data.DB2.DB2Type.Decimal, lenRUCInt)
        pRUC.Direction = System.Data.ParameterDirection.Input
        pRUC.Value = iRUC

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Direction = System.Data.ParameterDirection.Input
        pIdUsuario.Value = iIdUsuario

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdGrupo)
        com.Parameters.Add(pCmcioId)
        com.Parameters.Add(pCodGrupo)
        com.Parameters.Add(pNomGrupo)
        com.Parameters.Add(pFlagRuc)
        com.Parameters.Add(pRUC)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        Dim da As New DB2DataAdapter
        da.SelectCommand = com
        da.Fill(ds)

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return ds

    End Function
    Public Function spQRYDetalleUsuarioVisanet(ByVal CN As DB2Connection, ByVal iIdUsuarioConsulta As Integer, _
                                      ByRef sLogin As String, _
                                      ByRef sNombre As String, _
                                      ByRef sAPaterno As String, _
                                      ByRef sEmail As String, _
                                      ByRef iNivel As Integer, _
                                      ByRef sEstadoUsuario As String, _
                                      ByRef dFechaInsert As Date, _
                                      ByRef dFechaUltActualiz As Date, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spQRYDetalleUsuarioVisanet", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdUsuarioConsulta As New DB2Parameter("PIDUSUARIOCONSULTA", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuarioConsulta.Value = iIdUsuarioConsulta
        pIdUsuarioConsulta.Direction = System.Data.ParameterDirection.Input

        Dim pLogin As New DB2Parameter("PLOGINUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenLogin)
        pLogin.Direction = System.Data.ParameterDirection.Output

        Dim pNombre As New DB2Parameter("PNOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombre)
        pNombre.Direction = System.Data.ParameterDirection.Output

        Dim pApaterno As New DB2Parameter("PAPELLIDOP", IBM.Data.DB2.DB2Type.VarChar, lenApellido)
        pApaterno.Direction = System.Data.ParameterDirection.Output

        Dim pEmail As New DB2Parameter("PEMAIL", IBM.Data.DB2.DB2Type.VarChar, lenEmail)
        pEmail.Direction = System.Data.ParameterDirection.Output

        Dim pNivel As New DB2Parameter("PNIVEL", IBM.Data.DB2.DB2Type.Integer)
        pNivel.Direction = System.Data.ParameterDirection.Output

        Dim pEstadoUsuario As New DB2Parameter("PESTADOUSUARIO", IBM.Data.DB2.DB2Type.Char, lenEstadoUsuario)
        pEstadoUsuario.Direction = System.Data.ParameterDirection.Output

        Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.Timestamp)
        pFechaInsert.Direction = System.Data.ParameterDirection.Output

        Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.Timestamp)
        pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdUsuarioConsulta)
        com.Parameters.Add(pLogin)
        com.Parameters.Add(pNombre)
        com.Parameters.Add(pApaterno)
        com.Parameters.Add(pEmail)
        com.Parameters.Add(pNivel)
        com.Parameters.Add(pEstadoUsuario)
        com.Parameters.Add(pFechaInsert)
        com.Parameters.Add(pFechaUltActualiz)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        'If Not (IsDBNull(pIdAlarma.Value)) Then sCodComercio = pIdAlarma.Value
        If Not (IsDBNull(pLogin.Value)) Then sLogin = pLogin.Value
        If Not (IsDBNull(pNombre.Value)) Then sNombre = pNombre.Value
        If Not (IsDBNull(pApaterno.Value)) Then sAPaterno = pApaterno.Value
        If Not (IsDBNull(pEmail.Value)) Then sEmail = pEmail.Value
        If Not (IsDBNull(pNivel.Value)) Then iNivel = pNivel.Value
        If Not (IsDBNull(pEstadoUsuario.Value)) Then sEstadoUsuario = pEstadoUsuario.Value
        If Not (IsDBNull(pFechaInsert.Value)) Then dFechaInsert = pFechaInsert.Value
        If Not (IsDBNull(pFechaUltActualiz.Value)) Then dFechaUltActualiz = pFechaUltActualiz.Value


        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spQRYDetalleUsuarioComercio(ByVal CN As DB2Connection, ByVal iIdUsuarioConsulta As Integer, _
                                      ByRef iIdGrupo As Integer, _
                                      ByRef iFlagAdmin As Integer, _
                                      ByRef sLogin As String, _
                                      ByRef sNombre As String, _
                                      ByRef sAPaterno As String, _
                                      ByRef sEmail As String, _
                                      ByRef sEstadoUsuario As String, _
                                      ByRef dFechaInsert As Date, _
                                      ByRef dFechaUltActualiz As Date, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spQRYDetalleUsuarioComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdUsuarioConsulta As New DB2Parameter("PIDUSUARIOCONSULTA", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuarioConsulta.Value = iIdUsuarioConsulta
        pIdUsuarioConsulta.Direction = System.Data.ParameterDirection.Input

        Dim pIdGrupo As New DB2Parameter("PIDGRUPO", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupo.Direction = System.Data.ParameterDirection.Output

        Dim pFlagAdmin As New DB2Parameter("PFLAGADMIN", IBM.Data.DB2.DB2Type.Integer)
        pFlagAdmin.Direction = System.Data.ParameterDirection.Output

        Dim pLogin As New DB2Parameter("PLOGINUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenLogin)
        pLogin.Direction = System.Data.ParameterDirection.Output

        Dim pNombre As New DB2Parameter("PNOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombre)
        pNombre.Direction = System.Data.ParameterDirection.Output

        Dim pApaterno As New DB2Parameter("PAPELLIDOP", IBM.Data.DB2.DB2Type.VarChar, lenApellido)
        pApaterno.Direction = System.Data.ParameterDirection.Output

        Dim pEmail As New DB2Parameter("PEMAIL", IBM.Data.DB2.DB2Type.VarChar, lenEmail)
        pEmail.Direction = System.Data.ParameterDirection.Output

        Dim pEstadoUsuario As New DB2Parameter("PESTADOUSUARIO", IBM.Data.DB2.DB2Type.Char, lenEstadoUsuario)
        pEstadoUsuario.Direction = System.Data.ParameterDirection.Output

        Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.Timestamp)
        pFechaInsert.Direction = System.Data.ParameterDirection.Output

        Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.Timestamp)
        pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdUsuarioConsulta)
        com.Parameters.Add(pIdGrupo)
        com.Parameters.Add(pFlagAdmin)
        com.Parameters.Add(pLogin)
        com.Parameters.Add(pNombre)
        com.Parameters.Add(pApaterno)
        com.Parameters.Add(pEmail)
        com.Parameters.Add(pEstadoUsuario)
        com.Parameters.Add(pFechaInsert)
        com.Parameters.Add(pFechaUltActualiz)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        iResp = com.ExecuteNonQuery

        'If Not (IsDBNull(pIdAlarma.Value)) Then sCodComercio = pIdAlarma.Value
        If Not (IsDBNull(pLogin.Value)) Then sLogin = pLogin.Value
        If Not (IsDBNull(pNombre.Value)) Then sNombre = pNombre.Value
        If Not (IsDBNull(pApaterno.Value)) Then sAPaterno = pApaterno.Value
        If Not (IsDBNull(pEmail.Value)) Then sEmail = pEmail.Value
        If Not (IsDBNull(pIdGrupo.Value)) Then iIdGrupo = pIdGrupo.Value
        If Not (IsDBNull(pFlagAdmin.Value)) Then iFlagAdmin = pFlagAdmin.Value
        If Not (IsDBNull(pEstadoUsuario.Value)) Then sEstadoUsuario = pEstadoUsuario.Value
        If Not (IsDBNull(pFechaInsert.Value)) Then dFechaInsert = pFechaInsert.Value
        If Not (IsDBNull(pFechaUltActualiz.Value)) Then dFechaUltActualiz = pFechaUltActualiz.Value

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spQRYDetalleTarifaEmpresa(ByVal CN As DB2Connection, _
                                      ByRef iCmcioId As Integer, _
                                      ByRef sTipoCalculo As String, _
                                      ByRef sMoneda As String, _
                                      ByRef dFechaInsert As Date, _
                                      ByRef dFechaUltActualiz As Date, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spQRYDetalleTarifaEmpresa", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pCmcioId As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pCmcioId.Value = iCmcioId
        pCmcioId.Direction = System.Data.ParameterDirection.Input

        Dim pTipoCalculo As New DB2Parameter("PTIPOCALCULO", IBM.Data.DB2.DB2Type.VarChar, lenTipoCalculo)
        pTipoCalculo.Direction = System.Data.ParameterDirection.Output

        Dim pMoneda As New DB2Parameter("PMONEDA", IBM.Data.DB2.DB2Type.VarChar, lenMoneda)
        pMoneda.Direction = System.Data.ParameterDirection.Output

        Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.Timestamp)
        pFechaInsert.Direction = System.Data.ParameterDirection.Output

        Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.Timestamp)
        pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pCmcioId)
        com.Parameters.Add(pTipoCalculo)
        com.Parameters.Add(pMoneda)
        com.Parameters.Add(pFechaInsert)
        com.Parameters.Add(pFechaUltActualiz)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)

        iResp = com.ExecuteNonQuery

        'If Not (IsDBNull(pIdAlarma.Value)) Then sCodComercio = pIdAlarma.Value
        If Not (IsDBNull(pCmcioId.Value)) Then iCmcioId = pCmcioId.Value
        If Not (IsDBNull(pTipoCalculo.Value)) Then sTipoCalculo = pTipoCalculo.Value
        If Not (IsDBNull(pMoneda.Value)) Then sMoneda = pMoneda.Value
        If Not (IsDBNull(pFechaInsert.Value)) Then dFechaInsert = pFechaInsert.Value
        If Not (IsDBNull(pFechaUltActualiz.Value)) Then dFechaUltActualiz = pFechaUltActualiz.Value

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spQRYDetalleGrupoComercio(ByVal CN As DB2Connection, _
                                      ByRef iIdGrupoConsulta As Integer, _
                                      ByRef iCmcioId As Integer, _
                                      ByRef sCodgrupo As String, _
                                      ByRef sNomGrupo As String, _
                                      ByRef sCmcioNombre As String, _
                                      ByRef sDescGrupo As String, _
                                      ByRef iFlagRUC As Integer, _
                                      ByRef iRUC As Long, _
                                      ByRef dFechaInsert As Date, _
                                      ByRef dFechaUltActualiz As Date, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spQRYDetalleGrupoComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdGrupoConsulta As New DB2Parameter("PIDGRUPOCONSULTA", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupoConsulta.Value = iIdGrupoConsulta
        pIdGrupoConsulta.Direction = System.Data.ParameterDirection.Input

        Dim pCmcioId As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pCmcioId.Direction = System.Data.ParameterDirection.Output

        Dim pCodGrupo As New DB2Parameter("PCODGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenCodGrupo)
        pCodGrupo.Direction = System.Data.ParameterDirection.Output

        Dim pNomGrupo As New DB2Parameter("PNOMGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenNombreGrupo)
        pNomGrupo.Direction = System.Data.ParameterDirection.Output

        Dim pCmcioNombre As New DB2Parameter("PCMCIONOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombreGrupo)
        pCmcioNombre.Direction = System.Data.ParameterDirection.Output

        Dim pDescGrupo As New DB2Parameter("PDESCGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenDescGrupo)
        pDescGrupo.Direction = System.Data.ParameterDirection.Output

        Dim pFlagRUC As New DB2Parameter("PFLAGRUC", IBM.Data.DB2.DB2Type.Integer)
        pFlagRUC.Direction = System.Data.ParameterDirection.Output

        Dim pRUC As New DB2Parameter("PRUC", IBM.Data.DB2.DB2Type.Decimal, lenRUCInt)
        pRUC.Direction = System.Data.ParameterDirection.Output


        Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.Timestamp)
        pFechaInsert.Direction = System.Data.ParameterDirection.Output

        Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.Timestamp)
        pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdGrupoConsulta)
        com.Parameters.Add(pCmcioId)
        com.Parameters.Add(pCodGrupo)
        com.Parameters.Add(pNomGrupo)
        com.Parameters.Add(pCmcioNombre)
        com.Parameters.Add(pDescGrupo)
        com.Parameters.Add(pFlagRUC)
        com.Parameters.Add(pRUC)
        com.Parameters.Add(pFechaInsert)
        com.Parameters.Add(pFechaUltActualiz)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        'If Not (IsDBNull(pIdAlarma.Value)) Then sCodComercio = pIdAlarma.Value
        If Not (IsDBNull(pIdGrupoConsulta.Value)) Then iIdGrupoConsulta = pIdGrupoConsulta.Value
        If Not (IsDBNull(pCmcioId.Value)) Then iCmcioId = pCmcioId.Value
        If Not (IsDBNull(pCodGrupo.Value)) Then sCodgrupo = pCodGrupo.Value
        If Not (IsDBNull(pNomGrupo.Value)) Then sNomGrupo = pNomGrupo.Value
        If Not (IsDBNull(pCmcioNombre.Value)) Then sCmcioNombre = pCmcioNombre.Value
        If Not (IsDBNull(pDescGrupo.Value)) Then sDescGrupo = pDescGrupo.Value
        If Not (IsDBNull(pFlagRUC.Value)) Then iFlagRUC = pFlagRUC.Value
        If Not (IsDBNull(pRUC.Value)) Then iRUC = pRUC.Value

        If Not (IsDBNull(pFechaInsert.Value)) Then dFechaInsert = pFechaInsert.Value
        If Not (IsDBNull(pFechaUltActualiz.Value)) Then dFechaUltActualiz = pFechaUltActualiz.Value

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spMANTInsertUsuarioVisanet(ByVal CN As DB2Connection, _
                                      ByVal sLogin As String, _
                                      ByVal sPassword As String, _
                                      ByVal sNombre As String, _
                                      ByVal sAPaterno As String, _
                                      ByVal sEmail As String, _
                                      ByVal iNivel As Integer, _
                                      ByVal sEstadoUsuario As String, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTInsertUsuarioVisanet", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pLogin As New DB2Parameter("PLOGINUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenLogin)
        pLogin.Value = sLogin
        pLogin.Direction = System.Data.ParameterDirection.Input

        Dim pPassword As New DB2Parameter("PPWDUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenPassword)
        pPassword.Value = sPassword
        pPassword.Direction = System.Data.ParameterDirection.Input

        Dim pNombre As New DB2Parameter("PNOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombre)
        pNombre.Value = sNombre
        pNombre.Direction = System.Data.ParameterDirection.Input

        Dim pApaterno As New DB2Parameter("PAPELLIDOP", IBM.Data.DB2.DB2Type.VarChar, lenApellido)
        pApaterno.Value = sAPaterno
        pApaterno.Direction = System.Data.ParameterDirection.Input

        Dim pEmail As New DB2Parameter("PEMAIL", IBM.Data.DB2.DB2Type.VarChar, lenEmail)
        pEmail.Value = sEmail
        pEmail.Direction = System.Data.ParameterDirection.Input

        Dim pNivel As New DB2Parameter("PNIVEL", IBM.Data.DB2.DB2Type.Integer)
        pNivel.Value = iNivel
        pNivel.Direction = System.Data.ParameterDirection.Input

        Dim pEstadoUsuario As New DB2Parameter("PESTADOUSUARIO", IBM.Data.DB2.DB2Type.Char, lenEstadoUsuario)
        pEstadoUsuario.Value = sEstadoUsuario
        pEstadoUsuario.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pLogin)
        com.Parameters.Add(pPassword)
        com.Parameters.Add(pNombre)
        com.Parameters.Add(pApaterno)
        com.Parameters.Add(pEmail)
        com.Parameters.Add(pNivel)
        com.Parameters.Add(pEstadoUsuario)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spMANTInsertUsuarioComercio(ByVal CN As DB2Connection, _
                                      ByVal iIdGrupo As Integer, _
                                      ByVal iFlagAdmin As Integer, _
                                      ByVal sLogin As String, _
                                      ByVal sPassword As String, _
                                      ByVal sNombre As String, _
                                      ByVal sAPaterno As String, _
                                      ByVal sEmail As String, _
                                      ByVal sEstadoUsuario As String, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTInsertUsuarioComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdGrupo As New DB2Parameter("PIDGRUPO", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupo.Value = iIdGrupo
        pIdGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pFlagAdmin As New DB2Parameter("PFLAGADMIN", IBM.Data.DB2.DB2Type.Integer)
        pFlagAdmin.Value = iFlagAdmin
        pFlagAdmin.Direction = System.Data.ParameterDirection.Input

        Dim pLogin As New DB2Parameter("PLOGINUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenLogin)
        pLogin.Value = sLogin
        pLogin.Direction = System.Data.ParameterDirection.Input

        Dim pPassword As New DB2Parameter("PPWDUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenPassword)
        pPassword.Value = sPassword
        pPassword.Direction = System.Data.ParameterDirection.Input

        Dim pNombre As New DB2Parameter("PNOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombre)
        pNombre.Value = sNombre
        pNombre.Direction = System.Data.ParameterDirection.Input

        Dim pApaterno As New DB2Parameter("PAPELLIDOP", IBM.Data.DB2.DB2Type.VarChar, lenApellido)
        pApaterno.Value = sAPaterno
        pApaterno.Direction = System.Data.ParameterDirection.Input

        Dim pEmail As New DB2Parameter("PEMAIL", IBM.Data.DB2.DB2Type.VarChar, lenEmail)
        pEmail.Value = sEmail
        pEmail.Direction = System.Data.ParameterDirection.Input

        Dim pEstadoUsuario As New DB2Parameter("PESTADOUSUARIO", IBM.Data.DB2.DB2Type.Char, lenEstadoUsuario)
        pEstadoUsuario.Value = sEstadoUsuario
        pEstadoUsuario.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdGrupo)
        com.Parameters.Add(pFlagAdmin)
        com.Parameters.Add(pLogin)
        com.Parameters.Add(pPassword)
        com.Parameters.Add(pNombre)
        com.Parameters.Add(pApaterno)
        com.Parameters.Add(pEmail)
        com.Parameters.Add(pEstadoUsuario)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spMANTInsertGrupoComercio(ByVal CN As DB2Connection, _
                                      ByRef iIdGrupo As Integer, _
                                      ByRef iCmcioId As Integer, _
                                      ByVal sCodGrupo As String, _
                                      ByVal sNomGrupo As String, _
                                      ByVal sDescGrupo As String, _
                                      ByVal iFlagRUC As Integer, _
                                      ByVal iRUC As Long, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTInsertGrupoComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdGrupo As New DB2Parameter("PIDGRUPO", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupo.Direction = System.Data.ParameterDirection.Output

        Dim pCmcioId As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pCmcioId.Value = iCmcioId
        pCmcioId.Direction = System.Data.ParameterDirection.Input

        Dim pCodGrupo As New DB2Parameter("PCODGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenCodGrupo)
        pCodGrupo.Value = sCodGrupo
        pCodGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pNomGrupo As New DB2Parameter("PNOMGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenNombreGrupo)
        pNomGrupo.Value = sNomGrupo
        pNomGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pDescGrupo As New DB2Parameter("PDESCGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenDescGrupo)
        pDescGrupo.Value = sDescGrupo
        pDescGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pFlagRUC As New DB2Parameter("PFLAGRUC", IBM.Data.DB2.DB2Type.Integer)
        pFlagRUC.Value = iFlagRUC
        pFlagRUC.Direction = System.Data.ParameterDirection.Input

        Dim pRUC As New DB2Parameter("PRUC", IBM.Data.DB2.DB2Type.Decimal, lenRUCInt)
        pRUC.Value = iRUC
        pRUC.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdGrupo)
        com.Parameters.Add(pCmcioId)
        com.Parameters.Add(pCodGrupo)
        com.Parameters.Add(pNomGrupo)
        com.Parameters.Add(pDescGrupo)
        com.Parameters.Add(pFlagRUC)
        com.Parameters.Add(pRUC)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery
        If Not (IsDBNull(pIdGrupo.Value)) Then iIdGrupo = pIdGrupo.Value

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spMANTUpdateUsuarioVisanet(ByVal CN As DB2Connection, ByVal iIdUsuarioConsulta As Integer, _
                                      ByVal sLogin As String, _
                                      ByVal sNombre As String, _
                                      ByVal sAPaterno As String, _
                                      ByVal sEmail As String, _
                                      ByVal iNivel As Integer, _
                                      ByVal sEstadoUsuario As String, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTUpdateUsuarioVisanet", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdUsuarioConsulta As New DB2Parameter("PIDUSUARIOCONSULTA", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuarioConsulta.Value = iIdUsuarioConsulta
        pIdUsuarioConsulta.Direction = System.Data.ParameterDirection.Input

        Dim pLogin As New DB2Parameter("PLOGINUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenLogin)
        pLogin.Value = sLogin
        pLogin.Direction = System.Data.ParameterDirection.Input

        Dim pNombre As New DB2Parameter("PNOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombre)
        pNombre.Value = sNombre
        pNombre.Direction = System.Data.ParameterDirection.Input

        Dim pApaterno As New DB2Parameter("PAPELLIDOP", IBM.Data.DB2.DB2Type.VarChar, lenApellido)
        pApaterno.Value = sAPaterno
        pApaterno.Direction = System.Data.ParameterDirection.Input

        Dim pEmail As New DB2Parameter("PEMAIL", IBM.Data.DB2.DB2Type.VarChar, lenEmail)
        pEmail.Value = sEmail
        pEmail.Direction = System.Data.ParameterDirection.Input

        Dim pNivel As New DB2Parameter("PNIVEL", IBM.Data.DB2.DB2Type.Integer)
        pNivel.Value = iNivel
        pNivel.Direction = System.Data.ParameterDirection.Input

        Dim pEstadoUsuario As New DB2Parameter("PESTADOUSUARIO", IBM.Data.DB2.DB2Type.Char, lenEstadoUsuario)
        pEstadoUsuario.Value = sEstadoUsuario
        pEstadoUsuario.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdUsuarioConsulta)
        com.Parameters.Add(pLogin)
        com.Parameters.Add(pNombre)
        com.Parameters.Add(pApaterno)
        com.Parameters.Add(pEmail)
        com.Parameters.Add(pNivel)
        com.Parameters.Add(pEstadoUsuario)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spMANTUpdateUsuarioComercio(ByVal CN As DB2Connection, ByVal iIdUsuarioConsulta As Integer, _
                                      ByVal iIdGrupo As Integer, _
                                      ByVal iFlagAdmin As Integer, _
                                      ByVal sLogin As String, _
                                      ByVal sNombre As String, _
                                      ByVal sAPaterno As String, _
                                      ByVal sEmail As String, _
                                      ByVal sEstadoUsuario As String, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTUpdateUsuarioComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdUsuarioConsulta As New DB2Parameter("PIDUSUARIOCONSULTA", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuarioConsulta.Value = iIdUsuarioConsulta
        pIdUsuarioConsulta.Direction = System.Data.ParameterDirection.Input

        Dim pidGrupo As New DB2Parameter("PIDGRUPO", IBM.Data.DB2.DB2Type.Integer)
        pidGrupo.Value = iIdGrupo
        pidGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pFlagAdmin As New DB2Parameter("PFLAGADMIN", IBM.Data.DB2.DB2Type.Integer)
        pFlagAdmin.Value = iFlagAdmin
        pFlagAdmin.Direction = System.Data.ParameterDirection.Input

        Dim pLogin As New DB2Parameter("PLOGINUSUARIO", IBM.Data.DB2.DB2Type.VarChar, lenLogin)
        pLogin.Value = sLogin
        pLogin.Direction = System.Data.ParameterDirection.Input

        Dim pNombre As New DB2Parameter("PNOMBRE", IBM.Data.DB2.DB2Type.VarChar, lenNombre)
        pNombre.Value = sNombre
        pNombre.Direction = System.Data.ParameterDirection.Input

        Dim pApaterno As New DB2Parameter("PAPELLIDOP", IBM.Data.DB2.DB2Type.VarChar, lenApellido)
        pApaterno.Value = sAPaterno
        pApaterno.Direction = System.Data.ParameterDirection.Input

        Dim pEmail As New DB2Parameter("PEMAIL", IBM.Data.DB2.DB2Type.VarChar, lenEmail)
        pEmail.Value = sEmail
        pEmail.Direction = System.Data.ParameterDirection.Input

        Dim pEstadoUsuario As New DB2Parameter("PESTADOUSUARIO", IBM.Data.DB2.DB2Type.Char, lenEstadoUsuario)
        pEstadoUsuario.Value = sEstadoUsuario
        pEstadoUsuario.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdUsuarioConsulta)
        com.Parameters.Add(pidGrupo)
        com.Parameters.Add(pFlagAdmin)
        com.Parameters.Add(pLogin)
        com.Parameters.Add(pNombre)
        com.Parameters.Add(pApaterno)
        com.Parameters.Add(pEmail)
        com.Parameters.Add(pEstadoUsuario)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spMANTResetPwdUsuarioComercio(ByVal CN As DB2Connection, ByVal iIdUsuarioConsulta As Integer, _
                                      ByVal sPassword As String, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTResetPwdUsuarioComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdUsuarioConsulta As New DB2Parameter("PIDUSUARIOCONSULTA", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuarioConsulta.Value = iIdUsuarioConsulta
        pIdUsuarioConsulta.Direction = System.Data.ParameterDirection.Input

        Dim pPassword As New DB2Parameter("PPASSWORD", IBM.Data.DB2.DB2Type.VarChar, lenPassword)
        pPassword.Value = sPassword
        pPassword.Direction = System.Data.ParameterDirection.Input


        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdUsuarioConsulta)
        com.Parameters.Add(pPassword)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spMANTUpdateGrupoComercio(ByVal CN As DB2Connection, _
                                      ByVal iIdGrupo As Integer, _
                                      ByVal iIdEmpresa As Integer, _
                                      ByVal sCodGrupo As String, _
                                      ByVal sNomGrupo As String, _
                                      ByVal sDescGrupo As String, _
                                      ByVal iFlagRUC As Integer, _
                                      ByVal iRUC As Long, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTUpdateGrupoComercio", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdGrupoConsulta As New DB2Parameter("PIDGRUPOCONSULTA", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupoConsulta.Value = iIdGrupo
        pIdGrupoConsulta.Direction = System.Data.ParameterDirection.Input

        Dim pCmcioId As New DB2Parameter("PMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pcmcioid.Value = iIdEmpresa
        pcmcioid.Direction = System.Data.ParameterDirection.Input

        Dim pCodGrupo As New DB2Parameter("PCODGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenCodGrupo)
        pCodGrupo.Value = sCodGrupo
        pCodGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pNomGrupo As New DB2Parameter("PNOMGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenNombreGrupo)
        pNomGrupo.Value = sNomGrupo
        pNomGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pDescGrupo As New DB2Parameter("PDESCGRUPO", IBM.Data.DB2.DB2Type.VarChar, lenDescGrupo)
        pDescGrupo.Value = sDescGrupo
        pDescGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pFlagRUC As New DB2Parameter("PFLAGRUC", IBM.Data.DB2.DB2Type.Integer)
        pFlagRUC.Value = iFlagRUC
        pFlagRUC.Direction = System.Data.ParameterDirection.Input

        Dim pRUC As New DB2Parameter("PRUC", IBM.Data.DB2.DB2Type.Decimal, lenRUCInt)
        pRUC.Value = iRUC
        pRUC.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pIdGrupoConsulta)
        com.Parameters.Add(pCmcioId)
        com.Parameters.Add(pCodGrupo)
        com.Parameters.Add(pNomGrupo)
        com.Parameters.Add(pDescGrupo)
        com.Parameters.Add(pFlagRUC)
        com.Parameters.Add(pRUC)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spMANTUpdateServicioConsulta(ByVal CN As DB2Connection, _
                                      ByVal sOpcion As String, _
                                      ByVal iIdGrupo As Integer, _
                                      ByVal iIdServicio As Integer, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTUpdateServicioConsulta", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pOpcion As New DB2Parameter("POPCION", IBM.Data.DB2.DB2Type.VarChar, lenEstado)
        pOpcion.Value = sOpcion
        pOpcion.Direction = System.Data.ParameterDirection.Input

        Dim pIdGrupo As New DB2Parameter("PIDGRUPO", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupo.Value = iIdGrupo
        pIdGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pIdServicio As New DB2Parameter("PIDSERVICIO", IBM.Data.DB2.DB2Type.Integer)
        pIdServicio.Value = iIdServicio
        pIdServicio.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pOpcion)
        com.Parameters.Add(pIdGrupo)
        com.Parameters.Add(pIdServicio)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function

    Public Function spMANTUpdateServicioEmpresa(ByVal CN As DB2Connection, _
                                      ByVal sOpcion As String, _
                                      ByVal iIdEmpresa As Integer, _
                                      ByVal iIdServicio As Integer, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTUpdateServicioEmpresa", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pOpcion As New DB2Parameter("POPCION", IBM.Data.DB2.DB2Type.VarChar, lenEstado)
        pOpcion.Value = sOpcion
        pOpcion.Direction = System.Data.ParameterDirection.Input

        Dim pIdEmpresa As New DB2Parameter("PCMCIOID", IBM.Data.DB2.DB2Type.Integer)
        pIdEmpresa.Value = iIdEmpresa
        pIdEmpresa.Direction = System.Data.ParameterDirection.Input

        Dim pIdServicio As New DB2Parameter("PIDSERVICIO", IBM.Data.DB2.DB2Type.Integer)
        pIdServicio.Value = iIdServicio
        pIdServicio.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pOpcion)
        com.Parameters.Add(pIdEmpresa)
        com.Parameters.Add(pIdServicio)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    
    Public Function spMANTUpdateComercioConsulta(ByVal CN As DB2Connection, _
                                      ByVal sOpcion As String, _
                                      ByVal iIdGrupo As Integer, _
                                      ByVal sCodComercio As String, _
                                      ByVal iIDUsuario As Integer, ByRef sCR As String, ByRef sDescError As String) As Integer


        Dim com As New DB2Command
        Dim iResp As Integer

        com = New DB2Command("SQMNUC.spMANTUpdateComercioConsulta", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pOpcion As New DB2Parameter("POPCION", IBM.Data.DB2.DB2Type.VarChar, lenEstado)
        pOpcion.Value = sOpcion
        pOpcion.Direction = System.Data.ParameterDirection.Input

        Dim pIdGrupo As New DB2Parameter("PIDGRUPO", IBM.Data.DB2.DB2Type.Integer)
        pIdGrupo.Value = iIdGrupo
        pIdGrupo.Direction = System.Data.ParameterDirection.Input

        Dim pCodComercio As New DB2Parameter("PCODCOMERCIO", IBM.Data.DB2.DB2Type.VarChar, lenCodComercio)
        pCodComercio.Value = sCodComercio
        pCodComercio.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaInsert As New DB2Parameter("PFECHAINSERT", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaInsert.Direction = System.Data.ParameterDirection.Input

        'Dim pFechaUltActualiz As New DB2Parameter("PFECHAULTACTUALIZ", IBM.Data.DB2.DB2Type.timestamp)
        'pFechaUltActualiz.Direction = System.Data.ParameterDirection.Output

        '--------------------------
        Dim pIdUsuario As New DB2Parameter("PIDUSUARIO", IBM.Data.DB2.DB2Type.Integer)
        pIdUsuario.Value = iIDUsuario
        pIdUsuario.Direction = System.Data.ParameterDirection.Input

        Dim pCR As New DB2Parameter("PCR", IBM.Data.DB2.DB2Type.Char, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Output

        Dim pDescError As New DB2Parameter("PDESCERROR", IBM.Data.DB2.DB2Type.VarChar, lenMensaje)
        pDescError.Direction = System.Data.ParameterDirection.Output

        com.Parameters.Add(pOpcion)
        com.Parameters.Add(pIdGrupo)
        com.Parameters.Add(pCodComercio)

        com.Parameters.Add(pIdUsuario)
        com.Parameters.Add(pCR)
        com.Parameters.Add(pDescError)


        iResp = com.ExecuteNonQuery

        If Not (IsDBNull(pCR.Value)) Then sCR = pCR.Value
        If Not (IsDBNull(pDescError.Value)) Then sDescError = pDescError.Value

        Return iResultOK

    End Function
    Public Function spTotalEmpresa(ByVal CN As DB2Connection, _
                                   ByVal iIdEmpresa As Integer, _
                                   ByVal dFechaIni As Date, _
                                   ByVal dFechaFin As Date, _
                                   ByVal iIdServicio As Integer, _
                                   ByVal sCR As String) As DataSet

        Dim com As New DB2Command

        com = New DB2Command("SQMNUC.spTotalEmpresa", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdEmpresa As New DB2Parameter("PIDEMPRESA", DB2Type.Integer)
        pIdEmpresa.Value = iIdEmpresa
        pIdEmpresa.Direction = System.Data.ParameterDirection.Input

        Dim pFechaIni As New DB2Parameter("PFECHAINI", DB2Type.Timestamp)
        pFechaIni.Value = dFechaIni
        pFechaIni.Direction = System.Data.ParameterDirection.Input

        Dim pFechaFin As New DB2Parameter("PFECHAFIN", DB2Type.Timestamp)
        pFechaFin.Value = dFechaFin
        pFechaFin.Direction = System.Data.ParameterDirection.Input


        '--------------------------
        Dim pServicio As New DB2Parameter("PSERVICIO", DB2Type.Integer)
        pServicio.Direction = System.Data.ParameterDirection.Input
        pServicio.Value = iIdServicio

        Dim pCR As New DB2Parameter("CR", DB2Type.VarChar, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Input
        pCR.Value = sCR

        com.Parameters.Add(pIdEmpresa)
        com.Parameters.Add(pFechaIni)
        com.Parameters.Add(pFechaFin)
        com.Parameters.Add(pServicio)
        com.Parameters.Add(pCR)

        Dim da As New DB2DataAdapter
        Dim ds As New DataSet

        da.SelectCommand = com
        da.Fill(ds)

        Return ds

    End Function

    Public Function spTotalEmpresaFecha(ByVal CN As DB2Connection, _
                                   ByVal iIdEmpresa As Integer, _
                                   ByVal dFechaIni As Date, _
                                   ByVal dFechaFin As Date, _
                                   ByVal iIdServicio As Integer, _
                                   ByVal sCR As String) As DataSet

        Dim com As New DB2Command

        com = New DB2Command("SQMNUC.spTotalEmpFecha", CN)
        com.CommandType = CommandType.StoredProcedure
        com.CommandTimeout = maxTOutQuery

        Dim pIdEmpresa As New DB2Parameter("PIDEMPRESA", DB2Type.Integer)
        pIdEmpresa.Value = iIdEmpresa
        pIdEmpresa.Direction = System.Data.ParameterDirection.Input

        Dim pFechaIni As New DB2Parameter("PFECHAINI", DB2Type.Timestamp)
        pFechaIni.Value = dFechaIni
        pFechaIni.Direction = System.Data.ParameterDirection.Input

        Dim pFechaFin As New DB2Parameter("PFECHAFIN", DB2Type.Timestamp)
        pFechaFin.Value = dFechaFin
        pFechaFin.Direction = System.Data.ParameterDirection.Input


        '--------------------------
        Dim pServicio As New DB2Parameter("PSERVICIO", DB2Type.Integer)
        pServicio.Direction = System.Data.ParameterDirection.Input
        pServicio.Value = iIdServicio

        Dim pCR As New DB2Parameter("CR", DB2Type.VarChar, lenCR)
        pCR.Direction = System.Data.ParameterDirection.Input
        pCR.Value = sCR

        com.Parameters.Add(pIdEmpresa)
        com.Parameters.Add(pFechaIni)
        com.Parameters.Add(pFechaFin)
        com.Parameters.Add(pServicio)
        com.Parameters.Add(pCR)

        Dim da As New DB2DataAdapter
        Dim ds As New DataSet

        da.SelectCommand = com
        da.Fill(ds)

        Return ds

    End Function
End Class
