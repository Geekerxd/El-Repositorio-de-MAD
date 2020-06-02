
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
	declare @Nombre_Comp varchar(80)
	set @Nombre_Comp=CAST (@nombreC +' '+@paterno+' '+@materno as varchar(80))
	select convert(varchar,  @Fecha_nacimiento, 112) --aaaammdd 

    insert into Usuario
    values (@Contrasena, @Nombre_Comp, @No_nomina, @Fecha_nacimiento, @Domicilio, @Telefono);

END

drop procedure sp_Insert_User
select * from Usuario

-------------------------REGISTRO PAIS---------------------------------------

CREATE PROCEDURE sp_Insert_Pais
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


--------------------------REGISTRO TIPO HABITACION----------------------------------

create PROCEDURE sp_Insertar_Tipo_Hab
@nombre           varchar(50),
@descrip      varchar(300),
@no_camas           tinyint,
@tipo_cama      varchar(30),
@cant_pers          tinyint
AS
BEGIN
    insert into Tipo_Habitacion
    values (@nombre, @descrip, @no_camas, @tipo_cama, @cant_pers);

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
