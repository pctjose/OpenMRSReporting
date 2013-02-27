Public Class frmCohoortPeriodico

    Private Sub frmCohoortPeriodico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
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

    Private Sub cmdVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizar.Click
        Try
            If Me.dataInicial.Value.Date > dataFinal.Value.Date Then
                MsgBox("Inconsistencia das datas...")
                dataInicial.Focus()
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            DAOVALIDATOR.FillCOHOOTPERIODICO(dataInicial.Value.Date, dataFinal.Value.Date, cboDistrito.SelectedValue)

            Dim strQuery As String = " SELECT descricao as INDICADOR,us as 'U. SANITÁRIA',valor as VALOR from openmrsreporting.cohoort_periodico"

            Me.DataGridView1.DataSource = TabelaDinamica(strQuery).Tables(0)

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Houve erro: " & ex.Message)

        End Try
    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.DataGridView1.RowCount <= 1 Then
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

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class