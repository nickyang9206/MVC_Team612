USE [master]
GO
/****** Object:  Database [JooleMay]    Script Date: 6/4/2019 16:07:08 ******/
CREATE DATABASE [JooleMay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JooleMay', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.NICKSQLSERVERR\MSSQL\DATA\JooleMay.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JooleMay_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.NICKSQLSERVERR\MSSQL\DATA\JooleMay_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [JooleMay] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JooleMay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JooleMay] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JooleMay] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JooleMay] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JooleMay] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JooleMay] SET ARITHABORT OFF 
GO
ALTER DATABASE [JooleMay] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JooleMay] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JooleMay] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JooleMay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JooleMay] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JooleMay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JooleMay] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JooleMay] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JooleMay] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JooleMay] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JooleMay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JooleMay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JooleMay] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JooleMay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JooleMay] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JooleMay] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JooleMay] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JooleMay] SET RECOVERY FULL 
GO
ALTER DATABASE [JooleMay] SET  MULTI_USER 
GO
ALTER DATABASE [JooleMay] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JooleMay] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JooleMay] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JooleMay] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JooleMay] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'JooleMay', N'ON'
GO
ALTER DATABASE [JooleMay] SET QUERY_STORE = OFF
GO
USE [JooleMay]
GO
/****** Object:  Table [dbo].[tblManufacture]    Script Date: 6/4/2019 16:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblManufacture](
	[ManufactureID] [int] IDENTITY(1,1) NOT NULL,
	[ManufactureName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ManufactureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ManufactureName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 6/4/2019 16:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[ProductModel] [nvarchar](50) NULL,
	[ProductType] [varchar](50) NULL,
	[CategoryID] [int] NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[ManufactureID] [int] NULL,
	[SeriesID] [int] NULL,
	[TechnicalSpecificationID] [int] NOT NULL,
	[ProductTypeDetailsID] [int] NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProductCategories]    Script Date: 6/4/2019 16:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblProductCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProductSubCategories]    Script Date: 6/4/2019 16:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductSubCategories](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SubCategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblProductSubCategories] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProductTypeDetails]    Script Date: 6/4/2019 16:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductTypeDetails](
	[ProductTypeID] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](50) NULL,
	[Application] [varchar](50) NULL,
	[MountainLocation] [varchar](50) NULL,
	[Accessories] [varchar](50) NULL,
	[ModelYear] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProject]    Script Date: 6/4/2019 16:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProject](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_tblProject] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSeries]    Script Date: 6/4/2019 16:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSeries](
	[SeriesID] [int] NOT NULL,
	[SeriesName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeriesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTechnicalSpecification]    Script Date: 6/4/2019 16:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTechnicalSpecification](
	[TechnicalSpecifationID] [int] IDENTITY(1,1) NOT NULL,
	[AirFlow(CFW)] [decimal](10, 2) NULL,
	[PowerMin] [decimal](10, 2) NULL,
	[PowerMax] [decimal](10, 2) NULL,
	[VAC_Min] [decimal](10, 2) NULL,
	[VAC_Max] [decimal](10, 2) NULL,
	[FanSpeedMin(RPM)] [int] NULL,
	[FanSpeedMax(RPM)] [int] NULL,
	[NumberofFanSpeed] [int] NULL,
	[SoundAtMaxSpeed] [int] NULL,
	[FanSweepDiameter] [decimal](10, 2) NULL,
	[HeightMin] [decimal](10, 2) NULL,
	[HeightMax] [decimal](10, 2) NULL,
	[Weight] [decimal](10, 2) NULL,
 CONSTRAINT [PK_TechnicalSpec] PRIMARY KEY CLUSTERED 
(
	[TechnicalSpecifationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 6/4/2019 16:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[PicUrl] [nvarchar](255) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [JooleMay] SET  READ_WRITE 
GO
