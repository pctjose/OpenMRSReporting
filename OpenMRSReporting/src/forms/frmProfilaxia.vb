Public Class frmProfilaxia

    Private Sub frmProfilaxia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Dim StrTipoProf As String = ""

            'If rdCTZ.Checked Then
            '    StrTipoProf = "((obs.concept_id=1534 and (value_numeric=1 or value_coded=916)) or (obs.concept_id=1719 and value_coded=916) or (obs.concept_id=1264 and value_coded=916))"
            'End If

            If rdCTZ.Checked Then
                StrTipoProf = "obs.concept_id=6121 and value_coded=1065 "
            End If

            'If rdINH.Checked Then
            '    StrTipoProf = "((obs.concept_id=1534 and value_coded=656) or (obs.concept_id=1719 and value_coded=656) or (obs.concept_id=1264 and value_coded=656))"
            'End If

            If rdINH.Checked Then
                StrTipoProf = "obs.concept_id=6122 and value_coded=1065 "
            End If

            'If rdAmbos.Checked Then
            '    StrTipoProf = "((obs.concept_id=1534 and value_coded in (656,916)) or (obs.concept_id=1534 and value_numeric=1) or (obs.concept_id=1719 and value_coded in (656,916)) or (obs.concept_id=1264 and value_coded in (656,916)))"
            'End If

            If rdAmbos.Checked Then
                StrTipoProf = "obs.concept_id in (6122,6121) and value_coded=1065 "
            End If

            If Me.chkEmTARV.Checked Then
                'strQuery = "Select profilaxia.NID NID,profilaxia.NOME NOME,profilaxia.DATAPROFILAXIA 'DATA PROFILAXIA',tarv.dataultimolevantamento 'ULTIMO LEVANTAMENTO' from " & _
                '        "(select patient.patient_id,patient_identifier.identifier NID, concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME, " & _
                '        " date_format(max(encounter.encounter_datetime),'%d-%m-%Y') as DATAPROFILAXIA " & _
                '        " from openmrs.person_name," & _
                '        " openmrs.patient_identifier," & _
                '        " openmrs.patient," & _
                '        " openmrs.encounter," & _
                '        " openmrs.obs " & _
                '        " where person_name.person_id=patient.patient_id and " & _
                '        " patient_identifier.patient_id=patient.patient_id and " & _
                '        " encounter.patient_id=patient.patient_id and " & _
                '        " encounter.encounter_id=obs.encounter_id and " & _
                '        " patient.voided=0 and encounter.voided=0 and " & _
                '        " obs.voided=0 and patient_identifier.preferred=1 and " & StrTipoProf & _
                '        "  and " & _
                '        " encounter.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' " & strLocal & _
                '        " group by patient.patient_id) profilaxia," & _
                '        " (select  person.person_id,gender,e.encounter_datetime dataultimolevantamento" & _
                '        " from 	openmrs.obs," & _
                '        " (	    select encounter_id,d.encounter_datetime" & _
                '        "       from 	openmrs.encounter," & _
                '        "       (	select patient.patient_id,max(encounter_datetime) as encounter_datetime" & _
                '        "           from openmrs.encounter, openmrs.patient" & _
                '        "           where 	encounter_type=18 and" & _
                '        "                   patient.patient_id=encounter.patient_id and" & _
                '        "                   encounter.voided=0 and patient.voided=0 and" & _
                '        "                   encounter_datetime <= '" & dataFim & "'" & _
                '        "           group by patient_id) d " & _
                '        "       where 	encounter.encounter_datetime=d.encounter_datetime and encounter.encounter_type=18 and" & _
                '        "               d.patient_id = encounter.patient_id And encounter.voided = 0) e,openmrs.person" & _
                '        " where obs.encounter_id=e.encounter_id and" & _
                '        " person.person_id=obs.person_id and " & _
                '        " obs.concept_id=1255 and obs.voided=0 and obs.value_coded<>1708) tarv " & _
                '        " where tarv.person_id=profilaxia.patient_id"
                strQuery = "Select profilaxia.NID NID,profilaxia.NOME NOME,profilaxia.DATAPROFILAXIA 'DATA PROFILAXIA',tarv.dataultimolevantamento 'ULTIMO LEVANTAMENTO' from " & _
                        "(select patient.patient_id,patient_identifier.identifier NID, concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME, " & _
                        " encounter.encounter_datetime as DATAPROFILAXIA " & _
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
                        " obs.voided=0 and patient_identifier.preferred=1 and " & StrTipoProf & _
                        "  and " & _
                        " encounter.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' " & strLocal & _
                        " group by patient.patient_id) profilaxia," & _
                        " (select  person.person_id,gender,e.encounter_datetime dataultimolevantamento" & _
                        " from 	openmrs.obs," & _
                        " (	    select encounter_id,d.encounter_datetime" & _
                        "       from 	openmrs.encounter," & _
                        "       (	select patient.patient_id,max(encounter_datetime) as encounter_datetime" & _
                        "           from openmrs.encounter, openmrs.patient" & _
                        "           where 	encounter_type=18 and" & _
                        "                   patient.patient_id=encounter.patient_id and" & _
                        "                   encounter.voided=0 and patient.voided=0 and" & _
                        "                   encounter_datetime <= '" & dataFim & "'" & _
                        "           group by patient_id) d " & _
                        "       where 	encounter.encounter_datetime=d.encounter_datetime and encounter.encounter_type=18 and" & _
                        "               d.patient_id = encounter.patient_id And encounter.voided = 0) e,openmrs.person" & _
                        " where obs.encounter_id=e.encounter_id and" & _
                        " person.person_id=obs.person_id and " & _
                        " obs.concept_id=1255 and obs.voided=0 and obs.value_coded<>1708) tarv " & _
                        " where tarv.person_id=profilaxia.patient_id"
            Else
                'strQuery = " select patient_identifier.identifier NID, concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME, " & _
                '        " date_format(max(encounter.encounter_datetime),'%d-%m-%Y') as 'DATA PROFILAXIA' " & _
                '        " from openmrs.person_name," & _
                '        " openmrs.patient_identifier," & _
                '        " openmrs.patient," & _
                '        " openmrs.encounter," & _
                '        " openmrs.obs " & _
                '        " where person_name.person_id=patient.patient_id and " & _
                '        " patient_identifier.patient_id=patient.patient_id and " & _
                '        " encounter.patient_id=patient.patient_id and " & _
                '        " encounter.encounter_id=obs.encounter_id and " & _
                '        " patient.voided=0 and encounter.voided=0 and " & _
                '        " obs.voided=0 and patient_identifier.preferred=1 and " & StrTipoProf & _
                '        " and " & _
                '        " encounter.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' " & strLocal & _
                '        " group by identifier"
                strQuery = " select patient_identifier.identifier NID, concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME, " & _
                        " encounter.encounter_datetime as 'DATA PROFILAXIA' " & _
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
                        " obs.voided=0 and patient_identifier.preferred=1 and " & StrTipoProf & _
                        " and " & _
                        " encounter.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' " & strLocal & _
                        " group by identifier"
            End If

            
            Me.dataView.DataSource = TabelaDinamica(strQuery).Tables(0)

            If Me.dataView.RowCount > 1 Then
                Me.lblNumero.Visible = True
                Me.lblNumero.Text = "NÚMERO TOTAL DE PACIENTES QUE RECEBERAM PROFILAXIA COM CTZ: " & Me.dataView.RowCount - 1
            Else
                Me.lblNumero.Visible = False
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve Erro ao visualizar: " & ex.Message)

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim dataInicio As String = dataMySQL(Me.dataInicial.Value.Date)
            Dim dataFim As String = dataMySQL(Me.dataFinal.Value.Date)

            Dim strQuery As String = " select idade IDADE,dataabertura DATA_ABERTURA,datatarv DATA_INICIO_TARV,dataseguimento DATA_SEGUIMENTO,dataprofilaxia DATA_PROFILAXIA,if(conceptid=6121,'PROFILAXIA CTZ',if(conceptid=6122,'PROFILAXIA INH','TRATAMENTO CTZ/INH')) TIPO_PROFILAXIA " & _
            " from " & _
            " (select encounter.patient_id,min(encounter.encounter_datetime) dataabertura," & _
            " round(datediff(curdate(),person.birthdate)/365) idade" & _
            " from 	openmrs.patient inner join openmrs.encounter on patient.patient_id=encounter.patient_id" & _
            " 	inner join openmrs.person on person.person_id=patient.patient_id" & _
            " where encounter.voided=0 and encounter.encounter_type in (5,7) and patient.voided=0" & _
            " group by encounter.patient_id) t_abertura" & _
            " inner join" & _
            " (select encounter.patient_id,min(encounter.encounter_datetime) dataseguimento" & _
            " from openmrs.encounter where encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' and " & _
            " encounter.voided=0 and encounter.encounter_type in (6,9)" & _
            " group by encounter.patient_id) t_seguimento" & _
            " on t_abertura.patient_id=t_seguimento.patient_id" & _
            " left join " & _
            " (select obs.person_id,max(obs.obs_datetime) dataprofilaxia,obs.concept_id conceptid" & _
            " from openmrs.obs" & _
            " where obs.obs_datetime between '" & dataInicio & "' and '" & dataFim & "' and " & _
            " (	(obs.concept_id in (6121,6122) and value_coded=1065) or " & _
            " 	(obs.concept_id=1719 and value_coded in (916,656)) " & _
            " ) and obs.voided=0" & _
            " group by obs.person_id) t_profilaxia" & _
            " on t_profilaxia.person_id=t_seguimento.patient_id" & _
            " left join " & _
            " (select encounter.patient_id,min(encounter.encounter_datetime) datatarv" & _
            " from openmrs.encounter" & _
            " where encounter.voided=0 and encounter.encounter_type=18" & _
            " group by encounter.patient_id) t_tarv" & _
            " on t_tarv.patient_id=t_seguimento.patient_id;"

            Me.dataView.DataSource = TabelaDinamica(strQuery).Tables(0)

            If Me.dataView.RowCount > 1 Then
                Me.lblNumero.Visible = True
                Me.lblNumero.Text = "NÚMERO TOTAL DE PACIENTES QUE TIVERAM SEGUIMENTO NO PERIODO: " & Me.dataView.RowCount - 1
            Else
                Me.lblNumero.Visible = False
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro: " & ex.Message)
        End Try

    End Sub
End Class