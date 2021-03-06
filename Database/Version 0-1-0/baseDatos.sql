USE [master]
GO
/****** Object:  Database [Venta]    Script Date: 07/04/2016 9:03:40 ******/
CREATE DATABASE [Venta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Venta', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MIGUEL\MSSQL\DATA\Venta.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Venta_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MIGUEL\MSSQL\DATA\Venta_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Venta] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Venta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Venta] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Venta] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Venta] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Venta] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Venta] SET ARITHABORT OFF 
GO
ALTER DATABASE [Venta] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Venta] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Venta] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Venta] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Venta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Venta] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Venta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Venta] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Venta] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Venta] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Venta] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Venta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Venta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Venta] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Venta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Venta] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Venta] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Venta] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Venta] SET RECOVERY FULL 
GO
ALTER DATABASE [Venta] SET  MULTI_USER 
GO
ALTER DATABASE [Venta] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Venta] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Venta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Venta] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Venta]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_clienteDelete]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_clienteDelete]
(
	@cliente_id int
)

AS

SET NOCOUNT ON

DELETE FROM [tbl_cliente]
WHERE [cliente_id] = @cliente_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_clienteInsert]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_clienteInsert]
(
	@nombre varchar(50),
	@nit varchar(50)
)

AS

SET NOCOUNT ON

INSERT INTO [tbl_cliente]
(
	[nombre],
	[nit]
)
VALUES
(
	@nombre,
	@nit
)

SELECT CAST(scope_identity() AS int)

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_clienteSelect]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_clienteSelect]
(
	@cliente_id int
)

AS

SET NOCOUNT ON

SELECT [cliente_id],
	[nombre],
	[nit]
FROM [tbl_cliente]
WHERE [cliente_id] = @cliente_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_clienteSelectAll]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_clienteSelectAll]

AS

SET NOCOUNT ON

SELECT [cliente_id],
	[nombre],
	[nit]
FROM [tbl_cliente]

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_clienteUpdate]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_clienteUpdate]
(
	@cliente_id int,
	@nombre varchar(50),
	@nit varchar(50)
)

AS

SET NOCOUNT ON

UPDATE [tbl_cliente]
SET [nombre] = @nombre,
	[nit] = @nit
WHERE [cliente_id] = @cliente_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_detalleVentaDeleteAllByProducto_id]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_detalleVentaDeleteAllByProducto_id]
(
	@producto_id int
)

AS

SET NOCOUNT ON

DELETE FROM [tbl_detalleVenta]
WHERE [producto_id] = @producto_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_detalleVentaDeleteAllByVenta_id]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_detalleVentaDeleteAllByVenta_id]
(
	@venta_id int
)

AS

SET NOCOUNT ON

DELETE FROM [tbl_detalleVenta]
WHERE [venta_id] = @venta_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_detalleVentaInsert]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_detalleVentaInsert]
(
	@venta_id int,
	@producto_id int,
	@precio int,
	@cantidad int,
	@subtotal int
)

AS

SET NOCOUNT ON

INSERT INTO [tbl_detalleVenta]
(
	[venta_id],
	[producto_id],
	[precio],
	[cantidad],
	[subtotal]
)
VALUES
(
	@venta_id,
	@producto_id,
	@precio,
	@cantidad,
	@subtotal
)

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_detalleVentaSelectAllByProducto_id]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_detalleVentaSelectAllByProducto_id]
(
	@producto_id int
)

AS

SET NOCOUNT ON

SELECT [venta_id],
	[producto_id],
	[precio],
	[cantidad],
	[subtotal]
FROM [tbl_detalleVenta]
WHERE [producto_id] = @producto_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_detalleVentaSelectAllByVenta_id]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_detalleVentaSelectAllByVenta_id]
(
	@venta_id int
)

AS

SET NOCOUNT ON

SELECT [venta_id],
	[producto_id],
	[precio],
	[cantidad],
	[subtotal]
FROM [tbl_detalleVenta]
WHERE [venta_id] = @venta_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_productoDelete]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_productoDelete]
(
	@producto_id int
)

AS

SET NOCOUNT ON

DELETE FROM [tbl_producto]
WHERE [producto_id] = @producto_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_productoInsert]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_productoInsert]
(
	@nombre varchar(50),
	@precio int
)

AS

SET NOCOUNT ON

INSERT INTO [tbl_producto]
(
	[nombre],
	[precio]
)
VALUES
(
	@nombre,
	@precio
)

SELECT CAST(scope_identity() AS int)

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_productoSelect]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_productoSelect]
(
	@producto_id int
)

AS

SET NOCOUNT ON

SELECT [producto_id],
	[nombre],
	[precio]
FROM [tbl_producto]
WHERE [producto_id] = @producto_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_productoSelectAll]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_productoSelectAll]

AS

SET NOCOUNT ON

SELECT [producto_id],
	[nombre],
	[precio]
FROM [tbl_producto]

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_productoUpdate]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_productoUpdate]
(
	@producto_id int,
	@nombre varchar(50),
	@precio int
)

AS

SET NOCOUNT ON

UPDATE [tbl_producto]
SET [nombre] = @nombre,
	[precio] = @precio
WHERE [producto_id] = @producto_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_ventaDelete]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_ventaDelete]
(
	@venta_id int
)

AS

SET NOCOUNT ON

DELETE FROM [tbl_venta]
WHERE [venta_id] = @venta_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_ventaDeleteAllByCliente_id]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_ventaDeleteAllByCliente_id]
(
	@cliente_id int
)

AS

SET NOCOUNT ON

DELETE FROM [tbl_venta]
WHERE [cliente_id] = @cliente_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_ventaInsert]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_ventaInsert]
(
	@fecha varchar(50),
	@cliente_id int,
	@total int
)

AS

SET NOCOUNT ON

INSERT INTO [tbl_venta]
(
	[fecha],
	[cliente_id],
	[total]
)
VALUES
(
	@fecha,
	@cliente_id,
	@total
)

SELECT CAST(scope_identity() AS int)

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_ventaSelect]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_ventaSelect]
(
	@venta_id int
)

AS

SET NOCOUNT ON

SELECT [venta_id],
	[fecha],
	[cliente_id],
	[total]
FROM [tbl_venta]
WHERE [venta_id] = @venta_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_ventaSelectAll]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_ventaSelectAll]

AS

SET NOCOUNT ON

SELECT [venta_id],
	[fecha],
	[cliente_id],
	[total]
FROM [tbl_venta]

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_ventaSelectAllByCliente_id]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_ventaSelectAllByCliente_id]
(
	@cliente_id int
)

AS

SET NOCOUNT ON

SELECT [venta_id],
	[fecha],
	[cliente_id],
	[total]
FROM [tbl_venta]
WHERE [cliente_id] = @cliente_id

GO
/****** Object:  StoredProcedure [dbo].[sp_tbl_ventaUpdate]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_tbl_ventaUpdate]
(
	@venta_id int,
	@fecha varchar(50),
	@cliente_id int,
	@total int
)

AS

SET NOCOUNT ON

UPDATE [tbl_venta]
SET [fecha] = @fecha,
	[cliente_id] = @cliente_id,
	[total] = @total
WHERE [venta_id] = @venta_id

GO
/****** Object:  Table [dbo].[tbl_cliente]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_cliente](
	[cliente_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[nit] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_cliente] PRIMARY KEY CLUSTERED 
(
	[cliente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_detalleVenta]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_detalleVenta](
	[venta_id] [int] NOT NULL,
	[producto_id] [int] NOT NULL,
	[precio] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[subtotal] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_producto]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_producto](
	[producto_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio] [int] NOT NULL,
 CONSTRAINT [PK_tbl_producto] PRIMARY KEY CLUSTERED 
(
	[producto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_venta]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_venta](
	[venta_id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](50) NOT NULL,
	[cliente_id] [int] NOT NULL,
	[total] [int] NOT NULL,
 CONSTRAINT [PK_tbl_venta] PRIMARY KEY CLUSTERED 
(
	[venta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Version]    Script Date: 07/04/2016 9:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Version](
	[versionMayor] [int] NULL,
	[versionMenor] [int] NULL,
	[patch] [int] NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tbl_detalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_tbl_detalleVenta_tbl_producto] FOREIGN KEY([producto_id])
REFERENCES [dbo].[tbl_producto] ([producto_id])
GO
ALTER TABLE [dbo].[tbl_detalleVenta] CHECK CONSTRAINT [FK_tbl_detalleVenta_tbl_producto]
GO
ALTER TABLE [dbo].[tbl_detalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_tbl_detalleVenta_tbl_venta] FOREIGN KEY([venta_id])
REFERENCES [dbo].[tbl_venta] ([venta_id])
GO
ALTER TABLE [dbo].[tbl_detalleVenta] CHECK CONSTRAINT [FK_tbl_detalleVenta_tbl_venta]
GO
ALTER TABLE [dbo].[tbl_venta]  WITH CHECK ADD  CONSTRAINT [FK_tbl_venta_tbl_cliente] FOREIGN KEY([cliente_id])
REFERENCES [dbo].[tbl_cliente] ([cliente_id])
GO
ALTER TABLE [dbo].[tbl_venta] CHECK CONSTRAINT [FK_tbl_venta_tbl_cliente]
GO
USE [master]
GO
ALTER DATABASE [Venta] SET  READ_WRITE 
GO
