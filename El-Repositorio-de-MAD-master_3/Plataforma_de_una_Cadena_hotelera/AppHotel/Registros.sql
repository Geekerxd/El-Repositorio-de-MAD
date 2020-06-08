USE GD_HOTELS3
------------------------------REGISTRO USUARIO-------------------------------

CREATE PROCEDURE sp_Insert_User
@Contrasena	       char(8),
@nombreC			  varchar(80),
@paterno				varchar(20),
@materno			varchar(20),
@No_nomina		    int,
@Fecha_nacimiento   datetime,
@Domicilio		    varchar(100),
@Telefono		    char(10)
AS
BEGIN
	--declare @Nombre_Comp varchar(80)
	--set @Nombre_Comp=CAST (@nombreC +' '+@paterno+' '+@materno as varchar(80))
	select convert(varchar,  @Fecha_nacimiento, 112) --aaaammdd 

    insert into Usuario
    values (@Contrasena, @nombreC, @paterno, @materno, @No_nomina, @Fecha_nacimiento, @Domicilio, @Telefono,null);

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
@id_pais        int,
@cve_usu		int
AS
BEGIN
    insert into Ciudad
    values (@nombre, @descrip, @cve_usu, @id_pais);

END

select * from Ciudad


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
--checar .-.
create PROCEDURE sp_Insert_Client
@RFC			   int,
@nombre			  varchar(80),
@paterno				varchar(20),
@materno			varchar(20),
@domicilio		    varchar(100),
@e_mail				varchar(50),
@telefono		    char(10),
@referencia		    varchar(50),
@fecha_naci		    date,
@usuRegistro		int
AS
BEGIN
	--declare @Nombre_Comp varchar(80)
	--set @Nombre_Comp=CAST (@nombre +' '+@paterno+' '+@materno as varchar(80))
	select convert(varchar,  @fecha_naci, 112) --aaaammdd 
	--@ shoft + anlt 
    insert into Cliente 
    values (@RFC, @nombre,@paterno,@materno, @domicilio, @e_mail, @telefono, @referencia, @fecha_naci, @usuRegistro);

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
@Ciudad			int
AS
BEGIN
	declare @fecha_ini datetime = getdate()
    insert into Hotel(Caracteristicas,Usuario_Registro,No_pisos,Nombre,Cant_habitaciones,Zona_Turistica,Fecha_inicio,Domicilio,id_ciudad)
    values (@caract, @usuario_registro, @no_pisos, @nombre, @cant_hab, @zona_tur, @fecha_ini, @domicilio, @Ciudad);

END

select * from Hotel

--------------------------REGISTRO HABITACION----------------------------------

create PROCEDURE sp_Insert_Habitacion
--@nivel			 varchar(50),
--@caract		varchar(300),
@no_hab			int,
@id_hotel		int,
@tipo		int
AS
BEGIN
    insert into Habitacion(No_Hab, ID_Hotel, id_tipoHab)
    values (@no_hab, @id_hotel, @tipo);

END

select * from Habitacion
select * from Hotel


--------------------------REGISTRO SERVICIOS EN HOTEL----------------------------------

create PROCEDURE sp_Insert_Servicios_en_Hotel
@id_hotel			 int,
@id_serv			int
--@HorarioE		datetime,
--@HorarioS		datetime
AS
BEGIN
    insert into Servicios_en_Hotel(ID_Hotel,id_servicio)
    values (@id_hotel, @id_serv);

END

select * from Servicios_en_Hotel


--------------------------REGISTRO RESERVACIONES----------------------------------
-- le quite lo de insertar RFC
alter PROCEDURE sp_Insert_Resevation

	@anticipo		money,			--
	@medio_pago_res	 varchar(50),	--
	@fecha_E		date,			--
	@fecha_S		date,			--
	@Personas		tinyint,		--
	@ID_client			int,		--
	@id_Habitacion bigint,			--
	@total		money				--
AS
BEGIN
    insert into Reservacion(Anticipo,Medio_Pago_Res,Fecha_Entrada,Fecha_Salida,Personas,
	ID_Habitacion,Costo_Total,RFC)
    values (@anticipo, @medio_pago_res,@fecha_E, @fecha_S, @Personas, @id_Habitacion,@total,@ID_client);

	

END


create PROCEDURE sp_Insert_Serv_in_Reserv
    @cve_reserv        bigint,
    @id_serv     int
    
AS
BEGIN
    insert into Servicios_en_Reservacion
    values (@cve_reserv, @id_serv);
END
----------------------=============================
create PROCEDURE sp_Nuevafactura
    @cve_reserv        bigint
    
AS
BEGIN
    insert into factura (Cve_Reservacion)
    values (@cve_reserv);
END

--==========================================================

select * from Usuario
select * from Cliente
select * from hotel
select * from habitacion
select * from Servicios_en_Hotel
select * from Servicio

select * from Reservacion

select * from Servicios_en_Reservacion

select * from hotel
select * from ciudad
select * from pais

select * from tipo_habitacion
select * from factura


select * from hotel
select * from habitacion


-- set S_Nombre='Srv Cuarto' 
--delete  Servicio
--where id_servicio=40






