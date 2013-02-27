<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferencia))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtNIDInicio = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNID = New System.Windows.Forms.TextBox
        Me.lblNID = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdVisualizar = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtNIDInicio)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.txtNID)
        Me.GroupBox4.Controls.Add(Me.lblNID)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(255, 48)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        '
        'txtNIDInicio
        '
        Me.txtNIDInicio.Location = New System.Drawing.Point(41, 15)
        Me.txtNIDInicio.MaxLength = 8
        Me.txtNIDInicio.Name = "txtNIDInicio"
        Me.txtNIDInicio.Size = New System.Drawing.Size(71, 22)
        Me.txtNIDInicio.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(179, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "00/0000"
        '
        'txtNID
        '
        Me.txtNID.Location = New System.Drawing.Point(118, 15)
        Me.txtNID.MaxLength = 8
        Me.txtNID.Name = "txtNID"
        Me.txtNID.Size = New System.Drawing.Size(55, 22)
        Me.txtNID.TabIndex = 1
        '
        'lblNID
        '
        Me.lblNID.AutoSize = True
        Me.lblNID.Location = New System.Drawing.Point(6, 18)
        Me.lblNID.Name = "lblNID"
        Me.lblNID.Size = New System.Drawing.Size(29, 16)
        Me.lblNID.TabIndex = 0
        Me.lblNID.Text = "NID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdFechar)
        Me.GroupBox1.Controls.Add(Me.cmdVisualizar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(255, 59)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'cmdVisualizar
        '
        Me.cmdVisualizar.Location = New System.Drawing.Point(19, 18)
        Me.cmdVisualizar.Name = "cmdVisualizar"
        Me.cmdVisualizar.Size = New System.Drawing.Size(104, 30)
        Me.cmdVisualizar.TabIndex = 0
        Me.cmdVisualizar.Text = "&Visualizar"
        Me.cmdVisualizar.UseVisualStyleBackColor = True
        '
        'cmdFechar
        '
        Me.cmdFechar.Location = New System.Drawing.Point(129, 18)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(104, 30)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = True
        '
        'frmTransferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 139)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmTransferencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferencia"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNIDInicio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNID As System.Windows.Forms.TextBox
    Friend WithEvents lblNID As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdVisualizar As System.Windows.Forms.Button
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
End Class
