Imports MySql.Data.MySqlClient
Public Class IndicatorDAO
    Public Shared Function insert(ByVal indicator As IndicatorVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting2)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting2
                .CommandType = CommandType.Text

                .CommandText = "Select max(Indicators_ID) from indicator"
                indicator.IndicatorID = .ExecuteScalar
                indicator.IndicatorID = indicator.IndicatorID + 1

                .CommandText = "insert into indicator(Indicators_ID,access_id,Indicator_Name,Indicator_Description," & _
                "Indicator_Manual_Creation,Indicator_Business_Logic,Indicator_Electronic_Creation,Void,Void_Date,Void_Reason,Language_Language_ID,group_id,automatic) " & _
                " values(" & indicator.IndicatorID & "," & indicator.AccessID & ",'" & indicator.IndicatorName & "','" & indicator.IndicatorDescription & "'," & _
                " '" & indicator.IndicatorManualCreation & "','" & indicator.IndicaotrBusinessLogic & "','" & indicator.IndicatorElectronicCreation & "',0," & _
                "null,null," & indicator.Language.LanguageID & "," & indicator.IndicatorGroup.GroupID & "," & indicator.Automatic & ")"
                .ExecuteNonQuery()

                Return True

            End With
        Catch ex As Exception
            MsgBox("Error during indicator insert." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function getIndicatorByID(ByVal id As Int16, ByVal languageID As Int16) As IndicatorVO
        Dim rs As MySqlDataReader
        Dim indicator As New IndicatorVO
        ReabreConexao(ConexaoOpenMRSReporting2)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting2
                .CommandType = CommandType.Text
                .CommandText = "Select Indicators_ID,access_id,Indicator_Name,Indicator_Description,Indicator_Manual_Creation," & _
                " Indicator_Business_Logic,Indicator_Electronic_Creation,Void,Void_Date,Void_Reason,Language_Language_ID,group_id,automatic " & _
                " from indicator where Indicators_ID=" & id & " and Language_Language_ID=" & languageID & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    
                End If

                FechaResultSet(rs)
            End With
            Return indicator
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Frequencia." & ex.Message)
            Return indicator
        End Try
    End Function
End Class
