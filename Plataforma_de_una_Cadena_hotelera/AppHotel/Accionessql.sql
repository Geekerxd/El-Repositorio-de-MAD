
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

    insert into Usuario (Contrasena,Nombre_Comp,No_nomina,Fecha_nacimiento,Domicilio,Telefono)
    values (@Contrasena, @Nombre_Comp, @No_nomina, @Fecha_nacimiento, @Domicilio, @Telefono);

END

ALTER PROCEDURE sp_Insert_User2
@Contrasena	       char(8),
@nombreC			  varchar(80),
@paterno				varchar(20),
@materno			varchar(20),
@No_nomina		    int,
@Fecha_nacimiento   datetime
AS
BEGIN
	declare @Nombre_Comp varchar(80)
	set @Nombre_Comp=CAST (@nombreC +' '+@paterno+' '+@materno as varchar(80))
	--select convert(varchar,  @Fecha_nacimiento, 112) --aaaammdd 

    insert into Usuario (Contrasena,Nombre_Comp,No_nomina,Fecha_nacimiento)
    values (@Contrasena, @Nombre_Comp,@No_nomina,@Fecha_nacimiento);

END

drop procedure sp_Insert_User

select * from Tipo_Habitacion

select * from Usuario


create procedure sp_StringUsu
as
begin
select * from Usuario

end
--===================================



insert into Pais values('Mexico','algooo')

insert into Usuario values('dsa','dsa perez','79','19980501','super calle 15','12345678',NULL)
select *,convert(varchar,  Fecha_nacimiento, 102) fecha from Usuario
--select --aaaammdd 





exec sp_Insert_User 'aas','David A. B.','45','19950118','calleee','456791'









CREATE PROCEDURE sp_Insert_User1
@Contrasena	       char(8),
@nombreC			  varchar(80),
@paterno				varchar(20),
@materno			  varchar(20),
@No_nomina		     int,
@Fecha_nacimiento    datetime,
@Domicilio		     varchar(100),
@Telefono		     char(10)

AS
BEGIN
    insert into Usuario (Contrasena,Nombre_Comp)
	 values (@Contrasena,@nombreC);
END



--exec sp_Insert_User 'aas','David A. B.','45','19950118','calleee','456791'
-----------REGISTRO PAIS-----------------

 



CREATE PROCEDURE sp_Insert_Pais
@nombre           varchar(50),
@descrip      varchar(300)
AS
BEGIN

 

    insert into Pais (P_Nombre, Descripcion)
    values (@nombre, @descrip);

 

END
select * from Pais


-----------REGISTRO CIUDAD-----------------

 

create PROCEDURE sp_Insert_City
@nombre           varchar(50),
@descrip      varchar(300),
@p_nombre        varchar(50)
AS
BEGIN

 

    insert into Ciudad (C_Nombre, Descripcion, P_Nombre)
    values (@nombre, @descrip, @p_nombre);

 

END


select * from Ciudad
select * from Pais



create view vw_BuscaPais
as
    select P_Nombre Nombre
    from Pais




alter PROCEDURE sp_BuscaPais
AS
BEGIN
    select P_Nombre
    from Pais
END

