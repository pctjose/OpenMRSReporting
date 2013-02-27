Public Class frmTransferencia

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Dim strQuery As String = ""
        Dim nid As String = ""

        Cursor = Cursors.WaitCursor
        Dim patientID As Integer = 0
        If Not (Me.txtNID.Text = Nothing) Then
            nid = Me.txtNIDInicio.Text & "/" & Me.txtNID.Text
            patientID = GetPatientOpenMRSIDByNID(nid)
            If patientID = 0 Or patientID = Nothing Then
                Cursor = Cursors.Default
                MsgBox("Nao existe paciente com o NID introduzido")
                Me.txtNID.Text = ""
                Exit Sub
            End If
        Else
            MsgBox("Introduza o NID do paciente que pretende transferir...")
            Me.txtNID.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If

        strQuery = " select encounter.encounter_datetime," & _
                    " encounter_type.name as consulta," & _
                    " encounter.encounter_type, " & _
                    " observation.Question_Name Observacao, " & _
                    " cn_answer.name as 'Valor_Conceito'," & _
                    " observation.value_datetime as 'Valor_Data', " & _
                    " observation.value_numeric as 'Valor_Numerico'," & _
                    " observation.value_text as 'Valor_Texto'" & _
                    " from " & _
                    " (	select	obs.*, " & _
                    " cn_question.name as Question_Name " & _
                    " from openmrs.obs left join openmrs.concept_name cn_question on obs.concept_id=cn_question.concept_id where cn_question.locale='pt' and obs.voided=0 and cn_question.voided=0 and cn_question.concept_name_type='FULLY_SPECIFIED' and obs.person_id=" & patientID & "" & _
                    " ) observation" & _
                    " left outer join openmrs.concept_name cn_answer on observation.value_coded=cn_answer.concept_id " & _
                    " left outer join openmrs.encounter on observation.encounter_id=encounter.encounter_id " & _
                    " left outer join openmrs.encounter_type on encounter_type.encounter_type_id=encounter.encounter_type" & _
                    " where cn_answer.locale='pt' or cn_answer.locale is null and encounter.voided <> 1 and encounter.patient_id=" & patientID & " order by 1 desc"
        'TabelaDinamica(strQuery)


        Dim rpt As New rptTransferencia
        Dim forma As New frmPrintReports
        rpt.SetDataSource(TabelaDinamica(strQuery))
        If RecourdCount = 0 Then
            MsgBox("Nao ha dados por visualizar com os parametros introduzidos")
            Cursor = Cursors.Default
            Exit Sub
        End If
        rpt.SetParameterValue(rpt.Parameter_HDD.ParameterFieldName, My.Settings.DefaultUSName)
        rpt.SetParameterValue(rpt.Parameter_NID.ParameterFieldName, nid)
        rpt.SetParameterValue(rpt.Parameter_Nome.ParameterFieldName, GetPatientNameByID(patientID))
        forma.rptViewer.ReportSource = rpt
        forma.Text = "Observacoes"
        forma.Show()
        Cursor = Cursors.Default

    End Sub

    Private Sub frmTransferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtNIDInicio.Text = My.Settings.DefaultHddNID
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class