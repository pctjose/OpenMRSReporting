<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreferidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreferidos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dataMaisUm = New System.Windows.Forms.DataGridView
        Me.dataSem = New System.Windows.Forms.DataGridView
        Me.cmdSen = New System.Windows.Forms.Button
        Me.cmdMais = New System.Windows.Forms.Button
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dataMaisUm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataSem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdMais)
        Me.GroupBox1.Controls.Add(Me.dataMaisUm)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(464, 502)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mais de Um Preferido"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSen)
        Me.GroupBox2.Controls.Add(Me.dataSem)
        Me.GroupBox2.Location = New System.Drawing.Point(482, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(463, 502)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sem Preferido"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdFechar)
        Me.GroupBox3.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 520)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(933, 59)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'dataMaisUm
        '
        Me.dataMaisUm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataMaisUm.Location = New System.Drawing.Point(6, 21)
        Me.dataMaisUm.Name = "dataMaisUm"
        Me.dataMaisUm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataMaisUm.Size = New System.Drawing.Size(452, 433)
        Me.dataMaisUm.TabIndex = 0
        '
        'dataSem
        '
        Me.dataSem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataSem.Location = New System.Drawing.Point(6, 21)
        Me.dataSem.Name = "dataSem"
        Me.dataSem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataSem.Size = New System.Drawing.Size(451, 433)
        Me.dataSem.TabIndex = 0
        '
        'cmdSen
        '
        Me.cmdSen.Location = New System.Drawing.Point(153, 458)
        Me.cmdSen.Name = "cmdSen"
        Me.cmdSen.Size = New System.Drawing.Size(152, 38)
        Me.cmdSen.TabIndex = 1
        Me.cmdSen.Text = "Excel"
        Me.cmdSen.UseVisualStyleBackColor = True
        '
        'cmdMais
        '
        Me.cmdMais.Location = New System.Drawing.Point(157, 457)
        Me.cmdMais.Name = "cmdMais"
        Me.cmdMais.Size = New System.Drawing.Size(152, 38)
        Me.cmdMais.TabIndex = 1
        Me.cmdMais.Text = "Excel"
        Me.cmdMais.UseVisualStyleBackColor = True
        '
        'cmdVisualizar
        '
        Me.cmdVisualizar.Location = New System.Drawing.Point(306, 15)
        Me.cmdVisualizar.Name = "cmdVisualizar"
        Me.cmdVisualizar.Size = New System.Drawing.Size(152, 38)
        Me.cmdVisualizar.TabIndex = 0
        Me.cmdVisualizar.Text = "Visualizar"
        Me.cmdVisualizar.UseVisualStyleBackColor = True
        '
        'cmdFechar
        '
        Me.cmdFechar.Location = New System.Drawing.Point(464, 15)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(152, 38)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = True
        '
        'frmPreferidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 593)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmPreferidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preferidos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dataMaisUm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataSem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMais As System.Windows.Forms.Button
    Friend WithEvents dataMaisUm As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSen As System.Windows.Forms.Button
    Friend WithEvents dataSem As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
End Class
