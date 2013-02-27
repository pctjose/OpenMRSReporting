Public Class frmAbandonoFaltoso

    Private Sub frmAbandonoFaltoso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
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

        Dim dataInicio As String = dataMySQL(Me.dataInicial.Value.Date)
        Dim dataFim As String = dataMySQL(Me.dataFinal.Value.Date)

        Dim strIdade As String = ""
        Dim strSexo As String = ""
        Dim strSaida As String = ""
        Dim strLocal As String = ""

        If Me.rdCrianca.Checked Then
            strIdade = " and idade_actual<=14"
        End If
        If Me.rdAdulto.Checked Then
            strIdade = " and idade_actual>=15"
        End If

        If rdF.Checked Then
            strSexo = " and gender='F'"
        End If
        If rdM.Checked Then
            strSexo = " and gender='M'"
        End If

        If rdAbandonoNotificado.Checked Then
            strSaida = " and estado_concept_id=1707"
        End If
        If rdTransferidosPara.Checked Then
            strSaida = " and estado_concept_id=1706"
        End If
        If rdObitos.Checked Then
            strSaida = " and estado_concept_id=1366"
        End If
        If rdSuspensos.Checked Then
            strSaida = " and estado_concept_id=1709"
        End If

        If Me.chkDistrital.Checked Then
            strLocal &= " and data_estado between '" & dataInicio & "' and '" & dataFim & "' and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
        Else
            strLocal &= " and data_estado between '" & dataInicio & "' and '" & dataFim & "' and location_id=" & Me.cboUS.SelectedValue
        End If

        Dim strQuery As String = " Select 	nid as NID," & _
              " 		nome as NOME," & _
              " 		location_name as 'UNIDADE SANITARIA'," & _
              " 		birthdate as 'DATA NASCIMENTO'," & _
              "       gender as SEXO," & _
              " 		data_inicio as 'DATA INICIO TARV'," & _
              " 		idade_inicio as 'IDADE INICIO TARV'," & _
              " 		idade_actual as 'IDADE ACTUAL'," & _
              "       ultimo_levantamento as 'DATA ULTIMO LEVANTAMENTO'," & _
              "       data_proximo as 'PROXIMO MARCADO', " & _
              " 		estado_actual as 'ESTADO ACTUAL'," & _
              " 		data_estado as 'DATA ESTADO'," & _
              " 		distrito as DISTRITO," & _
              " 		localidade as LOCALIDADE," & _
              " 		bairro as BAIRRO," & _
              " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
              "      data_busca as 'ULTIMA BUSCA'," & _
              " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
              " from  processo_tarv where data_inicio is not null and estado_actual is not null" & strIdade & strSexo & strLocal & strSaida
        Dim dataS As DataSet = TabelaDinamica(strQuery)
        Me.dataView.DataSource = dataS.Tables(0)
        lblNumero.Text = "Número Total: " & dataView.RowCount - 1
        lblNumero.Visible = True
    End Sub

    Private Sub cmdVisualizarTARV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizarTARV.Click

        Dim dataInicio As String = dataMySQL(Me.dataInicial.Value.Date)
        Dim dataFim As String = dataMySQL(Me.dataFinal.Value.Date)


        Dim strIdade As String = ""
        Dim strSexo As String = ""

        Dim strLocal As String = ""

        Dim strQuery As String = ""

        
        If rdF.Checked Then
            'strSexo = " and person.gender='F'"
            strSexo = " and gender='F'"
        End If
        If rdM.Checked Then
            'strSexo = " and person.gender='M'"
            strSexo = " and gender='M'"
        End If
        

        

        If rdInicioTARV.Checked Then

            If Me.chkDistrital.Checked Then
                strLocal &= " and data_inicio between '" & dataInicio & "' and '" & dataFim & "' and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and data_inicio between '" & dataInicio & "' and '" & dataFim & "' and location_id=" & Me.cboUS.SelectedValue
            End If

            If Me.rdCrianca.Checked Then
                strIdade = " and idade_actual<=14"
            End If
            If Me.rdAdulto.Checked Then
                strIdade = " and idade_actual>=15"
            End If

            strQuery = " Select 	nid as NID," & _
            " 		nome as NOME," & _
            " 		location_name as 'UNIDADE SANITARIA'," & _
            " 		birthdate as 'DATA NASCIMENTO'," & _
            "       gender as SEXO," & _
            " 		data_inicio as 'DATA INICIO TARV'," & _
            " 		idade_inicio as 'IDADE INICIO TARV'," & _
            " 		idade_actual as 'IDADE ACTUAL'," & _
            " 		if(estado_actual is null,'ACTIVO NO PROGRAMA',estado_actual) as 'ESTADO ACTUAL'," & _
            " 		distrito as DISTRITO," & _
            " 		localidade as LOCALIDADE," & _
            " 		bairro as BAIRRO," & _
            " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
             " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from 	openmrsreporting.processo_tarv  " & _
            " where 	data_inicio is not null "

            strQuery &= strSexo & strIdade & strLocal
        End If
        If rdTarv.Checked Then
            
            If Me.chkDistrital.Checked Then
                strLocal &= " and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and location_id=" & Me.cboUS.SelectedValue
            End If

            If Me.rdCrianca.Checked Then
                strIdade = " and idade_actual<=14"
            End If
            If Me.rdAdulto.Checked Then
                strIdade = " and idade_actual>=15"
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
            " 		distrito as DISTRITO," & _
            " 		localidade as LOCALIDADE," & _
            " 		bairro as BAIRRO," & _
            " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
            " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from 	openmrsreporting.processo_tarv  " & _
            " where 	data_inicio is not null and " & _
            " 		(estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) "
            strQuery &= strSexo & strIdade & strLocal
        End If

        If rdAbandono.Checked Or rdFaltoso.Checked Then

            If Me.chkDistrital.Checked Then
                strLocal &= " and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and location_id=" & Me.cboUS.SelectedValue
            End If

            If Me.rdCrianca.Checked Then
                strIdade = " and idade_actual<=14"
            End If
            If Me.rdAdulto.Checked Then
                strIdade = " and idade_actual>=15"
            End If

            Dim abandonoFaltoso As String = ""

            If Me.rdFaltoso.Checked Then
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
             "      data_busca as 'ULTIMA BUSCA'," & _
             " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
             " from  processo_tarv where data_inicio is not null and (estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) " & strIdade & strSexo & strLocal
                abandonoFaltoso = " and datediff(curdate(),data_proximo) between 5 and 60"
            Else
                strQuery = " Select 	nid as NID," & _
             " 		nome as NOME," & _
             " 		location_name as 'UNIDADE SANITARIA'," & _
             "       gender as SEXO," & _
             " 		birthdate as 'DATA NASCIMENTO'," & _
             " 		data_inicio as 'DATA INICIO TARV'," & _
             " 		idade_inicio as 'IDADE INICIO TARV'," & _
             " 		idade_actual as 'IDADE ACTUAL'," & _
             "       ultimo_levantamento as 'DATA ULTIMO LEVANTAMENTO'," & _
             "       data_proximo as 'PROXIMO MARCADO', " & _
             " 		datediff(curdate(),data_proximo) as 'DIAS DE FALTA'," & _
             "      date_add(data_proximo,interval 61 day) as 'DATA PARA MARCAR ABANDONO'," & _
             " 		distrito as DISTRITO," & _
             " 		localidade as LOCALIDADE," & _
             " 		bairro as BAIRRO," & _
             " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
             "      data_busca as 'ULTIMA BUSCA'," & _
              " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
             " from  processo_tarv where data_inicio is not null and (estado_actual is null or (estado_actual is not null and estado_concept_id=6269)) " & strIdade & strSexo & strLocal
                abandonoFaltoso = " and datediff(curdate(),data_proximo) > 60"
            End If

            strQuery &= abandonoFaltoso

        End If
        If rdReinicio.Checked Then

            If Me.chkDistrital.Checked Then
                strLocal &= " and p.data_reinicio between '" & dataInicio & "' and '" & dataFim & "' and p.location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and p.data_reinicio between '" & dataInicio & "' and '" & dataFim & "' and p.location_id=" & Me.cboUS.SelectedValue
            End If

            If Me.rdCrianca.Checked Then
                strIdade = " and idade_actual<=14"
            End If
            If Me.rdAdulto.Checked Then
                strIdade = " and idade_actual>=15"
            End If

            strQuery = " Select 	nid as NID," & _
            " 		nome as NOME," & _
            " 		location_name as 'UNIDADE SANITARIA'," & _
            " 		birthdate as 'DATA NASCIMENTO'," & _
            "       gender as SEXO," & _
            " 		data_inicio as 'DATA INICIO TARV'," & _
            " 		idade_inicio as 'IDADE INICIO TARV'," & _
            " 		idade_actual as 'IDADE ACTUAL'," & _
            "       p.data_reinicio as 'DATA REINICIO'," & _
            " 		if(estado_actual is null,'ACTIVO NO PROGRAMA',estado_actual) as 'ESTADO ACTUAL'," & _
            " 		distrito as DISTRITO," & _
            " 		localidade as LOCALIDADE," & _
            " 		bairro as BAIRRO," & _
            " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
             " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from 	openmrsreporting.processo_tarv p " & _
            " where p.data_inicio is not null and p.data_reinicio is not null "
            strQuery &= strSexo & strIdade & strLocal
        End If
        If rdTransferidosDe.Checked Then
            If Me.chkDistrital.Checked Then
                strLocal &= " and p.data_transferido_de between '" & dataInicio & "' and '" & dataFim & "' and p.location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
            Else
                strLocal &= " and p.data_transferido_de between '" & dataInicio & "' and '" & dataFim & "' and p.location_id=" & Me.cboUS.SelectedValue
            End If

            If Me.rdCrianca.Checked Then
                strIdade = " and idade_actual<=14"
            End If
            If Me.rdAdulto.Checked Then
                strIdade = " and idade_actual>=15"
            End If

            strQuery = " Select 	nid as NID," & _
            " 		nome as NOME," & _
            " 		location_name as 'UNIDADE SANITARIA'," & _
            " 		birthdate as 'DATA NASCIMENTO'," & _
            "       gender as SEXO," & _
            " 		data_inicio as 'DATA INICIO TARV'," & _
            " 		idade_inicio as 'IDADE INICIO TARV'," & _
            " 		idade_actual as 'IDADE ACTUAL'," & _
            "       p.data_transferido_de as 'DATA TRANSFERIDO DE'," & _
            " 		if(estado_actual is null,'ACTIVO',estado_actual) as 'ESTADO ACTUAL'," & _
            " 		distrito as DISTRITO," & _
            " 		localidade as LOCALIDADE," & _
            " 		bairro as BAIRRO," & _
            " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
             " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
            " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
            " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
            " 		data_livro_tarv as 'DATA REGISTO TARV' " & _
            " from 	openmrsreporting.processo_tarv p " & _
            " where p.transferido_de is not null and p.data_inicio is not null "
            strQuery &= strSexo & strIdade & strLocal
        End If


        Dim dataS As DataSet = TabelaDinamica(strQuery)
        Me.dataView.DataSource = dataS.Tables(0)
        lblNumero.Text = "Número Total: " & dataView.RowCount - 1
        lblNumero.Visible = True

    End Sub

End Class