Public Class frmCD4Paciente

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Cursor = Cursors.WaitCursor
        Try
            Cursor = Cursors.WaitCursor
            If Me.cboUS.SelectedIndex < 0 Then
                MsgBox("Seleccione o servico TARV")
                Me.cboUS.Focus()
                Cursor = Cursors.Default
                Exit Sub
            End If
            If Me.dataInicial.Value.Date > Me.dataFinal.Value.Date Then
                MsgBox("Ha inconsistencia entre a data inicial e a data final")
                Me.dataInicial.Focus()
                Cursor = Cursors.Default
                Exit Sub
            End If
            Dim strQuery As String = "Select concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) name," & _
            "patient_identifier.identifier nid,encounter.encounter_datetime,obs.value_numeric " & _
            " from openmrs.patient_identifier,openmrs.person,openmrs.patient,openmrs.person_name,openmrs.encounter,openmrs.obs " & _
            " where patient_identifier.patient_id=patient.patient_id and " & _
            " person.person_id=patient.patient_id and " & _
            " person.person_id=person_name.person_id and " & _
            " patient.patient_id=encounter.patient_id and " & _
            " encounter.encounter_id=obs.encounter_id and " & _
            " patient_identifier.identifier_type=2 and obs.concept_id=5497 and " & _
            " patient_identifier.voided=0 and person_name.voided=0 and patient.voided=0 and " & _
            " person.voided=0 and encounter.voided=0 and obs.voided=0 and encounter.location_id=" & Me.cboUS.SelectedValue & " and " & _
            " encounter.encounter_datetime between '" & dataMySQL(Me.dataInicial.Value.Date) & "' and '" & dataMySQL(Me.dataFinal.Value.Date) & "' "

            Dim patientID As Integer = 0
            If Not (Me.txtNID.Text = Nothing) Then
                Dim nid = Me.txtNIDInicio.Text & "/" & Me.txtNID.Text
                patientID = GetPatientOpenMRSIDByNID(nid)
                If patientID = 0 Or patientID = Nothing Then
                    Cursor = Cursors.Default
                    MsgBox("Nao existe paciente com o NID introduzido")
                    Me.txtNID.Text = ""
                    Exit Sub
                End If
                strQuery &= " and patient.patient_id=" & patientID
            End If

            Dim rpt As New CD4
            Dim forma As New frmPrintReports
            rpt.SetDataSource(TabelaDinamica(strQuery))
            If RecourdCount = 0 Then
                MsgBox("Nao ha dados por visualizar com os parametros introduzidos")
                Cursor = Cursors.Default
                Exit Sub
            End If
            rpt.SetParameterValue(rpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
            If Me.rdDetalhado.Checked Then
                rpt.SetParameterValue(rpt.Parameter_Tipo.ParameterFieldName, 0)
                rpt.SetParameterValue(rpt.Parameter_Titulo.ParameterFieldName, "HISTORICO DE CD4 DE PACIENTES")
            Else
                rpt.SetParameterValue(rpt.Parameter_Tipo.ParameterFieldName, 1)
                rpt.SetParameterValue(rpt.Parameter_Titulo.ParameterFieldName, "ULTIMO CD4 DE CADA PACIENTE")
            End If
            forma.rptViewer.ReportSource = rpt
            forma.Text = "CD4"


            forma.Show()
            Cursor = Cursors.Default


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

    Private Sub frmCD4Paciente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
            If Me.cboProvincia.Items.Count > 0 Then
                Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
            End If
            Me.txtNIDInicio.Text = My.Settings.DefaultHddNID
        Catch ex As Exception
            MsgBox("Error in Load: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class