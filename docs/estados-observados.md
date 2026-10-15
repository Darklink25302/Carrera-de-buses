# Estados de los buses

Con el Timer en 100 ms vimos estos estados durante las pruebas:

| Texto en la etiqueta | Qué significa |
| --- | --- |
| `Background` | El bus es un hilo de fondo. Puede terminar sin mantener abierto el programa. |
| `Background, WaitSleepJoin` | Es un hilo de fondo y está esperando. En esta carrera aparece mientras hace una pausa con `Thread.Sleep`. |
| `Stopped` | El hilo terminó su recorrido. Cuando los tres llegan a este estado se habilita otra vez Iniciar. |

`Sin iniciar` es un texto que pusimos en la pantalla antes de arrancar los buses. No es un valor de `ThreadState`.

En la primera copia del experimento 1 también apareció `Background, Unstarted`: los objetos Thread estaban creados, pero no se habían arrancado. Eso no corresponde a la carrera normal.

Casi no se alcanza a ver `Running` porque el Timer solo revisa el estado cada 100 ms. Entre una revisión y otra, el bus puede avanzar y volver a quedar esperando. No significa que el bus no haya trabajado.

Los estados pueden venir combinados. Por eso mostramos `ThreadState.ToString()` y comprobamos la bandera `Stopped` para saber si terminó el hilo. Cada carrera crea hilos nuevos, porque un hilo que terminó no se puede volver a iniciar.

Las capturas de la carrera en curso y terminada están en la carpeta [capturas](capturas/).
