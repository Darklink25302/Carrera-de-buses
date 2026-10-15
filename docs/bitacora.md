# Bitácora 

## Experimento 1: ejecutar la carrera sin hilos

Integrante 1. Prueba del 13 de octubre de 2026.

Usamos una copia del proyecto para no cambiar la carrera normal. En el botón Iniciar pusimos `Viajar()` en lugar de `ArrancarHilos()`. También cambiamos la selección del bus para que el hilo de la ventana moviera la barra del Bus 1.

El recorrido tardó unos 4,2 segundos. Durante ese tiempo el temporizador de prueba no atendió ningún evento. Después del recorrido volvió a funcionar. Al final, la barra del Bus 1 estaba en 150 y las otras dos seguían en cero.

Esto pasó porque el hilo de la ventana estaba haciendo todo el recorrido, incluyendo las pausas de `Thread.Sleep`. En la versión normal cada bus tiene su propio hilo y la ventana puede seguir atendiendo eventos.

El 14 de octubre repetimos la observación en otra copia. Para tener tiempo de intentar mover la ventana, solo en esa copia ampliamos las pausas a 1 segundo por vuelta. Al intentar arrastrarla durante el recorrido, Windows mostró el aviso `No responde`.

La barra llegó a verse parcialmente llena antes de terminar; no apareció solamente al final. Las etiquetas de estado seguían en `Sin iniciar`. Al terminar el recorrido desapareció el aviso y la ventana volvió a responder. El bloqueo se notó en la respuesta de la ventana y del temporizador, aunque la barra pudiera mostrar parte del avance.

[Captura de la ventana sin responder](capturas/experimento-1-no-responde.png)

Los cambios de esta prueba quedaron en la copia. El proyecto normal sigue usando `ArrancarHilos()`

[Captura del experimento](capturas/experimento-1-final.png)

## Experimento 2: cambiar las barras sin Invoke

Integrante 2.

Se cambió la actualización con `InvocarSiAbierto()` por una asignación directa a las barras. Al iniciar la carrera con F5 apareció una excepción `System.InvalidOperationException` en la línea 64. El Bus 3 intentó cambiar `pbBus3.Value` cuando iba por 5 km.

Pasó porque el hilo del bus intentó modificar un control creado por el hilo de la ventana. Se restauró `InvocarSiAbierto()` y los tres buses volvieron a terminar sin errores.

El registro original está en [la prueba del integrante 2](experimentos/integrante-2.md).

## Experimento 3: usar IsBackground = False

Integrante 4. Prueba del 13 de octubre de 2026.

Se cambió `IsBackground` a `False` y se cerró la ventana a mitad de la carrera. La ventana cerró rápido y `CarreraBuses.exe` ya no aparecía en el Administrador de tareas.

Aunque eran hilos de primer plano, la señal `CierreSolicitado()` hizo que salieran del recorrido al cerrar. Después de la prueba se dejó otra vez `IsBackground = True`.

## Experimento 4: quitar SyncLock

Prueba de integración del 14 de octubre de 2026.

En dos copias del proyecto pusimos las pausas del recorrido en 100 ms. También agregamos una pausa de 150 ms entre comprobar si el ganador estaba vacío y guardarlo, y un contador de registros.

En la primera copia quitamos el `SyncLock` de `RegistrarLlegada()`. En la segunda lo conservamos, con las mismas pausas.

| Prueba | Buses que se registraron como ganadores |
| --- | --- |
| Sin SyncLock | 3 |
| Con SyncLock | 1 |

Sin el candado, los tres encontraron el ganador vacío antes de que otro lo guardara. Cada uno se registró y cambió la etiqueta. Con el candado, solo uno pudo guardar su nombre; los otros encontraron un ganador registrado. En las dos pruebas las barras terminaron en 150.

Los contadores y las pausas de prueba quedaron en las copias. El proyecto de entrega conserva `SyncLock` y las pausas aleatorias normales.

- [Prueba sin SyncLock](capturas/experimento-4-sin-candado.png)
- [Prueba con SyncLock](capturas/experimento-4-con-candado.png)

## Experimento 5: cambiar el intervalo del Timer

Integrante 4. Prueba del 13 de octubre de 2026.

Con el intervalo en 1000 ms se vieron pocos cambios de estado. Con 20 ms las etiquetas cambiaron más rápido.

El Timer revisa los estados cada cierto tiempo. Si un estado dura muy poco, puede cambiar antes de la siguiente revisión y no aparecer en la etiqueta. Al terminar se restauró el intervalo de 100 ms.

## Experimento 6: cambiar Invoke por BeginInvoke

Integrante 2.

Se cambió `InvocarSiAbierto()` por `BeginInvoke`. Primero se mantuvo la copia local de los kilómetros y los buses avanzaron bien. Después se usó directamente `km` dentro de la acción.

En esa segunda prueba los tres llegaron a 150, terminaron en `Stopped` y ganó el Bus 1. No hubo errores. Con la captura final no se pudo saber si las barras habían dado saltos durante el recorrido.

`Invoke` espera a que la ventana haga el cambio. `BeginInvoke` deja el cambio en espera y el hilo sigue. Si la acción usa una variable capturada, esa variable puede tener otro valor cuando se ejecute. Por eso conviene copiar el kilómetro de cada vuelta.

Se restauró `InvocarSiAbierto()` y se comprobó otra carrera sin errores. El registro original está en [la prueba del integrante 2](experimentos/integrante-2.md).

## Diez carreras con la versión normal

Se hicieron diez carreras seguidas. Estos fueron los ganadores:

| Carrera | Ganador |
| --- | --- |
| 1 | Bus 2 |
| 2 | Bus 1 |
| 3 | Bus 1 |
| 4 | Bus 1 |
| 5 | Bus 3 |
| 6 | Bus 3 |
| 7 | Bus 1 |
| 8 | Bus 1 |
| 9 | Bus 1 |
| 10 | Bus 1 |

En todas las carreras las tres barras llegaron a 150 y se mostró un solo ganador. Al terminar, los estados quedaron en `Stopped` y el botón Iniciar volvió a habilitarse. Al empezar otra carrera se limpiaron las barras y el ganador anterior. Estas comprobaciones se hicieron con una prueba automática sobre el formulario.

También se probó Salir durante la carrera, a los 700 y a los 3600 ms. En los dos casos la ventana se cerró sin errores y los hilos terminaron.

Las siguientes capturas son de otra ejecución de la versión normal, en la que ganó el Bus 1:

- [Carrera en curso](capturas/carrera-en-curso.png)
- [Carrera terminada](capturas/carrera-terminada.png)
