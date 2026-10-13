<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBuses
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lblTitulo = New Label()
        lblBus1 = New Label()
        lblBus2 = New Label()
        lblBus3 = New Label()
        pbBus1 = New ProgressBar()
        pbBus2 = New ProgressBar()
        pbBus3 = New ProgressBar()
        lblEstado1 = New Label()
        lblEstado2 = New Label()
        lblEstado3 = New Label()
        lblGanador = New Label()
        btnIniciar = New Button()
        btnSalir = New Button()
        tmrEstados = New Timer(components)
        SuspendLayout()
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTitulo.ForeColor = Color.Navy
        lblTitulo.Location = New Point(20, 15)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(248, 25)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "Managua → Estelí · 150 km"
        ' 
        ' lblBus1
        ' 
        lblBus1.AutoSize = True
        lblBus1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblBus1.Location = New Point(20, 75)
        lblBus1.Name = "lblBus1"
        lblBus1.Size = New Size(44, 19)
        lblBus1.TabIndex = 1
        lblBus1.Text = "Bus 1"
        ' 
        ' lblBus2
        ' 
        lblBus2.AutoSize = True
        lblBus2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblBus2.Location = New Point(20, 143)
        lblBus2.Name = "lblBus2"
        lblBus2.Size = New Size(44, 19)
        lblBus2.TabIndex = 2
        lblBus2.Text = "Bus 2"
        ' 
        ' lblBus3
        ' 
        lblBus3.AutoSize = True
        lblBus3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblBus3.Location = New Point(20, 211)
        lblBus3.Name = "lblBus3"
        lblBus3.Size = New Size(44, 19)
        lblBus3.TabIndex = 3
        lblBus3.Text = "Bus 3"
        ' 
        ' pbBus1
        ' 
        pbBus1.Location = New Point(90, 70)
        pbBus1.Maximum = 150
        pbBus1.Name = "pbBus1"
        pbBus1.Size = New Size(400, 28)
        pbBus1.Step = 5
        pbBus1.Style = ProgressBarStyle.Continuous
        pbBus1.TabIndex = 4
        ' 
        ' pbBus2
        ' 
        pbBus2.Location = New Point(90, 138)
        pbBus2.Maximum = 150
        pbBus2.Name = "pbBus2"
        pbBus2.Size = New Size(400, 28)
        pbBus2.Step = 5
        pbBus2.Style = ProgressBarStyle.Continuous
        pbBus2.TabIndex = 5
        ' 
        ' pbBus3
        ' 
        pbBus3.Location = New Point(90, 206)
        pbBus3.Maximum = 150
        pbBus3.Name = "pbBus3"
        pbBus3.Size = New Size(400, 28)
        pbBus3.Step = 5
        pbBus3.Style = ProgressBarStyle.Continuous
        pbBus3.TabIndex = 6
        ' 
        ' lblEstado1
        ' 
        lblEstado1.BackColor = Color.White
        lblEstado1.BorderStyle = BorderStyle.FixedSingle
        lblEstado1.Font = New Font("Segoe UI", 9F)
        lblEstado1.Location = New Point(505, 70)
        lblEstado1.Name = "lblEstado1"
        lblEstado1.Size = New Size(235, 28)
        lblEstado1.TabIndex = 7
        lblEstado1.Text = "Sin iniciar"
        lblEstado1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblEstado2
        ' 
        lblEstado2.BackColor = Color.White
        lblEstado2.BorderStyle = BorderStyle.FixedSingle
        lblEstado2.Font = New Font("Segoe UI", 9F)
        lblEstado2.Location = New Point(505, 138)
        lblEstado2.Name = "lblEstado2"
        lblEstado2.Size = New Size(235, 28)
        lblEstado2.TabIndex = 8
        lblEstado2.Text = "Sin iniciar"
        lblEstado2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblEstado3
        ' 
        lblEstado3.BackColor = Color.White
        lblEstado3.BorderStyle = BorderStyle.FixedSingle
        lblEstado3.Font = New Font("Segoe UI", 9F)
        lblEstado3.Location = New Point(505, 206)
        lblEstado3.Name = "lblEstado3"
        lblEstado3.Size = New Size(235, 28)
        lblEstado3.TabIndex = 9
        lblEstado3.Text = "Sin iniciar"
        lblEstado3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblGanador
        ' 
        lblGanador.BackColor = Color.White
        lblGanador.BorderStyle = BorderStyle.FixedSingle
        lblGanador.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblGanador.ForeColor = Color.DarkGreen
        lblGanador.Location = New Point(20, 285)
        lblGanador.Name = "lblGanador"
        lblGanador.Size = New Size(720, 40)
        lblGanador.TabIndex = 10
        lblGanador.Text = "Ganador: —"
        lblGanador.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnIniciar
        ' 
        btnIniciar.Enabled = False
        btnIniciar.Location = New Point(460, 350)
        btnIniciar.Name = "btnIniciar"
        btnIniciar.Size = New Size(130, 36)
        btnIniciar.TabIndex = 11
        btnIniciar.Text = "&Iniciar carrera"
        btnIniciar.UseVisualStyleBackColor = True
        ' 
        ' btnSalir
        ' 
        btnSalir.Location = New Point(610, 350)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(130, 36)
        btnSalir.TabIndex = 12
        btnSalir.Text = "&Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' FrmBuses
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnSalir
        ClientSize = New Size(760, 410)
        Controls.Add(lblTitulo)
        Controls.Add(lblBus1)
        Controls.Add(lblBus2)
        Controls.Add(lblBus3)
        Controls.Add(pbBus1)
        Controls.Add(pbBus2)
        Controls.Add(pbBus3)
        Controls.Add(lblEstado1)
        Controls.Add(lblEstado2)
        Controls.Add(lblEstado3)
        Controls.Add(lblGanador)
        Controls.Add(btnIniciar)
        Controls.Add(btnSalir)
        Font = New Font("Segoe UI", 10F)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmBuses"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Carrera de buses Managua - Estelí"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblBus1 As System.Windows.Forms.Label
    Friend WithEvents lblBus2 As System.Windows.Forms.Label
    Friend WithEvents lblBus3 As System.Windows.Forms.Label
    Friend WithEvents pbBus1 As System.Windows.Forms.ProgressBar
    Friend WithEvents pbBus2 As System.Windows.Forms.ProgressBar
    Friend WithEvents pbBus3 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblEstado1 As System.Windows.Forms.Label
    Friend WithEvents lblEstado2 As System.Windows.Forms.Label
    Friend WithEvents lblEstado3 As System.Windows.Forms.Label
    Friend WithEvents lblGanador As System.Windows.Forms.Label
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents tmrEstados As System.Windows.Forms.Timer
End Class