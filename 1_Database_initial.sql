CREATE DATABASE [EFCoreEncapsulation]
GO
USE [EFCoreEncapsulation]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 1/15/2022 8:19:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 1/15/2022 8:19:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentID] [bigint] IDENTITY(1,1) NOT NULL,
	[CourseID] [bigint] NOT NULL,
	[StudentID] [bigint] NOT NULL,
	[Grade] [int] NOT NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/15/2022 8:19:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (1, N'Calculus')
GO
INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (2, N'Chemistry')
GO
INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (3, N'Literature')
GO
INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (4, N'Trigonometry')
GO
INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (5, N'Microeconomics')
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([StudentID], [Name], [Email]) VALUES (1, N'Alice', N'alice@gmail.com')
GO
INSERT [dbo].[Student] ([StudentID], [Name], [Email]) VALUES (2, N'Bob', N'bob@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Enrollment] ON 
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (2, 2, 1, 2)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (3, 1, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Course]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Student]
GO
