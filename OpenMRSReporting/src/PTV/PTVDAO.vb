Imports MySql.Data.MySqlClient
Public Class PTVDAO
    Public Shared Function PTVPreNatal(ByVal reportID As Integer, ByVal location As Int16) As DataSet
        Dim ds As New DataSet("ptvprenatal")
        Dim tabela As New DataTable("ptvprenatal")
        Dim cmmD As New MySqlCommand
        Dim rs As MySqlDataReader

        Dim linha As DataRow

        Dim coluna As DataColumn = New DataColumn

        Dim nome As String = ""
        For i = 172 To 190
            nome = "indicador" & i
            coluna.AllowDBNull = False
            coluna.ColumnName = nome
            coluna.Caption = nome
            coluna.DefaultValue = 0
            coluna.DataType = System.Type.GetType("System.Int64")
            tabela.Columns.Add(coluna)
            coluna = New DataColumn
        Next
        coluna.AllowDBNull = False
        coluna.ColumnName = "indicador208"
        coluna.Caption = "indicador208"
        coluna.DefaultValue = 0
        coluna.DataType = System.Type.GetType("System.Int64")
        tabela.Columns.Add(coluna)

        linha = tabela.NewRow

        With cmmD
            .CommandType = CommandType.Text
            .Connection = ConexaoOpenMRSReporting3
            .CommandText = "Select indicator_id,result from reportdata where report_id=" & reportID & " and location=" & location & " "
            rs = .ExecuteReader
            If rs.HasRows Then
                While rs.Read
                    nome = "indicador" & rs.GetInt64("indicator_id")
                    linha(nome) = rs.GetInt64("result")
                End While
            End If
            rs.Close()
        End With
        tabela.Rows.Add(linha)
        ds.Tables.Add(tabela)
        Return ds
    End Function

    Public Shared Function PTVMaternidade(ByVal reportID As Integer, ByVal location As Int16) As DataSet
        Dim ds As New DataSet("ptvmaternidade")
        Dim tabela As New DataTable("ptvmaternidade")
        Dim cmmD As New MySqlCommand
        Dim rs As MySqlDataReader

        Dim linha As DataRow

        Dim coluna As DataColumn = New DataColumn

        Dim nome As String = ""
        For i = 156 To 171
            nome = "indicador" & i
            coluna.AllowDBNull = False
            coluna.ColumnName = nome
            coluna.Caption = nome
            coluna.DefaultValue = 0
            coluna.DataType = System.Type.GetType("System.Int64")
            tabela.Columns.Add(coluna)
            coluna = New DataColumn
        Next
        For i = 209 To 214
            nome = "indicador" & i
            coluna.AllowDBNull = False
            coluna.ColumnName = nome
            coluna.Caption = nome
            coluna.DefaultValue = 0
            coluna.DataType = System.Type.GetType("System.Int64")
            tabela.Columns.Add(coluna)
            coluna = New DataColumn
        Next
        
        linha = tabela.NewRow

        With cmmD
            .CommandType = CommandType.Text
            .Connection = ConexaoOpenMRSReporting3
            .CommandText = "Select indicator_id,result from reportdata where report_id=" & reportID & " and location=" & location & " "
            rs = .ExecuteReader
            If rs.HasRows Then
                While rs.Read
                    nome = "indicador" & rs.GetInt64("indicator_id")
                    linha(nome) = rs.GetInt64("result")
                End While
            End If
            rs.Close()
        End With
        tabela.Rows.Add(linha)
        ds.Tables.Add(tabela)
        Return ds
    End Function
    Public Shared Function PTVCCR(ByVal reportID As Integer, ByVal location As Int16) As DataSet
        Dim ds As New DataSet("ptvccr")
        Dim tabela As New DataTable("ptvccr")
        Dim cmmD As New MySqlCommand
        Dim rs As MySqlDataReader

        Dim linha As DataRow

        Dim coluna As DataColumn = New DataColumn

        Dim nome As String = ""
        For i = 191 To 202
            nome = "indicador" & i
            coluna.AllowDBNull = False
            coluna.ColumnName = nome
            coluna.Caption = nome
            coluna.DefaultValue = 0
            coluna.DataType = System.Type.GetType("System.Int64")
            tabela.Columns.Add(coluna)
            coluna = New DataColumn
        Next
        coluna.AllowDBNull = False
        coluna.ColumnName = "indicador183"
        coluna.Caption = "indicador183"
        coluna.DefaultValue = 0
        coluna.DataType = System.Type.GetType("System.Int64")
        tabela.Columns.Add(coluna)

        coluna = New DataColumn
        coluna.AllowDBNull = False
        coluna.ColumnName = "indicador184"
        coluna.Caption = "indicador184"
        coluna.DefaultValue = 0
        coluna.DataType = System.Type.GetType("System.Int64")
        tabela.Columns.Add(coluna)

        coluna = New DataColumn
        coluna.AllowDBNull = False
        coluna.ColumnName = "indicador162"
        coluna.Caption = "indicador162"
        coluna.DefaultValue = 0
        coluna.DataType = System.Type.GetType("System.Int64")
        tabela.Columns.Add(coluna)

        coluna = New DataColumn
        coluna.AllowDBNull = False
        coluna.ColumnName = "indicador169"
        coluna.Caption = "indicador169"
        coluna.DefaultValue = 0
        coluna.DataType = System.Type.GetType("System.Int64")
        tabela.Columns.Add(coluna)

        coluna = New DataColumn
        coluna.AllowDBNull = False
        coluna.ColumnName = "indicador165"
        coluna.Caption = "indicador165"
        coluna.DefaultValue = 0
        coluna.DataType = System.Type.GetType("System.Int64")
        tabela.Columns.Add(coluna)

        coluna = New DataColumn
        coluna.AllowDBNull = False
        coluna.ColumnName = "indicador166"
        coluna.Caption = "indicador166"
        coluna.DefaultValue = 0
        coluna.DataType = System.Type.GetType("System.Int64")
        tabela.Columns.Add(coluna)

        linha = tabela.NewRow

        With cmmD
            .CommandType = CommandType.Text
            .Connection = ConexaoOpenMRSReporting3
            .CommandText = "Select indicator_id,result from reportdata where report_id=" & reportID & " and location=" & location & " "
            rs = .ExecuteReader
            If rs.HasRows Then
                While rs.Read
                    nome = "indicador" & rs.GetInt64("indicator_id")
                    linha(nome) = rs.GetInt64("result")
                End While
            End If
            rs.Close()
        End With
        tabela.Rows.Add(linha)
        ds.Tables.Add(tabela)
        Return ds
    End Function


    Public Shared Sub CalcularPTVPreNatal(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL ptv_prenatal('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularPTVMaternidade(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL ptv_maternidade('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
    Public Shared Sub CalcularPTVCCR(ByVal rpt As ReportPrintVO)
        Dim cmmrpt As New MySqlCommand
        ReabreConexao(ConexaoOpenMRSReporting3)

        cmmrpt.CommandType = CommandType.Text
        cmmrpt.Connection = ConexaoOpenMRSReporting3

        Dim dataInicial As String = dataMySQL(rpt.ReportDateRangeStart)
        Dim dataFinal As String = dataMySQL(rpt.ReportDateRangeEnd)
        Dim idPrint As Integer = rpt.ReportsID
        Dim hdd As Integer = rpt.Location.hddOpenMRSID

        cmmrpt.CommandText = "CALL ccr_mensal('" & dataInicial & "','" & dataFinal & "'," & hdd & "," & idPrint & "," & utilizador.UserID & ")"
        cmmrpt.ExecuteNonQuery()

    End Sub
End Class
