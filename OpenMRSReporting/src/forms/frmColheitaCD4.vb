Public Class frmColheitaCD4
    'Public isUpdate As Boolean

    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        Try
            'If Not isUpdate Then
            Me.DataGridView1.CurrentRow.Cells("DataColheita").Value = Today.Day & "/" & Today.Month & "/" & Today.Year
            Me.DataGridView1.CurrentRow.Cells("NID").Value = My.Settings.DefaultHddNID & "/"
            Me.DataGridView1.CurrentRow.Cells("Sexo").Value = "F"
            'End If


        Catch ex As Exception

        End Try
    End Sub
    Private Function validarDados(ByVal dg As DataGridView) As Int16
        For Each dgItem As DataGridViewRow In dg.Rows

            If dgItem.Index = Me.DataGridView1.RowCount - 1 Then
                Exit For
            End If

            If IsDBNull(dgItem.Cells(0).Value) Then
                Return 1
            ElseIf String.IsNullOrEmpty(dgItem.Cells(0).Value) Then
                Return 1
            End If

            If IsDBNull(dgItem.Cells(1).Value) Then
                Return 2
            ElseIf String.IsNullOrEmpty(dgItem.Cells(1).Value) Then
                Return 2
            End If

            If IsDBNull(dgItem.Cells(2).Value) Then
                Return 3
            ElseIf String.IsNullOrEmpty(dgItem.Cells(2).Value) Then
                Return 3
            ElseIf Not IsNumeric(dgItem.Cells(2).Value) Then
                Return 3
            End If

            If IsDBNull(dgItem.Cells(3).Value) Then
                Return 4
            ElseIf String.IsNullOrEmpty(dgItem.Cells(3).Value) Then
                Return 4
            End If

            If IsDBNull(dgItem.Cells(5).Value) Then
                Return 5
            ElseIf String.IsNullOrEmpty(dgItem.Cells(5).Value) Then
                Return 5
            ElseIf Not IsDate(dgItem.Cells(5).Value) Then
                Return 5
            End If

        Next

        Return 0
    End Function

    Private Sub frmColheitaCD4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If Me.cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If

        'If isUpdate Then
        '    Me.DataGridView1.Columns("DataRecepcao").Visible = True
        'Else
        '    Me.DataGridView1.Columns("DataRecepcao").Visible = False
        'End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Try
            Dim strQuery As String


            Dim erro As Integer = validarDados(Me.DataGridView1)
            If erro <> 0 Then
                Select Case erro
                    Case 1
                        MsgBox("Existe um nome não preenchido ou mal preechido")
                        Exit Sub
                    Case 2
                        MsgBox("Existe sexo não preenchido ou mal preechido")
                        Exit Sub
                    Case 3
                        MsgBox("Existe idade não preenchida ou mal preechida")
                        Exit Sub
                    Case 4
                        MsgBox("Existe um NID não preenchido ou mal preechido")
                        Exit Sub
                    Case 5
                        MsgBox("Existe data de colheita não preenchida ou mal preechida")
                        Exit Sub
                End Select
            End If



            For Each dgItem As DataGridViewRow In DataGridView1.Rows
                If dgItem.Index = Me.DataGridView1.RowCount - 1 Then
                    Exit For
                End If
                If (IsDBNull(dgItem.Cells(7).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(7).Value)) Then
                    strQuery = "insert into colheita_cdquatro(nid,nome,sexo,idade,data_colheita,gravida,location_id,uuid,data_recepcao) " & _
                                        " Values('" & dgItem.Cells(3).Value & "','" & dgItem.Cells(0).Value & "','" & dgItem.Cells(1).Value & "'," & _
                                        " " & dgItem.Cells(2).Value & ",'" & dataMySQL(dgItem.Cells(5).Value) & "'," & _
                                        " " & IIf(dgItem.Cells(4).Value, True, False) & "," & cboUS.SelectedValue & ",uuid()," & _
                                        " " & IIf((IsDBNull(dgItem.Cells(6).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(6).Value)) Or (Not IsDate(dgItem.Cells(6).Value)), "null", addQuote(dataMySQL(dgItem.Cells(6).Value))) & ")"
                Else

                    strQuery = "update colheita_cdquatro set nid='" & dgItem.Cells(3).Value & "',nome='" & dgItem.Cells(0).Value & "'" & _
                            " ,sexo='" & dgItem.Cells(1).Value & "',idade=" & dgItem.Cells(2).Value & ",data_colheita='" & dataMySQL(dgItem.Cells(5).Value) & "'," & _
                            " gravida=" & IIf(dgItem.Cells(4).Value, True, False) & ",data_recepcao=" & IIf((IsDBNull(dgItem.Cells(6).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(6).Value)) Or (Not IsDate(dgItem.Cells(6).Value)), "null", addQuote(dataMySQL(dgItem.Cells(6).Value))) & "  " & _
                            " where uuid='" & dgItem.Cells(7).Value & "'"

                End If
                With cmm
                    .Connection = ConexaoOpenMRSReporting1
                    .CommandText = strQuery
                    .CommandType = CommandType.Text
                    .ExecuteNonQuery()
                End With

            Next
            MsgBox("Registo/Actualização efectuada.")
        Catch ex As Exception
            MsgBox("Houve Erro: " & ex.Message)
        End Try
        

    End Sub
    Private Function addQuote(ByVal valor As String) As String
        valor = valor.Insert(0, "'")
        valor = valor.Insert(valor.Length, "'")
        Return valor
    End Function

    Private Sub cboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.SelectedIndexChanged
        Try
            Dim strCriterio = " distritoid='" & Me.cboDistrito.SelectedValue & "' and openmrs_id is not null"
            EncherCombo1(Me.cboUS, "nomeus", "hdd", "openmrs_id", strCriterio)
            If cboUS.Items.Count > 0 Then
                cboUS.SelectedValue = My.Settings.DefaultHddID
                'cboUS_SelectedIndexChanged(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        Try
            EncherCombo(Me.cboDistrito, "nome", "district", "DistritoID", "ProvinciaID", , Me.cboProvincia.SelectedValue)
            If Me.cboDistrito.Items.Count > 0 Then
                Me.cboDistrito.SelectedValue = My.Settings.DefaultDistrictID
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub filtrar(ByVal dataInicial As Date, ByVal dataFinal As Date, ByVal localId As Integer, Optional ByVal recebidas As Boolean = False, Optional ByVal naoRecebidas As Boolean = False)
        Me.DataGridView1.Rows.Clear()
        Dim strQuery As String = "Select nome,sexo,idade,nid,gravida,data_colheita,data_recepcao,uuid from colheita_cdquatro where data_colheita between '" & dataMySQL(dataInicial) & "' and " & _
        " '" & dataMySQL(dataFinal) & "' and location_id=" & localId & " "
        If recebidas Then
            strQuery &= " and data_recepcao is not null"
        End If

        If naoRecebidas Then
            strQuery &= " and data_recepcao is null"
        End If
        Dim rs As MySql.Data.MySqlClient.MySqlDataReader
        Dim nome As Object
        Dim sexo As Object
        Dim idade As Object
        Dim nid As Object
        Dim gravida As Object
        Dim dataColheita As Object
        Dim dataRecepcao As Object
        Dim uuid As Object

        With cmm
            .Connection = ConexaoOpenMRSReporting1
            .CommandText = strQuery
            .CommandType = CommandType.Text
            rs = .ExecuteReader
            If rs.HasRows Then
                While rs.Read
                    nome = verificaNulo(rs, 0)
                    sexo = verificaNulo(rs, 1)
                    idade = verificaNulo(rs, 2)
                    nid = verificaNulo(rs, 3)
                    gravida = verificaNulo(rs, 4)
                    dataColheita = verificaNulo(rs, 5)
                    dataRecepcao = verificaNulo(rs, 6)
                    uuid = verificaNulo(rs, 7)
                    If dataRecepcao.ToString.Contains("System") Then
                        dataRecepcao = Nothing
                    Else
                        If dataRecepcao.ToString.Length > 10 Then
                            dataRecepcao = dataRecepcao.ToString.Substring(0, 10)
                        End If
                    End If

                    If dataColheita.ToString.Contains("System") Then
                        dataColheita = Nothing
                    Else
                        If dataColheita.ToString.Length > 10 Then
                            dataColheita = dataColheita.ToString.Substring(0, 10)
                        End If
                    End If

                    Dim oneDimArray() As Object = {nome, sexo, idade, nid, gravida, dataColheita, dataRecepcao, uuid}

                    Me.DataGridView1.Rows.Add(oneDimArray)
                End While
                'rs.Close()
            End If
        End With
        If Not rs.IsClosed Then
            rs.Close()
        End If

    End Sub
    Private Function verificaNulo(ByVal rs As MySql.Data.MySqlClient.MySqlDataReader, ByVal coluna As Integer) As Object
        If rs.IsDBNull(coluna) Then
            Return New Object
        Else
            Return rs.GetValue(coluna)

        End If
    End Function

    Private Sub cboUS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUS.SelectedIndexChanged
        Try
            'If isUpdate Then
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, chkRecebidas.Checked, chkNaoRecebidas.Checked)
            'End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dataInicial_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataInicial.ValueChanged
        Try
            'If isUpdate Then
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, chkRecebidas.Checked, chkNaoRecebidas.Checked)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dataFinal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataFinal.ValueChanged
        Try
            'If isUpdate Then
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, chkRecebidas.Checked, chkNaoRecebidas.Checked)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkRecebidas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNaoRecebidas.CheckedChanged

        If Me.chkNaoRecebidas.Checked Then
            Me.chkRecebidas.Checked = False
        End If

        Try
            'If isUpdate Then
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, chkRecebidas.Checked, chkNaoRecebidas.Checked)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.DataGridView1.RowCount <= 0 Then
                MsgBox("Não há dados para exportar...")
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            ExportToExcel(Me.DataGridView1, xlsOption.xlsOpen)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub chkRecebidas_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecebidas.CheckedChanged
        If Me.chkRecebidas.Checked Then
            Me.chkNaoRecebidas.Checked = False
        End If
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, chkRecebidas.Checked, chkNaoRecebidas.Checked)
        Catch ex As Exception

        End Try
    End Sub
End Class