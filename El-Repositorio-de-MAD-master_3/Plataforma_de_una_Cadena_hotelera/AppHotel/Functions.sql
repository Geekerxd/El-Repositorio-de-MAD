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
end--

create function fn_checa_idHab(@idHab	bigint)
returns int
as
begin
	declare @ID int;
	set @ID = 0;
	select @ID = id_tipoHab 
	from Habitacion
	where ID_Habitacion = @idHab

return @ID
end--

--===================
alter function fn_NombreHotel(@id_hab    int)
returns int
as
begin
    declare @IDHotel    int
    select @IDHotel = B.ID_Hotel
    from Hotel A
    left join Habitacion B
    on @id_hab = B.ID_Habitacion-- and B.ID_Hotel = A.ID_Hotel
return @IDHotel
end


create trigger tg_check_out
on Reservacion
instead of delete
as
begin
    declare @cve    bigint

 

    select @cve = Cve_Reservacion
    from deleted

 

    update Reservacion
    set check_out = 1
    where Cve_Reservacion = @cve
end

create procedure sp_deleteReserv
@clave    bigint
as
begin
    delete from Reservacion where Cve_Reservacion = @clave
end
--===========================
create function fn_idPais(@nombrep    varchar(50))
returns int
as
begin
    declare @idp    int
    select    @idp= id_pais
    from Pais
    where P_Nombre = @nombrep
return @idp
end

 go

create function fn_buscaciudad(@nombrep    varchar(50))
returns int
as
begin
    declare @idc    int
    select    @idc= id_ciudad
    from Ciudad
    where id_pais = dbo.fn_idPais('EEUU')
return @idc
end

 

alter function fn_ingresototal(@mes    int)
returns varchar (50)
as
begin
    declare @ingreso    money
    declare @cont    int
    select @cont = count(0)
    from Reservacion

 

    while @cont > 0
    begin
        select @ingreso = @ingreso + Costo_Total
        from Reservacion
        where month(Fecha_Salida) = @mes

 

        set @cont = @cont -1
    end

 
 
    return convert(varchar, @ingreso) 
end




alter function fn_ingresototal2(@mes    int)
returns varchar (50)
as
begin
    declare @ingreso    money
    declare @cont    int
    select @cont = count(0)
    from Reservacion

 

    set @ingreso =0

 

    --while @cont > 0
    --begin
    
        if month(getdate()) = @mes
        begin
            select @ingreso = @ingreso + Costo_Total
            from Reservacion
            where month(Fecha_Salida) = @mes-- and year(Fecha_Salida) = year(getdate())
        end

 

    --    set @cont = @cont -1
    --end

 

    return convert(varchar, @ingreso) 
end

select dbo.fn_ingresototal2(6)


