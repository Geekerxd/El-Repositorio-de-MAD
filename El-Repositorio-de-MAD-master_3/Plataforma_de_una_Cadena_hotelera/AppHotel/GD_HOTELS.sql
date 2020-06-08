
CREATE DATABASE GD_HOTELS3
GO

USE GD_HOTELS3
GO

--Creación de tablas

--Creacion tabla usuario

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
	Nombre varchar(80) not null,
	Paterno varchar(80) not null,
	Materno varchar(80) not null,
	No_nomina int,
	Fecha_nacimiento datetime,
	Domicilio varchar(100),
	Telefono char(10),
	foto image default null,
);
GO

--cambiar tipo de dato datetime to time
ALTER TABLE Usuario Alter column Fecha_nacimiento date;

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
	
	id_cliente	int primary key not null identity(100,100),
	RFC int  not null unique,
	Nombre varchar(80) NOT NULL,
	Paterno varchar(80) NOT NULL,
	Materno varchar(80) NOT NULL,
	Domicilio varchar(100),
	e_mail varchar(50),
	Telefono char(10) not null,
	Referencia varchar(50),
	Fecha_nacimiento datetime,
	
	Cve_usuario int FOREIGN KEY REFERENCES Usuario(Cve_usuario),
);
GO

ALTER TABLE Cliente Alter column Fecha_nacimiento date;

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
	
	ID_Hotel int primary key identity(10,10) not null,
	Caracteristicas varchar(300),
	Usuario_Registro varchar(80) not null,
	No_pisos tinyint,
	Nombre varchar(50) not null,
	Cant_habitaciones int,
	Zona_Turistica varchar(50),
	Fecha_inicio datetime,
	Domicilio varchar(100),
	
	id_ciudad int FOREIGN KEY REFERENCES Ciudad(id_ciudad)
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
	
	ID_Habitacion bigint primary key identity(1,1) not null,
	Nivel tinyint,
	Caracteristicas varchar(300),
	No_Hab int,
	
	ID_Hotel int FOREIGN KEY REFERENCES Hotel(ID_Hotel),
	id_tipoHab int FOREIGN KEY REFERENCES Tipo_Habitacion(id_tipoHab)
);
GO
select * from Habitacion
ALTER TABLE Habitacion Alter column Nivel varchar(50);
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
	
	Cve_Reservacion  bigint primary key identity(1000,50) not null,
	check_in bit default null,
	check_out bit default null,
	Anticipo money not null,
	Medio_Pago_Res varchar(50),
	Fecha_Entrada datetime not null,
	Fecha_Salida datetime,
	Personas tinyint not null,
	
	RFC int FOREIGN KEY REFERENCES Cliente(RFC),
	ID_Habitacion bigint FOREIGN KEY REFERENCES Habitacion(ID_Habitacion),

	Costo_Total money default null,
	Medio_Pago_Fac varchar(50),
	Descuento money,
	No_Fact bigint default null
);
GO
alter table Reservacion alter column No_Fact bigint 

ALTER TABLE Reservacion Alter column Fecha_Entrada date;
ALTER TABLE Reservacion Alter column Fecha_Salida date;

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
	
	id_servicio	int primary key not null identity(5,5),
	S_Nombre varchar(50) not null,
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
	
	id_ciudad	int primary key not null identity(20,20),
	C_Nombre  varchar(50) not null,
	Descripcion varchar(300),
	
	Cve_usuario int FOREIGN KEY REFERENCES Usuario(Cve_usuario),
	id_pais int FOREIGN KEY REFERENCES Pais(id_pais)
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
	
	id_pais	int primary key not null identity(5,5),
	P_Nombre  varchar(50) not null,
	Descripcion varchar(300)
);
GO
select * from Pais
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
	
	id_tipoHab	int primary key not null identity(1,1),
	Tipo varchar(50) not null,
	Caracteristicas varchar(300),
	No_Camas tinyint,
	Tipo_Cama varchar(30),
	Cant_Personas tinyint not null,
	Precio_noche money not null
);
GO
select * from Tipo_Habitacion
--Creación de tabla Servicios_en_Hotel

IF EXISTS
(
    SELECT *
    FROM sys.objects
    WHERE object_id = OBJECT_ID(N'dbo.Servicios_en_Hotel')
)
    DROP TABLE dbo.Servicios_en_Hotel;
GO

CREATE TABLE  (
	ID_Hotel int FOREIGN KEY REFERENCES Hotel(ID_Hotel),
	id_servicio int FOREIGN KEY REFERENCES Servicio(id_servicio),
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
	
	Cve_Reservacion bigint FOREIGN KEY REFERENCES Reservacion(Cve_Reservacion),
	id_servicio int FOREIGN KEY REFERENCES Servicio(id_servicio),
);--
GO
drop table Servicios_en_Reservacion
drop table factura
drop table Reservacion


select * from ciudad


create table factura(

	numFac int primary key not null identity(1000,100),

	Cve_Reservacion bigint FOREIGN KEY REFERENCES Reservacion(Cve_Reservacion),

);






