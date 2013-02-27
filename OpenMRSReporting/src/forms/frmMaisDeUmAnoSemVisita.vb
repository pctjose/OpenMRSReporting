Public Class frmMaisDeUmAnoSemVisita

    Private Sub frmMaisDeUmAnoSemVisita_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                strLocal &= " and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and location_id=" & Me.cboUS.SelectedValue
            End If

            strQuery = " Select 	nid as NID," & _
              " 		nome as NOME," & _
              " 		location_name as 'UNIDADE SANITARIA'," & _
              " 		birthdate as 'DATA NASCIMENTO'," & _
              "       gender as SEXO," & _
              "       data_abertura as 'DATA ABERTURA'," & _
              " 		data_inicio as 'DATA INICIO TARV'," & _
              " 		idade_actual as 'IDADE ACTUAL'," & _
              "       ultima_visita as 'DATA ULTIMO VISITA'," & _
              " round(datediff(curdate(),ultima_visita)/30) as 'MESES SEM VISITA', " & _
              " 		distrito as DISTRITO," & _
              " 		localidade as LOCALIDADE," & _
              " 		bairro as BAIRRO," & _
              " 		ponto_referencia as 'PONTO DE REFERENCIA'" & _
              " from  processo_tarv where dead=0 and estado_actual is null and round(datediff(curdate(),ultima_visita)/30)>=12" & strLocal


            'strQuery = " select patient_identifier.identifier NID,concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) NOME, " & _
            '            " max(encounter.encounter_datetime) 'DATA ULTIMA VISITA', " & _
            '            " round(datediff(curdate(),max(encounter.encounter_datetime))/30) as 'MESES SEM VISITA' " & _
            '            " from openmrs.person_name," & _
            '            " openmrs.patient_identifier," & _
            '            " openmrs.patient," & _
            '            " openmrs.encounter " & _
            '            " where person_name.person_id=patient.patient_id and " & _
            '            " patient_identifier.patient_id=patient.patient_id and " & _
            '            " encounter.patient_id=patient.patient_id and " & _
            '            " patient.voided = 0 And encounter.voided = 0 And identifier_type = 2 " & strLocal & _
            '            " group by identifier " & _
            '            " having round(datediff(curdate(),max(encounter.encounter_datetime))/30)>=12 order by 4 desc"
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