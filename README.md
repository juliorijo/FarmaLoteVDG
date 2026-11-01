# FarmaLote VDG: gestión de lotes con base de datos

Rama: `feature/conexion-bd`

Esta rama conecta la aplicación con SQL Server. Los lotes se guardan en la base de datos `FarmaLoteVDG` y ya no se pierden al cerrar el programa.

## Requisitos

- Visual Studio con la carga de trabajo **Desarrollo de escritorio con .NET**
- **SQL Server** (Express, Developer o LocalDB)
- **SQL Server Management Studio (SSMS)**
- Git

## Pasos para probar esta rama

### 1. Usar rama

```bash
git clone <URL-del-repositorio>
cd <carpeta-del-repositorio>
git checkout feature/conexion-bd
```

Si ya tienen el repositorio clonado:

```bash
git fetch
git checkout feature/conexion-bd
```

### 2. Abrir la solución

Abrir `FarmaLoteVDG.slnx` en Visual Studio.

### 3. Crear la base de datos

1. Abrir SSMS y conectarse a su servidor SQL. Anotar el nombre que aparece en **Nombre del servidor**.
2. Abrir el archivo `FarmaLoteVDG.sql/FarmaLoteVDG.sql` (Archivo → Abrir → Archivo).
3. Pulsar **Ejecutar** (F5).

El script crea la base `FarmaLoteVDG`, las tablas, los procedimientos almacenados y el trigger. Se puede ejecutar varias veces sin problema.

### 4. Cambiar el servidor en `App.config`

Abrir `App.config` y cambiar el valor de `Server=` por **el nombre de su propio servidor** (el que anotaron en SSMS):

```xml
<connectionStrings>
  <add name="FarmaLoteVDG"
       connectionString="Server=SU_SERVIDOR;Database=FarmaLoteVDG;Trusted_Connection=True;Connect Timeout=5;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Ejemplos de valores para `Server=`:

| Si tienen | Usar |
|---|---|
| SQL Server Express | `.\SQLEXPRESS` |
| Instancia predeterminada | `localhost` |
| LocalDB (viene con Visual Studio) | `(localdb)\MSSQLLocalDB` |
| Otra instancia con nombre | `.\NOMBRE_INSTANCIA` |

**Importante:** no subir este cambio a Git. Para que Git ignore sus cambios en ese archivo:

```bash
git update-index --skip-worktree App.config
```

### 5. Ejecutar

Compilar y ejecutar con **F5**. La lista empieza vacía. Usar el botón **Nuevo** para registrar lotes; se guardan en la base de datos.

### 6. Revisar los datos en la base de datos

En SSMS, abrir y ejecutar `FarmaLoteVDG.sql/Consultas.sql`. Incluye consultas para ver los lotes activos, los retirados, los próximos a vencer y un resumen por estado.

## Estructura de la carpeta SQL

```
FarmaLoteVDG.sql/
├── FarmaLoteVDG.sql   Script base: base de datos, tablas, procedimientos y trigger
└── Consultas.sql      Consultas para verificar los datos
```

## Datos de prueba sugeridos

| Medicamento | N.º de lote | Cantidad | Estado esperado |
|---|---|---|---|
| Paracetamol 500 mg | PAR-2601 | 120 | Vigente |
| Amoxicilina 500 mg | AMX-2602 | 48 | Por vencer (menos de 30 días) |
| Loratadina 10 mg | LOR-2603 | 32 | Vencido |

## Problemas frecuentes

| Mensaje | Causa y solución |
|---|---|
| "El sistema no puede encontrar el archivo especificado" o "no se encontró el servidor" | El `Server=` del `App.config` no coincide con su instancia. Revisar el nombre en SSMS o en `services.msc`. |
| "Cannot open database FarmaLoteVDG" | No ejecutaron el script del paso 3. |
| "Invalid column name ..." | Tienen una base `FarmaLoteVDG` de una versión anterior. Borrarla en SSMS y volver a ejecutar el script. |
| "Could not find stored procedure" | El script no se ejecutó completo. Volver a ejecutarlo. |
| "El nombre 'ConfigurationManager' no existe" | Falta la referencia a `System.Configuration` (Referencias → Agregar referencia → System.Configuration). |
| "La operación del depurador está tardando más de lo previsto" | Suele ser la conexión a SQL Server esperando respuesta. Revisar que el servicio esté en ejecución y que el `Server=` sea correcto. |

## Cómo funciona la conexión

- `Datos.cs` (clase `ConexionTest`) contiene los métodos que hablan con la base de datos: `ListarLotes`, `CrearLote`, `ActualizarLote` y `RetirarLote`.
- Cada método llama a un procedimiento almacenado del script SQL.
- **Retirar** un lote no lo borra: lo marca como inactivo (`Activo = 0`), por eso desaparece de la lista pero sigue en la tabla.

