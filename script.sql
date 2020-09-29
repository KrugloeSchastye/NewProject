USE [master]
GO
/****** Object:  Database [KrugloeSchastye]    Script Date: 29.09.2020 20:53:39 ******/
CREATE DATABASE [KrugloeSchastye]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KrugloeSchastye', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\KrugloeSchastye.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KrugloeSchastye_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\KrugloeSchastye_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KrugloeSchastye] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KrugloeSchastye].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KrugloeSchastye] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET ARITHABORT OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KrugloeSchastye] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KrugloeSchastye] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KrugloeSchastye] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KrugloeSchastye] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KrugloeSchastye] SET  MULTI_USER 
GO
ALTER DATABASE [KrugloeSchastye] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KrugloeSchastye] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KrugloeSchastye] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KrugloeSchastye] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [KrugloeSchastye] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KrugloeSchastye] SET QUERY_STORE = OFF
GO
USE [KrugloeSchastye]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[idEmployee] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Patronymic] [nvarchar](max) NOT NULL,
	[Telephone] [nvarchar](max) NOT NULL,
	[BirthDate] [smalldatetime] NOT NULL,
	[Restoran] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[idEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IsBusy]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IsBusy](
	[idBusy] [bit] NOT NULL,
	[textBusy] [nchar](10) NOT NULL,
 CONSTRAINT [PK_IsBusy] PRIMARY KEY CLUSTERED 
(
	[idBusy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Role] [int] NOT NULL,
	[CountWrong] [int] NOT NULL,
 CONSTRAINT [PK_Login_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[idBluda] [int] IDENTITY(0,1) NOT NULL,
	[NameBludo] [nvarchar](max) NOT NULL,
	[Wheight] [nvarchar](max) NOT NULL,
	[Struct] [nvarchar](max) NOT NULL,
	[RazdelMenu] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[idBluda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Razdeli]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Razdeli](
	[idRazdel] [int] IDENTITY(0,1) NOT NULL,
	[NameRazdela] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Razdeli] PRIMARY KEY CLUSTERED 
(
	[idRazdel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurants]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurants](
	[idRestoran] [int] IDENTITY(1,1) NOT NULL,
	[NameRest] [nchar](50) NOT NULL,
	[Adress] [nvarchar](max) NOT NULL,
	[Telephone] [nvarchar](max) NOT NULL,
	[Leader] [nvarchar](50) NOT NULL,
	[OpenDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Restaurants_1] PRIMARY KEY CLUSTERED 
(
	[idRestoran] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRole] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stoli]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stoli](
	[idStola] [int] IDENTITY(1,1) NOT NULL,
	[NameStola] [nvarchar](max) NOT NULL,
	[IsBusy] [bit] NOT NULL,
 CONSTRAINT [PK_Stoli] PRIMARY KEY CLUSTERED 
(
	[idStola] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZakazBluda]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZakazBluda](
	[idZakazBludo] [int] IDENTITY(0,1) NOT NULL,
	[idZakaza] [int] NOT NULL,
	[NameBludo] [int] NOT NULL,
	[Kolvo] [int] NOT NULL,
	[Cena] [int] NOT NULL,
	[Summa] [int] NOT NULL,
 CONSTRAINT [PK_ZakazBluda] PRIMARY KEY CLUSTERED 
(
	[idZakazBludo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zakazi]    Script Date: 29.09.2020 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zakazi](
	[idZakaza] [int] IDENTITY(1,1) NOT NULL,
	[Stol] [int] NOT NULL,
	[SummaZakaza] [nvarchar](max) NOT NULL,
	[DateOpenZakaz] [datetime] NULL,
	[DateCloseZakaz] [datetime] NULL,
 CONSTRAINT [PK_Zakazi] PRIMARY KEY CLUSTERED 
(
	[idZakaza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([idEmployee], [Name], [Surname], [Patronymic], [Telephone], [BirthDate], [Restoran]) VALUES (1, N'Артем', N'Артемов', N'Артемович', N'9999999', CAST(N'1989-03-23T00:00:00' AS SmallDateTime), 1)
INSERT [dbo].[Employee] ([idEmployee], [Name], [Surname], [Patronymic], [Telephone], [BirthDate], [Restoran]) VALUES (5, N'Николай', N'Николаев', N'Николаевич', N'9999999', CAST(N'1990-01-21T00:00:00' AS SmallDateTime), 1)
INSERT [dbo].[Employee] ([idEmployee], [Name], [Surname], [Patronymic], [Telephone], [BirthDate], [Restoran]) VALUES (6, N'Александр', N'Пушкин', N'Сергеевич', N'921932139', CAST(N'1999-05-06T00:00:00' AS SmallDateTime), 1)
INSERT [dbo].[Employee] ([idEmployee], [Name], [Surname], [Patronymic], [Telephone], [BirthDate], [Restoran]) VALUES (7, N'Петр', N'Петров', N'Николаевич', N'892843843', CAST(N'1990-11-14T00:00:00' AS SmallDateTime), 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
INSERT [dbo].[IsBusy] ([idBusy], [textBusy]) VALUES (0, N'Занят     ')
INSERT [dbo].[IsBusy] ([idBusy], [textBusy]) VALUES (1, N'Свободен  ')
GO
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([Id], [UserName], [Password], [Role], [CountWrong]) VALUES (1, N'Admin', N'1', 1, 0)
INSERT [dbo].[Login] ([Id], [UserName], [Password], [Role], [CountWrong]) VALUES (2, N'Manager', N'2', 2, 0)
SET IDENTITY_INSERT [dbo].[Login] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([idBluda], [NameBludo], [Wheight], [Struct], [RazdelMenu], [Price]) VALUES (0, N'Пицца "Моцарелла"', N'120', N'Колбаса, сыр, помидоры', 3, 150)
INSERT [dbo].[Menu] ([idBluda], [NameBludo], [Wheight], [Struct], [RazdelMenu], [Price]) VALUES (1, N'Пепперони', N'200', N'Огурцы, колбаса, перец, лук', 3, 200)
INSERT [dbo].[Menu] ([idBluda], [NameBludo], [Wheight], [Struct], [RazdelMenu], [Price]) VALUES (2, N'Деревенская', N'230', N'Курица, соус, сыр, салат, колбаса', 3, 200)
INSERT [dbo].[Menu] ([idBluda], [NameBludo], [Wheight], [Struct], [RazdelMenu], [Price]) VALUES (3, N'Домашняя лапша', N'120', N'Куриный бульон, курица, лапша', 2, 100)
INSERT [dbo].[Menu] ([idBluda], [NameBludo], [Wheight], [Struct], [RazdelMenu], [Price]) VALUES (4, N'Спрайт', N'20', N'Газированная вода', 5, 50)
INSERT [dbo].[Menu] ([idBluda], [NameBludo], [Wheight], [Struct], [RazdelMenu], [Price]) VALUES (5, N'Кола', N'20', N'Газированная вода', 5, 55)
INSERT [dbo].[Menu] ([idBluda], [NameBludo], [Wheight], [Struct], [RazdelMenu], [Price]) VALUES (8, N'Шашлык', N'300', N'Мясо', 6, 170)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Razdeli] ON 

INSERT [dbo].[Razdeli] ([idRazdel], [NameRazdela]) VALUES (0, N'Холодные закуски')
INSERT [dbo].[Razdeli] ([idRazdel], [NameRazdela]) VALUES (1, N'Горячие закуски')
INSERT [dbo].[Razdeli] ([idRazdel], [NameRazdela]) VALUES (2, N'Супы')
INSERT [dbo].[Razdeli] ([idRazdel], [NameRazdela]) VALUES (3, N'Пицца')
INSERT [dbo].[Razdeli] ([idRazdel], [NameRazdela]) VALUES (4, N'Роллы и суши')
INSERT [dbo].[Razdeli] ([idRazdel], [NameRazdela]) VALUES (5, N'Напитки')
INSERT [dbo].[Razdeli] ([idRazdel], [NameRazdela]) VALUES (6, N'Горячие блюда')
INSERT [dbo].[Razdeli] ([idRazdel], [NameRazdela]) VALUES (7, N'Десерты')
SET IDENTITY_INSERT [dbo].[Razdeli] OFF
GO
SET IDENTITY_INSERT [dbo].[Restaurants] ON 

INSERT [dbo].[Restaurants] ([idRestoran], [NameRest], [Adress], [Telephone], [Leader], [OpenDate]) VALUES (1, N'Апельсин                                          ', N'ул. Пушкина, д. 30', N'99999999', N'Николаев М. В.', CAST(N'2010-01-30T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Restaurants] OFF
GO
INSERT [dbo].[Roles] ([idRole], [Name]) VALUES (0, N'нет роли')
INSERT [dbo].[Roles] ([idRole], [Name]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([idRole], [Name]) VALUES (2, N'Менеджер ресторана')
INSERT [dbo].[Roles] ([idRole], [Name]) VALUES (3, N'Повар')
INSERT [dbo].[Roles] ([idRole], [Name]) VALUES (4, N'Обслуживающий персонал')
GO
SET IDENTITY_INSERT [dbo].[Stoli] ON 

INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (1, N'Стол - 1', 1)
INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (2, N'Стол - 2', 1)
INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (3, N'Стол - 3', 1)
INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (4, N'Стол - 4', 1)
INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (5, N'Стол - 5', 1)
INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (6, N'Стол - 6', 1)
INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (7, N'Стол - 7', 1)
INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (8, N'Стол - 8', 1)
INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (9, N'Стол - 9', 1)
INSERT [dbo].[Stoli] ([idStola], [NameStola], [IsBusy]) VALUES (10, N'Стол - 10', 1)
SET IDENTITY_INSERT [dbo].[Stoli] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Restaurants] FOREIGN KEY([Restoran])
REFERENCES [dbo].[Restaurants] ([idRestoran])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Restaurants]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([idRole])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Roles]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Razdeli] FOREIGN KEY([RazdelMenu])
REFERENCES [dbo].[Razdeli] ([idRazdel])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Razdeli]
GO
ALTER TABLE [dbo].[Stoli]  WITH CHECK ADD  CONSTRAINT [FK_Stoli_IsBusy] FOREIGN KEY([IsBusy])
REFERENCES [dbo].[IsBusy] ([idBusy])
GO
ALTER TABLE [dbo].[Stoli] CHECK CONSTRAINT [FK_Stoli_IsBusy]
GO
ALTER TABLE [dbo].[ZakazBluda]  WITH CHECK ADD  CONSTRAINT [FK_ZakazBluda_Menu] FOREIGN KEY([NameBludo])
REFERENCES [dbo].[Menu] ([idBluda])
GO
ALTER TABLE [dbo].[ZakazBluda] CHECK CONSTRAINT [FK_ZakazBluda_Menu]
GO
ALTER TABLE [dbo].[ZakazBluda]  WITH CHECK ADD  CONSTRAINT [FK_ZakazBluda_Zakazi] FOREIGN KEY([idZakaza])
REFERENCES [dbo].[Zakazi] ([idZakaza])
GO
ALTER TABLE [dbo].[ZakazBluda] CHECK CONSTRAINT [FK_ZakazBluda_Zakazi]
GO
ALTER TABLE [dbo].[Zakazi]  WITH CHECK ADD  CONSTRAINT [FK_Zakazi_Stoli] FOREIGN KEY([Stol])
REFERENCES [dbo].[Stoli] ([idStola])
GO
ALTER TABLE [dbo].[Zakazi] CHECK CONSTRAINT [FK_Zakazi_Stoli]
GO
USE [master]
GO
ALTER DATABASE [KrugloeSchastye] SET  READ_WRITE 
GO
