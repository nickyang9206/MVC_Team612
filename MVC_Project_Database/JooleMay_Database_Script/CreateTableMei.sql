create database JooleMay
go
use JooleMay
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
