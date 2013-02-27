Imports MySql.Data.MySqlClient
Public Class LanguageDAO
    Public Shared Function insert(ByVal language As LanguageVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "insert into language(Language_ID,Language,Void," & _
                "Void_Date,Void_Reason) " & _
                " values(" & language.LanguageID & ",'" & language.LanguageName & "',0," & _
                "null,null)"
                .ExecuteNonQuery()

                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao inserir Lingua." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function update(ByVal language As LanguageVO) As Boolean
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "update language set Language='" & language.LanguageName & "',Void=" & language.Voided & "," & _
                "Void_Date='" & dataMySQL(language.VoidedDate) & "',Void_Reason='" & language.VoidReason & "') " & _
                " where Language_ID=" & language.LanguageID & ""
                .ExecuteNonQuery()

                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao Actualizar Lingua." & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function getLanguageByID(ByVal id As Integer) As LanguageVO
        Dim rs As MySqlDataReader
        Dim language As New LanguageVO
        ReabreConexao(ConexaoOpenMRSReporting1)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "Select * from language " & _
                " where Language_ID=" & id & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    language.LanguageID = rs.GetInt16("Language_ID")
                    language.LanguageName = rs.GetString("Language")
                    language.Voided = rs.GetBoolean("Void")
                    language.VoidedDate = VerificaRDate(rs, 3)
                    language.VoidReason = VerificaRS(rs, 4)
                End If

                FechaResultSet(rs)
            End With
            Return language
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Lingua." & ex.Message)
            Return language
        End Try
    End Function
End Class
