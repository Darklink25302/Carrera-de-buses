# Registro individual — Integrante 4

**Nombre:** Maria Antonella Aleman Centeno
**Usuario GitHub:** antonellaaleman129-oss
**Módulo:** Cierre seguro y coordinación de pruebas

---

## Experimento 3 — Hilos de primer plano

**Responsable:** Integrante 4
**Fecha:** 13/10/2026
**Rama o commit de prueba:** equipo01/cierre-pruebas
**Cambio realizado:** Cambié `hilo.IsBackground = True` a `False` en `FrmBuses.Hilos.vb`.

**Pasos para reproducir:**
1. compilar
2. Iniciar una carrera.
3. Cerrar la ventana con la X a mitad de carrera.
4. Abrir el Administrador de tareas y buscar `CarreraBuses.exe`.

**Resultado esperado:** El proceso debería quedar vivo porque los hilos de primer plano impiden que el proceso termine.

**Observación real:** La ventana cerró rápido y `CarreraBuses.exe` NO seguía en el Administrador de tareas. El cierre cooperativo hizo que los hilos salieran rápido incluso siendo de primer plano.


 Aunque los hilos eran de primer plano (que normalmente mantienen el proceso vivo), nuestra señal `CierreSolicitado()` hace que salgan rápido. Por eso el proceso murió igual de rápido que con hilos de fondo.

**Confirmación de restauración del código normal:** `IsBackground = True` restaurado ✅

---

## Experimento 5 — Frecuencia del Timer

**Responsable:** Integrante 4
**Fecha:** 13/10/2026
**Rama o commit de prueba:** equipo01/cierre-pruebas
**Cambio realizado:** Modifiqué `Interval` del Timer `tmrEstados` de 100 a 1000, luego a 20.

Pasos para reproducir:
1. Abrir el diseñador y seleccionar `tmrEstados`.
2. Cambiar `Interval` a 1000.
3. Ejecutar F5 e iniciar carrera.
4. Observar las etiquetas de estado.
5. Cambiar `Interval` a 20 y repetir.

Resultado esperado: Con Interval=1000 se pierden transiciones; con Interval=20 se ven más estados.

Observación real:
- Con `Interval = 1000`: cambiaron algunos títulos (pocos cambios visibles).
- Con `Interval = 20`: los estados cambiaban más rápido (más transiciones visibles).

 El Timer solo "toma muestras" del estado de los hilos. Si el intervalo es muy largo (1000 ms), se pierden cambios rápidos. Si es muy corto (20 ms), se ven más transiciones pero consume más recursos. Por eso 100 ms es un buen equilibrio.

**Confirmación de restauración del código normal:** `Interval = 100` restaurado ✅