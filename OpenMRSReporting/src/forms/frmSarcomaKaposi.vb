Public Class frmSarcomaKaposi

    Private Sub frmSarcomaKaposi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'EncherCombo(Me.cboUS, "name", "Location", "location_id")
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If Me.cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
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

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Try

            Cursor = Cursors.WaitCursor
            Dim strQuery As String = ""
            Dim strLocal As String = ""
            Dim dataInicio As String = dataMySQL(Me.dataInicial.Value.Date)
            Dim dataFim As String = dataMySQL(Me.dataFinal.Value.Date)

            If Me.chkDistrital.Checked Then
                strLocal &= " and encounter.location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and encounter.location_id=" & Me.cboUS.SelectedValue
            End If

            strQuery = " select patient_identifier.identifier NID, concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME, " & _
                        " max(encounter.encounter_datetime) as 'DATA NOTIFICACAO' " & _
                        " from openmrs.person_name," & _
                        " openmrs.patient_identifier," & _
                        " openmrs.patient," & _
                        " openmrs.encounter," & _
                        " openmrs.obs " & _
                        " where person_name.person_id=patient.patient_id and " & _
                        " patient_identifier.patient_id=patient.patient_id and " & _
                        " encounter.patient_id=patient.patient_id and " & _
                        " encounter.encounter_id=obs.encounter_id and " & _
                        " patient.voided=0 and encounter.voided=0 and " & _
                        " obs.voided=0 and patient_identifier.preferred=1 and " & _
                        " obs.concept_id in (2066,1670,1120,1127,1569) and value_coded=507 and " & _
                        " encounter.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' " & strLocal & _
                        " group by identifier"
            Me.dataView.DataSource = TabelaDinamica(strQuery).Tables(0)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve Erro: " & ex.Message)

        End Try
    End Sub


    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.dataView.RowCount <= 1 Then
                MsgBox("Não há dados para exportar...")
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            ExportToExcel(Me.dataView, xlsOption.xlsOpen)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro: " & ex.Message)
        End Try

    End Sub
End Class