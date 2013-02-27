Imports MySql.Data.MySqlClient
Public Class ReportPrintDAO
    Public Shared Function insert(ByVal rpt As ReportPrintVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting3)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting3
                .CommandType = CommandType.Text
                .CommandText = "insert into report_print(Location,Report_Date_Range_Start,Report_Date_Range_End," & _
                " Date_Created,Created_By,Voided,Voided_By,Voided_Date,Voided_Reason,Report_print_report) " & _
                " values(" & rpt.Location.hddOpenMRSID & ",'" & dataMySQL(rpt.ReportDateRangeStart) & "','" & dataMySQL(rpt.ReportDateRangeEnd) & "'," & _
                " now()," & rpt.CreatedBy.UserID & ",0,null,null,null," & rpt.Report.Id & ")"
                .ExecuteNonQuery()
                .CommandText = "Select max(Reports_ID) from report_print"
                rpt.ReportsID = .ExecuteScalar
            End With
            Return True
        Catch ex As Exception
            MsgBox("Houve erro ao inserir relatorio." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function getPrintReportByID(ByVal id As Integer) As ReportPrintVO
        Dim rs As MySqlDataReader
        Dim report As New ReportPrintVO
        ReabreConexao(ConexaoOpenMRSReporting3)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting3
                .CommandType = CommandType.Text
                .CommandText = "Select report_print.* from report_print " & _
                " where report_print.Reports_ID=" & id & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    report.ReportsID = rs.GetInt32("Reports_ID")
                    report.Location = HddDAO.getHddByOpenMRSID(rs.GetInt32("Location"))
                    report.ReportDateRangeStart = dataMicrosoft(rs.GetMySqlDateTime("Report_Date_Range_Start"))
                    report.ReportDateRangeEnd = dataMicrosoft(rs.GetMySqlDateTime("Report_Date_Range_End"))
                    report.DateCreated = dataMicrosoft(rs.GetMySqlDateTime("Date_Created"))
                    report.CreatedBy = UserDAO.getUserByID(rs.GetInt16("Created_By"))
                    report.Voided = rs.GetBoolean("Voided")
                    If report.Voided Then
                        report.VoidedBy = UserDAO.getUserByID(rs.GetInt16("Voided_By"))
                        report.VoidedDate = dataMicrosoft(rs.GetMySqlDateTime("Voided_Date"))
                        report.VoidedReason = rs.GetString("Voided_Reason")
                    End If
                    report.Report = ReportDAO.getReportByID(rs.GetInt16("Report_print_report"))
                End If

                FechaResultSet(rs)
            End With
            Return report
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar relatorio." & ex.Message)
            Return report
        End Try
    End Function

    Public Shared Function getPrintReportByHDDDateRangeReport(ByVal location As Int16, ByVal dataInicial As Date, ByVal DataFinal As Date, ByVal reportID As Int16) As ReportPrintVO
        Dim rs As MySqlDataReader
        Dim report As New ReportPrintVO
        ReabreConexao(ConexaoOpenMRSReporting3)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting3
                .CommandType = CommandType.Text
                .CommandText = "Select report_print.* from report_print " & _
                " where Location=" & location & " and Report_Date_Range_Start='" & dataMySQL(dataInicial) & "' and Report_Date_Range_End='" & dataMySQL(DataFinal) & "' and Report_print_report=" & reportID & " and Voided=0"
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    report.ReportsID = rs.GetInt32("Reports_ID")
                    report.Location = HddDAO.getHddByOpenMRSID(rs.GetInt32("Location"))
                    report.ReportDateRangeStart = dataMicrosoft(rs.GetMySqlDateTime("Report_Date_Range_Start"))
                    report.ReportDateRangeEnd = dataMicrosoft(rs.GetMySqlDateTime("Report_Date_Range_End"))
                    report.DateCreated = dataMicrosoft(rs.GetMySqlDateTime("Date_Created"))
                    report.CreatedBy = UserDAO.getUserByID(rs.GetInt16("Created_By"))
                    report.Voided = rs.GetBoolean("Voided")
                    If report.Voided Then
                        report.VoidedBy = UserDAO.getUserByID(rs.GetInt16("Voided_By"))
                        report.VoidedDate = dataMicrosoft(rs.GetMySqlDateTime("Voided_Date"))
                        report.VoidedReason = rs.GetString("Voided_Reason")
                    End If
                    report.Report = ReportDAO.getReportByID(rs.GetInt16("Report_print_report"))
                End If

                FechaResultSet(rs)
            End With
            Return report
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar relatorio." & ex.Message)
            Return report
        End Try
    End Function

    Public Shared Function void(ByVal rpt As ReportPrintVO) As Boolean
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting3
                .CommandType = CommandType.Text
                .CommandText = "update report_print set " & _
                " Voided=1,Voided_By='" & rpt.VoidedBy.UserID & "',Voided_Date=now()," & _
                " Voided_Reason='" & rpt.VoidedReason & "' where Reports_ID=" & rpt.ReportsID & " "
                .ExecuteNonQuery()
                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao anular relatorio." & ex.Message)
            Return False
        End Try
    End Function
End Class
