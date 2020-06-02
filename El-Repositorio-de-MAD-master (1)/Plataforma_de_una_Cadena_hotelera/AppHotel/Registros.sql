
------------------------------REGISTRO USUARIO-------------------------------

create PROCEDURE sp_Insert_User
@Contrasena	       char(8),
@nombreC			  varchar(80),
@paterno				varchar(20),
@materno			varchar(20),
@No_nomina		    int,
@Fecha_nacimiento   date,
@Domicilio		    varchar(100),
@Telefono		    char(10)
AS
BEGIN
	declare @Nombre_Comp varchar(80)
	set @Nombre_Comp=CAST (@nombreC +' '+@paterno+' '+@materno as varchar(80))
	--select convert(varchar,  @Fecha_nacimiento, 112) --aaaammdd 

    insert into Usuario
    values (@Contrasena, @Nombre_Comp, @No_nomina, @Fecha_nacimiento, @Domicilio, @Telefono,null);

END

drop procedure sp_Insert_User
select * from Usuario

-------------------------REGISTRO PAIS---------------------------------------

create PROCEDURE sp_Insert_Pais
@nombre           varchar(50),
@descrip      varchar(300)
AS
BEGIN
    insert into Pais
    values (@nombre, @descrip);

END

select * from Pais


-----------------------REGISTRO CIUDAD------------------------------------------

create PROCEDURE sp_Insert_City
@nombre           varchar(50),
@descrip      varchar(300),
@p_nombre        varchar(50)
AS
BEGIN
    insert into Ciudad
    values (@nombre, @descrip, @p_nombre);

END

select * from Ciudad
delete from Ciudad where C_Nombre='Hotel Trivago'

--------------------------REGISTRO TIPO HABITACION----------------------------------

create PROCEDURE sp_Insertar_Tipo_Hab
@nombre           varchar(50),
@descrip      varchar(300),
@no_camas           tinyint,
@tipo_cama      varchar(30),
@cant_pers          tinyint,
@precio			money
AS
BEGIN
    insert into Tipo_Habitacion
    values (@nombre, @descrip, @no_camas, @tipo_cama, @cant_pers, @precio);

END

select * from Tipo_Habitacion


--------------------------REGISTRO SERVICIOS----------------------------------

create PROCEDURE sp_Insert_Service
@nombre       varchar(50),
@precio		  money,
@caract		varchar(300)
AS
BEGIN
    insert into Servicio
    values (@nombre, @precio, @caract);

END

select * from Servicio


--------------------------REGISTRO CLIENTES----------------------------------

create PROCEDURE sp_Insert_Client
@RFC			   int,
@nombre			  varchar(80),
@paterno				varchar(20),
@materno			varchar(20),
@domicilio		    varchar(100),
@e_mail				varchar(50),
@telefono		    char(10),
@referencia		    varchar(50),
@fecha_naci		    date
AS
BEGIN
	declare @Nombre_Comp varchar(80)
	set @Nombre_Comp=CAST (@nombre +' '+@paterno+' '+@materno as varchar(80))
	--select convert(varchar,  @fecha_naci, 112) --aaaammdd 

    insert into Cliente(RFC, Nombre_Comp, Domicilio, e_mail, Telefono, Referencia, Fecha_nacimiento, Usuario_Atiende)
    values (@RFC, @Nombre_Comp, @domicilio, @e_mail, @telefono, @referencia, @fecha_naci, 1000);

END

select * from Cliente


--------------------------REGISTRO HOTEL----------------------------------

create PROCEDURE sp_Insert_Hotel
@caract			 varchar(300),
@usuario_registro	varchar(80),
@no_pisos		tinyint,
@nombre			varchar(50),
@cant_hab		int,
@zona_tur		varchar(50),
--@fecha_ini		date,
@domicilio		varchar(100),
@usuario_atiende	int,
@Ciudad			varchar(50)
AS
BEGIN
	declare @fecha_ini datetime = getdate()
    insert into Hotel(Caracteristicas,Usuario_Registro,No_pisos,Nombre,Cant_habitaciones,Zona_Turistica,Fecha_inicio,Domicilio,Cve_usuario,C_Nombre)
    values (@caract, @usuario_registro, @no_pisos, @nombre, @cant_hab, @zona_tur, @fecha_ini, @domicilio, @usuario_atiende, @Ciudad);

END

select * from Hotel

--------------------------REGISTRO HABITACION----------------------------------

create PROCEDURE sp_Insert_Habitacion
@nivel			 tinyint,
--@caract		varchar(300),
@no_hab			int,
@id_hotel		int,
@tipo		varchar(50)
AS
BEGIN
    insert into Habitacion(Nivel, No_Hab, ID_Hotel, Tipo)
    values (@nivel, @no_hab, @id_hotel, @tipo);

END

select * from Habitacion


--------------------------REGISTRO SERVICIOS EN HOTEL----------------------------------

create PROCEDURE sp_Insert_Servicios_en_Hotel
@id_hotel			 int,
@nombre		varchar(50),
@HorarioE		datetime,
@HorarioS		datetime
AS
BEGIN
    insert into Servicios_en_Hotel
    values (@id_hotel, @nombre, @HorarioE, @HorarioS);

END

select * from Servicios_en_Hotel