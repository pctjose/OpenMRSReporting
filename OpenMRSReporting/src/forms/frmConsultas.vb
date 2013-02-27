Public Class frmConsultas

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Cursor = Cursors.WaitCursor
        Dim strQuery As String = ""
        Dim strLocal As String = ""
        Dim dataInicio As String = dataMySQL(Me.dataInicial.Value.Date)
        Dim dataFim As String = dataMySQL(Me.dataFinal.Value.Date)

        strLocal = " where encounter.voided=0"

        If Me.chkDistrital.Checked Then
            strLocal &= " and encounter.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' and encounter.location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
        Else
            strLocal &= " and encounter.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' and encounter.location_id=" & Me.cboUS.SelectedValue
        End If

        If Me.rdSeguimento.Checked Then
            strLocal &= " and encounter.encounter_type in (6,9)"
        End If

        If Me.rdRastreio.Checked Then
            strLocal &= " and encounter.encounter_type=20"
        End If

        If Me.rdAconselhamento.Checked Then
            strLocal &= " and encounter.encounter_type in (19,24)"
        End If

        strQuery = " Select paciente.identifier as NID,patient_name as NOME,encounter.encounter_datetime as 'DATA CONSULTA'," & _
        " 		encounter_type.name as 'TIPO CONSULTA', location.name as 'LOCAL CONSULTA'" & _
        " from 	(Select		distinct	encounter.patient_id,min(encounter_datetime) data_abertura," & _
        " 					location.location_id,location.name local_abertura,birthdate,gender,dead,death_date,	" & _
        " 					concat(given_name,' ',middle_name,' ',family_name) as patient_name,	identifier" & _
        " 		from 		openmrs.encounter " & _
        " 					inner join openmrs.patient on encounter.patient_id=patient.patient_id" & _
        " 					inner join openmrs.person on person.person_id=patient.patient_id" & _
        " 					inner join openmrs.location on encounter.location_id=location.location_id" & _
        " 					inner join openmrs.person_name on patient.patient_id=person_name.person_id" & _
        " 					inner join openmrs.patient_identifier on patient.patient_id=patient_identifier.patient_id" & _
        " 		where 		patient.voided=0 and encounter_type in (5,7) and encounter.voided=0 and person.voided=0 and " & _
        " 					person_name.voided=0 and patient_identifier.identifier_type=2 and patient_identifier.voided=0" & _
        " 		group by patient_id" & _
        " 		) paciente" & _
        " 		inner join openmrs.encounter on encounter.patient_id=paciente.patient_id" & _
        " 		inner join openmrs.encounter_type on encounter_type.encounter_type_id=encounter.encounter_type" & _
        " 		inner join openmrs.location on location.location_id=encounter.location_id " & strLocal
        Dim dataS As DataSet = TabelaDinamica(strQuery)
        Me.dataView.DataSource = dataS.Tables(0)
        lblTotalConsultas.Text = "TOTAL DE CONSULTAS: " & dataView.RowCount - 1
        Cursor = Cursors.Default
    End Sub

    Private Sub frmConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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