Public Class frmCoorteTARV

    Private Sub frmCoorteTARV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim dataInicioTARV As String = dataMySQL(dataInicialTarv.Value.Date)
            Dim dataFinalTarv As String = dataMySQL(Me.dataFinalTarv.Value.Date)
            Dim dataFinalAnalise As String = dataMySQL(Me.dataFinalAnalise.Value.Date)
            ExecuteFillTempCoortTARV(dataInicioTARV, dataFinalTarv, dataFinalAnalise, cboUS.SelectedValue, cboDistrito.SelectedValue, chkDistrital.Checked)
            Dim strQuery As String = "Select nid as NID,data_nascimento as 'DATA NASCIMENTO',sexo AS SEXO,idade_actual AS 'IDADE ACTUAL', " & _
            "data_admissao AS 'DATA ADMISSAO',idade_abertura AS 'IDADE ADMISSÃO',data_inicio AS 'DATA INICIO TARV',idade_inicio_tarv AS 'IDADE INICIO TARV'," & _
            "local_abertura AS 'UNIDADE SANITÁRIA',data_gravida AS 'DATA GRAVIDA',semanas_gravida AS 'SEMANAS GRAVIDA',cd4_inicio_tarv AS 'CD4 INICIO TARV'," & _
            "data_cd4 AS 'DATA CD4',estadio_inicio_tarv AS 'ESTADIO INICIO TARV',data_estadio AS 'DATA ESTADIO',ultima_frida AS 'DATA ULTIMO LEVANTAMENTO'," & _
            "ultimo_consulta AS 'DATA ULTIMA CONSULTA',data_tb AS 'DATA TRATAMENTO TB',estado1 AS 'ESTADO 1',data_estado1 AS 'DATA ESTADO 1'," & _
            "estado2 AS 'ESTADO 2',data_estado2 AS 'DATA ESTADO 2',estado3 AS 'ESTADO 3',data_estado3 AS 'DATA ESTADO 3'," & _
            "estado4 AS 'ESTADO 4',data_estado4 AS 'DATA ESTADO 4',estado5 AS 'ESTADO 5',data_estado5 AS 'DATA ESTADO 5'," & _
            "estado6 AS 'ESTADO 6',data_estado6 AS 'DATA ESTADO 6',estado7 AS 'ESTADO 7',data_estado7 AS 'DATA ESTADO 7'," & _
            "estado8 AS 'ESTADO 8',data_estado8 AS 'DATA ESTADO 8' from temp_coorte_tarv"

            Me.dataView.DataSource = TabelaDinamica(strQuery).Tables(0)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve Erro: " & ex.Message)

        End Try
        
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.dataView.RowCount <= 1 Then
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