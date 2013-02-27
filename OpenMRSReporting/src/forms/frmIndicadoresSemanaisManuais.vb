Imports MySql.Data.MySqlClient
Public Class frmIndicadoresSemanaisManuais
    Friend reportPrint As ReportPrintVO
    Private Sub frmIndicadoresSemanaisManuais_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            EncherCombo1(cboUS, "Nomeus", "hdd", "openmrs_id", " openmrs_id is not null and distritoID=" & My.Settings.DefaultDistrictID)
            EncherCombo1(cboServico, "group_name", "indicator_group", "group_id", " group_id is not null and group_id<=13")
            If Me.cboUS.Items.Count > 0 Then
                Me.cboUS.SelectedValue = My.Settings.DefaultHddID
                cboUS_SelectedIndexChanged(sender, e)
            End If
            If Me.cboServico.Items.Count > 0 Then
                Me.cboServico.SelectedValue = 1
            End If
        Catch ex As Exception
            MsgBox("Erro ao Carregar Unidades Sanitarias: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
        'validarDados(dgIndicadoresManuais)
    End Sub

    Private Function validarDados(ByVal dg As DataGridView) As Int16
        For Each dgItem As DataGridViewRow In dg.Rows
            If Not IsDBNull(dgItem.Cells(2).Value) Then
                If Not String.IsNullOrEmpty(dgItem.Cells(2).Value) Then
                    If Not IsNumeric(dgItem.Cells(2).Value) Then
                        Return dgItem.Index
                    End If
                End If
            End If
            
        Next
        Return 0
    End Function

    
    Private Sub cmdSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalvar.Click
        Try
            Dim strQuery As String
            Dim cmm As New MySqlCommand
            Dim index As Int16 = validarDados(dgIndicadoresManuais)
            If index <> 0 Then
                MsgBox("Preecha correctamente o valor...")
                Me.dgIndicadoresManuais.Rows(index).Selected = True
                Exit Sub
            End If
            For Each dgItem As DataGridViewRow In dgIndicadoresManuais.Rows
                If Not IsDBNull(dgItem.Cells(2).Value) Then
                    If Not String.IsNullOrEmpty(dgItem.Cells(2).Value) Then
                        If dgItem.Cells(3).Value Then
                            strQuery = "update reportdata set result=" & dgItem.Cells(2).Value & " " & _
                        " where indicator_id=" & dgItem.Cells(0).Value & " and report_id=" & reportPrint.ReportsID & " and Location=" & Me.cboUS.SelectedValue & ""
                        Else
                            strQuery = "insert into reportdata(indicator_id,report_id,result,StartDate,EndDate,RunBy,RunOn,Location) " & _
                        " Values(" & dgItem.Cells(0).Value & "," & reportPrint.ReportsID & "," & dgItem.Cells(2).Value & "," & _
                        " '" & dataMySQL(reportPrint.ReportDateRangeStart) & "','" & dataMySQL(reportPrint.ReportDateRangeEnd) & "'," & _
                        " " & reportPrint.CreatedBy.UserID & ",now()," & cboUS.SelectedValue & ")"
                        End If
                        With cmm
                            .Connection = ConexaoOpenMRSReporting1
                            .CommandText = strQuery
                            .CommandType = CommandType.Text
                            .ExecuteNonQuery()
                        End With

                    End If
                End If

            Next
            MsgBox("Indicadores de " & Me.cboUS.Text & " registados")
            'Me.Close()
        Catch ex As Exception
            MsgBox("Houve Erro ao Registar Indicadores:" & ex.Message)
        End Try
    End Sub

    Private Sub cboUS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUS.SelectedIndexChanged
        filterIndicator()
    End Sub

    Private Sub filterIndicator()
        Try
            Dim indicatorID As Int16
            Dim indicatorName As String
            Dim indicatorValor As String
            Dim edit As Boolean
            Dim rs As MySqlDataReader
            Dim cmm As New MySqlCommand
            'EncherCombo1(cboUS, "Nomeus", "hdd", "openmrs_id", " openmrs_id is not null and distritoID=" & My.Settings.DefaultDistrictID)
            Dim sqlQuery As String = ""
            If Me.chkTodos.Checked Then
                sqlQuery = "select indicator.indicators_id," & _
                                    " indicator.indicator_name," & _
                                    " reportdata.result " & _
                                    " from indicator " & _
                                    " inner join report_indicator on indicator.indicators_id=report_indicator.indicator_id " & _
                                    " inner join report on report.id=report_indicator.report_id " & _
                                    " inner join report_print on report.id=report_print.Report_print_report " & _
                                    " left join (Select indicator_id,result,reportdata.Location as Location from reportdata,report_print " & _
                                            " where reportdata.report_id=report_print.reports_id and report_print.Reports_ID=" & reportPrint.ReportsID & " and reportdata.Location=" & Me.cboUS.SelectedValue & ")" & _
                                            " reportdata on reportdata.indicator_id=indicator.indicators_id " & _
                                    " where 	indicator.automatic=0 and  report_print.Reports_ID=" & reportPrint.ReportsID & " order by indicator.group_id"
            Else
                sqlQuery = "select indicator.indicators_id," & _
                                    " indicator.indicator_name," & _
                                    " reportdata.result " & _
                                    " from indicator " & _
                                    " inner join report_indicator on indicator.indicators_id=report_indicator.indicator_id " & _
                                    " inner join report on report.id=report_indicator.report_id " & _
                                    " inner join report_print on report.id=report_print.Report_print_report " & _
                                    " left join (Select indicator_id,result,reportdata.Location as Location from reportdata,report_print " & _
                                            " where reportdata.report_id=report_print.reports_id and report_print.Reports_ID=" & reportPrint.ReportsID & " and reportdata.Location=" & Me.cboUS.SelectedValue & ")" & _
                                            " reportdata on reportdata.indicator_id=indicator.indicators_id " & _
                                    " where 	indicator.automatic=0 and indicator.group_id=" & Me.cboServico.SelectedValue & " and report_print.Reports_ID=" & reportPrint.ReportsID & " "


            End If
            
            ReabreConexao(ConexaoOpenMRSReporting1)
            dsManualIndicator.Tables(0).Clear()
            With cmm
                .Connection = ConexaoOpenMRSReporting1
                .CommandType = CommandType.Text
                .CommandText = sqlQuery
                rs = .ExecuteReader
                If rs.HasRows Then
                    While rs.Read
                        Dim nova_linha As DataRow = dsManualIndicator.Tables(0).NewRow()
                        indicatorID = rs.GetInt16(0)
                        indicatorName = rs.GetString(1)
                        'indicatorValor = VerificaRI(rs, 2)
                        If rs.IsDBNull(2) Then
                            indicatorValor = ""
                            edit = False
                        Else
                            indicatorValor = rs.GetInt32(2)
                            edit = True
                        End If

                        nova_linha.ItemArray = New Object() {indicatorID, indicatorName, indicatorValor, edit}
                        Try
                            dsManualIndicator.Tables(0).Rows.Add(nova_linha)
                        Catch ex As Exception
                            MsgBox("Erro ao visualizar Indicador: " & ex.Message)
                        End Try
                    End While
                End If
            End With
            FechaResultSet(rs)
        Catch ex As Exception
            'MsgBox("General Error: " & ex.Message)
        End Try
    End Sub

    Private Sub cboServico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServico.SelectedIndexChanged
        filterIndicator()
    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        filterIndicator()
    End Sub
End Class