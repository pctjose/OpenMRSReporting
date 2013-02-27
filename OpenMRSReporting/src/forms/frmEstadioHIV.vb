Public Class frmEstadioHIV

    
    Private Sub rdCrianca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCrianca.CheckedChanged
        If rdCrianca.Checked Then
            chkEstadioIV.Checked = False
            chkEstadioIV.Enabled = False
        Else
            chkEstadioIV.Enabled = True
        End If
    End Sub

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Try

        
            Cursor = Cursors.WaitCursor
            If Me.cboUS.SelectedIndex < 0 Then
                MsgBox("Seleccione o servico TARV")
                Me.cboUS.Focus()
                Cursor = Cursors.Default
                Exit Sub
            End If
            If Me.dataInicial.Value.Date > Me.dataFinal.Value.Date Then
                MsgBox("Ha inconsistencia entre a data inicial e a data final")
                Me.dataInicial.Focus()
                Cursor = Cursors.Default
                Exit Sub
            End If
            Dim strQuery As String = "Select concat(person_name.given_name,' ',person_name.middle_name,' ',person_name.family_name) name," & _
            "patient_identifier.identifier nid,encounter.encounter_datetime,obs.concept_id,obs.value_coded " & _
            " from openmrs.patient_identifier,openmrs.person,openmrs.patient,openmrs.person_name,openmrs.encounter,openmrs.obs " & _
            " where patient_identifier.patient_id=patient.patient_id and " & _
            " person.person_id=patient.patient_id and " & _
            " person.person_id=person_name.person_id and " & _
            " patient.patient_id=encounter.patient_id and " & _
            " encounter.encounter_id=obs.encounter_id and " & _
            " patient_identifier.identifier_type=2 and " & _
            " patient_identifier.voided=0 and person_name.voided=0 and patient.voided=0 and " & _
            " person.voided=0 and encounter.voided=0 and obs.voided=0 and encounter.location_id=" & Me.cboUS.SelectedValue & " and " & _
            " encounter.encounter_datetime between '" & dataMySQL(Me.dataInicial.Value.Date) & "' and '" & dataMySQL(Me.dataFinal.Value.Date) & "' "

            Dim strConceptID As String = ""
            Dim strValueCoded As String = ""
            If rdAdulto.Checked Then
                strConceptID = "openmrs.obs.concept_id=5356 "


                If chkEstadioI.Checked Then
                    strValueCoded &= ",1204"
                End If
                If chkEstadioII.Checked Then
                    strValueCoded &= ",1205"
                End If
                If chkEstadioIII.Checked Then
                    strValueCoded &= ",1206"
                End If
                If chkEstadioIV.Checked Then
                    strValueCoded &= ",1207"
                End If


            End If
            If rdCrianca.Checked Then
                strConceptID = "openmrs.obs.concept_id=1559 "
                If chkEstadioI.Checked Then
                    strValueCoded &= ",1558"
                End If
                If chkEstadioII.Checked Then
                    strValueCoded &= ",1561"
                End If
                If chkEstadioIII.Checked Then
                    strValueCoded &= ",1562"
                End If
                If chkEstadioIV.Checked Then
                    strValueCoded &= ",2066"
                End If
            End If
            If rdAmbos.Checked Then
                strConceptID = "openmrs.obs.concept_id in (5356,1559) "

                If chkEstadioI.Checked Then
                    strValueCoded &= ",1204,1558"
                End If
                If chkEstadioII.Checked Then
                    strValueCoded &= ",1205,1561"
                End If
                If chkEstadioIII.Checked Then
                    strValueCoded &= ",1206,1562"
                End If
                If chkEstadioIV.Checked Then
                    strValueCoded &= ",1207,2066"
                End If
            End If

            strQuery &= " and " & strConceptID
            If Not strValueCoded = "" Then
                strValueCoded = strValueCoded.Remove(0, 1)
                strValueCoded = "(" & strValueCoded & ")"
                strQuery &= " and openmrs.obs.value_coded in " & strValueCoded
            End If
            Dim rpt As New EstadioHIV
            Dim forma As New frmPrintReports
            rpt.SetDataSource(TabelaDinamica(strQuery))
            If RecourdCount = 0 Then
                MsgBox("Nao ha dados por visualizar com os parametros introduzidos")
                Cursor = Cursors.Default
                Exit Sub
            End If
            rpt.SetParameterValue(rpt.Parameter_hdd.ParameterFieldName, Me.cboUS.Text)
            If Me.rdDetalhado.Checked Then
                rpt.SetParameterValue(rpt.Parameter_Tipo.ParameterFieldName, 0)
                rpt.SetParameterValue(rpt.Parameter_Titulo.ParameterFieldName, "HISTORICO DE ESTADIO HIV DE PACIENTES")
            Else
                rpt.SetParameterValue(rpt.Parameter_Tipo.ParameterFieldName, 1)
                rpt.SetParameterValue(rpt.Parameter_Titulo.ParameterFieldName, "ULTIMO ESTADIO HIV DE CADA PACIENTE")
            End If
            forma.rptViewer.ReportSource = rpt
            forma.Text = "Estadio de HIV de Pacientes "


            forma.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro. O Erro é: " & ex.Message & Chr(13) & "Tente de novo, se o problema permanecer reporte o erro.")

        End Try

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

    Private Sub frmEstadioHIV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
            If Me.cboProvincia.Items.Count > 0 Then
                Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
            End If
        Catch ex As Exception
            MsgBox("Error in Load: " & ex.Message)
        End Try
        
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    
End Class