# Bitácora 

## Experimento 1: ejecutar la carrera sin hilos

Integrante 1. Prueba del 13 de octubre de 2026.

Usamos una copia del proyecto para no cambiar la carrera normal. En el botón Iniciar pusimos `Viajar()` en lugar de `ArrancarHilos()`. También cambiamos la selección del bus para que el hilo de la ventana moviera la barra del Bus 1.

El recorrido tardó unos 4,2 segundos. Durante ese tiempo el temporizador de prueba no atendió ningún evento. Después del recorrido volvió a funcionar. Al final, la barra del Bus 1 estaba en 150 y las otras dos seguían en cero.

Esto pasó porque el hilo de la ventana estaba haciendo todo el recorrido, incluyendo las pausas de `Thread.Sleep`. En la versión normal cada bus tiene su propio hilo y la ventana puede seguir atendiendo eventos.

Todavía falta intentar mover la ventana durante esta prueba y anotar si la barra avanza poco a poco o se pinta al final. Lo que comprobamos hasta ahora fue el bloqueo del temporizador.

Los cambios de esta prueba quedaron en la copia. El proyecto normal sigue usando `ArrancarHilos()`

[Captura del experimento](capturas/experimento-1-final.png)

## Experimento 2: cambiar las barras sin Invoke

Integrante 2. Pendiente. Falta probarlo con F5 y anotar el mensaje de error y la línea donde se detiene.

## Experimento 3: usar IsBackground = False

Integrante 4. Pendiente. Falta cerrar la ventana a mitad de la carrera y revisar si el proceso sigue abierto y cuándo termina.

## Experimento 4: quitar SyncLock

Integrante 3. Pendiente. Falta provocar el empate, contar cuántos buses se registran como ganadores y comparar con la versión que usa `SyncLock`.

## Experimento 5: cambiar el intervalo del Timer

Integrante 4. Pendiente. Falta comparar los estados que se ven con intervalos de 1000 y 20 ms y explicar por qué casi no se ve `Running`.

## Experimento 6: cambiar Invoke por BeginInvoke

Integrante 2. Pendiente. Falta probarlo sin copiar el kilómetro a una variable local y anotar qué pasa con las barras

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
