Public Class frmMaisDeUmaConsultaFrida

    Private Sub frmMaisDeUmaConsultaFrida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
            If Me.cboProvincia.Items.Count > 0 Then
                Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
            End If

        Catch ex As Exception
            MsgBox("Error in Load: " & ex.Message)
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

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Cursor = Cursors.WaitCursor
        Dim rpt As New ConsultasFridaMesmaData
        Dim forma As New frmPrintReports

        Dim sqlQuery As String = ""

        If Me.chkIncluir.Checked Then
            sqlQuery = "select concat(person_name.given_name,' ', person_name.middle_name,' ',person_name.family_name) nome," & _
                            " identifier nid,encounter_datetime,count(*) numero " & _
                            " from openmrs.person_name, openmrs.patient, openmrs.patient_identifier, openmrs.encounter " & _
                            " where " & _
                            " patient.patient_id=person_name.person_id and " & _
                            " patient_identifier.patient_id=patient.patient_id and " & _
                            " patient.patient_id=encounter.patient_id and patient_identifier.identifier_type=2 and person_name.preferred=1 and " & _
                            " patient.voided=0 and encounter.voided=0 and person_name.voided=0 and encounter.encounter_type=18 and encounter.location_id in (select openmrs_id from hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "')" & _
                            " group by identifier,encounter_datetime" & _
                            " having count(*)>=2"
        Else
            sqlQuery = "select concat(person_name.given_name,' ', person_name.middle_name,' ',person_name.family_name) nome," & _
                            " identifier nid,encounter_datetime,count(*) numero " & _
                            " from openmrs.person_name, openmrs.patient, openmrs.patient_identifier, openmrs.encounter " & _
                            " where " & _
                            " patient.patient_id=person_name.person_id and " & _
                            " patient_identifier.patient_id=patient.patient_id and " & _
                            " patient.patient_id=encounter.patient_id and patient_identifier.identifier_type=2 and person_name.preferred=1 and " & _
                            " patient.voided=0 and encounter.voided=0 and person_name.voided=0 and encounter.encounter_type=18 and encounter.location_id=" & Me.cboUS.SelectedValue & "" & _
                            " group by identifier,encounter_datetime" & _
                            " having count(*)>=2"
        End If

        'Dim sqlQuery As String = "select concat(given_name,' ', middle_name,' ',family_name) nome," & _
        '                        " identifier nid,encounter_datetime,count(*) numero " & _
        '                        " from v_encounter where encounter_type = 18 and location_id=" & Me.cboUS.SelectedValue & "" & _
        '                        " group by identifier,encounter_datetime" & _
        '                        " having count(*)>=2 "

        rpt.SetDataSource(TabelaDinamica(sqlQuery))
        If RecourdCount = 0 Then
            MsgBox("Nao ha dados por visualizar com os parametros introduzidos")
            Cursor = Cursors.Default
            Exit Sub
        End If
        rpt.SetParameterValue(rpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
        
        forma.rptViewer.ReportSource = rpt
        forma.Text = "Pacientes com mais de uma consulta frida na mesma data"


        forma.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class