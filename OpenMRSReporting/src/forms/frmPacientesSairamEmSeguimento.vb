

Public Class frmPacientesSairamEmSeguimento

    Private Sub frmPacientesSemCD4Mais6Meses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If Me.chkDistrital.Checked Then
                strLocal &= " and encounter.location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and encounter.location_id=" & Me.cboUS.SelectedValue
            End If
            If chkEmTARV.Checked Then
                strQuery &= "select cd4.nid as NID,cd4.nome as NOME,cd4.valor as CD4,date_format(ultimocd4.datacd4,'%d-%m-%Y') as 'DATA CD4',round(ultimocd4.dias/30) Meses " & _
                " From " & _
                " ( select patient.patient_id ,max(encounter.encounter_datetime) datacd4,datediff(curdate(),max(encounter.encounter_datetime)) as dias " & _
                " from openmrs.encounter, openmrs.obs, openmrs.patient " & _
                " where 	patient.patient_id=encounter.patient_id and " & _
                " encounter.encounter_id=obs.encounter_id and " & _
                " obs.voided=0 and encounter.voided=0 and patient.voided=0 and  " & _
                " obs.concept_id = 5497 " & strLocal & _
                " group by patient.patient_id) ultimocd4," & _
                " (select patient.patient_id ,encounter.encounter_datetime,obs.value_numeric valor,patient_identifier.identifier nid, concat( person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) nome " & _
                " from openmrs.encounter, openmrs.obs, openmrs.patient, openmrs.patient_identifier, openmrs.person_name " & _
                " where 	patient.patient_id=encounter.patient_id and " & _
                " encounter.encounter_id=obs.encounter_id and " & _
                " patient_identifier.patient_id=patient.patient_id and " & _
                " person_name.person_id=patient.patient_id and " & _
                " patient_identifier.identifier_type=2 and " & _
                " obs.voided=0 and encounter.voided=0 and patient.voided=0 and  " & _
                " obs.concept_id = 5497 " & strLocal & " ) cd4," & _
                " (select  distinct obs.person_id from 	openmrs.obs," & _
                " (	select encounter_id " & _
                " from 	openmrs.encounter," & _
                " (	select patient.patient_id,max(encounter_datetime) as encounter_datetime  " & _
                "   from openmrs.encounter, openmrs.patient" & _
                " where 	encounter_type=18 and " & _
                " patient.patient_id=encounter.patient_id and " & _
                " encounter.voided = 0 And patient.voided = 0" & _
                " group by patient_id) d " & _
                " where 	encounter.encounter_datetime=d.encounter_datetime and " & _
                " d.patient_id = encounter.patient_id And encounter.voided = 0) e" & _
                " where 	obs.encounter_id=e.encounter_id and " & _
                " obs.concept_id=1255 and obs.voided=0 and" & _
                " obs.value_coded<>1708) emtarv" & _
                " where ultimocd4.patient_id=cd4.patient_id and " & _
                " ultimocd4.datacd4=cd4.encounter_datetime and " & _
                " emtarv.person_id=ultimocd4.patient_id and " & _
                " ultimocd4.dias>180 order by 5 desc"
            Else
                strQuery &= "select cd4.nid as NID,cd4.nome as NOME,cd4.valor as CD4,date_format(ultimocd4.datacd4,'%d-%m-%Y') as 'DATA CD4',round(ultimocd4.dias/30) Meses " & _
                " From " & _
                " ( select patient.patient_id ,max(encounter.encounter_datetime) datacd4,datediff(curdate(),max(encounter.encounter_datetime)) as dias " & _
                " from openmrs.encounter, openmrs.obs, openmrs.patient " & _
                " where 	patient.patient_id=encounter.patient_id and " & _
                " encounter.encounter_id=obs.encounter_id and " & _
                " obs.voided=0 and encounter.voided=0 and patient.voided=0 and  " & _
                " obs.concept_id = 5497 " & strLocal & _
                " group by patient.patient_id) ultimocd4," & _
                " (select patient.patient_id ,encounter.encounter_datetime,obs.value_numeric valor,patient_identifier.identifier nid, concat( person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) nome " & _
                " from openmrs.encounter, openmrs.obs, openmrs.patient, openmrs.patient_identifier, openmrs.person_name " & _
                " where 	patient.patient_id=encounter.patient_id and " & _
                " encounter.encounter_id=obs.encounter_id and " & _
                " patient_identifier.patient_id=patient.patient_id and " & _
                " person_name.person_id=patient.patient_id and " & _
                " patient_identifier.identifier_type=2 and " & _
                " obs.voided=0 and encounter.voided=0 and patient.voided=0 and  " & _
                " obs.concept_id = 5497 " & strLocal & ") cd4 " & _
                " where ultimocd4.patient_id=cd4.patient_id and " & _
                " ultimocd4.datacd4=cd4.encounter_datetime and " & _
                " ultimocd4.dias>180 order by 5 desc "

            End If

            Me.dataView.DataSource = TabelaDinamica(strQuery).Tables(0)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve Erro: " & ex.Message)

        End Try
    End Sub


    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.dataView.RowCount <= 0 Then
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