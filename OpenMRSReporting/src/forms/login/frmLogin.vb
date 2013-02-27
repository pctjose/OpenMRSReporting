Public Class frmLogin
    Dim tentativas As Int16 = 0
    
    Private Sub cmdEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEntrar.Click
        ConexaoOpenMRS1 = Connexao.conectarOpenMRS
        ConexaoOpenMRS2 = Connexao.conectarOpenMRS
        ConexaoOpenMRS3 = Connexao.conectarOpenMRS

        ConexaoOpenMRSReporting1 = Connexao.conectarOpenMRSReporting
        ConexaoOpenMRSReporting2 = Connexao.conectarOpenMRSReporting
        ConexaoOpenMRSReporting3 = Connexao.conectarOpenMRSReporting

        Cursor = Cursors.WaitCursor
        utilizador = New UserVO

        utilizador = UserDAO.getUserByUserNameAndPassword(Me.txtUserName.Text, Me.txtPassword.Text)

        If Not utilizador.isNull Then


            If utilizador.Voided Then
                MsgBox("A sua conta foi desactivada." & vbNewLine & _
                "Consulte o administrador para activar a sua conta", vbApplicationModal + vbInformation, "Conta desactivada")
                End
            End If

            frmMain.Text = frmMain.Text & " (" & utilizador.Hdd.hddName & " : " & utilizador.Name & " )"
            'privilegios = GrupoUtilizadorDAO.getUserPrivilegios(utilizador)
            'loadPrivilegios(utilizador)
            'Conexao = Conexao 'cone.conectar
            'TabelaDinamica("Select * from mm_indicator_data")
            Dim hoje As String = dataMySQL(Today.Date)
            ExecuteFillProcessoTARVTable(hoje, 0)

            frmMain.Show()
            'frmToDo.Show()
            Me.Hide()
            
        Else
            tentativas = tentativas + 1

            If tentativas = 3 Then
                MsgBox("Nome do Usuario ou Senha Invalidos!" & vbNewLine & _
                "Tres (3) Tentativas Erradas, O sistema vai Fechar.", vbApplicationModal + vbInformation, tentativas & " Tentativas")
                fechaConexoes()
                End
            Else
                Beep()
                MsgBox("Nome de Usuario ou Senha Invalidos.", vbApplicationModal + vbInformation, tentativas & " Tentativa(s)")
                txtPassword.Text = ""
                txtPassword.Focus()
                fechaConexoes()
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        fechaConexoes()
        End
    End Sub


    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        centerForm(Me)
    End Sub
End Class
