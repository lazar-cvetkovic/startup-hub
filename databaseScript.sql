USE [master]
GO
/****** Object:  Database [startuphub]    Script Date: 7/10/2024 12:29:13 PM ******/
CREATE DATABASE [startuphub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'startuphub', FILENAME = N'C:\Users\Lazar\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\startuphub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'startuphub_log', FILENAME = N'C:\Users\Lazar\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\startuphub.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [startuphub] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [startuphub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [startuphub] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [startuphub] SET ANSI_NULLS ON 
GO
ALTER DATABASE [startuphub] SET ANSI_PADDING ON 
GO
ALTER DATABASE [startuphub] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [startuphub] SET ARITHABORT ON 
GO
ALTER DATABASE [startuphub] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [startuphub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [startuphub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [startuphub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [startuphub] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [startuphub] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [startuphub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [startuphub] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [startuphub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [startuphub] SET  DISABLE_BROKER 
GO
ALTER DATABASE [startuphub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [startuphub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [startuphub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [startuphub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [startuphub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [startuphub] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [startuphub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [startuphub] SET RECOVERY FULL 
GO
ALTER DATABASE [startuphub] SET  MULTI_USER 
GO
ALTER DATABASE [startuphub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [startuphub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [startuphub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [startuphub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [startuphub] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [startuphub] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [startuphub] SET QUERY_STORE = OFF
GO
USE [startuphub]
GO
/****** Object:  Table [dbo].[FundingProgram]    Script Date: 7/10/2024 12:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingProgram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Deadline] [datetime] NOT NULL,
	[FundingAmount] [varchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegisteredQuestion]    Script Date: 7/10/2024 12:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegisteredQuestion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
	[Question] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[UserId] ASC,
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StartupEvent]    Script Date: 7/10/2024 12:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StartupEvent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StartupEventRegistration]    Script Date: 7/10/2024 12:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StartupEventRegistration](
	[UserId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[DateOfRegistration] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/10/2024 12:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Role] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FundingProgram] ON 

INSERT [dbo].[FundingProgram] ([Id], [Name], [Description], [Deadline], [FundingAmount], [UserId]) VALUES (1, N'Raising Starts', N'Raising Starts is the first pre-seed program in Serbia that simultaneously provides professional and financial support (up to 20,000 CHF non-refundable, no participation, no equity) to startup teams and companies in the earliest stages of developing innovative products and services. The program is implemented by Science and Technology Park Belgrade, with the support of the Government of Switzerland, in partnership with Science and Technology Park Niš and Science and Technology Park Cacak.', CAST(N'2024-12-01T12:00:00.000' AS DateTime), N'CHF 15000', 1)
INSERT [dbo].[FundingProgram] ([Id], [Name], [Description], [Deadline], [FundingAmount], [UserId]) VALUES (2, N'Smart Start', N'The goal of the Smart Start program (Program) is to support highly promising teams in their efforts to validate their business ideas and demonstrate future usefulness of their technology through development of a first prototype or a minimum viable product (MVP).

The program Awardees will receive financial and mentorship support that will help them execute the first phase of market research, engage in product development, establish a business model and begin preparation for the next phase of fundraising. Furthermore, in addition to the mentorship support through the Program, if and where is applicable, the Innovation Fund (the IF) will organize a series of specifically targeted workshops that will help them deliver their projects successfully and better organize their operations and start-on their startups on the right foot.', CAST(N'2025-02-01T00:00:00.000' AS DateTime), N'45000 Euros', 1)
INSERT [dbo].[FundingProgram] ([Id], [Name], [Description], [Deadline], [FundingAmount], [UserId]) VALUES (3, N'MINI GRANTS PROGRAM', N'The Mini Grants Program is aimed at private young enterprises which are engaged in the development of technological innovations with a clear market need. This Program is designed to support the survival of companies during the critical phase of research and development and to allow Serbian entrepreneurs to grow effective business capacities through which they will launch their innovations on the market.', CAST(N'2024-04-01T00:00:00.000' AS DateTime), N'120000 Euros', 1)
INSERT [dbo].[FundingProgram] ([Id], [Name], [Description], [Deadline], [FundingAmount], [UserId]) VALUES (4, N'MATCHING GRANTS PROGRAM', N'The Matching Grants Program is designed for enterprises looking for significant financial resources for the commercialization of research and development. The Program has the goal to stimulate further knowledge-based development of innovative enterprises, encourage establishment of partnerships with international partners and to increase the number of technology-based companies.', CAST(N'2024-04-01T00:00:00.000' AS DateTime), N'500000 Euros', 1)
INSERT [dbo].[FundingProgram] ([Id], [Name], [Description], [Deadline], [FundingAmount], [UserId]) VALUES (1002, N'EmpoWomen', N'It offers female entrepreneurs in the deep-tech sector a chance for financial support, acceleration services and visibility on the EU markets, with the aim of improving innovation and diversity in the startup ecosystem.', CAST(N'2024-08-03T10:00:00.000' AS DateTime), N'60000 Euros', 1)
SET IDENTITY_INSERT [dbo].[FundingProgram] OFF
GO
SET IDENTITY_INSERT [dbo].[RegisteredQuestion] ON 

INSERT [dbo].[RegisteredQuestion] ([Id], [UserId], [EventId], [Question], [Description]) VALUES (1, 1, 3, N'what is love?', N'baby don''t hurt me :o')
INSERT [dbo].[RegisteredQuestion] ([Id], [UserId], [EventId], [Question], [Description]) VALUES (2, 2, 3, N'kako?', N'zasto?')
INSERT [dbo].[RegisteredQuestion] ([Id], [UserId], [EventId], [Question], [Description]) VALUES (1002, 1, 1004, N'Participants?', N'Who will be attending?')
INSERT [dbo].[RegisteredQuestion] ([Id], [UserId], [EventId], [Question], [Description]) VALUES (1003, 1, 1004, N'Food?', N'Is there going to be food?')
SET IDENTITY_INSERT [dbo].[RegisteredQuestion] OFF
GO
SET IDENTITY_INSERT [dbo].[StartupEvent] ON 

INSERT [dbo].[StartupEvent] ([Id], [Name], [Description], [Date], [Location], [UserId]) VALUES (3, N'Investor Office Hours', N'Investor Office Hours with the Eleven Ventures fund will be held on February 20 from 12:00 p.m. to 5:00 p.m. at the Tenderly office at Milutin Milankovica 7d.

The event is intended for startups that are in the pre-seed phase and are currently in the fundraising process.

Eleven Ventures fund representatives will send invitations to startups they want to meet with.', CAST(N'2024-02-20T00:00:00.000' AS DateTime), N'Milutin Milankovica 7d', 1)
INSERT [dbo].[StartupEvent] ([Id], [Name], [Description], [Date], [Location], [UserId]) VALUES (1004, N'PODIM 2024', N'It is a three-day tech and startup conference that connects early-stage startups with global investors and corporate giants, serving as a platform for creating collaborations and prospective investments.', CAST(N'2024-05-13T12:00:00.000' AS DateTime), N'Maribor, Slovenia', 1)
INSERT [dbo].[StartupEvent] ([Id], [Name], [Description], [Date], [Location], [UserId]) VALUES (1006, N'"What investors want to see in your pitch"', N'An opportunity for teams to find out what over 100 VC funds, angel investors and accelerators want to see in a pitch.

Launch Deck, which has helped startups raise over $60 million, is coming to the Haos Community Space to share valuable insights on how teams can transform their fundraising experience.', CAST(N'2024-02-22T12:00:00.000' AS DateTime), N'Belgrade, Serbia', 1)
INSERT [dbo].[StartupEvent] ([Id], [Name], [Description], [Date], [Location], [UserId]) VALUES (1007, N'Mondays with Bayern experts', N'During 12 weeks, experts from Bayern will talk about different but very important topics in the field of pharmaceutical innovation.

Participants will get the opportunity to hear how to prepare their pitch, approach investment funds, how corporate pharmacy and academia cooperate, and what the due diligence process looks like with a large pharmaceutical company.', CAST(N'2024-02-26T18:00:00.000' AS DateTime), N'Online', 1)
SET IDENTITY_INSERT [dbo].[StartupEvent] OFF
GO
INSERT [dbo].[StartupEventRegistration] ([UserId], [EventId], [Status], [DateOfRegistration]) VALUES (1, 3, N'Attending', CAST(N'2024-02-18T10:38:43.933' AS DateTime))
INSERT [dbo].[StartupEventRegistration] ([UserId], [EventId], [Status], [DateOfRegistration]) VALUES (2, 3, N'Cancelling', CAST(N'2024-02-18T10:39:34.893' AS DateTime))
INSERT [dbo].[StartupEventRegistration] ([UserId], [EventId], [Status], [DateOfRegistration]) VALUES (1, 1004, N'Cancelling', CAST(N'2024-02-18T14:00:19.880' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Email], [Name], [Password], [Role]) VALUES (1, N'admin@admin.com', N'admin', N'admin', N'Admin')
INSERT [dbo].[User] ([Id], [Email], [Name], [Password], [Role]) VALUES (2, N'laki@laki.com', N'laki', N'laki', N'0')
INSERT [dbo].[User] ([Id], [Email], [Name], [Password], [Role]) VALUES (1002, N'pera@peric.com', N'pera', N'peraperic', N'0')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[FundingProgram]  WITH CHECK ADD  CONSTRAINT [FK_FundingProgram_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FundingProgram] CHECK CONSTRAINT [FK_FundingProgram_User]
GO
ALTER TABLE [dbo].[RegisteredQuestion]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredQuestion_StartupEventRegistration] FOREIGN KEY([EventId], [UserId])
REFERENCES [dbo].[StartupEventRegistration] ([EventId], [UserId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RegisteredQuestion] CHECK CONSTRAINT [FK_RegisteredQuestion_StartupEventRegistration]
GO
ALTER TABLE [dbo].[StartupEvent]  WITH CHECK ADD  CONSTRAINT [FK_StartupEvent_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[StartupEvent] CHECK CONSTRAINT [FK_StartupEvent_User]
GO
ALTER TABLE [dbo].[StartupEventRegistration]  WITH CHECK ADD  CONSTRAINT [FK_StartupEventRegistration_StartupEvent] FOREIGN KEY([EventId])
REFERENCES [dbo].[StartupEvent] ([Id])
GO
ALTER TABLE [dbo].[StartupEventRegistration] CHECK CONSTRAINT [FK_StartupEventRegistration_StartupEvent]
GO
ALTER TABLE [dbo].[StartupEventRegistration]  WITH CHECK ADD  CONSTRAINT [FK_StartupEventRegistration_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[StartupEventRegistration] CHECK CONSTRAINT [FK_StartupEventRegistration_User]
GO
USE [master]
GO
ALTER DATABASE [startuphub] SET  READ_WRITE 
GO
