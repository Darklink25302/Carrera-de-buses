Imports System.Threading

Partial Class FrmBuses

    ' ============================================================
    ' MÓDULO DEL INTEGRANTE 4: Cierre seguro y coordinación
    ' ============================================================

    ' Bandera de cierre: solo este archivo la declara y la modifica.
    ' Los otros módulos la consultan mediante CierreSolicitado().
    Private banderaCierre As Boolean = False
    Private ReadOnly candadoCierre As New Object()

    ''' <summary>
    ''' Consulta si ya se solicitó el cierre del formulario.
    ''' Usado por los hilos de los buses para terminar limpiamente.
    ''' </summary>
    Public Function CierreSolicitado() As Boolean
        SyncLock candadoCierre
            Return banderaCierre
        End SyncLock
    End Function

    ''' <summary>
    ''' Marca la bandera de cierre. Lo llama FormClosing.
    ''' </summary>
    Private Sub SolicitarCierre()
        SyncLock candadoCierre
            banderaCierre = True
        End SyncLock
    End Sub

    ''' <summary>
    ''' Cierra el formulario de forma coordinada:
    ''' avisa a los hilos y detiene el Timer de estados.
    ''' </summary>
    Private Sub FrmBuses_FormClosing(sender As Object, e As FormClosingEventArgs) _
            Handles Me.FormClosing

        ' 1. Señalizar a los hilos que deben terminar
        SolicitarCierre()

        ' 2. Detener el Timer de estados
        If tmrEstados IsNot Nothing Then
            tmrEstados.Stop()
        End If

        ' 3. NO hacemos Join desde el hilo UI: podría congelar el cierre.
        '    Los hilos son IsBackground = True, así que terminan solos.

    End Sub

    ''' <summary>
    ''' Ejecuta una acción de actualización en el hilo UI de forma segura.
    ''' Devuelve True si la actualización se ejecutó; False si el formulario
    ''' está cerrándose o ya fue destruido.
    ''' </summary>
    Public Function InvocarSiAbierto(accion As MethodInvoker) As Boolean

        ' Verificación previa (fuera del hilo UI)
        If CierreSolicitado() Then Return False
        If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return False

        Try
            Me.Invoke(New MethodInvoker(
                Sub()
                    ' Verificación doble dentro del hilo UI
                    If CierreSolicitado() OrElse Me.IsDisposed Then Return
                    accion.Invoke()
                End Sub))
            Return True

        Catch ex As ObjectDisposedException
            ' El formulario se destruyó mientras intentábamos actualizar
            Return False

        Catch ex As InvalidOperationException
            ' El handle dejó de ser válido (típico durante el cierre)
            Return False

        End Try

    End Function

End Class
