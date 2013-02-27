Public Class frmInicioTARVsemFILAouDatasDiferentes

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




    Private Sub cmdVisualizarnaocoincide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizarnaocoincide.Click

        Dim dataInicio As String = dataMySQL(Me.dataInicial.Value.Date)
        Dim dataFim As String = dataMySQL(Me.dataFinal.Value.Date)

        Dim strIdade As String = ""
        Dim strSexo As String = ""
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

       

        If Me.chkDistrital.Checked Then
            strLocal &= " and data_estado between '" & dataInicio & "' and '" & dataFim & "' and location_id in (select openmrs_id from openmrsreporting.hdd where openmrs_id is not null and distritoID='" & Me.cboDistrito.SelectedValue & "') "
        Else
            strLocal &= " and data_estado between '" & dataInicio & "' and '" & dataFim & "' and location_id=" & Me.cboUS.SelectedValue
        End If

        Dim strQuery As String = "select nid as 'NID'," & _
         "nome as 'NOME'," & _
         "location_name as 'UNIDADE SANITARIA'," & _
         "data_inicio as 'DATA INICIO TARV'," & _
         "dia 'INICIO LEV'," & _
         "birthdate as 'DATA NASCIMENTO'," & _
         "gender as 'SEXO'," & _
         "idade_inicio as 'IDADE INICIO TARV'," & _
         "idade_actual as 'IDADE ACTUAL'," & _
         "if(estado_actual is null,'ACTIVO NO PROGRAMA',estado_actual) as 'ESTADO ACTUAL'," & _
         "		distrito as DISTRITO," & _
         " 		localidade as LOCALIDADE," & _
         " 		bairro as BAIRRO," & _
         " 		ponto_referencia as 'PONTO DE REFERENCIA'," & _
         " 		if(livro_pretarv=6259,'LIVRO 1',if(livro_pretarv=6260,'LIVRO 2','')) as 'LIVRO PRE-TARV'," & _
         " 		data_livro_pretarv as 'DATA REGISTO PRE-TARV'," & _
         " 		if(livro_tarv=6261,'LIVRO 1',if(livro_tarv=6262,'LIVRO 2','')) as 'LIVRO TARV'," & _
         " 		data_livro_tarv as 'DATA REGISTO TARV'" & _
         "   from openmrsreporting.processo_tarv proc Inner Join " & _
         "       (SELECT p.identifier, min(encounter_datetime) dia" & _
         "           FROM openmrs.patient_identifier p" & _
         "                    Inner Join openmrs.encounter e ON p.patient_id = e.patient_id" & _
         "                    Inner Join openmrs.obs ON openmrs.obs.encounter_id= e.encounter_id and p.voided =  0 " & _
         "AND e.voided =  0 and openmrs.obs.voided=0 and e.encounter_type = 18" & _
         "                   group by identifier) fila ON fila.identifier= proc.nid" & _
         "           where dia <> data_inicio" & strIdade & strSexo & strLocal
        Dim dataS As DataSet = TabelaDinamica(strQuery)
        Me.dataView.DataSource = dataS.Tables(0)
        lblNumero.Text = "Número Total: " & dataView.RowCount - 1
        lblNumero.Visible = True
    End Sub

    Private Sub cmdVisualizarTARVsemFILA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizarTARV.Click

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
            " where 	data_inicio is not null " & _
            "           and nid not in (select distinct identifier" & _
            "                           from openmrs.patient_identifier o inner join openmrs.encounter e on o.patient_id = e.patient_id " & _
            "                            where o.voided=0 and e.voided=0 and encounter_type = 18) "

            strQuery &= strSexo & strIdade & strLocal
        End If


        Dim dataS As DataSet = TabelaDinamica(strQuery)
        Me.dataView.DataSource = dataS.Tables(0)
        lblNumero.Text = "Número Total: " & dataView.RowCount - 1
        lblNumero.Visible = True

    End Sub

End Class