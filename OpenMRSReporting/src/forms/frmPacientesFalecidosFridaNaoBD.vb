Public Class frmPacientesFalecidosFridaNaoBD

    Private Sub frmPacientesFalecidosFridaNaoBD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
        'cboProvincia.SelectedValue = "04"
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

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        Try
            EncherCombo(Me.cboDistrito, "nome", "district", "DistritoID", "ProvinciaID", , Me.cboProvincia.SelectedValue)
            If Me.cboDistrito.Items.Count > 0 Then
                Me.cboDistrito.SelectedValue = My.Settings.DefaultDistrictID
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Cursor = Cursors.WaitCursor
        Dim rpt As New PacientesFalecidosFridaNaoBDODBC
        If Me.cboUS.Items.Count <= 0 Then
            MsgBox("Seleccione a HDD")
            Me.cboUS.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If
        Dim prtRPT As New printReport
        'Dim strQuery As String = "select 	v_patient.patient_id," & _
        '                        "v_patient.given_name," & _
        '                        "v_patient.middle_name," & _
        '                        "v_patient.family_name," & _
        '                        "trim(concat(v_patient.given_name,' ',v_patient.middle_name,' ',v_patient.family_name)) as p_full_name," & _
        '                        "v_patient.identifier as NID," & _
        '                        "v_patient.dead," & _
        '                        "encounter.location_id," & _
        '                        "encounter.encounter_id," & _
        '                        "encounter.encounter_datetime," & _
        '                        "encounter.date_created," & _
        '                        "encounter.voided," & _
        '                        "form.form_id," & _
        '                        "form.name as formulario," & _
        '                        "encounter_type.encounter_type_id," & _
        '                        "encounter_type.name as tipo," & _
        '                        "v_users.full_name as u_full_name," & _
        '                        "location.name as hdd " & _
        '                        " from v_patient, encounter, Form, encounter_type, v_users, Location, v_value_coded " & _
        '                        " where v_patient.patient_id=encounter.patient_id and " & _
        '                        " encounter.encounter_type=encounter_type.encounter_type_id and " & _
        '                        " encounter.form_id=form.form_id and encounter.creator=v_users.user_id and " & _
        '                        " encounter.location_id=location.location_id and " & _
        '                        " encounter.encounter_id=v_value_coded.encounter_id and " & _
        '                        " v_value_coded.concept_id=1708 and " & _
        '                        " v_value_coded.concept_id_value=1366 and " & _
        '                        " v_patient.dead=0 and v_value_coded.voided=0 and v_patient.voided=0 and encounter.voided=0 and encounter.location_id=" & Me.cboUS.SelectedValue & " order by v_patient.given_name"
        'rpt.SetDataSource(TabelaDinamicaOpenMRSDATABASE(strQuery))
        'If RecourdCount = 0 Then
        '    MsgBox("Nao ha pacientes registadas como falecidos no frida e nao reflectido no estado do paciente.")
        '    Cursor = Cursors.Default
        '    Exit Sub
        'End If
        'rpt.SetParameterValue(rpt.Parameter_data.ParameterFieldName, Me.dataAbertura.Value.Date)
        rpt.SetParameterValue(rpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
        rpt.SetParameterValue(rpt.Parameter_hddid.ParameterFieldName, Me.cboUS.SelectedValue)
        prtRPT.LogOnReportAndSubReportsOpenMRSReporting(rpt)
        Dim forma As New frmPrintReports
        forma.rptViewer.ReportSource = rpt

        forma.Show()
        Cursor = Cursors.Default

    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class