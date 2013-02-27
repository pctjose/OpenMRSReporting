<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultas))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dataView = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.FaixaEtaria = New System.Windows.Forms.GroupBox
        Me.rdAconselhamento = New System.Windows.Forms.RadioButton
        Me.rdRastreio = New System.Windows.Forms.RadioButton
        Me.rdTodas = New System.Windows.Forms.RadioButton
        Me.rdSeguimento = New System.Windows.Forms.RadioButton
        Me.chkDistrital = New System.Windows.Forms.CheckBox
        Me.dataInicial = New System.Windows.Forms.DateTimePicker
        Me.dataFinal = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTotalConsultas = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.FaixaEtaria.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdExcel)
        Me.GroupBox3.Controls.Add(Me.cmdFechar)
        Me.GroupBox3.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 632)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(774, 54)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        '
        'cmdExcel
        '
        Me.cmdExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExcel.Location = New System.Drawing.Point(292, 14)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(110, 30)
        Me.cmdExcel.TabIndex = 2
        Me.cmdExcel.Text = "&Exportar Excel"
        Me.cmdExcel.UseVisualStyleBackColor = False
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Location = New System.Drawing.Point(408, 14)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(110, 30)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'cmdVisualizar
        '
        Me.cmdVisualizar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVisualizar.Location = New System.Drawing.Point(176, 14)
        Me.cmdVisualizar.Name = "cmdVisualizar"
        Me.cmdVisualizar.Size = New System.Drawing.Size(110, 30)
        Me.cmdVisualizar.TabIndex = 0
        Me.cmdVisualizar.Text = "&Visualizar"
        Me.cmdVisualizar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dataView)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(774, 454)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'dataView
        '
        Me.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataView.Location = New System.Drawing.Point(11, 21)
        Me.dataView.Name = "dataView"
        Me.dataView.Size = New System.Drawing.Size(757, 427)
        Me.dataView.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FaixaEtaria)
        Me.GroupBox1.Controls.Add(Me.chkDistrital)
        Me.GroupBox1.Controls.Add(Me.dataInicial)
        Me.GroupBox1.Controls.Add(Me.dataFinal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboDistrito)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboProvincia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboUS)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(774, 152)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'FaixaEtaria
        '
        Me.FaixaEtaria.Controls.Add(Me.lblTotalConsultas)
        Me.FaixaEtaria.Controls.Add(Me.rdAconselhamento)
        Me.FaixaEtaria.Controls.Add(Me.rdRastreio)
        Me.FaixaEtaria.Controls.Add(Me.rdTodas)
        Me.FaixaEtaria.Controls.Add(Me.rdSeguimento)
        Me.FaixaEtaria.Location = New System.Drawing.Point(500, 22)
        Me.FaixaEtaria.Name = "FaixaEtaria"
        Me.FaixaEtaria.Size = New System.Drawing.Size(268, 115)
        Me.FaixaEtaria.TabIndex = 17
        Me.FaixaEtaria.TabStop = False
        Me.FaixaEtaria.Text = "Faixa Etaria"
        '
        'rdAconselhamento
        '
        Me.rdAconselhamento.AutoSize = True
        Me.rdAconselhamento.Location = New System.Drawing.Point(128, 62)
        Me.rdAconselhamento.Name = "rdAconselhamento"
        Me.rdAconselhamento.Size = New System.Drawing.Size(123, 20)
        Me.rdAconselhamento.TabIndex = 3
        Me.rdAconselhamento.TabStop = True
        Me.rdAconselhamento.Text = "Aconselhamento"
        Me.rdAconselhamento.UseVisualStyleBackColor = True
        '
        'rdRastreio
        '
        Me.rdRastreio.AutoSize = True
        Me.rdRastreio.Location = New System.Drawing.Point(28, 63)
        Me.rdRastreio.Name = "rdRastreio"
        Me.rdRastreio.Size = New System.Drawing.Size(94, 20)
        Me.rdRastreio.TabIndex = 2
        Me.rdRastreio.TabStop = True
        Me.rdRastreio.Text = "Rastreio TB"
        Me.rdRastreio.UseVisualStyleBackColor = True
        '
        'rdTodas
        '
        Me.rdTodas.AutoSize = True
        Me.rdTodas.Location = New System.Drawing.Point(28, 26)
        Me.rdTodas.Name = "rdTodas"
        Me.rdTodas.Size = New System.Drawing.Size(60, 20)
        Me.rdTodas.TabIndex = 1
        Me.rdTodas.TabStop = True
        Me.rdTodas.Text = "Todas"
        Me.rdTodas.UseVisualStyleBackColor = True
        '
        'rdSeguimento
        '
        Me.rdSeguimento.AutoSize = True
        Me.rdSeguimento.Checked = True
        Me.rdSeguimento.Location = New System.Drawing.Point(128, 29)
        Me.rdSeguimento.Name = "rdSeguimento"
        Me.rdSeguimento.Size = New System.Drawing.Size(95, 20)
        Me.rdSeguimento.TabIndex = 0
        Me.rdSeguimento.TabStop = True
        Me.rdSeguimento.Text = "Seguimento"
        Me.rdSeguimento.UseVisualStyleBackColor = True
        '
        'chkDistrital
        '
        Me.chkDistrital.AutoSize = True
        Me.chkDistrital.Checked = True
        Me.chkDistrital.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDistrital.Location = New System.Drawing.Point(303, 51)
        Me.chkDistrital.Name = "chkDistrital"
        Me.chkDistrital.Size = New System.Drawing.Size(107, 20)
        Me.chkDistrital.TabIndex = 15
        Me.chkDistrital.Text = "Incluir 2º Sitio"
        Me.chkDistrital.UseVisualStyleBackColor = True
        '
        'dataInicial
        '
        Me.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataInicial.Location = New System.Drawing.Point(147, 112)
        Me.dataInicial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dataInicial.Name = "dataInicial"
        Me.dataInicial.Size = New System.Drawing.Size(108, 22)
        Me.dataInicial.TabIndex = 14
        '
        'dataFinal
        '
        Me.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataFinal.Location = New System.Drawing.Point(284, 114)
        Me.dataFinal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dataFinal.Name = "dataFinal"
        Me.dataFinal.Size = New System.Drawing.Size(107, 22)
        Me.dataFinal.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Periodo de Admissão"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(261, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "A"
        '
        'cboDistrito
        '
        Me.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrito.FormattingEnabled = True
        Me.cboDistrito.Location = New System.Drawing.Point(147, 49)
        Me.cboDistrito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(150, 24)
        Me.cboDistrito.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Distrito"
        '
        'cboProvincia
        '
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(147, 19)
        Me.cboProvincia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(263, 24)
        Me.cboProvincia.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Provincia"
        '
        'cboUS
        '
        Me.cboUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUS.FormattingEnabled = True
        Me.cboUS.Location = New System.Drawing.Point(147, 81)
        Me.cboUS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboUS.Name = "cboUS"
        Me.cboUS.Size = New System.Drawing.Size(263, 24)
        Me.cboUS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unidade Sanitaria"
        '
        'lblTotalConsultas
        '
        Me.lblTotalConsultas.AutoSize = True
        Me.lblTotalConsultas.Location = New System.Drawing.Point(40, 90)
        Me.lblTotalConsultas.Name = "lblTotalConsultas"
        Me.lblTotalConsultas.Size = New System.Drawing.Size(0, 16)
        Me.lblTotalConsultas.TabIndex = 4
        '
        'frmConsultas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 701)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmConsultas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultas"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FaixaEtaria.ResumeLayout(False)
        Me.FaixaEtaria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dataView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FaixaEtaria As System.Windows.Forms.GroupBox
    Friend WithEvents rdTodas As System.Windows.Forms.RadioButton
    Friend WithEvents rdSeguimento As System.Windows.Forms.RadioButton
    Friend WithEvents chkDistrital As System.Windows.Forms.CheckBox
    Friend WithEvents dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdRastreio As System.Windows.Forms.RadioButton
    Friend WithEvents rdAconselhamento As System.Windows.Forms.RadioButton
    Friend WithEvents lblTotalConsultas As System.Windows.Forms.Label
End Class
