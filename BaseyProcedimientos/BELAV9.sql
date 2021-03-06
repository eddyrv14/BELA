USE [master]
GO
/****** Object:  Database [bela]    Script Date: 28/5/2018 12:28:06 a. m. ******/
CREATE DATABASE [bela]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bela', FILENAME = N'C:\A-Universidad\BaseDatos\proyectoBela\bela.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bela_log', FILENAME = N'C:\A-Universidad\BaseDatos\proyectoBela\bela_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [bela] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bela].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bela] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bela] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bela] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bela] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bela] SET ARITHABORT OFF 
GO
ALTER DATABASE [bela] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bela] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bela] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bela] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bela] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bela] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bela] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bela] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bela] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bela] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bela] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bela] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bela] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bela] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bela] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bela] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bela] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bela] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bela] SET  MULTI_USER 
GO
ALTER DATABASE [bela] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bela] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bela] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bela] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bela] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bela] SET QUERY_STORE = OFF
GO
USE [bela]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [bela]
GO
/****** Object:  Table [dbo].[DetalleMateria]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleMateria](
	[idDetalleMateria] [int] IDENTITY(1,1) NOT NULL,
	[idMateria] [int] NULL,
	[idUsuario] [int] NULL,
	[idSeccion] [int] NULL,
	[grado] [int] NULL,
 CONSTRAINT [PK__DetalleM__16F81F7BFD8F153B] PRIMARY KEY CLUSTERED 
(
	[idDetalleMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EstudianteSeccion]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstudianteSeccion](
	[idEstudianteSeccion] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[idSeccion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstudianteSeccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EstudiantesMaterias]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstudiantesMaterias](
	[idEstudianteMateria] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[idDetalleMateria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstudianteMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImagenNoticia]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImagenNoticia](
	[idImagen] [int] IDENTITY(1,1) NOT NULL,
	[idNoticia] [int] NULL,
	[imagen] [varchar](100) NULL,
 CONSTRAINT [PK__ImagenNo__EA9A7136417883C0] PRIMARY KEY CLUSTERED 
(
	[idImagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasMaterial]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasMaterial](
	[idMasMaterial] [int] IDENTITY(1,1) NOT NULL,
	[idMaterial] [int] NULL,
	[material] [varchar](100) NULL,
	[nombreMaterial] [varchar](100) NULL,
 CONSTRAINT [PK__MasMater__D7BC2C2F562EC716] PRIMARY KEY CLUSTERED 
(
	[idMasMaterial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Materia]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[idMateria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Material]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[idMaterial] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[idDetalleMateria] [int] NULL,
	[titulo] [varchar](100) NULL,
	[mensaje] [varchar](300) NULL,
	[material] [varchar](100) NULL,
	[nombreMaterial] [varchar](100) NULL,
	[fechaHora] [datetime] NULL,
 CONSTRAINT [PK__Material__6AC7E3EB098242B1] PRIMARY KEY CLUSTERED 
(
	[idMaterial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MensajeContacto]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MensajeContacto](
	[idMensaje] [int] IDENTITY(1,1) NOT NULL,
	[correo] [varchar](45) NULL,
	[asunto] [varchar](60) NULL,
	[mensaje] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[idMensaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Noticia]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Noticia](
	[idNoticia] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[idtipo] [int] NULL,
	[titulo] [varchar](100) NULL,
	[descripcion] [varchar](300) NULL,
	[contenido] [varchar](1000) NULL,
	[imagen] [varchar](45) NULL,
	[fechaYHora] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idNoticia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NotiExternas]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotiExternas](
	[idNoticficacionExter] [int] IDENTITY(1,1) NOT NULL,
	[correo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idNoticficacionExter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NotiInternas]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotiInternas](
	[idNotificacionInter] [int] IDENTITY(1,1) NOT NULL,
	[correo] [varchar](100) NOT NULL,
 CONSTRAINT [PK__NotiInte__8D226C2954C8F029] PRIMARY KEY CLUSTERED 
(
	[idNotificacionInter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](60) NULL,
	[apellido1] [varchar](60) NULL,
	[apellido2] [varchar](60) NULL,
	[cedula] [varchar](20) NULL,
	[correo] [varchar](100) NULL,
 CONSTRAINT [PK__Persona__A47881413DFAB78B] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfesoresMaterias]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesoresMaterias](
	[idProfesoresMaterias] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[idDetalleMateria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProfesoresMaterias] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seccion]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seccion](
	[idSeccion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[idSeccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoNoticia]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoNoticia](
	[idTipoNoticia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoNoticia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] NOT NULL,
	[idRol] [int] NULL,
	[usuario] [varchar](30) NULL,
	[contrasena] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DetalleMateria] ON 

INSERT [dbo].[DetalleMateria] ([idDetalleMateria], [idMateria], [idUsuario], [idSeccion], [grado]) VALUES (1, 1, 5, 1, 7)
INSERT [dbo].[DetalleMateria] ([idDetalleMateria], [idMateria], [idUsuario], [idSeccion], [grado]) VALUES (2, 2, 5, 1, 7)
INSERT [dbo].[DetalleMateria] ([idDetalleMateria], [idMateria], [idUsuario], [idSeccion], [grado]) VALUES (6, 4, 5, 2, NULL)
INSERT [dbo].[DetalleMateria] ([idDetalleMateria], [idMateria], [idUsuario], [idSeccion], [grado]) VALUES (7, 1, 33, 3, NULL)
INSERT [dbo].[DetalleMateria] ([idDetalleMateria], [idMateria], [idUsuario], [idSeccion], [grado]) VALUES (8, 3, 42, 7, NULL)
INSERT [dbo].[DetalleMateria] ([idDetalleMateria], [idMateria], [idUsuario], [idSeccion], [grado]) VALUES (9, 1, 33, 7, NULL)
SET IDENTITY_INSERT [dbo].[DetalleMateria] OFF
SET IDENTITY_INSERT [dbo].[EstudianteSeccion] ON 

INSERT [dbo].[EstudianteSeccion] ([idEstudianteSeccion], [idUsuario], [idSeccion]) VALUES (2, 6, 1)
INSERT [dbo].[EstudianteSeccion] ([idEstudianteSeccion], [idUsuario], [idSeccion]) VALUES (3, 30, 3)
INSERT [dbo].[EstudianteSeccion] ([idEstudianteSeccion], [idUsuario], [idSeccion]) VALUES (5, 32, 2)
INSERT [dbo].[EstudianteSeccion] ([idEstudianteSeccion], [idUsuario], [idSeccion]) VALUES (6, 37, 3)
INSERT [dbo].[EstudianteSeccion] ([idEstudianteSeccion], [idUsuario], [idSeccion]) VALUES (7, 41, 2)
SET IDENTITY_INSERT [dbo].[EstudianteSeccion] OFF
SET IDENTITY_INSERT [dbo].[EstudiantesMaterias] ON 

INSERT [dbo].[EstudiantesMaterias] ([idEstudianteMateria], [idUsuario], [idDetalleMateria]) VALUES (1, 6, 1)
INSERT [dbo].[EstudiantesMaterias] ([idEstudianteMateria], [idUsuario], [idDetalleMateria]) VALUES (2, 6, 2)
SET IDENTITY_INSERT [dbo].[EstudiantesMaterias] OFF
SET IDENTITY_INSERT [dbo].[ImagenNoticia] ON 

INSERT [dbo].[ImagenNoticia] ([idImagen], [idNoticia], [imagen]) VALUES (1, 2, N'/Imagenes/ImagenesNoticias/Adicional1.jpg')
INSERT [dbo].[ImagenNoticia] ([idImagen], [idNoticia], [imagen]) VALUES (2, 2, N'/Imagenes/ImagenesNoticias/Adicional2.jpg')
SET IDENTITY_INSERT [dbo].[ImagenNoticia] OFF
SET IDENTITY_INSERT [dbo].[MasMaterial] ON 

INSERT [dbo].[MasMaterial] ([idMasMaterial], [idMaterial], [material], [nombreMaterial]) VALUES (1, 5, N'/Materiales/Tarea1CienciasAdicional1.docx', N'Tarea1CienciasAdicional1.docx')
INSERT [dbo].[MasMaterial] ([idMasMaterial], [idMaterial], [material], [nombreMaterial]) VALUES (2, 5, N'/Materiales/Tarea1CienciasAdicional2.docx', N'Tarea1CienciasAdicional2.docx')
INSERT [dbo].[MasMaterial] ([idMasMaterial], [idMaterial], [material], [nombreMaterial]) VALUES (3, 6, N'/Materiales/AdicionalTarea1_Estudios_1Tri_7-2.docx', N'AdicionalTarea1_Estudios_1Tri_7-2.docx')
INSERT [dbo].[MasMaterial] ([idMasMaterial], [idMaterial], [material], [nombreMaterial]) VALUES (4, 7, N'/Materiales/AdicinalesTareaEspañol1_8-1_1Tri.docx', N'AdicinalesTareaEspañol1_8-1_1Tri.docx')
INSERT [dbo].[MasMaterial] ([idMasMaterial], [idMaterial], [material], [nombreMaterial]) VALUES (5, 7, N'/Materiales/AdicionalesTarea1Español1_8-1_1Tri.docx', N'AdicionalesTarea1Español1_8-1_1Tri.docx')
SET IDENTITY_INSERT [dbo].[MasMaterial] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([idMateria], [nombre]) VALUES (1, N'Ciencias')
INSERT [dbo].[Materia] ([idMateria], [nombre]) VALUES (2, N'Matematicas')
INSERT [dbo].[Materia] ([idMateria], [nombre]) VALUES (3, N'Español')
INSERT [dbo].[Materia] ([idMateria], [nombre]) VALUES (4, N'Estudios Sociales')
SET IDENTITY_INSERT [dbo].[Materia] OFF
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([idMaterial], [idUsuario], [idDetalleMateria], [titulo], [mensaje], [material], [nombreMaterial], [fechaHora]) VALUES (1, 5, 1, N'Material Ciencias Jueves', N'Temas de examen ciencias', N'docs', N'docs', CAST(N'2018-04-21T17:44:03.000' AS DateTime))
INSERT [dbo].[Material] ([idMaterial], [idUsuario], [idDetalleMateria], [titulo], [mensaje], [material], [nombreMaterial], [fechaHora]) VALUES (2, 5, 1, N'Temas de  examen Ciencias', N'Examen sads', N'/Materiales/Temas de Examen1_1Tri-7-1.docx', N'Temas de Examen1_1Tri-7-1.docx', CAST(N'2018-04-23T19:00:37.000' AS DateTime))
INSERT [dbo].[Material] ([idMaterial], [idUsuario], [idDetalleMateria], [titulo], [mensaje], [material], [nombreMaterial], [fechaHora]) VALUES (3, 5, 6, N'Temas Examen Estudions', N'Estudien', N'/Materiales/TemasDeExamenEstudiosSociales1_1T', N'TemasDeExamenEstudiosSociales1_1T', CAST(N'2018-04-23T23:13:07.000' AS DateTime))
INSERT [dbo].[Material] ([idMaterial], [idUsuario], [idDetalleMateria], [titulo], [mensaje], [material], [nombreMaterial], [fechaHora]) VALUES (4, 33, 7, N'Temas de  examen Ciencias', N'Fecha de exament>>>.', N'/Materiales/ExtraclaseCiencias1_1Tri_7-3.docx', N'ExtraclaseCiencias1_1Tri_7-3.docx', CAST(N'2018-04-25T02:19:59.000' AS DateTime))
INSERT [dbo].[Material] ([idMaterial], [idUsuario], [idDetalleMateria], [titulo], [mensaje], [material], [nombreMaterial], [fechaHora]) VALUES (5, 33, 7, N'Tarea Ciencias', N'Se adjuntan documentos e instrucciones', N'/Materiales/TareaCiencias1_1Tri_7-3.docx', N'TareaCiencias1_1Tri_7-3.docx', CAST(N'2018-04-25T09:08:17.000' AS DateTime))
INSERT [dbo].[Material] ([idMaterial], [idUsuario], [idDetalleMateria], [titulo], [mensaje], [material], [nombreMaterial], [fechaHora]) VALUES (6, 5, 6, N'Tarea Estudios', N'Se adjuntan instrucciones y documentos', N'/Materiales/TareaEstudios1_1Tri_7-2.docx', N'TareaEstudios1_1Tri_7-2.docx', CAST(N'2018-04-25T09:18:52.000' AS DateTime))
INSERT [dbo].[Material] ([idMaterial], [idUsuario], [idDetalleMateria], [titulo], [mensaje], [material], [nombreMaterial], [fechaHora]) VALUES (7, 42, 8, N'Tarea Español', N'Se adjunta instrucciones y documentos adicionales', N'/Materiales/IntruccionesTareaEspañol1_8-1_1Tri.docx', N'IntruccionesTareaEspañol1_8-1_1Tri.docx', CAST(N'2018-04-25T13:47:56.000' AS DateTime))
INSERT [dbo].[Material] ([idMaterial], [idUsuario], [idDetalleMateria], [titulo], [mensaje], [material], [nombreMaterial], [fechaHora]) VALUES (8, 42, 8, N'prueba', N'prueba', N'/Materiales/TareaCiencias1_1Tri_7-3.docx', N'TareaCiencias1_1Tri_7-3.docx', CAST(N'2018-04-25T14:02:33.000' AS DateTime))
INSERT [dbo].[Material] ([idMaterial], [idUsuario], [idDetalleMateria], [titulo], [mensaje], [material], [nombreMaterial], [fechaHora]) VALUES (9, 33, 9, N'MaterialCiencias81', N'cIENCIA81', N'/Materiales/nOTICIASS.txt', N'nOTICIASS.txt', CAST(N'2018-04-25T18:00:11.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Material] OFF
SET IDENTITY_INSERT [dbo].[MensajeContacto] ON 

INSERT [dbo].[MensajeContacto] ([idMensaje], [correo], [asunto], [mensaje]) VALUES (2, N'ponce@gmail.com', N'prueba2', N'Esto es la prueba 2')
INSERT [dbo].[MensajeContacto] ([idMensaje], [correo], [asunto], [mensaje]) VALUES (3, N'ponce@gmail.com', N'sdsd', N'ssssssssss ssss sss')
INSERT [dbo].[MensajeContacto] ([idMensaje], [correo], [asunto], [mensaje]) VALUES (4, N'prueba2@gmail.com', N'sdsdsdss', N'ss')
INSERT [dbo].[MensajeContacto] ([idMensaje], [correo], [asunto], [mensaje]) VALUES (5, N'prueba@gmail.com', N'prueba', N'prueba')
INSERT [dbo].[MensajeContacto] ([idMensaje], [correo], [asunto], [mensaje]) VALUES (6, N'sdsd@gmail.com', N'ss', N'ss')
INSERT [dbo].[MensajeContacto] ([idMensaje], [correo], [asunto], [mensaje]) VALUES (7, N'pruebadb@gmail.com', N'prueb', N'42422')
SET IDENTITY_INSERT [dbo].[MensajeContacto] OFF
SET IDENTITY_INSERT [dbo].[Noticia] ON 

INSERT [dbo].[Noticia] ([idNoticia], [idUsuario], [idtipo], [titulo], [descripcion], [contenido], [imagen], [fechaYHora]) VALUES (2, 1, 1, N'El mural a lápiz más grande se implantó Colombia', N'El artista Julián Castillo y un equipo de jóvenes colombianos han elaborado 
el mural a lápiz más grande del mundo en Roldanillo, Colombia. Utilizaron más de
mil lápices en la creación del mural que tiene una superficie de 84,86 metros cuadrados.', N'
El título de la obra es “El concepto de la realidad absoluta” y representa 
la figura de un señor y una chica sosteniendo un diamante. Castillo y su equipo utilizaron lápiz estándar y lápiz de color rojo. El mural 
está protegido por varias capas de acronal, una resina acrílica. 

“El mural se realizó con el objetivo de innovar con una obra de arte poco usual y con el 
fin de promover el arte en una zona de posconflicto como es el norte 
del Valle del Cauca en Colombia y dar nuestro trabajo a conocer,” dijo 
Castillo en sus materiales de solicitud. ', N'/Imagenes/ImagenesNoticias/Portada.jpg', CAST(N'2018-05-27T23:59:08.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Noticia] OFF
SET IDENTITY_INSERT [dbo].[NotiExternas] ON 

INSERT [dbo].[NotiExternas] ([idNoticficacionExter], [correo]) VALUES (9, N'bayronk12.pon@gmail.com')
SET IDENTITY_INSERT [dbo].[NotiExternas] OFF
SET IDENTITY_INSERT [dbo].[NotiInternas] ON 

INSERT [dbo].[NotiInternas] ([idNotificacionInter], [correo]) VALUES (1, N'Ponce.bayron.bayron944@gmail.com')
SET IDENTITY_INSERT [dbo].[NotiInternas] OFF
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (1, N'Bayron', N'Navarro', N'Ponce', N'207600256', N'Ponce.bayron.bayron944@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (5, N'BayronProf', N'Navarro', N'Ponce', N'345634564', N'Ponce@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (6, N'BayronEstudian', N'Navarro', N'Ponce', N'456456435', N'PonceFide@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (30, N'73', N'sd', N'sd', N'445566774', N'sdsd@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (32, N'bayron72', N'bayron72', N'bayron72', N'887766544', N'72@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (33, N'ProfeCiencias', N'Ciencias', N'Ciencias2', N'233445644', N'Ciencias@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (37, N'Nombre Estudiante73', N'Estudiante73', N'Estudiante73', N'56765678', N'estudiante73@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (41, N'Presentacion', N'Presentacion', N'Presentaci', N'667756775', N'Presentaciion@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (42, N'profesor8-1', N'profesor8-1', N'profesor8-1', N'881188118', N'profesor8-1@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [cedula], [correo]) VALUES (46, N'ProfesorPrueba3', N'analisis3', N'analisis3', N'33435356353', N'analisis3@gmail.com')
SET IDENTITY_INSERT [dbo].[Persona] OFF
SET IDENTITY_INSERT [dbo].[ProfesoresMaterias] ON 

INSERT [dbo].[ProfesoresMaterias] ([idProfesoresMaterias], [idUsuario], [idDetalleMateria]) VALUES (1, 5, 1)
INSERT [dbo].[ProfesoresMaterias] ([idProfesoresMaterias], [idUsuario], [idDetalleMateria]) VALUES (2, 5, 2)
INSERT [dbo].[ProfesoresMaterias] ([idProfesoresMaterias], [idUsuario], [idDetalleMateria]) VALUES (4, 5, 6)
INSERT [dbo].[ProfesoresMaterias] ([idProfesoresMaterias], [idUsuario], [idDetalleMateria]) VALUES (5, 33, 7)
INSERT [dbo].[ProfesoresMaterias] ([idProfesoresMaterias], [idUsuario], [idDetalleMateria]) VALUES (6, 42, 8)
INSERT [dbo].[ProfesoresMaterias] ([idProfesoresMaterias], [idUsuario], [idDetalleMateria]) VALUES (7, 33, 9)
SET IDENTITY_INSERT [dbo].[ProfesoresMaterias] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([idRol], [nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[Rol] ([idRol], [nombre]) VALUES (2, N'Profesor')
INSERT [dbo].[Rol] ([idRol], [nombre]) VALUES (3, N'Estudiante')
SET IDENTITY_INSERT [dbo].[Rol] OFF
SET IDENTITY_INSERT [dbo].[Seccion] ON 

INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (1, N'7-1')
INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (2, N'7-2')
INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (3, N'7-3')
INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (4, N'7-4')
INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (5, N'7-5')
INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (6, N'7-6')
INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (7, N'8-1')
INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (8, N'8-2')
INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (9, N'8-3')
INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (10, N'8-4')
SET IDENTITY_INSERT [dbo].[Seccion] OFF
SET IDENTITY_INSERT [dbo].[TipoNoticia] ON 

INSERT [dbo].[TipoNoticia] ([idTipoNoticia], [nombre]) VALUES (1, N'Publica')
INSERT [dbo].[TipoNoticia] ([idTipoNoticia], [nombre]) VALUES (2, N'Privada')
SET IDENTITY_INSERT [dbo].[TipoNoticia] OFF
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (1, 1, N'bayron', N'1234')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (5, 2, N'bayronProf', N'1234')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (6, 3, N'bayronEst', N'1234')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (30, 3, N'sd', N'sd')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (32, 3, N'72', N'72')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (33, 2, N'proCiencias', N'1234')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (37, 3, N'73', N'1234')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (41, 3, N'presentacion', N'1234')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (42, 2, N'profe81', N'profe81')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (46, 2, N'analisis', N'1234')
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__NotiExte__2A586E0BBEB27262]    Script Date: 28/5/2018 12:28:07 a. m. ******/
ALTER TABLE [dbo].[NotiExternas] ADD UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Persona__2A586E0BC410AAFA]    Script Date: 28/5/2018 12:28:07 a. m. ******/
ALTER TABLE [dbo].[Persona] ADD UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Persona__415B7BE5838648EE]    Script Date: 28/5/2018 12:28:07 a. m. ******/
ALTER TABLE [dbo].[Persona] ADD UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleMateria]  WITH CHECK ADD  CONSTRAINT [FK_IDMATERIA] FOREIGN KEY([idMateria])
REFERENCES [dbo].[Materia] ([idMateria])
GO
ALTER TABLE [dbo].[DetalleMateria] CHECK CONSTRAINT [FK_IDMATERIA]
GO
ALTER TABLE [dbo].[DetalleMateria]  WITH CHECK ADD  CONSTRAINT [FK_IDPROFESOR] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[DetalleMateria] CHECK CONSTRAINT [FK_IDPROFESOR]
GO
ALTER TABLE [dbo].[DetalleMateria]  WITH CHECK ADD  CONSTRAINT [FK_IDSECCION] FOREIGN KEY([idSeccion])
REFERENCES [dbo].[Seccion] ([idSeccion])
GO
ALTER TABLE [dbo].[DetalleMateria] CHECK CONSTRAINT [FK_IDSECCION]
GO
ALTER TABLE [dbo].[EstudianteSeccion]  WITH CHECK ADD  CONSTRAINT [FK_IDUSUARIOSEC] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[EstudianteSeccion] CHECK CONSTRAINT [FK_IDUSUARIOSEC]
GO
ALTER TABLE [dbo].[EstudianteSeccion]  WITH CHECK ADD  CONSTRAINT [FK_SECCIONEST] FOREIGN KEY([idSeccion])
REFERENCES [dbo].[Seccion] ([idSeccion])
GO
ALTER TABLE [dbo].[EstudianteSeccion] CHECK CONSTRAINT [FK_SECCIONEST]
GO
ALTER TABLE [dbo].[EstudiantesMaterias]  WITH CHECK ADD  CONSTRAINT [FK_IDDETALLEMATERIAEST] FOREIGN KEY([idDetalleMateria])
REFERENCES [dbo].[DetalleMateria] ([idDetalleMateria])
GO
ALTER TABLE [dbo].[EstudiantesMaterias] CHECK CONSTRAINT [FK_IDDETALLEMATERIAEST]
GO
ALTER TABLE [dbo].[EstudiantesMaterias]  WITH CHECK ADD  CONSTRAINT [FK_IDUSUESTUDIANTE] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[EstudiantesMaterias] CHECK CONSTRAINT [FK_IDUSUESTUDIANTE]
GO
ALTER TABLE [dbo].[ImagenNoticia]  WITH CHECK ADD  CONSTRAINT [FK_IDNOTICIAIMG] FOREIGN KEY([idNoticia])
REFERENCES [dbo].[Noticia] ([idNoticia])
GO
ALTER TABLE [dbo].[ImagenNoticia] CHECK CONSTRAINT [FK_IDNOTICIAIMG]
GO
ALTER TABLE [dbo].[MasMaterial]  WITH CHECK ADD  CONSTRAINT [FK_IDMaterialMas] FOREIGN KEY([idMaterial])
REFERENCES [dbo].[Material] ([idMaterial])
GO
ALTER TABLE [dbo].[MasMaterial] CHECK CONSTRAINT [FK_IDMaterialMas]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE] FOREIGN KEY([idDetalleMateria])
REFERENCES [dbo].[DetalleMateria] ([idDetalleMateria])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK_DETALLE]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK_IDUSUARIOSUBIO] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK_IDUSUARIOSUBIO]
GO
ALTER TABLE [dbo].[Noticia]  WITH CHECK ADD  CONSTRAINT [FK_IDTIPONOTI] FOREIGN KEY([idtipo])
REFERENCES [dbo].[TipoNoticia] ([idTipoNoticia])
GO
ALTER TABLE [dbo].[Noticia] CHECK CONSTRAINT [FK_IDTIPONOTI]
GO
ALTER TABLE [dbo].[Noticia]  WITH CHECK ADD  CONSTRAINT [FK_IDUSUARIONOTI] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Noticia] CHECK CONSTRAINT [FK_IDUSUARIONOTI]
GO
ALTER TABLE [dbo].[ProfesoresMaterias]  WITH CHECK ADD  CONSTRAINT [FK_IDDETALLEMATERIAPROF] FOREIGN KEY([idDetalleMateria])
REFERENCES [dbo].[DetalleMateria] ([idDetalleMateria])
GO
ALTER TABLE [dbo].[ProfesoresMaterias] CHECK CONSTRAINT [FK_IDDETALLEMATERIAPROF]
GO
ALTER TABLE [dbo].[ProfesoresMaterias]  WITH CHECK ADD  CONSTRAINT [FK_IDUSUPROFE] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[ProfesoresMaterias] CHECK CONSTRAINT [FK_IDUSUPROFE]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_IDPERSONA] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_IDPERSONA]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_IDROL] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_IDROL]
GO
/****** Object:  StoredProcedure [dbo].[agregarCorreoNotiEx]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[agregarCorreoNotiEx]
@correo varchar(100)
as
INSERT INTO NotiExternas VALUES(@correo)

GO
/****** Object:  StoredProcedure [dbo].[agregarCorreoNotiInter]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[agregarCorreoNotiInter]
@correo varchar(100)
as
INSERT INTO NotiInternas VALUES(@correo)

GO
/****** Object:  StoredProcedure [dbo].[agregarDetalleMateria]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[agregarDetalleMateria]
@idMateria int,
@idUsuario int,
@idSeccion int
as
INSERT INTO DetalleMateria (idMateria,idUsuario,idSeccion) values(@idMateria,@idUsuario,@idSeccion)

GO
/****** Object:  StoredProcedure [dbo].[agregarMateriaPro]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[agregarMateriaPro]
@idUsuario int
as
INSERT INTO ProfesoresMaterias(idUsuario,idDetalleMateria) values(@idUsuario,(Select TOP 1 idDetalleMateria From DetalleMateria order by idDetalleMateria desc))

GO
/****** Object:  StoredProcedure [dbo].[buscarCuenta]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[buscarCuenta]
@idUsuario int
as
Select p.idPersona,p.nombre,p.apellido1,apellido2,p.cedula,p.correo,u.idUsuario,u.idRol as rol,r.nombre as rolNombre,u.usuario,u.contrasena FROM Persona p
JOIN Usuario u on p.idPersona=u.idUsuario JOIN Rol  r on u.idRol=r.idRol where u.idUsuario=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[buscarMateria]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[buscarMateria]
@idMateria int
as
Select de.idDetalleMateria,m.nombre as materia,s.nombre as seccion
From Detallemateria de JOIN Materia m on de.idMateria=m.idMateria 
JOIN Seccion s on de.idSeccion=s.idSeccion  JOIN ProfesoresMaterias prof on prof.idDetalleMateria=de.idDetalleMateria  where de.idDetalleMateria=@idMateria

GO
/****** Object:  StoredProcedure [dbo].[buscarMateriaDetaProf]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE   PROC [dbo].[buscarMateriaDetaProf]
 @idProfesor int
 as
  Select   prof.idProfesoresMaterias idPrMa,prof.idUsuario,m.nombre nomMateria,sec.nombre nomSeccion FROM  ProfesoresMaterias prof   JOIN DetalleMateria det on det.idDetalleMateria=prof.idDetalleMateria
  JOIN Materia m on m.idMateria=det.idMateria
  JOIN Seccion sec on sec.idSeccion=det.idSeccion  
 where det.idUsuario=@idProfesor

GO
/****** Object:  StoredProcedure [dbo].[crearEstudianteSeccion]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   proc [dbo].[crearEstudianteSeccion]
@idSeccion int
as
INSERT INTO EstudianteSeccion(idUsuario,idSeccion) values((Select TOP 1 idPersona From Persona order by idPersona desc),@idSeccion)

GO
/****** Object:  StoredProcedure [dbo].[crearNoticia]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[crearNoticia]
@idAdmin int,
@idTipo int,
@titulo varchar(100),
@descripcion varchar(300),
@contenido varchar(1000),
@imagen varchar(45),
@fechaHora datetime
as
INSERT INTO Noticia values(@idAdmin,@idTipo,@titulo,@descripcion,@contenido,@imagen,@fechaHora)

GO
/****** Object:  StoredProcedure [dbo].[crearPersona]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   proc [dbo].[crearPersona]
@nombre varchar(60),
@apellido1 varchar(60),
@apellido2 varchar(60),
@cedula varchar(20),
@correo varchar(100)
as
Insert into Persona values(@nombre,@apellido1,@apellido2,@cedula,@correo)

GO
/****** Object:  StoredProcedure [dbo].[crearUsuario]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create   proc [dbo].[crearUsuario]
@idRol int,
@usuario varchar(30),
@contrasena varchar(30)
as
Insert into Usuario(idUsuario,idRol,usuario,contrasena) values((Select TOP 1 idPersona From Persona order by idPersona desc),@idRol,@usuario,@contrasena)

GO
/****** Object:  StoredProcedure [dbo].[detalleMaterial]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   proc [dbo].[detalleMaterial]
@idMaterial int
as
SELECT m.idMaterial,m.idDetalleMateria,m.titulo,m.mensaje,m.material,m.nombreMaterial from Material m where m.idMaterial=@idMaterial

GO
/****** Object:  StoredProcedure [dbo].[detalleNoticia]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   proc [dbo].[detalleNoticia]
@idNoticia int
as
SELECT n.idNoticia,p.Nombre,p.Apellido1,
n.Titulo,n.Descripcion,n.Contenido,n.Imagen,n.fechaYHora from Noticia n join  Persona p on p.idPersona=n.idUsuario  where n.idNoticia=@idNoticia

GO
/****** Object:  StoredProcedure [dbo].[eliminarImagenNoticia]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[eliminarImagenNoticia]
@idNoticia int
as
DELETE FROM ImagenNoticia where  idNoticia=@idNoticia

GO
/****** Object:  StoredProcedure [dbo].[eliminarMateriaPro]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE   PROC [dbo].[eliminarMateriaPro]
@idMateria int
as
DELETE FROM ProfesoresMaterias where idProfesoresMaterias=@idMateria

GO
/****** Object:  StoredProcedure [dbo].[eliminarNoticia]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROC [dbo].[eliminarNoticia]
@idNoticia int
as
DELETE FROM Noticia where idNoticia=@idNoticia

GO
/****** Object:  StoredProcedure [dbo].[eliminarPersona]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[eliminarPersona]
@idUsuario int
as
DELETE FROM Persona where idPersona=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[eliminarUsuario]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[eliminarUsuario]
@idUsuario int
as
DELETE FROM Usuario where idUsuario=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[insertarImagenes]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarImagenes]
@imagenes varchar(50)
as
INSERT INTO ImagenNoticia values((Select top 1 idNoticia from Noticia order by idNoticia desc),@imagenes)

GO
/****** Object:  StoredProcedure [dbo].[insertarMaterial]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[insertarMaterial]
@idUsuario int,
@idDetalleMateria int,
@titulo varchar(50),
@mensaje varchar(300),
@material varchar(100),
@nombreMaterial varchar(100),
@fechaHora DATETIME
as
INSERT INTO Material (idUsuario,idDetalleMateria,titulo,mensaje,material,nombreMaterial,fechaHora) 
values(@idUsuario,@idDetalleMateria,@titulo,@mensaje,@material,@nombreMaterial,@fechaHora)

GO
/****** Object:  StoredProcedure [dbo].[insertarMaterialesAdicionales]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarMaterialesAdicionales]
@material varchar(100),
@nombreMaterial varchar(100)
as
INSERT INTO MasMaterial values((Select top 1 idMaterial from Material order by idMaterial desc),@material,@nombreMaterial)

GO
/****** Object:  StoredProcedure [dbo].[insertarMensaje]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarMensaje]
@correo varchar(45),
@asunto varchar(45),
@mensaje varchar(200)
as
INSERT INTO MensajeContacto(correo,asunto,mensaje) values(@correo,@asunto,@mensaje)

GO
/****** Object:  StoredProcedure [dbo].[listaEstudiantesSeccion]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[listaEstudiantesSeccion]
as
Select u.idUsuario, p.nombre,p.apellido1,p.apellido2,p.cedula,se.nombre Seccion FROM Persona p 
Join Usuario u on p.idPersona=u.idUsuario
JOIN EstudianteSeccion est on u.idUsuario=est.idUsuario
JOIN Seccion se on se.idSeccion=est.idSeccion

GO
/****** Object:  StoredProcedure [dbo].[listaMaterialesMateria]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   proc [dbo].[listaMaterialesMateria]
@idDetalleMateria int
as
SELECT m.idMaterial,m.idUsuario,m.idDetalleMateria,m.titulo,m.mensaje,m.material,m.nombreMaterial,m.fechaHora from Material m where m.idDetalleMateria=@idDetalleMateria ORDER BY m.idMaterial DESC

GO
/****** Object:  StoredProcedure [dbo].[listaMaterias]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   proc [dbo].[listaMaterias]
@idUsuario int
as
Select de.idDetalleMateria,m.nombre as Materia, concat(p.nombre,' ',p.apellido1,' ',p.apellido2) as nomProfesor,s.nombre as Seccion,grado 
   From Detallemateria de JOIN Materia m on de.idMateria=m.idMateria Join Persona p  on de.idUsuario=p.idPersona 
   JOIN Seccion s on de.idSeccion=de.idSeccion  JOIN EstudiantesMaterias es on es.idDetalleMateria=de.idDetalleMateria where es.idUsuario=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[listaMateriasEstudiante]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[listaMateriasEstudiante]
@idSeccion int
as
  Select de.idDetalleMateria,m.nombre as Materia, concat(p.nombre,' ',p.apellido1,' ',p.apellido2) as nomProfesor,s.nombre as Seccion
   From Detallemateria de JOIN Materia m on de.idMateria=m.idMateria Join Persona p  on de.idUsuario=p.idPersona 
   JOIN Seccion s on de.idSeccion=s.idSeccion  where de.idSeccion=@idSeccion

GO
/****** Object:  StoredProcedure [dbo].[listaMateriasProfesor]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE   proc [dbo].[listaMateriasProfesor]
@idUsuario int
as
Select de.idDetalleMateria,m.nombre as Materia,s.nombre as Seccion,grado 
From Detallemateria de JOIN Materia m on de.idMateria=m.idMateria 
JOIN Seccion s on de.idSeccion=s.idSeccion  JOIN ProfesoresMaterias prof on prof.idDetalleMateria=de.idDetalleMateria where prof.idUsuario=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[listaNoticiasInternas]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create    PROC [dbo].[listaNoticiasInternas]
as
SELECT idNoticia,idtipo,titulo,descripcion,imagen,fechaYHora from Noticia where idTipo=2 Order by idNoticia Desc

GO
/****** Object:  StoredProcedure [dbo].[listaNoticiasPublicas]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create    PROC [dbo].[listaNoticiasPublicas]
as
SELECT idNoticia,idtipo,titulo,descripcion,imagen,fechaYHora from Noticia where idTipo=1 Order by idNoticia Desc

GO
/****** Object:  StoredProcedure [dbo].[listaRoles]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[listaRoles]
as
Select*from Rol

GO
/****** Object:  StoredProcedure [dbo].[listaSecciones]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[listaSecciones]
as
Select*from Seccion

GO
/****** Object:  StoredProcedure [dbo].[listaUsuarios]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[listaUsuarios]
as
Select p.idPersona,p.nombre,p.apellido1,apellido2,p.cedula,p.correo,u.idUsuario,u.idRol as rol,r.nombre as rolNombre,u.usuario,u.contrasena FROM Persona p
JOIN Usuario u on p.idPersona=u.idUsuario JOIN Rol  r on u.idRol=r.idRol 

GO
/****** Object:  StoredProcedure [dbo].[login]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   proc [dbo].[login]
@usuario varchar(30),
@contrasena varchar(30)
as
Select p.idPersona,p.nombre,p.apellido1,p.apellido2,p.correo,u.idUsuario,u.idRol,r.nombre as rolNombre,u.usuario,u.contrasena From Usuario u JOIN Persona p on p.idPersona=u.idUsuario
JOIN Rol  r on u.idRol=r.idRol where u.usuario=@usuario and u.contrasena=@contrasena

GO
/****** Object:  StoredProcedure [dbo].[modificarEstudianteSeccion]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create   proc [dbo].[modificarEstudianteSeccion]
@idUsuario int,
@idSeccion int
as
UPDATE EstudianteSeccion set idSeccion=@idSeccion where idUsuario=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[modificarNoticia]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[modificarNoticia]
@idNoticia int,
@idTipo int,
@titulo varchar(100),
@descripcion varchar(300),
@contenido varchar(1000),
@imagen varchar(45)
as
Update Noticia set idtipo=@idTipo,titulo=@titulo,descripcion=@descripcion,contenido=@contenido,imagen=@imagen where idNoticia=@idNoticia

GO
/****** Object:  StoredProcedure [dbo].[modificarPersona]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[modificarPersona]
@idPersona int,
@nombre varchar(60),
@apellido1 varchar(60),
@apellido2 varchar(60),
@cedula varchar(20),
@correo varchar(100)
as
UPDATE Persona set nombre=@nombre,apellido1=@apellido1,apellido2=@apellido2,cedula=@cedula,correo=@correo where idPersona=@idPersona

GO
/****** Object:  StoredProcedure [dbo].[modificarUsuario]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[modificarUsuario]
@idUsuario int,
@idRol int,
@usuario varchar(30),
@contrasena varchar(30)
as
UPDATE Usuario set idRol=@idRol,usuario=@usuario,contrasena=@contrasena where idUsuario=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[ultimasNoticias]    Script Date: 28/5/2018 12:28:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PROC [dbo].[ultimasNoticias]
as
SELECT TOP 3 idNoticia,idtipo,titulo,descripcion,imagen,fechaYHora from Noticia where idTipo=1
ORDER BY idNoticia DESC

GO
USE [master]
GO
ALTER DATABASE [bela] SET  READ_WRITE 
GO
