Public Class frmDuploInicioTARV

    Private Sub frmDuploInicioTARV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
    End Sub

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        Try
            EncherCombo(Me.cboDistrito, "nome", "district", "DistritoID", "ProvinciaID", , Me.cboProvincia.SelectedValue)
            If cboDistrito.Items.Count > 0 Then
                cboDistrito.SelectedValue = My.Settings.DefaultDistrictID
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
        Try

            Cursor = Cursors.WaitCursor
            'DAOVALIDATOR.FillFRIDATRACK()

            If Me.cboUS.Items.Count <= 0 Then
                MsgBox("Seleccione a HDD")
                Me.cboUS.Focus()
                Cursor = Cursors.Default
                Exit Sub
            End If

            ExecuteFillDuploTARVTempTable()

            Cursor = Cursors.WaitCursor
            Dim rpt As New DuploInicioTarv

            Dim prpt As New printReport


            rpt.SetParameterValue(rpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
            rpt.SetParameterValue(rpt.Parameter_location_id.ParameterFieldName, Me.cboUS.SelectedValue)

            prpt.LogOnReportAndSubReportsOpenMRSReporting(rpt)

            Dim forma As New frmPrintReports
            forma.rptViewer.ReportSource = rpt
            forma.Text = "Pacientes com duplo inicio de TARV"
            forma.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve Erro: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    
End Class