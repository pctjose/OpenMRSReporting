<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadioHIV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadioHIV))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.rdUltimoEstado = New System.Windows.Forms.RadioButton
        Me.rdDetalhado = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkEstadioIV = New System.Windows.Forms.CheckBox
        Me.chkEstadioIII = New System.Windows.Forms.CheckBox
        Me.chkEstadioII = New System.Windows.Forms.CheckBox
        Me.chkEstadioI = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdAmbos = New System.Windows.Forms.RadioButton
        Me.rdCrianca = New System.Windows.Forms.RadioButton
        Me.rdAdulto = New System.Windows.Forms.RadioButton
        Me.lblA = New System.Windows.Forms.Label
        Me.dataFinal = New System.Windows.Forms.DateTimePicker
        Me.dataInicial = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.rdPrimeiro = New System.Windows.Forms.RadioButton
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.lblA)
        Me.GroupBox1.Controls.Add(Me.dataFinal)
        Me.GroupBox1.Controls.Add(Me.dataInicial)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboDistrito)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboProvincia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboUS)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(486, 305)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdPrimeiro)
        Me.GroupBox5.Controls.Add(Me.rdUltimoEstado)
        Me.GroupBox5.Controls.Add(Me.rdDetalhado)
        Me.GroupBox5.Location = New System.Drawing.Point(11, 250)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(349, 39)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        '
        'rdUltimoEstado
        '
        Me.rdUltimoEstado.AutoSize = True
        Me.rdUltimoEstado.Checked = True
        Me.rdUltimoEstado.Location = New System.Drawing.Point(132, 13)
        Me.rdUltimoEstado.Name = "rdUltimoEstado"
        Me.rdUltimoEstado.Size = New System.Drawing.Size(108, 20)
        Me.rdUltimoEstado.TabIndex = 1
        Me.rdUltimoEstado.TabStop = True
        Me.rdUltimoEstado.Text = "Ultimo Estado"
        Me.rdUltimoEstado.UseVisualStyleBackColor = True
        '
        'rdDetalhado
        '
        Me.rdDetalhado.AutoSize = True
        Me.rdDetalhado.Location = New System.Drawing.Point(246, 13)
        Me.rdDetalhado.Name = "rdDetalhado"
        Me.rdDetalhado.Size = New System.Drawing.Size(84, 20)
        Me.rdDetalhado.TabIndex = 0
        Me.rdDetalhado.Text = "Detalhado"
        Me.rdDetalhado.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkEstadioIV)
        Me.GroupBox4.Controls.Add(Me.chkEstadioIII)
        Me.GroupBox4.Controls.Add(Me.chkEstadioII)
        Me.GroupBox4.Controls.Add(Me.chkEstadioI)
        Me.GroupBox4.Location = New System.Drawing.Point(132, 148)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(228, 96)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        '
        'chkEstadioIV
        '
        Me.chkEstadioIV.AutoSize = True
        Me.chkEstadioIV.Location = New System.Drawing.Point(123, 55)
        Me.chkEstadioIV.Name = "chkEstadioIV"
        Me.chkEstadioIV.Size = New System.Drawing.Size(99, 20)
        Me.chkEstadioIV.TabIndex = 3
        Me.chkEstadioIV.Text = "ESTADIO IV"
        Me.chkEstadioIV.UseVisualStyleBackColor = True
        '
        'chkEstadioIII
        '
        Me.chkEstadioIII.AutoSize = True
        Me.chkEstadioIII.Location = New System.Drawing.Point(29, 55)
        Me.chkEstadioIII.Name = "chkEstadioIII"
        Me.chkEstadioIII.Size = New System.Drawing.Size(96, 20)
        Me.chkEstadioIII.TabIndex = 2
        Me.chkEstadioIII.Text = "ESTADIO III"
        Me.chkEstadioIII.UseVisualStyleBackColor = True
        '
        'chkEstadioII
        '
        Me.chkEstadioII.AutoSize = True
        Me.chkEstadioII.Location = New System.Drawing.Point(125, 19)
        Me.chkEstadioII.Name = "chkEstadioII"
        Me.chkEstadioII.Size = New System.Drawing.Size(93, 20)
        Me.chkEstadioII.TabIndex = 1
        Me.chkEstadioII.Text = "ESTADIO II"
        Me.chkEstadioII.UseVisualStyleBackColor = True
        '
        'chkEstadioI
        '
        Me.chkEstadioI.AutoSize = True
        Me.chkEstadioI.Location = New System.Drawing.Point(29, 19)
        Me.chkEstadioI.Name = "chkEstadioI"
        Me.chkEstadioI.Size = New System.Drawing.Size(90, 20)
        Me.chkEstadioI.TabIndex = 0
        Me.chkEstadioI.Text = "ESTADIO I"
        Me.chkEstadioI.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdAmbos)
        Me.GroupBox3.Controls.Add(Me.rdCrianca)
        Me.GroupBox3.Controls.Add(Me.rdAdulto)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 148)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(115, 96)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        '
        'rdAmbos
        '
        Me.rdAmbos.AutoSize = True
        Me.rdAmbos.Location = New System.Drawing.Point(6, 70)
        Me.rdAmbos.Name = "rdAmbos"
        Me.rdAmbos.Size = New System.Drawing.Size(67, 20)
        Me.rdAmbos.TabIndex = 2
        Me.rdAmbos.Text = "Ambos"
        Me.rdAmbos.UseVisualStyleBackColor = True
        '
        'rdCrianca
        '
        Me.rdCrianca.AutoSize = True
        Me.rdCrianca.Location = New System.Drawing.Point(6, 44)
        Me.rdCrianca.Name = "rdCrianca"
        Me.rdCrianca.Size = New System.Drawing.Size(77, 20)
        Me.rdCrianca.TabIndex = 1
        Me.rdCrianca.Text = "Criancas"
        Me.rdCrianca.UseVisualStyleBackColor = True
        '
        'rdAdulto
        '
        Me.rdAdulto.AutoSize = True
        Me.rdAdulto.Checked = True
        Me.rdAdulto.Location = New System.Drawing.Point(6, 18)
        Me.rdAdulto.Name = "rdAdulto"
        Me.rdAdulto.Size = New System.Drawing.Size(70, 20)
        Me.rdAdulto.TabIndex = 0
        Me.rdAdulto.TabStop = True
        Me.rdAdulto.Text = "Adultos"
        Me.rdAdulto.UseVisualStyleBackColor = True
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(231, 113)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(17, 16)
        Me.lblA.TabIndex = 13
        Me.lblA.Text = "A"
        '
        'dataFinal
        '
        Me.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataFinal.Location = New System.Drawing.Point(273, 110)
        Me.dataFinal.Name = "dataFinal"
        Me.dataFinal.Size = New System.Drawing.Size(87, 22)
        Me.dataFinal.TabIndex = 12
        '
        'dataInicial
        '
        Me.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataInicial.Location = New System.Drawing.Point(122, 110)
        Me.dataInicial.Name = "dataInicial"
        Me.dataInicial.Size = New System.Drawing.Size(89, 22)
        Me.dataInicial.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Periodo de"
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
        Me.GroupBox2.Controls.Add(Me.cmdExcel)
        Me.GroupBox2.Controls.Add(Me.cmdFechar)
        Me.GroupBox2.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 323)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(376, 51)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Location = New System.Drawing.Point(241, 14)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(100, 30)
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
        Me.cmdVisualizar.Text = "&Visualizar"
        Me.cmdVisualizar.UseVisualStyleBackColor = False
        '
        'rdPrimeiro
        '
        Me.rdPrimeiro.AutoSize = True
        Me.rdPrimeiro.Location = New System.Drawing.Point(41, 13)
        Me.rdPrimeiro.Name = "rdPrimeiro"
        Me.rdPrimeiro.Size = New System.Drawing.Size(74, 20)
        Me.rdPrimeiro.TabIndex = 2
        Me.rdPrimeiro.TabStop = True
        Me.rdPrimeiro.Text = "Primeiro"
        Me.rdPrimeiro.UseVisualStyleBackColor = True
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(135, 14)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(100, 30)
        Me.cmdExcel.TabIndex = 2
        Me.cmdExcel.Text = "&Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(371, 54)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox1.TabIndex = 17
        Me.CheckBox1.Text = "Incluir 2º Sitio"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmEstadioHIV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 385)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmEstadioHIV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadio HIV"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdCrianca As System.Windows.Forms.RadioButton
    Friend WithEvents rdAdulto As System.Windows.Forms.RadioButton
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEstadioI As System.Windows.Forms.CheckBox
    Friend WithEvents rdAmbos As System.Windows.Forms.RadioButton
    Friend WithEvents chkEstadioIV As System.Windows.Forms.CheckBox
    Friend WithEvents chkEstadioIII As System.Windows.Forms.CheckBox
    Friend WithEvents chkEstadioII As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rdDetalhado As System.Windows.Forms.RadioButton
    Friend WithEvents rdUltimoEstado As System.Windows.Forms.RadioButton
    Friend WithEvents rdPrimeiro As System.Windows.Forms.RadioButton
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
