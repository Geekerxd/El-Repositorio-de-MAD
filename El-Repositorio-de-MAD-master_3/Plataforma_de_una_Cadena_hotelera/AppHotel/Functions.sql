USE GD_HOTELS3
--------------------------------------------------------FUNCTIONS-----------------------------------------------------

create function fn_checa_idCiudad(@nombreC	varchar(80), @nombreUsu	int)
returns int
as
begin
	declare @ID int;
	set @ID=0;
	select @ID= id_ciudad 
	from Ciudad
	where C_Nombre = @nombreC and Cve_usuario = @nombreUsu

return @ID
end;

create function fn_checa_idHotel(@nombreH	varchar(80))--fn_checa_idHotel
returns int
as
begin
	declare @IDH int;
	set @IDH=0;
	select @IDH = ID_Hotel 
	from Hotel
	where Nombre = @nombreH

return @IDH
end;

alter function fn_checa_idTipoHab3(@tipo_hab	varchar(50))--fn_checa_idHotel
returns int
as
begin
	declare @IDH int;
	set @IDH=0;

	select @IDH = id_tipoHab 
	from Tipo_Habitacion
	where Tipo = @tipo_hab

return @IDH
end;


create function fn_checa_idTipoHab4(@tipo_hab	varchar(50))--fn_checa_idHotel
returns money
as
begin
	declare @IDH money;
	set @IDH=0;

	select @IDH = id_tipoHab 
	from Tipo_Habitacion
	where Tipo = @tipo_hab

return @IDH
end;



create function fn_checa_idTipoHab(@numHab	int)
returns int
as
begin
	declare @ID int;
	set @ID = 0;
	select @ID = ID_Habitacion 
	from Habitacion
	where No_Hab = @numHab

return @ID
end;