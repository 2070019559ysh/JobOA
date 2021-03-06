USE [master]
GO
/****** Object:  Database [JOB_OA]    Script Date: 04/24/2016 18:28:36 ******/
CREATE DATABASE [JOB_OA] ON  PRIMARY 
( NAME = N'JOB_OA', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\JOB_OA.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JOB_OA_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\JOB_OA_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JOB_OA] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JOB_OA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JOB_OA] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [JOB_OA] SET ANSI_NULLS OFF
GO
ALTER DATABASE [JOB_OA] SET ANSI_PADDING OFF
GO
ALTER DATABASE [JOB_OA] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [JOB_OA] SET ARITHABORT OFF
GO
ALTER DATABASE [JOB_OA] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [JOB_OA] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [JOB_OA] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [JOB_OA] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [JOB_OA] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [JOB_OA] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [JOB_OA] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [JOB_OA] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [JOB_OA] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [JOB_OA] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [JOB_OA] SET  ENABLE_BROKER
GO
ALTER DATABASE [JOB_OA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [JOB_OA] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [JOB_OA] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [JOB_OA] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [JOB_OA] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [JOB_OA] SET READ_COMMITTED_SNAPSHOT ON
GO
ALTER DATABASE [JOB_OA] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [JOB_OA] SET  READ_WRITE
GO
ALTER DATABASE [JOB_OA] SET RECOVERY FULL
GO
ALTER DATABASE [JOB_OA] SET  MULTI_USER
GO
ALTER DATABASE [JOB_OA] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [JOB_OA] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'JOB_OA', N'ON'
GO
USE [JOB_OA]
GO
/****** Object:  Table [dbo].[OAUi]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OAUi](
	[UiId] [int] IDENTITY(1,1) NOT NULL,
	[UiImg] [nvarchar](50) NULL,
	[UiTitle] [nvarchar](100) NULL,
	[UiMess] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.OAUi] PRIMARY KEY CLUSTERED 
(
	[UiId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OAException]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OAException](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExMessage] [varchar](max) NOT NULL,
	[ExTime] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.OAException] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[PermissionIds] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[IsSecrecy] [bit] NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccessPath]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccessPath](
	[AccessPathId] [int] IDENTITY(1,1) NOT NULL,
	[HttpMethod] [varchar](20) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AccessPath] PRIMARY KEY CLUSTERED 
(
	[AccessPathId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_dbo.Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](11) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[RealName] [nvarchar](20) NOT NULL,
	[HeadPicture] [nvarchar](max) NULL,
	[Introduction] [nvarchar](max) NULL,
	[LastLoginTime] [datetime] NULL,
	[Email] [varchar](50) NULL,
	[IsEnabled] [bit] NOT NULL,
	[RoleIds] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[OnlineState] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Employee] 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[AccessPathId] [int] NULL,
 CONSTRAINT [PK_dbo.Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccessPathId] ON [dbo].[Permission] 
(
	[AccessPathId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MajorTask]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MajorTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ArrangePersonId] [int] NOT NULL,
	[ExePersonId] [int] NOT NULL,
	[CheckPersonId] [int] NOT NULL,
	[Participator] [varchar](max) NULL,
	[StartTime] [datetime] NOT NULL,
	[CompleteTime] [datetime] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CommitTime] [datetime] NULL,
	[State] [int] NOT NULL,
	[IsSecrecy] [bit] NOT NULL,
	[Attachment] [nvarchar](255) NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MajorTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_ArrangePersonId] ON [dbo].[MajorTask] 
(
	[ArrangePersonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_CheckPersonId] ON [dbo].[MajorTask] 
(
	[CheckPersonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ExePersonId] ON [dbo].[MajorTask] 
(
	[ExePersonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ProjectId] ON [dbo].[MajorTask] 
(
	[ProjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubTask]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[No] [varchar](max) NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ArrangePersonId] [int] NOT NULL,
	[ExePersonId] [int] NOT NULL,
	[CheckPersonId] [int] NOT NULL,
	[Participator] [varchar](max) NULL,
	[StartTime] [datetime] NOT NULL,
	[CompleteTime] [datetime] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CommitTime] [datetime] NULL,
	[TaskId] [int] NOT NULL,
	[State] [int] NOT NULL,
	[IsSecrecy] [bit] NOT NULL,
	[SubmissionThing] [nvarchar](500) NULL,
	[Attachment] [nvarchar](255) NULL,
	[CompletionCriteria] [nvarchar](500) NULL,
	[WorkMethod] [nvarchar](500) NULL,
	[Progress] [decimal](3, 0) NOT NULL,
 CONSTRAINT [PK_dbo.SubTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_ArrangePersonId] ON [dbo].[SubTask] 
(
	[ArrangePersonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_CheckPersonId] ON [dbo].[SubTask] 
(
	[CheckPersonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ExePersonId] ON [dbo].[SubTask] 
(
	[ExePersonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TaskId] ON [dbo].[SubTask] 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OAMessage]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OAMessage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[ExtraMessage] [nvarchar](1000) NULL,
	[TaskId] [int] NULL,
	[SubTaskId] [int] NULL,
	[FromEmployeeId] [int] NOT NULL,
	[ToEmployeeId] [int] NOT NULL,
	[IsLookUp] [bit] NOT NULL,
	[SendDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.OAMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FromEmployeeId] ON [dbo].[OAMessage] 
(
	[FromEmployeeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_SubTaskId] ON [dbo].[OAMessage] 
(
	[SubTaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TaskId] ON [dbo].[OAMessage] 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ToEmployeeId] ON [dbo].[OAMessage] 
(
	[ToEmployeeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyUpdate]    Script Date: 04/24/2016 18:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyUpdate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [datetime] NOT NULL,
	[WorkContent] [nvarchar](500) NOT NULL,
	[ExtraTask] [nvarchar](500) NULL,
	[SpendTime] [decimal](4, 0) NULL,
	[SubTaskId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DailyUpdate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_SubTaskId] ON [dbo].[DailyUpdate] 
(
	[SubTaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_dbo.Employee_dbo.Department_DepartmentId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employee_dbo.Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_dbo.Employee_dbo.Department_DepartmentId]
GO
/****** Object:  ForeignKey [FK_dbo.Permission_dbo.AccessPath_AccessPathId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Permission_dbo.AccessPath_AccessPathId] FOREIGN KEY([AccessPathId])
REFERENCES [dbo].[AccessPath] ([AccessPathId])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_dbo.Permission_dbo.AccessPath_AccessPathId]
GO
/****** Object:  ForeignKey [FK_dbo.MajorTask_dbo.Employee_ArrangePersonId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[MajorTask]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MajorTask_dbo.Employee_ArrangePersonId] FOREIGN KEY([ArrangePersonId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[MajorTask] CHECK CONSTRAINT [FK_dbo.MajorTask_dbo.Employee_ArrangePersonId]
GO
/****** Object:  ForeignKey [FK_dbo.MajorTask_dbo.Employee_CheckPersonId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[MajorTask]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MajorTask_dbo.Employee_CheckPersonId] FOREIGN KEY([CheckPersonId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[MajorTask] CHECK CONSTRAINT [FK_dbo.MajorTask_dbo.Employee_CheckPersonId]
GO
/****** Object:  ForeignKey [FK_dbo.MajorTask_dbo.Employee_ExePersonId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[MajorTask]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MajorTask_dbo.Employee_ExePersonId] FOREIGN KEY([ExePersonId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[MajorTask] CHECK CONSTRAINT [FK_dbo.MajorTask_dbo.Employee_ExePersonId]
GO
/****** Object:  ForeignKey [FK_dbo.MajorTask_dbo.Project_ProjectId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[MajorTask]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MajorTask_dbo.Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[MajorTask] CHECK CONSTRAINT [FK_dbo.MajorTask_dbo.Project_ProjectId]
GO
/****** Object:  ForeignKey [FK_dbo.SubTask_dbo.Employee_ArrangePersonId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[SubTask]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubTask_dbo.Employee_ArrangePersonId] FOREIGN KEY([ArrangePersonId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[SubTask] CHECK CONSTRAINT [FK_dbo.SubTask_dbo.Employee_ArrangePersonId]
GO
/****** Object:  ForeignKey [FK_dbo.SubTask_dbo.Employee_CheckPersonId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[SubTask]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubTask_dbo.Employee_CheckPersonId] FOREIGN KEY([CheckPersonId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[SubTask] CHECK CONSTRAINT [FK_dbo.SubTask_dbo.Employee_CheckPersonId]
GO
/****** Object:  ForeignKey [FK_dbo.SubTask_dbo.Employee_ExePersonId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[SubTask]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubTask_dbo.Employee_ExePersonId] FOREIGN KEY([ExePersonId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[SubTask] CHECK CONSTRAINT [FK_dbo.SubTask_dbo.Employee_ExePersonId]
GO
/****** Object:  ForeignKey [FK_dbo.SubTask_dbo.MajorTask_TaskId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[SubTask]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubTask_dbo.MajorTask_TaskId] FOREIGN KEY([TaskId])
REFERENCES [dbo].[MajorTask] ([Id])
GO
ALTER TABLE [dbo].[SubTask] CHECK CONSTRAINT [FK_dbo.SubTask_dbo.MajorTask_TaskId]
GO
/****** Object:  ForeignKey [FK_dbo.OAMessage_dbo.Employee_FromEmployeeId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[OAMessage]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OAMessage_dbo.Employee_FromEmployeeId] FOREIGN KEY([FromEmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[OAMessage] CHECK CONSTRAINT [FK_dbo.OAMessage_dbo.Employee_FromEmployeeId]
GO
/****** Object:  ForeignKey [FK_dbo.OAMessage_dbo.Employee_ToEmployeeId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[OAMessage]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OAMessage_dbo.Employee_ToEmployeeId] FOREIGN KEY([ToEmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[OAMessage] CHECK CONSTRAINT [FK_dbo.OAMessage_dbo.Employee_ToEmployeeId]
GO
/****** Object:  ForeignKey [FK_dbo.OAMessage_dbo.MajorTask_TaskId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[OAMessage]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OAMessage_dbo.MajorTask_TaskId] FOREIGN KEY([TaskId])
REFERENCES [dbo].[MajorTask] ([Id])
GO
ALTER TABLE [dbo].[OAMessage] CHECK CONSTRAINT [FK_dbo.OAMessage_dbo.MajorTask_TaskId]
GO
/****** Object:  ForeignKey [FK_dbo.OAMessage_dbo.SubTask_SubTaskId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[OAMessage]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OAMessage_dbo.SubTask_SubTaskId] FOREIGN KEY([SubTaskId])
REFERENCES [dbo].[SubTask] ([Id])
GO
ALTER TABLE [dbo].[OAMessage] CHECK CONSTRAINT [FK_dbo.OAMessage_dbo.SubTask_SubTaskId]
GO
/****** Object:  ForeignKey [FK_dbo.DailyUpdate_dbo.SubTask_SubTaskId]    Script Date: 04/24/2016 18:28:37 ******/
ALTER TABLE [dbo].[DailyUpdate]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DailyUpdate_dbo.SubTask_SubTaskId] FOREIGN KEY([SubTaskId])
REFERENCES [dbo].[SubTask] ([Id])
GO
ALTER TABLE [dbo].[DailyUpdate] CHECK CONSTRAINT [FK_dbo.DailyUpdate_dbo.SubTask_SubTaskId]
GO
