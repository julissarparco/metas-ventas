/****** Object:  Database [BCP.API_db]    Script Date: 15/09/2023 06:53:03 ******/
CREATE DATABASE [BCP.API_db]  (EDITION = 'Standard', SERVICE_OBJECTIVE = 'S0', MAXSIZE = 1 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [BCP.API_db] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [BCP.API_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BCP.API_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BCP.API_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BCP.API_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BCP.API_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [BCP.API_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BCP.API_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BCP.API_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BCP.API_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BCP.API_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BCP.API_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BCP.API_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BCP.API_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BCP.API_db] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [BCP.API_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BCP.API_db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BCP.API_db] SET  MULTI_USER 
GO
ALTER DATABASE [BCP.API_db] SET ENCRYPTION ON
GO
ALTER DATABASE [BCP.API_db] SET QUERY_STORE = ON
GO
ALTER DATABASE [BCP.API_db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Agencias]    Script Date: 15/09/2023 06:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agencias](
	[AgenciaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[AgenciaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsesoresComerciales]    Script Date: 15/09/2023 06:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsesoresComerciales](
	[AsesorID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[GerenteID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AsesorID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 15/09/2023 06:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteID] [int] IDENTITY(1,1) NOT NULL,
	[TipoDocumento] [varchar](50) NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[Apellidos] [varchar](255) NULL,
	[Nombres] [varchar](255) NULL,
	[NumeroCelular] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TipoDocumento] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GerentesAgencia]    Script Date: 15/09/2023 06:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GerentesAgencia](
	[GerenteID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[AgenciaID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[GerenteID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetasMensuales]    Script Date: 15/09/2023 06:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetasMensuales](
	[MetaID] [int] IDENTITY(1,1) NOT NULL,
	[GerenteID] [int] NULL,
	[Mes] [int] NULL,
	[Anio] [int] NULL,
	[Meta] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MetaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductosFinancieros]    Script Date: 15/09/2023 06:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductosFinancieros](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[PuntosPorVenta] [varchar](200) NULL,
	[TipoPuntos] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 15/09/2023 06:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[VentaID] [int] IDENTITY(1,1) NOT NULL,
	[MetaMensualID] [int] NULL,
	[PeriodoMes] [int] NULL,
	[PeriodoAnio] [int] NULL,
	[AsesorID] [int] NULL,
	[ClienteID] [int] NULL,
	[ProductoID] [int] NULL,
	[PuntosObtenidos] [int] NULL,
	[FechaVenta] [date] NULL,
	[MontoPrestamo] [decimal](18, 2) NULL,
	[MontoDesembolsado] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[VentaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AsesoresComerciales]  WITH CHECK ADD  CONSTRAINT [FK_Gerente] FOREIGN KEY([GerenteID])
REFERENCES [dbo].[GerentesAgencia] ([GerenteID])
GO
ALTER TABLE [dbo].[AsesoresComerciales] CHECK CONSTRAINT [FK_Gerente]
GO
ALTER TABLE [dbo].[GerentesAgencia]  WITH CHECK ADD  CONSTRAINT [FK_Agencia] FOREIGN KEY([AgenciaID])
REFERENCES [dbo].[Agencias] ([AgenciaID])
GO
ALTER TABLE [dbo].[GerentesAgencia] CHECK CONSTRAINT [FK_Agencia]
GO
/****** Object:  StoredProcedure [dbo].[up_crear_cliente]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_crear_cliente]
    @nombre NVARCHAR(255),
    @apellido NVARCHAR(255),
    @tipoDocumento NVARCHAR(50),
    @numeroDocumento NVARCHAR(50),
    @numeroCelular NVARCHAR(20)
AS
BEGIN
    BEGIN TRANSACTION;

    DECLARE @Code INT;
    DECLARE @Message NVARCHAR(MAX);
	DECLARE @Error INT;
     
    INSERT INTO Clientes (Nombres, Apellidos, TipoDocumento, NumeroDocumento, NumeroCelular)
    VALUES (@nombre, @apellido, @tipoDocumento, @numeroDocumento, @numeroCelular);
    

    SET @Error = @@ERROR;

    IF @Error = 0
    BEGIN
        COMMIT;
        SET @Code = 0;
        SET @Message = 'Éxito';
    END
    ELSE
    BEGIN
        ROLLBACK;
        SET @Code = @Error;
        SET @Message = 'Error en la transacción';
    END;

	SELECT @Code code, @Message as 'message';
END;
GO
/****** Object:  StoredProcedure [dbo].[up_get_agencia_by_id]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_agencia_by_id]
(
	@id INT
)
AS
SELECT * FROM AGENCIA where id = @id;
GO
/****** Object:  StoredProcedure [dbo].[up_get_all_agencias]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_all_agencias]
AS
SELECT *
FROM Agencias;
GO
/****** Object:  StoredProcedure [dbo].[up_get_all_asesores_comerciales]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_all_asesores_comerciales]
AS
SELECT * FROM AsesoresComerciales
GO
/****** Object:  StoredProcedure [dbo].[up_get_all_clientes]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_all_clientes]
AS
SELECT * 
FROM clientes;
GO
/****** Object:  StoredProcedure [dbo].[up_get_all_productos]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_all_productos]
AS
SELECT *
FROM ProductosFinancieros;
GO
/****** Object:  StoredProcedure [dbo].[up_get_all_ventas]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_all_ventas]
AS
SELECT
    ROW_NUMBER() OVER (ORDER BY v.VentaID) AS RowId,
    v.VentaID AS Id,
    v.PeriodoMes,
    v.PeriodoAnio,
    v.FechaVenta,
    c.ClienteID AS [ClienteId],
    c.Nombres AS [ClienteNombres],
    c.Apellidos AS [ClienteApellidos],
    ac.AsesorID AS [AsesorId],
    ac.Nombre AS [AsesorNombres],
    p.ProductoID AS [ProductoId],
    p.Nombre AS [ProductoNombres],
	v.MontoDesembolsado,
	v.MontoPrestamo
FROM Ventas v
INNER JOIN Clientes c ON c.ClienteID = v.ClienteID
INNER JOIN AsesoresComerciales ac ON ac.AsesorID = v.AsesorID
INNER JOIN ProductosFinancieros p ON p.ProductoID = v.ProductoID;
GO
/****** Object:  StoredProcedure [dbo].[up_get_asesor_comercial_by_id]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_asesor_comercial_by_id]
( @id INT)
AS
SELECT * FROM AsesoresComerciales WHERE AsesorID = @id;
GO
/****** Object:  StoredProcedure [dbo].[up_get_cliente_by_id]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_cliente_by_id]
(
@id int
)
AS
SELECT *
FROM clientes
where ClienteID = @id; 
GO
/****** Object:  StoredProcedure [dbo].[up_get_meta_mensual_by_gerente_mes]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_meta_mensual_by_gerente_mes]
(
	@gerenteId INT,
	@mes VARCHAR(2)
)
AS
SELECT *
FROM MetasMensuales
WHERE gerenteId = @gerenteId AND mes = @mes;
GO
/****** Object:  StoredProcedure [dbo].[up_get_producto_by_id]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_get_producto_by_id]
(
@id int
)
AS
SELECT *
FROM productosFinancieros
where productoID = @id
GO
/****** Object:  StoredProcedure [dbo].[up_registrar_meta_mensual]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[up_registrar_meta_mensual]
    @GerenteId INT,
    @Mes INT,
    @Anio INT,
    @Meta DECIMAL(18, 2)
AS
BEGIN
    BEGIN TRANSACTION;

    DECLARE @Code INT;
    DECLARE @Message NVARCHAR(MAX);
	DECLARE @Error INT;

    INSERT INTO MetasMensuales (GerenteId, Mes, Anio, Meta)
    VALUES (@GerenteId, @Mes, @Anio, @Meta);

    SET @Error = @@ERROR;

    IF @Error = 0
    BEGIN
        COMMIT;
        SET @Code = 0;
        SET @Message = 'Éxito';
    END
    ELSE
    BEGIN
        ROLLBACK;
        SET @Code = @Error;
        SET @Message = 'Error en la transacción';
    END;

	SELECT @Code code, @Message as 'message';
END
GO
/****** Object:  StoredProcedure [dbo].[up_registrar_venta]    Script Date: 15/09/2023 06:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_registrar_venta]
    @ClienteId INT,
    @AsesorId INT,
    @ProductoId INT,
    @MontoPrestamo DECIMAL(18, 2),
    @MontoDesembolsado DECIMAL(18, 2),
    @FechaVenta DATETIME,
    @MetaMensualId INT,
    @PuntosObtenidos INT,
    @PeriodoMes INT,
    @PeriodoAnio INT
AS
BEGIN
    BEGIN TRANSACTION;

    DECLARE @Code INT;
    DECLARE @Message NVARCHAR(MAX);
	DECLARE @Error INT;

    INSERT INTO Ventas (ClienteId, AsesorId, ProductoId, MontoPrestamo, MontoDesembolsado, FechaVenta, MetaMensualId, PuntosObtenidos, PeriodoMes, PeriodoAnio)
    VALUES (@ClienteId, @AsesorId, @ProductoId, @MontoPrestamo, @MontoDesembolsado, @FechaVenta, @MetaMensualId, @PuntosObtenidos, @PeriodoMes, @PeriodoAnio);

    SET @Error = @@ERROR;

    IF @Error = 0
    BEGIN
        COMMIT;
        SET @Code = 0;
        SET @Message = 'Éxito';
    END
    ELSE
    BEGIN
        ROLLBACK;
        SET @Code = @Error;
        SET @Message = 'Error en la transacción';
    END;
END
GO
ALTER DATABASE [BCP.API_db] SET  READ_WRITE 
GO
