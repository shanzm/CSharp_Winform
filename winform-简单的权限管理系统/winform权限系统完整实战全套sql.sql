USE [master]
GO
/****** Object:  Database [RightDBase]    Script Date: 2020/4/3 星期五 下午 8:44:51 ******/
--数据库文件路径：'D:\课程\新课程\DBase' 改成本地存在的路径 
CREATE DATABASE [RightDBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RightDBase', FILENAME = N'D:\课程\新课程\DBase\RightDBase.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RightDBase_log', FILENAME = N'D:\课程\新课程\DBase\RightDBase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RightDBase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RightDBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RightDBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RightDBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RightDBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RightDBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RightDBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [RightDBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RightDBase] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [RightDBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RightDBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RightDBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RightDBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RightDBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RightDBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RightDBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RightDBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RightDBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RightDBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RightDBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RightDBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RightDBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RightDBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RightDBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RightDBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RightDBase] SET RECOVERY FULL 
GO
ALTER DATABASE [RightDBase] SET  MULTI_USER 
GO
ALTER DATABASE [RightDBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RightDBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RightDBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RightDBase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RightDBase', N'ON'
GO
USE [RightDBase]
GO
/****** Object:  Table [dbo].[MenuInfos]    Script Date: 2020/4/3 星期五 下午 8:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MenuInfos](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[ParentId] [int] NOT NULL,
	[FrmName] [varchar](500) NULL,
	[MKey] [nchar](10) NULL,
 CONSTRAINT [PK_MenuInfos] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoleInfos]    Script Date: 2020/4/3 星期五 下午 8:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleInfos](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Remark] [nvarchar](500) NULL,
	[IsAdmin] [int] NOT NULL,
 CONSTRAINT [PK_RoleInfos] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleMenuInfos]    Script Date: 2020/4/3 星期五 下午 8:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenuInfos](
	[RMId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuId] [int] NOT NULL,
 CONSTRAINT [PK_RoleMenuInfos] PRIMARY KEY CLUSTERED 
(
	[RMId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInfos]    Script Date: 2020/4/3 星期五 下午 8:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfos](
	[UserId] [int] IDENTITY(101,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[UserPwd] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserInfos] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRoleInfos]    Script Date: 2020/4/3 星期五 下午 8:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleInfos](
	[URId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoleInfos] PRIMARY KEY CLUSTERED 
(
	[URId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[MenuInfos] ON 

INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (1, N'系统管理', 0, NULL, NULL)
INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (2, N'新增菜单', 1, N'sm.FrmAddMenuInfo', NULL)
INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (3, N'菜单列表', 1, N'sm.FrmMenuList', NULL)
INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (4, N'角色列表', 1, N'sm.FrmRoleList', NULL)
INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (5, N'权限分配', 1, N'sm.FrmRight', NULL)
INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (6, N'用户列表', 1, N'sm.FrmUserList', NULL)
INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (8, N'新增用户', 6, N'sm.FrmUserInfo', NULL)
INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (10, N'成绩管理', 0, N'', N'Alt+S     ')
INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (11, N'成绩列表', 10, N'score.FrmScoreList', N'          ')
INSERT [dbo].[MenuInfos] ([MenuId], [MenuName], [ParentId], [FrmName], [MKey]) VALUES (12, N'成绩信息', 10, N'score.FrmScoreInfo', N'          ')
SET IDENTITY_INSERT [dbo].[MenuInfos] OFF
SET IDENTITY_INSERT [dbo].[RoleInfos] ON 

INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin]) VALUES (1, N'超级管理员', N'具有一切权限', 1)
INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin]) VALUES (3, N'系统管理员', N'负责系统管理功能。ssssssssddddd', 0)
INSERT [dbo].[RoleInfos] ([RoleId], [RoleName], [Remark], [IsAdmin]) VALUES (4, N'成绩管理员', N'负责成绩信息管理', 0)
SET IDENTITY_INSERT [dbo].[RoleInfos] OFF
SET IDENTITY_INSERT [dbo].[RoleMenuInfos] ON 

INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MenuId]) VALUES (7, 3, 1)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MenuId]) VALUES (8, 3, 2)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MenuId]) VALUES (9, 3, 3)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MenuId]) VALUES (10, 3, 6)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MenuId]) VALUES (11, 3, 8)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MenuId]) VALUES (12, 4, 10)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MenuId]) VALUES (13, 4, 11)
INSERT [dbo].[RoleMenuInfos] ([RMId], [RoleId], [MenuId]) VALUES (14, 4, 12)
SET IDENTITY_INSERT [dbo].[RoleMenuInfos] OFF
SET IDENTITY_INSERT [dbo].[UserInfos] ON 

INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd]) VALUES (101, N'admin', N'admin')
INSERT [dbo].[UserInfos] ([UserId], [UserName], [UserPwd]) VALUES (102, N'lyc001', N'123456')
SET IDENTITY_INSERT [dbo].[UserInfos] OFF
SET IDENTITY_INSERT [dbo].[UserRoleInfos] ON 

INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId]) VALUES (1, 101, 1)
INSERT [dbo].[UserRoleInfos] ([URId], [UserId], [RoleId]) VALUES (3, 102, 3)
SET IDENTITY_INSERT [dbo].[UserRoleInfos] OFF
ALTER TABLE [dbo].[RoleInfos] ADD  CONSTRAINT [DF_RoleInfos_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[RoleMenuInfos]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenuInfos_RoleInfos] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleInfos] ([RoleId])
GO
ALTER TABLE [dbo].[RoleMenuInfos] CHECK CONSTRAINT [FK_RoleMenuInfos_RoleInfos]
GO
ALTER TABLE [dbo].[UserRoleInfos]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleInfos_RoleInfos] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserInfos] ([UserId])
GO
ALTER TABLE [dbo].[UserRoleInfos] CHECK CONSTRAINT [FK_UserRoleInfos_RoleInfos]
GO
ALTER TABLE [dbo].[UserRoleInfos]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleInfos_RoleInfos1] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleInfos] ([RoleId])
GO
ALTER TABLE [dbo].[UserRoleInfos] CHECK CONSTRAINT [FK_UserRoleInfos_RoleInfos1]
GO
USE [master]
GO
ALTER DATABASE [RightDBase] SET  READ_WRITE 
GO
