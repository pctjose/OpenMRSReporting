Public Class frmBuscaActiva

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmBuscaActiva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If

        'Me.Size = New Size(472, 338)
        'Me.cboIdade.SelectedIndex = 0
        'Me.cboSexo.SelectedIndex = 0
        Cursor = Cursors.Default
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

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Dim strLocal As String = ""
        Dim strQuery As String = ""

        If chkDistrital.Checked Then
            strLocal = " and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
        Else
            strLocal = " and location_id=" & Me.cboUS.SelectedValue
        End If

        If cboUS.SelectedIndex < 0 Then
            MsgBox("Seleccione a unidade sanitaria")
            cboUS.Focus()
            Exit Sub
        End If

        If rdFaltoso.Checked Then
            strQuery = "Select nid as NID,nome as 'NOME COMPLETO',gender as SEXO,idade_actual as IDADE,localidade as LOCALIDADE,bairro as BAIRRO,ponto_referencia as 'PONTO DE REFERENCIA',ultimo_levantamento as 'ULTIMO LEVANTAMENTO'," & _
                    "data_proximo as 'DATA MARCADA',datediff(curdate(),data_proximo) as 'DIAS FALTA',data_consentimento as 'DATA ASS. CONSENTIMENTO',data_busca as 'ULTIMA BUSCA/VISITA', " & _
            " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from openmrsreporting.processo_tarv " & _
                    " where dead=0 and data_inicio is not null and (estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) and datediff(curdate(),data_proximo) between 7 and 59" & strLocal

        End If

        If rdNaoVoltouCD4.Checked Then
            strQuery = "Select nid as NID,nome as 'NOME COMPLETO',gender as SEXO,idade_actual as IDADE,localidade as LOCALIDADE,bairro as BAIRRO,ponto_referencia as 'PONTO DE REFERENCIA'," & _
                    "data_abertura as 'DATA ABERTURA',ultima_visita_seguimento as 'ULTIMA VISITA SEGUIMENTO',proxima_visita as 'PROXIMA VISITA',data_cd4 as 'DATA CD4',ultimo_cd4 as 'ULTIMO CD4',data_consentimento as 'DATA ASS. CONSENTIMENTO',data_busca as 'ULTIMA BUSCA/VISITA', " & _
            " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from openmrsreporting.processo_tarv " & _
                    " where data_inicio is null and ultimo_cd4 is not null and (estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) and ((ultima_visita_seguimento<data_cd4 and proxima_visita is null) or (curdate()>proxima_visita and proxima_visita is not null)) and dead=0" & strLocal

        End If

        If rdCD4Menor350.Checked Then
            strQuery = "Select nid as NID,nome as 'NOME COMPLETO',gender as SEXO,idade_actual as IDADE,localidade as LOCALIDADE,bairro as BAIRRO,ponto_referencia as 'PONTO DE REFERENCIA'," & _
                    "data_abertura as 'DATA ABERTURA',ultima_visita_seguimento as 'ULTIMA VISITA SEGUIMENTO',proxima_visita as 'PROXIMA VISITA',data_cd4 as 'DATA CD4',ultimo_cd4 as 'ULTIMO CD4',data_consentimento as 'DATA ASS. CONSENTIMENTO',data_busca as 'ULTIMA BUSCA/VISITA', " & _
            " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from openmrsreporting.processo_tarv " & _
                    " where data_inicio is null and ultimo_cd4 is not null and (estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) and ultimo_cd4<=350 and dead=0" & strLocal

        End If

        If rdNaoVoltou.Checked Then
            Dim dataInicio As String = dataMySQL(Me.dataInicial.Value.Date)
            Dim dataFim As String = dataMySQL(Me.dataFinal.Value.Date)
            strQuery = "Select nid as NID,nome as 'NOME COMPLETO',gender as SEXO,idade_actual as IDADE,localidade as LOCALIDADE,bairro as BAIRRO,ponto_referencia as 'PONTO DE REFERENCIA'," & _
                    "data_abertura as 'DATA ABERTURA',ultima_visita_seguimento as 'ULTIMA VISITA SEGUIMENTO',proxima_visita as 'PROXIMA VISITA',data_consentimento as 'DATA ASS. CONSENTIMENTO',data_busca as 'ULTIMA BUSCA/VISITA', " & _
            " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from openmrsreporting.processo_tarv " & _
                    " where data_inicio is null and (estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) and ((ultima_visita_seguimento is null) or (ultima_visita_seguimento=data_abertura)) and dead=0" & strLocal
            strQuery &= " and data_abertura between '" & dataInicio & "' and '" & dataFim & "'"
        End If

        If rdNaoColheuCD4.Checked Then

            strQuery = "Select nid as NID,nome as 'NOME COMPLETO',gender as SEXO,idade_actual as IDADE,localidade as LOCALIDADE,bairro as BAIRRO,ponto_referencia as 'PONTO DE REFERENCIA'," & _
                    "data_abertura as 'DATA ABERTURA',ultima_visita_seguimento as 'ULTIMA VISITA SEGUIMENTO',proxima_visita as 'PROXIMA VISITA',data_consentimento as 'DATA ASS. CONSENTIMENTO',data_busca as 'ULTIMA BUSCA/VISITA', " & _
            " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from openmrsreporting.processo_tarv " & _
                    " where data_inicio is null and (estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) and ultima_visita_seguimento is not null and ultimo_cd4 is null and ultima_visita_seguimento>data_abertura and dead=0" & strLocal
        End If

        If rdCCR.Checked Then
            strQuery = "Select nid as NID,nome as 'NOME COMPLETO',gender as SEXO,idade_actual as IDADE,localidade as LOCALIDADE,bairro as BAIRRO,ponto_referencia as 'PONTO DE REFERENCIA'," & _
                   "data_abertura as 'DATA ABERTURA',ultima_visita_seguimento as 'ULTIMA VISITA SEGUIMENTO',proxima_visita as 'PROXIMA VISITA',data_consentimento as 'DATA ASS. CONSENTIMENTO',data_busca as 'ULTIMA BUSCA/VISITA', " & _
            " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from openmrsreporting.processo_tarv " & _
                   " where data_inicio is null and (estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) and proveniencia_concept_id=1872 and idade_abertura<=14 and dead=0" & strLocal

        End If

        Dim dataS As DataSet = TabelaDinamica(strQuery)
        Me.Lista.DataSource = dataS.Tables(0)


        'TabelaDinamica(strQueryFaltoso)
        
    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.Lista.RowCount - 1 <= 0 Then
                MsgBox("Não há dados para exportar...")
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            ExportToExcel(Me.Lista, xlsOption.xlsOpen)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro: " & ex.Message)
        End Try
    End Sub
End Class