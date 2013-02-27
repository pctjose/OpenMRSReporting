<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnularConsulta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnularConsulta))
        Me.cboConsulta = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dataConsulta = New System.Windows.Forms.DateTimePicker
        Me.txtMotivo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdAnular = New System.Windows.Forms.Button
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboConsulta
        '
        Me.cboConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsulta.FormattingEnabled = True
        Me.cboConsulta.Items.AddRange(New Object() {"5-ADULTO A", "1-ADULTO B", "6-ADULTO SEGUIMENTO", "7-PEDIATRIA A", "3-PEDIATRIA B", "9-PEDIATRIA SEGUIMENTO", "13-LABORATORIO", "17-SOLICITACAO ARV", "18-FRIDA", "19-ACONSELHAMENTO", "14-ACONSELHAMENTO SEGUIMENTO", "20-RASTRIO TB", "21-BUSCA ACTIVA"})
        Me.cboConsulta.Location = New System.Drawing.Point(121, 43)
        Me.cboConsulta.Name = "cboConsulta"
        Me.cboConsulta.Size = New System.Drawing.Size(243, 24)
        Me.cboConsulta.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdFechar)
        Me.GroupBox1.Controls.Add(Me.cmdAnular)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtMotivo)
        Me.GroupBox1.Controls.Add(Me.dataConsulta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboConsulta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 188)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Consulta:"
        '
        'txtNID
        '
        Me.txtNID.Location = New System.Drawing.Point(121, 15)
        Me.txtNID.Name = "txtNID"
        Me.txtNID.Size = New System.Drawing.Size(243, 22)
        Me.txtNID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(82, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "NID:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Data:"
        '
        'dataConsulta
        '
        Me.dataConsulta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataConsulta.Location = New System.Drawing.Point(121, 73)
        Me.dataConsulta.Name = "dataConsulta"
        Me.dataConsulta.Size = New System.Drawing.Size(104, 22)
        Me.dataConsulta.TabIndex = 5
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(121, 101)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(241, 22)
        Me.txtMotivo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(66, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Motivo:"
        '
        'cmdAnular
        '
        Me.cmdAnular.Location = New System.Drawing.Point(121, 129)
        Me.cmdAnular.Name = "cmdAnular"
        Me.cmdAnular.Size = New System.Drawing.Size(89, 37)
        Me.cmdAnular.TabIndex = 8
        Me.cmdAnular.Text = "&Anular"
        Me.cmdAnular.UseVisualStyleBackColor = True
        '
        'cmdFechar
        '
        Me.cmdFechar.Location = New System.Drawing.Point(226, 129)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(79, 36)
        Me.cmdFechar.TabIndex = 9
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = True
        '
        'frmAnularConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 212)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmAnularConsulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anular Consulta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboConsulta As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNID As System.Windows.Forms.TextBox
    Friend WithEvents dataConsulta As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdAnular As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
End Class
