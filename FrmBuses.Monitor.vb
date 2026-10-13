Imports System.Threading

Partial Class FrmBuses
    Private ganador As String = String.Empty
    Private ReadOnly candadoGanador As New Object()

    Private Sub ReiniciarGanador()
        SyncLock candadoGanador
            ganador = String.Empty
        End SyncLock
    End Sub

    Private Sub RegistrarLlegada(nombre As String)
        Dim registrado As Boolean = False

        SyncLock candadoGanador
            If ganador = String.Empty Then
                ganador = nombre
                registrado = True
            End If
        End SyncLock

        If registrado Then
            Me.Invoke(Sub()
                          lblGanador.Text = "Ganador: Bus " & nombre
                      End Sub)
        End If
    End Sub

    Private Function ObtenerGanador() As String
        SyncLock candadoGanador
            Return ganador
        End SyncLock
    End Function

    Private Sub tmrEstados_Tick(sender As Object, e As EventArgs) Handles tmrEstados.Tick
        Dim todosDetenidos As Boolean = True

        For i As Integer = 0 To buses.Length - 1
            Dim textoEstado As String = "Sin iniciar"
            Dim th As Thread = buses(i)

            If th IsNot Nothing Then
                Dim estado As ThreadState = th.ThreadState
                textoEstado = estado.ToString()
                If (estado And ThreadState.Stopped) <> ThreadState.Stopped Then
                    todosDetenidos = False
                End If
            Else
                todosDetenidos = False
            End If

            Select Case i
                Case 0
                    lblEstado1.Text = textoEstado
                Case 1
                    lblEstado2.Text = textoEstado
                Case 2
                    lblEstado3.Text = textoEstado
            End Select
        Next

        If todosDetenidos Then
            tmrEstados.Stop()
            btnIniciar.Enabled = True
        End If
    End Sub
End Class
