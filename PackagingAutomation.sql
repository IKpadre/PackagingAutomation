USE [master]
GO
/****** Object:  Database [PackagingAutomationDB]    Script Date: 25.03.2025 21:58:19 ******/
CREATE DATABASE [PackagingAutomationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PackagingAutomationDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PackagingAutomationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PackagingAutomationDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PackagingAutomationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PackagingAutomationDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PackagingAutomationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PackagingAutomationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PackagingAutomationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PackagingAutomationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PackagingAutomationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PackagingAutomationDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PackagingAutomationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PackagingAutomationDB] SET  MULTI_USER 
GO
ALTER DATABASE [PackagingAutomationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PackagingAutomationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PackagingAutomationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PackagingAutomationDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PackagingAutomationDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PackagingAutomationDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PackagingAutomationDB', N'ON'
GO
ALTER DATABASE [PackagingAutomationDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [PackagingAutomationDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PackagingAutomationDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distributors]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distributors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Distributors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flavors]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flavors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ProductTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Flavors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormatTubes]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormatTubes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FormatTubes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DistributorId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[Deadline] [datetime2](7) NOT NULL,
	[Priority] [bigint] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackagingMachines]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackagingMachines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[ProductId] [int] NULL,
	[ProductionLineId] [int] NOT NULL,
 CONSTRAINT [PK_PackagingMachines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionLines]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionLines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductionLines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionSchedules]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionSchedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MachineId] [int] NOT NULL,
	[OrderId] [int] NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[ReconfigType] [int] NOT NULL,
 CONSTRAINT [PK_ProductionSchedules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrademarkId] [int] NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[FlavorId] [int] NOT NULL,
	[WeightId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trademarks]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trademarks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Trademarks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Weights]    Script Date: 25.03.2025 21:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weights](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grams] [bigint] NOT NULL,
	[Performance] [bigint] NOT NULL,
	[FormatTubeId] [int] NOT NULL,
 CONSTRAINT [PK_Weights] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Flavors_ProductTypeId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_Flavors_ProductTypeId] ON [dbo].[Flavors]
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_DistributorId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_DistributorId] ON [dbo].[Orders]
(
	[DistributorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_ProductId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_ProductId] ON [dbo].[Orders]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PackagingMachines_ProductId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_PackagingMachines_ProductId] ON [dbo].[PackagingMachines]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PackagingMachines_ProductionLineId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_PackagingMachines_ProductionLineId] ON [dbo].[PackagingMachines]
(
	[ProductionLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductionSchedules_MachineId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_ProductionSchedules_MachineId] ON [dbo].[ProductionSchedules]
(
	[MachineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductionSchedules_OrderId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_ProductionSchedules_OrderId] ON [dbo].[ProductionSchedules]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_FlavorId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_Products_FlavorId] ON [dbo].[Products]
(
	[FlavorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_ProductTypeId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_Products_ProductTypeId] ON [dbo].[Products]
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_TrademarkId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_Products_TrademarkId] ON [dbo].[Products]
(
	[TrademarkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_WeightId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_Products_WeightId] ON [dbo].[Products]
(
	[WeightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Weights_FormatTubeId]    Script Date: 25.03.2025 21:58:19 ******/
CREATE NONCLUSTERED INDEX [IX_Weights_FormatTubeId] ON [dbo].[Weights]
(
	[FormatTubeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [Priority]
GO
ALTER TABLE [dbo].[PackagingMachines] ADD  DEFAULT ((0)) FOR [ProductionLineId]
GO
ALTER TABLE [dbo].[ProductionSchedules] ADD  DEFAULT ((0)) FOR [ReconfigType]
GO
ALTER TABLE [dbo].[Flavors]  WITH CHECK ADD  CONSTRAINT [FK_Flavors_ProductTypes_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flavors] CHECK CONSTRAINT [FK_Flavors_ProductTypes_ProductTypeId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Distributors_DistributorId] FOREIGN KEY([DistributorId])
REFERENCES [dbo].[Distributors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Distributors_DistributorId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products_ProductId]
GO
ALTER TABLE [dbo].[PackagingMachines]  WITH CHECK ADD  CONSTRAINT [FK_PackagingMachines_ProductionLines_ProductionLineId] FOREIGN KEY([ProductionLineId])
REFERENCES [dbo].[ProductionLines] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PackagingMachines] CHECK CONSTRAINT [FK_PackagingMachines_ProductionLines_ProductionLineId]
GO
ALTER TABLE [dbo].[PackagingMachines]  WITH CHECK ADD  CONSTRAINT [FK_PackagingMachines_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[PackagingMachines] CHECK CONSTRAINT [FK_PackagingMachines_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_ProductionSchedules_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[ProductionSchedules] CHECK CONSTRAINT [FK_ProductionSchedules_Orders_OrderId]
GO
ALTER TABLE [dbo].[ProductionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_ProductionSchedules_PackagingMachines_MachineId] FOREIGN KEY([MachineId])
REFERENCES [dbo].[PackagingMachines] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductionSchedules] CHECK CONSTRAINT [FK_ProductionSchedules_PackagingMachines_MachineId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Flavors_FlavorId] FOREIGN KEY([FlavorId])
REFERENCES [dbo].[Flavors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Flavors_FlavorId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes_ProductTypeId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Trademarks_TrademarkId] FOREIGN KEY([TrademarkId])
REFERENCES [dbo].[Trademarks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Trademarks_TrademarkId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Weights_WeightId] FOREIGN KEY([WeightId])
REFERENCES [dbo].[Weights] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Weights_WeightId]
GO
ALTER TABLE [dbo].[Weights]  WITH CHECK ADD  CONSTRAINT [FK_Weights_FormatTubes_FormatTubeId] FOREIGN KEY([FormatTubeId])
REFERENCES [dbo].[FormatTubes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Weights] CHECK CONSTRAINT [FK_Weights_FormatTubes_FormatTubeId]
GO
USE [master]
GO
ALTER DATABASE [PackagingAutomationDB] SET  READ_WRITE 
GO
