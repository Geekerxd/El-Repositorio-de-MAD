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
alter function fn_NombreHotel(@id_hab    bigint)
returns int
as
begin
    declare @IDHotel    int
    select @IDHotel = B.ID_Hotel
    from Hotel A
    left join Habitacion B
    on A.ID_Hotel = B.ID_Hotel
	where @id_hab = B.ID_Habitacion-- and B.ID_Hotel = A.ID_Hotel
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
alter function fn_idPais(@nombrep    varchar(50))
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

alter function fn_buscaciudad(@nombrep    varchar(50))
returns int
as
begin
    declare @idc    int
    select    @idc= id_ciudad
    from Ciudad
    where id_pais = dbo.fn_idPais(@nombrep)
	
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

 
        if month(getdate()) = @mes
        begin
            select @ingreso = @ingreso + Costo_Total
            from Reservacion A
			full join Hotel B
			on month(Fecha_Salida) = @mes
            where month(Fecha_Salida) = @mes and B.ID_Hotel= dbo.fn_NombreHotel(A.ID_Habitacion)-- and year(Fecha_Salida) = year(getdate())
        end

 
 

    return convert(varchar, @ingreso) 
end

select dbo.fn_ingresototal2(6)

--=================
alter function fn_historialservicios(@idr    bigint)
returns varchar(300)
as
begin
    declare @servicios    varchar(300)
    set @servicios = ''
    select @servicios = @servicios  + A.S_Nombre+ ', '
    from Servicio A
    full outer join Servicios_en_Reservacion B
    on A.id_servicio = B.id_servicio
    where B.Cve_Reservacion = @idr
	return @servicios
end
--===================
create function fn_ingresototal3(@mes    int)
returns varchar (50)
as
begin
    declare @ingreso    money
    declare @cont    int
    select @cont = count(0)
    from Servicio

 

    set @ingreso =0
    
        if month(getdate()) = @mes
        begin
            select @ingreso = @ingreso + B.Precio
            from Servicios_en_Hotel A
            left join Servicio B
            on A.id_servicio = B.id_servicio
        end

 

    return convert(varchar, @ingreso) 
end
--==================================
alter function fn_ingresototal2_1(@mes    int, @ID_H    int, @pais	varchar(50), @ingreso money)
returns varchar (50)
as
begin
    --declare @ingreso    money
    declare @cont    int
    select @cont = count(0)
    from Reservacion

 

    --set @ingreso =0

 

        --if month(getdate()) = @mes
        --begin
		
            select @ingreso = SUM(A.Costo_Total) 
            from Reservacion A
            full join Habitacion B
            on A.ID_Habitacion = B.ID_Habitacion
            where month(A.Fecha_Salida) = @mes  and @ID_H = B.ID_Hotel--dbo.fn_NombreHotel(A.ID_Habitacion) and B.id_ciudad = dbo.fn_buscaciudad(@pais)--dand B.ID_Hotel=@ID_H bo.fn_buscaciudad(@pais)-- and year(Fecha_Salida) = year(getdate())
			group by B.ID_Hotel
		--end

    return convert(varchar, @ingreso) 
end



alter function fn_ingresototal2(@mes    int, @idh	int)
returns varchar (50)
as
begin
    declare @ingreso    money
    declare @cont    int
    select @cont = count(0)
    from Reservacion

    set @ingreso =0

 
        --if month(getdate()) = @mes
        --begin
            select @ingreso = SUM(A.Costo_Total)
            from Reservacion A
			--full join Hotel B
			--on month(Fecha_Salida) = @mes
            where month(A.Fecha_Salida) = @mes and @idh= dbo.fn_NombreHotel(A.ID_Habitacion)-- and year(Fecha_Salida) = year(getdate())
        --end

    return convert(varchar, @ingreso) 
end
--===================================================================================
create function FN_RegresaHotelName(@Id_H int)
returns varchar (50)
as 
begin
declare @HotelName varchar (50)

select @HotelName=Nombre
from Hotel
where ID_Hotel=@Id_H

return @HotelName
 end
 --===================================================================================
 create function fn_traeidciudadName(@idh    int)
returns varchar (50)
as
begin
declare @nombre    varchar(50)
    select @nombre = B.C_Nombre
    from Hotel A
    left join Ciudad B
    on A.id_ciudad = B.id_ciudad
    where ID_Hotel = @idh
    return @nombre
end
 --===================================================================================

 create function fn_traeidciudadpais(@idh    int)
returns int
as
begin
declare @idp    int
    select @idp = B.id_pais
    from Hotel A
	left join Ciudad B
	on  A.id_ciudad = B.id_ciudad
    where A.ID_Hotel = @idh

    return @idp
end


 --===================================================================================