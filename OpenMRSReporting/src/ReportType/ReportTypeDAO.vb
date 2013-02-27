Imports MySql.Data.MySqlClient
Public Class ReportTypeDAO
    Public Shared Function insert(ByVal rt As ReportTypeVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting2)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting2
                .CommandType = CommandType.Text

                .CommandText = "insert into report_type(Report_Type_Name,Report_Type_Description,Voided," & _
                "Voided_By,Voided_Date,Voided_Reason,Language_Language_ID,frequency_id) " & _
                " values('" & rt.ReportTypeName & "','" & rt.ReportTypeDescription & "',0,null,null,null," & rt.Language.LanguageID & "," & rt.Frequency.Id & ")"
                .ExecuteNonQuery()

                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao inserir Tipo de Relatorio." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function getReportTypeByID(ByVal id As Integer) As ReportTypeVO
        Dim rs As MySqlDataReader
        Dim rt As New ReportTypeVO
        ReabreConexao(ConexaoOpenMRSReporting2)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting2
                .CommandType = CommandType.Text
                .CommandText = "Select Report_Type_ID,Report_Type_Name,Report_Type_Description,Voided,Voided_By,Voided_Date,Voided_Reason,Language_Language_ID,frequency_id from report_type " & _
                " where Report_Type_ID=" & id & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    rt.ReportTypeID = rs.GetInt16("Report_Type_ID")
                    rt.ReportTypeName = rs.GetString("Report_Type_Name")
                    rt.ReportTypeDescription = VerificaRS(rs, 2)
                    rt.Voided = rs.GetBoolean("Voided")
                    rt.VoidedBy = VerificaRS(rs, 4)
                    rt.VoidedDate = VerificaRDate(rs, 5)
                    rt.VoidedReason = VerificaRS(rs, 6)
                    rt.Language = LanguageDAO.getLanguageByID(rs.GetInt16("Language_Language_ID"))
                    rt.Frequency = FrequencyDAO.getFrequencyByID(rs.GetInt16("frequency_id"))
                    
                End If

                FechaResultSet(rs)
            End With
            Return rt
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Report Type." & ex.Message)
            Return rt
        End Try
    End Function
End Class
