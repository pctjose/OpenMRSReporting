Public Class frmMovimentoFRIDA

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Try
            Cursor = Cursors.WaitCursor
            DAOVALIDATOR.FillFRIDATRACK()

            Dim strQuery As String = " SELECT`openmrs`.`patient_identifier`.`identifier` NID," & _
                                    " concat(`openmrs`.`person_name`.`given_name`,' ',`openmrs`.`person_name`.`middle_name`,' ',`openmrs`.`person_name`.`family_name`) NOME," & _
                                    " `openmrsreporting`.`frida_track`.`encounter_datetime` 'DATA CONSULTA' ," & _
                                    " `openmrsreporting`.`frida_track`.`desc_error` 'DESCRIÇÃO ERRO'" & _
                                    " FROM `openmrsreporting`.`frida_track` " & _
                                    " inner join `openmrs`.`patient_identifier`  ON `openmrs`.`patient_identifier`.`patient_id` = `openmrsreporting`.`frida_track`.`patient_id`" & _
                                    " inner join `openmrs`.`person_name` on  `openmrsreporting`.`frida_track`.`patient_id` = `openmrs`.`person_name`.`person_id`" & _
                                    " where patient_identifier.identifier_type = 2"

            Me.DataGridView1.DataSource = TabelaDinamica(strQuery).Tables(0)

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro: " & ex.Message)

        End Try

    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        'Try
        If Me.DataGridView1.RowCount <= 1 Then
            MsgBox("Não há dados para exportar...")
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        ExportToExcel(Me.DataGridView1, xlsOption.xlsOpen)
        Cursor = Cursors.Default
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        '    MsgBox("Houve erro: " & ex.Message)
        'End Try
    End Sub
End Class