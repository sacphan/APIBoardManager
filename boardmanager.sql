USE [master]
GO
/****** Object:  Database [BoardManager]    Script Date: 10/28/2020 00:54:16 ******/
CREATE DATABASE [BoardManager] ON  PRIMARY 
( NAME = N'BoardManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BoardManager.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BoardManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BoardManager_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BoardManager] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BoardManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BoardManager] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BoardManager] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BoardManager] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BoardManager] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BoardManager] SET ARITHABORT OFF
GO
ALTER DATABASE [BoardManager] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BoardManager] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BoardManager] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BoardManager] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BoardManager] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BoardManager] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BoardManager] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BoardManager] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BoardManager] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BoardManager] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BoardManager] SET  DISABLE_BROKER
GO
ALTER DATABASE [BoardManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BoardManager] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BoardManager] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BoardManager] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BoardManager] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BoardManager] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BoardManager] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BoardManager] SET  READ_WRITE
GO
ALTER DATABASE [BoardManager] SET RECOVERY SIMPLE
GO
ALTER DATABASE [BoardManager] SET  MULTI_USER
GO
ALTER DATABASE [BoardManager] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BoardManager] SET DB_CHAINING OFF
GO
USE [BoardManager]
GO
/****** Object:  Table [dbo].[Column_Board]    Script Date: 10/28/2020 00:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Column_Board](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Column_Board] ON
INSERT [dbo].[Column_Board] ([Id], [Name]) VALUES (1, N'Went Well')
INSERT [dbo].[Column_Board] ([Id], [Name]) VALUES (2, N'To Improve')
INSERT [dbo].[Column_Board] ([Id], [Name]) VALUES (3, N'ActionItem')
SET IDENTITY_INSERT [dbo].[Column_Board] OFF
/****** Object:  Table [dbo].[User_Profile]    Script Date: 10/28/2020 00:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User_Profile] ON
INSERT [dbo].[User_Profile] ([Id], [Firstname], [LastName], [Email]) VALUES (1, N'Sắc', N'Phan', N'sacphan242@gmail.com')
SET IDENTITY_INSERT [dbo].[User_Profile] OFF
/****** Object:  Table [dbo].[Google_Account]    Script Date: 10/28/2020 00:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Google_Account](
	[User_Profile_Id] [int] NOT NULL,
	[Google_Id] [int] NOT NULL,
 CONSTRAINT [PK_Google_Account] PRIMARY KEY CLUSTERED 
(
	[User_Profile_Id] ASC,
	[Google_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Google_Account] ([User_Profile_Id], [Google_Id]) VALUES (1, 12)
/****** Object:  Table [dbo].[Facebook_Account]    Script Date: 10/28/2020 00:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facebook_Account](
	[User_Profile_Id] [int] NOT NULL,
	[Facebook_Id] [int] NOT NULL,
 CONSTRAINT [PK_Facebook_Account] PRIMARY KEY CLUSTERED 
(
	[User_Profile_Id] ASC,
	[Facebook_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Facebook_Account] ([User_Profile_Id], [Facebook_Id]) VALUES (1, 13)
/****** Object:  Table [dbo].[Users_Account]    Script Date: 10/28/2020 00:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Profile_Id] [int] NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[PassWord] [nvarchar](100) NULL,
 CONSTRAINT [PK_Users_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users_Account] ON
INSERT [dbo].[Users_Account] ([Id], [User_Profile_Id], [UserName], [PassWord]) VALUES (2, 1, N'sacphan', N'123')
SET IDENTITY_INSERT [dbo].[Users_Account] OFF
/****** Object:  Table [dbo].[Board]    Script Date: 10/28/2020 00:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Profile_Id] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[LinkShare] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Board] ON
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (1, 1, N'Bảng test', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (2, 1, N'bảng 2', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (3, 1, N'bảng 3', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (4, 1, N'bảng 4', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (5, 1, N'bảng 5', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (6, 1, N'bảng 6', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (7, 1, N'bảng 7', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (8, 1, N'bảng 8', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (9, 1, N'bảng 9', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (10, 1, N'bảng 10', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (11, 1, N'bảng 11', NULL)
INSERT [dbo].[Board] ([Id], [User_Profile_Id], [Name], [LinkShare]) VALUES (12, 1, N'bảng 12', NULL)
SET IDENTITY_INSERT [dbo].[Board] OFF
/****** Object:  Table [dbo].[Board_Detail]    Script Date: 10/28/2020 00:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board_Detail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](1000) NULL,
	[Column_Id] [int] NULL,
	[Board_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Column_Mapping_Board]    Script Date: 10/28/2020 00:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Column_Mapping_Board](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Column_Board_Id] [int] NOT NULL,
	[Board_Id] [int] NOT NULL,
 CONSTRAINT [PK_Column_Mapping_Board] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Column_Mapping_Board] ON
INSERT [dbo].[Column_Mapping_Board] ([Id], [Column_Board_Id], [Board_Id]) VALUES (1, 1, 1)
INSERT [dbo].[Column_Mapping_Board] ([Id], [Column_Board_Id], [Board_Id]) VALUES (2, 2, 1)
INSERT [dbo].[Column_Mapping_Board] ([Id], [Column_Board_Id], [Board_Id]) VALUES (3, 3, 1)
SET IDENTITY_INSERT [dbo].[Column_Mapping_Board] OFF
/****** Object:  ForeignKey [FK__Google_Ac__User___164452B1]    Script Date: 10/28/2020 00:54:17 ******/
ALTER TABLE [dbo].[Google_Account]  WITH CHECK ADD FOREIGN KEY([User_Profile_Id])
REFERENCES [dbo].[User_Profile] ([Id])
GO
/****** Object:  ForeignKey [FK__Facebook___User___15502E78]    Script Date: 10/28/2020 00:54:17 ******/
ALTER TABLE [dbo].[Facebook_Account]  WITH CHECK ADD FOREIGN KEY([User_Profile_Id])
REFERENCES [dbo].[User_Profile] ([Id])
GO
/****** Object:  ForeignKey [FK_Users_Account_User_Profile]    Script Date: 10/28/2020 00:54:17 ******/
ALTER TABLE [dbo].[Users_Account]  WITH CHECK ADD  CONSTRAINT [FK_Users_Account_User_Profile] FOREIGN KEY([User_Profile_Id])
REFERENCES [dbo].[User_Profile] ([Id])
GO
ALTER TABLE [dbo].[Users_Account] CHECK CONSTRAINT [FK_Users_Account_User_Profile]
GO
/****** Object:  ForeignKey [FK__Board__User_Prof__45F365D3]    Script Date: 10/28/2020 00:54:17 ******/
ALTER TABLE [dbo].[Board]  WITH CHECK ADD FOREIGN KEY([User_Profile_Id])
REFERENCES [dbo].[User_Profile] ([Id])
GO
/****** Object:  ForeignKey [FK__Board_Det__Board__30F848ED]    Script Date: 10/28/2020 00:54:17 ******/
ALTER TABLE [dbo].[Board_Detail]  WITH CHECK ADD FOREIGN KEY([Board_Id])
REFERENCES [dbo].[Board] ([Id])
GO
/****** Object:  ForeignKey [FK__Board_Det__Colum__31EC6D26]    Script Date: 10/28/2020 00:54:17 ******/
ALTER TABLE [dbo].[Board_Detail]  WITH CHECK ADD FOREIGN KEY([Column_Id])
REFERENCES [dbo].[Column_Board] ([Id])
GO
/****** Object:  ForeignKey [FK_Column_Mapping_Board_Board]    Script Date: 10/28/2020 00:54:17 ******/
ALTER TABLE [dbo].[Column_Mapping_Board]  WITH CHECK ADD  CONSTRAINT [FK_Column_Mapping_Board_Board] FOREIGN KEY([Board_Id])
REFERENCES [dbo].[Board] ([Id])
GO
ALTER TABLE [dbo].[Column_Mapping_Board] CHECK CONSTRAINT [FK_Column_Mapping_Board_Board]
GO
/****** Object:  ForeignKey [FK_Column_Mapping_Board_Column_Board]    Script Date: 10/28/2020 00:54:17 ******/
ALTER TABLE [dbo].[Column_Mapping_Board]  WITH CHECK ADD  CONSTRAINT [FK_Column_Mapping_Board_Column_Board] FOREIGN KEY([Column_Board_Id])
REFERENCES [dbo].[Column_Board] ([Id])
GO
ALTER TABLE [dbo].[Column_Mapping_Board] CHECK CONSTRAINT [FK_Column_Mapping_Board_Column_Board]
GO
