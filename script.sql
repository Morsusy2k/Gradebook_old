/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [Max.Gradebook]    Script Date: 10/1/2017 4:39:56 AM ******/
CREATE DATABASE [Max.Gradebook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Max.Gradebook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Max.Gradebook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Max.Gradebook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Max.Gradebook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Max.Gradebook] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Max.Gradebook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Max.Gradebook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ARITHABORT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Max.Gradebook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Max.Gradebook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Max.Gradebook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Max.Gradebook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Max.Gradebook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Max.Gradebook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Max.Gradebook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Max.Gradebook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Max.Gradebook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Max.Gradebook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Max.Gradebook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Max.Gradebook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Max.Gradebook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Max.Gradebook] SET  MULTI_USER 
GO
ALTER DATABASE [Max.Gradebook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Max.Gradebook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Max.Gradebook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Max.Gradebook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Max.Gradebook] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Max.Gradebook] SET QUERY_STORE = OFF
GO
USE [Max.Gradebook]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Max.Gradebook]
GO
/****** Object:  Table [dbo].[FieldOfStudy]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldOfStudy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldOfStudyHasSubjects]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldOfStudyHasSubjects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fieldOfStudyId] [int] NOT NULL,
	[subjectId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gradebook]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gradebook](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pClassId] [int] NOT NULL,
	[schoolYearStart] [datetime] NOT NULL,
	[schoolYearEnd] [datetime] NOT NULL,
	[editable] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mark]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marksId] [int] NOT NULL,
	[mark] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pupilId] [int] NOT NULL,
	[subjectId] [int] NOT NULL,
	[finalMark] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PClass]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PClass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[fieldOfStudyId] [int] NOT NULL,
	[generation] [datetime] NOT NULL,
	[Year] [nvarchar](4) NOT NULL,
	[PClassIndex] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pupil]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pupil](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pClassId] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectLesson]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectLesson](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gradebookId] [int] NOT NULL,
	[subjectId] [int] NOT NULL,
	[lessonTheme] [nvarchar](254) NULL,
	[date] [datetime] NOT NULL,
	[timeOfLesson] [nvarchar](3) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectLessonsHaveAbsentees]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectLessonsHaveAbsentees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subjectLessonId] [int] NOT NULL,
	[pupilId] [int] NOT NULL,
 CONSTRAINT [PK_SUBJECTLESSONSHAVEABSENTEES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](25) NOT NULL,
	[surname] [nvarchar](25) NOT NULL,
	[username] [nvarchar](30) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[email] [nvarchar](254) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserHasRoles]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserHasRoles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[roleId] [int] NOT NULL,
 CONSTRAINT [PK_USERHASROLES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FieldOfStudy] ON 

INSERT [dbo].[FieldOfStudy] ([id], [name]) VALUES (65, N'Science')
INSERT [dbo].[FieldOfStudy] ([id], [name]) VALUES (66, N'Technology')
INSERT [dbo].[FieldOfStudy] ([id], [name]) VALUES (67, N'Engineering')
SET IDENTITY_INSERT [dbo].[FieldOfStudy] OFF
SET IDENTITY_INSERT [dbo].[FieldOfStudyHasSubjects] ON 

INSERT [dbo].[FieldOfStudyHasSubjects] ([id], [fieldOfStudyId], [subjectId]) VALUES (38, 65, 57)
INSERT [dbo].[FieldOfStudyHasSubjects] ([id], [fieldOfStudyId], [subjectId]) VALUES (40, 67, 59)
SET IDENTITY_INSERT [dbo].[FieldOfStudyHasSubjects] OFF
SET IDENTITY_INSERT [dbo].[Gradebook] ON 

INSERT [dbo].[Gradebook] ([id], [pClassId], [schoolYearStart], [schoolYearEnd], [editable]) VALUES (35, 46, CAST(N'2013-05-05T00:00:00.000' AS DateTime), CAST(N'2017-05-05T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Gradebook] ([id], [pClassId], [schoolYearStart], [schoolYearEnd], [editable]) VALUES (36, 47, CAST(N'2014-05-05T00:00:00.000' AS DateTime), CAST(N'2018-05-05T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Gradebook] OFF
SET IDENTITY_INSERT [dbo].[Mark] ON 

INSERT [dbo].[Mark] ([id], [marksId], [mark]) VALUES (20, 23, 10)
INSERT [dbo].[Mark] ([id], [marksId], [mark]) VALUES (21, 23, 10)
SET IDENTITY_INSERT [dbo].[Mark] OFF
SET IDENTITY_INSERT [dbo].[Marks] ON 

INSERT [dbo].[Marks] ([id], [pupilId], [subjectId], [finalMark]) VALUES (23, 31, 57, 10)
INSERT [dbo].[Marks] ([id], [pupilId], [subjectId], [finalMark]) VALUES (24, 31, 57, 10)
SET IDENTITY_INSERT [dbo].[Marks] OFF
SET IDENTITY_INSERT [dbo].[PClass] ON 

INSERT [dbo].[PClass] ([id], [userId], [fieldOfStudyId], [generation], [Year], [PClassIndex]) VALUES (46, 91, 65, CAST(N'2013-05-05T00:00:00.000' AS DateTime), N'Firs', 2)
INSERT [dbo].[PClass] ([id], [userId], [fieldOfStudyId], [generation], [Year], [PClassIndex]) VALUES (47, 92, 66, CAST(N'2013-05-05T00:00:00.000' AS DateTime), N'Thir', 1)
SET IDENTITY_INSERT [dbo].[PClass] OFF
SET IDENTITY_INSERT [dbo].[Pupil] ON 

INSERT [dbo].[Pupil] ([id], [pClassId], [name]) VALUES (31, 46, N'Pupil Name1')
INSERT [dbo].[Pupil] ([id], [pClassId], [name]) VALUES (32, 47, N'Pupil Name2')
SET IDENTITY_INSERT [dbo].[Pupil] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (53, N'Guest')
INSERT [dbo].[Role] ([id], [name]) VALUES (54, N'User')
INSERT [dbo].[Role] ([id], [name]) VALUES (55, N'Moderator')
INSERT [dbo].[Role] ([id], [name]) VALUES (56, N'Administrator')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([id], [userId], [name]) VALUES (57, 91, N'Geometry')
INSERT [dbo].[Subject] ([id], [userId], [name]) VALUES (59, 93, N'Mathematic')
SET IDENTITY_INSERT [dbo].[Subject] OFF
SET IDENTITY_INSERT [dbo].[SubjectLesson] ON 

INSERT [dbo].[SubjectLesson] ([id], [gradebookId], [subjectId], [lessonTheme], [date], [timeOfLesson]) VALUES (20, 35, 57, N'Geometry 101', CAST(N'2017-10-20T00:00:00.000' AS DateTime), N'9 A')
INSERT [dbo].[SubjectLesson] ([id], [gradebookId], [subjectId], [lessonTheme], [date], [timeOfLesson]) VALUES (21, 36, 57, N'Mathematics 101', CAST(N'2017-10-20T00:00:00.000' AS DateTime), N'4 P')
INSERT [dbo].[SubjectLesson] ([id], [gradebookId], [subjectId], [lessonTheme], [date], [timeOfLesson]) VALUES (22, 36, 59, N'Introduction to programming', CAST(N'2017-10-20T00:00:00.000' AS DateTime), N'2 P')
SET IDENTITY_INSERT [dbo].[SubjectLesson] OFF
SET IDENTITY_INSERT [dbo].[SubjectLessonsHaveAbsentees] ON 

INSERT [dbo].[SubjectLessonsHaveAbsentees] ([id], [subjectLessonId], [pupilId]) VALUES (13, 20, 31)
INSERT [dbo].[SubjectLessonsHaveAbsentees] ([id], [subjectLessonId], [pupilId]) VALUES (14, 21, 32)
SET IDENTITY_INSERT [dbo].[SubjectLessonsHaveAbsentees] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [name], [surname], [username], [password], [email]) VALUES (91, N'Smiljko', N'Kostic', N'skostic', N'kosta123', N'kosta29@gmail.com')
INSERT [dbo].[User] ([id], [name], [surname], [username], [password], [email]) VALUES (92, N'Milan', N'Markovic', N'milan', N'mile123', N'mile95@gmail.com')
INSERT [dbo].[User] ([id], [name], [surname], [username], [password], [email]) VALUES (93, N'Dragica', N'Savic', N'Dragica90', N'dsavic', N'dsavic@gmail.com')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserHasRoles] ON 

INSERT [dbo].[UserHasRoles] ([id], [userId], [roleId]) VALUES (59, 91, 53)
INSERT [dbo].[UserHasRoles] ([id], [userId], [roleId]) VALUES (60, 91, 54)
INSERT [dbo].[UserHasRoles] ([id], [userId], [roleId]) VALUES (61, 91, 56)
INSERT [dbo].[UserHasRoles] ([id], [userId], [roleId]) VALUES (62, 92, 54)
INSERT [dbo].[UserHasRoles] ([id], [userId], [roleId]) VALUES (64, 93, 54)
SET IDENTITY_INSERT [dbo].[UserHasRoles] OFF
/****** Object:  Index [PK_FIELDOFSTUDY]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[FieldOfStudy] ADD  CONSTRAINT [PK_FIELDOFSTUDY] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_FIELDOFSTUDYHASSUBJECTS]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] ADD  CONSTRAINT [PK_FIELDOFSTUDYHASSUBJECTS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_GRADEBOOK]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[Gradebook] ADD  CONSTRAINT [PK_GRADEBOOK] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_MARK]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[Mark] ADD  CONSTRAINT [PK_MARK] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_MARKS]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[Marks] ADD  CONSTRAINT [PK_MARKS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_PCLASS]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[PClass] ADD  CONSTRAINT [PK_PCLASS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_PUPIL]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[Pupil] ADD  CONSTRAINT [PK_PUPIL] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_ROLE]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [PK_ROLE] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_SUBJECT]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [PK_SUBJECT] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_SUBJECTLESSON]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[SubjectLesson] ADD  CONSTRAINT [PK_SUBJECTLESSON] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_USER]    Script Date: 10/1/2017 4:39:56 AM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [PK_USER] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects]  WITH NOCHECK ADD  CONSTRAINT [FK_FieldOfStudyHasSubjects_FieldOfStudy] FOREIGN KEY([fieldOfStudyId])
REFERENCES [dbo].[FieldOfStudy] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] CHECK CONSTRAINT [FK_FieldOfStudyHasSubjects_FieldOfStudy]
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects]  WITH NOCHECK ADD  CONSTRAINT [FK_FieldOfStudyHasSubjects_Subject] FOREIGN KEY([subjectId])
REFERENCES [dbo].[Subject] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] CHECK CONSTRAINT [FK_FieldOfStudyHasSubjects_Subject]
GO
ALTER TABLE [dbo].[Gradebook]  WITH NOCHECK ADD  CONSTRAINT [FK_Gradebook_PClass] FOREIGN KEY([pClassId])
REFERENCES [dbo].[PClass] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Gradebook] CHECK CONSTRAINT [FK_Gradebook_PClass]
GO
ALTER TABLE [dbo].[Mark]  WITH NOCHECK ADD  CONSTRAINT [FK_Mark_Marks] FOREIGN KEY([marksId])
REFERENCES [dbo].[Marks] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_Marks]
GO
ALTER TABLE [dbo].[Marks]  WITH NOCHECK ADD  CONSTRAINT [FK_Marks_Pupil] FOREIGN KEY([pupilId])
REFERENCES [dbo].[Pupil] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Pupil]
GO
ALTER TABLE [dbo].[Marks]  WITH NOCHECK ADD  CONSTRAINT [FK_Marks_Subject] FOREIGN KEY([subjectId])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Subject]
GO
ALTER TABLE [dbo].[PClass]  WITH NOCHECK ADD  CONSTRAINT [FK_PClass_FieldOfStudy] FOREIGN KEY([fieldOfStudyId])
REFERENCES [dbo].[FieldOfStudy] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PClass] CHECK CONSTRAINT [FK_PClass_FieldOfStudy]
GO
ALTER TABLE [dbo].[PClass]  WITH NOCHECK ADD  CONSTRAINT [FK_PClass_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PClass] CHECK CONSTRAINT [FK_PClass_User]
GO
ALTER TABLE [dbo].[Pupil]  WITH NOCHECK ADD  CONSTRAINT [FK_Pupil_PClass] FOREIGN KEY([pClassId])
REFERENCES [dbo].[PClass] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pupil] CHECK CONSTRAINT [FK_Pupil_PClass]
GO
ALTER TABLE [dbo].[Subject]  WITH NOCHECK ADD  CONSTRAINT [FK_Subject_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_User]
GO
ALTER TABLE [dbo].[SubjectLesson]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLesson_Gradebook] FOREIGN KEY([gradebookId])
REFERENCES [dbo].[Gradebook] ([id])
GO
ALTER TABLE [dbo].[SubjectLesson] CHECK CONSTRAINT [FK_SubjectLesson_Gradebook]
GO
ALTER TABLE [dbo].[SubjectLesson]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLesson_Subject] FOREIGN KEY([subjectId])
REFERENCES [dbo].[Subject] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectLesson] CHECK CONSTRAINT [FK_SubjectLesson_Subject]
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLessonsHaveAbsentees_Pupil] FOREIGN KEY([pupilId])
REFERENCES [dbo].[Pupil] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees] CHECK CONSTRAINT [FK_SubjectLessonsHaveAbsentees_Pupil]
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLessonsHaveAbsentees_SubjectLesson] FOREIGN KEY([subjectLessonId])
REFERENCES [dbo].[SubjectLesson] ([id])
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees] CHECK CONSTRAINT [FK_SubjectLessonsHaveAbsentees_SubjectLesson]
GO
ALTER TABLE [dbo].[UserHasRoles]  WITH NOCHECK ADD  CONSTRAINT [FK_UserHasRoles_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserHasRoles] CHECK CONSTRAINT [FK_UserHasRoles_Role]
GO
ALTER TABLE [dbo].[UserHasRoles]  WITH NOCHECK ADD  CONSTRAINT [FK_UserHasRoles_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserHasRoles] CHECK CONSTRAINT [FK_UserHasRoles_User]
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyDelete]
@Id int
AS
DELETE FROM FieldOfStudy WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyDeleteSubject]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyDeleteSubject]
@Id int
AS
DELETE FROM FieldOfStudyHasSubjects WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyGetAll]
AS
SELECT * FROM FieldOfStudy
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyGetById]
@Id int
AS
SELECT * FROM FieldOfStudy WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyGetSubjectsById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyGetSubjectsById]
@Id int
AS
SELECT * FROM FieldOfStudyHasSubjects WHERE fieldOfStudyId = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyInsert]
@Name nvarchar(50)
AS
INSERT INTO FieldOfStudy (name) VALUES(@Name)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyInsertSubject]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyInsertSubject]
@fieldOfStudy int,
@subjectId int
AS
INSERT INTO FieldOfStudyHasSubjects (fieldOfStudyId, subjectId) VALUES(@fieldOfStudy, @subjectId)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyUpdate]
@Id int,
@Name nvarchar(50)
AS
UPDATE FieldOfStudy SET name = @Name WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GradebookDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookDelete]
@Id int
AS
DELETE FROM Gradebook WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GradebookGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookGetAll]
AS
SELECT * FROM Gradebook
GO
/****** Object:  StoredProcedure [dbo].[GradebookGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookGetById]
@Id int
AS
SELECT * FROM Gradebook WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GradebookInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookInsert]
@PClassId int,
@SchoolYearStart datetime,
@SchoolYearEnd datetime,
@Editable bit
AS
INSERT INTO Gradebook (pClassId, schoolYearStart, schoolYearEnd, editable) VALUES(@PClassId, @SchoolYearStart, @SchoolYearEnd, @Editable)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[GradebookUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookUpdate]
@Id int,
@PClassId int,
@SchoolYearStart datetime,
@SchoolYearEnd datetime,
@Editable bit
AS
UPDATE Gradebook SET pClassId = @PClassId, schoolYearStart = @SchoolYearStart, schoolYearEnd = @SchoolYearEnd, editable = @Editable WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[ListAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListAll]
AS
EXEC sp_MSFOREACHTABLE 'SELECT * FROM ?'
GO
/****** Object:  StoredProcedure [dbo].[MarkDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkDelete]
@Id int
AS
DELETE FROM Mark WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetAll]
AS
SELECT * FROM Mark
GO
/****** Object:  StoredProcedure [dbo].[MarkGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetById]
@Id int
AS
SELECT * FROM Mark WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkInsert]
@MarksId int,
@Mark int
AS
INSERT INTO Mark (marksId, mark) VALUES(@MarksId, @Mark)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[MarksDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksDelete]
@Id int
AS
DELETE FROM Marks WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarksGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksGetAll]
AS
SELECT * FROM Marks
GO
/****** Object:  StoredProcedure [dbo].[MarksGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksGetById]
@Id int
AS
SELECT * FROM Marks WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarksInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksInsert]
@PupilId int,
@SubjectId int,
@FinalMark int
AS
INSERT INTO Marks (pupilId, subjectId, finalMark) VALUES(@PupilId,@SubjectId,@FinalMark)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[MarksUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksUpdate]
@Id int,
@PupilId int,
@SubjectId int,
@FinalMark int
AS
UPDATE Marks SET pupilId = @PupilId, subjectId = @SubjectId, finalMark = @FinalMark WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkUpdate]
@Id int,
@MarksId int,
@Mark int
AS
UPDATE Mark SET marksId = @MarksId, mark = @Mark WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassDelete]
@Id int
AS
DELETE FROM PClass WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetAll]
AS
SELECT * FROM PClass
GO
/****** Object:  StoredProcedure [dbo].[PClassGetAllByUserId]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetAllByUserId]
@Id int
AS
SELECT * FROM PClass WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetById]
@Id int
AS
SELECT * FROM PClass WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassInsert]
@userId int,
@fieldOfStudyId int,
@generation datetime,
@Year nvarchar(4),
@PClassIndex int
AS
INSERT INTO PClass (userId, fieldOfStudyId, generation, Year, PClassIndex) VALUES(@userId, @fieldOfStudyId, @generation, @Year, @PClassIndex)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[PClassUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassUpdate]
@Id int,
@userId int,
@fieldOfStudyId int,
@generation datetime,
@Year nvarchar(4),
@PClassIndex int
AS
UPDATE PClass SET userId = @userId, fieldOfStudyId = @fieldOfStudyId, generation = @generation, Year = @Year, PClassIndex = @PClassIndex WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PupilDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilDelete]
@Id int
AS
DELETE FROM Pupil WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PupilGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilGetAll]
AS
SELECT * FROM Pupil
GO
/****** Object:  StoredProcedure [dbo].[PupilGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilGetById]
@Id int
AS
SELECT * FROM Pupil WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PupilInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilInsert]
@PClassId int,
@Name nvarchar(50)
AS
INSERT INTO Pupil (pClassId, name) VALUES(@PClassId, @Name)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[PupilUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilUpdate]
@Id int,
@PClassId int,
@Name nvarchar(50)
AS
UPDATE Pupil SET pClassId = @PClassId, name = @Name WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleDelete]
@Id int
AS
DELETE FROM Role WHERE id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetAll]
AS
SELECT * FROM Role
GO
/****** Object:  StoredProcedure [dbo].[RoleGetAllByUserId]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetAllByUserId]
@Id int
AS
SELECT * FROM Role INNER JOIN UserHasRoles ON Role.id = UserHasRoles.roleId WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetById]
@Id int
AS
SELECT * FROM Role WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleInsert]
@Name nvarchar(15)
AS
INSERT INTO Role (name) VALUES(@Name)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleUpdate]
@Id int,
@Name nvarchar(15)
AS
UPDATE Role SET name = @Name WHERE id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectDelete]
@Id int
AS
DELETE FROM Subject WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetAll]
AS
SELECT * FROM Subject
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetAllByUserId]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetAllByUserId]
@Id int
AS
SELECT * FROM Subject WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetById]
@Id int
AS
SELECT * FROM Subject WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectInsert]
@userId int,
@name nvarchar(50)
AS
INSERT INTO Subject (userId,name) VALUES(@userId,@name)
SELECT CAST(SCOPE_IDENTITY() AS int)
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonAbsenteesGetAllById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonAbsenteesGetAllById]
@Id int
AS
SELECT * FROM SubjectLessonsHaveAbsentees WHERE subjectLessonId = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonDelete]
@Id int
AS
DELETE FROM SubjectLesson WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonDeleteAbsentee]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonDeleteAbsentee]
@Id int
AS
DELETE FROM SubjectLessonsHaveAbsentees WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonGetAll]
AS
SELECT * FROM SubjectLesson
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonGetById]
@Id int
AS
SELECT * FROM SubjectLesson WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonInsert]
@GradebookId int,
@SubjectId int,
@LessonTheme nvarchar(254),
@Date datetime,
@TimeOfLesson nvarchar(3)
AS
INSERT INTO SubjectLesson (gradebookId,subjectId,lessonTheme,date,timeOfLesson) VALUES(@GradebookId,@SubjectId,@LessonTheme,@Date,@TimeOfLesson)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonInsertAbsentee]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonInsertAbsentee]
@subjectLessonId int,
@pupilId int
AS
INSERT INTO SubjectLessonsHaveAbsentees (subjectLessonId, pupilId) VALUES(@subjectLessonId, @pupilId)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonUpdate]
@Id int,
@GradebookId int,
@SubjectId int,
@LessonTheme nvarchar(254),
@Date datetime,
@TimeOfLesson nvarchar(3)
AS
UPDATE SubjectLesson SET gradebookId = @GradebookId, subjectId = @SubjectId, lessonTheme = @LessonTheme, date = @Date, timeOfLesson = @TimeOfLesson WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectUpdate]
@Id int,
@userId int,
@name nvarchar(50)
AS
UPDATE Subject SET userId = @userId, name = @name WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[TruncateAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TruncateAll]
AS
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
EXEC sp_MSForEachTable 'ALTER TABLE ? DISABLE TRIGGER ALL'
EXEC sp_MSForEachTable 'DELETE FROM ?'
EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
EXEC sp_MSForEachTable 'ALTER TABLE ? ENABLE TRIGGER ALL'
EXEC sp_MSFOREACHTABLE 'SELECT * FROM ?'
GO
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserDelete]
@Id int
AS
DELETE FROM [User] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserGetAll]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetAll]
AS
SELECT * FROM [User]
GO
/****** Object:  StoredProcedure [dbo].[UserGetById]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetById]
@Id int
AS
SELECT * FROM [User] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserInsert]
@Name nvarchar(25),
@Surname nvarchar(25),
@Username nvarchar(30),
@Password nvarchar(50),
@Email nvarchar(254)
AS
INSERT INTO [User] (Name,Surname,Username,Password,Email) VALUES(@Name,@Surname,@Username,@Password,@Email)
SELECT CAST(SCOPE_IDENTITY() AS int)
GO
/****** Object:  StoredProcedure [dbo].[UserRoleDelete]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRoleDelete]
@Id int
AS
DELETE FROM UserHasRoles WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserRoleInsert]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRoleInsert]
@UserId int,
@RoleId int
AS
INSERT INTO UserHasRoles (userId, roleId) VALUES(@UserId, @RoleId)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[UserRolesGetByUserId]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRolesGetByUserId]
@Id int
AS
SELECT * FROM UserHasRoles WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 10/1/2017 4:39:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserUpdate]
@Id int,
@Name nvarchar(25),
@Surname nvarchar(25),
@Username nvarchar(30),
@Password nvarchar(50),
@Email nvarchar(254)
AS
UPDATE [User] SET Name = @Name, Surname = @Surname, Username = @Username, Password = @Password, Email = @Email  WHERE Id = @Id
GO
USE [master]
GO
ALTER DATABASE [Max.Gradebook] SET  READ_WRITE 
GO
