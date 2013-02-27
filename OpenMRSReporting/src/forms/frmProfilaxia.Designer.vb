<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfilaxia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProfilaxia))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblNumero = New System.Windows.Forms.Label
        Me.dataView = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdAmbos = New System.Windows.Forms.RadioButton
        Me.rdINH = New System.Windows.Forms.RadioButton
        Me.rdCTZ = New System.Windows.Forms.RadioButton
        Me.chkEmTARV = New System.Windows.Forms.CheckBox
        Me.dataInicial = New System.Windows.Forms.DateTimePicker
        Me.dataFinal = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkDistrital = New System.Windows.Forms.CheckBox
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.cmdExcel)
        Me.GroupBox3.Controls.Add(Me.cmdFechar)
        Me.GroupBox3.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 621)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(583, 54)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        '
        'cmdExcel
        '
        Me.cmdExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExcel.Location = New System.Drawing.Point(316, 12)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(110, 30)
        Me.cmdExcel.TabIndex = 2
        Me.cmdExcel.Text = "&Exportar Excel"
        Me.cmdExcel.UseVisualStyleBackColor = False
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Location = New System.Drawing.Point(432, 12)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(110, 30)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'cmdVisualizar
        '
        Me.cmdVisualizar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVisualizar.Location = New System.Drawing.Point(25, 12)
        Me.cmdVisualizar.Name = "cmdVisualizar"
        Me.cmdVisualizar.Size = New System.Drawing.Size(110, 30)
        Me.cmdVisualizar.TabIndex = 0
        Me.cmdVisualizar.Text = "&Visualizar"
        Me.cmdVisualizar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblNumero)
        Me.GroupBox2.Controls.Add(Me.dataView)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(583, 458)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(8, 429)
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
        Me.dataView.Size = New System.Drawing.Size(566, 395)
        Me.dataView.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdAmbos)
        Me.GroupBox1.Controls.Add(Me.rdINH)
        Me.GroupBox1.Controls.Add(Me.rdCTZ)
        Me.GroupBox1.Controls.Add(Me.chkEmTARV)
        Me.GroupBox1.Controls.Add(Me.dataInicial)
        Me.GroupBox1.Controls.Add(Me.dataFinal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkDistrital)
        Me.GroupBox1.Controls.Add(Me.cboDistrito)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboProvincia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboUS)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(583, 139)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'rdAmbos
        '
        Me.rdAmbos.AutoSize = True
        Me.rdAmbos.Location = New System.Drawing.Point(506, 108)
        Me.rdAmbos.Name = "rdAmbos"
        Me.rdAmbos.Size = New System.Drawing.Size(61, 20)
        Me.rdAmbos.TabIndex = 18
        Me.rdAmbos.Text = "Todas"
        Me.rdAmbos.UseVisualStyleBackColor = True
        '
        'rdINH
        '
        Me.rdINH.AutoSize = True
        Me.rdINH.Location = New System.Drawing.Point(453, 108)
        Me.rdINH.Name = "rdINH"
        Me.rdINH.Size = New System.Drawing.Size(47, 20)
        Me.rdINH.TabIndex = 17
        Me.rdINH.Text = "INH"
        Me.rdINH.UseVisualStyleBackColor = True
        '
        'rdCTZ
        '
        Me.rdCTZ.AutoSize = True
        Me.rdCTZ.Checked = True
        Me.rdCTZ.Location = New System.Drawing.Point(393, 108)
        Me.rdCTZ.Name = "rdCTZ"
        Me.rdCTZ.Size = New System.Drawing.Size(49, 20)
        Me.rdCTZ.TabIndex = 16
        Me.rdCTZ.TabStop = True
        Me.rdCTZ.Text = "CTZ"
        Me.rdCTZ.UseVisualStyleBackColor = True
        '
        'chkEmTARV
        '
        Me.chkEmTARV.AutoSize = True
        Me.chkEmTARV.Location = New System.Drawing.Point(393, 77)
        Me.chkEmTARV.Name = "chkEmTARV"
        Me.chkEmTARV.Size = New System.Drawing.Size(85, 20)
        Me.chkEmTARV.TabIndex = 15
        Me.chkEmTARV.Text = "Em TARV"
        Me.chkEmTARV.UseVisualStyleBackColor = True
        '
        'dataInicial
        '
        Me.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataInicial.Location = New System.Drawing.Point(151, 105)
        Me.dataInicial.Name = "dataInicial"
        Me.dataInicial.Size = New System.Drawing.Size(93, 22)
        Me.dataInicial.TabIndex = 14
        '
        'dataFinal
        '
        Me.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataFinal.Location = New System.Drawing.Point(273, 105)
        Me.dataFinal.Name = "dataFinal"
        Me.dataFinal.Size = New System.Drawing.Size(92, 22)
        Me.dataFinal.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Periodo de Profilaxia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(250, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "A"
        '
        'chkDistrital
        '
        Me.chkDistrital.AutoSize = True
        Me.chkDistrital.Checked = True
        Me.chkDistrital.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDistrital.Location = New System.Drawing.Point(393, 47)
        Me.chkDistrital.Name = "chkDistrital"
        Me.chkDistrital.Size = New System.Drawing.Size(107, 20)
        Me.chkDistrital.TabIndex = 10
        Me.chkDistrital.Text = "Incluir 2º Sitio"
        Me.chkDistrital.UseVisualStyleBackColor = True
        '
        'cboDistrito
        '
        Me.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrito.FormattingEnabled = True
        Me.cboDistrito.Location = New System.Drawing.Point(151, 45)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(236, 24)
        Me.cboDistrito.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Distrito"
        '
        'cboProvincia
        '
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(151, 15)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(236, 24)
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
        'cboUS
        '
        Me.cboUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUS.FormattingEnabled = True
        Me.cboUS.Location = New System.Drawing.Point(151, 75)
        Me.cboUS.Name = "cboUS"
        Me.cboUS.Size = New System.Drawing.Size(238, 24)
        Me.cboUS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unidade Sanitaria"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(141, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(169, 30)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Visualizar Com Detalhes"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmProfilaxia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 687)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmProfilaxia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Profilaxia com Cotrimoxazol"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dataView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkDistrital As System.Windows.Forms.CheckBox
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents chkEmTARV As System.Windows.Forms.CheckBox
    Friend WithEvents rdAmbos As System.Windows.Forms.RadioButton
    Friend WithEvents rdINH As System.Windows.Forms.RadioButton
    Friend WithEvents rdCTZ As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
