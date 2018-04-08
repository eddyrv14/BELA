USE [bela]
GO
/****** Object:  Table [dbo].[DetalleMateria]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[EstudiantesMaterias]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[ImagenNoticia]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[MasMaterial]    Script Date: 7/4/2018 4:33:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasMaterial](
	[idMasMaterial] [int] IDENTITY(1,1) NOT NULL,
	[idMaterial] [int] NULL,
	[material] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[idMasMaterial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Materia]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[Material]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
	[material] [varchar](45) NULL,
	[fechaHora] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMaterial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MensajeContacto]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[Noticia]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[NotiExternas]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[NotiInternas]    Script Date: 7/4/2018 4:33:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotiInternas](
	[idNotificacionInt] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idNotificacionInt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 7/4/2018 4:33:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](60) NULL,
	[apellido1] [varchar](60) NULL,
	[apellido2] [varchar](60) NULL,
	[correo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfesoresMaterias]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[Seccion]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[TipoNoticia]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/4/2018 4:33:43 p. m. ******/
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
SET IDENTITY_INSERT [dbo].[DetalleMateria] OFF
SET IDENTITY_INSERT [dbo].[EstudiantesMaterias] ON 

INSERT [dbo].[EstudiantesMaterias] ([idEstudianteMateria], [idUsuario], [idDetalleMateria]) VALUES (1, 6, 1)
INSERT [dbo].[EstudiantesMaterias] ([idEstudianteMateria], [idUsuario], [idDetalleMateria]) VALUES (2, 6, 2)
SET IDENTITY_INSERT [dbo].[EstudiantesMaterias] OFF
SET IDENTITY_INSERT [dbo].[ImagenNoticia] ON 

INSERT [dbo].[ImagenNoticia] ([idImagen], [idNoticia], [imagen]) VALUES (6, 20, '/Imagenes/ImagenesNoticias/4.jpg')
INSERT [dbo].[ImagenNoticia] ([idImagen], [idNoticia], [imagen]) VALUES (7, 20, '/Imagenes/ImagenesNoticias/5.jpg')
SET IDENTITY_INSERT [dbo].[ImagenNoticia] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([idMateria], [nombre]) VALUES (1, 'Ciencias')
INSERT [dbo].[Materia] ([idMateria], [nombre]) VALUES (2, 'Matematicas')
SET IDENTITY_INSERT [dbo].[Materia] OFF
SET IDENTITY_INSERT [dbo].[MensajeContacto] ON 

INSERT [dbo].[MensajeContacto] ([idMensaje], [correo], [asunto], [mensaje]) VALUES (2, 'ponce@gmail.com', 'prueba2', 'Esto es la prueba 2')
INSERT [dbo].[MensajeContacto] ([idMensaje], [correo], [asunto], [mensaje]) VALUES (3, 'ponce@gmail.com', 'sdsd', 'ssssssssss ssss sss')
INSERT [dbo].[MensajeContacto] ([idMensaje], [correo], [asunto], [mensaje]) VALUES (4, 'prueba2@gmail.com', 'sdsdsdss', 'ss')
SET IDENTITY_INSERT [dbo].[MensajeContacto] OFF
SET IDENTITY_INSERT [dbo].[Noticia] ON 

INSERT [dbo].[Noticia] ([idNoticia], [idUsuario], [idtipo], [titulo], [descripcion], [contenido], [imagen], [fechaYHora]) VALUES (1, 1, 1, 'Noticia Prueba 1', 'Descripcion prueba 1', 'Contenido prueba 1', '/Imagenes/inicio3.jpg', CAST('2018-02-21T17:44:03.000' AS DateTime))
INSERT [dbo].[Noticia] ([idNoticia], [idUsuario], [idtipo], [titulo], [descripcion], [contenido], [imagen], [fechaYHora]) VALUES (2, 1, 1, 'Noticia Prueba 2', 'Descripcion prueba 2', 'Contenido prueba 2', '/Imagenes/inicio3.jpg', CAST('2018-02-21T18:44:03.000' AS DateTime))
INSERT [dbo].[Noticia] ([idNoticia], [idUsuario], [idtipo], [titulo], [descripcion], [contenido], [imagen], [fechaYHora]) VALUES (3, 1, 1, 'Noticia Prueba 3', 'Descripcion prueba 3', 'Contenido prueba 3', '/Imagenes/inicio3.jpg', CAST('2018-02-21T19:44:03.000' AS DateTime))
INSERT [dbo].[Noticia] ([idNoticia], [idUsuario], [idtipo], [titulo], [descripcion], [contenido], [imagen], [fechaYHora]) VALUES (4, 1, 1, 'Noticia Prueba 4', 'Descripcion prueba 4', 'Contenido prueba 4', '/Imagenes/ImagenesNoticias/5.jpg', CAST('2018-02-21T20:44:03.000' AS DateTime))
INSERT [dbo].[Noticia] ([idNoticia], [idUsuario], [idtipo], [titulo], [descripcion], [contenido], [imagen], [fechaYHora]) VALUES (19, 1, 2, 'Noticia privada', 'noticia privada', 'privada asdsdsadsad', '/Imagenes/ImagenesNoticias/4.jpg', CAST('2018-03-21T12:55:14.000' AS DateTime))
INSERT [dbo].[Noticia] ([idNoticia], [idUsuario], [idtipo], [titulo], [descripcion], [contenido], [imagen], [fechaYHora]) VALUES (20, 1, 1, 'v06', 'v05', 'v05', '/Imagenes/ImagenesNoticias/6.jpg', CAST('2018-04-04T19:50:52.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Noticia] OFF
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [correo]) VALUES (1, 'Bayron', 'Navarro', 'Ponce', 'Ponce.bayron.bayron944@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [correo]) VALUES (2, 'Lester', 'Torres', 'Nose', 'lester.togu@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [correo]) VALUES (3, 'Luis', 'Chavez', 'Nose', 'Luis@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [correo]) VALUES (4, 'Eddy', 'Retana', 'Nose', 'Eddy@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [correo]) VALUES (5, 'BayronProf', 'Navarro', 'Ponce', 'Ponce@gmail.com')
INSERT [dbo].[Persona] ([idPersona], [nombre], [apellido1], [apellido2], [correo]) VALUES (6, 'BayronEstudian', 'Navarro', 'Ponce', 'PonceFide@gmail.com')
SET IDENTITY_INSERT [dbo].[Persona] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([idRol], [nombre]) VALUES (1, 'Administrador')
INSERT [dbo].[Rol] ([idRol], [nombre]) VALUES (2, 'Profesor')
INSERT [dbo].[Rol] ([idRol], [nombre]) VALUES (3, 'Estudiante')
SET IDENTITY_INSERT [dbo].[Rol] OFF
SET IDENTITY_INSERT [dbo].[Seccion] ON 

INSERT [dbo].[Seccion] ([idSeccion], [nombre]) VALUES (1, '7-1')
SET IDENTITY_INSERT [dbo].[Seccion] OFF
SET IDENTITY_INSERT [dbo].[TipoNoticia] ON 

INSERT [dbo].[TipoNoticia] ([idTipoNoticia], [nombre]) VALUES (1, 'Publica')
INSERT [dbo].[TipoNoticia] ([idTipoNoticia], [nombre]) VALUES (2, 'Privada')
SET IDENTITY_INSERT [dbo].[TipoNoticia] OFF
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (1, 1, 'bayron', '1234')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (2, 1, 'lester', '1234')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (5, 2, 'bayronProf', '1234')
INSERT [dbo].[Usuario] ([idUsuario], [idRol], [usuario], [contrasena]) VALUES (6, 3, 'bayronEst', '1234')
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
ALTER TABLE [dbo].[NotiInternas]  WITH CHECK ADD  CONSTRAINT [FK_IDUSARIOCORREO] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[NotiInternas] CHECK CONSTRAINT [FK_IDUSARIOCORREO]
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
/****** Object:  StoredProcedure [dbo].[buscarCuenta]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[buscarCuenta]
@idUsuario int
as
Select p.idPersona,p.nombre,p.apellido1,apellido2,p.correo,u.idUsuario,u.idRol as rol,r.nombre as rolNombre,u.usuario,u.contrasena FROM Persona p
JOIN Usuario u on p.idPersona=u.idUsuario JOIN Rol  r on u.idRol=r.idRol where u.idUsuario=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[crearNoticia]    Script Date: 7/4/2018 4:33:44 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[crearPersona]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   proc [dbo].[crearPersona]
@nombre varchar(60),
@apellido1 varchar(60),
@apellido2 varchar(60),
@correo varchar(100)
as
Insert into Persona values(@nombre,@apellido1,@apellido2,@correo)

GO
/****** Object:  StoredProcedure [dbo].[crearUsuario]    Script Date: 7/4/2018 4:33:44 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[detalleNoticia]    Script Date: 7/4/2018 4:33:44 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[eliminarNoticia]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROC [dbo].[eliminarNoticia]
@idNoticia int
as
DELETE FROM Noticia where idNoticia=@idNoticia

GO
/****** Object:  StoredProcedure [dbo].[eliminarPersona]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[eliminarPersona]
@idUsuario int
as
DELETE FROM Persona where idPersona=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[eliminarUsuario]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[eliminarUsuario]
@idUsuario int
as
DELETE FROM Usuario where idUsuario=@idUsuario

GO
/****** Object:  StoredProcedure [dbo].[insertarImagenes]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarImagenes]
@imagenes varchar(50)
as
INSERT INTO ImagenNoticia values((Select top 1 idNoticia from Noticia order by idNoticia desc),@imagenes)

GO
/****** Object:  StoredProcedure [dbo].[insertarMensaje]    Script Date: 7/4/2018 4:33:44 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[listaMaterias]    Script Date: 7/4/2018 4:33:44 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[listaNoticiasInternas]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create    PROC [dbo].[listaNoticiasInternas]
as
SELECT idNoticia,idtipo,titulo,descripcion,imagen,fechaYHora from Noticia where idTipo=2 Order by idNoticia Desc

GO
/****** Object:  StoredProcedure [dbo].[listaNoticiasPublicas]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create    PROC [dbo].[listaNoticiasPublicas]
as
SELECT idNoticia,idtipo,titulo,descripcion,imagen,fechaYHora from Noticia where idTipo=1 Order by idNoticia Desc

GO
/****** Object:  StoredProcedure [dbo].[listaUsuarios]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[listaUsuarios]
as
Select p.idPersona,p.nombre,p.apellido1,apellido2,p.correo,u.idUsuario,u.idRol as rol,r.nombre as rolNombre,u.usuario,u.contrasena FROM Persona p
JOIN Usuario u on p.idPersona=u.idUsuario JOIN Rol  r on u.idRol=r.idRol 

GO
/****** Object:  StoredProcedure [dbo].[login]    Script Date: 7/4/2018 4:33:44 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[modificarNoticia]    Script Date: 7/4/2018 4:33:44 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[modificarPersona]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[modificarPersona]
@idPersona int,
@nombre varchar(60),
@apellido1 varchar(60),
@apellido2 varchar(60),
@correo varchar(100)
as
UPDATE Persona set nombre=@nombre,apellido1=@apellido1,apellido2=@apellido2,correo=@correo where idPersona=@idPersona

GO
/****** Object:  StoredProcedure [dbo].[modificarUsuario]    Script Date: 7/4/2018 4:33:44 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[ultimasNoticias]    Script Date: 7/4/2018 4:33:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PROC [dbo].[ultimasNoticias]
as
SELECT TOP 3 idNoticia,idtipo,titulo,descripcion,imagen,fechaYHora from Noticia where idTipo=1
ORDER BY idNoticia DESC

GO
