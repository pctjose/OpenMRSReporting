Public Class frmSelectHDD

    Private Sub frmSelectHDD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If Me.cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
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

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        Try
            EncherCombo(Me.cboDistrito, "nome", "district", "DistritoID", "ProvinciaID", , Me.cboProvincia.SelectedValue)
            If Me.cboDistrito.Items.Count > 0 Then
                Me.cboDistrito.SelectedValue = My.Settings.DefaultDistrictID
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub cboUS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUS.SelectedIndexChanged
    '    Try
    '        Dim hdd As HddVO = HddDAO.getHddByOpenMRSID(Me.cboUS.SelectedValue)
    '        Me.txtDataAbertura.Text = hdd.hddDataAbertura
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '    End Try

    'End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        'TabelaDinamicaOpenMRSDATABASE("Select * from v_consulta_antes_180706")
        Me.Close()
    End Sub

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Cursor = Cursors.WaitCursor

        Dim rpt As New ConsultasDataInconsistentes

        If Me.cboUS.Items.Count <= 0 Then
            MsgBox("Seleccione a HDD")
            Me.cboUS.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim prrpt As New printReport
        'Dim dataAbertura1 As String
        'dataAbertura1 = dataMySQL(Me.dataAbertura.Value.Date)

        'Dim strQuery As String
        'strQuery = "select 	v_patient.patient_id," & _
        '            "v_patient.given_name," & _
        '            "v_patient.middle_name," & _
        '            "v_patient.family_name," & _
        '            "trim(concat(v_patient.given_name,' ',v_patient.middle_name,' ',v_patient.family_name)) as p_full_name," & _
        '            "v_patient.identifier as NID," & _
        '            "encounter.location_id," & _
        '            "encounter.encounter_id," & _
        '            "encounter.encounter_datetime," & _
        '            "encounter.date_created," & _
        '            "encounter.voided," & _
        '            "form.form_id, " & _
        '            "form.name as formulario," & _
        '            "encounter_type.encounter_type_id," & _
        '            "encounter_type.name as tipo," & _
        '            "v_users.full_name as u_full_name," & _
        '            "location.name as hdd " & _
        '            " from v_patient, encounter, Form, encounter_type, v_users, Location " & _
        '            " where v_patient.patient_id=encounter.patient_id and " & _
        '            " encounter.encounter_type=encounter_type.encounter_type_id and " & _
        '            " encounter.form_id=form.form_id and encounter.creator=v_users.user_id and " & _
        '            " encounter.location_id=location.location_id and " & _
        '            " encounter.encounter_datetime<'" & dataAbertura1 & "' and encounter.location_id=" & Me.cboUS.SelectedValue & ""


        'rpt.SetDataSource(TabelaDinamicaOpenMRSDATABASE(strQuery))
        'If RecourdCount = 0 Then
        '    MsgBox("Nao pacientes com consultas registada antes da data de abertura do HDD")
        '    Cursor = Cursors.Default
        '    Exit Sub
        'End If

        'rpt.SetParameterValue(rpt.Parameter_data.ParameterFieldName, Me.txtDataAbertura.Text)
        rpt.SetParameterValue(rpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
        rpt.SetParameterValue(rpt.Parameter_hddID.ParameterFieldName, Me.cboUS.SelectedValue)
        
        prrpt.LogOnReportAndSubReportsOpenMRSReporting(rpt)

        Dim forma As New frmPrintReports

        forma.rptViewer.ReportSource = rpt

        forma.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdDataRetorno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDataRetorno.Click
        Cursor = Cursors.WaitCursor

        Dim rpt As New DataRetornoInconsistente

        If Me.cboUS.Items.Count <= 0 Then
            MsgBox("Seleccione a Unidade Sanitaria")
            Me.cboUS.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim prrpt As New printReport
        'Dim dataAbertura1 As String
        'dataAbertura1 = dataMySQL(Me.dataAbertura.Value.Date)

        'Dim strQuery As String
        'strQuery = "select 	v_patient.patient_id," & _
        '            "v_patient.given_name," & _
        '            "v_patient.middle_name," & _
        '            "v_patient.family_name," & _
        '            "trim(concat(v_patient.given_name,' ',v_patient.middle_name,' ',v_patient.family_name)) as p_full_name," & _
        '            "v_patient.identifier as NID," & _
        '            "encounter.location_id," & _
        '            "encounter.encounter_id," & _
        '            "encounter.encounter_datetime," & _
        '            "encounter.date_created," & _
        '            "encounter.voided," & _
        '            "form.form_id, " & _
        '            "form.name as formulario," & _
        '            "encounter_type.encounter_type_id," & _
        '            "encounter_type.name as tipo," & _
        '            "v_users.full_name as u_full_name," & _
        '            "location.name as hdd " & _
        '            " from v_patient, encounter, Form, encounter_type, v_users, Location " & _
        '            " where v_patient.patient_id=encounter.patient_id and " & _
        '            " encounter.encounter_type=encounter_type.encounter_type_id and " & _
        '            " encounter.form_id=form.form_id and encounter.creator=v_users.user_id and " & _
        '            " encounter.location_id=location.location_id and " & _
        '            " encounter.encounter_datetime<'" & dataAbertura1 & "' and encounter.location_id=" & Me.cboUS.SelectedValue & ""


        'rpt.SetDataSource(TabelaDinamicaOpenMRSDATABASE(strQuery))
        'If RecourdCount = 0 Then
        '    MsgBox("Nao pacientes com consultas registada antes da data de abertura do HDD")
        '    Cursor = Cursors.Default
        '    Exit Sub
        'End If

        'rpt.SetParameterValue(rpt.Parameter_data.ParameterFieldName, Me.txtDataAbertura.Text)
        rpt.SetParameterValue(rpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
        'rpt.SetParameterValue(rpt.Parameter_hddID.ParameterFieldName, Me.cboUS.SelectedValue)

        prrpt.LogOnReportAndSubReportsOpenMRSReporting(rpt)

        Dim forma As New frmPrintReports

        forma.rptViewer.ReportSource = rpt

        forma.Show()
        Cursor = Cursors.Default
    End Sub

    
End Class