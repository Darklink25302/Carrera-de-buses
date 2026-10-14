Imports System.Threading

Partial Class FrmBuses

    ' ============================================================
    ' MÓDULO DEL INTEGRANTE 3 (completado)
    ' Ganador protegido, Timer de estados y fin de carrera.
    ' ============================================================

    Private ganador As String = ""
    Private ReadOnly candadoGanador As New Object()

    ''' <summary>
    ''' Vacía el ganador antes de iniciar una nueva carrera.
    ''' </summary>
    Public Sub ReiniciarGanador()
        SyncLock candadoGanador
            ganador = ""
        End SyncLock
    End Sub

    ''' <summary>
    ''' Registra al primer bus que llega a la meta. Solo el primero
    ''' consigue registrarse; los demás encuentran el ganador ya ocupado.
    ''' </summary>
    Public Sub RegistrarLlegada(nombre As String)
        Dim consiguioRegistro As Boolean = False

        SyncLock candadoGanador
            If ganador = "" Then
                ganador = nombre
                consiguioRegistro = True
            End If
        End SyncLock

        ' Solo el ganador actualiza la etiqueta, y fuera del candado
        If consiguioRegistro Then
            InvocarSiAbierto(New MethodInvoker(
                Sub()
                    lblGanador.Text = "Ganador: " & ganador
                End Sub))
        End If
    End Sub

    ''' <summary>
    ''' Tick del Timer: actualiza estados, detecta fin de los 3 buses,
    ''' detiene el Timer y habilita Iniciar.
    ''' </summary>
    Private Sub tmrEstados_Tick(sender As Object, e As EventArgs) Handles tmrEstados.Tick

        ' 1. Actualizar etiquetas de estado
        ActualizarEstadoHilo(buses(0), lblEstado1)
        ActualizarEstadoHilo(buses(1), lblEstado2)
        ActualizarEstadoHilo(buses(2), lblEstado3)

        ' 2. Comprobar si los 3 terminaron
        If TodosTerminaron() Then
            tmrEstados.Stop()
            btnIniciar.Enabled = True
        End If

    End Sub

    ''' <summary>
    ''' Actualiza la etiqueta de estado de un hilo.
    ''' </summary>
    Private Sub ActualizarEstadoHilo(hilo As Thread, etiqueta As Label)
        If hilo Is Nothing Then
            etiqueta.Text = "Sin iniciar"
            Return
        End If

        If hilo.ThreadState.HasFlag(ThreadState.Stopped) OrElse
           hilo.ThreadState.HasFlag(ThreadState.Aborted) Then
            etiqueta.Text = "Terminado"
        ElseIf hilo.ThreadState.HasFlag(ThreadState.WaitSleepJoin) Then
            etiqueta.Text = "WaitSleepJoin"
        ElseIf hilo.ThreadState.HasFlag(ThreadState.Running) Then
            etiqueta.Text = "Running"
        ElseIf hilo.ThreadState.HasFlag(ThreadState.Background) Then
            etiqueta.Text = "Background"
        Else
            etiqueta.Text = hilo.ThreadState.ToString()
        End If
    End Sub

    ''' <summary>
    ''' Devuelve True si los tres hilos ya terminaron (o no existen).
    ''' </summary>
    Private Function TodosTerminaron() As Boolean
        If buses Is Nothing Then Return True

        For Each hilo As Thread In buses
            If hilo IsNot Nothing Then
                If Not (hilo.ThreadState.HasFlag(ThreadState.Stopped) OrElse
                        hilo.ThreadState.HasFlag(ThreadState.Aborted)) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

End Class