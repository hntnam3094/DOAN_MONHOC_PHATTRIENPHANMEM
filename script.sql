USE [master]
GO
/****** Object:  Database [SALON_AND_SPA]    Script Date: 8/15/2020 3:29:31 PM ******/
CREATE DATABASE [SALON_AND_SPA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SALON_AND_SPA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SALON_AND_SPA.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SALON_AND_SPA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SALON_AND_SPA_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SALON_AND_SPA] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SALON_AND_SPA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SALON_AND_SPA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET ARITHABORT OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SALON_AND_SPA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SALON_AND_SPA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SALON_AND_SPA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SALON_AND_SPA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET RECOVERY FULL 
GO
ALTER DATABASE [SALON_AND_SPA] SET  MULTI_USER 
GO
ALTER DATABASE [SALON_AND_SPA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SALON_AND_SPA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SALON_AND_SPA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SALON_AND_SPA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SALON_AND_SPA] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SALON_AND_SPA', N'ON'
GO
USE [SALON_AND_SPA]
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[USERNAME] [nchar](10) NOT NULL,
	[PASSWORD] [nvarchar](100) NOT NULL,
	[TYPE] [int] NULL DEFAULT ((0)),
	[HoatDong] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BILL]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdKH] [int] NOT NULL,
	[IdRoom] [int] NOT NULL,
	[TOTALPRICE] [float] NULL,
	[DATEIN] [datetime] NULL,
	[Status] [int] NULL DEFAULT ((0)),
	[Discount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BILLINFO]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILLINFO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDBILL] [int] NOT NULL,
	[IDPRO_SER] [int] NOT NULL,
	[COUNT] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CATEGORY]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gio_TV]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gio_TV](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Gio] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SDT] [nvarchar](10) NOT NULL,
	[USERNAME] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[NamSinh] [date] NOT NULL,
	[CMND] [char](12) NOT NULL,
	[ADDRESS] [nvarchar](100) NULL,
	[EMAIL] [nvarchar](100) NULL,
	[HOATDONG] [int] NULL DEFAULT ((0)),
	[TICHDIEM] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LICHHEN_NV]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LICHHEN_NV](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Gio_TV] [int] NOT NULL,
	[ID_NV_TV] [int] NOT NULL,
	[Id_KH] [int] NOT NULL,
	[NOIDUNG] [nvarchar](1000) NULL,
	[Status] [int] NULL DEFAULT ((0)),
	[Ngay] [date] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAI_NV]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI_NV](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NV_TuVan]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NV_TuVan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](100) NOT NULL,
	[NamSinh] [date] NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[DIACHI] [nvarchar](100) NOT NULL,
	[CMND] [nvarchar](15) NOT NULL,
	[SDT] [nchar](10) NOT NULL,
	[ID_LOAINV] [int] NOT NULL,
	[HoatDong_TV] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PRO_SER]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRO_SER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](100) NOT NULL,
	[IDCATEGORY] [int] NOT NULL,
	[SOLUONG] [int] NULL,
	[MOTA] [nvarchar](1000) NULL,
	[Price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 8/15/2020 3:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL DEFAULT ((0)),
	[VIP] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ACCOUNT] ([USERNAME], [PASSWORD], [TYPE], [HoatDong]) VALUES (N'nam123    ', N'123', 0, 1)
INSERT [dbo].[ACCOUNT] ([USERNAME], [PASSWORD], [TYPE], [HoatDong]) VALUES (N'namhaha   ', N'123', 1, 0)
INSERT [dbo].[ACCOUNT] ([USERNAME], [PASSWORD], [TYPE], [HoatDong]) VALUES (N'thanhnam  ', N'123', 0, 0)
SET IDENTITY_INSERT [dbo].[BILL] ON 

INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (7, 1, 1, 300000, CAST(N'2020-07-16 11:58:24.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (8, 1, 1, 522000, CAST(N'2020-07-16 12:00:00.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (9, 1, 1, 138000, CAST(N'2020-07-16 12:48:52.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (10, 1, 1, 290000, CAST(N'2020-07-26 08:38:27.000' AS DateTime), 1, 50)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (11, 1, 1, 228000, CAST(N'2020-07-26 10:39:17.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (12, 1, 1, 220000, CAST(N'2020-07-26 11:06:49.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (13, 1, 1, 220000, CAST(N'2020-07-26 11:08:19.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (14, 1, 1, 580000, CAST(N'2020-07-26 11:09:05.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (15, 1, 5, 220000, CAST(N'2020-07-26 11:13:03.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (16, 1, 1, 250000, CAST(N'2020-07-26 11:13:13.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (17, 1, 6, 250000, CAST(N'2020-07-26 11:13:22.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (18, 1, 1, 580000, CAST(N'2020-07-26 11:15:34.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (19, 1, 1, 220000, CAST(N'2020-07-26 11:16:56.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (20, 1, 1, 300000, CAST(N'2020-07-26 11:20:32.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (26, 1, 1, 300000, CAST(N'2020-07-26 14:27:14.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (27, 1, 1, 108000, CAST(N'2020-07-27 10:24:14.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (28, 1, 1, 630000, CAST(N'2020-07-27 10:24:50.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (29, 1, 6, 130000, CAST(N'2020-07-27 10:25:19.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (33, 1, 1, 630000, CAST(N'2020-07-27 10:28:25.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (34, 1, 6, 250000, CAST(N'2020-07-27 10:30:06.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (35, 1, 3, 0, CAST(N'2020-07-27 10:30:14.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (36, 1, 6, 100000, CAST(N'2020-07-27 10:30:48.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (37, 1, 5, 50000, CAST(N'2020-07-27 10:35:42.000' AS DateTime), 1, 50)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (38, 1, 5, 0, CAST(N'2020-07-27 10:36:11.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (39, 1, 5, 0, CAST(N'2020-07-27 10:36:19.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (46, 1, 1, 210000, CAST(N'2020-08-02 13:46:46.000' AS DateTime), 1, 30)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (47, 1, 1, 280000, CAST(N'2020-08-02 13:47:33.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (48, 1, 5, 270000, CAST(N'2020-08-02 13:49:40.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (49, 1, 5, 300000, CAST(N'2020-08-02 13:51:02.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (51, 1, 5, 0, CAST(N'2020-08-02 13:51:21.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (53, 1, 5, 400000, CAST(N'2020-08-02 14:36:21.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (54, 1, 5, 0, CAST(N'2020-08-02 14:36:54.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (55, 1, 5, 0, CAST(N'2020-08-02 14:37:02.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (56, 1, 5, 400000, CAST(N'2020-08-02 14:39:17.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (57, 1, 5, 0, CAST(N'2020-08-02 14:48:48.483' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (58, 1, 5, 0, CAST(N'2020-08-02 14:51:10.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (59, 1, 5, 100000, CAST(N'2020-08-02 14:54:39.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (61, 1, 5, 0, CAST(N'2020-08-02 14:55:25.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (62, 1, 5, 0, CAST(N'2020-08-02 14:56:26.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (63, 6, 6, 270000, CAST(N'2020-08-03 10:47:59.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (64, 1, 1, 330000, CAST(N'2020-08-03 10:56:09.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (65, 1, 3, 60000, CAST(N'2020-08-03 11:40:19.000' AS DateTime), 1, 50)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (66, 6, 1, 300000, CAST(N'2020-08-03 11:40:45.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (67, 1, 3, 300000, CAST(N'2020-08-03 13:04:57.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (68, 6, 1, 3230000, CAST(N'2020-08-03 13:09:16.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (71, 1, 3, 300000, CAST(N'2020-08-03 16:09:11.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (72, 1, 5, 490000, CAST(N'2020-08-03 17:23:22.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (73, 1, 3, 819000, CAST(N'2020-08-03 17:25:07.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (74, 1, 1, 120000, CAST(N'2020-08-03 17:27:49.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (75, 1, 5, 490000, CAST(N'2020-08-03 17:30:42.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (76, 7, 6, 30000, CAST(N'2020-08-06 07:43:02.000' AS DateTime), 1, 100)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1076, 1, 5, 490000, CAST(N'2020-08-10 11:29:37.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1078, 1, 5, 0, CAST(N'2020-08-10 11:29:58.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1079, 1, 5, 0, CAST(N'2020-08-10 11:30:08.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1080, 1, 5, 0, CAST(N'2020-08-10 11:30:28.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1082, 1, 5, 120000, CAST(N'2020-08-10 11:36:23.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1083, 6, 6, 450000, CAST(N'2020-08-10 12:03:42.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1084, 1, 1, 600000, CAST(N'2020-08-10 12:32:46.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1085, 1, 5, 1000000, CAST(N'2020-08-10 12:35:10.000' AS DateTime), 1, 20)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1086, 1, 5, 198000, CAST(N'2020-08-12 16:02:03.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1087, 5, 2, 96000, CAST(N'2020-08-12 17:05:15.000' AS DateTime), 1, 20)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1089, 5, 5, 0, CAST(N'2020-08-12 18:36:56.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1090, 1, 5, 0, CAST(N'2020-08-12 18:37:37.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1097, 1, 1, 540000, CAST(N'2020-08-13 13:31:46.000' AS DateTime), 1, 20)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1098, 1, 3, 0, CAST(N'2019-08-14 08:45:18.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1100, 1007, 1, 240000, CAST(N'2019-08-14 08:57:39.000' AS DateTime), 1, 10)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1101, 1007, 5, 492000, CAST(N'2020-08-14 09:33:31.000' AS DateTime), 1, 20)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1102, 6, 5, 530000, CAST(N'2020-08-15 13:00:09.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1103, 1, 3, 0, CAST(N'2020-08-15 14:25:42.000' AS DateTime), 1, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1116, 6, 3, 0, CAST(N'2020-08-15 15:14:05.000' AS DateTime), 0, 0)
INSERT [dbo].[BILL] ([ID], [IdKH], [IdRoom], [TOTALPRICE], [DATEIN], [Status], [Discount]) VALUES (1117, 1, 4, 0, CAST(N'2020-08-15 15:26:03.000' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[BILL] OFF
SET IDENTITY_INSERT [dbo].[BILLINFO] ON 

INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (12, 7, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (13, 7, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (14, 8, 4, 4)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (15, 9, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (16, 8, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (17, 11, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (18, 20, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (21, 27, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (22, 29, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (23, 34, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (24, 34, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (25, 36, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (26, 37, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (29, 46, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (30, 47, 7, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (31, 38, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (32, 38, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (33, 59, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (34, 63, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (35, 64, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (36, 65, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (37, 66, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (38, 67, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (39, 68, 4, 10)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (40, 68, 3, 5)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (41, 68, 9, 5)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (44, 71, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (45, 61, 5, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (46, 61, 6, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (47, 73, 5, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (48, 73, 7, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (49, 73, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (50, 73, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (51, 74, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (52, 76, 9, 5)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1053, 1082, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1054, 1083, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1055, 1083, 4, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1056, 1084, 9, 2)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1057, 1085, 7, 5)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1058, 1086, 3, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1059, 1086, 8, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1060, 1087, 8, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1061, 1097, 9, 2)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1062, 1098, 3, 5)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1066, 66, 3, -2)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1067, 1100, 8, 2)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1068, 1101, 9, 1)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1069, 1101, 8, 2)
INSERT [dbo].[BILLINFO] ([ID], [IDBILL], [IDPRO_SER], [COUNT]) VALUES (1070, 1102, 3, 5)
SET IDENTITY_INSERT [dbo].[BILLINFO] OFF
SET IDENTITY_INSERT [dbo].[CATEGORY] ON 

INSERT [dbo].[CATEGORY] ([ID], [NAME]) VALUES (1, N'Sản phẩm làm đẹp, và chăm sóc sắc đẹp')
INSERT [dbo].[CATEGORY] ([ID], [NAME]) VALUES (2, N'Dịch vụ làm đẹp')
INSERT [dbo].[CATEGORY] ([ID], [NAME]) VALUES (5, N'Dịch vụ mới')
INSERT [dbo].[CATEGORY] ([ID], [NAME]) VALUES (11, N'Dịch vụ 2 giờ')
SET IDENTITY_INSERT [dbo].[CATEGORY] OFF
SET IDENTITY_INSERT [dbo].[Gio_TV] ON 

INSERT [dbo].[Gio_TV] ([ID], [Gio]) VALUES (1, 7)
INSERT [dbo].[Gio_TV] ([ID], [Gio]) VALUES (2, 8)
INSERT [dbo].[Gio_TV] ([ID], [Gio]) VALUES (3, 9)
INSERT [dbo].[Gio_TV] ([ID], [Gio]) VALUES (4, 10)
INSERT [dbo].[Gio_TV] ([ID], [Gio]) VALUES (5, 13)
INSERT [dbo].[Gio_TV] ([ID], [Gio]) VALUES (6, 14)
INSERT [dbo].[Gio_TV] ([ID], [Gio]) VALUES (7, 15)
INSERT [dbo].[Gio_TV] ([ID], [Gio]) VALUES (8, 16)
SET IDENTITY_INSERT [dbo].[Gio_TV] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([Id], [SDT], [USERNAME], [GioiTinh], [NamSinh], [CMND], [ADDRESS], [EMAIL], [HOATDONG], [TICHDIEM]) VALUES (1, N'0378918649', N'Thành Nam', N'Nam', CAST(N'1998-10-22' AS Date), N'281166959   ', N'HCMC', N'hntnam98@gmail.com', 0, 0)
INSERT [dbo].[KHACHHANG] ([Id], [SDT], [USERNAME], [GioiTinh], [NamSinh], [CMND], [ADDRESS], [EMAIL], [HOATDONG], [TICHDIEM]) VALUES (3, N'0378918649', N'Hòàng Nam', N'Nam', CAST(N'2020-07-15' AS Date), N'281166959   ', N'HCMC', N'dsads@gmail.com', 1, 0)
INSERT [dbo].[KHACHHANG] ([Id], [SDT], [USERNAME], [GioiTinh], [NamSinh], [CMND], [ADDRESS], [EMAIL], [HOATDONG], [TICHDIEM]) VALUES (4, N'0378918649', N'Đăng', N'Nữ', CAST(N'2020-07-15' AS Date), N'281166959   ', N'HCMC', N'nvy@gmail.com', 0, 0)
INSERT [dbo].[KHACHHANG] ([Id], [SDT], [USERNAME], [GioiTinh], [NamSinh], [CMND], [ADDRESS], [EMAIL], [HOATDONG], [TICHDIEM]) VALUES (5, N'0834566525', N'Anh Vinh', N'Nam', CAST(N'1999-07-07' AS Date), N'321950658   ', N'HCMC', N'pvmn1@gmail.com', 1, 0)
INSERT [dbo].[KHACHHANG] ([Id], [SDT], [USERNAME], [GioiTinh], [NamSinh], [CMND], [ADDRESS], [EMAIL], [HOATDONG], [TICHDIEM]) VALUES (6, N'0973407644', N'Anh Lâm', N'Nam', CAST(N'1999-08-05' AS Date), N'025960270   ', N'Bà Hôm', N'lammatloz@gmail.com', 0, 0)
INSERT [dbo].[KHACHHANG] ([Id], [SDT], [USERNAME], [GioiTinh], [NamSinh], [CMND], [ADDRESS], [EMAIL], [HOATDONG], [TICHDIEM]) VALUES (7, N'0935275255', N'Anh Khánh', N'Nam', CAST(N'2020-08-06' AS Date), N'098765412   ', N'HCMC', N'khachdaptrai@gmail.com', 0, 0)
INSERT [dbo].[KHACHHANG] ([Id], [SDT], [USERNAME], [GioiTinh], [NamSinh], [CMND], [ADDRESS], [EMAIL], [HOATDONG], [TICHDIEM]) VALUES (1007, N'0378918649', N'Cô Lý', N'Nữ', CAST(N'2019-08-14' AS Date), N'281166959   ', N'HCMC', N'coly@gmail.com', 0, 0)
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
SET IDENTITY_INSERT [dbo].[LICHHEN_NV] ON 

INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1, 3, 6, 1, N'abc', 1, CAST(N'2020-07-26' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (2, 1, 6, 1, N'avc', 1, CAST(N'2020-07-27' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (5, 1, 6, 1, N'a', 1, CAST(N'2020-07-26' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (7, 4, 6, 1, N'b', 0, CAST(N'2020-07-26' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (8, 6, 6, 5, N'abc', 1, CAST(N'2020-07-26' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (9, 5, 6, 1, N'abc', 0, CAST(N'2020-07-26' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (10, 3, 15, 5, N'Massage tái tạo da mặt', 1, CAST(N'2020-08-03' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (11, 5, 15, 6, N'Lột mụn', 1, CAST(N'2020-08-03' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (12, 4, 17, 7, N'Massage CU', 1, CAST(N'2020-08-07' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (13, 1, 6, 1, N'', 1, CAST(N'2020-08-13' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1012, 3, 17, 5, N'Làm đẹp', 1, CAST(N'2020-08-12' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1013, 4, 17, 6, N'Khách hàng quen! đến massage đá nóng! 
Khách hàng muốn được massage nhẹ trước
tip 100k', 0, CAST(N'2020-08-13' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1014, 2, 6, 1007, N'Đến massage đá nóng', 1, CAST(N'2019-08-14' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1015, 2, 15, 1007, N'Massage Đá nóng', 1, CAST(N'2020-08-14' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1016, 3, 6, 1, N'3ee', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1017, 1, 6, 1, N'', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1019, 4, 6, 1, N'', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1020, 2, 6, 1, N'đasa', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1023, 1, 15, 1, N'dsadasfas', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1029, 1, 6, 1, N'hahaha', 0, CAST(N'2020-08-16' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1030, 2, 6, 1, N'hahaha', 0, CAST(N'2020-08-16' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1031, 3, 6, 1, N'hahaha', 0, CAST(N'2020-08-16' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1032, 1, 17, 6, N'dsadsa', 0, CAST(N'2020-08-16' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1033, 6, 6, 7, N'đâsd', 1, CAST(N'2020-08-16' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1034, 1, 20, 7, N'abc xyz', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1037, 5, 20, 1, N'dsfdsfs', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1038, 4, 20, 4, N'', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1039, 1, 18, 6, N'abc', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1040, 2, 15, 1, N'', 1, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[LICHHEN_NV] ([ID], [ID_Gio_TV], [ID_NV_TV], [Id_KH], [NOIDUNG], [Status], [Ngay]) VALUES (1041, 3, 15, 1, N'', 1, CAST(N'2020-08-15' AS Date))
SET IDENTITY_INSERT [dbo].[LICHHEN_NV] OFF
SET IDENTITY_INSERT [dbo].[LOAI_NV] ON 

INSERT [dbo].[LOAI_NV] ([ID], [NAME]) VALUES (1, N'Nhân viên spa')
INSERT [dbo].[LOAI_NV] ([ID], [NAME]) VALUES (2, N'Nhân viên lễ tân')
SET IDENTITY_INSERT [dbo].[LOAI_NV] OFF
SET IDENTITY_INSERT [dbo].[NV_TuVan] ON 

INSERT [dbo].[NV_TuVan] ([ID], [NAME], [NamSinh], [GioiTinh], [DIACHI], [CMND], [SDT], [ID_LOAINV], [HoatDong_TV]) VALUES (6, N'Điêu Thuyền', CAST(N'1999-10-22' AS Date), N'Nữ', N'HCMC', N'281166959', N'0378918649', 1, 0)
INSERT [dbo].[NV_TuVan] ([ID], [NAME], [NamSinh], [GioiTinh], [DIACHI], [CMND], [SDT], [ID_LOAINV], [HoatDong_TV]) VALUES (14, N'Phước Vinh', CAST(N'1998-10-22' AS Date), N'Nữ', N'HCMC', N'281166959', N'0378918649', 2, 0)
INSERT [dbo].[NV_TuVan] ([ID], [NAME], [NamSinh], [GioiTinh], [DIACHI], [CMND], [SDT], [ID_LOAINV], [HoatDong_TV]) VALUES (15, N'Hải đăng', CAST(N'1998-10-22' AS Date), N'Nữ', N'HCMC', N'291188676', N'0378918649', 1, 0)
INSERT [dbo].[NV_TuVan] ([ID], [NAME], [NamSinh], [GioiTinh], [DIACHI], [CMND], [SDT], [ID_LOAINV], [HoatDong_TV]) VALUES (17, N'Cô Long', CAST(N'1998-10-22' AS Date), N'Nữ', N'HCMC', N'281166959', N'0378918649', 1, 0)
INSERT [dbo].[NV_TuVan] ([ID], [NAME], [NamSinh], [GioiTinh], [DIACHI], [CMND], [SDT], [ID_LOAINV], [HoatDong_TV]) VALUES (18, N'Dương quá', CAST(N'1998-10-22' AS Date), N'Nữ', N'HCMC', N'281166959', N'0378918649', 1, 0)
INSERT [dbo].[NV_TuVan] ([ID], [NAME], [NamSinh], [GioiTinh], [DIACHI], [CMND], [SDT], [ID_LOAINV], [HoatDong_TV]) VALUES (20, N'Hải đăng', CAST(N'1998-10-22' AS Date), N'Nữ', N'HCMC', N'291188676', N'0378918649', 1, 0)
INSERT [dbo].[NV_TuVan] ([ID], [NAME], [NamSinh], [GioiTinh], [DIACHI], [CMND], [SDT], [ID_LOAINV], [HoatDong_TV]) VALUES (21, N'Điêu Thuyền', CAST(N'1999-10-22' AS Date), N'Nữ', N'HCMC', N'281166959', N'0378918649', 2, 0)
INSERT [dbo].[NV_TuVan] ([ID], [NAME], [NamSinh], [GioiTinh], [DIACHI], [CMND], [SDT], [ID_LOAINV], [HoatDong_TV]) VALUES (22, N'Điêu Thuyền', CAST(N'1999-10-22' AS Date), N'Nữ', N'HCMC', N'281166959', N'0378918649', 2, 0)
INSERT [dbo].[NV_TuVan] ([ID], [NAME], [NamSinh], [GioiTinh], [DIACHI], [CMND], [SDT], [ID_LOAINV], [HoatDong_TV]) VALUES (23, N'Xuka', CAST(N'1999-10-05' AS Date), N'Nam', N'HCMC', N'281166959', N'0378918649', 2, 0)
SET IDENTITY_INSERT [dbo].[NV_TuVan] OFF
SET IDENTITY_INSERT [dbo].[PRO_SER] ON 

INSERT [dbo].[PRO_SER] ([ID], [NAME], [IDCATEGORY], [SOLUONG], [MOTA], [Price]) VALUES (3, N'Trị hói', 1, 82, N'Trị hói tận góc', 100000)
INSERT [dbo].[PRO_SER] ([ID], [NAME], [IDCATEGORY], [SOLUONG], [MOTA], [Price]) VALUES (4, N'Nặn mụn', 2, 0, N'Nặn mụn tận góc', 120000)
INSERT [dbo].[PRO_SER] ([ID], [NAME], [IDCATEGORY], [SOLUONG], [MOTA], [Price]) VALUES (5, N'Massage đá nóng', 2, 0, N'Massage đá nóng giúp làm da mịn và căng', 240000)
INSERT [dbo].[PRO_SER] ([ID], [NAME], [IDCATEGORY], [SOLUONG], [MOTA], [Price]) VALUES (6, N'Massage trà xanh', 2, 0, N'Massage Trà xanh giúp làm loại bỏ bả nhờn', 250000)
INSERT [dbo].[PRO_SER] ([ID], [NAME], [IDCATEGORY], [SOLUONG], [MOTA], [Price]) VALUES (7, N'Massage trà xanh, hạt chia', 2, 0, N'Massage Trà xanh giúp làm loại bỏ bả nhờn', 250000)
INSERT [dbo].[PRO_SER] ([ID], [NAME], [IDCATEGORY], [SOLUONG], [MOTA], [Price]) VALUES (8, N'Dầu gội mượt tóc', 1, 141, N'Làm cho tóc mượt ', 120000)
INSERT [dbo].[PRO_SER] ([ID], [NAME], [IDCATEGORY], [SOLUONG], [MOTA], [Price]) VALUES (9, N'Massage trà xanh mix bánh trung thu', 5, 0, N'Ngon, bổ rẻ', 300000)
SET IDENTITY_INSERT [dbo].[PRO_SER] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([ID], [Name], [Status], [VIP]) VALUES (1, N'Phòng 1', 0, 0)
INSERT [dbo].[Room] ([ID], [Name], [Status], [VIP]) VALUES (2, N'Phòng 2', 0, 0)
INSERT [dbo].[Room] ([ID], [Name], [Status], [VIP]) VALUES (3, N'Phòng 3', 1, 0)
INSERT [dbo].[Room] ([ID], [Name], [Status], [VIP]) VALUES (4, N'Phòng 4', 1, 0)
INSERT [dbo].[Room] ([ID], [Name], [Status], [VIP]) VALUES (5, N'Phòng 5', 0, 1)
INSERT [dbo].[Room] ([ID], [Name], [Status], [VIP]) VALUES (6, N'Phòng 6', 0, 1)
SET IDENTITY_INSERT [dbo].[Room] OFF
ALTER TABLE [dbo].[BILL]  WITH CHECK ADD FOREIGN KEY([IdRoom])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[BILL]  WITH CHECK ADD FOREIGN KEY([IdKH])
REFERENCES [dbo].[KHACHHANG] ([Id])
GO
ALTER TABLE [dbo].[BILLINFO]  WITH CHECK ADD FOREIGN KEY([IDBILL])
REFERENCES [dbo].[BILL] ([ID])
GO
ALTER TABLE [dbo].[BILLINFO]  WITH CHECK ADD FOREIGN KEY([IDPRO_SER])
REFERENCES [dbo].[PRO_SER] ([ID])
GO
ALTER TABLE [dbo].[LICHHEN_NV]  WITH CHECK ADD FOREIGN KEY([ID_Gio_TV])
REFERENCES [dbo].[Gio_TV] ([ID])
GO
ALTER TABLE [dbo].[LICHHEN_NV]  WITH CHECK ADD FOREIGN KEY([Id_KH])
REFERENCES [dbo].[KHACHHANG] ([Id])
GO
ALTER TABLE [dbo].[LICHHEN_NV]  WITH CHECK ADD FOREIGN KEY([ID_NV_TV])
REFERENCES [dbo].[NV_TuVan] ([ID])
GO
ALTER TABLE [dbo].[NV_TuVan]  WITH CHECK ADD FOREIGN KEY([ID_LOAINV])
REFERENCES [dbo].[LOAI_NV] ([ID])
GO
ALTER TABLE [dbo].[PRO_SER]  WITH CHECK ADD FOREIGN KEY([IDCATEGORY])
REFERENCES [dbo].[CATEGORY] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[getKhachHangRoom]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
		CREATE PROC [dbo].[getKhachHangRoom]
		@idRoom INT
		AS
        BEGIN
				SELECT dbo.Room.Name, dbo.Room.VIP,dbo.KHACHHANG.USERNAME, dbo.BILL.DATEIN, dbo.NV_TuVan.NAME  AS 'NameNV'
		FROM dbo.KHACHHANG, dbo.BILL, dbo.Room, dbo.NV_TuVan, dbo.LICHHEN_NV 
		WHERE  dbo.NV_TuVan.ID = dbo.LICHHEN_NV.ID_NV_TV  AND dbo.LICHHEN_NV.Id_KH = dbo.KHACHHANG.Id  AND dbo.KHACHHANG.Id = dbo.BILL.IdKH AND dbo.BILL.IdRoom = dbo.Room.ID AND dbo.BILL.Status = 0  AND dbo.LICHHEN_NV.Status = 1 AND  dbo.Room.ID = @idRoom
		GROUP BY dbo.Room.Name, dbo.Room.VIP,dbo.KHACHHANG.USERNAME, dbo.BILL.DATEIN, dbo.NV_TuVan.NAME

		END
GO
/****** Object:  StoredProcedure [dbo].[USP_ADDNewProSer]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[USP_ADDNewProSer]
												  @IdBill INT, @IdroSer INT, @Count INT
												  AS
                                                  BEGIN
														DECLARE @Category INT 
														SELECT @Category = IDCATEGORY FROM dbo.PRO_SER WHERE ID = @IdroSer
														DECLARE @IDBI INT
														SELECT @IDBI = ID FROM dbo.BILLINFO WHERE IDBILL = @IdBill AND IDPRO_SER = @IdroSer
                                                  		DECLARE @SL INT
														SELECT @SL = COUNT FROM dbo.BILLINFO WHERE IDBILL = @IdBill AND IDPRO_SER = @IdroSer
														DECLARE @SL_after_Count INT = @SL + @Count
														IF(@SL IS NULL)
															BEGIN
																INSERT INTO dbo.BILLINFO
																VALUES  ( @IdBill, -- IDBILL - int
																          @IdroSer, -- IDPRO_SER - int
																          @Count  -- COUNT - int
																          )
																IF(@Category = 1)
																BEGIN 
																	UPDATE dbo.PRO_SER SET SOLUONG = SOLUONG - @Count WHERE ID = @IdroSer
																END	
															END
														ELSE IF(@SL_after_Count<1)
															BEGIN
																DELETE FROM dbo.BILLINFO WHERE ID = @IDBI
																IF(@Category = 1)
																BEGIN 
																	UPDATE dbo.PRO_SER SET SOLUONG = SOLUONG - @Count WHERE ID = @IdroSer
																END	
															END
														ELSE IF(@SL>=1)
															BEGIN
																UPDATE dbo.BILLINFO SET COUNT=COUNT+@Count WHERE ID = @IDBI
																IF(@Category = 1)
																BEGIN 
																	UPDATE dbo.PRO_SER SET SOLUONG = SOLUONG - @Count WHERE ID = @IdroSer
																END	
															END
                                                  END
GO
/****** Object:  StoredProcedure [dbo].[USP_ChuyenPhong]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_ChuyenPhong]
												@idRoom1 INT, @idRoom2 INT
												AS
                                                BEGIN
													UPDATE dbo.BILL SET IdRoom = @idRoom2 WHERE IdRoom = @idRoom1
													UPDATE dbo.Room SET Status = 0 WHERE ID = @idRoom1
													UPDATE dbo.Room SET Status = 1 WHERE ID = @idRoom2
												END	
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccount]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetAccount]
			@username NVARCHAR(100), @password NVARCHAR(100)
			AS
            BEGIN
            	SELECT * FROM dbo.ACCOUNT WHERE USERNAME = @username AND	PASSWORD = @password
            END


GO
/****** Object:  StoredProcedure [dbo].[USP_GetChitiet_LichHen]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROC [dbo].[USP_GetChitiet_LichHen]
						 @idLH INT
						 AS
                         BEGIN
							SELECT  dbo.LICHHEN_NV.ID,ID_Gio_TV,dbo.KHACHHANG.USERNAME,EMAIL, Gio, dbo.NV_TuVan.NAME, dbo.KHACHHANG.ADDRESS, dbo.KHACHHANG.SDT, NOIDUNG, Ngay
							FROM dbo.LICHHEN_NV, dbo.Gio_TV, dbo.NV_TuVan, dbo.KHACHHANG
							 WHERE dbo.LICHHEN_NV.ID_Gio_TV = dbo.Gio_TV.ID AND dbo.NV_TuVan.ID = dbo.LICHHEN_NV.ID_NV_TV AND dbo.KHACHHANG.Id = dbo.LICHHEN_NV.Id_KH AND dbo.LICHHEN_NV.ID = @idLH
						 END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetLichHen]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetLichHen]
					@Startday DATETIME, @Endday DATETIME
					AS
                    BEGIN
						SELECT dbo.LICHHEN_NV.ID, ID_Gio_TV, dbo.KHACHHANG.USERNAME,EMAIL, Gio, dbo.NV_TuVan.NAME, dbo.KHACHHANG.ADDRESS, dbo.KHACHHANG.SDT, NOIDUNG, Ngay
						FROM dbo.LICHHEN_NV, dbo.Gio_TV, dbo.NV_TuVan, dbo.KHACHHANG
						 WHERE dbo.LICHHEN_NV.ID_Gio_TV = dbo.Gio_TV.ID AND dbo.NV_TuVan.ID = dbo.LICHHEN_NV.ID_NV_TV AND dbo.KHACHHANG.Id = dbo.LICHHEN_NV.Id_KH AND dbo.LICHHEN_NV.Status = 0 AND  ngay BETWEEN @Startday AND @Endday 
					END
GO
/****** Object:  StoredProcedure [dbo].[usp_getlisttime]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_getlisttime]
		@timeming INT
		AS
        BEGIN
			DECLARE	@GioMax INT
			SELECT @GioMax = MAX(Gio) FROM dbo.Gio_TV
			DECLARE	@GioMin INT
			SELECT @GioMin = MIN(Gio) FROM dbo.Gio_TV 
			WHILE(@GioMax>@GioMin)
			BEGIN
				SELECT * FROM dbo.Gio_TV WHERE Gio = @GioMax
				SET @GioMax = @GioMax - @timeming
            END	
			
		END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetThongKe]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetThongKe]
		@datefrom DATETIME, @dateto DATETIME
		AS
        BEGIN
			SELECT dbo.PRO_SER.NAME, dbo.BILLINFO.COUNT, dbo.BILLINFO.COUNT*dbo.PRO_SER.Price AS PRICE, dbo.BILL.Discount,  ((dbo.BILLINFO.COUNT*dbo.PRO_SER.Price)*(dbo.BILL.Discount%100))/100 AS AFTERDISCOUNT
			FROM dbo.KHACHHANG, dbo.BILL, dbo.Room, dbo.BILLINFO, dbo.PRO_SER 
			WHERE dbo.KHACHHANG.Id = dbo.BILL.IdKH AND dbo.BILL.IdRoom = dbo.Room.ID AND dbo.BILL.ID = dbo.BILLINFO.IDBILL AND dbo.BILLINFO.IDPRO_SER=dbo.PRO_SER.ID  AND DATEIN BETWEEN  @datefrom AND @dateto 
			GROUP BY dbo.PRO_SER.NAME, dbo.BILLINFO.COUNT, dbo.BILL.TOTALPRICE, dbo.BILL.Discount, dbo.PRO_SER.Price
		END

GO
/****** Object:  StoredProcedure [dbo].[Usp_getThongKeByNhanVien]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_getThongKeByNhanVien]
		@datefrom DATETIME, @dateto DATETIME, @idnv INT
		AS
        BEGIN
		SELECT dbo.PRO_SER.NAME, dbo.BILLINFO.COUNT, dbo.BILLINFO.COUNT*dbo.PRO_SER.Price AS PRICE, dbo.BILL.Discount,  ((dbo.BILLINFO.COUNT*dbo.PRO_SER.Price)*(dbo.BILL.Discount%100))/100 AS AFTERDISCOUNT
			FROM dbo.KHACHHANG, dbo.BILL, dbo.Room, dbo.BILLINFO, dbo.PRO_SER , dbo.LICHHEN_NV, dbo.NV_TuVan
			WHERE dbo.KHACHHANG.Id = dbo.LICHHEN_NV.ID AND dbo.LICHHEN_NV.ID_NV_TV = dbo.NV_TuVan.ID AND dbo.KHACHHANG.Id = dbo.BILL.IdKH AND dbo.BILL.IdRoom = dbo.Room.ID AND dbo.BILL.ID = dbo.BILLINFO.IDBILL AND dbo.BILLINFO.IDPRO_SER=dbo.PRO_SER.ID  AND DATEIN BETWEEN  @datefrom AND @dateto  AND dbo.NV_TuVan.ID = @idnv
			GROUP BY dbo.PRO_SER.NAME, dbo.BILLINFO.COUNT, dbo.BILL.TOTALPRICE, dbo.BILL.Discount, dbo.PRO_SER.Price 
		END
GO
/****** Object:  StoredProcedure [dbo].[USP_MoPhong]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[USP_MoPhong]
											@idRoom INT, @idKH INT, @totalprice FLOAT, @datein DATETIME, @status INT, @discount int 
											AS
                                            BEGIN
												UPDATE dbo.Room SET Status = 1 WHERE ID = @idRoom
												INSERT INTO dbo.BILL
												        ( IdKH ,
												          IdRoom ,
												          TOTALPRICE ,
												          DATEIN ,
												          Status ,
												          Discount
												        )
												VALUES  ( @idKH , -- IdKH - int
												          @idRoom , -- IdRoom - int
												          @totalprice , -- TOTALPRICE - float
												          @datein , -- DATEIN - datetime
												          @status , -- Status - int
												          @discount  -- Discount - int
												        )
											END
GO
/****** Object:  StoredProcedure [dbo].[USP_ThanhToan]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[USP_ThanhToan]
												  @IdKH INT, @idRoom INT, @totalPrice FLOAT, @Discount INT	
												  AS
												  BEGIN
												  DECLARE @idBillUnCheck INT
														SELECT @idBillUnCheck = ID FROM dbo.BILL WHERE IdKH = @IdKH AND IdRoom = @idRoom AND Status = 0
														IF(@idBillUnCheck>0)
														BEGIN
														UPDATE dbo.BILL SET TOTALPRICE = @totalPrice, Discount = @Discount, Status =1 WHERE ID= @idBillUnCheck
														END

														UPDATE dbo.Room SET Status = 0 WHERE ID = @idRoom
												  END	
GO
/****** Object:  StoredProcedure [dbo].[USP_XoaPhong]    Script Date: 8/15/2020 3:29:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   
											CREATE PROC [dbo].[USP_XoaPhong]
											@idRoom INT
											AS
                                            BEGIN
												DELETE dbo.BILL WHERE IdRoom = @idRoom AND Status = 0;
                                            	UPDATE dbo.Room SET Status = 0 WHERE ID = @idRoom
                                            END
GO
USE [master]
GO
ALTER DATABASE [SALON_AND_SPA] SET  READ_WRITE 
GO
