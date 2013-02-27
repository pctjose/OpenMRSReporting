Imports MySql.Data.MySqlClient
Public Class ReportDAO

    Public Shared Function insert(ByVal report As ReportVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "insert into report(reportname,reportdescription,program_id,frequency) " & _
                " values('" & report.Reportname & "','" & report.Reportdescription & "'," & report.Program.id & "," & report.Frequency.Id & ")"

                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox("Houve erro ao inserir Relatorio." & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function getReportByID(ByVal id As Integer) As ReportVO
        Dim rs As MySqlDataReader
        Dim report As New ReportVO
        ReabreConexao(ConexaoOpenMRSReporting2)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting2
                .CommandType = CommandType.Text
                .CommandText = "Select report.* from report " & _
                " where id=" & id & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()

                    report.Id = rs.GetInt16("id")
                    report.Reportname = rs.GetString("reportname")
                    report.Reportdescription = VerificaRS(rs, 2)
                    report.Program = ProgramDAO.getProgramByID(rs.GetInt16("program_id"))
                    report.Frequency = FrequencyDAO.getFrequencyByID(rs.GetInt16("frequency"))
                    

                End If

                FechaResultSet(rs)
            End With
            Return report
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar relatorio." & ex.Message)
            Return report
        End Try
        Return Nothing
    End Function
    
End Class
