Imports System.Threading

Partial Class FrmBuses
    Private buses(2) As Thread


    Private Sub CrearHilos()

        For i As Integer = 0 To 2
            buses(i) = New Thread(AddressOf Viajar)
            buses(i).Name = "Bus " & (i + 1).ToString()
            buses(i).IsBackground = True
        Next

    End Sub



    Private Sub ArrancarHilos()

        For i As Integer = 0 To 2
            buses(i).Start()
        Next

    End Sub


    Private Sub Viajar()

        ' Identificar el bus que está ejecutando el hilo
        Dim nombre As String = Thread.CurrentThread.Name
        Dim numeroBus As Integer

        Select Case nombre
            Case "Bus 1"
                numeroBus = 1
            Case "Bus 2"
                numeroBus = 2
            Case "Bus 3"
                numeroBus = 3
            Case Else
                Return
        End Select

        ' Generador de pausas aleatorias para este bus
        Dim azar As New Random()

        ' Recorrer los 150 kilómetros
        For km As Integer = 5 To 150 Step 5

            If CierreSolicitado() Then Return

            Dim kilometrosActuales As Integer = km

            ' Actualizar las barras desde el hilo de interfaz
            Dim actualizado As Boolean =
            InvocarSiAbierto(
                Sub()
                    Select Case numeroBus
                        Case 1
                            pbBus1.Value = kilometrosActuales
                        Case 2
                            pbBus2.Value = kilometrosActuales
                        Case 3
                            pbBus3.Value = kilometrosActuales
                    End Select
                End Sub)

            If Not actualizado Then Return

            ' Pausa aleatoria entre 50 y 200 milisegundos
            Thread.Sleep(azar.Next(50, 201))

        Next

        ' Registrar el bus que llegó
        If Not CierreSolicitado() Then
            RegistrarLlegada(nombre)
        End If

    End Sub

End Class