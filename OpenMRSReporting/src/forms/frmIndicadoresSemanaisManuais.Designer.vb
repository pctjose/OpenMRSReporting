<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndicadoresSemanaisManuais
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndicadoresSemanaisManuais))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgIndicadoresManuais = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IndicadorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Actualizar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dsManualIndicator = New System.Data.DataSet
        Me.DataTable1 = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdSalvar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboServico = New System.Windows.Forms.ComboBox
        Me.chkTodos = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgIndicadoresManuais, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsManualIndicator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.dgIndicadoresManuais)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(672, 446)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "INDICADORES SEMANAIS MANUAIS"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkTodos)
        Me.GroupBox3.Controls.Add(Me.cboServico)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cboUS)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 21)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(660, 46)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'cboUS
        '
        Me.cboUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUS.FormattingEnabled = True
        Me.cboUS.Location = New System.Drawing.Point(128, 15)
        Me.cboUS.Name = "cboUS"
        Me.cboUS.Size = New System.Drawing.Size(198, 24)
        Me.cboUS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unidade Sanitaria"
        '
        'dgIndicadoresManuais
        '
        Me.dgIndicadoresManuais.AllowUserToAddRows = False
        Me.dgIndicadoresManuais.AllowUserToDeleteRows = False
        Me.dgIndicadoresManuais.AutoGenerateColumns = False
        Me.dgIndicadoresManuais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgIndicadoresManuais.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.IndicadorDataGridViewTextBoxColumn, Me.ValorDataGridViewTextBoxColumn, Me.Actualizar})
        Me.dgIndicadoresManuais.DataMember = "Indicador"
        Me.dgIndicadoresManuais.DataSource = Me.dsManualIndicator
        Me.dgIndicadoresManuais.Location = New System.Drawing.Point(6, 81)
        Me.dgIndicadoresManuais.Name = "dgIndicadoresManuais"
        Me.dgIndicadoresManuais.Size = New System.Drawing.Size(660, 359)
        Me.dgIndicadoresManuais.TabIndex = 0
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Width = 50
        '
        'IndicadorDataGridViewTextBoxColumn
        '
        Me.IndicadorDataGridViewTextBoxColumn.DataPropertyName = "Indicador"
        Me.IndicadorDataGridViewTextBoxColumn.HeaderText = "Indicador"
        Me.IndicadorDataGridViewTextBoxColumn.Name = "IndicadorDataGridViewTextBoxColumn"
        Me.IndicadorDataGridViewTextBoxColumn.ReadOnly = True
        Me.IndicadorDataGridViewTextBoxColumn.Width = 480
        '
        'ValorDataGridViewTextBoxColumn
        '
        Me.ValorDataGridViewTextBoxColumn.DataPropertyName = "Valor"
        Me.ValorDataGridViewTextBoxColumn.HeaderText = "Valor"
        Me.ValorDataGridViewTextBoxColumn.Name = "ValorDataGridViewTextBoxColumn"
        Me.ValorDataGridViewTextBoxColumn.Width = 70
        '
        'Actualizar
        '
        Me.Actualizar.DataPropertyName = "Actualizar"
        Me.Actualizar.HeaderText = "Actualizar"
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.ReadOnly = True
        Me.Actualizar.Visible = False
        Me.Actualizar.Width = 80
        '
        'dsManualIndicator
        '
        Me.dsManualIndicator.DataSetName = "Indicators"
        Me.dsManualIndicator.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4})
        Me.DataTable1.Constraints.AddRange(New System.Data.Constraint() {New System.Data.UniqueConstraint("Constraint1", New String() {"ID"}, True)})
        Me.DataTable1.PrimaryKey = New System.Data.DataColumn() {Me.DataColumn1}
        Me.DataTable1.TableName = "Indicador"
        '
        'DataColumn1
        '
        Me.DataColumn1.AllowDBNull = False
        Me.DataColumn1.ColumnName = "ID"
        Me.DataColumn1.DataType = GetType(Short)
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "Indicador"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "Valor"
        '
        'DataColumn4
        '
        Me.DataColumn4.Caption = "Actualizar"
        Me.DataColumn4.ColumnName = "Actualizar"
        Me.DataColumn4.DataType = GetType(Boolean)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdFechar)
        Me.GroupBox1.Controls.Add(Me.cmdSalvar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 464)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(672, 60)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Location = New System.Drawing.Point(348, 13)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(100, 35)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'cmdSalvar
        '
        Me.cmdSalvar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSalvar.Location = New System.Drawing.Point(221, 13)
        Me.cmdSalvar.Name = "cmdSalvar"
        Me.cmdSalvar.Size = New System.Drawing.Size(121, 35)
        Me.cmdSalvar.TabIndex = 0
        Me.cmdSalvar.Text = "&Salvar"
        Me.cmdSalvar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(339, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Serviço"
        '
        'cboServico
        '
        Me.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServico.FormattingEnabled = True
        Me.cboServico.Location = New System.Drawing.Point(395, 15)
        Me.cboServico.Name = "cboServico"
        Me.cboServico.Size = New System.Drawing.Size(186, 24)
        Me.cboServico.TabIndex = 3
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(592, 17)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(62, 20)
        Me.chkTodos.TabIndex = 4
        Me.chkTodos.Text = "Todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'frmIndicadoresSemanaisManuais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 536)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmIndicadoresSemanaisManuais"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicadores Semanais Manuais"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgIndicadoresManuais, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsManualIndicator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dsManualIndicator As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents dgIndicadoresManuais As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdSalvar As System.Windows.Forms.Button
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IndicadorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Actualizar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboServico As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
End Class
