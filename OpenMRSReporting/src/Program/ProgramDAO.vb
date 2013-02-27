Imports MySql.Data.MySqlClient
Public Class ProgramDAO
    Public Shared Function insert(ByVal program As ProgramVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "insert into program(program,description,active) " & _
                " values('" & program.Program & "','" & program.Description & "'," & program.Active & ")"

                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox("Houve erro ao inserir Programa." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function getProgramByID(ByVal id As Integer) As ProgramVO
        Dim rs As MySqlDataReader
        Dim program As New ProgramVO
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "Select program.* from program " & _
                " where id=" & id & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    program.id = rs.GetInt16("id")
                    program.Program = rs.GetString("program")
                    program.Description = VerificaRS(rs, 2)
                    program.Active = rs.GetBoolean("active")
                    
                End If

                FechaResultSet(rs)
            End With
            Return program
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Programa." & ex.Message)
            Return program
        End Try
    End Function
    Public Shared Function getProgramByName(ByVal name As String) As ProgramVO
        Dim rs As MySqlDataReader
        Dim program As New ProgramVO
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "Select program.* from program " & _
                " where program=" & name & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    program.id = rs.GetInt16("id")
                    program.Program = rs.GetString("program")
                    program.Description = VerificaRS(rs, 2)
                    program.Active = rs.GetBoolean("active")

                End If

                FechaResultSet(rs)
            End With
            Return program
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Programa." & ex.Message)
            Return program
        End Try
    End Function
End Class
