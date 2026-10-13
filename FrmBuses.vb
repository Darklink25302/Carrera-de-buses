Public Class FrmBuses
    Private Sub FrmBuses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrEstados.Stop()
        PrepararPantalla()
    End Sub

    Private Sub PrepararPantalla()
        pbBus1.Value = 0
        pbBus2.Value = 0
        pbBus3.Value = 0
        lblEstado1.Text = "Sin iniciar"
        lblEstado2.Text = "Sin iniciar"
        lblEstado3.Text = "Sin iniciar"
        lblGanador.Text = "Ganador: —"
        tmrEstados.Interval = 100
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        PrepararPantalla()
        ReiniciarGanador()
        btnIniciar.Enabled = False
        CrearHilos()
        tmrEstados.Start()
        ArrancarHilos()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub lblGanador_Click(sender As Object, e As EventArgs) Handles lblGanador.Click

    End Sub
End Class