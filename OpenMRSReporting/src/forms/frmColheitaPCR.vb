Public Class frmColheitaPCR
    'Public isUpdate As Boolean
    Private Sub frmColheitaPCR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If Me.cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
    End Sub
    Private Function verificaNulo(ByVal rs As MySql.Data.MySqlClient.MySqlDataReader, ByVal coluna As Integer) As Object
        If rs.IsDBNull(coluna) Then
            Return New Object
        Else
            Return rs.GetValue(coluna)
        End If
    End Function
    Private Sub filtrar(ByVal dataInicial As Date, ByVal dataFinal As Date, ByVal localId As Integer, Optional ByVal enviadas As Boolean = False, Optional ByVal recebidas As Boolean = False, _
                        Optional ByVal entregues As Boolean = False, Optional ByVal perdidos As Boolean = False, Optional ByVal naoEnviadas As Boolean = False, Optional ByVal naoRecebidas As Boolean = False, Optional ByVal naoEntregues As Boolean = False)
        Me.DataGridView1.Rows.Clear()
        Dim strQuery As String = "Select data_colheita,num_ordem,num_fea,nid_crianca,nome_apelido," & _
                                " sexo,idade,colheita,data_envio,data_chegada,resultado,data_entrega,resultado_perdido,uuid " & _
                                " from colheita_pcr where data_colheita between '" & dataMySQL(dataInicial) & "' and " & _
                                " '" & dataMySQL(dataFinal) & "' and location_id=" & localId & " "
        If enviadas Then
            strQuery &= " and data_envio is not null"
        End If

        If recebidas Then
            strQuery &= " and data_chegada is not null"
        End If

        If entregues Then
            strQuery &= " and data_entrega is not null"
        End If

        If perdidos Then
            strQuery &= " and resultado_perdido=1"
        End If


        If naoEnviadas Then
            strQuery &= " and data_envio is null"
        End If

        If naoRecebidas Then
            strQuery &= " and data_chegada is null"
        End If

        If naoEntregues Then
            strQuery &= " and data_entrega is null"
        End If

        Dim rs As MySql.Data.MySqlClient.MySqlDataReader

        Dim dataColheita As Object
        Dim numOrdem As Object
        Dim numFea As Object
        Dim nidCrianca As Object
        Dim nomeApelido As Object
        Dim sexo As Object
        Dim idade As Object
        Dim colheita As Object
        Dim dataEnvio As Object
        Dim dataChegada As Object
        Dim resultado As Object
        Dim dataEntrega As Object
        Dim resultadoPerdido As Object
        Dim uuid As Object

        With cmm
            .Connection = ConexaoOpenMRSReporting1
            .CommandText = strQuery
            .CommandType = CommandType.Text
            rs = .ExecuteReader
            If rs.HasRows Then
                While rs.Read

                    dataColheita = verificaNulo(rs, 0)
                    numOrdem = verificaNulo(rs, 1)
                    numFea = verificaNulo(rs, 2)
                    nidCrianca = verificaNulo(rs, 3)
                    nomeApelido = verificaNulo(rs, 4)
                    sexo = verificaNulo(rs, 5)
                    idade = verificaNulo(rs, 6)
                    colheita = verificaNulo(rs, 7)
                    dataEnvio = verificaNulo(rs, 8)
                    dataChegada = verificaNulo(rs, 9)
                    resultado = verificaNulo(rs, 10)
                    dataEntrega = verificaNulo(rs, 11)
                    resultadoPerdido = verificaNulo(rs, 12)
                    uuid = verificaNulo(rs, 13)

                    If dataColheita.ToString.Contains("System") Then
                        dataColheita = ""
                    Else
                        If dataColheita.ToString.Length > 10 Then
                            dataColheita = dataColheita.ToString.Substring(0, 10)
                        End If
                    End If

                    If dataEnvio.ToString.Contains("System") Then
                        dataEnvio = Nothing
                    Else
                        If dataEnvio.ToString.Length > 10 Then
                            dataEnvio = dataEnvio.ToString.Substring(0, 10)
                        End If
                    End If

                    If dataChegada.ToString.Contains("System") Then
                        dataChegada = Nothing
                    Else
                        If dataChegada.ToString.Length > 10 Then
                            dataChegada = dataChegada.ToString.Substring(0, 10)
                        End If
                    End If

                    If dataEntrega.ToString.Contains("System") Then
                        dataEntrega = Nothing
                    Else
                        If dataEntrega.ToString.Length > 10 Then
                            dataEntrega = dataEntrega.ToString.Substring(0, 10)
                        End If
                    End If

                    Dim oneDimArray() As Object = {dataColheita, numOrdem, numFea, nidCrianca, nomeApelido, sexo, idade, colheita, dataEnvio, dataChegada, resultado, dataEntrega, resultadoPerdido, uuid}

                    Me.DataGridView1.Rows.Add(oneDimArray)
                End While
                'rs.Close()
            End If
        End With
        If Not rs.IsClosed Then
            rs.Close()
        End If

    End Sub
    Private Function validarDados(ByVal dg As DataGridView) As Int16
        For Each dgItem As DataGridViewRow In dg.Rows

            If dgItem.Index = Me.DataGridView1.RowCount - 1 Then
                Exit For
            End If

            If IsDBNull(dgItem.Cells(0).Value) Then
                Return 0
            ElseIf String.IsNullOrEmpty(dgItem.Cells(0).Value) Then
                Return 0
            ElseIf Not IsDate(dgItem.Cells(0).Value) Then
                Return 0
            End If

            If IsDBNull(dgItem.Cells(1).Value) Then
                Return 1
            ElseIf String.IsNullOrEmpty(dgItem.Cells(1).Value) Then
                Return 1
            ElseIf Not IsNumeric(dgItem.Cells(1).Value) Then
                Return 1
            End If

            'If IsDBNull(dgItem.Cells(2).Value) Then
            '    Return 2
            'ElseIf String.IsNullOrEmpty(dgItem.Cells(2).Value) Then
            '    Return 2
            'End If

            If IsDBNull(dgItem.Cells(3).Value) Then
                Return 3
            ElseIf String.IsNullOrEmpty(dgItem.Cells(3).Value) Then
                Return 3
            End If

            If IsDBNull(dgItem.Cells(4).Value) Then
                Return 4
            ElseIf String.IsNullOrEmpty(dgItem.Cells(4).Value) Then
                Return 4
            End If

            If IsDBNull(dgItem.Cells(5).Value) Then
                Return 5
            ElseIf String.IsNullOrEmpty(dgItem.Cells(5).Value) Then
                Return 5
            End If

            If IsDBNull(dgItem.Cells(6).Value) Then
                Return 6
            ElseIf String.IsNullOrEmpty(dgItem.Cells(6).Value) Then
                Return 6
            ElseIf Not IsNumeric(dgItem.Cells(6).Value) Then
                Return 6
            End If

            If IsDBNull(dgItem.Cells(7).Value) Then
                Return 7
            ElseIf String.IsNullOrEmpty(dgItem.Cells(7).Value) Then
                Return 7
            End If

        Next

        Return 8
    End Function



    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        Try
            'If Not isUpdate Then
            Me.DataGridView1.CurrentRow.Cells("dataColheita").Value = Today.Day & "/" & Today.Month & "/" & Today.Year

            If Me.DataGridView1.Rows.Count > 2 Then
                Me.DataGridView1.CurrentRow.Cells("numOrdem").Value = Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index - 1).Cells("numOrdem").Value + 1
            Else
                Me.DataGridView1.CurrentRow.Cells("numOrdem").Value = 1
            End If
            Me.DataGridView1.CurrentRow.Cells("sexo").Value = "F"
            Me.DataGridView1.CurrentRow.Cells("nidCrianca").Value = My.Settings.DefaultHddNID & "/"
            Me.DataGridView1.CurrentRow.Cells("colheita").Value = "Primeira"
            'End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdRegistar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRegistar.Click
        Try
            Dim strQuery As String


            Dim erro As Integer = validarDados(Me.DataGridView1)

            If erro <> 8 Then
                Select Case erro
                    Case 0
                        MsgBox("Existe uma Data de colheita não preenchido ou mal preechido")
                        Exit Sub
                    Case 1
                        MsgBox("Existe um numero de ordem não preenchido ou mal preechido")
                        Exit Sub
                    Case 3
                        MsgBox("Existe um NID da criança não preenchido ou mal preechido")
                        Exit Sub
                    Case 4
                        MsgBox("Existe um Nome não preenchido ou mal preechido")
                        Exit Sub
                    Case 5
                        MsgBox("Existe um Sexo não preenchida ou mal preechida")
                        Exit Sub
                    Case 6
                        MsgBox("Existe uma idade não preenchida ou mal preechida")
                        Exit Sub
                    Case 7
                        MsgBox("Existe uma Recolha não preenchida ou mal preechida")
                        Exit Sub
                End Select
            End If

            For Each dgItem As DataGridViewRow In DataGridView1.Rows
                If dgItem.Index = Me.DataGridView1.RowCount - 1 Then
                    Exit For
                End If
                If (IsDBNull(dgItem.Cells(13).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(13).Value)) Then
                    strQuery = "insert into colheita_pcr(data_colheita,num_ordem,num_fea,nid_crianca,nome_apelido," & _
                       "sexo,idade,colheita,data_envio,data_chegada,resultado,data_entrega,resultado_perdido,location_id,uuid) " & _
                                   " Values('" & dataMySQL(dgItem.Cells(0).Value) & "'," & dgItem.Cells(1).Value & ",'" & IIf((IsDBNull(dgItem.Cells(2).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(2).Value)), "", dgItem.Cells(1).Value) & "'," & _
                                   " '" & dgItem.Cells(3).Value & "','" & dgItem.Cells(4).Value & "','" & dgItem.Cells(5).Value & "'," & dgItem.Cells(6).Value & "," & _
                                   " '" & dgItem.Cells(7).Value & "'," & IIf((IsDBNull(dgItem.Cells(8).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(8).Value)) Or (Not IsDate(dgItem.Cells(8).Value)), "null", addQuote(dataMySQL(dgItem.Cells(8).Value))) & "," & _
                                   " " & IIf((IsDBNull(dgItem.Cells(9).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(9).Value)) Or (Not IsDate(dgItem.Cells(9).Value)), "null", addQuote(dataMySQL(dgItem.Cells(9).Value))) & "," & _
                                   " '" & IIf((IsDBNull(dgItem.Cells(10).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(10).Value)), "", dgItem.Cells(10).Value) & "'," & _
                                   " " & IIf((IsDBNull(dgItem.Cells(11).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(11).Value)) Or (Not IsDate(dgItem.Cells(11).Value)), "null", addQuote(dataMySQL(dgItem.Cells(11).Value))) & "," & _
                                   " " & IIf(dgItem.Cells(12).Value, True, False) & "," & cboUS.SelectedValue & ",uuid())"

                Else

                    strQuery = "update colheita_pcr set " & _
                                    " data_colheita='" & dataMySQL(dgItem.Cells(0).Value) & "',num_ordem=" & dgItem.Cells(1).Value & ",num_fea='" & IIf((IsDBNull(dgItem.Cells(2).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(2).Value)), "", dgItem.Cells(1).Value) & "'," & _
                                    " nid_crianca='" & dgItem.Cells(3).Value & "',nome_apelido='" & dgItem.Cells(4).Value & "',sexo='" & dgItem.Cells(5).Value & "',idade=" & dgItem.Cells(6).Value & "," & _
                                    " colheita='" & dgItem.Cells(7).Value & "',data_envio=" & IIf((IsDBNull(dgItem.Cells(8).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(8).Value)) Or (Not IsDate(dgItem.Cells(8).Value)), "null", addQuote(dataMySQL(dgItem.Cells(8).Value))) & "," & _
                                    " data_chegada=" & IIf((IsDBNull(dgItem.Cells(9).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(9).Value)) Or (Not IsDate(dgItem.Cells(9).Value)), "null", addQuote(dataMySQL(dgItem.Cells(9).Value))) & "," & _
                                    " resultado='" & IIf((IsDBNull(dgItem.Cells(10).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(10).Value)), "", dgItem.Cells(10).Value) & "'," & _
                                    " data_entrega=" & IIf((IsDBNull(dgItem.Cells(11).Value)) Or (String.IsNullOrEmpty(dgItem.Cells(11).Value)) Or (Not IsDate(dgItem.Cells(11).Value)), "null", addQuote(dataMySQL(dgItem.Cells(11).Value))) & "," & _
                                    " resultado_perdido=" & IIf(dgItem.Cells(12).Value, True, False) & " where uuid='" & dgItem.Cells(13).Value & "'"

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


    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        Try
            EncherCombo(Me.cboDistrito, "nome", "district", "DistritoID", "ProvinciaID", , Me.cboProvincia.SelectedValue)
            If Me.cboDistrito.Items.Count > 0 Then
                Me.cboDistrito.SelectedValue = My.Settings.DefaultDistrictID
            End If
        Catch ex As Exception

        End Try
    End Sub

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

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
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

    Private Sub chkEnviadas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnviadas.CheckedChanged
        If Me.chkEnviadas.Checked Then
            Me.chkNaoEnviadas.Checked = False
        End If
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkNaoEnviadas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNaoEnviadas.CheckedChanged
        If Me.chkNaoEnviadas.Checked Then
            Me.chkEnviadas.Checked = False
        End If
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkRecebidas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecebidas.CheckedChanged
        If Me.chkRecebidas.Checked Then
            Me.chkNaoRecebidas.Checked = False
        End If
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkNaoRecebidas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNaoRecebidas.CheckedChanged
        If Me.chkNaoRecebidas.Checked Then
            Me.chkRecebidas.Checked = False
        End If
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkEntregue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEntregue.CheckedChanged
        If Me.chkEntregue.Checked Then
            Me.chkNaoEntregue.Checked = False
        End If
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkNaoEntregue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNaoEntregue.CheckedChanged
        If Me.chkNaoEntregue.Checked Then
            Me.chkEntregue.Checked = False
        End If
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboUS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUS.SelectedIndexChanged
        Try
            'If isUpdate Then
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dataInicial_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataInicial.ValueChanged
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dataFinal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataFinal.ValueChanged
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkPerdido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPerdido.CheckedChanged
        Try
            filtrar(Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, Me.cboUS.SelectedValue, Me.chkEnviadas.Checked, Me.chkRecebidas.Checked, Me.chkEntregue.Checked, Me.chkPerdido.Checked, Me.chkNaoEnviadas.Checked, Me.chkNaoRecebidas.Checked, Me.chkNaoEntregue.Checked)
        Catch ex As Exception

        End Try
    End Sub
End Class