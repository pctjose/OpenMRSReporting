Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub mnuConsultasAntesAberturaHDD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultasAntesAberturaHDD.Click
        frmSelectHDD.MdiParent = Me
        frmSelectHDD.Show()
    End Sub

    Private Sub mnuPacientesFalecidosFrida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPacientesFalecidosFrida.Click
        frmPacientesFalecidosFridaNaoBD.MdiParent = Me
        frmPacientesFalecidosFridaNaoBD.Show()
    End Sub

    Private Sub mnuFridaSemInicioTarv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFridaSemInicioTarv.Click
        frmPacienteFridaSemInicioTarv.MdiParent = Me
        frmPacienteFridaSemInicioTarv.Show()
    End Sub

    
    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        fechaConexoes()
        End
    End Sub

    Private Sub mnuConsultasSemObservacoes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultasSemObservacoes.Click
        frmConsultasSemObservacoes.MdiParent = Me
        frmConsultasSemObservacoes.Show()
    End Sub

    


    Private Sub PacientesQueDevemLevantarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacientesQueDevemLevantarToolStripMenuItem.Click
        frmPacientesVemLevantar.MdiParent = Me
        frmPacientesVemLevantar.Show()
    End Sub

    Private Sub MisauMensalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MisauMensalToolStripMenuItem.Click
        frmRelatorioMensal.MdiParent = Me
        frmRelatorioMensal.Show()
    End Sub

    Private Sub DPSCafeTARVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DPSCafeTARVToolStripMenuItem.Click
        frmRelatorioSemanal.MdiParent = Me
        frmRelatorioSemanalNovo.Show()
    End Sub

    Private Sub PEPFARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEPFARToolStripMenuItem.Click
        frmGeneralPrintReport.MdiParent = Me
        frmGeneralPrintReport.Show()
    End Sub

    

    Private Sub ConsultasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultasToolStripMenuItem.Click
        frmMaisDeUmaConsultaFrida.MdiParent = Me
        frmMaisDeUmaConsultaFrida.Show()
    End Sub

    
    Private Sub PTVPreNatalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PTVPreNatalToolStripMenuItem.Click
        frmptv.Close()
        frmptv.tipo = PTVMensal.PTVPreNatal
        frmptv.Text = "RELATÓRIO MENSAL - PTV/PRE-NATAL"
        frmptv.Show()
    End Sub

    Private Sub PTVMaternidadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PTVMaternidadeToolStripMenuItem.Click
        frmptv.Close()
        frmptv.tipo = PTVMensal.PTVMaternidade
        frmptv.Text = "RELATÓRIO MENSAL - PTV/MATERNIDADE"
        frmptv.Show()
    End Sub

    Private Sub CCRToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CCRToolStripMenuItem1.Click
        frmptv.Close()
        frmptv.tipo = PTVMensal.PTVCCR
        frmptv.Text = "RELATÓRIO MENSAL - CCR"
        frmptv.Show()
    End Sub

    Private Sub PacientesComDuploInicioTARVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacientesComDuploInicioTARVToolStripMenuItem.Click
        frmDuploInicioTARV.MdiParent = Me
        frmDuploInicioTARV.Show()

    End Sub

    Private Sub FaltososAbandonosETARVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FaltososAbandonosETARVToolStripMenuItem.Click
        frmAbandonoFaltoso.MdiParent = Me
        frmAbandonoFaltoso.Show()
    End Sub

    Private Sub EstadioHIVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadioHIVToolStripMenuItem.Click
        frmEstadioHIV.MdiParent = Me
        frmEstadioHIV.Show()
    End Sub

    Private Sub CD4ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CD4ToolStripMenuItem1.Click
        frmCD4Paciente.MdiParent = Me
        frmCD4Paciente.Show()
    End Sub

    Private Sub HistoricoTARVToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoricoTARVToolStripMenuItem1.Click
        frmListaLevantamento.MdiParent = Me
        frmListaLevantamento.Show()
    End Sub

    Private Sub ObsExpressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObsExpressToolStripMenuItem.Click
        frmExpressObs.MdiParent = Me
        frmExpressObs.Show()
    End Sub


    Private Sub TransferenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferenciaToolStripMenuItem.Click
        frmTransferencia.MdiParent = Me
        frmTransferencia.Show()
    End Sub

    Private Sub NotificaçãoDeSarcomaDeKaposiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotificaçãoDeSarcomaDeKaposiToolStripMenuItem.Click
        frmSarcomaKaposi.MdiParent = Me
        frmSarcomaKaposi.Show()
    End Sub

    Private Sub MaisDeUmAnoSemVisitaAUSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaisDeUmAnoSemVisitaAUSToolStripMenuItem.Click
        frmMaisDeUmAnoSemVisita.MdiParent = Me
        frmMaisDeUmAnoSemVisita.Show()
    End Sub

    

    Private Sub ColheitaDePCRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColheitaDePCRToolStripMenuItem.Click
        frmColheitaPCR.MdiParent = Me
        frmColheitaPCR.Show()
    End Sub

    Private Sub ColheitaDeCD4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColheitaDeCD4ToolStripMenuItem.Click
        frmColheitaCD4.MdiParent = Me
        frmColheitaCD4.Show()
    End Sub

    Private Sub GrávidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrávidasToolStripMenuItem.Click
        frmGravidas.MdiParent = Me
        frmGravidas.gBusca.Visible = False
        frmGravidas.Show()
    End Sub

    
    Private Sub ProfilaxiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfilaxiToolStripMenuItem.Click
        frmProfilaxia.MdiParent = Me
        frmProfilaxia.Show()
    End Sub

    Private Sub InscriToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InscriToolStripMenuItem.Click
        frmAdmissaoServicoTARV.MdiParent = Me
        frmAdmissaoServicoTARV.Show()
    End Sub

    Private Sub TARVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARVToolStripMenuItem.Click
        frmAbandonoFaltoso.MdiParent = Me
        frmAbandonoFaltoso.Show()
    End Sub

    Private Sub MovimentoFRIDAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimentoFRIDAToolStripMenuItem.Click
        frmMovimentoFRIDA.MdiParent = Me
        frmMovimentoFRIDA.Show()
    End Sub

    Private Sub TARVCohoortPeriodicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARVCohoortPeriodicoToolStripMenuItem.Click
        frmCohoortPeriodico.MdiParent = Me
        frmCohoortPeriodico.Show()
    End Sub

    Private Sub TARVToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARVToolStripMenuItem1.Click
        frmConsultas.MdiParent = Me
        frmConsultas.Show()
    End Sub

    Private Sub IdentificadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IdentificadoresToolStripMenuItem.Click
        frmPreferidos.Close()
        frmPreferidos.MdiParent = Me
        frmPreferidos.opcao = "NID"
        frmPreferidos.Show()
    End Sub

    Private Sub NomesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NomesToolStripMenuItem.Click
        frmPreferidos.Close()
        frmPreferidos.MdiParent = Me
        frmPreferidos.opcao = "NOME"
        frmPreferidos.Show()
    End Sub

    Private Sub EnderecoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnderecoToolStripMenuItem.Click
        frmPreferidos.Close()
        frmPreferidos.MdiParent = Me
        frmPreferidos.opcao = "ENDERECO"
        frmPreferidos.Show()
    End Sub

    Private Sub ContinuationReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContinuationReportToolStripMenuItem.Click
        frmContinuationReport.MdiParent = Me
        frmContinuationReport.Show()
    End Sub

    Private Sub TARVCOHOORTPERIODICO2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARVCOHOORTPERIODICO2ToolStripMenuItem.Click
        frmCoorteTARV.MdiParent = Me
        frmCoorteTARV.Show()
    End Sub

    Private Sub SESPSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SESPSToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        frmSESP.MdiParent = Me
        frmSESP.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub AnularConsultaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularConsultaToolStripMenuItem.Click
        frmAnularConsulta.MdiParent = Me
        frmAnularConsulta.Show()

    End Sub

    
    Private Sub STARVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STARVToolStripMenuItem.Click
        frmBuscaActiva.MdiParent = Me
        frmBuscaActiva.Show()
    End Sub

    Private Sub CPNPTVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CPNPTVToolStripMenuItem.Click
        frmGravidas.MdiParent = Me
        frmGravidas.gBusca.Visible = True
        frmGravidas.Show()
    End Sub

    Private Sub InicioNaoCoincideLev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InicioNaoCoincideLev.Click
        frmPacientesInicioNaoCoincideLev.MdiParent = Me
        frmPacientesInicioNaoCoincideLev.Show()
    End Sub

    Private Sub InicioSemFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InicioSemFila.Click
        frmPacientesInicioSemFila.MdiParent = Me
        frmPacientesInicioSemFila.Show()
    End Sub

    Private Sub SairamEmSeguimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairamEmSeguimento.Click
        frmPacientesSairamEmSeguimento.MdiParent = Me
        frmPacientesSairamEmSeguimento.Show()
    End Sub
End Class