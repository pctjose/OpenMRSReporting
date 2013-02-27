Imports MySql.Data.MySqlClient
Public Class FrequencyDAO
    Public Shared Function insert(ByVal fr As FrequencyVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text

                .CommandText = "Select max(id) from frequency"
                fr.Id = .ExecuteScalar
                fr.Id = fr.Id + 1
                .CommandText = "insert into frequency(id,frequency,active) " & _
                " values(" & fr.Id & ",'" & fr.Frequency & "'," & fr.Active & ")"
                .ExecuteNonQuery()

                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao inserir Frequencia de Impressao do Relatorio." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function getFrequencyByID(ByVal id As Int16) As FrequencyVO
        Dim rs As MySqlDataReader
        Dim fr As New FrequencyVO
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "Select id,frequency,active from frequency " & _
                " where id=" & id & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    fr.Id = rs.GetInt16("id")
                    fr.Frequency = rs.GetString("frequency")
                    fr.Active = rs.GetBoolean("active")
                End If

                FechaResultSet(rs)
            End With
            Return fr
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Frequencia." & ex.Message)
            Return fr
        End Try
    End Function
    Public Shared Function getFrequencyByFrequency(ByVal frequency As String) As FrequencyVO
        Dim rs As MySqlDataReader
        Dim fr As New FrequencyVO
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "Select id,frequency,active from frequency " & _
                " where frequency='" & frequency & "'"
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    fr.Id = rs.GetInt16("id")
                    fr.Frequency = rs.GetString("frequency")
                    fr.Active = rs.GetBoolean("active")
                End If

                FechaResultSet(rs)
            End With
            Return fr
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Frequencia." & ex.Message)
            Return fr
        End Try
    End Function
End Class
