# FarmaLote VDG

Interfaz de inventario farmacéutico por lotes, desarrollada con Windows Forms y .NET Framework 4.8.

## Ejecutar en Visual Studio

Abre `FarmaLoteVDG.slnx` o `FarmaLoteVDG.csproj` en Visual Studio y ejecuta el proyecto.

El inventario actual es de demostración y se guarda únicamente en memoria. Los cambios se pierden al cerrar la aplicación. Todavía no hay una base de datos ni un backend conectados.

## Verificar la estructura del proyecto

Las pruebas automáticas comprueban que se conserven la estructura inicial de Windows Forms, el punto de entrada STA, los vínculos del diseñador, el destino .NET Framework 4.8 y los recursos de marca. También compilan el proyecto en una carpeta temporal para evitar modificar o bloquear los archivos de compilación habituales.

Desde PowerShell, ejecuta:

```powershell
.\tests\Test-ProjectStructure.ps1
```

La misma comprobación se ejecuta automáticamente con GitHub Actions al subir cambios a `main`, abrir o actualizar un pull request dirigido a `main`, o iniciarla manualmente desde la pestaña **Actions**.

La compilación requiere Visual Studio/MSBuild con el destino de .NET Framework 4.8. Para ejecutar solo las comprobaciones de estructura cuando no se dispone de MSBuild:

```powershell
.\tests\Test-ProjectStructure.ps1 -SkipBuild
```

## Colaborar en el repositorio

Para evitar que los cambios de varias personas se mezclen, trabajen con ramas cortas y pull requests:

1. Actualiza `main` antes de empezar y crea una rama por tarea, por ejemplo `feature/busqueda-lotes` o `fix/validacion-cantidad`.
2. Limita cada rama a una tarea y asigna claramente qué archivos o parte de la interfaz modifica cada integrante.
3. Antes de abrir el pull request, compila el proyecto en Visual Studio y comprueba el flujo que cambiaste.
4. Abre un pull request hacia `main`, describe los cambios y las pruebas realizadas y pide a otra persona del equipo que lo revise.
5. Integra los cambios solo después de la revisión. Antes de comenzar otra tarea, actualiza tu rama con el `main` más reciente.

Mantengan `main` como rama estable y eviten que varias personas editen simultáneamente el mismo formulario o archivo Designer. Si una tarea requiere tocar los mismos archivos, coordinen el cambio primero y divídanlo en pull requests pequeños y consecutivos. No suban `bin/`, `obj/`, `.vs/` ni archivos locales de usuario; ya están excluidos por `.gitignore`.
