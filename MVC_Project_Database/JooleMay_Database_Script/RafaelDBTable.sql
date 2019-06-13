USE [JooleMay]
GO

/****** Object:  Table [dbo].[tblTechnicalSpecification]    Script Date: 6/4/2019 3:28:59 PM ******/
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


