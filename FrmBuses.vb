Public Class FrmBuses
    Private Sub FrmBuses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepararPantalla()
    End Sub

    ' Este método se llama desde el hilo de la interfaz antes de cada carrera.
    Private Sub PrepararPantalla()
        pbBus1.Value = 0
        pbBus2.Value = 0
        pbBus3.Value = 0
        lblEstado1.Text = "Sin iniciar"
        lblEstado2.Text = "Sin iniciar"
        lblEstado3.Text = "Sin iniciar"
        lblGanador.Text = "Ganador: —"
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    ' btnIniciar se habilitará al integrar CrearHilos, ArrancarHilos
    ' y ReiniciarGanador de los otros módulos del equipo.
End Class