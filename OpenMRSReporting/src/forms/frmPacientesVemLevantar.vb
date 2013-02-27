Public Class frmPacientesVemLevantar

    Private Sub frmPacientesVemLevantar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
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

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        Try
            EncherCombo(Me.cboDistrito, "nome", "district", "DistritoID", "ProvinciaID", , Me.cboProvincia.SelectedValue)
            If Me.cboDistrito.Items.Count > 0 Then
                Me.cboDistrito.SelectedValue = My.Settings.DefaultDistrictID
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Cursor = Cursors.WaitCursor
        'Dim rpt As New PacientesVemLavantarMedicamento
        If Me.cboUS.Items.Count <= 0 Then
            MsgBox("Seleccione a HDD")
            Me.cboUS.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If
        If Me.dataInicial.Value > Me.dataFinal.Value Then
            MsgBox("Inconsistencia entre a data inicial e a data final")
            Me.dataInicial.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If
        Dim strLocal As String = ""
        Dim dataS As DataSet = Nothing
        Dim strQuery As String = ""
        If rdARV.Checked Then
            If Me.chkSitio.Checked Then
                strLocal &= " and data_proximo between '" & dataMySQL(dataInicial.Value.Date) & "' and '" & dataMySQL(dataFinal.Value.Date) & "' and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and data_proximo between '" & dataMySQL(dataInicial.Value.Date) & "' and '" & dataMySQL(dataFinal.Value.Date) & "' and location_id=" & Me.cboUS.SelectedValue
            End If
            strQuery = " Select 	nid as NID," & _
                 " 		nome as NOME," & _
                 " 		location_name as 'UNIDADE SANITARIA'," & _
                 " 		birthdate as 'DATA NASCIMENTO'," & _
                 "       gender as SEXO," & _
                 " 		data_inicio as 'DATA INICIO TARV'," & _
                 " 		idade_inicio as 'IDADE INICIO TARV'," & _
                 " 		idade_actual as 'IDADE ACTUAL'," & _
                 "       ultimo_levantamento as 'DATA ULTIMO LEVANTAMENTO'," & _
                 "       data_proximo as 'PROXIMO MARCADO', " & _
                 " 		datediff(curdate(),data_proximo) as 'DIAS DE FALTA'," & _
                 " 		distrito as DISTRITO," & _
                 " 		localidade as LOCALIDADE," & _
                 " 		bairro as BAIRRO," & _
                 " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
                 " 		if(estado_actual is null,'ACTIVO NO PROGRAMA',estado_actual) as 'ESTADO ACTUAL' " & _
                 " from  processo_tarv where data_inicio is not null and (estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) " & strLocal
        ElseIf rdConsulta.Checked Then
            If Me.chkSitio.Checked Then
                strLocal &= " and proxima_visita between '" & dataMySQL(dataInicial.Value.Date) & "' and '" & dataMySQL(dataFinal.Value.Date) & "' and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and proxima_visita between '" & dataMySQL(dataInicial.Value.Date) & "' and '" & dataMySQL(dataFinal.Value.Date) & "' and location_id=" & Me.cboUS.SelectedValue
            End If
            strQuery = " Select 	nid as NID," & _
                 " 		nome as NOME," & _
                 " 		location_name as 'UNIDADE SANITARIA'," & _
                 " 		birthdate as 'DATA NASCIMENTO'," & _
                 "       gender as SEXO," & _
                 " 		data_abertura as 'DATA ABERTURA'," & _
                 "      ultima_visita_seguimento as 'ULTIMO SEGUIMENTO'," & _
                 "      proxima_visita as 'PROXIMO SEGUIMENTO', " & _
                 " 		datediff(curdate(),proxima_visita) as 'DIAS DE FALTA'," & _
                 " 		distrito as DISTRITO," & _
                 " 		localidade as LOCALIDADE," & _
                 " 		bairro as BAIRRO," & _
                 " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
                 " 		if(estado_actual is null,'ACTIVO NO PROGRAMA',estado_actual) as 'ESTADO ACTUAL', " & _
                 " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
                 " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
                 " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
                 " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
                 " from  processo_tarv where proxima_visita is not null " & strLocal
        ElseIf rdCD4.Checked Then
            If Me.chkSitio.Checked Then
                strLocal &= " and data_proximo_cd4 between '" & dataMySQL(dataInicial.Value.Date) & "' and '" & dataMySQL(dataFinal.Value.Date) & "' and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and data_proximo_cd4 between '" & dataMySQL(dataInicial.Value.Date) & "' and '" & dataMySQL(dataFinal.Value.Date) & "' and location_id=" & Me.cboUS.SelectedValue
            End If
            strQuery = " Select 	nid as NID," & _
                 " 		nome as NOME," & _
                 " 		location_name as 'UNIDADE SANITARIA'," & _
                 " 		birthdate as 'DATA NASCIMENTO'," & _
                 "       gender as SEXO," & _
                 " 		data_abertura as 'DATA ABERTURA'," & _
                 "      ultimo_cd4 as 'ULTIMO CD4'," & _
                 "      data_cd4 as 'DATA ULTIMO CD4'," & _
                 "      data_proximo_cd4 as 'PROXIMO CD4', " & _
                 " 		datediff(curdate(),data_proximo_cd4) as 'DIAS DE FALTA CD4'," & _
                 "      ultima_visita_seguimento as 'ULTIMO SEGUIMENTO'," & _
                 "      proxima_visita as 'PROXIMO SEGUIMENTO', " & _
                 " 		distrito as DISTRITO," & _
                 " 		localidade as LOCALIDADE," & _
                 " 		bairro as BAIRRO," & _
                 " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
                 " 		if(estado_actual is null,'ACTIVO NO PROGRAMA',estado_actual) as 'ESTADO ACTUAL', " & _
                 " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
                 " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
                 " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
                 " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
                 " from  processo_tarv where (data_cd4 is null or (data_cd4 is not null and data_proximo_cd4>data_cd4)) and data_proximo_cd4 is not null  " & strLocal
        End If
        dataS = TabelaDinamica(strQuery)
        Me.DataGridView1.DataSource = dataS.Tables(0)
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.DataGridView1.RowCount - 1 <= 0 Then
                MsgBox("Não há dados para exportar...")
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            ExportToExcel(Me.DataGridView1, xlsOption.xlsOpen)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro: " & ex.Message)
        End Try
    End Sub
End Class