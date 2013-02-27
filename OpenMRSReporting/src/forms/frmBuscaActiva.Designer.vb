<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscaActiva
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscaActiva))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkDistrital = New System.Windows.Forms.CheckBox
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.categoria = New System.Windows.Forms.GroupBox
        Me.dataInicial = New System.Windows.Forms.DateTimePicker
        Me.dataFinal = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.rdNaoVoltouCD4 = New System.Windows.Forms.RadioButton
        Me.rdNaoVoltou = New System.Windows.Forms.RadioButton
        Me.rdFaltoso = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Lista = New System.Windows.Forms.DataGridView
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.rdNaoColheuCD4 = New System.Windows.Forms.RadioButton
        Me.rdCD4Menor350 = New System.Windows.Forms.RadioButton
        Me.rdCCR = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.categoria.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDistrital)
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
        Me.GroupBox1.Size = New System.Drawing.Size(365, 121)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'chkDistrital
        '
        Me.chkDistrital.AutoSize = True
        Me.chkDistrital.Checked = True
        Me.chkDistrital.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDistrital.Location = New System.Drawing.Point(247, 49)
        Me.chkDistrital.Name = "chkDistrital"
        Me.chkDistrital.Size = New System.Drawing.Size(107, 20)
        Me.chkDistrital.TabIndex = 15
        Me.chkDistrital.Text = "Incluir 2º Sitio"
        Me.chkDistrital.UseVisualStyleBackColor = True
        '
        'cboDistrito
        '
        Me.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrito.FormattingEnabled = True
        Me.cboDistrito.Location = New System.Drawing.Point(91, 47)
        Me.cboDistrito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(150, 24)
        Me.cboDistrito.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Distrito"
        '
        'cboProvincia
        '
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(91, 16)
        Me.cboProvincia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(263, 24)
        Me.cboProvincia.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Provincia"
        '
        'cboUS
        '
        Me.cboUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUS.FormattingEnabled = True
        Me.cboUS.Location = New System.Drawing.Point(91, 81)
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
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "U. Sanitaria"
        '
        'categoria
        '
        Me.categoria.Controls.Add(Me.rdCCR)
        Me.categoria.Controls.Add(Me.rdCD4Menor350)
        Me.categoria.Controls.Add(Me.rdNaoColheuCD4)
        Me.categoria.Controls.Add(Me.dataInicial)
        Me.categoria.Controls.Add(Me.dataFinal)
        Me.categoria.Controls.Add(Me.Label3)
        Me.categoria.Controls.Add(Me.rdNaoVoltouCD4)
        Me.categoria.Controls.Add(Me.rdNaoVoltou)
        Me.categoria.Controls.Add(Me.rdFaltoso)
        Me.categoria.Location = New System.Drawing.Point(383, 13)
        Me.categoria.Name = "categoria"
        Me.categoria.Size = New System.Drawing.Size(449, 121)
        Me.categoria.TabIndex = 12
        Me.categoria.TabStop = False
        Me.categoria.Text = "Categoria"
        '
        'dataInicial
        '
        Me.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataInicial.Location = New System.Drawing.Point(204, 45)
        Me.dataInicial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dataInicial.Name = "dataInicial"
        Me.dataInicial.Size = New System.Drawing.Size(89, 22)
        Me.dataInicial.TabIndex = 17
        '
        'dataFinal
        '
        Me.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataFinal.Location = New System.Drawing.Point(341, 47)
        Me.dataFinal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dataFinal.Name = "dataFinal"
        Me.dataFinal.Size = New System.Drawing.Size(99, 22)
        Me.dataFinal.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(308, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "A"
        '
        'rdNaoVoltouCD4
        '
        Me.rdNaoVoltouCD4.AutoSize = True
        Me.rdNaoVoltouCD4.Location = New System.Drawing.Point(138, 74)
        Me.rdNaoVoltouCD4.Name = "rdNaoVoltouCD4"
        Me.rdNaoVoltouCD4.Size = New System.Drawing.Size(144, 20)
        Me.rdNaoVoltouCD4.TabIndex = 2
        Me.rdNaoVoltouCD4.Text = "Nao voltou para CD4"
        Me.ToolTip1.SetToolTip(Me.rdNaoVoltouCD4, "Pacientes pre-tarv, que colheram CD4 mas que nao vieram saber o seu resultado")
        Me.rdNaoVoltouCD4.UseVisualStyleBackColor = True
        '
        'rdNaoVoltou
        '
        Me.rdNaoVoltou.AutoSize = True
        Me.rdNaoVoltou.Location = New System.Drawing.Point(12, 47)
        Me.rdNaoVoltou.Name = "rdNaoVoltou"
        Me.rdNaoVoltou.Size = New System.Drawing.Size(186, 20)
        Me.rdNaoVoltou.TabIndex = 1
        Me.rdNaoVoltou.Text = "Abriu processo e nao voltou"
        Me.ToolTip1.SetToolTip(Me.rdNaoVoltou, "Abriram processo e nao voltaram a consulta")
        Me.rdNaoVoltou.UseVisualStyleBackColor = True
        '
        'rdFaltoso
        '
        Me.rdFaltoso.AutoSize = True
        Me.rdFaltoso.Checked = True
        Me.rdFaltoso.Location = New System.Drawing.Point(12, 20)
        Me.rdFaltoso.Name = "rdFaltoso"
        Me.rdFaltoso.Size = New System.Drawing.Size(131, 20)
        Me.rdFaltoso.TabIndex = 0
        Me.rdFaltoso.TabStop = True
        Me.rdFaltoso.Text = "Faltosos ao TARV"
        Me.ToolTip1.SetToolTip(Me.rdFaltoso, "Faltosos a farmácia para levantamento de medicamentos ARV. (7-59 dias apos a data" & _
                " marcada para levantamento)")
        Me.rdFaltoso.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdExcel)
        Me.GroupBox2.Controls.Add(Me.cmdFechar)
        Me.GroupBox2.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox2.Location = New System.Drawing.Point(838, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(96, 121)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(12, 47)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(74, 30)
        Me.cmdExcel.TabIndex = 2
        Me.cmdExcel.Text = "&Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'cmdFechar
        '
        Me.cmdFechar.Location = New System.Drawing.Point(12, 83)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(74, 30)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = True
        '
        'cmdVisualizar
        '
        Me.cmdVisualizar.Location = New System.Drawing.Point(12, 11)
        Me.cmdVisualizar.Name = "cmdVisualizar"
        Me.cmdVisualizar.Size = New System.Drawing.Size(74, 30)
        Me.cmdVisualizar.TabIndex = 0
        Me.cmdVisualizar.Text = "&Visualizar"
        Me.cmdVisualizar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Lista)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 141)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(922, 352)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lista"
        '
        'Lista
        '
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Location = New System.Drawing.Point(6, 21)
        Me.Lista.Name = "Lista"
        Me.Lista.Size = New System.Drawing.Size(906, 325)
        Me.Lista.TabIndex = 0
        '
        'rdNaoColheuCD4
        '
        Me.rdNaoColheuCD4.AutoSize = True
        Me.rdNaoColheuCD4.Location = New System.Drawing.Point(12, 74)
        Me.rdNaoColheuCD4.Name = "rdNaoColheuCD4"
        Me.rdNaoColheuCD4.Size = New System.Drawing.Size(120, 20)
        Me.rdNaoColheuCD4.TabIndex = 18
        Me.rdNaoColheuCD4.TabStop = True
        Me.rdNaoColheuCD4.Text = "Não colheu CD4"
        Me.ToolTip1.SetToolTip(Me.rdNaoColheuCD4, "Abriram processo, voltaram a consulta mas não colheram CD4")
        Me.rdNaoColheuCD4.UseVisualStyleBackColor = True
        '
        'rdCD4Menor350
        '
        Me.rdCD4Menor350.AutoSize = True
        Me.rdCD4Menor350.Location = New System.Drawing.Point(301, 74)
        Me.rdCD4Menor350.Name = "rdCD4Menor350"
        Me.rdCD4Menor350.Size = New System.Drawing.Size(88, 20)
        Me.rdCD4Menor350.TabIndex = 19
        Me.rdCD4Menor350.TabStop = True
        Me.rdCD4Menor350.Text = "CD4 < 350"
        Me.ToolTip1.SetToolTip(Me.rdCD4Menor350, "Pacientes pre-tarv elegiveis para iniciar TARV (CD4<350) , mas que nao vieram sab" & _
                "er o seu resultado de CD4")
        Me.rdCD4Menor350.UseVisualStyleBackColor = True
        '
        'rdCCR
        '
        Me.rdCCR.AutoSize = True
        Me.rdCCR.Location = New System.Drawing.Point(12, 95)
        Me.rdCCR.Name = "rdCCR"
        Me.rdCCR.Size = New System.Drawing.Size(149, 20)
        Me.rdCCR.TabIndex = 20
        Me.rdCCR.TabStop = True
        Me.rdCCR.Text = "Provenientes do CCR"
        Me.ToolTip1.SetToolTip(Me.rdCCR, "Inscritos no serviço TARV provenientes do CCR e que não iniciaram TARV")
        Me.rdCCR.UseVisualStyleBackColor = True
        '
        'frmBuscaActiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 505)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.categoria)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmBuscaActiva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busca Activa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.categoria.ResumeLayout(False)
        Me.categoria.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDistrital As System.Windows.Forms.CheckBox
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents categoria As System.Windows.Forms.GroupBox
    Friend WithEvents rdFaltoso As System.Windows.Forms.RadioButton
    Friend WithEvents rdNaoVoltouCD4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdNaoVoltou As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Lista As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents rdNaoColheuCD4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdCD4Menor350 As System.Windows.Forms.RadioButton
    Friend WithEvents rdCCR As System.Windows.Forms.RadioButton
End Class
