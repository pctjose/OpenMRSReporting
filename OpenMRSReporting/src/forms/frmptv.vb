Public Class frmptv
    Friend tipo As Int16
    Dim dataInicial As String
    Dim dataFinal As String
    Dim idPrint As Int16
    Private Sub frmptv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboMes.SelectedIndex = Month(Now.Date) - 1
        'EncherCombo(Me.cboUS, "name", "Location", "location_id")
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If Me.cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
        Me.lblInfo.Text = "Preencha os campos e clique Visualizar..."
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

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Cursor = Cursors.WaitCursor
        Dim rptVO As New ReportPrintVO
        Dim mmrpt As New RelatorioMensal
        Dim forma As New frmPrintReports

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
        If CInt(Me.txtAno.Text) < 2005 Then
            MsgBox("O ano introduzido e anterior a 2006, nao ha dados nesse periodo")
            Me.txtAno.Focus()
            Exit Sub
        End If
        'Cursor = Cursors.WaitCursor

        montarData()

        'Dim ReportID As Int32 = SeeIfPrintedReportInMonthChoosen()
        Dim printedRpt As New ReportPrintVO
        Me.lblInfo.Text = "Verificando relatorio imprimido anteriormente..."
        Me.StatusStrip1.Refresh()

        rptVO.CreatedBy = utilizador
        rptVO.DateCreated = Now.Date
        rptVO.Location = HddDAO.getHddByOpenMRSID(Me.cboUS.SelectedValue)
        rptVO.ReportDateRangeEnd = dataFinal
        rptVO.ReportDateRangeStart = dataInicial
        If tipo = PTVMensal.PTVPreNatal Then
            rptVO.Report = ReportDAO.getReportByID(My.Settings.PTVPreNatalMensal)
        ElseIf tipo = PTVMensal.PTVMaternidade Then
            rptVO.Report = ReportDAO.getReportByID(My.Settings.PTVMaternidadeMensal)
        ElseIf tipo = PTVMensal.PTVCCR Then
            rptVO.Report = ReportDAO.getReportByID(My.Settings.PTVCCRMensal)
        End If
        rptVO.Voided = 0

        printedRpt = ReportPrintDAO.getPrintReportByHDDDateRangeReport(Me.cboUS.SelectedValue, dataInicial, dataFinal, rptVO.Report.Id)

        ProgressBar.Value = 10


        If printedRpt.isNull Then

            If ReportPrintDAO.insert(rptVO) Then


                PrepararNovo(rptVO)

                Me.lblInfo.Text = "Visualizando o Relatorio..."
                Me.StatusStrip1.Refresh()

                If tipo = PTVMensal.PTVPreNatal Then
                    Dim ptvPreNatal As New PTVConsultaPreNatal
                    'Dim forma As New frmPrintReports

                    ptvPreNatal.SetDataSource(PTVDAO.PTVPreNatal(rptVO.ReportsID, rptVO.Location.hddOpenMRSID))

                    ProgressBar.Value = 90

                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)
                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_us.ParameterFieldName, Me.cboUS.Text)
                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_mes.ParameterFieldName, Me.cboMes.Text)

                    forma.rptViewer.ReportSource = ptvPreNatal
                    forma.Text = "PTV Pre-Natal"
                    ProgressBar.Value = 100
                    forma.Show()

                ElseIf tipo = PTVMensal.PTVMaternidade Then
                    Dim ptvMaternidade As New PTVMaternidade
                    'Dim forma As New frmPrintReports

                    ptvMaternidade.SetDataSource(PTVDAO.PTVMaternidade(rptVO.ReportsID, rptVO.Location.hddOpenMRSID))

                    ProgressBar.Value = 90

                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)
                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_us.ParameterFieldName, Me.cboUS.Text)
                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_mes.ParameterFieldName, Me.cboMes.Text)

                    forma.rptViewer.ReportSource = ptvMaternidade
                    forma.Text = "PTV Maternidade"
                    ProgressBar.Value = 100
                    forma.Show()
                ElseIf tipo = PTVMensal.PTVCCR Then
                    Dim ptvCCR As New PTVCCR
                    'Dim forma As New frmPrintReports

                    ptvCCR.SetDataSource(PTVDAO.PTVCCR(rptVO.ReportsID, rptVO.Location.hddOpenMRSID))

                    ProgressBar.Value = 90

                    ptvCCR.SetParameterValue(ptvCCR.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)
                    ptvCCR.SetParameterValue(ptvCCR.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                    ptvCCR.SetParameterValue(ptvCCR.Parameter_us.ParameterFieldName, Me.cboUS.Text)
                    ptvCCR.SetParameterValue(ptvCCR.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                    ptvCCR.SetParameterValue(ptvCCR.Parameter_mes.ParameterFieldName, Me.cboMes.Text)

                    forma.rptViewer.ReportSource = ptvCCR
                    forma.Text = "PTV CCR"
                    ProgressBar.Value = 100
                    forma.Show()
                End If
                Me.lblInfo.Text = "Visualizado..."
                Me.StatusStrip1.Refresh()
            End If

        Else
            Dim resp As Int16 = MsgBox("Este relatorio ja foi emitido antes." & Chr(13) & "O que pretende fazer?" & Chr(13) & "Yes - Para Emitir novamente" & Chr(13) & "No - Para visualizar o emitido antes." & Chr(13) & " Cancel - Cancelar", MsgBoxStyle.YesNoCancel, "Imprimir")
            If resp = MsgBoxResult.Yes Then
                printedRpt.Voided = True
                printedRpt.VoidedBy = utilizador
                printedRpt.VoidedDate = Now.Date
                printedRpt.VoidedReason = "Reeimprimido por " & utilizador.Name & " em " & Now.Date

                ReportPrintDAO.void(printedRpt)

                If ReportPrintDAO.insert(rptVO) Then


                    PrepararNovo(rptVO)

                    Me.lblInfo.Text = "Visualizando o Relatorio..."
                    Me.StatusStrip1.Refresh()

                    If tipo = PTVMensal.PTVPreNatal Then
                        Dim ptvPreNatal As New PTVConsultaPreNatal
                        'Dim forma As New frmPrintReports

                        ptvPreNatal.SetDataSource(PTVDAO.PTVPreNatal(rptVO.ReportsID, rptVO.Location.hddOpenMRSID))

                        ProgressBar.Value = 90

                        ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)
                        ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                        ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_us.ParameterFieldName, Me.cboUS.Text)
                        ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                        ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_mes.ParameterFieldName, Me.cboMes.Text)

                        forma.rptViewer.ReportSource = ptvPreNatal
                        forma.Text = "PTV Pre-Natal"
                        ProgressBar.Value = 100
                        forma.Show()

                    ElseIf tipo = PTVMensal.PTVMaternidade Then
                        Dim ptvMaternidade As New PTVMaternidade
                        'Dim forma As New frmPrintReports

                        ptvMaternidade.SetDataSource(PTVDAO.PTVMaternidade(rptVO.ReportsID, rptVO.Location.hddOpenMRSID))

                        ProgressBar.Value = 90

                        ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)
                        ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                        ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_us.ParameterFieldName, Me.cboUS.Text)
                        ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                        ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_mes.ParameterFieldName, Me.cboMes.Text)

                        forma.rptViewer.ReportSource = ptvMaternidade
                        forma.Text = "PTV Maternidade"
                        ProgressBar.Value = 100
                        forma.Show()
                    ElseIf tipo = PTVMensal.PTVCCR Then
                        Dim ptvCCR As New PTVCCR
                        'Dim forma As New frmPrintReports

                        ptvCCR.SetDataSource(PTVDAO.PTVCCR(rptVO.ReportsID, rptVO.Location.hddOpenMRSID))

                        ProgressBar.Value = 90

                        ptvCCR.SetParameterValue(ptvCCR.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)
                        ptvCCR.SetParameterValue(ptvCCR.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                        ptvCCR.SetParameterValue(ptvCCR.Parameter_us.ParameterFieldName, Me.cboUS.Text)
                        ptvCCR.SetParameterValue(ptvCCR.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                        ptvCCR.SetParameterValue(ptvCCR.Parameter_mes.ParameterFieldName, Me.cboMes.Text)

                        forma.rptViewer.ReportSource = ptvCCR
                        forma.Text = "PTV CCR"
                        ProgressBar.Value = 100
                        forma.Show()
                    End If
                    Me.lblInfo.Text = "Visualizado..."
                    Me.StatusStrip1.Refresh()
                End If
                'Void o impresso, re-imprimir de novo
            ElseIf resp = MsgBoxResult.No Then

                Me.lblInfo.Text = "Visualizando o Relatorio..."
                Me.StatusStrip1.Refresh()

                If tipo = PTVMensal.PTVPreNatal Then
                    Dim ptvPreNatal As New PTVConsultaPreNatal
                    'Dim forma As New frmPrintReports

                    ptvPreNatal.SetDataSource(PTVDAO.PTVPreNatal(printedRpt.ReportsID, printedRpt.Location.hddOpenMRSID))

                    ProgressBar.Value = 90

                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)
                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_us.ParameterFieldName, Me.cboUS.Text)
                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                    ptvPreNatal.SetParameterValue(ptvPreNatal.Parameter_mes.ParameterFieldName, Me.cboMes.Text)

                    forma.rptViewer.ReportSource = ptvPreNatal
                    forma.Text = "PTV Pre-Natal"
                    ProgressBar.Value = 100
                    forma.Show()

                ElseIf tipo = PTVMensal.PTVMaternidade Then
                    Dim ptvMaternidade As New PTVMaternidade
                    'Dim forma As New frmPrintReports

                    ptvMaternidade.SetDataSource(PTVDAO.PTVMaternidade(rptVO.ReportsID, rptVO.Location.hddOpenMRSID))

                    ProgressBar.Value = 90

                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)
                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_us.ParameterFieldName, Me.cboUS.Text)
                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                    ptvMaternidade.SetParameterValue(ptvMaternidade.Parameter_mes.ParameterFieldName, Me.cboMes.Text)

                    forma.rptViewer.ReportSource = ptvMaternidade
                    forma.Text = "PTV Maternidade"
                    ProgressBar.Value = 100
                    forma.Show()
                ElseIf tipo = PTVMensal.PTVCCR Then
                    Dim ptvCCR As New PTVCCR
                    'Dim forma As New frmPrintReports

                    ptvCCR.SetDataSource(PTVDAO.PTVCCR(rptVO.ReportsID, rptVO.Location.hddOpenMRSID))

                    ProgressBar.Value = 90

                    ptvCCR.SetParameterValue(ptvCCR.Parameter_provincia.ParameterFieldName, Me.cboProvincia.Text)
                    ptvCCR.SetParameterValue(ptvCCR.Parameter_distrito.ParameterFieldName, Me.cboDistrito.Text)
                    ptvCCR.SetParameterValue(ptvCCR.Parameter_us.ParameterFieldName, Me.cboUS.Text)
                    ptvCCR.SetParameterValue(ptvCCR.Parameter_ano.ParameterFieldName, Me.txtAno.Text)
                    ptvCCR.SetParameterValue(ptvCCR.Parameter_mes.ParameterFieldName, Me.cboMes.Text)

                    forma.rptViewer.ReportSource = ptvCCR
                    forma.Text = "PTV CCR"
                    ProgressBar.Value = 100
                    forma.Show()
                End If
                Me.lblInfo.Text = "Visualizado..."
                Me.StatusStrip1.Refresh()
            Else
                Me.Close()
            End If

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub PrepararNovo(ByVal rptVO As ReportPrintVO)
        If tipo = PTVMensal.PTVPreNatal Then
            Me.lblInfo.Text = "Calculando Indicadores PRE-NATAL..."
            Me.StatusStrip1.Refresh()
            PTVDAO.CalcularPTVPreNatal(rptVO)
            Me.ProgressBar.Value = 60
        ElseIf tipo = PTVMensal.PTVMaternidade Then
            Me.lblInfo.Text = "Calculando Indicadores MATERNIDADE..."
            Me.StatusStrip1.Refresh()
            PTVDAO.CalcularPTVMaternidade(rptVO)
            Me.ProgressBar.Value = 60
        ElseIf tipo = PTVMensal.PTVCCR Then
            Me.lblInfo.Text = "Calculando Indicadores CCR..."
            Me.StatusStrip1.Refresh()
            PTVDAO.CalcularPTVCCR(rptVO)
            Me.ProgressBar.Value = 60
        End If
    End Sub

    Private Sub txtAno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAno.KeyPress
        proibirLetrasInt(e, txtAno.Text)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class