USE JooleMay

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

if exists (select * from sysobjects where id = object_id('dbo.tblProject') 
and sysstat & 0xf = 3)
	drop table "dbo"."tblProject"
GO

CREATE TABLE dbo.tblProject(
	"ProjectID" int NOT NULL IDENTITY(1,1),
	"ProjectName" nvarchar(50) NULL,
	"UserID" int NOT NULL

	CONSTRAINT "PK_tblProject" PRIMARY KEY CLUSTERED
	(
		"ProjectID"
	)
)
GO

if exists (select * from sysobjects where id = object_id('dbo.tblProduct') 
and sysstat & 0xf = 3)
	drop table "dbo"."tblProduct"
GO

CREATE TABLE dbo.tblProduct(
	"ProductID" int NOT NULL IDENTITY(1,1),
	"ProductName" nvarchar(50) NULL,
	"ProductModel" nvarchar(50) NULL,
	"ProductType" varchar(50) NULL,
	"CategoryID" int NOT NULL,
	"SubCategoryID" int NOT NULL,
	"ManufactureID" int NULL,
	"SeriesID" int NULL,
	"TechnicalSpecificationID" int NOT NULL,
	"ProductTypeDetailsID" int NULL,

	CONSTRAINT "PK_tblProduct" PRIMARY KEY CLUSTERED
	(
		"ProductID"
	)
)
GO



USE [JooleMay]
GO

/****** Object:  Table [dbo].[tblProductCategories]    Script Date: 6/4/2019 3:38:14 PM ******/
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

USE [JooleMay]
GO

/****** Object:  Table [dbo].[tblProductSubCategories]    Script Date: 6/4/2019 3:38:35 PM ******/
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

USE [JooleMay]
GO

/****** Object:  Table [dbo].[tblUser]    Script Date: 6/4/2019 3:38:51 PM ******/
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

go
create table dbo.tblSeries
(SeriesID int not null primary key,
SeriesName nvarchar(50))
go

create table dbo.tblManufacture
(ManufactureID int identity(1,1) not null primary key,
ManufactureName nvarchar(50) not null,
unique(ManufactureName))
go

create table dbo.tblProductType
(ProductTypeID int identity(1,1) not null primary key,
 UserType varchar(50) null,
 Application varchar(50) null,
 MountainLocation varchar(50) null,
 Accessories varchar(50) null,
 ModelYear varchar(50) null
)
go





