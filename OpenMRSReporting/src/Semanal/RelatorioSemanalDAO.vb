Imports MySql.Data.MySqlClient
Public Class RelatorioSemanalDAO
    Public Shared Sub PrepararGravidas()
        MMReportDAO.PrepararGravidas()
    End Sub
    Public Shared Sub PrepararFrida()
        MMReportDAO.PrepararFrida()
    End Sub
    Public Shared Sub INDICADORSAIDATARV(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL INDICATOR_SUSPENSO('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL INDICATOR_TRANSFERIDOSPARA('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL INDICATOR_ABANDONO('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL INDICATOR_OBITOTARV('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub INDICADORENTRADATARV(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL INDICATOR_INICIO('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL INDICATOR_REINICIADOS('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL INDICATOR_TRANSFERIDOSDE('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub INDICATOR_TUBERCULOSE(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL INDICATOR_TUBERCULOSE('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub INDICATOR_INSCRITOS(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL INDICATOR_INSCRITOS('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub INDICATOR_REFERIDOSDE(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL INDICATOR_REFERIDOSDE('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub INDICATOR_EMTRATAMENTO(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL INDICATOR_EMTRATAMENTO('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub INDICATOR_CONSULTAS(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL INDICATOR_CONSULTAS('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub INDICADORTARVNOVO(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim districtID As String = rpt.Location.hddDistrictID

        cmmrpt.CommandText = "CALL INDICATOR_TARV_NEW('" & dataInicial & "','" & dataFinal & "','" & districtID & "'," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL INDICATOR_OBITO_NEW('" & dataInicial & "','" & dataFinal & "','" & districtID & "'," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub INDICADORCCRNOVO(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim districtID As String = rpt.Location.hddDistrictID

        cmmrpt.CommandText = "CALL INDICATOR_CCR_NEW('" & dataInicial & "','" & dataFinal & "','" & districtID & "'," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub INDICADORPTVMATERNIDADENOVO(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim districtID As String = rpt.Location.hddDistrictID

        cmmrpt.CommandText = "CALL INDICATOR_PTVMATERNIDADE_NEW('" & dataInicial & "','" & dataFinal & "','" & districtID & "'," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub INDICADORPTVCPNNOVO(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim districtID As String = rpt.Location.hddDistrictID

        cmmrpt.CommandText = "CALL INDICATOR_PTVCPN_NEW('" & dataInicial & "','" & dataFinal & "','" & districtID & "'," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub INDICADORUATSNOVO(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim districtID As String = rpt.Location.hddDistrictID

        cmmrpt.CommandText = "CALL INDICATOR_UATS_NEW('" & dataInicial & "','" & dataFinal & "','" & districtID & "'," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub INDICADORTUBERCULOSENOVO(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim districtID As String = rpt.Location.hddDistrictID

        cmmrpt.CommandText = "CALL INDICATOR_TUBERCULOSE_NEW('" & dataInicial & "','" & dataFinal & "','" & districtID & "'," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Function NumeroDeGravidasAdmitidas(ByVal dataInicial As String, ByVal dataFinal As String, Optional ByVal local As Integer = 0, Optional ByVal distrito As String = "") As Int32
        'Nota: Esta função deve ser chamadas depois de correr a função: manageGravidas 
        'escrita dentro do da base de dados openmrsreporting
        Dim cmmrpt As New MySqlCommand
        Dim query As String = "select count(*) from gravidas_inscritas where encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "'"
        ReabreConexao(ConexaoOpenMRSReporting3)
        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        If local = 0 Then
            query &= " and location_id in (select openmrs_id from hdd where openmrs_id is not null and distritoID='" & distrito & "')"
        Else
            query &= " and location_id =" & local & ""

        End If

        cmmrpt.CommandText = query
        Return cmmrpt.ExecuteScalar
    End Function
    Public Shared Function NumeroDeGravidasInicioTARV(ByVal dataInicial As String, ByVal dataFinal As String, Optional ByVal local As Integer = 0, Optional ByVal distrito As String = "") As Int32
        'Nota: Esta função deve ser chamadas depois de correr a função: manageGravidas 
        'escrita dentro do da base de dados openmrsreporting
        Dim cmmrpt As New MySqlCommand
        Dim query As String = "select count(*) " & _
                                "from gravidas_inscritas inner join openmrs.patient on gravidas_inscritas.patient_id=patient.patient_id " & _
                                " inner join openmrs.encounter on patient.patient_id=encounter.patient_id " & _
                                " inner join openmrs.obs on obs.encounter_id=encounter.encounter_id " & _
                                " where encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and " & _
                                " encounter.encounter_type=18 and obs.concept_id=1255 and obs.value_coded=1256 and " & _
                                " encounter.voided=0 and obs.voided=0 and patient.voided=0 and " & _
                                " round(datediff(encounter.encounter_datetime,gravidas_inscritas.encounter_datetime)/30) between 0 and 10"
        ReabreConexao(ConexaoOpenMRSReporting3)
        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        If local = 0 Then
            query &= " and encounter.location_id in (select openmrs_id from hdd where openmrs_id is not null and distritoID='" & distrito & "')"
        Else
            query &= " and encounter.location_id =" & local & ""

        End If

        cmmrpt.CommandText = query
        Return cmmrpt.ExecuteScalar
    End Function
    Public Shared Function GravidasActualmenteEmTARV(Optional ByVal local As Integer = 0, Optional ByVal distrito As String = "") As Int32
        'Nota: Esta função deve ser chamadas depois de correr a função: manageGravidas 
        'escrita dentro do da base de dados openmrsreporting
        Dim cmmrpt As New MySqlCommand
        Dim strQuery As String = " select count(*) " & _
                        " from 	gravidas_inscritas inner join openmrs.patient on  gravidas_inscritas.patient_id=openmrs.patient.patient_id " & _
                        " inner join temp_tarv_anterior on temp_tarv_anterior.patient_id=gravidas_inscritas.patient_id " & _
                        " where round(datediff(temp_tarv_anterior.encounter_datetime,gravidas_inscritas.encounter_datetime)/30) between 0 and 10"
        ReabreConexao(ConexaoOpenMRSReporting3)
        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        If local = 0 Then
            strQuery &= " and gravidas_inscritas.location_id in (select openmrs_id from hdd where openmrs_id is not null and distritoID='" & distrito & "')"
        Else
            strQuery &= " and gravidas_inscritas.location_id =" & local & ""

        End If

        cmmrpt.CommandText = strQuery
        Return cmmrpt.ExecuteScalar
    End Function
    Public Shared Function GravidasAlgumaVezTARV(Optional ByVal local As Integer = 0, Optional ByVal distrito As String = "") As Int32
        'Nota: Esta função deve ser chamadas depois de correr a função: manageGravidas 
        'escrita dentro do da base de dados openmrsreporting
        Dim cmmrpt As New MySqlCommand
        Dim strQuery As String = "select count(*) " & _
                                "from gravidas_inscritas inner join openmrs.patient on gravidas_inscritas.patient_id=patient.patient_id " & _
                                " inner join openmrs.encounter on patient.patient_id=encounter.patient_id " & _
                                " inner join openmrs.obs on obs.encounter_id=encounter.encounter_id " & _
                                " where  encounter.encounter_type=18 and obs.concept_id=1255 and obs.value_coded in (1256,1369) and " & _
                                " encounter.voided=0 and obs.voided=0 and patient.voided=0 and " & _
                                " round(datediff(encounter.encounter_datetime,gravidas_inscritas.encounter_datetime)/30) between 0 and 10"
        ReabreConexao(ConexaoOpenMRSReporting3)
        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        If local = 0 Then
            strQuery &= " and gravidas_inscritas.location_id in (select openmrs_id from hdd where openmrs_id is not null and distritoID='" & distrito & "')"
        Else
            strQuery &= " and gravidas_inscritas.location_id =" & local & ""

        End If

        cmmrpt.CommandText = strQuery
        Return cmmrpt.ExecuteScalar
    End Function
End Class
