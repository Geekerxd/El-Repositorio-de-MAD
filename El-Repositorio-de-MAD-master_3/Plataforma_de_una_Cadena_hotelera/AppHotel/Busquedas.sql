USE GD_HOTELS3
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

create PROCEDURE sp_MuestraTipoHab2
@id		int
AS
BEGIN
	
	
	select distinct tipo  nombre
	from Tipo_Habitacion
	where id_tipoHab = @id

	

END

--create PROCEDURE sp_MuestraHab  -BORRAR
--@nombre_hotel		varchar(50)
--AS
--BEGIN
--	
--	--fn_checa_idCiudad
--	--declare @idTemp;
--
--	--select ;
--
--	select Nombre nombre
--	from Hotel
--	where id_ciudad = dbo.fn_checa_idCiudad(@nombre_ciudad)
--
--	--select Nombre from Hotel
--END

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
--checar y tambien adentro de EnlaceDB
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
--CREATE PROCEDURE sp_BuscaInfoH		--	BORRAR
--@nombre_H		varchar(50)
--AS
--BEGIN
--	select Nombre nombre, No_pisos pisos, Cant_habitaciones num_hab, Zona_Turistica zona, 
--	Caracteristicas caract, Domicilio domi, Fecha_inicio fecha_ini
--	from Hotel
--	where C_Nombre = @nombre_ciudad

--	--select Nombre from Hotel


--END

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

--==========================

alter PROCEDURE sp_MuestraServ
@id_hotel        varchar (50)
AS
BEGIN
    
    select distinct id_servicio  ID
    from Servicios_en_Hotel
    where ID_Hotel = dbo.fn_checa_idHotel(@id_hotel)

 

END
create PROCEDURE sp_MuestraServicios
@id        int
AS
BEGIN
    
    select distinct S_Nombre  nombre
    from Servicio
    where id_servicio = @id

 

END

alter Procedure sp_TraeCosto
@tipo_hab        varchar(50)

as
begin
    --declare @price money
    --declare    @Total    money

 

    select Precio_noche Price 
    from Tipo_Habitacion
    where id_tipoHab = dbo.fn_checa_idTipoHab4(@tipo_hab)

 

end
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
@tipo        varchar(50)
AS
BEGIN
    select ID_Habitacion ID
    from Habitacion
    where id_tipoHab = dbo.fn_checa_idTipoHab3(@tipo) and ID_Hotel = dbo.fn_checa_idHotel(@hotel)
END
go
create PROCEDURE sp_Maximo
AS
BEGIN
select Max(Cve_Reservacion) ID
	from Reservacion
END


--========
alter procedure Busca_resreva
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
create procedure BorraServiReservacion
@IDR bigint
AS
BEGIN
DELETE FROM Servicios_en_Reservacion where Cve_Reservacion=@IDR

END

--

--alter procedure SP_Consulta_cliente
--@nombreCliente varchar (80)
--as 
--BEGIN
--declare @nom	varchar(80)
--declare @pat	varchar(50)
--	
--declare @mat	varchar(50)
--
--declare @rfc	int
--
--
--
--create table #tabla2(Nombre_Cliente	varchar(80), Apellido_Paterno	varchar(50), Apellido_Materno	varchar(50), RFC	int)
--select @nom = Nombre,@pat = Paterno,@mat =Materno, @rfc=RFC 
--from Cliente 
--where @nombreCliente=Nombre
--
--insert into #tabla2
--values(@nom, @pat,@mat,@rfc)
--
--
--select Nombre_Cliente, Apellido_Paterno, Apellido_Materno, RFC
--from #tabla2
--END
alter procedure SP_Consulta_cliente
@nombreCliente varchar (80)
as
BEGIN
select Nombre Nombre_Cliente,Paterno Apellido_Paterno,Materno Apellido_Materno, RFC  [RFC del Cliente]
from Cliente 
where @nombreCliente=Nombre
END

--================= CKECK IN  =============

alter PROCEDURE sp_MostrarDatosReservacion
@id        bigint
AS
BEGIN
    select RFC idc, id_habitacion idh, Personas personas, Anticipo anticipo, Medio_Pago_Res MPR, CONVERT(date,Fecha_Entrada,2) FE, CONVERT(date,Fecha_Salida,2) FS, check_in CheckIN
    from Reservacion
    where Cve_Reservacion = @id
END


alter PROCEDURE sp_MostrarNombreCliente
@id        int
AS
BEGIN
    select Nombre name, Paterno p, Materno m
    from Cliente
    where RFC = @id
END

alter PROCEDURE sp_MostrarNombreHabitac
@id        bigint
AS
BEGIN
    select B.Tipo nom
    from Habitacion A
	left join Tipo_Habitacion B
    on B.id_tipoHab = dbo.fn_checa_idHab(@id) 
END


alter PROCEDURE sp_CheckIn
@id        bigint
AS
BEGIN
    update Reservacion
    set check_in = 1
    WHERE Cve_Reservacion = @id
END

alter procedure sp_checkinpasado
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



alter procedure sp_checkinpasado
as
begin
	declare @tabla table(fecha	date)
	insert into @tabla(fecha) select Fecha_Entrada from Reservacion
	declare @count int = (select count(*) from @tabla)				-- La cantidad de registros en reservación


	while (@count > 0)
	begin
		declare @fecha	date = (select top(1) fecha from @tabla)

		if(@fecha < getdate())
		begin
			delete
			from Reservacion
			where Fecha_Entrada = @fecha
		end

			--set @count =( select count(*) from @tabla)
			set @count = @count-1
	end
   
end

alter procedure sp_descuento
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

 

    set @Final = @total- @total*(@desc/100) - @anti
	select @Final final
end





--=================  CHECK OUT  ===============

create PROCEDURE sp_MaximoFACTURA
AS
BEGIN
select Max(numFac) ID
	from factura
END


alter procedure sp_descuento2
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

--=================
alter procedure sp_BuscaClientRFC
@nombre varchar (80)
as
begin
    select RFC, Nombre, Paterno, Materno
    from Cliente
    where @nombre = Nombre
end
--=================
alter procedure sp_HistorialClient
@RFC    int
as
begin
    declare @NH varchar(50)
    select A.Cve_Reservacion [Clave de Reservacion], B.Nombre [Nombre del hotel], A.Fecha_Entrada [Fecha de entrada],
         A.Fecha_Salida [Fecha de salida], A.Costo_Total [Costo total], A.Personas [Cantidad de personas]
    from Reservacion A
    left join Hotel B
    on A.RFC = @RFC and B.ID_Hotel = dbo.fn_NombreHotel(A.ID_Habitacion)
	where  A.check_in = 1 and A.check_out = 1
end

--=================


alter procedure sp_reporte_ventas
@pais    varchar(50),
@mes    int
as
begin
    declare @c_nom    varchar
    declare @ingresos    money
    select  Nombre [Nombre del Hotel], dbo.fn_ingresototal2(@mes) [Ingresos por hospedaje]
    from Hotel 
    where dbo.fn_buscaciudad(@pais) = id_ciudad
   
   
    
end


exec sp_reporte_ventas 'EEUU',6


 select dbo.fn_ingresototal(7) [Ingresos]
    from Reservacion B
    where month(getdate()) = 7
