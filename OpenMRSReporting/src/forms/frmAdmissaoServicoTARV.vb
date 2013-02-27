Public Class frmAdmissaoServicoTARV

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Try

            Cursor = Cursors.WaitCursor
            Dim strQuery As String = ""
            Dim strLocal As String = ""
            Dim dataInicio As String = dataMySQL(Me.dataInicial.Value.Date)
            Dim dataFim As String = dataMySQL(Me.dataFinal.Value.Date)

            strLocal = " where encounter.voided=0 and patient.voided=0 and person_name.voided=0 and patient_identifier.voided=0 and encounter.encounter_type in (5,7)"

            If Me.chkDistrital.Checked Then
                strLocal &= " and encounter.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' and encounter.location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and encounter.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' and encounter.location_id=" & Me.cboUS.SelectedValue
            End If

            If Me.rdF.Checked Then
                strLocal &= " and person.gender='F'"
            End If

            If Me.rdM.Checked Then
                strLocal &= " and person.gender='M'"
            End If

            If Me.rdCrianca.Checked Then
                strLocal &= " and round(datediff(encounter.encounter_datetime,person.birthdate)/365)<=14"
            End If

            If Me.rdAdulto.Checked Then
                strLocal &= " and round(datediff(encounter.encounter_datetime,person.birthdate)/365)>=15"
            End If

            strQuery = " Select 	patient_identifier.identifier as NID," & _
                        " concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME," & _
                        " location.name as 'UNIDADE SANITARIA'," & _
                        " date_format(person.birthdate,'%d-%m-%Y') as 'DATA NASCIMENTO'," & _
                        " date_format(Abertura.encounter_datetime,'%d-%m-%Y') as 'DATA ADMISSAO'," & _
                        " round(datediff(Abertura.encounter_datetime,person.birthdate)/365) as 'IDADE ADMISSAO'," & _
                        " round(datediff(curdate(),person.birthdate)/365) as 'IDADE ACTUAL'," & _
                        " if(person.dead=1,'SIM','NAO') as OBITO" & _
                        " from openmrs.patient " & _
                        " inner join openmrs.person on person.person_id=patient.patient_id " & _
                        " inner join openmrs.encounter on patient.patient_id=encounter.patient_id" & _
                        " inner join (Select patient_id,min(encounter_datetime) as encounter_datetime,min(encounter_id) encounter_id " & _
                        " from openmrs.encounter " & _
                        " where encounter_type in (5,7) and voided=0 group by patient_id" & _
                        " ) Abertura on 	Abertura.patient_id=encounter.patient_id and Abertura.encounter_id=encounter.encounter_id and " & _
                        " Abertura.encounter_datetime = encounter.encounter_datetime" & _
                        " inner join openmrs.patient_identifier on patient.patient_id=patient_identifier.patient_id and patient_identifier.identifier_type=2 " & _
                        " inner join openmrs.person_name on  patient.patient_id=openmrs.person_name.person_id " & _
                        " inner join openmrs.location on encounter.location_id=location.location_id " & strLocal
            Dim dataS As DataSet = TabelaDinamica(strQuery)
            Me.dataView.DataSource = dataS.Tables(0)
            Dim obj As Object


            Dim obitos As Integer = 0

            For Each row As DataRow In dataS.Tables(0).Rows
                obj = row.Item(7)
                If Not IsDBNull(obj) Then
                    If obj = "SIM" Then
                        obitos = obitos + 1
                    End If
                End If
            Next

            lblNumero.Text = "Número Total de Admitidos: " & dataView.RowCount - 1
            lblTarv.Text = "OBITOS: " & obitos



            lblNumero.Visible = True

            lblTarv.Visible = True

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve Erro: " & ex.Message)

        End Try
    End Sub

    Private Sub frmAdmissaoServicoTARV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    
End Class