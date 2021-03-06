USE [master]
GO
/****** Object:  Database [ShopOnline]    Script Date: 5/5/2021 10:53:48 AM ******/
CREATE DATABASE [ShopOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.VANH\MSSQL\DATA\ShopOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.VANH\MSSQL\DATA\ShopOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopOnline] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopOnline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopOnline] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopOnline] SET  MULTI_USER 
GO
ALTER DATABASE [ShopOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopOnline] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopOnline', N'ON'
GO
ALTER DATABASE [ShopOnline] SET QUERY_STORE = OFF
GO
USE [ShopOnline]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Detail] [nvarchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfirmStatus]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfirmStatus](
	[ID] [int] NULL,
	[Name] [nvarchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Mobile] [varchar](15) NULL,
	[Title] [nvarchar](50) NULL,
	[Content] [text] NULL,
	[CreatedAt] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageDetail]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageDetail](
	[ID] [int] NULL,
	[ProductID] [int] NULL,
	[Description] [nvarchar](256) NULL,
	[Url] [varchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[ID] [int] NULL,
	[Content] [text] NULL,
	[CreatedBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[Status] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetai]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetai](
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[ColorID] [int] NULL,
	[SizeID] [int] NULL,
	[Price] [float] NULL,
	[Quantity] [int] NULL,
	[Discount] [float] NULL,
	[Total] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Andress] [nvarchar](256) NULL,
	[Mobile] [varchar](15) NULL,
	[UserID] [int] NULL,
	[Payment] [nvarchar](50) NULL,
	[Total] [float] NULL,
	[Fee] [float] NULL,
	[Discount] [float] NULL,
	[Status] [bit] NULL,
	[ConfirmStatusId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[ID] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[Image] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Content] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyAt] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[ID] [int] NULL,
	[ProductID] [int] NULL,
	[SizeID] [int] NULL,
	[ColorID] [int] NULL,
	[UrlImage] [varchar](256) NULL,
	[Invenory] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](12) NULL,
	[Name] [nvarchar](50) NULL,
	[CategoryID] [int] NULL,
	[SupplierID] [int] NULL,
	[UrlImage] [varchar](256) NULL,
	[ImportPrice] [float] NULL,
	[ExportPrice] [float] NULL,
	[Description] [text] NULL,
	[Discount] [float] NULL,
	[TotalPurchase] [int] NULL,
	[TotalInventory] [int] NULL,
	[Status] [bit] NULL,
	[ShowOnHome] [bit] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Detail] [nvarchar](50) NULL,
	[Status] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopInformation]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopInformation](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Logo] [varchar](50) NULL,
	[TaxCode] [varchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Moblie] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[Facebook] [varchar](50) NULL,
	[Instagram] [varchar](50) NULL,
	[Twitter] [varchar](50) NULL,
	[Youtube] [varchar](50) NULL,
	[Zalo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Detail] [nvarchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statistical]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statistical](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Title] [nvarchar](256) NULL,
	[Content] [text] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppeliers]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppeliers](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Andress] [nvarchar](256) NULL,
	[Mobile] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[Manager] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TagProduct]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagProduct](
	[ProductID] [int] NULL,
	[TagID] [int] NULL,
	[Detail] [nvarchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Detail] [nvarchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[ID] [int] NULL,
	[OrderID] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[Note] [nvarchar](256) NULL,
	[Status] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/5/2021 10:53:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](256) NULL,
	[Mobile] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[RoleID] [int] NULL,
	[Status] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_CreateAt]  DEFAULT (getdate()) FOR [CreateAt]
GO
ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF_Posts_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF_Posts_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF_Posts_ModifyAt]  DEFAULT (getdate()) FOR [ModifyAt]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_ImportPrice]  DEFAULT ((0)) FOR [ImportPrice]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_ExportPrice]  DEFAULT ((0)) FOR [ExportPrice]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Discount]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_TotalPurchase]  DEFAULT ((0)) FOR [TotalPurchase]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_TotalInventory]  DEFAULT ((0)) FOR [TotalInventory]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_ShowOnHome]  DEFAULT ((1)) FOR [ShowOnHome]
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Statistical] ADD  CONSTRAINT [DF_Statistical_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_CreateAt]  DEFAULT (getdate()) FOR [CreateAt]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((1)) FOR [Status]
GO
USE [master]
GO
ALTER DATABASE [ShopOnline] SET  READ_WRITE 
GO
