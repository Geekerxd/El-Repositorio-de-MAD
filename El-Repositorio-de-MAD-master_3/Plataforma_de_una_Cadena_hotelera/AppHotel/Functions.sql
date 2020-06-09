USE GD_HOTEL_MAX5
--------------------------------------------------------FUNCTIONS-----------------------------------------------------
go
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
go
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
go
create function fn_checa_idTipoHab3(@tipo_hab	varchar(50))--fn_checa_idHotel
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
go

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

go

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
go
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
go
--===================
create function fn_NombreHotel(@id_hab    bigint)
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

go
create trigger tg_check_out
on Reservacion
instead of delete
as
begin
    declare @cve    bigint

 

    select @cve = Cve_Reservacion
    from deleted

 

    update Reservacion
    set check_out = 0,check_in = 0
    where Cve_Reservacion = @cve





end


go
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
    where id_pais = dbo.fn_idPais(@nombrep)
	
return @idc
end

 go

create function fn_ingresototal(@mes    int)
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


go

--create function fn_ingresototal2(@mes    int)
--returns varchar (50)
--as
--begin
--    declare @ingreso    money
--    declare @cont    int
--    select @cont = count(0)
--    from Reservacion
--
-- 
--
--    set @ingreso =0
--
-- 
--        if month(getdate()) = @mes
--        begin
--            select @ingreso = @ingreso + Costo_Total
--            from Reservacion A
--			full join Hotel B
--			on month(Fecha_Salida) = @mes
--            where month(Fecha_Salida) = @mes and B.ID_Hotel= dbo.fn_NombreHotel(A.ID_Habitacion)-- and year(Fecha_Salida) = year(getdate())
--        end
--
-- 
-- 
--
--    return convert(varchar, @ingreso) 
--end
--


--=================
create function fn_historialservicios(@idr    bigint)
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
go
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
go
--==================================
create function fn_ingresototal2_1(@mes    int, @ID_H    int, @pais	varchar(50), @ingreso money)
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

go

create function fn_ingresototal2(@mes    int, @idh	int)
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
go
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
 go
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
go
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
go


 --===================================================================================
  --============================================4 funciones================================
   --===================================================================================

-- create function fn_porcentajeH(@idh    int)
--returns float
--as
--begin
--    declare @porcentaje    float
--    declare @cant    float
--    declare @cant2    float
--    set @cant = dbo.fn_cantidadHab(@idh)
--    --set @cant2 = dbo.fn_cantidadHabOcupadas(B.Cve_Reservacion)

 

--    select  @porcentaje = dbo.fn_calcula_porcentaje(@cant, dbo.fn_cantidadHabOcupadas(B.Cve_Reservacion))--B.Cve_Reservacion
--    from Habitacion A
--    left join Reservacion B
--    on A.ID_Habitacion = B.ID_Habitacion
--    where A.ID_Hotel = @idh

 

--    return @porcentaje
--end

 

create function fn_cantidadHab(@idh    int)
returns float
as
begin
    declare @cant    float
    select @cant = count(No_Hab)
    from Habitacion
    where ID_Hotel = @idh

    return @cant
end

 go

create function fn_cantidadHabOcupadas(@idr    bigint)
returns float
as
begin
    declare @cant    float
    select @cant = count(A.No_Hab)
    from Habitacion A
    full outer join Reservacion B
    on A.ID_Habitacion = B.ID_Habitacion
    where B.Cve_Reservacion = @idr

    return @cant
end

 go

create function fn_calcula_porcentaje(@cant    float, @cant2    float)
returns float
as
begin
    declare @porcentaje as float
	
    set @porcentaje = @cant2 * 100/@cant
	--select @porcentaje

    return round(@porcentaje,2)
end
go


--======================================================================================================
create function fn_cantidadHab2(@idh    int)
returns float
as
begin
    declare @cant    float
    select @cant = count(A.id_tipoHab)
    from Habitacion A
    left join Tipo_Habitacion B
    on A.id_tipoHab = B.id_tipoHab
    where A.ID_Hotel = @idh
    group by B.id_tipoHab

 

    return @cant
end
go


create function fn_buscacanttipo(@fecha	date)
returns float
as
begin
	declare @cant	float
	select @cant = count(A.id_tipoHab)
	from Habitacion A
	left join Reservacion B
	on A.ID_Habitacion = B.ID_Habitacion
	where @fecha between B.Fecha_Entrada and B.Fecha_Salida
	group by A.id_tipoHab


	return @cant
end
go



	create function fn_calcula_porcentaje2(@cant    float, @cant2    float)
returns float
as
begin
    declare @porcentaje as float
	
    set @porcentaje = @cant2 * 100/@cant
	--select @porcentaje

    return round(@porcentaje,2)
end
go



create function fn_RepreOcupacionesTipo (@id_hotel	int,@fecha	date,@id_tipo	int)
returns float
as
begin
declare	@cant	float
 select @cant = count(A.id_tipoHab) --dbo.fn_calcula_porcentaje2(count(A.id_tipoHab))--, dbo.fn_buscacanttipo(@fecha))
    from Habitacion A
    left join Tipo_Habitacion B
    on A.id_tipoHab = B.id_tipoHab
	full outer join Reservacion C
	on C.ID_Habitacion = A.ID_Habitacion
    where A.ID_Hotel = @id_hotel and @fecha between C.Fecha_Entrada and C.Fecha_Salida and B.id_tipoHab = @id_tipo
    group by B.id_tipoHab

	return @cant
end
go


create function fn_RepreOcupacionesTipo2 (@id_hotel	int, @id_tipo	int)
returns float
as
begin
declare	@cant	float
 select @cant = count(A.id_tipoHab) --dbo.fn_calcula_porcentaje2(count(A.id_tipoHab))--, dbo.fn_buscacanttipo(@fecha))
    from Habitacion A
    left join Tipo_Habitacion B
    on A.id_tipoHab = B.id_tipoHab
	--left outer join Reservacion C
	--on C.ID_Habitacion = A.ID_Habitacion
    where A.ID_Hotel = @id_hotel and B.id_tipoHab = @id_tipo
    group by A.id_tipoHab

	return @cant
end
go


 --===================================================================================
 create function fn_traeidTipoHabName(@idhab    int)
returns varchar (50)
as
begin
declare @nombre    varchar(50)

    select @nombre = tipo
    from Tipo_Habitacion
    where id_tipoHab = @idhab

    return @nombre
end
go
 --===================================================================================

 create function fn_repreOcupacionesPersonas (@id_hotel	int, @id_tipo	int, @cve_reserv	bigint)
returns float
as
begin
declare	@cant	float
 select @cant = sum(C.Personas) --dbo.fn_calcula_porcentaje2(count(A.id_tipoHab))--, dbo.fn_buscacanttipo(@fecha))
    from Habitacion A
    left join Tipo_Habitacion B
    on A.id_tipoHab = B.id_tipoHab
	left outer join Reservacion C
	on C.ID_Habitacion = A.ID_Habitacion
    where A.ID_Hotel = @id_hotel and B.id_tipoHab = @id_tipo and C.cve_reservacion = @cve_reserv
    group by C.Personas

	return @cant
end
