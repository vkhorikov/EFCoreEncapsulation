USE [EFCoreEncapsulation]
GO
/****** Object:  Table [dbo].[Sports]    Script Date: 1/27/2022 6:26:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sports](
	[SportsID] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sports] PRIMARY KEY CLUSTERED 
(
	[SportsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SportsEnrollment]    Script Date: 1/27/2022 6:26:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SportsEnrollment](
	[SportsEnrollmentID] [bigint] NOT NULL,
	[SportsID] [bigint] NOT NULL,
	[StudentID] [bigint] NOT NULL,
	[Grade] [int] NOT NULL,
 CONSTRAINT [PK_SportsEnrollment] PRIMARY KEY CLUSTERED 
(
	[SportsEnrollmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Sports] ([SportsID], [Name]) VALUES (1, N'Tennis')
GO
INSERT [dbo].[Sports] ([SportsID], [Name]) VALUES (2, N'Football')
GO
INSERT [dbo].[SportsEnrollment] ([SportsEnrollmentID], [SportsID], [StudentID], [Grade]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[SportsEnrollment] ([SportsEnrollmentID], [SportsID], [StudentID], [Grade]) VALUES (2, 2, 1, 2)
GO
ALTER TABLE [dbo].[SportsEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_SportsEnrollment_Sports] FOREIGN KEY([SportsID])
REFERENCES [dbo].[Sports] ([SportsID])
GO
ALTER TABLE [dbo].[SportsEnrollment] CHECK CONSTRAINT [FK_SportsEnrollment_Sports]
GO
ALTER TABLE [dbo].[SportsEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_SportsEnrollment_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[SportsEnrollment] CHECK CONSTRAINT [FK_SportsEnrollment_Student]
GO
