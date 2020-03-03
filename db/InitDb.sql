USE [master]
GO
/****** Object:  Database [WorkRecordDb]    Script Date: 2020/3/3 22:00:55 ******/
CREATE DATABASE [WorkRecordDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorkRecordDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WorkRecordDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WorkRecordDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WorkRecordDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WorkRecordDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkRecordDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkRecordDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorkRecordDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorkRecordDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorkRecordDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorkRecordDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorkRecordDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorkRecordDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkRecordDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkRecordDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkRecordDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorkRecordDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorkRecordDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkRecordDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorkRecordDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkRecordDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WorkRecordDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkRecordDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkRecordDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkRecordDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkRecordDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkRecordDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [WorkRecordDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkRecordDb] SET RECOVERY FULL 
GO
ALTER DATABASE [WorkRecordDb] SET  MULTI_USER 
GO
ALTER DATABASE [WorkRecordDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorkRecordDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorkRecordDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorkRecordDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WorkRecordDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WorkRecordDb', N'ON'
GO
ALTER DATABASE [WorkRecordDb] SET QUERY_STORE = OFF
GO
USE [WorkRecordDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2020/3/3 22:00:56 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Department]    Script Date: 2020/3/3 22:00:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Department](
	[DeptID] [nvarchar](50) NOT NULL,
	[CreatedUserId] [nvarchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[UpdatedUserId] [nvarchar](50) NOT NULL,
	[UpdatedTime]  AS (getdate()),
	[DeptCode] [nvarchar](16) NULL,
	[DeptName] [nvarchar](32) NULL,
 CONSTRAINT [PK_T_Department] PRIMARY KEY CLUSTERED 
(
	[DeptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Role]    Script Date: 2020/3/3 22:00:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Role](
	[RoleID] [nvarchar](50) NOT NULL,
	[CreatedUserId] [nvarchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[UpdatedUserId] [nvarchar](50) NOT NULL,
	[UpdatedTime]  AS (getdate()),
	[RoleCode] [nvarchar](16) NULL,
	[RoleName] [nvarchar](32) NULL,
	[IsDel] [bit] NOT NULL,
 CONSTRAINT [PK_T_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_User]    Script Date: 2020/3/3 22:00:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_User](
	[UserID] [nvarchar](50) NOT NULL,
	[CreatedUserId] [nvarchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[UpdatedUserId] [nvarchar](50) NOT NULL,
	[UpdatedTime]  AS (getdate()),
	[Account] [nvarchar](32) NOT NULL,
	[Password] [nvarchar](32) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[RoleID] [nvarchar](50) NOT NULL,
	[DepartmentID] [nvarchar](50) NOT NULL,
	[IsDel] [bit] NOT NULL,
 CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_WorkItem]    Script Date: 2020/3/3 22:00:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_WorkItem](
	[WorkID] [nvarchar](50) NOT NULL,
	[CreatedUserId] [nvarchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[UpdatedUserId] [nvarchar](50) NOT NULL,
	[UpdatedTime]  AS (getdate()),
	[WorkContent] [nvarchar](max) NULL,
	[RecordTime] [datetime] NOT NULL,
	[Memos] [nvarchar](128) NULL,
 CONSTRAINT [PK_T_WorkItem] PRIMARY KEY CLUSTERED 
(
	[WorkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_Department] ADD  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[T_Role] ADD  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[T_User] ADD  DEFAULT (getdate()) FOR [CreatedTime]
GO
ALTER TABLE [dbo].[T_WorkItem] ADD  DEFAULT (getdate()) FOR [CreatedTime]
GO
USE [master]
GO
ALTER DATABASE [WorkRecordDb] SET  READ_WRITE 
GO

USE [WorkRecordDb]
GO
INSERT [dbo].[T_Department] ([DeptID], [CreatedUserId], [CreatedTime], [UpdatedUserId], [DeptCode], [DeptName]) VALUES (N'127ba6cf-6f64-4a31-90a0-5078c7850fd3', N'8d19734d-5781-4f54-b31c-4258cf7e3424', CAST(N'2020-03-03T21:34:18.060' AS DateTime), N'8d19734d-5781-4f54-b31c-4258cf7e3424', N'1001', N'开发部')
INSERT [dbo].[T_Department] ([DeptID], [CreatedUserId], [CreatedTime], [UpdatedUserId], [DeptCode], [DeptName]) VALUES (N'87030fb0-fb51-4a6d-934b-19615fba6bd1', N'8d19734d-5781-4f54-b31c-4258cf7e3424', CAST(N'2020-03-03T21:34:18.060' AS DateTime), N'8d19734d-5781-4f54-b31c-4258cf7e3424', N'2001', N'综合管理部')
INSERT [dbo].[T_Role] ([RoleID], [CreatedUserId], [CreatedTime], [UpdatedUserId], [RoleCode], [RoleName], [IsDel]) VALUES (N'39b5f16c-5321-4ef9-934d-3bad00e5f640', N'8d19734d-5781-4f54-b31c-4258cf7e3424', CAST(N'2020-03-03T21:34:18.083' AS DateTime), N'8d19734d-5781-4f54-b31c-4258cf7e3424', N'3', N'普通员工', 0)
INSERT [dbo].[T_Role] ([RoleID], [CreatedUserId], [CreatedTime], [UpdatedUserId], [RoleCode], [RoleName], [IsDel]) VALUES (N'6230ae3d-2014-4a8b-81b4-565e2f053423', N'8d19734d-5781-4f54-b31c-4258cf7e3424', CAST(N'2020-03-03T21:34:18.083' AS DateTime), N'8d19734d-5781-4f54-b31c-4258cf7e3424', N'1', N'系统管理员', 0)
INSERT [dbo].[T_Role] ([RoleID], [CreatedUserId], [CreatedTime], [UpdatedUserId], [RoleCode], [RoleName], [IsDel]) VALUES (N'b96ea97b-0681-4034-b317-2d0eaf3dfeed', N'8d19734d-5781-4f54-b31c-4258cf7e3424', CAST(N'2020-03-03T21:34:18.083' AS DateTime), N'8d19734d-5781-4f54-b31c-4258cf7e3424', N'2', N'部门管理员', 0)
INSERT [dbo].[T_User] ([UserID], [CreatedUserId], [CreatedTime], [UpdatedUserId], [Account], [Password], [Name], [RoleID], [DepartmentID], [IsDel]) VALUES (N'88ee150f-78aa-4a06-8600-76683207f01c', N'8d19734d-5781-4f54-b31c-4258cf7e3424', CAST(N'2020-03-03T21:34:18.110' AS DateTime), N'8d19734d-5781-4f54-b31c-4258cf7e3424', N'admin', N'E10ADC3949BA59ABBE56E057F20F883E', N'admin', N'b96ea97b-0681-4034-b317-2d0eaf3dfeed', N'127ba6cf-6f64-4a31-90a0-5078c7850fd3', 0)
INSERT [dbo].[T_User] ([UserID], [CreatedUserId], [CreatedTime], [UpdatedUserId], [Account], [Password], [Name], [RoleID], [DepartmentID], [IsDel]) VALUES (N'8d19734d-5781-4f54-b31c-4258cf7e3424', N'8d19734d-5781-4f54-b31c-4258cf7e3424', CAST(N'2020-03-03T21:34:18.110' AS DateTime), N'8d19734d-5781-4f54-b31c-4258cf7e3424', N'System', N'E10ADC3949BA59ABBE56E057F20F883E', N'系统管理员', N'6230ae3d-2014-4a8b-81b4-565e2f053423', N'87030fb0-fb51-4a6d-934b-19615fba6bd1', 0)
INSERT [dbo].[T_User] ([UserID], [CreatedUserId], [CreatedTime], [UpdatedUserId], [Account], [Password], [Name], [RoleID], [DepartmentID], [IsDel]) VALUES (N'd05f4164-09ab-4d54-8c0a-70b4ded3e7a5', N'8d19734d-5781-4f54-b31c-4258cf7e3424', CAST(N'2020-03-03T21:34:18.110' AS DateTime), N'8d19734d-5781-4f54-b31c-4258cf7e3424', N'张三', N'E10ADC3949BA59ABBE56E057F20F883E', N'张三', N'39b5f16c-5321-4ef9-934d-3bad00e5f640', N'127ba6cf-6f64-4a31-90a0-5078c7850fd3', 0)
