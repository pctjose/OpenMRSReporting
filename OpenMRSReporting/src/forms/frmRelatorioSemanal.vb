

Public Class frmRelatorioSemanal

    Private Sub frmRelatorioSemanal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'EncherCombo(Me.cboUS, "name", "Location", "location_id")
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If Me.cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
        Me.lblInfo.Text = "Preencha os campos e clique Visualizar..."
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
    Private Sub PrepararNovo(ByVal rptVO As ReportPrintVO)

        Me.lblInfo.Text = "Verificando os Fridas de cada paciente..."
        Me.StatusStrip1.Refresh()
        'RelatorioSemanalDAO.PrepararFrida()
        Me.ProgressBar.Value = 10

        Me.lblInfo.Text = "Verificando estado de mulheres gravidas..."
        Me.StatusStrip1.Refresh()
        'RelatorioSemanalDAO.PrepararGravidas()
        Me.ProgressBar.Value = 20

        Me.lblInfo.Text = "Processando Inscritos..."
        Me.StatusStrip1.Refresh()
        RelatorioSemanalDAO.INDICATOR_INSCRITOS(rptVO)
        Me.ProgressBar.Value = 30

        Me.lblInfo.Text = "Processando Consultas Clinicas..."
        Me.StatusStrip1.Refresh()
        RelatorioSemanalDAO.INDICATOR_CONSULTAS(rptVO)
        Me.ProgressBar.Value = 40

        Me.lblInfo.Text = "Processando Entradas TARV..."
        Me.StatusStrip1.Refresh()
        RelatorioSemanalDAO.INDICADORENTRADATARV(rptVO)
        Me.ProgressBar.Value = 50

        Me.lblInfo.Text = "Processando Saidas TARV..."
        Me.StatusStrip1.Refresh()
        RelatorioSemanalDAO.INDICADORSAIDATARV(rptVO)
        Me.ProgressBar.Value = 60

        Me.lblInfo.Text = "Processando pacientes em TARV..."
        Me.StatusStrip1.Refresh()
        RelatorioSemanalDAO.INDICATOR_EMTRATAMENTO(rptVO)
        Me.ProgressBar.Value = 70

        Me.lblInfo.Text = "Processando Tratamento de TB..."
        Me.StatusStrip1.Refresh()
        RelatorioSemanalDAO.INDICATOR_TUBERCULOSE(rptVO)
        Me.ProgressBar.Value = 80

        Me.lblInfo.Text = "Processando referencia..."
        Me.StatusStrip1.Refresh()
        RelatorioSemanalDAO.INDICATOR_REFERIDOSDE(rptVO)
        Me.ProgressBar.Value = 90

    End Sub

    Private Sub cmdAutomatico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutomatico.Click
        If Me.cboUS.SelectedIndex < 0 Then
            MsgBox("Seleccione a Unidade Sanitaria")
            Me.cboUS.Focus()
            Exit Sub
        End If

        If Not (Me.dataInicial.Value.DayOfWeek = DayOfWeek.Saturday) Then
            MsgBox("O dia da data inicial tem que ser um sabado")
            Me.dataInicial.Focus()
            Exit Sub
        End If

        If Not (Me.dataFinal.Value.DayOfWeek = DayOfWeek.Friday) Then
            MsgBox("O dia da data final tem que ser uma sexta feira")
            Me.dataFinal.Focus()
            Exit Sub
        End If

        If DateDiff(DateInterval.Day, Me.dataInicial.Value, Me.dataFinal.Value) <> 6 Then
            MsgBox("O periodo seleccionado nao corresponde a uma semana.")
            Me.dataInicial.Focus()
            Exit Sub
        End If
        Dim rptPrinted As New ReportPrintVO
        Dim report As New ReportPrintVO

        report.DateCreated = Now.Date
        report.CreatedBy = utilizador
        'report.Location = HddDAO.getHddByOpenMRSID(Me.cboUS.SelectedValue)
        report.Location = HddDAO.getHddByOpenMRSID(My.Settings.DefaultHddID)
        report.Report = ReportDAO.getReportByID(My.Settings.DPSCafeTARVReportID)
        report.ReportDateRangeEnd = Me.dataFinal.Value.Date
        report.ReportDateRangeStart = Me.dataInicial.Value.Date
        report.Voided = 0

        'rptPrinted = ReportPrintDAO.getPrintReportByHDDDateRangeReport(Me.cboUS.SelectedValue, Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, My.Settings.DPSCafeTARVReportID)
        rptPrinted = ReportPrintDAO.getPrintReportByHDDDateRangeReport(My.Settings.DefaultHddID, Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, My.Settings.DPSCafeTARVReportID)
        If rptPrinted.isNull Then
            If ReportPrintDAO.insert(report) Then
                PrepararNovo(report)
                Me.lblInfo.Text = "Indicadores da Semana processados..."
                Me.ProgressBar.Value = 100
                Me.StatusStrip1.Refresh()
            End If
        Else
            If MsgBox("Os indicadores desta semana ja foram processados por " & rptPrinted.CreatedBy.Name & " no dia " & rptPrinted.DateCreated & "." & _
                       Chr(13) & Chr(13) & "Pretende processar novamente? (Nota: Os processados antes serao invalidados )", MsgBoxStyle.YesNo, "Processado") = MsgBoxResult.Yes Then

                Me.lblInfo.Text = "Anulando indicadores anteriormente impressos..."
                Me.StatusStrip1.Refresh()

                rptPrinted.Voided = 1
                rptPrinted.VoidedBy = utilizador
                rptPrinted.VoidedDate = Now
                rptPrinted.VoidedReason = "Reprocessado por " & utilizador.Name & " em " & Now
                ReportPrintDAO.void(rptPrinted)

                If ReportPrintDAO.insert(report) Then
                    PrepararNovo(report)
                    Me.lblInfo.Text = "Indicadores da Semana Reprocessados..."
                    Me.ProgressBar.Value = 100
                    Me.StatusStrip1.Refresh()
                End If

            End If
        End If
    End Sub

    Private Sub cmdManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdManual.Click
        If Me.cboUS.SelectedIndex < 0 Then
            MsgBox("Seleccione a Unidade Sanitaria")
            Me.cboUS.Focus()
            Exit Sub
        End If

        If Not (Me.dataInicial.Value.DayOfWeek = DayOfWeek.Saturday) Then
            MsgBox("O dia da data inicial tem que ser um sabado")
            Me.dataInicial.Focus()
            Exit Sub
        End If

        If Not (Me.dataFinal.Value.DayOfWeek = DayOfWeek.Friday) Then
            MsgBox("O dia da data final tem que ser uma sexta feira")
            Me.dataFinal.Focus()
            Exit Sub
        End If

        If DateDiff(DateInterval.Day, Me.dataInicial.Value, Me.dataFinal.Value) <> 6 Then
            MsgBox("O periodo seleccionado nao corresponde a uma semana.")
            Me.dataInicial.Focus()
            Exit Sub
        End If
        Dim rptPrinted As New ReportPrintVO
        rptPrinted = ReportPrintDAO.getPrintReportByHDDDateRangeReport(Me.cboUS.SelectedValue, Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, My.Settings.DPSCafeTARVReportID)
        If rptPrinted.isNull Then
            MsgBox("Tem que processar indicadores automaticos primeiro...", , "Automatico")
            Me.dataInicial.Focus()
            Exit Sub
        Else
            frmIndicadoresSemanaisManuais.reportPrint = rptPrinted
            frmIndicadoresSemanaisManuais.Text = "Relatorio (Indicadores) Semanal: (Semana de " & Me.dataInicial.Value.Date & " a " & Me.dataFinal.Value.Date & ")"
            frmIndicadoresSemanaisManuais.ShowDialog()
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        'Dim boo As New Microsoft.Office.Tools.Excel.Workbook
        'Dim dg As New DataGridView

        Dim strQuery As String = "SELECT indicator.access_id as Indicator," & _
                                " reportdata.result as Result," & _
                                " reportdata.StartDate as StartDate," & _
                                " reportdata.EndDate as EndDate," & _
                                " user.access_id as RunBy," & _
                                " reportdata.RunOn as RunOn," & _
                                " hdd.access_id as Location," & _
                                " report_print.Report_print_report as Report " & _
                                " FROM user, hdd, indicator, report_print, reportdata" & _
                                " where " & _
                                " reportdata.indicator_id=indicator.indicators_id and " & _
                                " reportdata.report_id=report_print.Reports_ID and " & _
                                " reportdata.RunBy=user.userid and " & _
                                " reportdata.Location=hdd.openmrs_id "

        Me.ProgressBar.Value = 20
        Me.lblInfo.Text = "Exportando indicadores..."
        Me.StatusStrip1.Refresh()
        ExportDataToExcelFile(TabelaDinamica(strQuery), "C:\SMART\reportdata.xls")
        Me.ProgressBar.Value = 90
        Me.lblInfo.Text = "Exportacao para C:\SMART\reportdata.xls completa"
        Me.ProgressBar.Value = 100
        Me.StatusStrip1.Refresh()

    End Sub

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click

        If Me.cboUS.SelectedIndex < 0 Then
            MsgBox("Seleccione a Unidade Sanitaria")
            Me.cboUS.Focus()
            Exit Sub
        End If

        If Not (Me.dataInicial.Value.DayOfWeek = DayOfWeek.Saturday) Then
            MsgBox("O dia da data inicial tem que ser um sabado")
            Me.dataInicial.Focus()
            Exit Sub
        End If

        If Not (Me.dataFinal.Value.DayOfWeek = DayOfWeek.Friday) Then
            MsgBox("O dia da data final tem que ser uma sexta feira")
            Me.dataFinal.Focus()
            Exit Sub
        End If

        If DateDiff(DateInterval.Day, Me.dataInicial.Value, Me.dataFinal.Value) <> 6 Then
            MsgBox("O periodo seleccionado nao corresponde a uma semana.")
            Me.dataInicial.Focus()
            Exit Sub
        End If
        Dim rptPrinted As New ReportPrintVO
        rptPrinted = ReportPrintDAO.getPrintReportByHDDDateRangeReport(Me.cboUS.SelectedValue, Me.dataInicial.Value.Date, Me.dataFinal.Value.Date, My.Settings.DPSCafeTARVReportID)
        If rptPrinted.isNull Then
            MsgBox("Tem que processar indicadores do periodo primeiro...", , "Automatico")
            Me.dataInicial.Focus()
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Dim strQuery As String = "select 	indicator.indicator_name," & _
                             " reportdata.result as Result," & _
                             " reportdata.StartDate as StartDate," & _
                             " reportdata.EndDate as EndDate," & _
                             " reportdata.RunOn as RunOn," & _
                             " report.reportname as Relatorio," & _
                             " report.id as ReportID" & _
                            " from report, indicator, report_print, reportdata " & _
                            " where " & _
                            " reportdata.indicator_id=indicator.indicators_id and " & _
                            " reportdata.report_id=report_print.Reports_ID and " & _
                            " report_print.Report_print_report=report.id and report_print.Reports_ID=" & rptPrinted.ReportsID & ""
        Dim rpt As New Indicadores
        Dim forma As New frmPrintReports
        rpt.SetDataSource(TabelaDinamica(strQuery))
        If RecourdCount = 0 Then
            MsgBox("Nao ha dados por visualizar com os parametros introduzidos")
            Cursor = Cursors.Default
            Exit Sub
        End If
        rpt.SetParameterValue(rpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
        forma.rptViewer.ReportSource = rpt
        forma.Text = "Indicadores"


        forma.Show()
        Cursor = Cursors.Default

    End Sub
End Class