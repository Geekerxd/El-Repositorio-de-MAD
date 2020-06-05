--USE GD_HOTELS3
CREATE view vw_BuscaPais
as
    select P_Nombre Nombre
    from Pais
	GO
create view vw_BuscaTipoHab
as
	select Tipo tipo
    from Tipo_Habitacion
	GO
create view vw_BuscaCiudad
as
	select C_Nombre Nombre
    from Ciudad
	GO


create view vw_BuscaCliente
as
	select Nombre nombre
    from Cliente
	go
create view vw_BuscaUsuario
as
	select Nombre nombre
    from Usuario
	GO
create view vw_BuscaServicio
as
	select S_Nombre Nombre
    from Servicio
	GO
	----------checar----------¿CANCElADO?
--create view vw_BuscaHotels
--as
--	select Nombre nombre
--	from Hotels
--	where C_Nombre = @nom_ciudad

create view vw_Busca_Cliente
as

select Nombre,Paterno,Materno, RFC 

from Cliente 
where @nombreCliente=Nombre