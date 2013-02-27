<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColheitaCD4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmColheitaCD4))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sexo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Idade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Gravida = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataColheita = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataRecepcao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.uuid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.cmdGravar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkRecebidas = New System.Windows.Forms.CheckBox
        Me.chkNaoRecebidas = New System.Windows.Forms.CheckBox
        Me.dataFinal = New System.Windows.Forms.DateTimePicker
        Me.dataInicial = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 152)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(806, 642)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nome, Me.Sexo, Me.Idade, Me.NID, Me.Gravida, Me.DataColheita, Me.DataRecepcao, Me.uuid})
        Me.DataGridView1.Location = New System.Drawing.Point(13, 23)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(775, 599)
        Me.DataGridView1.TabIndex = 0
        '
        'Nome
        '
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.Width = 200
        '
        'Sexo
        '
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Items.AddRange(New Object() {"F", "M"})
        Me.Sexo.Name = "Sexo"
        Me.Sexo.Width = 50
        '
        'Idade
        '
        Me.Idade.HeaderText = "Idade"
        Me.Idade.Name = "Idade"
        Me.Idade.Width = 50
        '
        'NID
        '
        Me.NID.HeaderText = "NID"
        Me.NID.Name = "NID"
        Me.NID.Width = 150
        '
        'Gravida
        '
        Me.Gravida.HeaderText = "Gravida"
        Me.Gravida.Name = "Gravida"
        Me.Gravida.Width = 60
        '
        'DataColheita
        '
        Me.DataColheita.HeaderText = "Data Colheita"
        Me.DataColheita.Name = "DataColheita"
        Me.DataColheita.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataColheita.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataRecepcao
        '
        Me.DataRecepcao.HeaderText = "Data Recepção"
        Me.DataRecepcao.Name = "DataRecepcao"
        Me.DataRecepcao.Width = 120
        '
        'uuid
        '
        Me.uuid.HeaderText = "UUID"
        Me.uuid.Name = "uuid"
        Me.uuid.ReadOnly = True
        Me.uuid.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdFechar)
        Me.GroupBox2.Controls.Add(Me.cmdExcel)
        Me.GroupBox2.Controls.Add(Me.cmdGravar)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 802)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(806, 77)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'cmdFechar
        '
        Me.cmdFechar.Location = New System.Drawing.Point(451, 22)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(100, 40)
        Me.cmdFechar.TabIndex = 2
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = True
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(345, 22)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(100, 40)
        Me.cmdExcel.TabIndex = 1
        Me.cmdExcel.Text = "&Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'cmdGravar
        '
        Me.cmdGravar.Location = New System.Drawing.Point(239, 22)
        Me.cmdGravar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdGravar.Name = "cmdGravar"
        Me.cmdGravar.Size = New System.Drawing.Size(100, 40)
        Me.cmdGravar.TabIndex = 0
        Me.cmdGravar.Text = "&Gravar"
        Me.cmdGravar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboDistrito)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cboProvincia)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cboUS)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(519, 129)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'cboDistrito
        '
        Me.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrito.FormattingEnabled = True
        Me.cboDistrito.Location = New System.Drawing.Point(126, 57)
        Me.cboDistrito.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(380, 24)
        Me.cboDistrito.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Distrito"
        '
        'cboProvincia
        '
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(126, 23)
        Me.cboProvincia.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(380, 24)
        Me.cboProvincia.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Provincia"
        '
        'cboUS
        '
        Me.cboUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUS.FormattingEnabled = True
        Me.cboUS.Location = New System.Drawing.Point(126, 91)
        Me.cboUS.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cboUS.Name = "cboUS"
        Me.cboUS.Size = New System.Drawing.Size(380, 24)
        Me.cboUS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unidade Sanitaria"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkRecebidas)
        Me.GroupBox4.Controls.Add(Me.chkNaoRecebidas)
        Me.GroupBox4.Controls.Add(Me.dataFinal)
        Me.GroupBox4.Controls.Add(Me.dataInicial)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(539, 14)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(281, 129)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filtragem Colheita"
        '
        'chkRecebidas
        '
        Me.chkRecebidas.AutoSize = True
        Me.chkRecebidas.Location = New System.Drawing.Point(19, 93)
        Me.chkRecebidas.Name = "chkRecebidas"
        Me.chkRecebidas.Size = New System.Drawing.Size(88, 20)
        Me.chkRecebidas.TabIndex = 5
        Me.chkRecebidas.Text = "Recebidas"
        Me.chkRecebidas.UseVisualStyleBackColor = True
        '
        'chkNaoRecebidas
        '
        Me.chkNaoRecebidas.AutoSize = True
        Me.chkNaoRecebidas.Location = New System.Drawing.Point(153, 93)
        Me.chkNaoRecebidas.Name = "chkNaoRecebidas"
        Me.chkNaoRecebidas.Size = New System.Drawing.Size(115, 20)
        Me.chkNaoRecebidas.TabIndex = 4
        Me.chkNaoRecebidas.Text = "Não Recebidas"
        Me.chkNaoRecebidas.UseVisualStyleBackColor = True
        '
        'dataFinal
        '
        Me.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataFinal.Location = New System.Drawing.Point(153, 55)
        Me.dataFinal.Name = "dataFinal"
        Me.dataFinal.Size = New System.Drawing.Size(102, 22)
        Me.dataFinal.TabIndex = 3
        '
        'dataInicial
        '
        Me.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataInicial.Location = New System.Drawing.Point(153, 21)
        Me.dataInicial.Name = "dataInicial"
        Me.dataInicial.Size = New System.Drawing.Size(102, 22)
        Me.dataInicial.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Data Final"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Data Inicial"
        '
        'frmColheitaCD4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 898)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmColheitaCD4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registo de Colheita de CD4"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGravar As System.Windows.Forms.Button
    Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sexo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Idade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gravida As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataColheita As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataRecepcao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uuid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkNaoRecebidas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents chkRecebidas As System.Windows.Forms.CheckBox
End Class
