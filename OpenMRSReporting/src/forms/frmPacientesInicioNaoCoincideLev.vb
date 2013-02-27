

Public Class frmPacientesInicioNaoCoincideLev

    Private Sub frmPacientesSemCD4Mais6Meses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            strQuery &= " select nid as NID, " & _
                        " nome as NOME, " & _
                        " location_name as 'UNIDADE SANITARIA', " & _
                        " gender as SEXO, " & _
                        " data_inicio as 'DATA INICIO TARV', " & _
                        " primeira_frida as 'PRIMEIRO LEVANTAMENTO ARV', " & _
                        " idade_actual as 'IDADE ACTUAL', " & _
                        " if(estado_actual is null,'ACTIVO NO PROGRAMA',estado_actual) as 'ESTADO ACTUAL', " & _
                        " distrito as DISTRITO, " & _
                        " bairro as BAIRRO, " & _
                        " if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV', " & _
                        " data_livro_tarv as 'DATA REGISTO TARV' " & _
                        " from openmrsreporting.processo_tarv proc Inner Join " & _
                        "       (   SELECT p.patient_id, min(encounter_datetime) primeira_frida " & _
                        "           FROM openmrs.patient p " & _
                        "               Inner Join openmrs.encounter e ON p.patient_id = e.patient_id " & _
                        "           WHERE p.voided =  0 AND e.voided =  0 and e.encounter_type = 18 " & _
                        "           GROUP BY p.patient_id) primeiro_levantamento ON primeiro_levantamento.patient_id= proc.patient_id " & _
                        " where primeira_frida <> data_inicio and data_inicio is not null and transferido_de is null " & strLocal



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