
-- SCRIPT DE BASE DE DATOS: FarmaLoteVDG
-- Sistema de Gestión de Inventario por Lotes (FEFO) y Facturación


USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'FarmaLoteVDG')
BEGIN
    CREATE DATABASE FarmaLoteVDG;
END;
GO

USE FarmaLoteVDG;
GO


-- 1. TABLAS PRINCIPALES


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRODUCTO]') AND type in (N'U'))
BEGIN
    CREATE TABLE PRODUCTO (
        IdProducto INT IDENTITY(1,1) PRIMARY KEY,
        Nombre VARCHAR(100) NOT NULL,
        Categoria VARCHAR(50) DEFAULT 'General',
        EsGravado BIT NOT NULL DEFAULT 1,
        FechaRegistro DATETIME DEFAULT GETDATE()
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOTE]') AND type in (N'U'))
BEGIN
    CREATE TABLE LOTE (
        IdLote INT IDENTITY(1,1) PRIMARY KEY,
        IdProducto INT NOT NULL,
        Nombre_Medicamento VARCHAR(150) NULL, -- Columna añadida para el nombre personalizado
        NumeroLote VARCHAR(50) NOT NULL,
        FechaVencimiento DATE NOT NULL,
        CantidadInicial INT NOT NULL CHECK (CantidadInicial >= 0),
        CantidadActual INT NOT NULL CHECK (CantidadActual >= 0),
        Activo BIT NOT NULL DEFAULT 1,
        FechaIngreso DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Lote_Producto FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto)
    );
END;
GO

-- Por si la tabla LOTE ya existía previamente sin la columna, nos aseguramos de agregarla:
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'LOTE') AND name = 'Nombre_Medicamento')
BEGIN
    ALTER TABLE LOTE ADD Nombre_Medicamento VARCHAR(150) NULL;
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACTURA]') AND type in (N'U'))
BEGIN
    CREATE TABLE FACTURA (
        IdFactura INT IDENTITY(1,1) PRIMARY KEY,
        NumeroFactura VARCHAR(20) NOT NULL UNIQUE,
        Fecha DATETIME DEFAULT GETDATE(),
        Subtotal DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        ITBIS DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        Total DECIMAL(10,2) NOT NULL DEFAULT 0.00
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DETALLE_FACTURA]') AND type in (N'U'))
BEGIN
    CREATE TABLE DETALLE_FACTURA (
        IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
        IdFactura INT NOT NULL,
        IdProducto INT NOT NULL,
        Cantidad INT NOT NULL CHECK (Cantidad > 0),
        PrecioUnitario DECIMAL(10,2) NOT NULL CHECK (PrecioUnitario >= 0),
        MontoITBIS DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        SubtotalLinea DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        CONSTRAINT FK_Detalle_Factura FOREIGN KEY (IdFactura) REFERENCES FACTURA(IdFactura),
        CONSTRAINT FK_Detalle_Producto FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto)
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MOVIMIENTO_LOTE]') AND type in (N'U'))
BEGIN
    CREATE TABLE MOVIMIENTO_LOTE (
        IdMovimiento INT IDENTITY(1,1) PRIMARY KEY,
        IdLote INT NOT NULL,
        IdFactura INT NULL,
        CantidadDescontada INT NOT NULL,
        FechaMovimiento DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Movimiento_Lote FOREIGN KEY (IdLote) REFERENCES LOTE(IdLote),
        CONSTRAINT FK_Movimiento_Factura FOREIGN KEY (IdFactura) REFERENCES FACTURA(IdFactura)
    );
END;
GO


-- 2. PROCEDIMIENTOS ALMACENADOS

CREATE OR ALTER PROCEDURE sp_ListarLotes
    @Filtro VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        L.IdLote AS Id,
        ISNULL(L.Nombre_Medicamento, P.Nombre) AS Medicamento, -- Prioriza el nombre personalizado del lote
        P.Categoria,
        L.NumeroLote,
        L.CantidadActual AS Cantidad,
        L.FechaVencimiento,
        L.Activo
    FROM LOTE L
    INNER JOIN PRODUCTO P ON L.IdProducto = P.IdProducto
    WHERE L.Activo = 1
      AND (@Filtro IS NULL OR L.Nombre_Medicamento LIKE '%' + @Filtro + '%' OR P.Nombre LIKE '%' + @Filtro + '%' OR L.NumeroLote LIKE '%' + @Filtro + '%')
    ORDER BY L.FechaVencimiento ASC;
END;
GO

CREATE OR ALTER PROCEDURE sp_CrearLote
    @NombreProducto VARCHAR(150),
    @Categoria VARCHAR(50),
    @Gravado BIT,
    @NumeroLote VARCHAR(50),
    @FechaVencimiento DATE,
    @Cantidad INT,
    @IdLoteNuevo INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @IdProd INT;

        -- Buscamos si ya existe un producto base genérico o lo creamos
        SELECT TOP 1 @IdProd = IdProducto FROM PRODUCTO;

        IF @IdProd IS NULL
        BEGIN
            INSERT INTO PRODUCTO (Nombre, Categoria, EsGravado)
            VALUES ('Medicamento General', @Categoria, @Gravado);
            SET @IdProd = SCOPE_IDENTITY();
        END

        -- Insertamos el lote guardando explícitamente el nombre personalizado en Nombre_Medicamento
        INSERT INTO LOTE (IdProducto, Nombre_Medicamento, NumeroLote, FechaVencimiento, CantidadInicial, CantidadActual, Activo)
        VALUES (@IdProd, @NombreProducto, @NumeroLote, @FechaVencimiento, @Cantidad, @Cantidad, 1);

        SET @IdLoteNuevo = SCOPE_IDENTITY();
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarLote
    @IdLote INT,
    @NumeroLote VARCHAR(50),
    @FechaVencimiento DATE,
    @Cantidad INT,
    @Nombre_Medicamento VARCHAR(150) -- Parámetro añadido para actualizar el nombre
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LOTE
    SET NumeroLote = @NumeroLote,
        FechaVencimiento = @FechaVencimiento,
        CantidadActual = @Cantidad,
        Nombre_Medicamento = @Nombre_Medicamento
    WHERE IdLote = @IdLote;
END;
GO

CREATE OR ALTER PROCEDURE sp_RetirarLote
    @IdLote INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LOTE
    SET Activo = 0
    WHERE IdLote = @IdLote;
END;
GO


-- 3. TRIGGER DE INVENTARIO (Estrategia FEFO)

CREATE OR ALTER TRIGGER trg_ValidarYDescontarInventario
ON DETALLE_FACTURA
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN LOTE l ON i.IdProducto = l.IdProducto
        WHERE l.Activo = 1 
          AND l.CantidadActual > 0 
          AND l.FechaVencimiento < CAST(GETDATE() AS DATE)
    )
    BEGIN
        RAISERROR ('No se puede procesar la venta: Hay lotes vencidos en el inventario.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    DECLARE @IdDetalle INT, @IdFactura INT, @IdProducto INT, @CantidadRequerida INT;

    DECLARE curDetalles CURSOR LOCAL FAST_FORWARD FOR
        SELECT IdDetalle, IdFactura, IdProducto, Cantidad
        FROM inserted;

    OPEN curDetalles;
    FETCH NEXT FROM curDetalles INTO @IdDetalle, @IdFactura, @IdProducto, @CantidadRequerida;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @StockTotal INT;
        SELECT @StockTotal = ISNULL(SUM(CantidadActual), 0)
        FROM LOTE
        WHERE IdProducto = @IdProducto AND Activo = 1 AND CantidadActual > 0;

        IF @StockTotal < @CantidadRequerida
        BEGIN
            CLOSE curDetalles;
            DEALLOCATE curDetalles;
            RAISERROR ('Stock insuficiente para cubrir la cantidad solicitada.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        DECLARE @IdLote INT, @CantidadLote INT;

        DECLARE curLotes CURSOR LOCAL FAST_FORWARD FOR
            SELECT IdLote, CantidadActual
            FROM LOTE
            WHERE IdProducto = @IdProducto AND Activo = 1 AND CantidadActual > 0
            ORDER BY FechaVencimiento ASC, IdLote ASC;

        OPEN curLotes;
        FETCH NEXT FROM curLotes INTO @IdLote, @CantidadLote;

        WHILE @@FETCH_STATUS = 0 AND @CantidadRequerida > 0
        BEGIN
            DECLARE @Descuento INT;

            IF @CantidadLote >= @CantidadRequerida
            BEGIN
                SET @Descuento = @CantidadRequerida;
                SET @CantidadRequerida = 0;
            END
            ELSE
            BEGIN
                SET @Descuento = @CantidadLote;
                SET @CantidadRequerida = @CantidadRequerida - @CantidadLote;
            END;

            UPDATE LOTE
            SET CantidadActual = CantidadActual - @Descuento
            WHERE IdLote = @IdLote;

            INSERT INTO MOVIMIENTO_LOTE (IdLote, IdFactura, CantidadDescontada)
            VALUES (@IdLote, @IdFactura, @Descuento);

            FETCH NEXT FROM curLotes INTO @IdLote, @CantidadLote;
        END;

        CLOSE curLotes;
        DEALLOCATE curLotes;

        FETCH NEXT FROM curDetalles INTO @IdDetalle, @IdFactura, @IdProducto, @CantidadRequerida;
    END;

    CLOSE curDetalles;
    DEALLOCATE curDetalles;
END;
GO