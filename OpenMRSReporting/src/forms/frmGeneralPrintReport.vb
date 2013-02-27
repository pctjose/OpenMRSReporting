Public Class frmGeneralPrintReport

    Private Sub frmGeneralPrintReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'EncherCombo(Me.cboUS, "name", "Location", "location_id")
        EncherCombo(Me.cboProvincia, "nome", "province", "ProvinciaID")
        If Me.cboProvincia.Items.Count > 0 Then
            Me.cboProvincia.SelectedValue = My.Settings.DefaultProvinceID
        End If
        encherTrimestre()
        Me.lblInfo.Text = "Preencha os campos e clique Visualizar..."
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
        If Me.cboUS.SelectedIndex < 0 Then
            MsgBox("Seleccione a Unidade Sanitaria")
            Me.cboUS.Focus()
            Exit Sub
        End If
       
    End Sub

    Private Sub rdTrimestral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTrimestral.CheckedChanged
        If rdTrimestral.Checked Then
            cboPeriodo.Enabled = True
            encherTrimestre()
        End If
    End Sub

    Private Sub rdSemestral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdSemestral.CheckedChanged
        If rdSemestral.Checked Then
            cboPeriodo.Enabled = True
            encherSemestre()
        End If
    End Sub

    Private Sub rdAnual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdAnual.CheckedChanged
        If rdAnual.Checked Then
            cboPeriodo.Enabled = False
        End If
    End Sub

    Private Sub txtAno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar)) Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub encherTrimestre()
        Me.cboPeriodo.Items.Clear()
        Me.cboPeriodo.Items.Add("Primeiro")
        Me.cboPeriodo.Items.Add("Segundo")
        Me.cboPeriodo.Items.Add("Terceiro")
        Me.cboPeriodo.Items.Add("Quarto")
        Me.cboPeriodo.SelectedIndex = 0
    End Sub
    Private Sub encherSemestre()
        Me.cboPeriodo.Items.Clear()
        Me.cboPeriodo.Items.Add("Primeiro")
        Me.cboPeriodo.Items.Add("Segundo")
        Me.cboPeriodo.SelectedIndex = 0
    End Sub

End Class