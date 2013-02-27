Public Class frmExpressObs

    Private Sub frmExpressObs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            If Me.txtConceptId.Text = Nothing Then
                MsgBox("Deve introduzir a conceito: Pesquise o conceito que pretende no sistema OpenMRS e registe o Concept ID")
                txtConceptId.Focus()
                Exit Sub
            End If

            Dim str As String = ""
            If Me.rdObservacoes.Checked Then
                str &= " select year(encounter.encounter_datetime) as Ano,date_format(encounter.encounter_datetime,'%M') as Mes,count(*) as Valor " & _
                " from openmrs.encounter, openmrs.obs, openmrs.patient" & _
                " where 	patient.patient_id=encounter.patient_id and " & _
                " encounter.encounter_id=obs.encounter_id and " & _
                " patient.voided=0 and encounter.voided=0 and obs.voided=0 and  " & _
                " encounter.encounter_datetime between '" & dataMySQL(Me.dataInicial.Value.Date) & "' and '" & dataMySQL(Me.dataFinal.Value.Date) & "' and " & _
                " obs.concept_id = " & CInt(Me.txtConceptId.Text)
                '"group by year(encounter.encounter_datetime),month(encounter.encounter_datetime);"
            Else
                str &= " select year(encounter.encounter_datetime) as Ano,date_format(encounter.encounter_datetime,'%M') as Mes,count(distinct(patient.patient_id)) as Valor " & _
               " from openmrs.encounter, openmrs.obs, openmrs.patient" & _
               " where 	patient.patient_id=encounter.patient_id and " & _
               " encounter.encounter_id=obs.encounter_id and " & _
               " patient.voided=0 and encounter.voided=0 and obs.voided=0 and  " & _
               " encounter.encounter_datetime between '" & dataMySQL(Me.dataInicial.Value.Date) & "' and '" & dataMySQL(Me.dataFinal.Value.Date) & "' and " & _
               " obs.concept_id = " & CInt(Me.txtConceptId.Text)
                '"group by year(encounter.encounter_datetime),month(encounter.encounter_datetime);"
            End If
            If Me.chkDistrital.Checked Then
                str &= " and encounter.location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                str &= " and encounter.location_id=" & Me.cboUS.SelectedValue
            End If

            str &= " group by year(encounter.encounter_datetime),month(encounter.encounter_datetime)"

            Me.dataView.DataSource = TabelaDinamica(str).Tables(0)
            'dataView.DataMember = TabelaDinamica(str).Tables(0)
        Catch ex As Exception
            MsgBox("Houve Erro: " & ex.Message)
        End Try
    End Sub
End Class