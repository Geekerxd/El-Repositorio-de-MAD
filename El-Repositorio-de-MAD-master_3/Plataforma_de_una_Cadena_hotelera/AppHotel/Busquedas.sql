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

select Fecha_Entrada,Fecha_Salida, Personas,isnull(id_cliente,000)id_cliente,ID_Habitacion, Medio_Pago_Res,Anticipo,Costo_Total
	from Reservacion where @IDR=Cve_Reservacion

END

--================================= BORRAR RESERVACION ============================


create procedure BorraReservacion
@IDR bigint
AS
BEGIN
DELETE FROM Reservacion where Cve_Reservacion=@IDR

END