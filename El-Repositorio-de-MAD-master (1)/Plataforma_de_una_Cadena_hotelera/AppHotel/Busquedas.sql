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