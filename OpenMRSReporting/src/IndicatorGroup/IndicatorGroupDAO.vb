Imports MySql.Data.MySqlClient
Public Class IndicatorGroupDAO
    Public Shared Function insert(ByVal ig As IndicatorGroupVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting2)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting2
                .CommandType = CommandType.Text

                .CommandText = "Select max(group_id) from indicator_group"
                ig.GroupID = .ExecuteScalar

                .CommandText = "insert into indicator_group(group_id,group_name,group_description," & _
                "voided,voided_date,voided_reason,voided_by) " & _
                " values(" & ig.GroupID & ",'" & ig.GroupName & "','" & ig.GroupDescription & "',0,null,null,null)"
                .ExecuteNonQuery()

                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao inserir Grupo de Indicador." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function getIndicatorGroupByID(ByVal id As Int16) As IndicatorGroupVO
        Dim rs As MySqlDataReader
        Dim ig As New IndicatorGroupVO
        ReabreConexao(ConexaoOpenMRSReporting2)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting2
                .CommandType = CommandType.Text
                .CommandText = "Select group_id,group_name,group_description,voided,voided_date,voided_reason,voided_by from indicator_group " & _
                " where group_id=" & id & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    ig.GroupID = id
                    ig.GroupName = rs.GetString("group_name")
                    ig.GroupDescription = VerificaRS(rs, 2)
                    ig.Voided = rs.GetBoolean("voided")
                    ig.VoidedDate = VerificaRDate(rs, 4)
                    ig.VoidReason = VerificaRS(rs, 5)
                End If

                FechaResultSet(rs)
            End With
            Return ig
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Frequencia." & ex.Message)
            Return ig
        End Try
    End Function
End Class
