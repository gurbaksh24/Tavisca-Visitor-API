USE [master]
GO
/****** Object:  Database [VisitorsDatabase]    Script Date: 10/18/2018 6:02:48 PM ******/
CREATE DATABASE [VisitorsDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VisitorsDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\VisitorsDatabase.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VisitorsDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\VisitorsDatabase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VisitorsDatabase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VisitorsDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VisitorsDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [VisitorsDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VisitorsDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VisitorsDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VisitorsDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VisitorsDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VisitorsDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [VisitorsDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VisitorsDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VisitorsDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VisitorsDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [VisitorsDatabase]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/18/2018 6:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [varchar](10) NOT NULL,
	[EmployeeName] [varchar](50) NOT NULL,
	[EmailId] [varchar](40) NOT NULL,
	[Location] [varchar](70) NOT NULL,
	[EmployeeStatus] [varchar](10) NOT NULL,
	[Gender] [varchar](7) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[LocalAddress] [varchar](100) NOT NULL,
	[PermanentAddress] [varchar](100) NOT NULL,
	[EmergencyContactPerson] [varchar](30) NOT NULL,
	[EmergencyContactNumber] [varchar](10) NOT NULL,
	[PrimaryContactNumber] [varchar](10) NOT NULL,
	[SecondaryContactNumber] [varchar](10) NULL,
	[DateOfJoining] [date] NOT NULL,
	[DateOfResignation] [date] NULL,
	[Remark] [varchar](30) NULL,
	[BloodGroup] [varchar](5) NULL,
	[MedicalSpecification] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Guard]    Script Date: 10/18/2018 6:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Guard](
	[GuardId] [varchar](10) NOT NULL,
	[GuardName] [varchar](50) NOT NULL,
	[EmailId] [varchar](40) NOT NULL,
	[GuardStatus] [varchar](10) NOT NULL,
	[Gender] [varchar](7) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[LocalAddress] [varchar](100) NOT NULL,
	[PermanentAddress] [varchar](100) NOT NULL,
	[EmergencyContactPerson] [varchar](30) NOT NULL,
	[EmergencyContactNumber] [varchar](10) NOT NULL,
	[PrimaryContactNumber] [varchar](10) NOT NULL,
	[SecondaryContactNumber] [varchar](10) NULL,
	[DateOfJoining] [date] NOT NULL,
	[DateOfResignation] [date] NULL,
	[Remark] [varchar](30) NULL,
	[BloodGroup] [varchar](5) NULL,
	[MedicalSpecification] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[GuardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GuardLogs]    Script Date: 10/18/2018 6:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GuardLogs](
	[SerialNumber] [int] IDENTITY(1,1) NOT NULL,
	[GuardId] [varchar](10) NOT NULL,
	[GuardPassword] [varchar](50) NOT NULL,
	[LoginTime] [time](7) NOT NULL,
	[LogoutTime] [time](7) NULL,
	[LoginDate] [date] NOT NULL,
	[LogoutDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[SerialNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoginCredentials]    Script Date: 10/18/2018 6:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoginCredentials](
	[SerialNumber] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](30) NOT NULL,
	[Password] [varchar](40) NOT NULL,
	[Category] [varchar](30) NOT NULL,
	[ContactNo] [varchar](20) NOT NULL,
	[Otp] [int] NULL,
	[SavingTime] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Visitors]    Script Date: 10/18/2018 6:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Visitors](
	[VisitorId] [int] IDENTITY(1,1) NOT NULL,
	[NameOfVisitor] [varchar](60) NOT NULL,
	[Contact] [varchar](10) NOT NULL,
	[VisitorImage] [varchar](100) NOT NULL,
	[GovtIdProof] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VisitorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VisitorsLogs]    Script Date: 10/18/2018 6:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VisitorsLogs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[ComingFrom] [varchar](50) NOT NULL,
	[WhomToMeet] [varchar](40) NOT NULL,
	[EmployeeId] [varchar](10) NOT NULL,
	[DateOfVisit] [date] NOT NULL,
	[TimeIn] [time](7) NOT NULL,
	[TimeOut] [time](7) NOT NULL,
	[VisitorId] [int] NOT NULL,
	[GuardId] [varchar](10) NOT NULL,
	[PurposeOfVisit] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [VisitorsDatabase] SET  READ_WRITE 
GO
