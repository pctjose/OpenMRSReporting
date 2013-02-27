<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColheitaPCR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmColheitaPCR))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.dataColheita = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numOrdem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numeroFEA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nidCrianca = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nomeApelido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sexo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.idadeMeses = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colheita = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.dataEnvio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataChegada = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.resultado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.dataEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.resultadoPerdido = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.uuid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdRegistar = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkNaoEnviadas = New System.Windows.Forms.CheckBox
        Me.dataFinal = New System.Windows.Forms.DateTimePicker
        Me.dataInicial = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkEnviadas = New System.Windows.Forms.CheckBox
        Me.chkRecebidas = New System.Windows.Forms.CheckBox
        Me.chkNaoRecebidas = New System.Windows.Forms.CheckBox
        Me.chkEntregue = New System.Windows.Forms.CheckBox
        Me.chkNaoEntregue = New System.Windows.Forms.CheckBox
        Me.chkPerdido = New System.Windows.Forms.CheckBox
        Me.cmdFiltrar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 152)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1267, 600)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dataColheita, Me.numOrdem, Me.numeroFEA, Me.nidCrianca, Me.nomeApelido, Me.sexo, Me.idadeMeses, Me.colheita, Me.dataEnvio, Me.dataChegada, Me.resultado, Me.dataEntrega, Me.resultadoPerdido, Me.uuid})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 23)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1234, 548)
        Me.DataGridView1.TabIndex = 0
        '
        'dataColheita
        '
        Me.dataColheita.HeaderText = "Data Colheita"
        Me.dataColheita.Name = "dataColheita"
        Me.dataColheita.Width = 111
        '
        'numOrdem
        '
        Me.numOrdem.HeaderText = "Ordem"
        Me.numOrdem.Name = "numOrdem"
        Me.numOrdem.Width = 50
        '
        'numeroFEA
        '
        Me.numeroFEA.HeaderText = "Numero FEA"
        Me.numeroFEA.Name = "numeroFEA"
        Me.numeroFEA.Width = 120
        '
        'nidCrianca
        '
        Me.nidCrianca.HeaderText = "NID Criança"
        Me.nidCrianca.Name = "nidCrianca"
        Me.nidCrianca.Width = 120
        '
        'nomeApelido
        '
        Me.nomeApelido.HeaderText = "Nome e Apelido"
        Me.nomeApelido.Name = "nomeApelido"
        Me.nomeApelido.Width = 150
        '
        'sexo
        '
        Me.sexo.HeaderText = "Sexo"
        Me.sexo.Items.AddRange(New Object() {"F", "M"})
        Me.sexo.Name = "sexo"
        Me.sexo.Width = 50
        '
        'idadeMeses
        '
        Me.idadeMeses.HeaderText = "Idade"
        Me.idadeMeses.Name = "idadeMeses"
        Me.idadeMeses.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.idadeMeses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idadeMeses.Width = 60
        '
        'colheita
        '
        Me.colheita.HeaderText = "Colheita"
        Me.colheita.Items.AddRange(New Object() {"Primeira", "Seguinte"})
        Me.colheita.Name = "colheita"
        Me.colheita.Width = 80
        '
        'dataEnvio
        '
        Me.dataEnvio.HeaderText = "Data Envio"
        Me.dataEnvio.Name = "dataEnvio"
        '
        'dataChegada
        '
        Me.dataChegada.HeaderText = "Data Chegada"
        Me.dataChegada.Name = "dataChegada"
        Me.dataChegada.Width = 115
        '
        'resultado
        '
        Me.resultado.HeaderText = "Resultado"
        Me.resultado.Items.AddRange(New Object() {"Negativo", "Positivo", "Indeterminado"})
        Me.resultado.Name = "resultado"
        Me.resultado.Width = 80
        '
        'dataEntrega
        '
        Me.dataEntrega.HeaderText = "Data Entrega"
        Me.dataEntrega.Name = "dataEntrega"
        Me.dataEntrega.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataEntrega.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'resultadoPerdido
        '
        Me.resultadoPerdido.HeaderText = "Perdido"
        Me.resultadoPerdido.Name = "resultadoPerdido"
        Me.resultadoPerdido.Width = 60
        '
        'uuid
        '
        Me.uuid.HeaderText = "UUID"
        Me.uuid.Name = "uuid"
        Me.uuid.ReadOnly = True
        Me.uuid.Visible = False
        '
        'cmdRegistar
        '
        Me.cmdRegistar.Location = New System.Drawing.Point(463, 18)
        Me.cmdRegistar.Name = "cmdRegistar"
        Me.cmdRegistar.Size = New System.Drawing.Size(106, 40)
        Me.cmdRegistar.TabIndex = 1
        Me.cmdRegistar.Text = "&Salvar"
        Me.cmdRegistar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dataFinal)
        Me.GroupBox4.Controls.Add(Me.dataInicial)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(537, 14)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(214, 129)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filtragem Colheita"
        '
        'chkNaoEnviadas
        '
        Me.chkNaoEnviadas.AutoSize = True
        Me.chkNaoEnviadas.Location = New System.Drawing.Point(16, 59)
        Me.chkNaoEnviadas.Name = "chkNaoEnviadas"
        Me.chkNaoEnviadas.Size = New System.Drawing.Size(106, 20)
        Me.chkNaoEnviadas.TabIndex = 4
        Me.chkNaoEnviadas.Text = "Não Enviadas"
        Me.chkNaoEnviadas.UseVisualStyleBackColor = True
        '
        'dataFinal
        '
        Me.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataFinal.Location = New System.Drawing.Point(98, 55)
        Me.dataFinal.Name = "dataFinal"
        Me.dataFinal.Size = New System.Drawing.Size(102, 22)
        Me.dataFinal.TabIndex = 3
        '
        'dataInicial
        '
        Me.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataInicial.Location = New System.Drawing.Point(98, 26)
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
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Data Inicial "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboDistrito)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cboProvincia)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cboUS)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(519, 129)
        Me.GroupBox3.TabIndex = 5
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdFechar)
        Me.GroupBox2.Controls.Add(Me.cmdExcel)
        Me.GroupBox2.Controls.Add(Me.cmdRegistar)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 761)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1267, 67)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(575, 18)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(106, 40)
        Me.cmdExcel.TabIndex = 2
        Me.cmdExcel.Text = "&Exportar Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'cmdFechar
        '
        Me.cmdFechar.Location = New System.Drawing.Point(687, 18)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(106, 40)
        Me.cmdFechar.TabIndex = 3
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdFiltrar)
        Me.GroupBox5.Controls.Add(Me.chkPerdido)
        Me.GroupBox5.Controls.Add(Me.chkNaoEntregue)
        Me.GroupBox5.Controls.Add(Me.chkEntregue)
        Me.GroupBox5.Controls.Add(Me.chkNaoRecebidas)
        Me.GroupBox5.Controls.Add(Me.chkRecebidas)
        Me.GroupBox5.Controls.Add(Me.chkEnviadas)
        Me.GroupBox5.Controls.Add(Me.chkNaoEnviadas)
        Me.GroupBox5.Location = New System.Drawing.Point(772, 14)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(507, 129)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Outras Filtragens"
        '
        'chkEnviadas
        '
        Me.chkEnviadas.AutoSize = True
        Me.chkEnviadas.Location = New System.Drawing.Point(16, 30)
        Me.chkEnviadas.Name = "chkEnviadas"
        Me.chkEnviadas.Size = New System.Drawing.Size(79, 20)
        Me.chkEnviadas.TabIndex = 5
        Me.chkEnviadas.Text = "Enviadas"
        Me.chkEnviadas.UseVisualStyleBackColor = True
        '
        'chkRecebidas
        '
        Me.chkRecebidas.AutoSize = True
        Me.chkRecebidas.Location = New System.Drawing.Point(128, 30)
        Me.chkRecebidas.Name = "chkRecebidas"
        Me.chkRecebidas.Size = New System.Drawing.Size(88, 20)
        Me.chkRecebidas.TabIndex = 6
        Me.chkRecebidas.Text = "Recebidas"
        Me.chkRecebidas.UseVisualStyleBackColor = True
        '
        'chkNaoRecebidas
        '
        Me.chkNaoRecebidas.AutoSize = True
        Me.chkNaoRecebidas.Location = New System.Drawing.Point(128, 59)
        Me.chkNaoRecebidas.Name = "chkNaoRecebidas"
        Me.chkNaoRecebidas.Size = New System.Drawing.Size(115, 20)
        Me.chkNaoRecebidas.TabIndex = 7
        Me.chkNaoRecebidas.Text = "Não Recebidas"
        Me.chkNaoRecebidas.UseVisualStyleBackColor = True
        '
        'chkEntregue
        '
        Me.chkEntregue.AutoSize = True
        Me.chkEntregue.Location = New System.Drawing.Point(253, 30)
        Me.chkEntregue.Name = "chkEntregue"
        Me.chkEntregue.Size = New System.Drawing.Size(79, 20)
        Me.chkEntregue.TabIndex = 8
        Me.chkEntregue.Text = "Entregue"
        Me.chkEntregue.UseVisualStyleBackColor = True
        '
        'chkNaoEntregue
        '
        Me.chkNaoEntregue.AutoSize = True
        Me.chkNaoEntregue.Location = New System.Drawing.Point(253, 59)
        Me.chkNaoEntregue.Name = "chkNaoEntregue"
        Me.chkNaoEntregue.Size = New System.Drawing.Size(106, 20)
        Me.chkNaoEntregue.TabIndex = 9
        Me.chkNaoEntregue.Text = "Não Entregue"
        Me.chkNaoEntregue.UseVisualStyleBackColor = True
        '
        'chkPerdido
        '
        Me.chkPerdido.AutoSize = True
        Me.chkPerdido.Location = New System.Drawing.Point(379, 30)
        Me.chkPerdido.Name = "chkPerdido"
        Me.chkPerdido.Size = New System.Drawing.Size(71, 20)
        Me.chkPerdido.TabIndex = 10
        Me.chkPerdido.Text = "Perdido"
        Me.chkPerdido.UseVisualStyleBackColor = True
        '
        'cmdFiltrar
        '
        Me.cmdFiltrar.Location = New System.Drawing.Point(192, 91)
        Me.cmdFiltrar.Name = "cmdFiltrar"
        Me.cmdFiltrar.Size = New System.Drawing.Size(98, 32)
        Me.cmdFiltrar.TabIndex = 11
        Me.cmdFiltrar.Text = "Filtrar"
        Me.cmdFiltrar.UseVisualStyleBackColor = True
        Me.cmdFiltrar.Visible = False
        '
        'frmColheitaPCR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1294, 848)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmColheitaPCR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registo de Colheita PCR"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dataColheita As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numOrdem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numeroFEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nidCrianca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nomeApelido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sexo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents idadeMeses As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colheita As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dataEnvio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataChegada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents resultado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dataEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents resultadoPerdido As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents uuid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdRegistar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkNaoEnviadas As System.Windows.Forms.CheckBox
    Friend WithEvents dataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEnviadas As System.Windows.Forms.CheckBox
    Friend WithEvents chkNaoEntregue As System.Windows.Forms.CheckBox
    Friend WithEvents chkEntregue As System.Windows.Forms.CheckBox
    Friend WithEvents chkNaoRecebidas As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecebidas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdFiltrar As System.Windows.Forms.Button
    Friend WithEvents chkPerdido As System.Windows.Forms.CheckBox
End Class
