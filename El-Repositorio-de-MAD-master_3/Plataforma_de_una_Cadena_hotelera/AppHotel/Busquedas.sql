USE GD_HOTEL_MAX5
go
CREATE PROCEDURE sp_Busca_Pais
AS
BEGIN
	select Nombre nombre
	from vw_BuscaPais
END
go
create PROCEDURE sp_Busca_Tipo_Hab
AS
BEGIN
	select tipo nombre
	from vw_BuscaTipoHab
END
go
create PROCEDURE sp_Busca_Ciudad
AS
BEGIN
	select Nombre nombre
	from vw_BuscaCiudad


END
go
create PROCEDURE sp_Busca_CiudadUsu
@idUsu	int
AS
BEGIN
select C_Nombre nombre
from Ciudad
where Cve_usuario = @idUsu


END
go
create PROCEDURE sp_Busca_Cliente
AS
BEGIN
	select Nombre nombre
	from vw_BuscaCliente
END
go
create PROCEDURE sp_Busca_Hotel
@nombre_ciudad		varchar(50),
@id_usu		int
AS
BEGIN
	
	--fn_checa_idCiudad
	--declare @idTemp;

	--select ;

	select Nombre nombre
	from Hotel
	where id_ciudad = dbo.fn_checa_idCiudad(@nombre_ciudad, @id_usu)

	--select Nombre from Hotel
END
go
create PROCEDURE sp_MuestraTipoHab
@nombre_hotel		varchar(50)
AS
BEGIN
	
	--fn_checa_idCiudad
	--declare @idTemp;

	----select ;
	--declare @num	int
	--set @num = 0
	select distinct id_tipoHab  ID
	from Habitacion
	where ID_Hotel = dbo.fn_checa_idHotel(@nombre_hotel)

	--select Tipo tipo
	--from Tipo_Habitacion
	--where id_tipoHab =@num

END
go
create PROCEDURE sp_MuestraHabitacion
@nombre_hotel		varchar(50),
@tipo_hab		varchar(50)
AS
BEGIN
	
	--fn_checa_idCiudad
	--declare @idTemp;

	----select ;
	--declare @num	int
	--set @num = 0
	select No_Hab  num
	from Habitacion
	where ID_Hotel = dbo.fn_checa_idHotel(@nombre_hotel) and id_tipoHab = dbo.fn_checa_idTipoHab3(@tipo_hab)

	--select Tipo tipo
	--from Tipo_Habitacion
	--where id_tipoHab =@num

END
go
create PROCEDURE sp_MuestraTipoHab2
@id		int
AS
BEGIN
	
	
	select distinct tipo  nombre
	from Tipo_Habitacion
	where id_tipoHab = @id

	

END

go

create PROCEDURE sp_Busca_Usuario
AS
BEGIN
	select Nombre nombre
	from vw_BuscaUsuario
END
go
create PROCEDURE sp_Busca_Servicio
AS
BEGIN
	select Nombre nombre
	from vw_BuscaServicio
END
go
CREATE PROCEDURE sp_Busca_idHotel
@nombreH		varchar(50)
AS
BEGIN
	select ID_Hotel ID
	from Hotel
	where Nombre = @nombreH
END
go

create PROCEDURE sp_Busca_idUsu
@nombreU		varchar(80)
AS
BEGIN
	select Cve_usuario ID
	from Usuario
	where Nombre = @nombreU
END
go
create PROCEDURE sp_Busca_idPais--sp_Busca_idPais
@nombreP		varchar(50)
AS
BEGIN
	select id_pais ID
	from Pais
	where P_Nombre = @nombreP
END
go
create PROCEDURE sp_Busca_idCiudad
@nombreC		varchar(80)
AS
BEGIN
	select id_ciudad ID
	from Ciudad
	where C_Nombre = @nombreC
END
go
create PROCEDURE sp_Busca_idTipoHab
@nombreTipo		varchar(80)
AS
BEGIN
	select id_tipoHab ID
	from Tipo_Habitacion
	where Tipo = @nombreTipo
END
go
create PROCEDURE sp_Busca_idTipoServ
@nombreTipo		varchar(80)
AS
BEGIN
	select id_servicio ID
	from Servicio
	where S_Nombre = @nombreTipo
END
go

create PROCEDURE sp_Busca_costoTipoServ
@nombreTipo		varchar(80)
AS
BEGIN
	select Precio precio
	from Servicio
	where S_Nombre = @nombreTipo
END
go
create  procedure sp_BuscaUsu
@usuName	varchar(80),
@usuContra	char(8)
as
begin
	select Nombre, Contrasena from Usuario where @usuName=Nombre and @usuContra=Contrasena
end
go
create PROCEDURE sp_MostrarDatosHotel
@nombre		varchar(80)
AS
BEGIN
	select Nombre nombre, Zona_Turistica ZT, Domicilio domi, No_pisos pisos, Cant_habitaciones habs, Caracteristicas carac, Fecha_inicio ini,
	Usuario_Registro usu
	from Hotel
	where Nombre = @nombre
END
go
--==========================

create PROCEDURE sp_MuestraServ
@id_hotel        varchar (50)
AS
BEGIN
    
    select distinct id_servicio  ID
    from Servicios_en_Hotel
    where ID_Hotel = dbo.fn_checa_idHotel(@id_hotel)

 

END
go
create PROCEDURE sp_MuestraServicios
@id        int
AS
BEGIN
    
    select distinct S_Nombre  nombre
    from Servicio
    where id_servicio = @id

 

END
go
create Procedure sp_TraeCosto
@tipo_hab        varchar(50)

as
begin
    --declare @price money
    --declare    @Total    money

 

    select Precio_noche Price 
    from Tipo_Habitacion
    where id_tipoHab = dbo.fn_checa_idTipoHab4(@tipo_hab)

 

end
go
--=======================================================
create PROCEDURE sp_Busca_idCliente
@nombreC        varchar(80)
AS
BEGIN
    select id_cliente ID
    from Cliente
    where Nombre = @nombreC
END
go
create PROCEDURE sp_Busca_idHabitation
@hotel        varchar(50),
@tipo        varchar(50),
@num	bigint
AS
BEGIN
    select ID_Habitacion ID
    from Habitacion
    where id_tipoHab = dbo.fn_checa_idTipoHab3(@tipo) and ID_Hotel = dbo.fn_checa_idHotel(@hotel) and No_Hab = @num
END
go
create PROCEDURE sp_Maximo
AS
BEGIN
select Max(Cve_Reservacion) ID
	from Reservacion
END

go
--========
create procedure Busca_resreva
@IDR bigint
AS
BEGIN

select Fecha_Entrada,Fecha_Salida, Personas,isnull(RFC,000)RFC,ID_Habitacion, Medio_Pago_Res,Anticipo,Costo_Total
	from Reservacion 
	where @IDR=Cve_Reservacion

END

--================================= BORRAR RESERVACION ============================

go
create procedure BorraReservacion
@IDR bigint
AS
BEGIN
DELETE FROM Reservacion where Cve_Reservacion=@IDR

END
go
create procedure BorraServiReservacion
@IDR bigint
AS
BEGIN
DELETE FROM Servicios_en_Reservacion where Cve_Reservacion=@IDR

END
go
create procedure SP_Consulta_cliente
@nombreCliente varchar (80)
as
BEGIN
select Nombre Nombre_Cliente,Paterno Apellido_Paterno,Materno Apellido_Materno, RFC  [RFC del Cliente]
from Cliente 
where @nombreCliente=Nombre
END
go
--================= CKECK IN  =============

create PROCEDURE sp_MostrarDatosReservacion
@id        bigint
AS
BEGIN
    select RFC idc, id_habitacion idh, Personas personas, Anticipo anticipo, Medio_Pago_Res MPR, CONVERT(date,Fecha_Entrada,2) FE, CONVERT(date,Fecha_Salida,2) FS, check_in CheckIN,check_out CheckOUT
    from Reservacion
    where Cve_Reservacion = @id
END

go
create PROCEDURE sp_MostrarNombreCliente
@id        int
AS
BEGIN
    select Nombre name, Paterno p, Materno m
    from Cliente
    where RFC = @id
END
go
create PROCEDURE sp_MostrarNombreHabitac
@id        bigint
AS
BEGIN
    select B.Tipo nom
    from Habitacion A
	left join Tipo_Habitacion B
    on B.id_tipoHab = dbo.fn_checa_idHab(@id) 
END

go
create PROCEDURE sp_CheckIn
@id        bigint
AS
BEGIN
    update Reservacion
    set check_in = 1
    WHERE Cve_Reservacion = @id
END
go
create procedure sp_checkinpasado
as
begin
	declare @tabla table(fecha	date)
	insert into @tabla(fecha) select Fecha_Entrada from Reservacion
	declare @count int = (select count(*) from @tabla)

	while (@count > 0)
	begin
		declare @fechae	date = (select top(1) fecha from @tabla)

		if(@fechae < getdate())
		begin
			delete
			from Reservacion
			where Fecha_Entrada = @fechae
		end

			set @count =( select count(*) from @tabla)
	end
   
end

go

--create procedure sp_checkinpasado
--as
--begin
--	declare @tabla table(fecha	date)
--	insert into @tabla(fecha) select Fecha_Entrada from Reservacion
--	declare @count int = (select count(*) from @tabla)				-- La cantidad de registros en reservación
--
--
--	while (@count > 0)
--	begin
--		declare @fecha	date = (select top(1) fecha from @tabla)
--
--		if(@fecha < getdate())
--		begin
--			delete
--			from Reservacion
--			where Fecha_Entrada = @fecha
--		end
--
--			--set @count =( select count(*) from @tabla)
--			set @count = @count-1
--	end
--   
--end

create procedure sp_descuento
@cve    bigint,
@desc    money

as
begin
    declare @total    money
    declare @anti    money
	declare @Final    money
    select Costo_Total-(Costo_Total-Anticipo)*(@desc/100) [final]
    from Reservacion
    where Cve_Reservacion = @cve

 

    --set @Final = @total- (@total- @anti)*(@desc/100) 
	--select @Final final
end
go

-- select Costo_Total
--    from Reservacion
--    where Cve_Reservacion = 1800

--=================  CHECK OUT  ===============

create PROCEDURE sp_MaximoFACTURA
AS
BEGIN
select Max(numFac) ID
	from factura
END

go
create procedure sp_descuento2
@cve    bigint,
@desc    money
as
begin
    declare @total    money
    declare @anti    money
	declare @Final    money
    select @total = Costo_Total, @anti = Anticipo
    from Reservacion
    where Cve_Reservacion = @cve

 

    set @Final =@total-  @total*(@desc/100) - @anti

 

    create table #tabla(id    int, costo    money);
    insert into #tabla(id) select B.id_servicio 
    from Reservacion A
    left join Servicios_en_Reservacion B
    on A.Cve_Reservacion = B.Cve_Reservacion

 

    declare @count    int
    select @count = count(id)
    from #tabla

 

    while (@count>0)
    begin
        insert into #tabla(costo) select D.Precio 
        from Servicios_en_Reservacion C
        left join Servicio D
        on C.id_servicio = D.id_servicio

 

        set @count = @count - 1 
    end

 

    select @count = count(costo)
    from #tabla

 

    declare @P    money
    while (@count>0)
    begin
        select @P = costo
        from #tabla

 

        set @Final = @Final + @P
    end

	select @Final final
end
go
--=================
create procedure sp_BuscaClientRFC
@nombre varchar (80)
as
begin
    select RFC, Nombre, Paterno, Materno
    from Cliente
    where @nombre = Nombre
end
--=================
go
create procedure sp_HistorialClient
@RFC    int
as
begin
    declare @NH varchar(50)
    select A.Cve_Reservacion [Clave de Reservacion], B.Nombre [Nombre del hotel], A.Fecha_Entrada [Fecha de entrada],
         A.Fecha_Salida [Fecha de salida], A.Costo_Total [Costo total], A.Personas [Cantidad de personas],dbo.fn_historialservicios(A.Cve_Reservacion) [Servicios]
    from Reservacion A
    left join Hotel B
    on A.RFC = @RFC and B.ID_Hotel = dbo.fn_NombreHotel(A.ID_Habitacion)
	where  A.RFC = @RFC and B.ID_Hotel = dbo.fn_NombreHotel(A.ID_Habitacion)and A.check_in = 1 and A.check_out = 1
end
--exec sp_HistorialClient 1234
--=================
go

--create procedure sp_reporte_ventas
--@pais    varchar(50),
--@mes    int
--as
--begin
--    declare @c_nom    varchar
--    declare @ingresos    money
--    select  Nombre [Nombre del Hotel], dbo.fn_ingresototal2(@mes) [Ingresos por hospedaje], dbo.fn_ingresototal3(@mes) [Ingresos de servicios]
--    from Hotel 
--    where dbo.fn_buscaciudad(@pais) = id_ciudad
--
--end
--go

--exec sp_reporte_ventas2 'EEUU',7


 --select dbo.fn_ingresototal(6) [Ingresos]
 --   from Reservacion B
 --   where month(getdate()) = 6

--=======================================

create procedure sp_reporte_ventas2
@pais    varchar(50),
@mes    int
as
begin
    declare @c_nom    varchar
    declare @ingresos    money
	set @ingresos = 0

    select  dbo.FN_RegresaHotelName(A.ID_Hotel) [Nombre del Hotel], SUM(C.Costo_Total) [Ingresos de hospedaje] --@ingresos + C.Costo_Total  --, dbo.fn_ingresototal3(@mes) [Ingresos de servicios], A.Nombre [Nombre del Hotel],
    from Hotel A
	full join Habitacion B
	on A.ID_Hotel = B.ID_Hotel
	full outer join Reservacion C
	on C.ID_Habitacion = B.ID_Habitacion
    where dbo.fn_buscaciudad(@pais) = A.id_ciudad and month(C.Fecha_Salida) = @mes
	group by A.ID_Hotel
end

--go
--select dbo.FN_RegresaHotelName(B.ID_Hotel) [Nombre del Hotel],SUM(Costo_Total)  [Ingresos por hospedaje]
--from Reservacion A
--inner join Habitacion B
--on B.ID_Habitacion=A.ID_Habitacion
--where month(A.Fecha_Salida) = 6
--group by B.ID_Hotel


go

create procedure sp_reporte_ventas
@pais    varchar(50),
@mes    int
as
begin
    declare @c_nom    varchar
    declare @ingresos    money
    select  B.C_Nombre [Ciudad], A.Nombre [Nombre del Hotel], dbo.fn_ingresototal2(@mes,A.ID_Hotel) [Ingresos por hospedaje], dbo.fn_ingresototal3(@mes) [Ingresos de servicios]
    from Hotel A
	left join Ciudad B
	on  A.id_ciudad = B.id_ciudad
    where dbo.fn_buscaciudad(@pais) = A.id_ciudad

end
go
--exec sp_reporte_ventas 'EEUU',6

--create view vw_reporteventas
--as

create procedure algo
as
begin
	drop table #tabla1
	create table  #tabla1 (id_ int,nombreHot varchar( 50), costoT money)
	declare @cant int
	declare @cont int
	select @cant = count(Cve_Reservacion) 
	from Reservacion



	set @cont = 0
	while @cont < @cant
	begin
		declare @A_id	int
		declare @B_nom	varchar(50)
		declare @C_cost	money

		select @A_id=B.ID_Hotel , @B_nom=dbo.FN_RegresaHotelName(B.ID_Hotel),@C_cost=SUM(Costo_Total)  
		--into #tabla1
		from Reservacion A
		inner join Habitacion B
		on B.ID_Habitacion=A.ID_Habitacion
		full outer join Hotel C
		on C.ID_Hotel = B.ID_Hotel	--if C.ID_Hotel != ''
		where month(A.Fecha_Salida) = 6 and A.Cve_Reservacion = @cont + 1000
		group by B.ID_Hotel
		
		insert into #tabla1 values(@A_id, @B_nom, @C_cost)
		set @cont = @cont+50
	end
	select id_, nombreHot, costoT 
	from #tabla1
end
go
---funcion base
--=================================================================================================================
--=================================================================================================================
create procedure sp_RegistroVentas @pais varchar (50),@mes int
as
begin

select dbo.fn_traeidciudadName(B.ID_Hotel) [ciudad],dbo.FN_RegresaHotelName(B.ID_Hotel) [Nombre del hotel],SUM(Costo_Total) [ingresos de hospedaje] ,sum( E.Precio) [ingresos de servicios]
from Reservacion A
inner join Habitacion B
on B.ID_Habitacion=A.ID_Habitacion
FULL OUTER JOIN Hotel C
on C.ID_Hotel = B.ID_Hotel
Full outer join Servicios_en_Reservacion D
on D.Cve_Reservacion = A.Cve_Reservacion
left join Servicio E
on D.id_servicio = E.id_servicio
where month(A.Fecha_Salida) = @mes and dbo.fn_traeidciudadpais(B.ID_Hotel) = dbo.fn_idPais(@pais)
group by B.ID_Hotel

end

go
--select dbo.fn_traeidciudadName(10)
--exec sp_RegistroVentas 'mexico',6



--===================================================================================
--regresa el nombre del hotel con el id
-- select  dbo.FN_RegresaHotelName(A.ID_Hotel) [Nombre del Hotel], SUM(C.Costo_Total) [Ingresos de hospedaje] --@ingresos + C.Costo_Total  --, dbo.fn_ingresototal3(@mes) [Ingresos de servicios], A.Nombre [Nombre del Hotel],
--    from Hotel A
--	full join Habitacion B
--	on A.ID_Hotel = B.ID_Hotel
--	full outer join Reservacion C
--	on C.ID_Habitacion = B.ID_Habitacion
--    where dbo.fn_buscaciudad('EEUU') = A.id_ciudad and month(C.Fecha_Salida) = 6
--	group by A.ID_Hotel
--
--	select [Id del Hotel],[Nombre del Hotel] from vw_reporteventas
--===================================================================================


create procedure sp_ReporteOcupaciones @pais varchar (50),@fecha date
as
begin 
select dbo.fn_traeidciudadName(B.ID_Hotel) [ciudad],dbo.FN_RegresaHotelName(B.ID_Hotel) [Nombre del hotel],round(SUM(dbo.fn_cantidadHabOcupadas(A.Cve_Reservacion) * 100/dbo.fn_cantidadHab(B.ID_Hotel)),2)[porcentaje de ocupacion total]
from Reservacion A
inner join Habitacion B
on B.ID_Habitacion=A.ID_Habitacion
FULL OUTER JOIN Hotel C
on C.ID_Hotel =B.ID_Hotel
Full outer join Tipo_Habitacion D
on D.id_tipoHab = B.id_tipoHab
where @fecha between A.Fecha_Entrada and A.Fecha_Salida and dbo.fn_traeidciudadpais(B.ID_Hotel) = dbo.fn_idPais(@pais)
group by B.ID_Hotel

 end
 go
 --exec sp_ReporteOcupaciones 'EEUU', '20200608'


create procedure RepreOcupacionesTipo 
@id_hotel	int,
@fecha	date
as
begin
 select dbo.fn_traeidTipoHabName(B.id_tipoHab) [Tipo de habitacion],count(A.id_tipoHab) --dbo.fn_calcula_porcentaje2(count(A.id_tipoHab))--, dbo.fn_buscacanttipo(@fecha))
    from Habitacion A
    left join Tipo_Habitacion B
    on A.id_tipoHab = B.id_tipoHab
	full outer join Reservacion C
	on C.ID_Habitacion = A.ID_Habitacion
    where A.ID_Hotel = @id_hotel and @fecha between C.Fecha_Entrada and C.Fecha_Salida
    group by B.id_tipoHab

end
go
create procedure ps_RepreOcupacionesTipo 
@id_hotel	int,
@fecha	date
as
begin
    select dbo.fn_traeidTipoHabName(B.id_tipoHab) [Tipo de habitacion], 
	round( dbo.fn_RepreOcupacionesTipo(A.ID_Hotel, @fecha, B.id_tipoHab)* 100/dbo.fn_RepreOcupacionesTipo2(@id_hotel, B.id_tipoHab),2) [ocupacion por tipo hab],
	SUM(dbo.fn_repreOcupacionesPersonas(@id_hotel, B.id_tipoHab, C.Cve_Reservacion))  [Personas alojadas]--dbo.repreOcupacionesPersonas(C.Cve_Reservacion)	
	from Habitacion A
	inner join Tipo_Habitacion B
	on A.id_tipoHab = B.id_tipoHab
	full outer join Reservacion C
	on C.ID_Habitacion = A.ID_Habitacion
	where A.ID_Hotel = @id_hotel and @fecha between C.Fecha_Entrada and C.Fecha_Salida
	group by B.id_tipoHab, A.ID_Hotel--,C.Personas
	

end
go

--====================================================================
create procedure traeserviciosfactura
@cve	bigint
as
begin
	select B.S_Nombre nombre, B.precio precio
	from Servicios_en_Reservacion A
	inner join Servicio B
	on A.id_servicio = B.id_servicio
	where @cve = cve_reservacion
end
go
create procedure sp_deleteReserv
@clave    bigint
as
begin
    delete from Reservacion where Cve_Reservacion = @clave



end
go
create procedure sp_updateReserv
@clave    bigint
as
begin
   update Reservacion set check_out = 1 where Cve_Reservacion = @clave



end
