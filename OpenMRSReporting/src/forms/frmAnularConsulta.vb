Imports MySql.Data.MySqlClient
Public Class frmAnularConsulta

    Private Sub frmAnularConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboConsulta.SelectedIndex = 0
    End Sub

    Private Sub cmdAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnular.Click
        Try

        
            If String.IsNullOrEmpty(txtNID.Text) Then
                MsgBox("Introduza o NID do paciente na sua forma completa...")
                txtNID.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtMotivo.Text) Then
                MsgBox("Introduza o motivo pelo qual pretende anular a consulta...")
                txtMotivo.Focus()
                Exit Sub
            End If
            Dim patientID As Integer = GetPatientOpenMRSIDByNID(txtNID.Text)
            If patientID > 0 Then
                Dim strType As String = cboConsulta.Text
                Dim indexTraco As Integer = strType.IndexOf("-")
                Dim encounterTypeId As Integer = strType.Substring(0, indexTraco)
                Dim strQuery As String = "Select encounter_id from openmrs.encounter " & _
                " where patient_id=" & patientID & " and encounter_datetime='" & dataMySQL(dataConsulta.Value.Date) & "'" & _
                " and voided=0 and encounter_type=" & encounterTypeId
                Dim comando As New MySqlCommand
                ReabreConexao(ConexaoOpenMRSReporting3)
                comando.Connection = ConexaoOpenMRSReporting3
                comando.CommandType = CommandType.Text
                comando.CommandText = strQuery
                Dim encounterId As Integer = comando.ExecuteScalar
                If encounterId > 0 Then
                    comando.CommandText = "Update openmrs.encounter set voided=1, voided_by=1,date_voided=curdate(),void_reason='" & txtMotivo.Text & "' where encounter_id=" & encounterId
                    comando.ExecuteNonQuery()

                    comando.CommandText = "Update openmrs.obs set voided=1, voided_by=1,date_voided=curdate(),void_reason='" & txtMotivo.Text & "' where encounter_id=" & encounterId
                    comando.ExecuteNonQuery()
                    MsgBox("Consulta Anulada...")
                Else
                    MsgBox("Não existe o tipo de consulta na data preenchida para o paciente seleccionado...")
                End If

            Else
                MsgBox("Não existe o paciente com o NID preenchido... Note que o NID deve ser na sua forma completa.")

            End If
        Catch ex As Exception
            MsgBox("Houve Erro:" & ex.Message)
        End Try
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()

    End Sub
End Class