Imports MySql.Data.MySqlClient
Public Class MMReportDAO
    Public Shared Function insert(ByVal rpt As MMReportVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting3)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting3
                .CommandType = CommandType.Text
                .CommandText = "insert into report_print(Location,Report_Date_Range_Start,Report_Date_Range_End," & _
                "Date_Created,Created_By,Voided,Voided_By,Voided_Date,Voided_Reason,Report_print_report) " & _
                " values(" & rpt.Location.hddOpenMRSID & ",'" & dataMySQL(rpt.ReportDateRangeStart) & "','" & dataMySQL(rpt.ReportDateRangeEnd) & "'," & _
                "now(),'" & rpt.CreatedBy.UserID & "',0,null,null,null," & rpt.Report.Id & ")"
                .ExecuteNonQuery()
                .CommandText = "Select max(Reports_ID) from report_print"
                rpt.ReportsID = .ExecuteScalar
                .CommandText = "Insert into month_report(report_id,month,year,distrital) values(" & rpt.ReportsID & "," & rpt.Month & "," & rpt.Year & "," & rpt.Distrital & ")"
                .ExecuteNonQuery()
                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao inserir relatorio." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function getMMByID(ByVal id As Integer) As MMReportVO
        Dim rs As MySqlDataReader
        Dim mmrpt As New MMReportVO
        ReabreConexao(ConexaoOpenMRSReporting3)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting3
                .CommandType = CommandType.Text
                .CommandText = "Select report_print.*,month_report.month,month_report.year,month_report.distrital from report_print,month_report " & _
                " where report_print.Reports_ID=month_report.report_id and report_print.Reports_ID=" & id & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    mmrpt.ReportsID = rs.GetInt32("Reports_ID")
                    mmrpt.Location = HddDAO.getHddByOpenMRSID(rs.GetInt32("Location"))
                    mmrpt.ReportDateRangeStart = dataMicrosoft(rs.GetMySqlDateTime("Report_Date_Range_Start"))
                    mmrpt.ReportDateRangeEnd = dataMicrosoft(rs.GetMySqlDateTime("Report_Date_Range_End"))
                    mmrpt.DateCreated = dataMicrosoft(rs.GetMySqlDateTime("Date_Created"))
                    mmrpt.CreatedBy = UserDAO.getUserByID(rs.GetString("Created_By"))
                    mmrpt.Voided = rs.GetBoolean("Voided")
                    mmrpt.Report = ReportDAO.getReportByID(rs.GetInt16("Report_print_report"))
                    mmrpt.Year = rs.GetInt16("year")
                    mmrpt.Month = rs.GetInt16("month")
                    mmrpt.Distrital = rs.GetBoolean("distrital")
                End If

                FechaResultSet(rs)
            End With
            Return mmrpt
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar relatorio (Print)." & ex.Message)
            Return mmrpt
        End Try
    End Function

    Public Shared Function getMMByHDDMesAno(ByVal hdd As Integer, ByVal mes As Integer, ByVal ano As Integer, ByVal distrital As Boolean) As MMReportVO
        Dim rs As MySqlDataReader
        Dim mmrpt As New MMReportVO
        ReabreConexao(ConexaoOpenMRSReporting3)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting3
                .CommandType = CommandType.Text
                .CommandText = "Select report_print.*,month_report.month,month_report.year,month_report.distrital from report_print,month_report " & _
                " where report_print.Reports_ID=month_report.report_id and month_report.month=" & mes & " " & _
                " and month_report.year=" & ano & " and report_print.location=" & hdd & " and report_print.voided=0 and month_report.distrital= " & distrital & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    mmrpt.ReportsID = rs.GetInt32("Reports_ID")
                    mmrpt.Location = HddDAO.getHddByOpenMRSID(rs.GetInt32("Location"))
                    mmrpt.ReportDateRangeStart = dataMicrosoft(rs.GetMySqlDateTime("Report_Date_Range_Start"))
                    mmrpt.ReportDateRangeEnd = dataMicrosoft(rs.GetMySqlDateTime("Report_Date_Range_End"))
                    mmrpt.DateCreated = dataMicrosoft(rs.GetMySqlDateTime("Date_Created"))
                    mmrpt.CreatedBy = UserDAO.getUserByID(rs.GetString("Created_By"))
                    mmrpt.Voided = rs.GetBoolean("Voided")
                    mmrpt.Report = ReportDAO.getReportByID(rs.GetInt16("Report_print_report"))
                    mmrpt.Year = rs.GetInt16("year")
                    mmrpt.Month = rs.GetInt16("month")
                    mmrpt.Distrital = rs.GetBoolean("distrital")

                End If

                FechaResultSet(rs)
            End With
            Return mmrpt
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar relatorio." & ex.Message)
            Return mmrpt
        End Try
    End Function



    Public Shared Function void(ByVal rpt As MMReportVO) As Boolean
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting3
                .CommandType = CommandType.Text
                .CommandText = "update report_print set " & _
                "Voided=1,Voided_By='" & rpt.VoidedBy.UserID & "',Voided_Date=now()," & _
                "Voided_Reason='" & rpt.VoidedReason & "' where Reports_ID=" & rpt.ReportsID & " "
                .ExecuteNonQuery()
                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao anular relatorio." & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Sub prepare(ByVal rpt As MMReportVO)
        Dim cmmOpenmrs As New MySqlCommand
        Dim cmmrpt As New MySqlCommand

        ReabreConexao(ConexaoOpenMRSReporting3)
        ReabreConexao(ConexaoOpenMRS3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        Dim valor As Integer = 0
        Dim valorTotal As Integer = 0

        'Strings de Condicoes
        Dim condicaoFemininoMenor14 As String = " v_encounter.location_id =" & hdd & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F' "
        Dim condicaoMasculinoMenor14 As String = " v_encounter.location_id =" & hdd & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M' "
        Dim condicaoFeminino1524 As String = " v_encounter.location_id =" & hdd & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F' "
        Dim condicaoMasculino1524 As String = " v_encounter.location_id =" & hdd & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M' "
        Dim condicaoFemininoMaior25 As String = " v_encounter.location_id =" & hdd & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F' "
        Dim condicaoMasculinoMaior25 As String = " v_encounter.location_id =" & hdd & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M' "

        cmmrpt.CommandText = "Insert into mm_indicator_data(report_id) values(" & idPrint & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "Insert into mm_indicator_data_total(report_id) values(" & idPrint & ")"
        cmmrpt.ExecuteNonQuery()

        'cmmrpt.CommandText = "Insert into mm_month_cumulative(report_id) values(" & idPrint & ")"
        'cmmrpt.ExecuteNonQuery()



        With cmmOpenmrs
            .CommandType = CommandType.Text
            .Connection = ConexaoOpenMRS2

            ''============================================================================================================================
            ''Inscritos Cumulativos ate o fim do mes anterior Femininos menores de 15 anos
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & _
            '"location_id =" & hdd & " and encounter_datetime<'" & dataInicial & "' and age<=14 and gender='F'"
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ic14f=" & valor & " where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Inscritos Cumulativos ate o fim do mes anterior Masculinos menores de 15 anos
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & _
            '"location_id =" & hdd & " and encounter_datetime<'" & dataInicial & "' and age<=14 and gender='M'"
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ic14m=" & valor & " where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            ''Inscritos Cumulativos ate o fim do mes anterior Feminios de 15 a 24 anos
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & _
            '"location_id =" & hdd & " and encounter_datetime<'" & dataInicial & "' and age between 15 and 24 and gender='F'"
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ic1524f=" & valor & "  where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Inscritos Cumulativos ate o fim do mes anterior Masculino de 15 a 24 anos

            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & _
            '"location_id =" & hdd & " and encounter_datetime<'" & dataInicial & "' and age between 15 and 24 and gender='M'"
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ic1524m=" & valor & "  where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Inscritos Cumulativos ate o fim do mes anterior Femininos 25 anos ou mais

            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & _
            '"location_id =" & hdd & " and encounter_datetime<'" & dataInicial & "' and age>=25 and gender='F'"
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ic25f=" & valor & " where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Inscritos Cumulativos ate o fim do mes anterior Masculinos 25 anos ou mais
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & _
            '"location_id =" & hdd & " and encounter_datetime<'" & dataInicial & "' and age>=25 and gender='M'"
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ic25m=" & valor & " where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Update Totais na tabela de totais
            'cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
            '                     " mm_indicator_data_total.ic14total = (mm_indicator_data.ic14f+mm_indicator_data.ic14m), " & _
            '                     " mm_indicator_data_total.ic1524total = (mm_indicator_data.ic1524f+mm_indicator_data.ic1524m), " & _
            '                     " mm_indicator_data_total.ic25total = (mm_indicator_data.ic25f+mm_indicator_data.ic25m), " & _
            '                     " mm_indicator_data_total.ictotalfeminino = (mm_indicator_data.ic14f+mm_indicator_data.ic1524f+mm_indicator_data.ic25f), " & _
            '                     " mm_indicator_data_total.ictotalmasculino = (mm_indicator_data.ic14m+mm_indicator_data.ic1524m+mm_indicator_data.ic25m), " & _
            '                     " mm_indicator_data_total.ictotal = (mm_indicator_data.ic14f + mm_indicator_data.ic14m + mm_indicator_data.ic1524f + mm_indicator_data.ic1524m + mm_indicator_data.ic25f + mm_indicator_data.ic25m) " & _
            '                     " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
            '                     " mm_indicator_data.report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''============================================================================================================================

            ''Novos Inscritos neste mes Femininos menores de 15 anos
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & condicaoFemininoMenor14
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ni14f= " & valor & "  where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            ''Novos Inscritos neste mes Masculinos menores de 15 anos
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & condicaoMasculinoMenor14
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ni14m= " & valor & "  where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            ''Novos Inscritos neste mes Femininos 15 a 24 anos
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & condicaoFeminino1524
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ni1524f= " & valor & "  where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            ''Novos Inscritos neste mes Masculinos 15 a 24 anos
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & condicaoMasculino1524
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ni1524m= " & valor & "  where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Novos Inscritos neste mes Femininos 25 anos
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & condicaoFemininoMaior25
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ni25f= " & valor & "  where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Novos Inscritos neste mes Femininos 25 anos
            '.CommandText = "Select count(distinct(patient_id)) from v_encounter where encounter_type in (5,7) and " & condicaoMasculinoMaior25
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set ni25m= " & valor & "  where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Update Totais na tabela de totais (Novos inscritos)
            'cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
            '                     " mm_indicator_data_total.ni14total = (mm_indicator_data.ni14f+mm_indicator_data.ni14m), " & _
            '                     " mm_indicator_data_total.ni1524total = (mm_indicator_data.ni1524f+mm_indicator_data.ni1524m), " & _
            '                     " mm_indicator_data_total.ni25total = (mm_indicator_data.ni25f+mm_indicator_data.ni25m), " & _
            '                     " mm_indicator_data_total.nitotalfeminino = (mm_indicator_data.ni14f+mm_indicator_data.ni1524f+mm_indicator_data.ni25f), " & _
            '                     " mm_indicator_data_total.nitotalmasculino = (mm_indicator_data.ni14m+mm_indicator_data.ni1524m+mm_indicator_data.ni25m), " & _
            '                     " mm_indicator_data_total.nitotal = (mm_indicator_data.ni14f + mm_indicator_data.ni14m + mm_indicator_data.ni1524f + mm_indicator_data.ni1524m + mm_indicator_data.ni25f + mm_indicator_data.ni25m) " & _
            '                     " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
            '                     " mm_indicator_data.report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            ''Update Incritos Cumulativos calculados
            'cmmrpt.CommandText = " update  mm_indicator_data,mm_indicator_data_total set " & _
            '                    " mm_indicator_data_total.ict14f = (mm_indicator_data.ic14f+mm_indicator_data.ni14f), " & _
            '                    " mm_indicator_data_total.ict14m = (mm_indicator_data.ic14m+mm_indicator_data.ni14m), " & _
            '                    " mm_indicator_data_total.ict14total = (mm_indicator_data_total.ic14total+mm_indicator_data_total.ni14total)," & _
            '                    " mm_indicator_data_total.ict1524f = (mm_indicator_data.ic1524f+mm_indicator_data.ni1524f), " & _
            '                    " mm_indicator_data_total.ict1524m = (mm_indicator_data.ic1524m+mm_indicator_data.ni1524m)," & _
            '                    " mm_indicator_data_total.ict1524total = (mm_indicator_data_total.ic1524total+mm_indicator_data_total.ni1524total)," & _
            '                    " mm_indicator_data_total.ict25f = (mm_indicator_data.ic25f+mm_indicator_data.ni25f), " & _
            '                    " mm_indicator_data_total.ict25m = (mm_indicator_data.ic25m+mm_indicator_data.ni25m), " & _
            '                    " mm_indicator_data_total.ict25total = (mm_indicator_data_total.ic25total+mm_indicator_data_total.ni25total)," & _
            '                    " mm_indicator_data_total.icttotalfeminino = (mm_indicator_data_total.ictotalfeminino+mm_indicator_data_total.nitotalfeminino)," & _
            '                    " mm_indicator_data_total.icttotalmasculino = (mm_indicator_data_total.ictotalmasculino+mm_indicator_data_total.nitotalmasculino), " & _
            '                    " mm_indicator_data_total.icttotal = (mm_indicator_data_total.ictotal + mm_indicator_data_total.nitotal) " & _
            '                    " where mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
            '                    " mm_indicator_data.report_id= " & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            ''============================================================================================================================================================
            ''Consultas Clinicas a doentes em TARV Feminino menor 15
            '.CommandText = "select count(*) from v_pacientes_tarv,v_encounter " & _
            '               " where v_encounter.encounter_datetime>=v_pacientes_tarv.data_inicio and v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoFemininoMenor14
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set cct14f=" & valor & " where report_id=" & idPrint & ""               
            'cmmrpt.ExecuteNonQuery()

            ''Consultas Clinicas a doentes em TARV Masculino menor 15
            '.CommandText = "select count(*) from v_pacientes_tarv,v_encounter " & _
            '               " where v_encounter.encounter_datetime>=v_pacientes_tarv.data_inicio and v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoMasculinoMenor14
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set cct14m=" & valor & " where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            ''Consultas Clinicas a doentes em TARV Feminino 15 a 24 anos
            '.CommandText = "select count(*) from v_pacientes_tarv,v_encounter " & _
            '              " where v_encounter.encounter_datetime>=v_pacientes_tarv.data_inicio and v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoFeminino1524
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set cct1524f=" & valor & " where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Consultas Clinicas a doentes em TARV Masculino 15 a 24 anos
            '.CommandText = "select count(*) from v_pacientes_tarv,v_encounter " & _
            '              " where v_encounter.encounter_datetime>=v_pacientes_tarv.data_inicio and v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoMasculino1524
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set cct1524m=" & valor & " where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()

            ''Consultas Clinicas a doentes em TARV Feminino 25 anos
            '.CommandText = "select count(*) from v_pacientes_tarv,v_encounter " & _
            '              " where v_encounter.encounter_datetime>=v_pacientes_tarv.data_inicio and v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoFemininoMaior25
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set cct25f=" & valor & " where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            ''Consultas Clinicas a doentes em TARV Masculino 25 anos

            '.CommandText = "select count(*) from v_pacientes_tarv,v_encounter " & _
            '              " where v_encounter.encounter_datetime>=v_pacientes_tarv.data_inicio and v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoMasculinoMaior25
            'valor = .ExecuteScalar

            'cmmrpt.CommandText = "Update mm_indicator_data set cct25m=" & valor & " where report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            ''Update Totais na tabela de totais (Consultas clinicas a doentes em tarv)
            'cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
            '                     " mm_indicator_data_total.cct14total = (mm_indicator_data.cct14f+mm_indicator_data.cct14m), " & _
            '                     " mm_indicator_data_total.cct1524total = (mm_indicator_data.cct1524f+mm_indicator_data.cct1524m), " & _
            '                     " mm_indicator_data_total.cct25total = (mm_indicator_data.cct25f+mm_indicator_data.cct25m), " & _
            '                     " mm_indicator_data_total.ccttotalfeminino = (mm_indicator_data.cct14f+mm_indicator_data.cct1524f+mm_indicator_data.cct25f), " & _
            '                     " mm_indicator_data_total.ccttotalmasculino = (mm_indicator_data.cct14m+mm_indicator_data.cct1524m+mm_indicator_data.cct25m), " & _
            '                     " mm_indicator_data_total.ccttotal = (mm_indicator_data.cct14f + mm_indicator_data.cct14m + mm_indicator_data.cct1524f + mm_indicator_data.cct1524m + mm_indicator_data.cct25f + mm_indicator_data.cct25m) " & _
            '                     " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
            '                     " mm_indicator_data.report_id=" & idPrint & ""
            'cmmrpt.ExecuteNonQuery()


            '=========================================================================================================================================================================================
            'Consultas Clinicas a doentes nao em TARV Feminino menor 15
            .CommandText = "select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoFemininoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ccnt14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Consultas Clinicas a doentes nao em TARV Masculino menor 15
            .CommandText = "select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                        " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoMasculinoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ccnt14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Consultas Clinicas a doentes nao em TARV Feminino 15 a 24 anos
            .CommandText = "select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                        " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoFeminino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ccnt1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Consultas Clinicas a doentes nao em TARV Masculino 15 a 24 anos
            .CommandText = "select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                        " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoMasculino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ccnt1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Consultas Clinicas a doentes nao em TARV Feminino 25 anos
            .CommandText = "select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                        " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoFemininoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ccnt25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Consultas Clinicas a doentes nao em TARV Masculino 25 anos
            .CommandText = "select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                       " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & condicaoMasculinoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ccnt25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()



            cmmrpt.CommandText = "select FillConsultasClinicasTARV('" & dataInicial & "','" & dataFinal & "'," & idPrint & ")"
            cmmrpt.ExecuteNonQuery()


            'Update Totais na tabela de totais (Consultas clinicas a doentes em tarv)
            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.cct14total = (mm_indicator_data.cct14f+mm_indicator_data.cct14m), " & _
                                 " mm_indicator_data_total.cct1524total = (mm_indicator_data.cct1524f+mm_indicator_data.cct1524m), " & _
                                 " mm_indicator_data_total.cct25total = (mm_indicator_data.cct25f+mm_indicator_data.cct25m), " & _
                                 " mm_indicator_data_total.ccttotalfeminino = (mm_indicator_data.cct14f+mm_indicator_data.cct1524f+mm_indicator_data.cct25f), " & _
                                 " mm_indicator_data_total.ccttotalmasculino = (mm_indicator_data.cct14m+mm_indicator_data.cct1524m+mm_indicator_data.cct25m), " & _
                                 " mm_indicator_data_total.ccttotal = (mm_indicator_data.cct14f + mm_indicator_data.cct14m + mm_indicator_data.cct1524f + mm_indicator_data.cct1524m + mm_indicator_data.cct25f + mm_indicator_data.cct25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()








            'Update Totais na tabela de totais (Consultas clinicas a doentes nao em tarv)
            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.ccnt14total = (mm_indicator_data.ccnt14f+mm_indicator_data.ccnt14m), " & _
                                 " mm_indicator_data_total.ccnt1524total = (mm_indicator_data.ccnt1524f+mm_indicator_data.ccnt1524m), " & _
                                 " mm_indicator_data_total.ccnt25total = (mm_indicator_data.ccnt25f+mm_indicator_data.ccnt25m), " & _
                                 " mm_indicator_data_total.ccnttotalfeminino = (mm_indicator_data.ccnt14f+mm_indicator_data.ccnt1524f+mm_indicator_data.ccnt25f), " & _
                                 " mm_indicator_data_total.ccnttotalmasculino = (mm_indicator_data.ccnt14m+mm_indicator_data.ccnt1524m+mm_indicator_data.ccnt25m), " & _
                                 " mm_indicator_data_total.ccnttotal = (mm_indicator_data.ccnt14f + mm_indicator_data.ccnt14m + mm_indicator_data.ccnt1524f + mm_indicator_data.ccnt1524m + mm_indicator_data.ccnt25f + mm_indicator_data.ccnt25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Update Total de consultas clinicas.
            cmmrpt.CommandText = " update  mm_indicator_data,mm_indicator_data_total set " & _
                                " mm_indicator_data_total.tcc14f = (mm_indicator_data.cct14f+mm_indicator_data.ccnt14f), " & _
                                " mm_indicator_data_total.tcc14m = (mm_indicator_data.cct14m+mm_indicator_data.ccnt14m), " & _
                                " mm_indicator_data_total.tcc14total = (mm_indicator_data_total.cct14total+mm_indicator_data_total.ccnt14total)," & _
                                " mm_indicator_data_total.tcc1524f = (mm_indicator_data.cct1524f+mm_indicator_data.ccnt1524f), " & _
                                " mm_indicator_data_total.tcc1524m = (mm_indicator_data.cct1524m+mm_indicator_data.ccnt1524m)," & _
                                " mm_indicator_data_total.tcc1524total = (mm_indicator_data_total.cct1524total+mm_indicator_data_total.ccnt1524total)," & _
                                " mm_indicator_data_total.tcc25f = (mm_indicator_data.cct25f+mm_indicator_data.ccnt25f), " & _
                                " mm_indicator_data_total.tcc25m = (mm_indicator_data.cct25m+mm_indicator_data.ccnt25m), " & _
                                " mm_indicator_data_total.tcc25total = (mm_indicator_data_total.cct25total+mm_indicator_data_total.ccnt25total)," & _
                                " mm_indicator_data_total.tcctotalfeminino = (mm_indicator_data_total.ccttotalfeminino+mm_indicator_data_total.ccnttotalfeminino)," & _
                                " mm_indicator_data_total.tcctotalmasculino = (mm_indicator_data_total.ccttotalmasculino+mm_indicator_data_total.ccnttotalmasculino), " & _
                                " mm_indicator_data_total.tcctotal = (mm_indicator_data_total.ccttotal + mm_indicator_data_total.ccnttotal) " & _
                                " where mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                " mm_indicator_data.report_id= " & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '=======================================================================================================================================================================
            'Entrada Novos Femininos menores de 15 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & condicaoFemininoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set en14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Entrada Novos Masculinos menores de 15 anos

            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & condicaoMasculinoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set en14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Entrada Novos Femininos entre de 15 a 24 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & condicaoFeminino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set en1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Entrada Novos Masculinos entre de 15 a 24 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & condicaoMasculino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set en1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Entrada Novos Feminino 25 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & condicaoFemininoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set en25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Entrada Novos Feminino 25 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & condicaoMasculinoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set en25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Update Totais na tabela de totais (Novas Entradas)
            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.en14total = (mm_indicator_data.en14f+mm_indicator_data.en14m), " & _
                                 " mm_indicator_data_total.en1524total = (mm_indicator_data.en1524f+mm_indicator_data.en1524m), " & _
                                 " mm_indicator_data_total.en25total = (mm_indicator_data.en25f+mm_indicator_data.en25m), " & _
                                 " mm_indicator_data_total.entotalfeminino = (mm_indicator_data.en14f+mm_indicator_data.en1524f+mm_indicator_data.en25f), " & _
                                 " mm_indicator_data_total.entotalmasculino = (mm_indicator_data.en14m+mm_indicator_data.en1524m+mm_indicator_data.en25m), " & _
                                 " mm_indicator_data_total.entotal = (mm_indicator_data.en14f + mm_indicator_data.en14m + mm_indicator_data.en1524f + mm_indicator_data.en1524m + mm_indicator_data.en25f + mm_indicator_data.en25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '===========================================================================================================================================================================================================================

            'Entrada Reiniciados Femininos menores de 15 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & condicaoFemininoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set er14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Entrada Reiniciados Masculinos menores de 15 anos

            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & condicaoMasculinoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set er14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Entrada Reiniciados Femininos entre de 15 a 24 anos

            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & condicaoFeminino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set er1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Entrada Reiniciados Masculinos entre de 15 a 24 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                           " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                           " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & condicaoMasculino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set er1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Entrada Reiniciados Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                           " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                           " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & condicaoFemininoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set er25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Entrada Reiniciados Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                           " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                           " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & condicaoMasculinoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set er25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Update Totais na tabela de totais (Entradas Reiniciados)
            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.er14total = (mm_indicator_data.er14f+mm_indicator_data.er14m), " & _
                                 " mm_indicator_data_total.er1524total = (mm_indicator_data.er1524f+mm_indicator_data.er1524m), " & _
                                 " mm_indicator_data_total.er25total = (mm_indicator_data.er25f+mm_indicator_data.er25m), " & _
                                 " mm_indicator_data_total.ertotalfeminino = (mm_indicator_data.er14f+mm_indicator_data.er1524f+mm_indicator_data.er25f), " & _
                                 " mm_indicator_data_total.ertotalmasculino = (mm_indicator_data.er14m+mm_indicator_data.er1524m+mm_indicator_data.er25m), " & _
                                 " mm_indicator_data_total.ertotal = (mm_indicator_data.er14f + mm_indicator_data.er14m + mm_indicator_data.er1524f + mm_indicator_data.er1524m + mm_indicator_data.er25f + mm_indicator_data.er25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Entrada Transferidos de Femininos menores de 15 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & condicaoFemininoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set et14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Entrada Transferidos de Masculinos menores de 15 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & condicaoMasculinoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set et14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()



            'Entrada Transferidos de Femininos entre de 15 a 24 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & condicaoFeminino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set et1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()



            'Entrada Transferidos de Masculinos entre de 15 a 24 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & condicaoMasculino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set et1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Entrada Transferidos de Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & condicaoFemininoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set et25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Entrada Transferidos de Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & condicaoMasculinoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set et25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Update Totais na tabela de totais (Entradas Transferidos de)
            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.et14total = (mm_indicator_data.et14f+mm_indicator_data.et14m), " & _
                                 " mm_indicator_data_total.et1524total = (mm_indicator_data.et1524f+mm_indicator_data.et1524m), " & _
                                 " mm_indicator_data_total.et25total = (mm_indicator_data.et25f+mm_indicator_data.et25m), " & _
                                 " mm_indicator_data_total.ettotalfeminino = (mm_indicator_data.et14f+mm_indicator_data.et1524f+mm_indicator_data.et25f), " & _
                                 " mm_indicator_data_total.ettotalmasculino = (mm_indicator_data.et14m+mm_indicator_data.et1524m+mm_indicator_data.et25m), " & _
                                 " mm_indicator_data_total.ettotal = (mm_indicator_data.et14f + mm_indicator_data.et14m + mm_indicator_data.et1524f + mm_indicator_data.et1524m + mm_indicator_data.et25f + mm_indicator_data.et25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Update Total de Entradas.
            cmmrpt.CommandText = " update  mm_indicator_data,mm_indicator_data_total set " & _
                                " mm_indicator_data_total.te14f = (mm_indicator_data.en14f+mm_indicator_data.er14f+mm_indicator_data.et14f), " & _
                                " mm_indicator_data_total.te14m = (mm_indicator_data.en14m+mm_indicator_data.er14m+mm_indicator_data.et14m), " & _
                                " mm_indicator_data_total.te14total = (mm_indicator_data_total.en14total+mm_indicator_data_total.er14total+mm_indicator_data_total.et14total)," & _
                                " mm_indicator_data_total.te1524f = (mm_indicator_data.en1524f+mm_indicator_data.en1524f+mm_indicator_data.et1524f), " & _
                                " mm_indicator_data_total.te1524m = (mm_indicator_data.en1524m+mm_indicator_data.er1524m+mm_indicator_data.et1524m)," & _
                                " mm_indicator_data_total.te1524total = (mm_indicator_data_total.en1524total+mm_indicator_data_total.er1524total+mm_indicator_data_total.et1524total)," & _
                                " mm_indicator_data_total.te25f = (mm_indicator_data.en25f+mm_indicator_data.er25f+mm_indicator_data.et25f), " & _
                                " mm_indicator_data_total.te25m = (mm_indicator_data.en25m+mm_indicator_data.er25m+mm_indicator_data.et25m), " & _
                                " mm_indicator_data_total.te25total = (mm_indicator_data_total.en25total+mm_indicator_data_total.er25total+mm_indicator_data_total.et25total)," & _
                                " mm_indicator_data_total.tetotalfeminino = (mm_indicator_data_total.entotalfeminino+mm_indicator_data_total.ertotalfeminino+mm_indicator_data_total.ettotalfeminino)," & _
                                " mm_indicator_data_total.tetotalmasculino = (mm_indicator_data_total.entotalmasculino+mm_indicator_data_total.ertotalmasculino+mm_indicator_data_total.ettotalmasculino), " & _
                                " mm_indicator_data_total.tetotal = (mm_indicator_data_total.entotal + mm_indicator_data_total.ertotal+mm_indicator_data_total.ettotal) " & _
                                " where mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                " mm_indicator_data.report_id= " & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '===========================================================================================================================================================================================================================


            'Saida Suspensos Femininos menores de 15 anos

            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & condicaoFemininoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ss14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Suspensos Masculinos menores de 15 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & condicaoMasculinoMenor14
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ss14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Suspensos Femininos entre de 15 a 24 anos

            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & condicaoFeminino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ss1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Saida Suspensos Masculinos entre de 15 a 24 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                           " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                           " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & condicaoMasculino1524
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ss1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Suspensos Feminino 25 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                           " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                           " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & condicaoFemininoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ss25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Suspensos Feminino 25 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                           " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                           " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & condicaoMasculinoMaior25
            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set ss25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Update Totais na tabela de totais (Saidas Suspensos)
            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.ss14total = (mm_indicator_data.ss14f+mm_indicator_data.ss14m), " & _
                                 " mm_indicator_data_total.ss1524total = (mm_indicator_data.ss1524f+mm_indicator_data.ss1524m), " & _
                                 " mm_indicator_data_total.ss25total = (mm_indicator_data.ss25f+mm_indicator_data.ss25m), " & _
                                 " mm_indicator_data_total.sstotalfeminino = (mm_indicator_data.ss14f+mm_indicator_data.ss1524f+mm_indicator_data.ss25f), " & _
                                 " mm_indicator_data_total.sstotalmasculino = (mm_indicator_data.ss14m+mm_indicator_data.ss1524m+mm_indicator_data.ss25m), " & _
                                 " mm_indicator_data_total.sstotal = (mm_indicator_data.ss14f + mm_indicator_data.ss14m + mm_indicator_data.ss1524f + mm_indicator_data.ss1524m + mm_indicator_data.ss25f + mm_indicator_data.ss25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Saida Transferidos para Femininos menores de 15 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & condicaoFemininoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set st14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Transferidos para Masculinos menores de 15 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & condicaoMasculinoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set st14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Saida Transferidos para Femininos entre de 15 a 24 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & condicaoFeminino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set st1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Saida Transferidos para Masculinos entre de 15 a 24 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & condicaoMasculino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set st1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Transferidos para Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & condicaoFemininoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set st25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Transferidos para Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & condicaoMasculinoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set st25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Update Totais na tabela de totais (Saidas Transferidos para)
            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.st14total = (mm_indicator_data.st14f+mm_indicator_data.st14m), " & _
                                 " mm_indicator_data_total.st1524total = (mm_indicator_data.st1524f+mm_indicator_data.st1524m), " & _
                                 " mm_indicator_data_total.st25total = (mm_indicator_data.st25f+mm_indicator_data.st25m), " & _
                                 " mm_indicator_data_total.sttotalfeminino = (mm_indicator_data.st14f+mm_indicator_data.st1524f+mm_indicator_data.st25f), " & _
                                 " mm_indicator_data_total.sttotalmasculino = (mm_indicator_data.st14m+mm_indicator_data.st1524m+mm_indicator_data.st25m), " & _
                                 " mm_indicator_data_total.sttotal = (mm_indicator_data.st14f + mm_indicator_data.st14m + mm_indicator_data.st1524f + mm_indicator_data.st1524m + mm_indicator_data.st25f + mm_indicator_data.st25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()



            '===========================================================================================================================================================================================================================
            'Saida Abandonos Femininos menores de 15 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & condicaoFemininoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set sa14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Abandonos Masculinos menores de 15 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & condicaoMasculinoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set sa14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Abandonos Femininos entre de 15 a 24 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & condicaoFeminino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set sa1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Saida Abandonos Masculinos entre de 15 a 24 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & condicaoMasculino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set sa1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Saida Abandonos Feminino 25 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & condicaoFemininoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set sa25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Saida Abandonos Feminino 25 anos
            .CommandText = " select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & condicaoMasculinoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set sa25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Update Totais na tabela de totais (Saidas Transferidos para)
            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.sa14total = (mm_indicator_data.sa14f+mm_indicator_data.sa14m), " & _
                                 " mm_indicator_data_total.sa1524total = (mm_indicator_data.sa1524f+mm_indicator_data.sa1524m), " & _
                                 " mm_indicator_data_total.sa25total = (mm_indicator_data.sa25f+mm_indicator_data.sa25m), " & _
                                 " mm_indicator_data_total.satotalfeminino = (mm_indicator_data.sa14f+mm_indicator_data.sa1524f+mm_indicator_data.sa25f), " & _
                                 " mm_indicator_data_total.satotalmasculino = (mm_indicator_data.sa14m+mm_indicator_data.sa1524m+mm_indicator_data.sa25m), " & _
                                 " mm_indicator_data_total.satotal = (mm_indicator_data.sa14f + mm_indicator_data.sa14m + mm_indicator_data.sa1524f + mm_indicator_data.sa1524m + mm_indicator_data.sa25f + mm_indicator_data.sa25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Saida Obitos Femininos menores de 15 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & condicaoFemininoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set so14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()



            'Saida Obitos Masculinos menores de 15 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & condicaoMasculinoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set so14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Obitos Femininos entre de 15 a 24 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & condicaoFeminino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set so1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Saida Obitos Masculinos entre de 15 a 24 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & condicaoMasculino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set so1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Saida Obitos Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & condicaoFemininoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set so25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Saida Obitos Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & condicaoMasculinoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set so25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.so14total = (mm_indicator_data.so14f+mm_indicator_data.so14m), " & _
                                 " mm_indicator_data_total.so1524total = (mm_indicator_data.so1524f+mm_indicator_data.so1524m), " & _
                                 " mm_indicator_data_total.so25total = (mm_indicator_data.so25f+mm_indicator_data.so25m), " & _
                                 " mm_indicator_data_total.sototalfeminino = (mm_indicator_data.so14f+mm_indicator_data.so1524f+mm_indicator_data.so25f), " & _
                                 " mm_indicator_data_total.sototalmasculino = (mm_indicator_data.so14m+mm_indicator_data.so1524m+mm_indicator_data.so25m), " & _
                                 " mm_indicator_data_total.sototal = (mm_indicator_data.so14f + mm_indicator_data.so14m + mm_indicator_data.so1524f + mm_indicator_data.so1524m + mm_indicator_data.so25f + mm_indicator_data.so25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            '===========================================================================================================================================================================================================================

            'Update Total de Saidas.
            cmmrpt.CommandText = " update  mm_indicator_data,mm_indicator_data_total set " & _
                                " mm_indicator_data_total.ts14f = (mm_indicator_data.ss14f+mm_indicator_data.st14f+mm_indicator_data.sa14f+mm_indicator_data.so14f), " & _
                                " mm_indicator_data_total.ts14m = (mm_indicator_data.ss14m+mm_indicator_data.st14m+mm_indicator_data.sa14m+mm_indicator_data.so14m), " & _
                                " mm_indicator_data_total.ts14total = (mm_indicator_data_total.ss14total+mm_indicator_data_total.st14total+mm_indicator_data_total.sa14total+mm_indicator_data_total.so14total)," & _
                                " mm_indicator_data_total.ts1524f = (mm_indicator_data.ss1524f+mm_indicator_data.st1524f+mm_indicator_data.sa1524f+mm_indicator_data.so1524f), " & _
                                " mm_indicator_data_total.ts1524m = (mm_indicator_data.ss1524m+mm_indicator_data.st1524m+mm_indicator_data.sa1524m+mm_indicator_data.so1524m)," & _
                                " mm_indicator_data_total.ts1524total = (mm_indicator_data_total.ss1524total+mm_indicator_data_total.st1524total+mm_indicator_data_total.sa1524total+mm_indicator_data_total.so1524total)," & _
                                " mm_indicator_data_total.ts25f = (mm_indicator_data.ss25f+mm_indicator_data.st25f+mm_indicator_data.sa25f+mm_indicator_data.so25f), " & _
                                " mm_indicator_data_total.ts25m = (mm_indicator_data.ss25m+mm_indicator_data.st25m+mm_indicator_data.sa25m+mm_indicator_data.so25m), " & _
                                " mm_indicator_data_total.ts25total = (mm_indicator_data_total.ss25total+mm_indicator_data_total.st25total+mm_indicator_data_total.sa25total+mm_indicator_data_total.so25total)," & _
                                " mm_indicator_data_total.tstotalfeminino = (mm_indicator_data_total.sstotalfeminino+mm_indicator_data_total.sttotalfeminino+mm_indicator_data_total.satotalfeminino+mm_indicator_data_total.sototalfeminino)," & _
                                " mm_indicator_data_total.tstotalmasculino = (mm_indicator_data_total.sstotalmasculino+mm_indicator_data_total.sttotalmasculino+mm_indicator_data_total.satotalmasculino+mm_indicator_data_total.sototalmasculino), " & _
                                " mm_indicator_data_total.tstotal = (mm_indicator_data_total.sstotal + mm_indicator_data_total.sttotal+mm_indicator_data_total.satotal+mm_indicator_data_total.sototal) " & _
                                " where mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                " mm_indicator_data.report_id= " & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '===========================================================================================================================================================================================================================

            'fillCumulativeLastMonth(rpt)

            '===========================================================================================================================================================================================================================

            'Em tratamento de TB Femininos menores de 15 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & condicaoFemininoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set etb14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()



            'Em tratamento de TB Masculinos menores de 15 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & condicaoMasculinoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set etb14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


            'Em tratamento de TB Femininos entre de 15 a 24 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                             " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                             " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & condicaoFeminino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set etb1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Em tratamento de TB Masculinos entre de 15 a 24 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                             " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                             " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & condicaoMasculino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set etb1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()
            'Em tratamento de TB Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                             " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                             " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & condicaoFemininoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set etb25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()
            'Em tratamento de TB Feminino 25 anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                             " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                             " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & condicaoMasculinoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set etb25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()
            'Update Totais na tabela de Totais
            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.etb14total = (mm_indicator_data.etb14f+mm_indicator_data.etb14m), " & _
                                 " mm_indicator_data_total.etb1524total = (mm_indicator_data.etb1524f+mm_indicator_data.etb1524m), " & _
                                 " mm_indicator_data_total.etb25total = (mm_indicator_data.etb25f+mm_indicator_data.etb25m), " & _
                                 " mm_indicator_data_total.etbtotalfeminino = (mm_indicator_data.etb14f+mm_indicator_data.etb1524f+mm_indicator_data.etb25f), " & _
                                 " mm_indicator_data_total.etbtotalmasculino = (mm_indicator_data.etb14m+mm_indicator_data.etb1524m+mm_indicator_data.etb25m), " & _
                                 " mm_indicator_data_total.etbtotal = (mm_indicator_data.etb14f + mm_indicator_data.etb14m + mm_indicator_data.etb1524f + mm_indicator_data.etb1524m + mm_indicator_data.etb25f + mm_indicator_data.etb25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()
            '===========================================================================================================================================================================================================================
            'Em TARV referidos aos cuidados domiciliarios femininos menores 15

            .CommandText = "select count(distinct(v_pacientes_TARV.patient_id)) from v_value_coded,v_pacientes_TARV,v_encounter " & _
                            " where v_pacientes_TARV.patient_id=v_encounter.patient_id and " & _
                            " v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " concept_id=1272 and concept_id_value=1699 and " & condicaoFemininoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set tcd14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Em TARV referidos aos cuidados domiciliarios masculino menores 15

            .CommandText = "select count(distinct(v_pacientes_TARV.patient_id)) from v_value_coded,v_pacientes_TARV,v_encounter " & _
                            " where v_pacientes_TARV.patient_id=v_encounter.patient_id and " & _
                            " v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " concept_id=1272 and concept_id_value=1699 and " & condicaoMasculinoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set tcd14m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Em TARV referidos aos cuidados domiciliarios femininos 15 a 24

            .CommandText = "select count(distinct(v_pacientes_TARV.patient_id)) from v_value_coded,v_pacientes_TARV,v_encounter " & _
                            " where v_pacientes_TARV.patient_id=v_encounter.patient_id and " & _
                            " v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " concept_id=1272 and concept_id_value=1699 and " & condicaoFeminino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set tcd1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Em TARV referidos aos cuidados domiciliarios Masculinos 15 a 24

            .CommandText = "select count(distinct(v_pacientes_TARV.patient_id)) from v_value_coded,v_pacientes_TARV,v_encounter " & _
                            " where v_pacientes_TARV.patient_id=v_encounter.patient_id and " & _
                            " v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " concept_id=1272 and concept_id_value=1699 and " & condicaoMasculino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set tcd1524m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Em TARV referidos aos cuidados domiciliarios femininos maior 25

            .CommandText = "select count(distinct(v_pacientes_TARV.patient_id)) from v_value_coded,v_pacientes_TARV,v_encounter " & _
                            " where v_pacientes_TARV.patient_id=v_encounter.patient_id and " & _
                            " v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " concept_id=1272 and concept_id_value=1699 and " & condicaoFemininoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set tcd25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Em TARV referidos aos cuidados domiciliarios Masculino maior 25

            .CommandText = "select count(distinct(v_pacientes_TARV.patient_id)) from v_value_coded,v_pacientes_TARV,v_encounter " & _
                            " where v_pacientes_TARV.patient_id=v_encounter.patient_id and " & _
                            " v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " concept_id=1272 and concept_id_value=1699 and " & condicaoMasculinoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set tcd25m=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()
            'Update na tabela de totais.

            cmmrpt.CommandText = " update mm_indicator_data,mm_indicator_data_total set " & _
                                 " mm_indicator_data_total.tcd14total = (mm_indicator_data.tcd14f+mm_indicator_data.tcd14m), " & _
                                 " mm_indicator_data_total.tcd1524total = (mm_indicator_data.tcd1524f+mm_indicator_data.tcd1524m), " & _
                                 " mm_indicator_data_total.tcd25total = (mm_indicator_data.tcd25f+mm_indicator_data.tcd25m), " & _
                                 " mm_indicator_data_total.tcdtotalfeminino = (mm_indicator_data.tcd14f+mm_indicator_data.tcd1524f+mm_indicator_data.tcd25f), " & _
                                 " mm_indicator_data_total.tcdtotalmasculino = (mm_indicator_data.tcd14m+mm_indicator_data.tcd1524m+mm_indicator_data.tcd25m), " & _
                                 " mm_indicator_data_total.tcdtotal = (mm_indicator_data.tcd14f + mm_indicator_data.tcd14m + mm_indicator_data.tcd1524f + mm_indicator_data.tcd1524m + mm_indicator_data.tcd25f + mm_indicator_data.tcd25m) " & _
                                 " where 	mm_indicator_data_total.report_id=mm_indicator_data.report_id and " & _
                                 " mm_indicator_data.report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Gravidas Inscritas Femininos Menores de 15 Anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,obs " & _
                            " where v_encounter.patient_id=obs.encounter_id and obs.concept_id=1279 " & _
                            " and " & condicaoFemininoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set gi14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Gravidas Inscritas Femininos 15-24 Anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,obs " & _
                            " where v_encounter.patient_id=obs.encounter_id and obs.concept_id=1279 " & _
                            " and " & condicaoFeminino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set gi1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Gravidas Inscritas Femininos maior 25 Anos
            .CommandText = "select count(distinct(v_encounter.patient_id)) from v_encounter,obs " & _
                            " where v_encounter.patient_id=obs.encounter_id and obs.concept_id=1279 " & _
                            " and " & condicaoFemininoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set gi25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Gravidas que Iniciaram TARV menores de 15 anos
            .CommandText = " select count(distinct v_pacientes_tarv.patient_id) from v_encounter,v_pacientes_tarv,obs " & _
                            " where v_pacientes_tarv.patient_id=v_encounter.patient_id and obs.encounter_id=v_encounter.encounter_id and " & _
                            " obs.concept_id=1279 " & _
                            " and " & condicaoFemininoMenor14

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set gt14f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Gravidas que Iniciaram TARV Entre 15 a 24 anos
            .CommandText = " select count(distinct v_pacientes_tarv.patient_id) from v_encounter,v_pacientes_tarv,obs " & _
                            " where v_pacientes_tarv.patient_id=v_encounter.patient_id and obs.encounter_id=v_encounter.encounter_id and " & _
                            " obs.concept_id=1279 " & _
                            " and " & condicaoFeminino1524

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set gt1524f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()

            'Gravidas que Iniciaram TARV Entre 15 a 24 anos
            .CommandText = " select count(distinct v_pacientes_tarv.patient_id) from v_encounter,v_pacientes_tarv,obs " & _
                            " where v_pacientes_tarv.patient_id=v_encounter.patient_id and obs.encounter_id=v_encounter.encounter_id and " & _
                            " obs.concept_id=1279 " & _
                            " and " & condicaoFemininoMaior25

            valor = .ExecuteScalar

            cmmrpt.CommandText = "Update mm_indicator_data set gt25f=" & valor & " where report_id=" & idPrint & ""
            cmmrpt.ExecuteNonQuery()


        End With

    End Sub

    Private Shared Sub fillCumulativeLastMonth(ByVal rpt As MMReportVO, ByVal lastMonthPrinted As Boolean)
        Dim rsA As MySqlDataReader
        Dim rsBC As MySqlDataReader
        Dim ds As New DataSet

        Dim cmmA As New MySqlCommand
        Dim cmmBC As New MySqlCommand

        Dim cmmUpdate As New MySqlCommand

        Dim valorA As Int32 = 0
        Dim valorB As Int32 = 0
        Dim valorC As Int32 = 0

        Dim yearOfLastMonth As Int16 = rpt.Year
        Dim lastMonth As Int16 = rpt.Month - 1

        If lastMonth = 0 Then
            lastMonth = 12
            yearOfLastMonth = yearOfLastMonth - 1
        End If

        cmmA.Connection = ConexaoOpenMRSReporting1
        cmmA.CommandType = CommandType.Text

        cmmBC.Connection = ConexaoOpenMRSReporting3
        cmmBC.CommandType = CommandType.Text

        cmmUpdate.Connection = ConexaoOpenMRSReporting2
        cmmUpdate.CommandType = CommandType.Text

        cmmA.CommandText = "Insert into mm_month_cumulative(report_id) values(" & rpt.ReportsID & ")"
        cmmA.ExecuteNonQuery()

        cmmA.CommandText = "Select mm_month_cumulative.* from mm_month_cumulative,month_report,report_print " & _
        " where report_print.reports_id=mm_month_cumulative.report_id and report_print.reports_id=month_report.report_id and " & _
        " report_print.voided=0 and report_print.hdd=" & rpt.Location.hddOpenMRSID & " and month_report.month=" & lastMonth & " and month_report.year=" & yearOfLastMonth & ""
        rsA = cmmA.ExecuteReader

        cmmBC.CommandText = "Select * from mm_indicator_data_total where report_id=" & rpt.ReportsID & ""
        rsBC = cmmBC.ExecuteReader

        If rsA.HasRows Then
            lastMonthPrinted = True
            rsBC.Read()
            rsA.Read()

            'Cumulativos no fim de Mes Feminino Menor 15
            valorA = rsA.GetInt32("cm14f")
            valorB = rsBC.GetInt32("te14f")
            valorC = rsBC.GetInt32("ts14f")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cm14f=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            'Cumulativos no fim de Mes Masculino Menor 15
            valorA = rsA.GetInt32("cm14m")
            valorB = rsBC.GetInt32("te14m")
            valorC = rsBC.GetInt32("ts14m")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cm14m=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            'Cumulativos no fim de Menor 15 total
            valorA = rsA.GetInt32("cm14total")
            valorB = rsBC.GetInt32("te14total")
            valorC = rsBC.GetInt32("ts14total")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cm14total=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            '=================================================================================
            'Cumulativos no fim de Feminino 15 a 24 anos
            valorA = rsA.GetInt32("cm1524f")
            valorB = rsBC.GetInt32("te1524f")
            valorC = rsBC.GetInt32("ts1524f")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cm1524f=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            'Cumulativos no fim de Masculino 15 a 24
            valorA = rsA.GetInt32("cm1524m")
            valorB = rsBC.GetInt32("te1524m")
            valorC = rsBC.GetInt32("ts1524m")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cm1524m=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            'Cumulativos no fim de 15 a 24 total
            valorA = rsA.GetInt32("cm1524total")
            valorB = rsBC.GetInt32("te1524total")
            valorC = rsBC.GetInt32("ts1524total")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cm1524total=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            '==================================================================================

            'Cumulativos no fim de Feminino maior de 25 anos
            valorA = rsA.GetInt32("cm25f")
            valorB = rsBC.GetInt32("te25f")
            valorC = rsBC.GetInt32("ts25f")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cm25f=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            'Cumulativos no fim de Masculino maior de 25 anos
            valorA = rsA.GetInt32("cm25m")
            valorB = rsBC.GetInt32("te25m")
            valorC = rsBC.GetInt32("ts25m")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cm25m=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            'Cumulativos no fim de 15 a 24 total
            valorA = rsA.GetInt32("cm25total")
            valorB = rsBC.GetInt32("te25total")
            valorC = rsBC.GetInt32("ts25total")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cm25total=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            '==================================================================================

            'Cumulativos no fim de Total Feminino
            valorA = rsA.GetInt32("cmtotalfeminino")
            valorB = rsBC.GetInt32("tetotalfeminino")
            valorC = rsBC.GetInt32("tstotalfeminino")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cmtotalfeminino=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            'Cumulativos no fim de Masculino maior de 25 anos
            valorA = rsA.GetInt32("cmtotalmasculino")
            valorB = rsBC.GetInt32("tetotalmasculino")
            valorC = rsBC.GetInt32("tstotalmasculino")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cmtotalmasculino=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()

            'Cumulativos no fim de 15 a 24 total
            valorA = rsA.GetInt32("cmtotal")
            valorB = rsBC.GetInt32("tetotal")
            valorC = rsBC.GetInt32("tstotal")
            cmmUpdate.CommandText = "Update mm_month_cumulative set cmtotal=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            cmmUpdate.ExecuteNonQuery()
        Else
            lastMonthPrinted = False
            'Exit Sub
            'rsBC.Read()

            ''Cumulativos no fim de Mes Feminino Menor 15
            ''valorA = rsA.GetInt32("cm14f")
            'valorB = rsBC.GetInt32("te14f")
            'valorC = rsBC.GetInt32("ts14f")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cm14f=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''Cumulativos no fim de Mes Masculino Menor 15
            ''valorA = rsA.GetInt32("cm14m")
            'valorB = rsBC.GetInt32("te14m")
            'valorC = rsBC.GetInt32("ts14m")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cm14m=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''Cumulativos no fim de Menor 15 total
            ''valorA = rsA.GetInt32("cm14total")
            'valorB = rsBC.GetInt32("te14total")
            'valorC = rsBC.GetInt32("ts14total")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cm14total=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''=================================================================================
            ''Cumulativos no fim de Feminino 15 a 24 anos
            ''valorA = rsA.GetInt32("cm1524f")
            'valorB = rsBC.GetInt32("te1524f")
            'valorC = rsBC.GetInt32("ts1524f")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cm1524f=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''Cumulativos no fim de Masculino 15 a 24
            ''valorA = rsA.GetInt32("cm1524m")
            'valorB = rsBC.GetInt32("te1524m")
            'valorC = rsBC.GetInt32("ts1524m")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cm1524m=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''Cumulativos no fim de 15 a 24 total
            ''valorA = rsA.GetInt32("cm1524total")
            'valorB = rsBC.GetInt32("te1524total")
            'valorC = rsBC.GetInt32("ts1524total")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cm1524total=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''==================================================================================

            ''Cumulativos no fim de Feminino maior de 25 anos
            ''valorA = rsA.GetInt32("cm25f")
            'valorB = rsBC.GetInt32("te25f")
            'valorC = rsBC.GetInt32("ts25f")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cm25f=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''Cumulativos no fim de Masculino maior de 25 anos
            ''valorA = rsA.GetInt32("cm25m")
            'valorB = rsBC.GetInt32("te25m")
            'valorC = rsBC.GetInt32("ts25m")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cm25m=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''Cumulativos no fim de 15 a 24 total
            ''valorA = rsA.GetInt32("cm25total")
            'valorB = rsBC.GetInt32("te25total")
            'valorC = rsBC.GetInt32("ts25total")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cm25total=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''==================================================================================

            ''Cumulativos no fim de Total Feminino
            ''valorA = rsA.GetInt32("cmtotalfeminino")
            'valorB = rsBC.GetInt32("tetotalfeminino")
            'valorC = rsBC.GetInt32("tstotalfeminino")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cmtotalfeminino=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''Cumulativos no fim de Masculino maior de 25 anos
            ''valorA = rsA.GetInt32("cmtotalmasculino")
            'valorB = rsBC.GetInt32("tetotalmasculino")
            'valorC = rsBC.GetInt32("tstotalmasculino")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cmtotalmasculino=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

            ''Cumulativos no fim de 15 a 24 total
            ''valorA = rsA.GetInt32("cmtotal")
            'valorB = rsBC.GetInt32("tetotal")
            'valorC = rsBC.GetInt32("tstotal")
            'cmmUpdate.CommandText = "Update mm_month_cumulative set cmtotal=" & ((valorA + valorB) - valorC) & " where report_id=" & rpt.ReportsID & ""
            'cmmUpdate.ExecuteNonQuery()

        End If
        FechaResultSet(rsA)
        FechaResultSet(rsBC)
    End Sub

    Public Shared Sub PrepararFrida()
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3
        'MsgBox(cmmrpt.Connection.ConnectionTimeout)
        cmmrpt.CommandText = "CALL UpdateFridaReporting()"
        cmmrpt.ExecuteScalar()

        cmmrpt.CommandText = "CALL FillSaidaManutencaoTARVTables()"
        cmmrpt.ExecuteScalar()

        'Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        'Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        'Dim idPrint As Integer = rpt.ReportsID
        'Dim hdd As Integer = rpt.Hdd
    End Sub
    Public Shared Sub PrepararGravidas()
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3
        'MsgBox(cmmrpt.Connection.ConnectionTimeout)
        cmmrpt.CommandText = "CALL GravidaSeguimento()"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL GravidasInscritas()"
        cmmrpt.ExecuteNonQuery()

        'Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        'Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        'Dim idPrint As Integer = rpt.ReportsID
        'Dim hdd As Integer = rpt.Hdd
    End Sub

    Public Shared Sub PrepararGravidasNEW()
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)
        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3
        cmmrpt.CommandText = "CALL managegravidas()"
        cmmrpt.ExecuteNonQuery()
    End Sub

    Public Shared Sub PrepararTempTARV()
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)
        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3
        cmmrpt.CommandText = "truncate table temp_tarv_anterior"
        cmmrpt.ExecuteNonQuery()
        cmmrpt.CommandText = "insert into temp_tarv_anterior " & _
                            " select  distinct obs.person_id,e.encounter_datetime" & _
                            " from 	openmrs.obs," & _
                            "       (   select encounter_id,d.encounter_datetime" & _
                            "           from openmrs.encounter," & _
                            "               (   select patient.patient_id,max(encounter_datetime) as encounter_datetime" & _
                            "                   from openmrs.encounter, openmrs.patient " & _
                            "                   where 	encounter_type=18 and " & _
                            "                           patient.patient_id=encounter.patient_id and" & _
                            "                           encounter.voided = 0 And patient.voided = 0" & _
                            "                   group by patient_id" & _
                            "               ) d" & _
                            "           where 	encounter.encounter_datetime=d.encounter_datetime and " & _
                            "           d.patient_id = encounter.patient_id And encounter.voided = 0" & _
                            "        ) e" & _
                            " where 	obs.encounter_id=e.encounter_id and" & _
                            " obs.concept_id=1255 and obs.voided=0 and" & _
                            " obs.value_coded<>1708"
        cmmrpt.ExecuteNonQuery()
    End Sub


    Public Shared Sub CalcularIncritos(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL MM_INSCRITOSANTERIOR('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_INSCRITOSNESTEMES('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub CalcularIncritosNEW(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_INSCRITOSANTERIORNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_INSCRITOSNESTEMESNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularIncritosNEW_(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_INSCRITOSANTERIORNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_INSCRITOSNESTEMESNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularConsultasClinicas(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL MM_CONSULTASCLINICAS('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        'cmmrpt.CommandText = "CALL MM_CONSULTASCLINICASNAOTARV('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & ")"
        'cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularConsultasClinicasNEW(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_CONSULTASCLINICASNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()
    End Sub
    Public Shared Sub CalcularConsultasClinicasNEW_(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_CONSULTASCLINICASNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()
    End Sub
    Public Shared Sub CalcularTARVEntradas(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL MM_TARVENTRADASNOVOS('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVENTRADASREINICIADOS('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVENTRADASTRANSFERIDOSDE('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularTARVEntradasNEW(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital


        cmmrpt.CommandText = "CALL MM_TARVENTRADASNOVOSNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVENTRADASREINICIADOSNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVENTRADASTRANSFERIDOSDENEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularTARVEntradasNEW_(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital


        cmmrpt.CommandText = "CALL MM_TARVENTRADASNOVOSNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVENTRADASREINICIADOSNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVENTRADASTRANSFERIDOSDENEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularTARVSaidas(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL MM_TARVESAIDASSUSPENSOS('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVESAIDASTRANSFERIDOSPARA('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVESAIDASABANDONO('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVESAIDASOBITO('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub CalcularTARVSaidasNEW(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital


        cmmrpt.CommandText = "CALL MM_TARVESAIDASSUSPENSOSNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVESAIDASTRANSFERIDOSPARANEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVESAIDASABANDONONEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVESAIDASOBITONEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub CalcularTARVSaidasNEW_(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital


        cmmrpt.CommandText = "CALL MM_TARVESAIDASSUSPENSOSNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVESAIDASTRANSFERIDOSPARANEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVESAIDASABANDONONEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_TARVESAIDASOBITONEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularCumulativo(ByVal rpt As MMReportVO)

        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim yearOfLastMonth As Int16 = rpt.Year
        Dim lastMonth As Int16 = rpt.Month - 1

        If lastMonth = 0 Then
            lastMonth = 12
            yearOfLastMonth = yearOfLastMonth - 1
        End If

        cmmrpt.CommandText = "CALL MM_CUMULATIVOESTEMES(" & lastMonth & "," & yearOfLastMonth & "," & hdd & "," & idPrint & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularCumulativoNEW(ByVal rpt As MMReportVO)

        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital
        Dim idPrint As Integer = rpt.ReportsID

        'cmmrpt.CommandText = "CALL MM_CUMULATIVOESTEMESRunTimeNEW('" & dataInicial & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & ")"
        cmmrpt.CommandText = "CALL MM_CUMULATIVOMESANTERIORRunTimeNEW('" & dataInicial & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & ")"

        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularCumulativoNEW_(ByVal rpt As MMReportVO)

        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital
        Dim idPrint As Integer = rpt.ReportsID

        'cmmrpt.CommandText = "CALL MM_CUMULATIVOESTEMESRunTimeNEW('" & dataInicial & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & ")"
        cmmrpt.CommandText = "CALL MM_CUMULATIVOMESANTERIORRunTimeNEW_('" & dataInicial & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & ")"

        cmmrpt.ExecuteNonQuery()

    End Sub


    Public Shared Sub Validade(ByVal rpt As MMReportVO)

        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital
        Dim idPrint As Integer = rpt.ReportsID
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)

        'cmmrpt.CommandText = "CALL MM_CUMULATIVOESTEMESRunTimeNEW('" & dataInicial & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & ")"
        cmmrpt.CommandText = "CALL MM_VALIDATE('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & ")"

        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub CalcularTratamentoTB(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        

        cmmrpt.CommandText = "CALL MM_TBINSCRITOS('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularTratamentoTBNEW(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_TBINSCRITOSNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"

        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularTratamentoTBNEW_(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID
        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_TBINSCRITOSNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"

        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularTARVReferidoCD(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL MM_TARVREFERIDOCD('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularTARVReferidoCDNEW(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_TARVREFERIDOCDNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"

        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularTARVReferidoCDNEW_(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_TARVREFERIDOCDNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"

        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularGravidas(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL MM_GRAVIDASINSCRITAS('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_GRAVIDASINICIOTARV('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub CalcularGravidasNEW(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_GRAVIDASINSCRITASNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_GRAVIDASINICIOTARVNEW('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularGravidasNEW_(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        cmmrpt.CommandText = "CALL MM_GRAVIDASINSCRITASNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "CALL MM_GRAVIDASINICIOTARVNEW_('" & dataInicial & "','" & dataFinal & "'," & hdd & ",'" & distrioID & "'," & distital & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub

    Public Shared Sub insertInitial(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand

        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim idPrint As Integer = rpt.ReportsID

        cmmrpt.CommandText = "Insert into mm_indicator_data(report_id) values(" & idPrint & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "Insert into mm_indicator_data_total(report_id) values(" & idPrint & ")"
        cmmrpt.ExecuteNonQuery()

        cmmrpt.CommandText = "Insert into mm_month_cumulative(report_id) values(" & idPrint & ")"
        cmmrpt.ExecuteNonQuery()
    End Sub

    'Funcoes para novo 
    Public Shared Sub insertInitialNovo(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand

        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim idPrint As Integer = rpt.ReportsID

        cmmrpt.CommandText = "Insert into mm_indicator_data(report_id,ic14f,ic14m,ic1524f,ic1524m,ic25f,ic25m,ni14f," & _
                            "ni14m,ni1524f,ni1524m,ni25f,ni25m,cct14f,cct14m,cct1524f,cct1524m,cct25f,cct25m,ccnt14f," & _
                            "ccnt14m,ccnt1524f,ccnt1524m,ccnt25f,ccnt25m,tcant14f,tcant14m,tcant1524f,tcant1524m,tcant25f," & _
                            "tcant25m,en14f,en14m,en1524f,en1524m,en25f,en25m,er14f,er14m,er1524f,er1524m,er25f,er25m,et14f," & _
                            "et14m,et1524f,et1524m,et25f,et25m,ss14f,ss14m,ss1524f,ss1524m,ss25f,ss25m,st14f,st14m,st1524f," & _
                            "st1524m,st25f,st25m,sa14f,sa14m,sa1524f,sa1524m,sa25f,sa25m,so14f,so14m,so1524f,so1524m,so25f," & _
                            "so25m,etb14f,etb14m,etb1524f,etb1524m,etb25f,etb25m,tcd14f,tcd14m,tcd1524f,tcd1524m,tcd25f,tcd25m," & _
                            "gi14f,gi1524f,gi25f,gt14f,gt1524f,gt25f) " & _
                            "values(" & idPrint & ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," & _
                            "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)"
        cmmrpt.ExecuteNonQuery()
    End Sub

    Public Shared Sub FillProcessoTARVTablesForMonthReport(ByVal rpt As MMReportVO)
        
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        
        ExecuteFillProcessoTARVTable(dataFinal, 1)

    End Sub

    Public Shared Sub FillMMINDICATORDATA(ByVal rpt As MMReportVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        Dim distrioID As String = rpt.Location.hddDistrictID
        Dim distital As Boolean = rpt.Distrital

        If distital Then
            cmmrpt.CommandText = "CALL RELATORIOMENSALMISAUDISTRITAL_('" & dataInicial & "','" & dataFinal & "','" & distrioID & "'," & idPrint & "," & utilizador.UserID & ")"
        Else
            cmmrpt.CommandText = "CALL RELATORIOMENSALMISAUUS_('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        End If
        cmmrpt.ExecuteNonQuery()
    End Sub

    

End Class
