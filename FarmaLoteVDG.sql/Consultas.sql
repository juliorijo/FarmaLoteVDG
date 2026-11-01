USE FarmaLoteVDG;
GO

-- 1. Lo mismo que ve la app (solo lotes activos)
EXEC sp_ListarLotes;

-- 2. Buscar por medicamento o número de lote
EXEC sp_ListarLotes @Filtro = 'PAR';

-- 3. Todos los lotes, incluidos los retirados
SELECT
    L.IdLote,
    ISNULL(L.Nombre_Medicamento, P.Nombre) AS Medicamento,
    L.NumeroLote,
    L.CantidadInicial,
    L.CantidadActual,
    L.FechaVencimiento,
    L.Activo
FROM LOTE L
INNER JOIN PRODUCTO P ON P.IdProducto = L.IdProducto
ORDER BY L.FechaVencimiento;

-- 4. Lotes vencidos o por vencer en 30 días (solo activos)
SELECT IdLote, Nombre_Medicamento, NumeroLote, CantidadActual, FechaVencimiento
FROM LOTE
WHERE Activo = 1
  AND FechaVencimiento <= DATEADD(DAY, 30, CAST(GETDATE() AS DATE))
ORDER BY FechaVencimiento;

-- 5. Resumen por estado
SELECT Estado, COUNT(*) AS Lotes
FROM (
    SELECT CASE
        WHEN FechaVencimiento < CAST(GETDATE() AS DATE) THEN 'Vencido'
        WHEN FechaVencimiento <= DATEADD(DAY, 30, CAST(GETDATE() AS DATE)) THEN 'Por vencer'
        ELSE 'Vigente' END AS Estado
    FROM LOTE
    WHERE Activo = 1
) X
GROUP BY Estado;

-- 6. Productos base y movimientos de inventario
SELECT * FROM PRODUCTO;
SELECT * FROM MOVIMIENTO_LOTE;
