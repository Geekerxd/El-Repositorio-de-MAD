
CREATE DATABASE GD_HOTELS
GO

USE GD_HOTELS
GO

--Creación de tablas

--Creación de tabla Usuario

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Usuario')
)
    DROP TABLE dbo.Usuario;
GO

CREATE TABLE Usuario (
	
	Cve_usuario int primary key not null identity(1000,100),
	Contrasena char(8) NOT NULL UNIQUE,
	Nombre_Comp varchar(80) not null,
	No_nomina int,
	Fecha_nacimiento datetime,
	Domicilio varchar(100),
	Telefono char(10),
	foto image default null,
);
GO

--Creación de tabla Cliente


IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Cliente')
)
    DROP TABLE dbo.Cliente;
GO

CREATE TABLE Cliente (
	
	RFC int primary key not null,
	Nombre_Comp varchar(80) NOT NULL,
	Domicilio varchar(100),
	e_mail varchar(50),
	Telefono char(10) not null,
	Referencia varchar(50),
	Fecha_nacimiento datetime,
	
	Usuario_Atiende int FOREIGN KEY REFERENCES Usuario(Cve_usuario),
);
GO

--Creación de tabla Hotel

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Hotel')
)
    DROP TABLE dbo.Hotel;
GO

CREATE TABLE Hotel (
	
	ID_Hotel int primary key not null,
	Caracteristicas varchar(300),
	Usuario_Registro varchar(80) not null,
	No_pisos tinyint,
	Nombre varchar(50) not null,
	Cant_habitaciones int,
	Zona_Turistica varchar(50),
	Fecha_inicio datetime,
	Domicilio varchar(100),
	
	Cve_usuario int FOREIGN KEY REFERENCES Usuario(Cve_usuario),
	C_Nombre varchar(50) FOREIGN KEY REFERENCES Ciudad(C_Nombre)
);
GO

--Creación de tabla Habitacion

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Habitacion')
)
    DROP TABLE dbo.Habitacion;
GO

CREATE TABLE Habitacion (
	
	ID_Habitacion int primary key not null,
	Nivel tinyint,
	Caracteristicas varchar(300),
	No_Hab int,
	Precio_Noche money not null,
	
	ID_Hotel int FOREIGN KEY REFERENCES Hotel(ID_Hotel),
	Tipo varchar(50) FOREIGN KEY REFERENCES Tipo_Habitacion(Tipo)
);
GO

--Creación de tabla Reservacion

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Reservacion')
)
    DROP TABLE dbo.Reservacion;
GO

CREATE TABLE Reservacion (
	
	Cve_Reservacion  int primary key not null,
	check_in bit default null,
	check_out bit default null,
	Anticipo money not null,
	Medio_Pago_Res varchar(50),
	Fecha_Entrada datetime not null,
	Fecha_Salida datetime,
	Personas tinyint not null,
	
	RFC_Cliente int FOREIGN KEY REFERENCES Cliente(RFC),
	ID_Habitacion int FOREIGN KEY REFERENCES Habitacion(ID_Habitacion),

	Costo_Total money default null,
	Medio_Pago_Fac varchar(50),
	Descuento money,
	No_Fact int default null
);
GO

--Creación de tabla Servicio

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Servicio')
)
    DROP TABLE dbo.Servicio;
GO

CREATE TABLE Servicio (
	
	S_Nombre varchar(50) primary key not null,
	Precio money not null,
	Caracteristicas varchar(300)
);
GO

--Creación de tabla Ciudad

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Ciudad')
)
    DROP TABLE dbo.Ciudad;
GO

CREATE TABLE Ciudad (
	
	C_Nombre  varchar(50) primary key not null,
	Descripcion varchar(300),
	
	P_Nombre varchar(50) FOREIGN KEY REFERENCES Pais(P_Nombre)
);
GO

--Creación de tabla Pais

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Pais')
)
    DROP TABLE dbo.Pais;
GO

CREATE TABLE Pais (
	
	P_Nombre  varchar(50) primary key not null,
	Descripcion varchar(300)
);
GO

--Creación de tabla Tipo_Habitacion

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Tipo_Habitacion')
)
    DROP TABLE dbo.Tipo_Habitacion;
GO

CREATE TABLE Tipo_Habitacion (
	
	Tipo varchar(50) primary key not null,
	Caracteristicas varchar(300),
	No_Camas tinyint,
	Tipo_Cama varchar(30),
	Cant_Personas tinyint not null
);
GO

--Creación de tabla Servicios_en_Hotel

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Servicios_en_Hotel')
)
    DROP TABLE dbo.Servicios_en_Hotel;
GO

CREATE TABLE Servicios_en_Hotel (
	
	ID_Hotel int FOREIGN KEY REFERENCES Hotel(ID_Hotel),
	S_Nombre varchar(50)FOREIGN KEY REFERENCES Servicio(S_Nombre),
	HorarioE datetime, 
	HorarioS datetime 
);
GO

--Creación de tabla Servicios_en_Reservacion

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Servicios_en_Reservacion')
)
    DROP TABLE dbo.Servicios_en_Reservacion;
GO

CREATE TABLE Servicios_en_Reservacion (
	
	Cve_Reservacion int FOREIGN KEY REFERENCES Reservacion(Cve_Reservacion),
	S_Nombre varchar(50)FOREIGN KEY REFERENCES Servicio(S_Nombre),
);
GO

