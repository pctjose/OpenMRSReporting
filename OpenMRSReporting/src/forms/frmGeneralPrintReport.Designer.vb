<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneralPrintReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneralPrintReport))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdAnual = New System.Windows.Forms.RadioButton
        Me.rdSemestral = New System.Windows.Forms.RadioButton
        Me.rdTrimestral = New System.Windows.Forms.RadioButton
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblPeriodo = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdManuais = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblInfo = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.cboPeriodo = New System.Windows.Forms.ComboBox
        Me.txtAno = New System.Windows.Forms.TextBox
        Me.lblAno = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAno)
        Me.GroupBox1.Controls.Add(Me.txtAno)
        Me.GroupBox1.Controls.Add(Me.cboPeriodo)
        Me.GroupBox1.Controls.Add(Me.rdAnual)
        Me.GroupBox1.Controls.Add(Me.rdSemestral)
        Me.GroupBox1.Controls.Add(Me.rdTrimestral)
        Me.GroupBox1.Controls.Add(Me.cboDistrito)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboProvincia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblPeriodo)
        Me.GroupBox1.Controls.Add(Me.cboUS)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 171)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'rdAnual
        '
        Me.rdAnual.AutoSize = True
        Me.rdAnual.Location = New System.Drawing.Point(302, 110)
        Me.rdAnual.Name = "rdAnual"
        Me.rdAnual.Size = New System.Drawing.Size(59, 20)
        Me.rdAnual.TabIndex = 14
        Me.rdAnual.Text = "Anual"
        Me.rdAnual.UseVisualStyleBackColor = True
        '
        'rdSemestral
        '
        Me.rdSemestral.AutoSize = True
        Me.rdSemestral.Location = New System.Drawing.Point(211, 110)
        Me.rdSemestral.Name = "rdSemestral"
        Me.rdSemestral.Size = New System.Drawing.Size(85, 20)
        Me.rdSemestral.TabIndex = 13
        Me.rdSemestral.Text = "Semestral"
        Me.rdSemestral.UseVisualStyleBackColor = True
        '
        'rdTrimestral
        '
        Me.rdTrimestral.AutoSize = True
        Me.rdTrimestral.Checked = True
        Me.rdTrimestral.Location = New System.Drawing.Point(122, 110)
        Me.rdTrimestral.Name = "rdTrimestral"
        Me.rdTrimestral.Size = New System.Drawing.Size(83, 20)
        Me.rdTrimestral.TabIndex = 12
        Me.rdTrimestral.TabStop = True
        Me.rdTrimestral.Text = "Trimestral"
        Me.rdTrimestral.UseVisualStyleBackColor = True
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
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(8, 139)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(62, 16)
        Me.lblPeriodo.TabIndex = 3
        Me.lblPeriodo.Text = "Trimestre"
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdManuais)
        Me.GroupBox2.Controls.Add(Me.cmdFechar)
        Me.GroupBox2.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 240)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(376, 51)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'cmdManuais
        '
        Me.cmdManuais.BackColor = System.Drawing.SystemColors.Control
        Me.cmdManuais.Enabled = False
        Me.cmdManuais.Location = New System.Drawing.Point(135, 14)
        Me.cmdManuais.Name = "cmdManuais"
        Me.cmdManuais.Size = New System.Drawing.Size(100, 30)
        Me.cmdManuais.TabIndex = 2
        Me.cmdManuais.Text = "&Manuais"
        Me.cmdManuais.UseVisualStyleBackColor = False
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Location = New System.Drawing.Point(285, 14)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(75, 30)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'cmdVisualizar
        '
        Me.cmdVisualizar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVisualizar.Location = New System.Drawing.Point(29, 14)
        Me.cmdVisualizar.Name = "cmdVisualizar"
        Me.cmdVisualizar.Size = New System.Drawing.Size(100, 30)
        Me.cmdVisualizar.TabIndex = 0
        Me.cmdVisualizar.Text = "&Automaticos"
        Me.cmdVisualizar.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 189)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(376, 45)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(42, 16)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(289, 20)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Visualizar Comparando Com Periodo Anterior"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblInfo, Me.ProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 307)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(404, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = False
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(230, 17)
        '
        'ProgressBar
        '
        Me.ProgressBar.AutoSize = False
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(150, 16)
        '
        'cboPeriodo
        '
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.FormattingEnabled = True
        Me.cboPeriodo.Location = New System.Drawing.Point(122, 136)
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(114, 24)
        Me.cboPeriodo.TabIndex = 16
        '
        'txtAno
        '
        Me.txtAno.Location = New System.Drawing.Point(295, 136)
        Me.txtAno.MaxLength = 4
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(65, 22)
        Me.txtAno.TabIndex = 17
        '
        'lblAno
        '
        Me.lblAno.AutoSize = True
        Me.lblAno.Location = New System.Drawing.Point(258, 139)
        Me.lblAno.Name = "lblAno"
        Me.lblAno.Size = New System.Drawing.Size(31, 16)
        Me.lblAno.TabIndex = 18
        Me.lblAno.Text = "Ano"
        '
        'frmGeneralPrintReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 329)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmGeneralPrintReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicadores PEPFAR"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents rdAnual As System.Windows.Forms.RadioButton
    Friend WithEvents rdSemestral As System.Windows.Forms.RadioButton
    Friend WithEvents rdTrimestral As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdManuais As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents cboPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents lblAno As System.Windows.Forms.Label
End Class
