# Carrera de buses Managua - Estelí

Proyecto de Programación de Aplicaciones de Escritorio realizado en Visual Basic con Windows Forms y .NET 10.

## Integrantes

| Integrante | Nombre | Usuario de GitHub | Responsabilidad |
|---|---|---|---|
| 1 | Por completar | Por completar | Interfaz, inicio y README |
| 2 | Por completar | Por completar | Hilos y recorrido de los buses |
| 3 | Por completar | Por completar | Ganador y estados de los hilos |
| 4 | Por completar | Por completar | Cierre durante la carrera y pruebas |

## Requisitos

- Windows.
- Visual Studio 2026 con la carga de trabajo Desarrollo de escritorio de .NET.
- .NET 10.

## Abrir y ejecutar

1. Abrir `CarreraBuses.slnx` en Visual Studio mediante Archivo > Abrir > Proyecto o solución.
2. Seleccionar Compilar > Compilar solución.
3. Pulsar F5 para ejecutar.
4. Pulsar Salir o la tecla Esc para cerrar la ventana.

## Estado actual

El formulario `FrmBuses` contiene las tres barras de progreso, las etiquetas de estado, la etiqueta del ganador, los botones y el temporizador.

Al abrir la ventana, las barras tienen valor cero, los estados muestran `Sin iniciar` y la etiqueta muestra `Ganador: —`.

El botón Iniciar carrera está desactivado mientras se completan los métodos de hilos y ganador. La carrera todavía no está implementada.

## Funcionamiento solicitado

Cada bus debe recorrer 150 km en un hilo independiente, avanzando de 5 en 5 km y realizando pausas aleatorias entre 50 y 200 ms. Las barras se actualizarán mediante `Invoke` y el temporizador mostrará los estados cada 100 ms.

El registro del ganador se protegerá con `SyncLock`. El botón Iniciar se habilitará de nuevo cuando los tres hilos hayan terminado. Durante el recorrido, la ventana deberá seguir respondiendo.

## Pendientes para la entrega

- Completar los nombres y usuarios de los integrantes.
- Integrar el inicio, el recorrido, el registro del ganador y el cierre durante la carrera.
- Añadir las capturas de una carrera en curso y de una carrera terminada en `docs/capturas`.
- Añadir los enlaces a `docs/bitacora.md` y `docs/estados-observados.md` cuando estén disponibles.
- Documentar los seis experimentos y las pruebas de las carreras.
