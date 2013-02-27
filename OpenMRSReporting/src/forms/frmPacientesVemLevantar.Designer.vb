<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacientesVemLevantar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPacientesVemLevantar))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkSitio = New System.Windows.Forms.CheckBox
        Me.dataFinal = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dataInicial = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.rdARV = New System.Windows.Forms.RadioButton
        Me.rdConsulta = New System.Windows.Forms.RadioButton
        Me.rdCD4 = New System.Windows.Forms.RadioButton
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdExcel)
        Me.GroupBox2.Controls.Add(Me.cmdFechar)
        Me.GroupBox2.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox2.Location = New System.Drawing.Point(522, 13)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(214, 172)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(51, 65)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(100, 40)
        Me.cmdExcel.TabIndex = 2
        Me.cmdExcel.Text = "&Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Location = New System.Drawing.Point(51, 113)
        Me.cmdFechar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(100, 40)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'cmdVisualizar
        '
        Me.cmdVisualizar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVisualizar.Location = New System.Drawing.Point(51, 18)
        Me.cmdVisualizar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdVisualizar.Name = "cmdVisualizar"
        Me.cmdVisualizar.Size = New System.Drawing.Size(100, 40)
        Me.cmdVisualizar.TabIndex = 0
        Me.cmdVisualizar.Text = "&Visualizar"
        Me.cmdVisualizar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdCD4)
        Me.GroupBox1.Controls.Add(Me.rdConsulta)
        Me.GroupBox1.Controls.Add(Me.rdARV)
        Me.GroupBox1.Controls.Add(Me.chkSitio)
        Me.GroupBox1.Controls.Add(Me.dataFinal)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dataInicial)
        Me.GroupBox1.Controls.Add(Me.Label2)
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
        Me.GroupBox1.Size = New System.Drawing.Size(504, 172)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'chkSitio
        '
        Me.chkSitio.AutoSize = True
        Me.chkSitio.Checked = True
        Me.chkSitio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSitio.Location = New System.Drawing.Point(390, 53)
        Me.chkSitio.Name = "chkSitio"
        Me.chkSitio.Size = New System.Drawing.Size(107, 20)
        Me.chkSitio.TabIndex = 14
        Me.chkSitio.Text = "Incluir 2º Sitio"
        Me.chkSitio.UseVisualStyleBackColor = True
        '
        'dataFinal
        '
        Me.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataFinal.Location = New System.Drawing.Point(290, 113)
        Me.dataFinal.Name = "dataFinal"
        Me.dataFinal.Size = New System.Drawing.Size(94, 22)
        Me.dataFinal.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(247, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "A"
        '
        'dataInicial
        '
        Me.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataInicial.Location = New System.Drawing.Point(142, 113)
        Me.dataInicial.Name = "dataInicial"
        Me.dataInicial.Size = New System.Drawing.Size(89, 22)
        Me.dataInicial.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Periodo de"
        '
        'cboDistrito
        '
        Me.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrito.FormattingEnabled = True
        Me.cboDistrito.Location = New System.Drawing.Point(142, 50)
        Me.cboDistrito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(242, 24)
        Me.cboDistrito.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Distrito"
        '
        'cboProvincia
        '
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(142, 18)
        Me.cboProvincia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(242, 24)
        Me.cboProvincia.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Provincia"
        '
        'cboUS
        '
        Me.cboUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUS.FormattingEnabled = True
        Me.cboUS.Location = New System.Drawing.Point(142, 82)
        Me.cboUS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboUS.Name = "cboUS"
        Me.cboUS.Size = New System.Drawing.Size(242, 24)
        Me.cboUS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unidade Sanitaria"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 192)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(724, 339)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 21)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(706, 312)
        Me.DataGridView1.TabIndex = 0
        '
        'rdARV
        '
        Me.rdARV.AutoSize = True
        Me.rdARV.Checked = True
        Me.rdARV.Location = New System.Drawing.Point(148, 145)
        Me.rdARV.Name = "rdARV"
        Me.rdARV.Size = New System.Drawing.Size(53, 20)
        Me.rdARV.TabIndex = 15
        Me.rdARV.TabStop = True
        Me.rdARV.Text = "ARV"
        Me.rdARV.UseVisualStyleBackColor = True
        '
        'rdConsulta
        '
        Me.rdConsulta.AutoSize = True
        Me.rdConsulta.Location = New System.Drawing.Point(207, 145)
        Me.rdConsulta.Name = "rdConsulta"
        Me.rdConsulta.Size = New System.Drawing.Size(77, 20)
        Me.rdConsulta.TabIndex = 16
        Me.rdConsulta.Text = "Consulta"
        Me.rdConsulta.UseVisualStyleBackColor = True
        '
        'rdCD4
        '
        Me.rdCD4.AutoSize = True
        Me.rdCD4.Location = New System.Drawing.Point(290, 145)
        Me.rdCD4.Name = "rdCD4"
        Me.rdCD4.Size = New System.Drawing.Size(51, 20)
        Me.rdCD4.TabIndex = 17
        Me.rdCD4.Text = "CD4"
        Me.rdCD4.UseVisualStyleBackColor = True
        '
        'frmPacientesVemLevantar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 543)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmPacientesVemLevantar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AGENDA DE VISITA"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSitio As System.Windows.Forms.CheckBox
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents rdCD4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdConsulta As System.Windows.Forms.RadioButton
    Friend WithEvents rdARV As System.Windows.Forms.RadioButton
End Class
