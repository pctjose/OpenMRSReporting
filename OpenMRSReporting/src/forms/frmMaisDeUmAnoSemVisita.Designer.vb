<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaisDeUmAnoSemVisita
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaisDeUmAnoSemVisita))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dataView = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkDistrital = New System.Windows.Forms.CheckBox
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
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdExcel)
        Me.GroupBox3.Controls.Add(Me.cmdFechar)
        Me.GroupBox3.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 543)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(810, 54)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        '
        'cmdExcel
        '
        Me.cmdExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExcel.Location = New System.Drawing.Point(350, 14)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(110, 30)
        Me.cmdExcel.TabIndex = 2
        Me.cmdExcel.Text = "&Exportar Excel"
        Me.cmdExcel.UseVisualStyleBackColor = False
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Location = New System.Drawing.Point(466, 14)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(110, 30)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'cmdVisualizar
        '
        Me.cmdVisualizar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVisualizar.Location = New System.Drawing.Point(234, 14)
        Me.cmdVisualizar.Name = "cmdVisualizar"
        Me.cmdVisualizar.Size = New System.Drawing.Size(110, 30)
        Me.cmdVisualizar.TabIndex = 0
        Me.cmdVisualizar.Text = "&Visualizar"
        Me.cmdVisualizar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dataView)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(810, 433)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'dataView
        '
        Me.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataView.Location = New System.Drawing.Point(11, 21)
        Me.dataView.Name = "dataView"
        Me.dataView.Size = New System.Drawing.Size(788, 395)
        Me.dataView.TabIndex = 0
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(810, 86)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'chkDistrital
        '
        Me.chkDistrital.AutoSize = True
        Me.chkDistrital.Checked = True
        Me.chkDistrital.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDistrital.Location = New System.Drawing.Point(395, 45)
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
        Me.cboDistrito.Location = New System.Drawing.Point(563, 15)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(236, 24)
        Me.cboDistrito.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(508, 18)
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
        Me.cboUS.Location = New System.Drawing.Point(151, 45)
        Me.cboUS.Name = "cboUS"
        Me.cboUS.Size = New System.Drawing.Size(238, 24)
        Me.cboUS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unidade Sanitaria"
        '
        'frmMaisDeUmAnoSemVisita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 614)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimizeBox = False
        Me.Name = "frmMaisDeUmAnoSemVisita"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pacientes com mais de um ano sem visita a unidade sanitaria"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
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
    Friend WithEvents chkDistrital As System.Windows.Forms.CheckBox
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
