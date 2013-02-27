<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmissaoServicoTARV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdmissaoServicoTARV))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblTarv = New System.Windows.Forms.Label
        Me.lblNumero = New System.Windows.Forms.Label
        Me.dataView = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.FaixaEtaria = New System.Windows.Forms.GroupBox
        Me.rdAdulto = New System.Windows.Forms.RadioButton
        Me.rdCrianca = New System.Windows.Forms.RadioButton
        Me.rdFaixaTodos = New System.Windows.Forms.RadioButton
        Me.Sexo = New System.Windows.Forms.GroupBox
        Me.rdM = New System.Windows.Forms.RadioButton
        Me.rdF = New System.Windows.Forms.RadioButton
        Me.rdSexoTodos = New System.Windows.Forms.RadioButton
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
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.FaixaEtaria.SuspendLayout()
        Me.Sexo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdExcel)
        Me.GroupBox3.Controls.Add(Me.cmdFechar)
        Me.GroupBox3.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 632)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(715, 54)
        Me.GroupBox3.TabIndex = 12
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
        Me.GroupBox2.Controls.Add(Me.lblTarv)
        Me.GroupBox2.Controls.Add(Me.lblNumero)
        Me.GroupBox2.Controls.Add(Me.dataView)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(715, 454)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'lblTarv
        '
        Me.lblTarv.AutoSize = True
        Me.lblTarv.Location = New System.Drawing.Point(495, 426)
        Me.lblTarv.Name = "lblTarv"
        Me.lblTarv.Size = New System.Drawing.Size(46, 16)
        Me.lblTarv.TabIndex = 3
        Me.lblTarv.Text = "Label7"
        Me.lblTarv.Visible = False
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(9, 426)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(46, 16)
        Me.lblNumero.TabIndex = 1
        Me.lblNumero.Text = "Label6"
        Me.lblNumero.Visible = False
        '
        'dataView
        '
        Me.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataView.Location = New System.Drawing.Point(11, 21)
        Me.dataView.Name = "dataView"
        Me.dataView.Size = New System.Drawing.Size(689, 395)
        Me.dataView.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FaixaEtaria)
        Me.GroupBox1.Controls.Add(Me.Sexo)
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
        Me.GroupBox1.Size = New System.Drawing.Size(715, 152)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'FaixaEtaria
        '
        Me.FaixaEtaria.Controls.Add(Me.rdAdulto)
        Me.FaixaEtaria.Controls.Add(Me.rdCrianca)
        Me.FaixaEtaria.Controls.Add(Me.rdFaixaTodos)
        Me.FaixaEtaria.Location = New System.Drawing.Point(552, 19)
        Me.FaixaEtaria.Name = "FaixaEtaria"
        Me.FaixaEtaria.Size = New System.Drawing.Size(148, 115)
        Me.FaixaEtaria.TabIndex = 17
        Me.FaixaEtaria.TabStop = False
        Me.FaixaEtaria.Text = "Faixa Etaria"
        '
        'rdAdulto
        '
        Me.rdAdulto.AutoSize = True
        Me.rdAdulto.Location = New System.Drawing.Point(28, 84)
        Me.rdAdulto.Name = "rdAdulto"
        Me.rdAdulto.Size = New System.Drawing.Size(70, 20)
        Me.rdAdulto.TabIndex = 2
        Me.rdAdulto.TabStop = True
        Me.rdAdulto.Text = "Adultos"
        Me.rdAdulto.UseVisualStyleBackColor = True
        '
        'rdCrianca
        '
        Me.rdCrianca.AutoSize = True
        Me.rdCrianca.Location = New System.Drawing.Point(28, 57)
        Me.rdCrianca.Name = "rdCrianca"
        Me.rdCrianca.Size = New System.Drawing.Size(77, 20)
        Me.rdCrianca.TabIndex = 1
        Me.rdCrianca.TabStop = True
        Me.rdCrianca.Text = "Crianças"
        Me.rdCrianca.UseVisualStyleBackColor = True
        '
        'rdFaixaTodos
        '
        Me.rdFaixaTodos.AutoSize = True
        Me.rdFaixaTodos.Checked = True
        Me.rdFaixaTodos.Location = New System.Drawing.Point(28, 29)
        Me.rdFaixaTodos.Name = "rdFaixaTodos"
        Me.rdFaixaTodos.Size = New System.Drawing.Size(61, 20)
        Me.rdFaixaTodos.TabIndex = 0
        Me.rdFaixaTodos.TabStop = True
        Me.rdFaixaTodos.Text = "Todos"
        Me.rdFaixaTodos.UseVisualStyleBackColor = True
        '
        'Sexo
        '
        Me.Sexo.Controls.Add(Me.rdM)
        Me.Sexo.Controls.Add(Me.rdF)
        Me.Sexo.Controls.Add(Me.rdSexoTodos)
        Me.Sexo.Location = New System.Drawing.Point(416, 19)
        Me.Sexo.Name = "Sexo"
        Me.Sexo.Size = New System.Drawing.Size(130, 115)
        Me.Sexo.TabIndex = 16
        Me.Sexo.TabStop = False
        Me.Sexo.Text = "Sexo"
        '
        'rdM
        '
        Me.rdM.AutoSize = True
        Me.rdM.Location = New System.Drawing.Point(19, 84)
        Me.rdM.Name = "rdM"
        Me.rdM.Size = New System.Drawing.Size(37, 20)
        Me.rdM.TabIndex = 2
        Me.rdM.Text = "M"
        Me.rdM.UseVisualStyleBackColor = True
        '
        'rdF
        '
        Me.rdF.AutoSize = True
        Me.rdF.Location = New System.Drawing.Point(19, 57)
        Me.rdF.Name = "rdF"
        Me.rdF.Size = New System.Drawing.Size(34, 20)
        Me.rdF.TabIndex = 1
        Me.rdF.Text = "F" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rdF.UseVisualStyleBackColor = True
        '
        'rdSexoTodos
        '
        Me.rdSexoTodos.AutoSize = True
        Me.rdSexoTodos.Checked = True
        Me.rdSexoTodos.Location = New System.Drawing.Point(19, 29)
        Me.rdSexoTodos.Name = "rdSexoTodos"
        Me.rdSexoTodos.Size = New System.Drawing.Size(67, 20)
        Me.rdSexoTodos.TabIndex = 0
        Me.rdSexoTodos.TabStop = True
        Me.rdSexoTodos.Text = "Ambos"
        Me.rdSexoTodos.UseVisualStyleBackColor = True
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
        Me.Label2.Size = New System.Drawing.Size(132, 16)
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
        'frmAdmissaoServicoTARV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 697)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmAdmissaoServicoTARV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admissão Serviço TARV"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FaixaEtaria.ResumeLayout(False)
        Me.FaixaEtaria.PerformLayout()
        Me.Sexo.ResumeLayout(False)
        Me.Sexo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTarv As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents dataView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents Sexo As System.Windows.Forms.GroupBox
    Friend WithEvents FaixaEtaria As System.Windows.Forms.GroupBox
    Friend WithEvents rdM As System.Windows.Forms.RadioButton
    Friend WithEvents rdF As System.Windows.Forms.RadioButton
    Friend WithEvents rdSexoTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdAdulto As System.Windows.Forms.RadioButton
    Friend WithEvents rdCrianca As System.Windows.Forms.RadioButton
    Friend WithEvents rdFaixaTodos As System.Windows.Forms.RadioButton
End Class
