<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSESP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSESP))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblNumero = New System.Windows.Forms.Label
        Me.dataView = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdFechar = New System.Windows.Forms.Button
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.FaixaEtaria = New System.Windows.Forms.GroupBox
        Me.rdAdulto = New System.Windows.Forms.RadioButton
        Me.rdCrianca = New System.Windows.Forms.RadioButton
        Me.rdFaixaTodos = New System.Windows.Forms.RadioButton
        Me.Sexo = New System.Windows.Forms.GroupBox
        Me.rdM = New System.Windows.Forms.RadioButton
        Me.rdF = New System.Windows.Forms.RadioButton
        Me.rdSexoTodos = New System.Windows.Forms.RadioButton
        Me.chkDistrital = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdVisualizarSaida = New System.Windows.Forms.Button
        Me.rdSuspensos = New System.Windows.Forms.RadioButton
        Me.rdObitos = New System.Windows.Forms.RadioButton
        Me.rdTransferidosPara = New System.Windows.Forms.RadioButton
        Me.rdTodasSaidas = New System.Windows.Forms.RadioButton
        Me.rdAbandonoNotificado = New System.Windows.Forms.RadioButton
        Me.lblPeriodo = New System.Windows.Forms.Label
        Me.tarv = New System.Windows.Forms.GroupBox
        Me.rdTransferidosDe = New System.Windows.Forms.RadioButton
        Me.rdReinicio = New System.Windows.Forms.RadioButton
        Me.cmdVisualizarTARV = New System.Windows.Forms.Button
        Me.rdInicioTARV = New System.Windows.Forms.RadioButton
        Me.rdTarv = New System.Windows.Forms.RadioButton
        Me.rdFaltoso = New System.Windows.Forms.RadioButton
        Me.rdAbandono = New System.Windows.Forms.RadioButton
        Me.dataFinal = New System.Windows.Forms.DateTimePicker
        Me.lblA = New System.Windows.Forms.Label
        Me.dataInicial = New System.Windows.Forms.DateTimePicker
        Me.cboDistrito = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboProvincia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboUS = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox5.SuspendLayout()
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.FaixaEtaria.SuspendLayout()
        Me.Sexo.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tarv.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblNumero)
        Me.GroupBox5.Controls.Add(Me.dataView)
        Me.GroupBox5.Location = New System.Drawing.Point(14, 444)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(728, 434)
        Me.GroupBox5.TabIndex = 14
        Me.GroupBox5.TabStop = False
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(57, 402)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(46, 16)
        Me.lblNumero.TabIndex = 1
        Me.lblNumero.Text = "Label6"
        Me.lblNumero.Visible = False
        '
        'dataView
        '
        Me.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataView.Location = New System.Drawing.Point(13, 26)
        Me.dataView.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dataView.Name = "dataView"
        Me.dataView.Size = New System.Drawing.Size(702, 369)
        Me.dataView.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.FaixaEtaria)
        Me.GroupBox1.Controls.Add(Me.Sexo)
        Me.GroupBox1.Controls.Add(Me.chkDistrital)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.lblPeriodo)
        Me.GroupBox1.Controls.Add(Me.tarv)
        Me.GroupBox1.Controls.Add(Me.dataFinal)
        Me.GroupBox1.Controls.Add(Me.lblA)
        Me.GroupBox1.Controls.Add(Me.dataInicial)
        Me.GroupBox1.Controls.Add(Me.cboDistrito)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboProvincia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboUS)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 17)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox1.Size = New System.Drawing.Size(728, 417)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdFechar)
        Me.GroupBox2.Controls.Add(Me.cmdExcel)
        Me.GroupBox2.Location = New System.Drawing.Point(569, 186)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox2.Size = New System.Drawing.Size(146, 210)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'cmdFechar
        '
        Me.cmdFechar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFechar.Location = New System.Drawing.Point(31, 105)
        Me.cmdFechar.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.cmdFechar.Name = "cmdFechar"
        Me.cmdFechar.Size = New System.Drawing.Size(93, 57)
        Me.cmdFechar.TabIndex = 1
        Me.cmdFechar.Text = "&Fechar"
        Me.cmdFechar.UseVisualStyleBackColor = False
        '
        'cmdExcel
        '
        Me.cmdExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExcel.Location = New System.Drawing.Point(31, 31)
        Me.cmdExcel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(93, 62)
        Me.cmdExcel.TabIndex = 0
        Me.cmdExcel.Text = "&Excel"
        Me.cmdExcel.UseVisualStyleBackColor = False
        '
        'FaixaEtaria
        '
        Me.FaixaEtaria.Controls.Add(Me.rdAdulto)
        Me.FaixaEtaria.Controls.Add(Me.rdCrianca)
        Me.FaixaEtaria.Controls.Add(Me.rdFaixaTodos)
        Me.FaixaEtaria.Location = New System.Drawing.Point(554, 28)
        Me.FaixaEtaria.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FaixaEtaria.Name = "FaixaEtaria"
        Me.FaixaEtaria.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FaixaEtaria.Size = New System.Drawing.Size(113, 122)
        Me.FaixaEtaria.TabIndex = 18
        Me.FaixaEtaria.TabStop = False
        Me.FaixaEtaria.Text = "Faixa Etaria"
        '
        'rdAdulto
        '
        Me.rdAdulto.AutoSize = True
        Me.rdAdulto.Location = New System.Drawing.Point(15, 85)
        Me.rdAdulto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdAdulto.Name = "rdAdulto"
        Me.rdAdulto.Size = New System.Drawing.Size(70, 20)
        Me.rdAdulto.TabIndex = 2
        Me.rdAdulto.TabStop = True
        Me.rdAdulto.Text = "Adultos"
        Me.rdAdulto.UseVisualStyleBackColor = True
        '
        'rdCrianca
        '
        Me.rdCrianca.AutoSize = True
        Me.rdCrianca.Location = New System.Drawing.Point(15, 58)
        Me.rdCrianca.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdCrianca.Name = "rdCrianca"
        Me.rdCrianca.Size = New System.Drawing.Size(77, 20)
        Me.rdCrianca.TabIndex = 1
        Me.rdCrianca.TabStop = True
        Me.rdCrianca.Text = "Crianças"
        Me.rdCrianca.UseVisualStyleBackColor = True
        '
        'rdFaixaTodos
        '
        Me.rdFaixaTodos.AutoSize = True
        Me.rdFaixaTodos.Checked = True
        Me.rdFaixaTodos.Location = New System.Drawing.Point(15, 26)
        Me.rdFaixaTodos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdFaixaTodos.Name = "rdFaixaTodos"
        Me.rdFaixaTodos.Size = New System.Drawing.Size(61, 20)
        Me.rdFaixaTodos.TabIndex = 0
        Me.rdFaixaTodos.TabStop = True
        Me.rdFaixaTodos.Text = "Todos"
        Me.rdFaixaTodos.UseVisualStyleBackColor = True
        '
        'Sexo
        '
        Me.Sexo.Controls.Add(Me.rdM)
        Me.Sexo.Controls.Add(Me.rdF)
        Me.Sexo.Controls.Add(Me.rdSexoTodos)
        Me.Sexo.Location = New System.Drawing.Point(444, 28)
        Me.Sexo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Sexo.Name = "Sexo"
        Me.Sexo.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Sexo.Size = New System.Drawing.Size(103, 122)
        Me.Sexo.TabIndex = 17
        Me.Sexo.TabStop = False
        Me.Sexo.Text = "Sexo"
        '
        'rdM
        '
        Me.rdM.AutoSize = True
        Me.rdM.Location = New System.Drawing.Point(7, 90)
        Me.rdM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdM.Name = "rdM"
        Me.rdM.Size = New System.Drawing.Size(37, 20)
        Me.rdM.TabIndex = 2
        Me.rdM.Text = "M"
        Me.rdM.UseVisualStyleBackColor = True
        '
        'rdF
        '
        Me.rdF.AutoSize = True
        Me.rdF.Location = New System.Drawing.Point(7, 58)
        Me.rdF.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdF.Name = "rdF"
        Me.rdF.Size = New System.Drawing.Size(34, 20)
        Me.rdF.TabIndex = 1
        Me.rdF.Text = "F" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rdF.UseVisualStyleBackColor = True
        '
        'rdSexoTodos
        '
        Me.rdSexoTodos.AutoSize = True
        Me.rdSexoTodos.Checked = True
        Me.rdSexoTodos.Location = New System.Drawing.Point(7, 26)
        Me.rdSexoTodos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdSexoTodos.Name = "rdSexoTodos"
        Me.rdSexoTodos.Size = New System.Drawing.Size(61, 20)
        Me.rdSexoTodos.TabIndex = 0
        Me.rdSexoTodos.TabStop = True
        Me.rdSexoTodos.Text = "Todos"
        Me.rdSexoTodos.UseVisualStyleBackColor = True
        '
        'chkDistrital
        '
        Me.chkDistrital.AutoSize = True
        Me.chkDistrital.Checked = True
        Me.chkDistrital.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDistrital.Location = New System.Drawing.Point(313, 69)
        Me.chkDistrital.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkDistrital.Name = "chkDistrital"
        Me.chkDistrital.Size = New System.Drawing.Size(107, 20)
        Me.chkDistrital.TabIndex = 17
        Me.chkDistrital.Text = "Incluir 2º Sitio"
        Me.chkDistrital.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdVisualizarSaida)
        Me.GroupBox4.Controls.Add(Me.rdSuspensos)
        Me.GroupBox4.Controls.Add(Me.rdObitos)
        Me.GroupBox4.Controls.Add(Me.rdTransferidosPara)
        Me.GroupBox4.Controls.Add(Me.rdTodasSaidas)
        Me.GroupBox4.Controls.Add(Me.rdAbandonoNotificado)
        Me.GroupBox4.Location = New System.Drawing.Point(325, 186)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(237, 210)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SAIDAS"
        '
        'cmdVisualizarSaida
        '
        Me.cmdVisualizarSaida.Location = New System.Drawing.Point(128, 159)
        Me.cmdVisualizarSaida.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdVisualizarSaida.Name = "cmdVisualizarSaida"
        Me.cmdVisualizarSaida.Size = New System.Drawing.Size(93, 37)
        Me.cmdVisualizarSaida.TabIndex = 16
        Me.cmdVisualizarSaida.Text = "Vi&sualizar"
        Me.cmdVisualizarSaida.UseVisualStyleBackColor = True
        '
        'rdSuspensos
        '
        Me.rdSuspensos.AutoSize = True
        Me.rdSuspensos.Location = New System.Drawing.Point(7, 158)
        Me.rdSuspensos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdSuspensos.Name = "rdSuspensos"
        Me.rdSuspensos.Size = New System.Drawing.Size(91, 20)
        Me.rdSuspensos.TabIndex = 15
        Me.rdSuspensos.Text = "Suspensos"
        Me.rdSuspensos.UseVisualStyleBackColor = True
        '
        'rdObitos
        '
        Me.rdObitos.AutoSize = True
        Me.rdObitos.Location = New System.Drawing.Point(8, 126)
        Me.rdObitos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdObitos.Name = "rdObitos"
        Me.rdObitos.Size = New System.Drawing.Size(64, 20)
        Me.rdObitos.TabIndex = 14
        Me.rdObitos.Text = "Obitos"
        Me.rdObitos.UseVisualStyleBackColor = True
        '
        'rdTransferidosPara
        '
        Me.rdTransferidosPara.AutoSize = True
        Me.rdTransferidosPara.Location = New System.Drawing.Point(8, 91)
        Me.rdTransferidosPara.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdTransferidosPara.Name = "rdTransferidosPara"
        Me.rdTransferidosPara.Size = New System.Drawing.Size(127, 20)
        Me.rdTransferidosPara.TabIndex = 13
        Me.rdTransferidosPara.Text = "Transferidos Para"
        Me.rdTransferidosPara.UseVisualStyleBackColor = True
        '
        'rdTodasSaidas
        '
        Me.rdTodasSaidas.AutoSize = True
        Me.rdTodasSaidas.Checked = True
        Me.rdTodasSaidas.Location = New System.Drawing.Point(7, 26)
        Me.rdTodasSaidas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdTodasSaidas.Name = "rdTodasSaidas"
        Me.rdTodasSaidas.Size = New System.Drawing.Size(61, 20)
        Me.rdTodasSaidas.TabIndex = 0
        Me.rdTodasSaidas.TabStop = True
        Me.rdTodasSaidas.Text = "Todas"
        Me.rdTodasSaidas.UseVisualStyleBackColor = True
        '
        'rdAbandonoNotificado
        '
        Me.rdAbandonoNotificado.AutoSize = True
        Me.rdAbandonoNotificado.Location = New System.Drawing.Point(8, 58)
        Me.rdAbandonoNotificado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdAbandonoNotificado.Name = "rdAbandonoNotificado"
        Me.rdAbandonoNotificado.Size = New System.Drawing.Size(91, 20)
        Me.rdAbandonoNotificado.TabIndex = 12
        Me.rdAbandonoNotificado.Text = "Abandonos"
        Me.rdAbandonoNotificado.UseVisualStyleBackColor = True
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(12, 158)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(52, 16)
        Me.lblPeriodo.TabIndex = 16
        Me.lblPeriodo.Text = "Periodo"
        '
        'tarv
        '
        Me.tarv.Controls.Add(Me.rdTransferidosDe)
        Me.tarv.Controls.Add(Me.rdReinicio)
        Me.tarv.Controls.Add(Me.cmdVisualizarTARV)
        Me.tarv.Controls.Add(Me.rdInicioTARV)
        Me.tarv.Controls.Add(Me.rdTarv)
        Me.tarv.Controls.Add(Me.rdFaltoso)
        Me.tarv.Controls.Add(Me.rdAbandono)
        Me.tarv.Location = New System.Drawing.Point(15, 186)
        Me.tarv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tarv.Name = "tarv"
        Me.tarv.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tarv.Size = New System.Drawing.Size(303, 210)
        Me.tarv.TabIndex = 11
        Me.tarv.TabStop = False
        Me.tarv.Text = "TARV"
        '
        'rdTransferidosDe
        '
        Me.rdTransferidosDe.AutoSize = True
        Me.rdTransferidosDe.Location = New System.Drawing.Point(135, 23)
        Me.rdTransferidosDe.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdTransferidosDe.Name = "rdTransferidosDe"
        Me.rdTransferidosDe.Size = New System.Drawing.Size(116, 20)
        Me.rdTransferidosDe.TabIndex = 21
        Me.rdTransferidosDe.TabStop = True
        Me.rdTransferidosDe.Text = "Transferidos De"
        Me.rdTransferidosDe.UseVisualStyleBackColor = True
        '
        'rdReinicio
        '
        Me.rdReinicio.AutoSize = True
        Me.rdReinicio.Location = New System.Drawing.Point(135, 58)
        Me.rdReinicio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdReinicio.Name = "rdReinicio"
        Me.rdReinicio.Size = New System.Drawing.Size(72, 20)
        Me.rdReinicio.TabIndex = 20
        Me.rdReinicio.TabStop = True
        Me.rdReinicio.Text = "Reinicio"
        Me.rdReinicio.UseVisualStyleBackColor = True
        '
        'cmdVisualizarTARV
        '
        Me.cmdVisualizarTARV.Location = New System.Drawing.Point(7, 159)
        Me.cmdVisualizarTARV.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdVisualizarTARV.Name = "cmdVisualizarTARV"
        Me.cmdVisualizarTARV.Size = New System.Drawing.Size(93, 37)
        Me.cmdVisualizarTARV.TabIndex = 19
        Me.cmdVisualizarTARV.Text = "&Visualizar"
        Me.cmdVisualizarTARV.UseVisualStyleBackColor = True
        '
        'rdInicioTARV
        '
        Me.rdInicioTARV.AutoSize = True
        Me.rdInicioTARV.Checked = True
        Me.rdInicioTARV.Location = New System.Drawing.Point(7, 26)
        Me.rdInicioTARV.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdInicioTARV.Name = "rdInicioTARV"
        Me.rdInicioTARV.Size = New System.Drawing.Size(94, 20)
        Me.rdInicioTARV.TabIndex = 18
        Me.rdInicioTARV.TabStop = True
        Me.rdInicioTARV.Text = "Inicio TARV"
        Me.rdInicioTARV.UseVisualStyleBackColor = True
        '
        'rdTarv
        '
        Me.rdTarv.AutoSize = True
        Me.rdTarv.Location = New System.Drawing.Point(7, 58)
        Me.rdTarv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdTarv.Name = "rdTarv"
        Me.rdTarv.Size = New System.Drawing.Size(122, 20)
        Me.rdTarv.TabIndex = 17
        Me.rdTarv.Text = "Pacientes TARV"
        Me.rdTarv.UseVisualStyleBackColor = True
        '
        'rdFaltoso
        '
        Me.rdFaltoso.AutoSize = True
        Me.rdFaltoso.Location = New System.Drawing.Point(7, 87)
        Me.rdFaltoso.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.rdFaltoso.Name = "rdFaltoso"
        Me.rdFaltoso.Size = New System.Drawing.Size(76, 20)
        Me.rdFaltoso.TabIndex = 11
        Me.rdFaltoso.Text = "Faltosos"
        Me.rdFaltoso.UseVisualStyleBackColor = True
        '
        'rdAbandono
        '
        Me.rdAbandono.AutoSize = True
        Me.rdAbandono.Location = New System.Drawing.Point(7, 126)
        Me.rdAbandono.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.rdAbandono.Name = "rdAbandono"
        Me.rdAbandono.Size = New System.Drawing.Size(182, 20)
        Me.rdAbandono.TabIndex = 10
        Me.rdAbandono.Text = "Abandonos nao notificados"
        Me.rdAbandono.UseVisualStyleBackColor = True
        '
        'dataFinal
        '
        Me.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataFinal.Location = New System.Drawing.Point(286, 151)
        Me.dataFinal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dataFinal.Name = "dataFinal"
        Me.dataFinal.Size = New System.Drawing.Size(105, 22)
        Me.dataFinal.TabIndex = 15
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(259, 155)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(17, 16)
        Me.lblA.TabIndex = 14
        Me.lblA.Text = "A"
        '
        'dataInicial
        '
        Me.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dataInicial.Location = New System.Drawing.Point(147, 151)
        Me.dataInicial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dataInicial.Name = "dataInicial"
        Me.dataInicial.Size = New System.Drawing.Size(105, 22)
        Me.dataInicial.TabIndex = 13
        '
        'cboDistrito
        '
        Me.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrito.FormattingEnabled = True
        Me.cboDistrito.Location = New System.Drawing.Point(147, 70)
        Me.cboDistrito.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(158, 24)
        Me.cboDistrito.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(95, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Distrito"
        '
        'cboProvincia
        '
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(147, 28)
        Me.cboProvincia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(290, 24)
        Me.cboProvincia.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Provincia"
        '
        'cboUS
        '
        Me.cboUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUS.FormattingEnabled = True
        Me.cboUS.Location = New System.Drawing.Point(147, 112)
        Me.cboUS.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.cboUS.Name = "cboUS"
        Me.cboUS.Size = New System.Drawing.Size(290, 24)
        Me.cboUS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Unidade Sanitaria"
        '
        'frmSESP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 901)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSESP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SESP"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.FaixaEtaria.ResumeLayout(False)
        Me.FaixaEtaria.PerformLayout()
        Me.Sexo.ResumeLayout(False)
        Me.Sexo.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.tarv.ResumeLayout(False)
        Me.tarv.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents dataView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFechar As System.Windows.Forms.Button
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents FaixaEtaria As System.Windows.Forms.GroupBox
    Friend WithEvents rdAdulto As System.Windows.Forms.RadioButton
    Friend WithEvents rdCrianca As System.Windows.Forms.RadioButton
    Friend WithEvents rdFaixaTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Sexo As System.Windows.Forms.GroupBox
    Friend WithEvents rdM As System.Windows.Forms.RadioButton
    Friend WithEvents rdF As System.Windows.Forms.RadioButton
    Friend WithEvents rdSexoTodos As System.Windows.Forms.RadioButton
    Friend WithEvents chkDistrital As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdVisualizarSaida As System.Windows.Forms.Button
    Friend WithEvents rdSuspensos As System.Windows.Forms.RadioButton
    Friend WithEvents rdObitos As System.Windows.Forms.RadioButton
    Friend WithEvents rdTransferidosPara As System.Windows.Forms.RadioButton
    Friend WithEvents rdTodasSaidas As System.Windows.Forms.RadioButton
    Friend WithEvents rdAbandonoNotificado As System.Windows.Forms.RadioButton
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents tarv As System.Windows.Forms.GroupBox
    Friend WithEvents rdTransferidosDe As System.Windows.Forms.RadioButton
    Friend WithEvents rdReinicio As System.Windows.Forms.RadioButton
    Friend WithEvents cmdVisualizarTARV As System.Windows.Forms.Button
    Friend WithEvents rdInicioTARV As System.Windows.Forms.RadioButton
    Friend WithEvents rdTarv As System.Windows.Forms.RadioButton
    Friend WithEvents rdFaltoso As System.Windows.Forms.RadioButton
    Friend WithEvents rdAbandono As System.Windows.Forms.RadioButton
    Friend WithEvents dataFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
