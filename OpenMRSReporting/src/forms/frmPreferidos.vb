Public Class frmPreferidos
    Friend opcao As String
    Private Sub frmPreferidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opcao = "NID" Then
            GroupBox1.Text = "Pacientes com mais de um Identificador (NID) preferido"
            GroupBox2.Text = "Pacientes sem Identificador (NID) Preferido"
        End If
        If opcao = "NOME" Then
            GroupBox1.Text = "Pacientes com mais de um Nome preferido"
            GroupBox2.Text = "Pacientes sem Nome Preferido"
        End If
        If opcao = "ENDERECO" Then
            GroupBox1.Text = "Pacientes com mais de um Endereço preferido"
            GroupBox2.Text = "Pacientes sem Endereço Preferido"
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Try
            Cursor = Cursors.WaitCursor
        
            Dim strQueryMais As String = ""
            Dim strQuerySem As String = ""
            If opcao = "NID" Then
                strQueryMais = " select 	patient_identifier.identifier as IDENTIFICADOR," & _
                " 		patient_identifier_type.name as TIPO," & _
                " 		concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME" & _
                " from 	openmrs.patient" & _
                " 		inner join openmrs.patient_identifier on patient.patient_id=patient_identifier.patient_id" & _
                " 		inner join openmrs.patient_identifier_type on patient_identifier_type.patient_identifier_type_id=patient_identifier.identifier_type" & _
                " 		inner join openmrs.person_name on person_name.person_id=patient.patient_id" & _
                " where 	patient_identifier.patient_id in(" & _
                " 			select patient_identifier.patient_id " & _
                " 			from openmrs.patient" & _
                " 				inner join openmrs.patient_identifier on patient.patient_id=patient_identifier.patient_id" & _
                " 			where patient_identifier.preferred=1 and patient_identifier.voided=0 and patient.voided=0" & _
                " 			group by patient.patient_id" & _
                " 			having count(*)>=2) and " & _
                " 		patient.voided=0 and patient_identifier.voided=0"


                strQuerySem = " select 	patient_identifier.identifier as IDENTIFICADOR," & _
                " 		patient_identifier_type.name as TIPO," & _
                " 		concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME" & _
                " from 	openmrs.patient" & _
                " 		inner join openmrs.patient_identifier on patient.patient_id=patient_identifier.patient_id" & _
                " 		inner join openmrs.patient_identifier_type on patient_identifier_type.patient_identifier_type_id=patient_identifier.identifier_type" & _
                " 		inner join openmrs.person_name on person_name.person_id=patient.patient_id" & _
                " where 	patient_identifier.patient_id not in(" & _
                " 			select patient_identifier.patient_id " & _
                " 			from openmrs.patient" & _
                " 				inner join openmrs.patient_identifier on patient.patient_id=patient_identifier.patient_id" & _
                " 			where patient_identifier.preferred=1 and patient_identifier.voided=0 and patient.voided=0) and " & _
                " 		patient.voided=0 and patient_identifier.voided=0"
            End If
            If opcao = "ENDERECO" Then
                strQueryMais = " select 	patient_identifier.identifier as IDENTIFICADOR," & _
                " 		concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME," & _
                " 		person_address.county_district as DISTRITO," & _
                " 		person_address.region as LOCALIDADE," & _
                "  		person_address.subregion as BAIRRO," & _
                " 		address1 as REFERENCIA " & _
                " from 	openmrs.patient" & _
                " 		inner join openmrs.person_address on patient.patient_id=person_address.person_id" & _
                " 		inner join openmrs.patient_identifier on patient_identifier.patient_id=patient.patient_id" & _
                " 		inner join openmrs.person_name on person_name.person_id=patient.patient_id" & _
                " where 	person_address.person_id in(" & _
                " 			select person_id " & _
                " 			from openmrs.patient" & _
                " 				inner join openmrs.person_address on patient.patient_id=person_address.person_id" & _
                " 			where person_address.preferred=1 and person_address.voided=0 and patient.voided=0" & _
                " 			group by person_id" & _
                " 			having count(*)>=2) and " & _
                " 		patient.voided=0 and person_address.voided=0 and person_name.voided=0 and patient_identifier.voided=0"


                strQuerySem = " select 	patient_identifier.identifier as IDENTIFICADOR," & _
                " 		concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME," & _
                " 		person_address.county_district as DISTRITO," & _
                " 		person_address.region as LOCALIDADE," & _
                " 		person_address.subregion as BAIRRO," & _
                " 		address1 as REFERENCIA " & _
                " from 	openmrs.patient" & _
                " 		inner join openmrs.person_address on patient.patient_id=person_address.person_id" & _
                " 		inner join openmrs.patient_identifier on patient_identifier.patient_id=patient.patient_id" & _
                " 		inner join openmrs.person_name on person_name.person_id=patient.patient_id" & _
                " where 	person_address.person_id not in(" & _
                " 			select person_id " & _
                " 			from openmrs.patient" & _
                " 				inner join openmrs.person_address on patient.patient_id=person_address.person_id" & _
                " 			where person_address.preferred=1 and person_address.voided=0 and patient.voided=0) and " & _
                " 		patient.voided=0 and person_address.voided=0 and person_name.voided=0 and patient_identifier.voided=0"
            End If
            If opcao = "NOME" Then
                strQueryMais = " select 	patient_identifier.identifier as IDENTIFICADOR," & _
                " 		concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME" & _
                " from 	openmrs.patient" & _
                " 		inner join openmrs.person_name on patient.patient_id=person_name.person_id" & _
                "  		inner join openmrs.patient_identifier on patient.patient_id=patient_identifier.patient_id" & _
                " where 	person_name.person_id in(" & _
                " 			select person_id " & _
                " 			from openmrs.patient" & _
                " 				inner join openmrs.person_name on patient.patient_id=person_name.person_id" & _
                " 			where person_name.preferred=1 and person_name.voided=0 and patient.voided=0" & _
                " 			group by person_id" & _
                " 			having count(*)>=2) and " & _
                " 		patient.voided=0 and person_name.voided=0 and patient_identifier.voided=0"


                strQuerySem = " select 	patient_identifier.identifier as IDENTIFICADOR," & _
                " 		concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) as NOME" & _
                " from 	openmrs.patient" & _
                " 		inner join openmrs.person_name on patient.patient_id=person_name.person_id" & _
                " 		inner join openmrs.patient_identifier on patient.patient_id=patient_identifier.patient_id" & _
                " where 	person_name.person_id not in (" & _
                "  			select person_id " & _
                " 			from openmrs.patient" & _
                " 				inner join openmrs.person_name on patient.patient_id=person_name.person_id" & _
                " 			where person_name.preferred=1 and person_name.voided=0 and patient.voided=0) and " & _
                " 		patient.voided=0 and person_name.voided=0 and patient_identifier.voided=0"
            End If
            Dim dsm As DataSet = TabelaDinamica(strQueryMais)
            Dim dss As DataSet = TabelaDinamica(strQuerySem)
            Me.dataMaisUm.DataSource = dsm.Tables(0)
            Me.dataSem.DataSource = dss.Tables(0)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houver Erro: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdMais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMais.Click
        Try
            If Me.dataMaisUm.RowCount <= 1 Then
                MsgBox("Não há dados para exportar...")
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            ExportToExcel(Me.dataMaisUm, xlsOption.xlsOpen)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdSen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSen.Click
        Try
            If Me.dataSem.RowCount <= 1 Then
                MsgBox("Não há dados para exportar...")
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            ExportToExcel(Me.dataSem, xlsOption.xlsOpen)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro: " & ex.Message)
        End Try
    End Sub
End Class