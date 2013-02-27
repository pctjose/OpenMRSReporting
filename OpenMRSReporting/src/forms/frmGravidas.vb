﻿Public Class frmGravidas

    Private Sub frmGravidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Try

            Cursor = Cursors.WaitCursor
            Dim strQuery As String = ""
            Dim strLocal As String = ""
            Dim dataInicio As String = dataMySQL(Me.dataInicial.Value.Date)
            Dim dataFim As String = dataMySQL(Me.dataFinal.Value.Date)

            If Me.chkDistrital.Checked Then
                strLocal &= " where g.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' and p.location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " where g.encounter_datetime between '" & dataInicio & "' and '" & dataFim & "' and p.location_id=" & Me.cboUS.SelectedValue
            End If

            If gBusca.Visible Then
                If rdSemCD4.Checked Then
                    strLocal &= " and p.data_cd4 is null"
                End If
                If rdElegivel.Checked Then
                    strLocal &= " and p.data_cd4 is not null and p.ultimo_cd4<=250 and p.data_inicio is null"
                End If
            End If
            If chkActual.Checked Then
                strLocal &= " and g.data_prevista>curdate()"
            End If

            strQuery = " Select nid NID,nome NOME,data_abertura 'DATA ABERTURA',encounter_datetime 'DATA REGISTO GRAVIDA'," & _
                        " semana_mes 'SEMANAS',data_prevista 'DATA PREVISTA',data_inicio 'DATA INICIO TARV',ultima_visita 'ULTIMA VISITA'," & _
                        " ultimo_cd4 'ULTIMO CD4',data_cd4 'DATA CD4'" & _
                       " from openmrsreporting.gravidas_inscritas_track g inner join openmrsreporting.processo_tarv p on g.patient_id=p.patient_id " & strLocal
                       
            Dim dataS As DataSet = TabelaDinamica(strQuery)
            Me.dataView.DataSource = dataS.Tables(0)
            
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve Erro: " & ex.Message)

        End Try
    End Sub
End Class