## Experimento 2: cambiar las barras sin Invoke

**Responsable:** Integrante 2

Cambio realizado: Se reemplazó temporalmente la actualización segura mediante InvocarSiAbierto() por una asignación directa a las barras de progreso.

Observación real: Al iniciar la carrera, Visual Studio mostró una excepción System.InvalidOperationException en la línea 64. El hilo Bus 3 intentó modificar pbBus3.Value cuando había avanzado 5 km.

Explicación: El error ocurrió porque un hilo secundario intentó modificar directamente un control creado por el hilo principal de Windows Forms. Para evitarlo, debemos usar Invoke para realizar las actualizaciones desde el hilo de la interfaz.

Restauración: Se recuperó el código original con InvocarSiAbierto() y se comprobó que los tres buses completaron nuevamente la carrera sin errores.

## Experimento 6: comparar Invoke y BeginInvoke

**Responsable:** Integrante 2

**Cambio realizado:** Se reemplazó temporalmente la actualización mediante `InvocarSiAbierto()` por `BeginInvoke`.

**Primera prueba:** Se mantuvo una copia local de los kilómetros. Los tres buses avanzaron correctamente.

**Segunda prueba:** Se eliminó la copia local y se utilizó directamente la variable `km` dentro de `BeginInvoke`.

**Observación real:** La carrera terminó con los tres buses en 150 km, los estados `Stopped` y un único ganador, Bus 1. No se observaron errores de ejecución. No se pudo determinar mediante la captura si ocurrieron saltos intermedios.

**Explicación:** `Invoke` espera a que el hilo de interfaz ejecute la actualización, mientras que `BeginInvoke` la programa de forma asíncrona. Una variable capturada puede haber cambiado cuando se ejecuta la acción, aunque ese efecto no necesariamente se observe en todas las pruebas.

**Restauración:** Se recuperó el código original con InvocarSiAbierto() y se comprobó que los tres buses completaron la carrera sin errores.