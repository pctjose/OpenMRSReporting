Imports MySql.Data.MySqlClient
Public Class frmRelatorioMensal
    Dim dataInicial As String
    Dim dataFinal As String
    Dim idPrint As Int16
    Private Sub txtAno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAno.KeyPress
        proibirLetrasInt(e, txtAno.Text)
    End Sub
    Private Sub montarData()
        Dim ano = Me.txtAno.Text
        Select Case Me.cboMes.SelectedIndex
            Case 0
                dataInicial = ano & "/0" & 1 & "/" & "01"
                dataFinal = ano & "/0" & 1 & "/" & 31
            Case 1
                If Date.IsLeapYear(ano) Then
                    dataInicial = ano & "/0" & 2 & "/" & "01"
                    dataFinal = ano & "/0" & 2 & "/" & 29
                Else
                    dataInicial = ano & "/0" & 2 & "/" & "01"
                    dataFinal = ano & "/0" & 2 & "/" & 28
                End If
            Case 2
                dataInicial = ano & "/0" & 3 & "/" & "01"
                dataFinal = ano & "/0" & 3 & "/" & 31
            Case 3
                dataInicial = ano & "/0" & 4 & "/" & "01"
                dataFinal = ano & "/0" & 4 & "/" & 30
            Case 4
                dataInicial = ano & "/0" & 5 & "/" & "01"
                dataFinal = ano & "/0" & 5 & "/" & 31
            Case 5
                dataInicial = ano & "/0" & 6 & "/" & "01"
                dataFinal = ano & "/0" & 6 & "/" & 30
            Case 6
                dataInicial = ano & "/0" & 7 & "/" & "01"
                dataFinal = ano & "/0" & 7 & "/" & 31
            Case 7
                dataInicial = ano & "/0" & 8 & "/" & "01"
                dataFinal = ano & "/0" & 8 & "/" & 31
            Case 8
                dataInicial = ano & "/0" & 9 & "/" & "01"
                dataFinal = ano & "/0" & 9 & "/" & 30
            Case 9
                dataInicial = ano & "/" & 10 & "/" & "01"
                dataFinal = ano & "/" & 10 & "/" & 31
            Case 10
                dataInicial = ano & "/" & 11 & "/" & "01"
                dataFinal = ano & "/" & 11 & "/" & 30
            Case 11
                dataInicial = ano & "/" & 12 & "/" & "01"
                dataFinal = ano & "/" & 12 & "/" & 31
        End Select
    End Sub

    Private Sub frmRelatorioMensal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.cboMes.SelectedIndex = Month(Now.Date) - 1
        'EncherCombo(Me.cboUS, "name", "Location", "location_id")
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If Me.cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
        Me.lblInfo.Text = "Preencha os campos e clique Visualizar..."

        Me.txtAno.Text = Now.Year
        Dim d1 As Date
        If Today.Month = 1 Then
            d1 = New Date(Today.Year - 1, 12, 21)
        Else
            d1 = New Date(Today.Year, Today.Month - 1, 21)
        End If
        'Dim d1 As New Date(Today.Year, Today.Month - 1, 21)
        Dim d2 As New Date(Today.Year, Today.Month, 20)
        Me.data1.Value = d1
        Me.data2.Value = d2
    End Sub
    Private Sub PrepararNovo(ByVal rptVO As MMReportVO)
        MMReportDAO.insertInitial(rptVO)

        Me.lblInfo.Text = "Verificando os Fridas de cada paciente..."
        Me.StatusStrip1.Refresh()
        'MMReportDAO.PrepararFrida()
        Me.ProgressBar.Value = 10

        Me.lblInfo.Text = "Verificando estado de mulheres gravidas..."
        Me.StatusStrip1.Refresh()
        'MMReportDAO.PrepararGravidas()
        Me.ProgressBar.Value = 20

        Me.lblInfo.Text = "Calculando Inscritos..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularIncritos(rptVO)
        Me.ProgressBar.Value = 30

        Me.lblInfo.Text = "Calculando Consultas Clinicas..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularConsultasClinicas(rptVO)
        Me.ProgressBar.Value = 40

        Me.lblInfo.Text = "Calculando Entradas TARV..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTARVEntradas(rptVO)
        Me.ProgressBar.Value = 50

        Me.lblInfo.Text = "Calculando Saidas TARV..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTARVSaidas(rptVO)
        Me.ProgressBar.Value = 60

        Me.lblInfo.Text = "Calculando Cumulativo do mes..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularCumulativo(rptVO)
        Me.ProgressBar.Value = 70

        Me.lblInfo.Text = "Calculando Tratamento de TB inscritos..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTratamentoTB(rptVO)
        Me.ProgressBar.Value = 80

        Me.lblInfo.Text = "Calculando TARV Referidos aos CD..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTARVReferidoCD(rptVO)
        Me.ProgressBar.Value = 90

        Me.lblInfo.Text = "Calculando Gravidas Inscritas..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularGravidas(rptVO)
    End Sub
    Private Sub PrepararNovoNEW(ByVal rptVO As MMReportVO)
        MMReportDAO.insertInitial(rptVO)

        Me.lblInfo.Text = "Verificando as Consistencias..."
        Me.StatusStrip1.Refresh()
        'MMReportDAO.Validade(rptVO)
        Me.ProgressBar.Value = 10

        Me.lblInfo.Text = "Verificando estado de mulheres gravidas..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.PrepararGravidasNEW()
        Me.ProgressBar.Value = 20

        Me.lblInfo.Text = "Calculando Inscritos..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularIncritosNEW(rptVO)
        Me.ProgressBar.Value = 30

        Me.lblInfo.Text = "Calculando Consultas Clinicas..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularConsultasClinicasNEW(rptVO)
        Me.ProgressBar.Value = 40

        Me.lblInfo.Text = "Calculando Entradas TARV..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTARVEntradasNEW(rptVO)
        Me.ProgressBar.Value = 50

        Me.lblInfo.Text = "Calculando Saidas TARV..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTARVSaidasNEW(rptVO)
        Me.ProgressBar.Value = 60

        Me.lblInfo.Text = "Calculando Cumulativo do mes..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularCumulativoNEW(rptVO)
        Me.ProgressBar.Value = 70

        Me.lblInfo.Text = "Calculando Tratamento de TB inscritos..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTratamentoTBNEW(rptVO)
        Me.ProgressBar.Value = 80

        Me.lblInfo.Text = "Calculando TARV Referidos aos CD..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTARVReferidoCDNEW(rptVO)
        Me.ProgressBar.Value = 90

        Me.lblInfo.Text = "Calculando Gravidas Inscritas..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularGravidasNEW(rptVO)
    End Sub
    Private Sub PrepararNovoNEW_(ByVal rptVO As MMReportVO)
        MMReportDAO.insertInitial(rptVO)

        Me.lblInfo.Text = "Verificando as Consistencias..."
        Me.StatusStrip1.Refresh()
        'MMReportDAO.Validade(rptVO)
        Me.ProgressBar.Value = 10

        'Me.lblInfo.Text = "Verificando estado de mulheres gravidas..."
        'Me.StatusStrip1.Refresh()
        'MMReportDAO.PrepararGravidasNEW()
        'Me.ProgressBar.Value = 20

        Me.lblInfo.Text = "Calculando Inscritos..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularIncritosNEW_(rptVO)
        Me.ProgressBar.Value = 30

        Me.lblInfo.Text = "Calculando Consultas Clinicas..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularConsultasClinicasNEW_(rptVO)
        Me.ProgressBar.Value = 40

        Me.lblInfo.Text = "Calculando Entradas TARV..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTARVEntradasNEW_(rptVO)
        Me.ProgressBar.Value = 50

        Me.lblInfo.Text = "Calculando Saidas TARV..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTARVSaidasNEW_(rptVO)
        Me.ProgressBar.Value = 60

        Me.lblInfo.Text = "Calculando Cumulativo do mes..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularCumulativoNEW_(rptVO)
        Me.ProgressBar.Value = 70

        Me.lblInfo.Text = "Calculando Tratamento de TB inscritos..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTratamentoTBNEW_(rptVO)
        Me.ProgressBar.Value = 80

        Me.lblInfo.Text = "Calculando TARV Referidos aos CD..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularTARVReferidoCDNEW_(rptVO)
        Me.ProgressBar.Value = 90

        Me.lblInfo.Text = "Calculando Gravidas Inscritas..."
        Me.StatusStrip1.Refresh()
        MMReportDAO.CalcularGravidasNEW_(rptVO)
    End Sub
    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Cursor = Cursors.WaitCursor
        Dim rptVO As New MMReportVO
        Dim mmrpt As New RelatorioMensalTeste
        Dim forma As New frmPrintReports
        Dim rptNovo As New RelatorioMensaNovo

        ProgressBar.Value = 0

        If Me.cboUS.SelectedIndex < 0 Then
            MsgBox("Seleccione a Unidade Sanitaria")
            Me.cboUS.Focus()
            Exit Sub
        End If
        If Me.cboMes.SelectedIndex < 0 Then
            MsgBox("Seleccione o mes que pretende visualizar o relatorio")
            Me.cboMes.Focus()
            Exit Sub
        End If
        If Me.txtAno.Text = Nothing Then
            MsgBox("Deve indicar o ano")
            txtAno.Focus()
            Exit Sub
        End If
        If CInt(Me.txtAno.Text) < 2000 Then
            MsgBox("O ano introduzido e anterior a 2006, nao ha dados nesse periodo")
            Me.txtAno.Focus()
            Exit Sub
        End If
        
        dataInicial = data1.Value.Date
        dataFinal = data2.Value.Date
        
        Dim printedRpt As New MMReportVO
        Me.lblInfo.Text = "Verificando relatorio do mes anterior..."
        Me.StatusStrip1.Refresh()

        printedRpt = MMReportDAO.getMMByHDDMesAno(Me.cboUS.SelectedValue, Me.cboMes.SelectedIndex + 1, CInt(Me.txtAno.Text), Me.chkDistrital.Checked)
        Me.ProgressBar.Value = 5

        rptVO.CreatedBy = utilizador
        rptVO.DateCreated = Now.Date
        rptVO.Location = HddDAO.getHddByOpenMRSID(Me.cboUS.SelectedValue)
        rptVO.Month = Me.cboMes.SelectedIndex + 1
        rptVO.ReportDateRangeEnd = dataFinal
        rptVO.ReportDateRangeStart = dataInicial
        rptVO.Report = ReportDAO.getReportByID(My.Settings.MisauReportID)
        rptVO.Voided = 0
        rptVO.Year = CInt(Me.txtAno.Text)
        rptVO.Distrital = Me.chkDistrital.Checked

        

        If printedRpt.isNull Then

            'Me.lblInfo.Text = "Preparando validacoes de dados..."
            'Me.StatusStrip1.Refresh()
            'Me.ProgressBar.Value = 30

            'If MM_ValidateNew() > 0 Then
            '    Dim resp1 As Int16 = MsgBox("Existe(m) paciente(s) com inconsistencia de movimento TARV (FRIDA)." & Chr(13) & Chr(13) & "Veja essas inconsistencias em Monitoria de dados -> Movimento FRIDA" & Chr(13) & " É aconselhavel corrigir estas inconsistencias antes de imprimir. Pretende imprimir?", MsgBoxStyle.YesNo, "Inconsistencia")
            '    If resp1 = MsgBoxResult.No Then
            '        Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If


            If MMReportDAO.insert(rptVO) Then

                MMReportDAO.insertInitialNovo(rptVO)

                Me.lblInfo.Text = "Preparando dados temporarios do relatorio..."
                Me.StatusStrip1.Refresh()
                MMReportDAO.FillProcessoTARVTablesForMonthReport(rptVO)
                Me.ProgressBar.Value = 60

                Me.lblInfo.Text = "Calculando Indicadores do Relatorio ..."
                Me.StatusStrip1.Refresh()
                MMReportDAO.FillMMINDICATORDATA(rptVO)
                Me.ProgressBar.Value = 80



                Me.lblInfo.Text = "Imprimindo o Relatorio..."
                Me.StatusStrip1.Refresh()

                rptNovo.SetDataSource(TabelaDinamica("Select * from mm_indicator_data where  report_id=" & rptVO.ReportsID))

                rptNovo.SetParameterValue(mmrpt.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                rptNovo.SetParameterValue(mmrpt.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                rptNovo.SetParameterValue(mmrpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
                rptNovo.SetParameterValue(mmrpt.Parameter_mes.ParameterFieldName, Me.cboMes.Text & " (" & dataInicial & " Até " & dataFinal & ")")
                rptNovo.SetParameterValue(mmrpt.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)


                forma.rptViewer.ReportSource = rptNovo
                forma.Text = "Relatorio Mensal, Mes de " & Me.cboMes.Text & ": Ano de " & Me.txtAno.Text

                Me.ProgressBar.Value = 100
                forma.Show()
                Me.lblInfo.Text = "Fim..."
                Me.StatusStrip1.Refresh()
            End If

        Else
            Dim resp As Int16 = MsgBox("Este relatorio ja foi emitido antes." & Chr(13) & "O que pretende fazer?" & Chr(13) & "Yes - Para Emitir novamente" & Chr(13) & "No - Para visualizar o emitido antes." & Chr(13) & " Cancel - Cancelar", MsgBoxStyle.YesNoCancel, "Imprimir")
            If resp = MsgBoxResult.Yes Then

                Me.lblInfo.Text = "Preparando validacoes de dados..."
                Me.StatusStrip1.Refresh()
                Me.ProgressBar.Value = 30

                'If MM_ValidateNew() > 0 Then
                '    Dim resp1 As Int16 = MsgBox("Existe(m) paciente(s) com inconsistencia de movimento TARV (FRIDA)." & Chr(13) & Chr(13) & "Veja essas inconsistencias em Monitoria de dados -> Movimento FRIDA" & Chr(13) & " É aconselhavel corrigir estas inconsistencias antes de imprimir. Pretende imprimir?", MsgBoxStyle.YesNo, "Inconsistencia")
                '    If resp1 = MsgBoxResult.No Then
                '        Cursor = Cursors.Default
                '        Exit Sub
                '    End If
                'End If


                printedRpt.Voided = True
                printedRpt.VoidedBy = utilizador
                printedRpt.VoidedDate = Now.Date
                printedRpt.VoidedReason = "Reeimprimido por " & utilizador.Name & " em " & Now.Date
                MMReportDAO.void(printedRpt)

                If MMReportDAO.insert(rptVO) Then

                    MMReportDAO.insertInitialNovo(rptVO)

                    Me.lblInfo.Text = "Preparando dados temporarios do relatorio..."
                    Me.StatusStrip1.Refresh()
                    MMReportDAO.FillProcessoTARVTablesForMonthReport(rptVO)
                    Me.ProgressBar.Value = 60

                    Me.lblInfo.Text = "Calculando Indicadores do Relatorio ..."
                    Me.StatusStrip1.Refresh()
                    MMReportDAO.FillMMINDICATORDATA(rptVO)
                    Me.ProgressBar.Value = 80



                    Me.lblInfo.Text = "Imprimindo o Relatorio..."
                    Me.StatusStrip1.Refresh()

                    rptNovo.SetDataSource(TabelaDinamica("Select * from mm_indicator_data where  report_id=" & rptVO.ReportsID))

                    rptNovo.SetParameterValue(mmrpt.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                    rptNovo.SetParameterValue(mmrpt.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                    rptNovo.SetParameterValue(mmrpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
                    rptNovo.SetParameterValue(mmrpt.Parameter_mes.ParameterFieldName, Me.cboMes.Text & " (" & dataInicial & " Até " & dataFinal & ")")
                    rptNovo.SetParameterValue(mmrpt.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)


                    forma.rptViewer.ReportSource = rptNovo
                    forma.Text = "Relatorio Mensal, Mes de " & Me.cboMes.Text & ": Ano de " & Me.txtAno.Text

                    Me.ProgressBar.Value = 100
                    forma.Show()
                    Me.lblInfo.Text = "Fim..."
                    Me.StatusStrip1.Refresh()

                End If

                'Void o impresso, re-imprimir de novo
            ElseIf resp = MsgBoxResult.No Then

                Me.lblInfo.Text = "Imprimindo o Relatorio..."
                Me.StatusStrip1.Refresh()
                Me.ProgressBar.Value = 70

                rptNovo.SetDataSource(TabelaDinamica("Select * from mm_indicator_data where  report_id=" & printedRpt.ReportsID))


                rptNovo.SetParameterValue(mmrpt.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                rptNovo.SetParameterValue(mmrpt.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                rptNovo.SetParameterValue(mmrpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
                rptNovo.SetParameterValue(mmrpt.Parameter_mes.ParameterFieldName, Me.cboMes.Text & " (" & dataInicial & " Até " & dataFinal & ")")
                rptNovo.SetParameterValue(mmrpt.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)


                forma.rptViewer.ReportSource = rptNovo
                forma.Text = "Relatorio Mensal, Mes de " & Me.cboMes.Text & ": Ano de " & Me.txtAno.Text
                Me.ProgressBar.Value = 100
                forma.Show()
                Me.lblInfo.Text = "Fim..."
                Me.StatusStrip1.Refresh()

            Else
                Me.Close()
            End If

        End If
        ' End If
        Cursor = Cursors.Default
    End Sub

    Private Function SeeIfPrintedReportInMonthChoosen() As Integer
        Dim reportId As Integer
        Dim rs As MySql.Data.MySqlClient.MySqlDataReader
        With cmm
            .Connection = ConexaoOpenMRSReporting1
            .CommandText = "Select reports.report_ID from reports,month_report where " & _
            " reports.report_id=month_report.report_id and month_report.month=" & (Me.cboMes.SelectedIndex + 1) & " and month_report.year=" & CInt(Me.txtAno.Text) & " and reports.hdd=" & Me.cboUS.SelectedValue & ""
            rs = .ExecuteReader
            If rs.HasRows Then
                rs.Read()
                reportId = rs.GetInt32(0)
            Else
                reportId = 0
            End If
            FechaResultSet(rs)
            Return reportId
        End With
    End Function

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        'TabelaDinamica("Select * from mm_indicator_data,mm_indicator_data_total")

        'fechaConexoes()
        Me.Close()
    End Sub
    Private Sub fillOpenMRSTempTable()

        With cmm
            .CommandType = CommandType.Text
            '.Connection = Conexao1
            '.CommandText = "Delete from temp_month_report"
            '.ExecuteNonQuery()
            '.CommandText = "insert into temp_month_report(ic14f) values(0)"
            '.ExecuteNonQuery()
            .CommandText = "Select max(id) from temp_month_report"
            idPrint = .ExecuteScalar
            'Inscritos Cumulativos ate o fim do mes anterior Femininos menores de 15 anos
            .CommandText = "Update temp_month_report set ic14f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age<=14 and gender='F') " & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Masculinos menores de 15 anos
            .CommandText = "Update temp_month_report set ic14m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age<=14 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Feminios menores de 15 a 24 anos
            .CommandText = "Update temp_month_report set ic1524f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age between 15 and 24 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Masculino menores de 15 a 24 anos
            .CommandText = "Update temp_month_report set ic1524m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age between 15 and 24 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Femininos menores de 25 anos ou mais
            .CommandText = "Update temp_month_report set ic25f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age>=25 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Masculinos menores de 25 anos ou mais
            .CommandText = "Update temp_month_report set ic25m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age>=25 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '============================================================================================================================

            'Novos Inscritos neste mes Femininos menores de 15 anos
            .CommandText = "Update temp_month_report set ni14f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age<=14 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Masculinos menores de 15 anos
            .CommandText = "Update temp_month_report set ni14m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age<=14 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Femininos 15 a 24 anos
            .CommandText = "Update temp_month_report set ni1524f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age between 15 and 24 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Masculinos 15 a 24 anos
            .CommandText = "Update temp_month_report set ni1524m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age between 15 and 24 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Femininos 25 anos
            .CommandText = "Update temp_month_report set ni25f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age >=25 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Femininos 25 anos
            .CommandText = "Update temp_month_report set ni25m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age >=25 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '============================================================================================================================================================
            'Consultas Clinicas a doentes em TARV Feminino menor 15
            .CommandText = "Update temp_month_report set cct14f=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes em TARV Masculino menor 15
            .CommandText = "Update temp_month_report set cct14m=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes em TARV Feminino 15 a 24 anos
            .CommandText = "Update temp_month_report set cct1524f=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Consultas Clinicas a doentes em TARV Masculino 15 a 24 anos
            .CommandText = "Update temp_month_report set cct1524m=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Consultas Clinicas a doentes em TARV Feminino 25 anos
            .CommandText = "Update temp_month_report set cct25f=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes em TARV Masculino 25 anos
            .CommandText = "Update temp_month_report set cct25m=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            '=========================================================================================================================================================================================
            'Consultas Clinicas a doentes nao em TARV Feminino menor 15
            .CommandText = "Update temp_month_report set ccnt14f=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Consultas Clinicas a doentes nao em TARV Masculino menor 15
            .CommandText = "Update temp_month_report set ccnt14m=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes nao em TARV Feminino 15 a 24 anos
            .CommandText = "Update temp_month_report set ccnt1524f=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes nao em TARV Masculino 15 a 24 anos
            .CommandText = "Update temp_month_report set ccnt1524m=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Consultas Clinicas a doentes nao em TARV Feminino 25 anos
            .CommandText = "Update temp_month_report set ccnt25f=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes nao em TARV Masculino 25 anos
            .CommandText = "Update temp_month_report set ccnt25m=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '=======================================================================================================================================================================
            'Entrada Novos Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set en14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Novos Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set en14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Entrada Novos Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set en1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Novos Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set en1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Novos Feminino 25 anos
            .CommandText = " Update temp_month_report set en25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Novos Feminino 25 anos
            .CommandText = " Update temp_month_report set en25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            '===========================================================================================================================================================================================================================

            'Entrada Reiniciados Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set er14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Reiniciados Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set er14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Entrada Reiniciados Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set er1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Reiniciados Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set er1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Reiniciados Feminino 25 anos
            .CommandText = " Update temp_month_report set er25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Reiniciados Feminino 25 anos
            .CommandText = " Update temp_month_report set er25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Entrada Transferidos de Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set et14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Transferidos de Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set et14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Entrada Transferidos de Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set et1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Transferidos de Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set et1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Transferidos de Feminino 25 anos
            .CommandText = " Update temp_month_report set et25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Transferidos de Feminino 25 anos
            .CommandText = " Update temp_month_report set et25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Saida Suspensos Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set ss14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Suspensos Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set ss14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Saida Suspensos Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set ss1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Suspensos Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set ss1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Suspensos Feminino 25 anos
            .CommandText = " Update temp_month_report set ss25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Suspensos Feminino 25 anos
            .CommandText = " Update temp_month_report set ss25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Saida Transferidos para Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set st14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Transferidos para Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set st14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Saida Transferidos para Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set st1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Transferidos para Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set st1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Transferidos para Feminino 25 anos
            .CommandText = " Update temp_month_report set st25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Transferidos para Feminino 25 anos
            .CommandText = " Update temp_month_report set st25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            '===========================================================================================================================================================================================================================
            'Saida Abandonos Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set sa14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Abandonos Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set sa14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Saida Abandonos Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set sa1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Abandonos Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set sa1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Abandonos Feminino 25 anos
            .CommandText = " Update temp_month_report set sa25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Abandonos Feminino 25 anos
            .CommandText = " Update temp_month_report set sa25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            '===========================================================================================================================================================================================================================
            'Saida Obitos Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set so14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Obitos Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set so14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Saida Obitos Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set so1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Obitos Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set so1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Obitos Feminino 25 anos
            .CommandText = " Update temp_month_report set so25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Obitos Feminino 25 anos
            .CommandText = " Update temp_month_report set so25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Em tratamento de TB Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set etb14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Em tratamento de TB Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set etb14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Em tratamento de TB Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set etb1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Em tratamento de TB Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set etb1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Em tratamento de TB Feminino 25 anos
            .CommandText = " Update temp_month_report set etb25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Em tratamento de TB Feminino 25 anos
            .CommandText = " Update temp_month_report set etb25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()



        End With
    End Sub

    Private Sub fillOpenMRSTempTableModificado()
        Dim cmmOpenmrs As New MySql.Data.MySqlClient.MySqlCommand
        Dim cmmOpenmrsreporting As New MySql.Data.MySqlClient.MySqlCommand

        cmmOpenmrs.CommandType = CommandType.Text
        cmmOpenmrs.Connection = ConexaoOpenMRS2


        With cmmOpenmrsreporting
            .CommandType = CommandType.Text
            .Connection = ConexaoOpenMRSReporting2
            '.CommandText = "Delete from temp_month_report"
            '.ExecuteNonQuery()
            '.CommandText = "insert into temp_month_report(ic14f) values(0)"
            '.ExecuteNonQuery()
            .CommandText = "Select max(id) from temp_month_report"
            idPrint = .ExecuteScalar
            'Inscritos Cumulativos ate o fim do mes anterior Femininos menores de 15 anos
            .CommandText = "Update temp_month_report set ic14f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age<=14 and gender='F') " & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Masculinos menores de 15 anos
            .CommandText = "Update temp_month_report set ic14m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age<=14 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Feminios menores de 15 a 24 anos
            .CommandText = "Update temp_month_report set ic1524f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age between 15 and 24 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Masculino menores de 15 a 24 anos
            .CommandText = "Update temp_month_report set ic1524m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age between 15 and 24 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Femininos menores de 25 anos ou mais
            .CommandText = "Update temp_month_report set ic25f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age>=25 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Inscritos Cumulativos ate o fim do mes anterior Masculinos menores de 25 anos ou mais
            .CommandText = "Update temp_month_report set ic25m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime<'" & dataInicial & "' and age>=25 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '============================================================================================================================

            'Novos Inscritos neste mes Femininos menores de 15 anos
            .CommandText = "Update temp_month_report set ni14f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age<=14 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Masculinos menores de 15 anos
            .CommandText = "Update temp_month_report set ni14m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age<=14 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Femininos 15 a 24 anos
            .CommandText = "Update temp_month_report set ni1524f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age between 15 and 24 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Masculinos 15 a 24 anos
            .CommandText = "Update temp_month_report set ni1524m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age between 15 and 24 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Femininos 25 anos
            .CommandText = "Update temp_month_report set ni25f=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age >=25 and gender='F')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Novos Inscritos neste mes Femininos 25 anos
            .CommandText = "Update temp_month_report set ni25m=(Select count(*) from v_encounter where encounter_type in (5,7) and " & _
            "location_id =" & Me.cboUS.SelectedValue & " and encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and age >=25 and gender='M')" & _
            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '============================================================================================================================================================
            'Consultas Clinicas a doentes em TARV Feminino menor 15
            .CommandText = "Update temp_month_report set cct14f=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes em TARV Masculino menor 15
            .CommandText = "Update temp_month_report set cct14m=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes em TARV Feminino 15 a 24 anos
            .CommandText = "Update temp_month_report set cct1524f=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Consultas Clinicas a doentes em TARV Masculino 15 a 24 anos
            .CommandText = "Update temp_month_report set cct1524m=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Consultas Clinicas a doentes em TARV Feminino 25 anos
            .CommandText = "Update temp_month_report set cct25f=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes em TARV Masculino 25 anos
            .CommandText = "Update temp_month_report set cct25m=(select count(*) from v_pacientes_tarv,v_encounter " & _
                         " where v_pacientes_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            '=========================================================================================================================================================================================
            'Consultas Clinicas a doentes nao em TARV Feminino menor 15
            .CommandText = "Update temp_month_report set ccnt14f=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Consultas Clinicas a doentes nao em TARV Masculino menor 15
            .CommandText = "Update temp_month_report set ccnt14m=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes nao em TARV Feminino 15 a 24 anos
            .CommandText = "Update temp_month_report set ccnt1524f=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes nao em TARV Masculino 15 a 24 anos
            .CommandText = "Update temp_month_report set ccnt1524m=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Consultas Clinicas a doentes nao em TARV Feminino 25 anos
            .CommandText = "Update temp_month_report set ccnt25f=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Consultas Clinicas a doentes nao em TARV Masculino 25 anos
            .CommandText = "Update temp_month_report set ccnt25m=(select count(*) from v_pacientes_nao_tarv,v_encounter " & _
                         " where v_pacientes_nao_tarv.patient_id=v_encounter.person_id and v_encounter.encounter_type in (6,9,10,12) and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '=======================================================================================================================================================================
            'Entrada Novos Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set en14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Novos Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set en14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Entrada Novos Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set en1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Novos Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set en1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Novos Feminino 25 anos
            .CommandText = " Update temp_month_report set en25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Novos Feminino 25 anos
            .CommandText = " Update temp_month_report set en25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            '===========================================================================================================================================================================================================================

            'Entrada Reiniciados Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set er14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Reiniciados Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set er14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Entrada Reiniciados Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set er1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Reiniciados Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set er1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Reiniciados Feminino 25 anos
            .CommandText = " Update temp_month_report set er25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Reiniciados Feminino 25 anos
            .CommandText = " Update temp_month_report set er25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1705 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Entrada Transferidos de Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set et14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Transferidos de Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set et14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Entrada Transferidos de Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set et1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Transferidos de Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set et1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Transferidos de Feminino 25 anos
            .CommandText = " Update temp_month_report set et25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Entrada Transferidos de Feminino 25 anos
            .CommandText = " Update temp_month_report set et25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1255 and v_value_coded.concept_id_value=1369 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Saida Suspensos Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set ss14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Suspensos Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set ss14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Saida Suspensos Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set ss1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Suspensos Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set ss1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Suspensos Feminino 25 anos
            .CommandText = " Update temp_month_report set ss25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Suspensos Feminino 25 anos
            .CommandText = " Update temp_month_report set ss25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1709 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Saida Transferidos para Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set st14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Transferidos para Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set st14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Saida Transferidos para Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set st1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Transferidos para Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set st1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Transferidos para Feminino 25 anos
            .CommandText = " Update temp_month_report set st25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Transferidos para Feminino 25 anos
            .CommandText = " Update temp_month_report set st25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1706 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            '===========================================================================================================================================================================================================================
            'Saida Abandonos Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set sa14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Abandonos Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set sa14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Saida Abandonos Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set sa1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Abandonos Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set sa1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Abandonos Feminino 25 anos
            .CommandText = " Update temp_month_report set sa25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Abandonos Feminino 25 anos
            .CommandText = " Update temp_month_report set sa25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1707 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            '===========================================================================================================================================================================================================================
            'Saida Obitos Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set so14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Obitos Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set so14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Saida Obitos Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set so1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Obitos Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set so1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Obitos Feminino 25 anos
            .CommandText = " Update temp_month_report set so25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Saida Obitos Feminino 25 anos
            .CommandText = " Update temp_month_report set so25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1708 and v_value_coded.concept_id_value=1366 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            '===========================================================================================================================================================================================================================
            'Em tratamento de TB Femininos menores de 15 anos
            .CommandText = " Update temp_month_report set etb14f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Em tratamento de TB Masculinos menores de 15 anos
            .CommandText = " Update temp_month_report set etb14m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age<=14 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()

            'Em tratamento de TB Femininos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set etb1524f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Em tratamento de TB Masculinos entre de 15 a 24 anos
            .CommandText = " Update temp_month_report set etb1524m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age between 15 and 24 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Em tratamento de TB Feminino 25 anos
            .CommandText = " Update temp_month_report set etb25f=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='F') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()
            'Em tratamento de TB Feminino 25 anos
            .CommandText = " Update temp_month_report set etb25m=(select count(distinct(v_encounter.patient_id)) from v_encounter,v_value_coded " & _
                            " where v_value_coded.person_id=v_encounter.patient_id and v_value_coded.encounter_id=v_encounter.encounter_id and " & _
                            " v_value_coded.concept_id=1268 and v_value_coded.concept_id_value=1256 and " & _
                            " v_encounter.location_id =" & Me.cboUS.SelectedValue & " and v_encounter.encounter_datetime between '" & dataInicial & "' and '" & dataFinal & "' and v_encounter.age>=25 and v_encounter.gender='M') " & _
                            " where id=" & idPrint & ""
            .ExecuteNonQuery()



        End With
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

    Private Sub cboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.SelectedIndexChanged
        Try
            Dim strCriterio = " distritoid='" & Me.cboDistrito.SelectedValue & "' and openmrs_id is not null"
            EncherCombo1(Me.cboUS, "nomeus", "hdd", "openmrs_id", strCriterio)
            If Me.cboUS.Items.Count > 0 Then
                Me.cboUS.SelectedValue = My.Settings.DefaultHddID
            End If
        Catch ex As Exception

        End Try
    End Sub

    
End Class
