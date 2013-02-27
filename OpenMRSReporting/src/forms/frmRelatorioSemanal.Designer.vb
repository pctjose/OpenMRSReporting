<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatorioSemanal
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelatorioSemanal))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdGrafico = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.cmdManual = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdAutomatico = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dataInicial = New System.Windows.Forms.DateTimePicker
        Me.dataFinal = New System.Windows.Forms.DateTimePicker
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblInfo = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdGrafico)
        Me.GroupBox2.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox2.Controls.Add(Me.cmdExcel)
        Me.GroupBox2.Controls.Add(Me.cmdManual)
        Me.GroupBox2.Controls.Add(Me.cmdFechar)
        Me.GroupBox2.Controls.Add(Me.cmdAutomatico)
        Me.GroupBox2.Location = New System.Drawing.Point(394, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(223, 145)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'cmdGrafico
        '
        Me.cmdGrafico.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGrafico.Enabled = False
        Me.cmdGrafico.Location = New System.Drawing.Point(6, 97)
        Me.cmdGrafico.Name = "cmdGrafico"
        Me.cmdGrafico.Size = New System.Drawing.Size(100, 35)
        Me.cmdGrafico.TabIndex = 5
        Me.cmdGrafico.Text = "&Grafico"
        Me.ToolTip1.SetToolTip(Me.cmdGrafico, "Comparacao Grafica de Indicadores")
        Me.cmdGrafico.UseVisualStyleBackColor = False
        '
        'cmdVisualizar
        '
        Me.cmdVisualizar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVisualizar.Location = New System.Drawing.Point(6, 56)
        Me.cmdVisualizar.Name = "cmdVisualizar"
        Me.cmdVisualizar.Size = New System.Drawing.Size(100, 35)
        Me.cmdVisualizar.TabIndex = 4
        Me.cmdVisualizar.Text = "&Visualizar"
        Me.ToolTip1.SetToolTip(Me.cmdVisualizar, "Visualizar os indicadores na forma de relatorio personalizado")
        Me.cmdVisualizar.UseVisualStyleBackColor = False
        '
        'cmdExcel
        '
        Me.cmdExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExcel.Location = New System.Drawing.Point(112, 56)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(100, 35)
        Me.cmdExcel.TabIndex = 3
        Me.cmdExcel.Text = "&Excel"
        Me.ToolTip1.SetToolTip(Me.cmdExcel, "Exportar Indicadores da semana para Excel")
        Me.cmdExcel.UseVisualStyleBackColor = False
        '
        'cmdManual
        '
        Me.cmdManual.BackColor = System.Drawing.SystemColors.Control
        Me.cmdManual.Location = New System.Drawing.Point(112, 15)
        Me.cmdManual.Name = "cmdManual"
        Me.cmdManual.Size = New System.Drawing.Size(100, 35)
        Me.cmdManual.TabIndex = 2
        Me.cmdManual.Text = "&Manuais"
        Me.ToolTip1.SetToolTip(Me.cmdManual, "Introduzir dados de indicadores nao gerados pelo sistema")
        Me.cmdManual.UseVisualStyleBackColor = False
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Location = New System.Drawing.Point(112, 94)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(100, 35)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'cmdAutomatico
        '
        Me.cmdAutomatico.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAutomatico.Location = New System.Drawing.Point(6, 15)
        Me.cmdAutomatico.Name = "cmdAutomatico"
        Me.cmdAutomatico.Size = New System.Drawing.Size(100, 35)
        Me.cmdAutomatico.TabIndex = 0
        Me.cmdAutomatico.Text = "&Automatico"
        Me.ToolTip1.SetToolTip(Me.cmdAutomatico, "Gerar Indicadores de producao automatica")
        Me.cmdAutomatico.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dataInicial)
        Me.GroupBox1.Controls.Add(Me.dataFinal)
        Me.GroupBox1.Controls.Add(Me.cboDistrito)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboProvincia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboUS)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 145)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'dataInicial
        '
        Me.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataInicial.Location = New System.Drawing.Point(122, 110)
        Me.dataInicial.Name = "dataInicial"
        Me.dataInicial.Size = New System.Drawing.Size(93, 22)
        Me.dataInicial.TabIndex = 11
        '
        'dataFinal
        '
        Me.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataFinal.Location = New System.Drawing.Point(268, 110)
        Me.dataFinal.Name = "dataFinal"
        Me.dataFinal.Size = New System.Drawing.Size(92, 22)
        Me.dataFinal.TabIndex = 10
        '
        'cboDistrito
        '
        Me.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrito.FormattingEnabled = True
        Me.cboDistrito.Location = New System.Drawing.Point(122, 47)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(238, 24)
        Me.cboDistrito.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Distrito"
        '
        'cboProvincia
        '
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(122, 15)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(238, 24)
        Me.cboProvincia.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Provincia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Semana de "
        '
        'cboUS
        '
        Me.cboUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUS.FormattingEnabled = True
        Me.cboUS.Location = New System.Drawing.Point(122, 80)
        Me.cboUS.Name = "cboUS"
        Me.cboUS.Size = New System.Drawing.Size(238, 24)
        Me.cboUS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unidade Sanitaria"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblInfo, Me.ProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 171)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(629, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = False
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(370, 17)
        '
        'ProgressBar
        '
        Me.ProgressBar.AutoSize = False
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(230, 16)
        '
        'frmRelatorioSemanal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 193)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmRelatorioSemanal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatorio (Indicadores) Semanal"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdAutomatico As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents cmdManual As System.Windows.Forms.Button
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents cmdGrafico As System.Windows.Forms.Button
End Class
