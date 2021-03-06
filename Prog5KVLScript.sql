USE [master]
GO
/****** Object:  Database [PR_r0444972]    Script Date: 29/01/2021 10:51:22 ******/
CREATE DATABASE [PR_r0444972]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PR_r0444972mdf', FILENAME = N'C:\DATA\PR_r0444972.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PR_r0444972ldf', FILENAME = N'C:\DATA\PR_r0444972_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PR_r0444972] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PR_r0444972].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PR_r0444972] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PR_r0444972] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PR_r0444972] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PR_r0444972] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PR_r0444972] SET ARITHABORT OFF 
GO
ALTER DATABASE [PR_r0444972] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PR_r0444972] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PR_r0444972] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PR_r0444972] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PR_r0444972] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PR_r0444972] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PR_r0444972] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PR_r0444972] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PR_r0444972] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PR_r0444972] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PR_r0444972] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PR_r0444972] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PR_r0444972] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PR_r0444972] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PR_r0444972] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PR_r0444972] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PR_r0444972] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PR_r0444972] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PR_r0444972] SET  MULTI_USER 
GO
ALTER DATABASE [PR_r0444972] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PR_r0444972] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PR_r0444972] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PR_r0444972] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PR_r0444972] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PR_r0444972', N'ON'
GO
ALTER DATABASE [PR_r0444972] SET QUERY_STORE = OFF
GO
USE [PR_r0444972]
GO
/****** Object:  User [pr__r0444972]    Script Date: 29/01/2021 10:51:22 ******/
CREATE USER [pr__r0444972] FOR LOGIN [pr__r0444972] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [pr__r0444972]
GO
/****** Object:  Schema [BH]    Script Date: 29/01/2021 10:51:22 ******/
CREATE SCHEMA [BH]
GO
/****** Object:  Table [BH].[Afhaalpunt]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[Afhaalpunt](
	[AfhaalpuntId] [int] IDENTITY(1,1) NOT NULL,
	[Omschrijving] [nvarchar](100) NOT NULL,
	[Adres] [nvarchar](100) NOT NULL,
	[Postcode] [nvarchar](100) NOT NULL,
	[stad] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Afhaalpunt] PRIMARY KEY CLUSTERED 
(
	[AfhaalpuntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [BH].[AspNetRoleClaims]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [BH].[AspNetRoles]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [BH].[AspNetUserClaims]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [BH].[AspNetUserLogins]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [BH].[AspNetUserRoles]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [BH].[AspNetUsers]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [BH].[AspNetUserTokens]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [BH].[Ingredient]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[Ingredient](
	[IngredientId] [int] IDENTITY(1,1) NOT NULL,
	[Soort] [nvarchar](100) NOT NULL,
	[Allergeen] [nvarchar](100) NOT NULL,
	[Voorraad] [int] NOT NULL,
	[Prijs] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [BH].[Klant]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[Klant](
	[KlantId] [int] IDENTITY(1,1) NOT NULL,
	[Voornaam] [nvarchar](max) NULL,
	[Naam] [nvarchar](max) NULL,
	[Postcode] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Telefoon] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Klant] PRIMARY KEY CLUSTERED 
(
	[KlantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [BH].[Order]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[KlantId] [int] NOT NULL,
	[AfhaalpuntId] [int] NOT NULL,
	[Orderdatum] [datetime2](7) NOT NULL,
	[LeverDatum] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [BH].[Orderlijn]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[Orderlijn](
	[OrderlijnId] [int] IDENTITY(1,1) NOT NULL,
	[Productid] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Aantal] [int] NOT NULL,
 CONSTRAINT [PK_Orderlijn] PRIMARY KEY CLUSTERED 
(
	[OrderlijnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [BH].[Product]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](100) NOT NULL,
	[Prijs] [decimal](18, 2) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [BH].[Productregel]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BH].[Productregel](
	[ProductregelId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
	[Aantal] [int] NOT NULL,
 CONSTRAINT [PK_Productregel] PRIMARY KEY CLUSTERED 
(
	[ProductregelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/01/2021 10:51:22 ******/
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
/****** Object:  Table [dbo].[Klant]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klant](
	[KlantId] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](max) NULL,
	[Voornaam] [nvarchar](max) NULL,
	[AangemaaktDatum] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Klant] PRIMARY KEY CLUSTERED 
(
	[KlantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Landen]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Landen](
	[CountryId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Landen] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Artikel] [nvarchar](max) NULL,
	[Prijs] [decimal](18, 2) NOT NULL,
	[KlantId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Races]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Races](
	[RaceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CountryId] [int] NULL,
	[Length] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[X] [int] NOT NULL,
	[Y] [int] NOT NULL,
 CONSTRAINT [PK_Races] PRIMARY KEY CLUSTERED 
(
	[RaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Riders]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Riders](
	[RiderId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[CountryId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[Bike] [nvarchar](max) NULL,
	[Number] [float] NOT NULL,
 CONSTRAINT [PK_Riders] PRIMARY KEY CLUSTERED 
(
	[RiderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 29/01/2021 10:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[TicketId1] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
	[CountryId] [int] NOT NULL,
	[RaceId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Orderdate] [datetime2](7) NOT NULL,
	[Paid] [bit] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [BH].[Afhaalpunt] ON 

INSERT [BH].[Afhaalpunt] ([AfhaalpuntId], [Omschrijving], [Adres], [Postcode], [stad]) VALUES (1, N'De beste bakkerij', N'Kleinhoefstraat 4', N'2270', N'Geel')
INSERT [BH].[Afhaalpunt] ([AfhaalpuntId], [Omschrijving], [Adres], [Postcode], [stad]) VALUES (2, N'Bakkerij Het Lekker Koekske', N'Monnikendijk 5', N'2260', N'Westerlo')
SET IDENTITY_INSERT [BH].[Afhaalpunt] OFF
GO
INSERT [BH].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7f3e33a6-4794-498e-a7c7-a76f69027706', N'Admin', N'ADMIN', N'21d05045-982a-4023-878e-f82eaa8fd3a9')
GO
INSERT [BH].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'253c096f-1f8c-46b0-a0d9-4035a3ab4703', N'7f3e33a6-4794-498e-a7c7-a76f69027706')
INSERT [BH].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'999d472e-180c-4103-a02d-3c05895e4b19', N'7f3e33a6-4794-498e-a7c7-a76f69027706')
GO
INSERT [BH].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'253c096f-1f8c-46b0-a0d9-4035a3ab4703', N'nieuw@hotmail.com', N'NIEUW@HOTMAIL.COM', N'nieuw@hotmail.com', N'NIEUW@HOTMAIL.COM', 0, N'AQAAAAEAACcQAAAAELKqN36540l/E1q1TbmbZjHWsl5dsbixqxk/2hdkU2DY1Pndn0qqU9cX7egKlxQ+AQ==', N'BSRCY2ASRFF5AAPRSSMQUDFIC7OHQNLN', N'd0b27950-8eec-4b5c-a1d0-4d58a9fbe53d', N'014541513', 0, 0, NULL, 1, 0)
INSERT [BH].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'999d472e-180c-4103-a02d-3c05895e4b19', N'koen@hotmail.com', N'KOEN@HOTMAIL.COM', N'koen@hotmail.com', N'KOEN@HOTMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPmZxXMZ1ObuHUZtYEIcEoxvGpIokx79DbZeeavpkCd1KC/rv1jJ05CKeF8ej9i0hA==', N'WFNN2SR6ZPGZTBGWJ6BPCU4N3BM356KV', N'de8d1519-fd22-4844-bb7c-2eb76a6d0909', N'014541513', 0, 0, NULL, 1, 0)
INSERT [BH].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c6a6e2e2-9d54-4e98-9d00-1e75b7dfc3e3', N'r0444972@student.thomasmore.be', N'R0444972@STUDENT.THOMASMORE.BE', N'r0444972@student.thomasmore.be', N'R0444972@STUDENT.THOMASMORE.BE', 0, N'AQAAAAEAACcQAAAAEKqN5GXM+4A2S9Xj4C/x2BooIKNOgQKO2+H/4kPxLzOoH3DnwgUsPy13Wxd+TX2Qsw==', N'6LGXIEO62LBX3SPTAQ6XMR4Z2EQMR3XM', N'7b43e6bc-d0da-4c88-916f-5b925ca1008c', NULL, 0, 0, NULL, 1, 0)
INSERT [BH].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f6a39629-e3ec-48d0-9f6f-4c8389d61555', N'klant@hotmail.com', N'KLANT@HOTMAIL.COM', N'klant@hotmail.com', N'KLANT@HOTMAIL.COM', 0, N'AQAAAAEAACcQAAAAECmmMyhJdMBhGBv6ktOOomTDi83eiV+MMFaiMgymWQLdipsM9TIZChgjDzeqCpBUCw==', N'STA3LHNIKWTXLIG53RWA3BONZHEODPVJ', N'9026fa9d-febe-4f18-8b09-6591d3d50019', N'014549090', 0, 0, NULL, 1, 0)
GO
INSERT [BH].[AspNetUserTokens] ([UserId], [LoginProvider], [Name], [Value]) VALUES (N'999d472e-180c-4103-a02d-3c05895e4b19', N'[AspNetUserStore]', N'AuthenticatorKey', N'R2BWOVOZM47OTGMDOREAHUXQZTPP4TF2')
GO
SET IDENTITY_INSERT [BH].[Ingredient] ON 

INSERT [BH].[Ingredient] ([IngredientId], [Soort], [Allergeen], [Voorraad], [Prijs]) VALUES (1, N'Melk.png', N'Melk', 20, CAST(2.50 AS Decimal(18, 2)))
INSERT [BH].[Ingredient] ([IngredientId], [Soort], [Allergeen], [Voorraad], [Prijs]) VALUES (2, N'Ei.png', N'Ei', 20, CAST(1.00 AS Decimal(18, 2)))
INSERT [BH].[Ingredient] ([IngredientId], [Soort], [Allergeen], [Voorraad], [Prijs]) VALUES (3, N'gluten.png', N'Gluten', 10, CAST(4.00 AS Decimal(18, 2)))
INSERT [BH].[Ingredient] ([IngredientId], [Soort], [Allergeen], [Voorraad], [Prijs]) VALUES (4, N'noten.png', N'Noten', 10, CAST(4.00 AS Decimal(18, 2)))
INSERT [BH].[Ingredient] ([IngredientId], [Soort], [Allergeen], [Voorraad], [Prijs]) VALUES (5, N'pindas.png', N'pindas', 10, CAST(2.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [BH].[Ingredient] OFF
GO
SET IDENTITY_INSERT [BH].[Klant] ON 

INSERT [BH].[Klant] ([KlantId], [Voornaam], [Naam], [Postcode], [Email], [Telefoon], [UserId]) VALUES (1, N'Koen', N'Van Looy', N'2260', N'nieuw@hotmail.com', N'014541513', N'253c096f-1f8c-46b0-a0d9-4035a3ab4703')
INSERT [BH].[Klant] ([KlantId], [Voornaam], [Naam], [Postcode], [Email], [Telefoon], [UserId]) VALUES (2, N'Danny', N'Wouters', N'2260', N'klant@hotmail.com', N'014549090', N'f6a39629-e3ec-48d0-9f6f-4c8389d61555')
SET IDENTITY_INSERT [BH].[Klant] OFF
GO
SET IDENTITY_INSERT [BH].[Order] ON 

INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (4, 1, 1, CAST(N'2021-01-23T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (5, 1, 1, CAST(N'2021-01-23T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (6, 1, 1, CAST(N'2021-01-23T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (7, 1, 1, CAST(N'2021-01-24T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (8, 1, 1, CAST(N'2021-01-24T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (9, 1, 1, CAST(N'2021-01-23T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (10, 1, 1, CAST(N'2021-01-25T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (11, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-23T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (12, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-23T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (13, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-24T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (14, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-25T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (15, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-24T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (16, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-24T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (17, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-24T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (18, 2, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-24T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (19, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-25T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (20, 1, 2, CAST(N'2021-01-25T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-25T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (21, 1, 2, CAST(N'2021-01-25T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-25T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (22, 1, 2, CAST(N'2021-01-26T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-26T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (23, 1, 2, CAST(N'2021-01-26T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-26T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (24, 1, 2, CAST(N'2021-01-26T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-26T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (25, 1, 2, CAST(N'2021-01-26T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-26T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (26, 1, 2, CAST(N'2021-01-28T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-28T00:00:00.0000000' AS DateTime2))
INSERT [BH].[Order] ([OrderId], [KlantId], [AfhaalpuntId], [Orderdatum], [LeverDatum]) VALUES (27, 1, 2, CAST(N'2021-01-29T00:00:00.0000000' AS DateTime2), CAST(N'2021-01-29T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [BH].[Order] OFF
GO
SET IDENTITY_INSERT [BH].[Orderlijn] ON 

INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (1, 8, 5, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (2, 9, 6, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (3, 8, 6, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (4, 8, 8, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (5, 8, 9, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (6, 8, 10, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (7, 8, 11, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (8, 8, 12, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (9, 8, 14, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (10, 8, 17, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (11, 8, 18, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (12, 8, 20, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (13, 8, 21, 4)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (14, 9, 21, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (15, 8, 22, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (16, 8, 25, 2)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (17, 19, 27, 1)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (18, 13, 27, 1)
INSERT [BH].[Orderlijn] ([OrderlijnId], [Productid], [OrderId], [Aantal]) VALUES (19, 15, 27, 1)
SET IDENTITY_INSERT [BH].[Orderlijn] OFF
GO
SET IDENTITY_INSERT [BH].[Product] ON 

INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (8, N'Regenboogtaart', CAST(15.00 AS Decimal(18, 2)), N'Taart', N'Regenboogtaart.jpg')
INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (9, N'Roomtaart', CAST(20.00 AS Decimal(18, 2)), N'Taart', N'Roomtaart.jpg')
INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (10, N'Appeltaart', CAST(10.50 AS Decimal(18, 2)), N'Taart', N'Appeltaartproduct.jpg')
INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (11, N'Rabarbertaart', CAST(15.00 AS Decimal(18, 2)), N'Taart', N'Rabarbertaart.jpg')
INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (13, N'Appelcake', CAST(10.00 AS Decimal(18, 2)), N'Cake', N'Appelcake.jpg')
INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (15, N'Pindabrownie', CAST(7.50 AS Decimal(18, 2)), N'Brownie', N'PindaBrownie.jpg')
INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (16, N'Marshmellowbrownie', CAST(7.50 AS Decimal(18, 2)), N'Brownie', N'MMBrownie.jpg')
INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (17, N'Chocoladecake', CAST(10.00 AS Decimal(18, 2)), N'Cake', N'Chocolatecake.jpg')
INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (19, N'Neapolitancupcake', CAST(15.00 AS Decimal(18, 2)), N'Cupcake', N'Neapolitancupcake.jpg')
INSERT [BH].[Product] ([ProductId], [Naam], [Prijs], [Type], [Image]) VALUES (20, N'ChocoladeCupcake', CAST(7.50 AS Decimal(18, 2)), N'Cupcake', N'ChocoCupcake.jpg')
SET IDENTITY_INSERT [BH].[Product] OFF
GO
SET IDENTITY_INSERT [BH].[Productregel] ON 

INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (1, 8, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (2, 8, 2, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (3, 9, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (4, 9, 2, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (5, 10, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (6, 10, 2, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (7, 11, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (8, 11, 3, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (9, 11, 5, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (20, 15, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (21, 15, 2, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (22, 15, 5, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (23, 16, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (24, 16, 2, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (25, 16, 3, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (26, 17, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (27, 17, 2, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (28, 17, 3, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (65, 19, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (66, 19, 2, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (67, 19, 3, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (72, 20, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (73, 20, 2, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (74, 20, 4, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (75, 20, 5, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (80, 13, 1, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (81, 13, 2, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (82, 13, 3, 0)
INSERT [BH].[Productregel] ([ProductregelId], [ProductId], [IngredientId], [Aantal]) VALUES (83, 13, 4, 0)
SET IDENTITY_INSERT [BH].[Productregel] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201108190213_InitialCreate', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201124191025_InitialCreate', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201208161641_AddIdentitySchema', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201221140833_image', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201221175530_Faultrecovery', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201223154742_Bugfix', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210118190419_CustomUserData', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210128122541_Collectiontolist', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210129094800_Validation', N'3.1.10')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [BH].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 29/01/2021 10:51:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [BH].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [BH].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [BH].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [BH].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [BH].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 29/01/2021 10:51:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [BH].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Klant_UserId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Klant_UserId] ON [BH].[Klant]
(
	[UserId] ASC
)
WHERE ([UserId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_AfhaalpuntId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Order_AfhaalpuntId] ON [BH].[Order]
(
	[AfhaalpuntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_KlantId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Order_KlantId] ON [BH].[Order]
(
	[KlantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orderlijn_OrderId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Orderlijn_OrderId] ON [BH].[Orderlijn]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orderlijn_Productid]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Orderlijn_Productid] ON [BH].[Orderlijn]
(
	[Productid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Productregel_IngredientId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Productregel_IngredientId] ON [BH].[Productregel]
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Productregel_ProductId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Productregel_ProductId] ON [BH].[Productregel]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_KlantId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Order_KlantId] ON [dbo].[Order]
(
	[KlantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Races_CountryId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Races_CountryId] ON [dbo].[Races]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Riders_CountryId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Riders_CountryId] ON [dbo].[Riders]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Riders_TeamId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Riders_TeamId] ON [dbo].[Riders]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_CountryId]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_CountryId] ON [dbo].[Tickets]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_TicketId1]    Script Date: 29/01/2021 10:51:24 ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_TicketId1] ON [dbo].[Tickets]
(
	[TicketId1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [BH].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [BH].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [BH].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [BH].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [BH].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [BH].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [BH].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [BH].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [BH].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [BH].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [BH].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [BH].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [BH].[Klant]  WITH CHECK ADD  CONSTRAINT [FK_Klant_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [BH].[AspNetUsers] ([Id])
GO
ALTER TABLE [BH].[Klant] CHECK CONSTRAINT [FK_Klant_AspNetUsers_UserId]
GO
ALTER TABLE [BH].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Afhaalpunt_AfhaalpuntId] FOREIGN KEY([AfhaalpuntId])
REFERENCES [BH].[Afhaalpunt] ([AfhaalpuntId])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[Order] CHECK CONSTRAINT [FK_Order_Afhaalpunt_AfhaalpuntId]
GO
ALTER TABLE [BH].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Klant_KlantId] FOREIGN KEY([KlantId])
REFERENCES [BH].[Klant] ([KlantId])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[Order] CHECK CONSTRAINT [FK_Order_Klant_KlantId]
GO
ALTER TABLE [BH].[Orderlijn]  WITH CHECK ADD  CONSTRAINT [FK_Orderlijn_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [BH].[Order] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[Orderlijn] CHECK CONSTRAINT [FK_Orderlijn_Order_OrderId]
GO
ALTER TABLE [BH].[Orderlijn]  WITH CHECK ADD  CONSTRAINT [FK_Orderlijn_Product_Productid] FOREIGN KEY([Productid])
REFERENCES [BH].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[Orderlijn] CHECK CONSTRAINT [FK_Orderlijn_Product_Productid]
GO
ALTER TABLE [BH].[Productregel]  WITH CHECK ADD  CONSTRAINT [FK_Productregel_Ingredient_IngredientId] FOREIGN KEY([IngredientId])
REFERENCES [BH].[Ingredient] ([IngredientId])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[Productregel] CHECK CONSTRAINT [FK_Productregel_Ingredient_IngredientId]
GO
ALTER TABLE [BH].[Productregel]  WITH CHECK ADD  CONSTRAINT [FK_Productregel_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [BH].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [BH].[Productregel] CHECK CONSTRAINT [FK_Productregel_Product_ProductId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Klant_KlantId] FOREIGN KEY([KlantId])
REFERENCES [dbo].[Klant] ([KlantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Klant_KlantId]
GO
ALTER TABLE [dbo].[Races]  WITH CHECK ADD  CONSTRAINT [FK_Races_Landen_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Landen] ([CountryId])
GO
ALTER TABLE [dbo].[Races] CHECK CONSTRAINT [FK_Races_Landen_CountryId]
GO
ALTER TABLE [dbo].[Riders]  WITH CHECK ADD  CONSTRAINT [FK_Riders_Landen_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Landen] ([CountryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Riders] CHECK CONSTRAINT [FK_Riders_Landen_CountryId]
GO
ALTER TABLE [dbo].[Riders]  WITH CHECK ADD  CONSTRAINT [FK_Riders_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Riders] CHECK CONSTRAINT [FK_Riders_Teams_TeamId]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Landen_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Landen] ([CountryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Landen_CountryId]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Tickets_TicketId1] FOREIGN KEY([TicketId1])
REFERENCES [dbo].[Tickets] ([TicketId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Tickets_TicketId1]
GO
USE [master]
GO
ALTER DATABASE [PR_r0444972] SET  READ_WRITE 
GO
