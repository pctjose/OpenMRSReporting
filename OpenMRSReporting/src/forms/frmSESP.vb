Public Class frmSESP
    Dim strSexo As String = ""
    Dim strIdade As String = ""
    Dim strQueryTarv As String = ""
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

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        Try
            EncherCombo(Me.cboDistrito, "nome", "district", "DistritoID", "ProvinciaID", , Me.cboProvincia.SelectedValue)
            If cboDistrito.Items.Count > 0 Then
                cboDistrito.SelectedValue = My.Settings.DefaultDistrictID
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmSESP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
        ExecuteFillProcessoTARVTable("2010-06-30", 0)
    End Sub

    Private Sub rdF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdF.CheckedChanged
        If rdF.Checked Then
            strSexo = " and processo_tarv.gender='F'"
        End If
    End Sub

    Private Sub rdM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdM.CheckedChanged
        If rdM.Checked Then
            strSexo = " and processo_tarv.gender='M'"
        End If
    End Sub

    Private Sub rdSexoTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdSexoTodos.CheckedChanged
        If rdSexoTodos.Checked Then
            strSexo = ""
        End If
    End Sub

    Private Sub rdCrianca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCrianca.CheckedChanged
        If Me.rdCrianca.Checked Then
            strIdade = " and processo_tarv.idade_actual between 0 and 14"
        End If
    End Sub

    Private Sub rdAdulto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdAdulto.CheckedChanged
        If Me.rdAdulto.Checked Then
            strIdade = " and processo_tarv.idade_actual >= 15"
        End If
    End Sub

    Private Sub rdFaixaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdFaixaTodos.CheckedChanged
        If rdFaixaTodos.Checked Then
            strIdade = ""
        End If
    End Sub

    Private Sub cmdVisualizarTARV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizarTARV.Click
        If rdInicioTARV.Checked Then
            strQueryTarv = "Select nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA',data_inicio as 'DATA INICIO TARV' " & _
            "from processo_tarv where data_inicio is not null and data_inicio<='" & dataMySQL(dataFinal.Value.Date) & "' and forma_inicio='INICIO'" & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and location_id=" & cboUS.SelectedValue & ""
            End If
        End If

        If rdReinicio.Checked Then
            strQueryTarv = "Select distinct nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA',data_inicio as 'DATA INICIO TARV' " & _
            " from processo_tarv inner join openmrs.encounter e on e.patient_id=processo_tarv.patient_id " & _
            " inner join openmrs.obs o on o.encounter_id=e.encounter_id" & _
            " where data_inicio is not null and e.encounter_datetime<='" & dataMySQL(dataFinal.Value.Date) & "' and e.voided=0" & _
            " and e.encounter_type=18 and o.voided=0 and o.concept_id=1255 and o.value_coded=1705" & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and processo_tarv.location_id=" & cboUS.SelectedValue & ""
            End If
        End If

        If rdTransferidosDe.Checked Then
            strQueryTarv = "Select nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA',data_inicio as 'DATA INICIO TARV' " & _
                        "from processo_tarv where data_inicio is not null and data_inicio<='" & dataMySQL(dataFinal.Value.Date) & "' and forma_inicio='TRANSFERIDO DE'" & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and location_id=" & cboUS.SelectedValue & ""
            End If
        End If

        If rdFaltoso.Checked Then
            strQueryTarv = " Select distinct nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA'," & _
                            " data_inicio as 'DATA INICIO TARV',ultimo_levantamento,o.value_datetime as data_proxima,datediff('" & dataMySQL(dataFinal.Value.Date) & "',o.value_datetime) as Dias" & _
                            " from processo_tarv inner join openmrs.encounter e on e.patient_id=processo_tarv.patient_id " & _
                            " inner join openmrs.obs o on o.encounter_id=e.encounter_id" & _
                            " where data_inicio is not null and e.encounter_datetime<='" & dataMySQL(dataFinal.Value.Date) & "' and e.voided=0" & _
                            " and e.encounter_type=18 and o.voided=0 and o.concept_id=5096 and datediff('" & dataMySQL(dataFinal.Value.Date) & "',o.value_datetime) between 5 and 59" & _
                            " and e.encounter_datetime=processo_tarv.ultimo_levantamento and (estado_actual is null or data_estado>'" & dataMySQL(dataFinal.Value.Date) & "')" & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and processo_tarv.location_id=" & cboUS.SelectedValue & ""
            End If
        End If

        If rdAbandono.Checked Then
            strQueryTarv = " Select distinct nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA'," & _
                            " data_inicio as 'DATA INICIO TARV',ultimo_levantamento,o.value_datetime as data_proxima,datediff('" & dataMySQL(dataFinal.Value.Date) & "',o.value_datetime) as Dias" & _
                            " from processo_tarv inner join openmrs.encounter e on e.patient_id=processo_tarv.patient_id " & _
                            " inner join openmrs.obs o on o.encounter_id=e.encounter_id" & _
                            " where data_inicio is not null and e.encounter_datetime<='" & dataMySQL(dataFinal.Value.Date) & "' and e.voided=0" & _
                            " and e.encounter_type=18 and o.voided=0 and o.concept_id=5096 and datediff('" & dataMySQL(dataFinal.Value.Date) & "',o.value_datetime)>=60" & _
                            " and e.encounter_datetime=processo_tarv.ultimo_levantamento and (estado_actual is null or data_estado>'" & dataMySQL(dataFinal.Value.Date) & "')" & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and processo_tarv.location_id=" & cboUS.SelectedValue & ""
            End If
        End If
        If rdTarv.Checked Then
            strQueryTarv = "Select nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA',data_inicio as 'DATA INICIO TARV',ultimo_levantamento as 'ULTIMO LEVANTAMENTO' " & _
            "from processo_tarv where data_inicio is not null and data_inicio<='" & dataMySQL(dataFinal.Value.Date) & "' and estado_actual is null" & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and location_id=" & cboUS.SelectedValue & ""
            End If
        End If

        Dim dataS As DataSet = TabelaDinamica(strQueryTarv)
        Me.dataView.DataSource = dataS.Tables(0)
        lblNumero.Text = "Número Total: " & dataView.RowCount - 1
        lblNumero.Visible = True
    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.dataView.RowCount - 1 <= 0 Then
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

    Private Sub cmdVisualizarSaida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizarSaida.Click
        If rdTodasSaidas.Checked Then
            strQueryTarv = "Select nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA',data_inicio as 'DATA INICIO TARV',estado_actual 'ESTADO ACTUAL',data_estado as 'DATA ESTADO' " & _
            "from processo_tarv where data_inicio is not null and data_inicio<='" & dataMySQL(dataFinal.Value.Date) & "' and estado_actual is not null " & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and location_id=" & cboUS.SelectedValue & ""
            End If
        End If
        If rdAbandonoNotificado.Checked Then
            strQueryTarv = "Select nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA',data_inicio as 'DATA INICIO TARV',estado_actual 'ESTADO ACTUAL',data_estado as 'DATA ESTADO' " & _
            "from processo_tarv where data_inicio is not null and data_inicio<='" & dataMySQL(dataFinal.Value.Date) & "' and estado_actual is not null and estado_concept_id=1707 " & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and location_id=" & cboUS.SelectedValue & ""
            End If
        End If
        If rdTransferidosPara.Checked Then
            strQueryTarv = "Select nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA',data_inicio as 'DATA INICIO TARV',estado_actual 'ESTADO ACTUAL',data_estado as 'DATA ESTADO' " & _
            "from processo_tarv where data_inicio is not null and data_inicio<='" & dataMySQL(dataFinal.Value.Date) & "' and estado_actual is not null and estado_concept_id=1706 " & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and location_id=" & cboUS.SelectedValue & ""
            End If
        End If
        If rdObitos.Checked Then
            strQueryTarv = "Select nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA',data_inicio as 'DATA INICIO TARV',estado_actual 'ESTADO ACTUAL',data_estado as 'DATA ESTADO' " & _
            "from processo_tarv where data_inicio is not null and data_inicio<='" & dataMySQL(dataFinal.Value.Date) & "' and estado_actual is not null and estado_concept_id=1366 " & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and location_id=" & cboUS.SelectedValue & ""
            End If
        End If
        If rdSuspensos.Checked Then
            strQueryTarv = "Select nid as NID,nome as NOME,gender as SEXO,idade_actual as IDADE,data_abertura as 'DATA ABERTURA',data_inicio as 'DATA INICIO TARV',estado_actual 'ESTADO ACTUAL',data_estado as 'DATA ESTADO' " & _
            "from processo_tarv where data_inicio is not null and data_inicio<='" & dataMySQL(dataFinal.Value.Date) & "' and estado_actual is not null and estado_concept_id=1709 " & strSexo & strIdade
            If Not chkDistrital.Checked Then
                strQueryTarv &= " and location_id=" & cboUS.SelectedValue & ""
            End If
        End If

        Dim dataS As DataSet = TabelaDinamica(strQueryTarv)
        Me.dataView.DataSource = dataS.Tables(0)
        lblNumero.Text = "Número Total: " & dataView.RowCount - 1
        lblNumero.Visible = True
    End Sub
End Class