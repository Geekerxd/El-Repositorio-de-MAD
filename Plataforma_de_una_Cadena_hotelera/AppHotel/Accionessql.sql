
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



select * from Usuario
--===================================



insert into Usuario values('pass','Santiago perez','78','19990501','super calle 15','12345678',NULL)

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
