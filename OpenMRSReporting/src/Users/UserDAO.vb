Imports MySql.Data.MySqlClient
Public Class UserDAO
    Public Shared Function insert(ByVal user As UserVO) As Boolean
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "insert into user(userid,username,name,password,hddid," & _
                "voided,void_date,voided_by,void_reason) " & _
                " values(" & user.UserID & ",'" & user.UserName & "','" & user.Name & "',password('" & user.Password & "')," & _
                " " & user.Hdd.hddOpenMRSID & ",0,null,null,null)"
                .ExecuteNonQuery()

                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao inserir Utilizador." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function update(ByVal user As UserVO) As Boolean
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = "update user set username='" & user.UserName & "',name='" & user.Name & "',password=password('" & user.Password & "'),hddid=" & user.Hdd.hddOpenMRSID & "," & _
                " voided=" & user.Voided & ",void_date='" & dataMySQL(user.VoidedDate) & "',voided_by=" & user.VoidedBy.UserID & ",void_reason='" & user.VoidReason & "' " & _
                " where userid=" & user.UserID & ""

                .ExecuteNonQuery()

                Return True

            End With
        Catch ex As Exception
            MsgBox("Houve erro ao Actualizar Utilizador." & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function getUserByID(ByVal id As Integer) As UserVO
        Dim rs As MySqlDataReader
        Dim user As New UserVO
        ReabreConexao(ConexaoOpenMRSReporting2)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting2
                .CommandType = CommandType.Text
                .CommandText = "Select * from user " & _
                " where userid=" & id & ""
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    user.UserID = rs.GetInt16("userid")
                    user.UserName = rs.GetString("username")
                    user.Name = rs.GetString("name")
                    user.Voided = rs.GetBoolean("voided")
                    user.VoidedDate = VerificaRDate(rs, 6)
                    user.VoidReason = VerificaRS(rs, 8)
                    user.Hdd = HddDAO.getHddByOpenMRSID(rs.GetInt32("hddid"))
                    'user.DefaultLanguage = LanguageDAO.getLanguageByID(rs.GetInt16("defaultlanguageid"))
                    
                End If

                FechaResultSet(rs)
            End With
            Return user
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Utilizador." & ex.Message)
            Return user
        End Try
    End Function
    Public Shared Function getUserByUserNameAndPassword(ByVal username As String, ByVal pass As String) As UserVO
        Dim rs As MySqlDataReader
        Dim user As New UserVO
        ReabreConexao(ConexaoOpenMRSReporting2)
        Try
            With cmm
                .Connection = ConexaoOpenMRSReporting2
                .CommandType = CommandType.Text
                .CommandText = "Select * from user " & _
                " where username='" & username & "' and password=password('" & pass & "') "
                rs = .ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    user.UserID = rs.GetInt16("userid")
                    user.UserName = rs.GetString("username")
                    user.Name = rs.GetString("name")
                    user.Voided = rs.GetBoolean("voided")
                    user.VoidedDate = VerificaRDate(rs, 6)
                    user.VoidReason = VerificaRS(rs, 8)
                    user.Hdd = HddDAO.getHddByOpenMRSID(rs.GetInt32("hddid"))
                    'user.DefaultLanguage = LanguageDAO.getLanguageByID(rs.GetInt16("defaultlanguageid"))

                End If

                FechaResultSet(rs)
            End With
            Return user
        Catch ex As Exception
            MsgBox("Houve erro ao Carregar Utilizador." & ex.Message)
            Return user
        End Try
    End Function
End Class
