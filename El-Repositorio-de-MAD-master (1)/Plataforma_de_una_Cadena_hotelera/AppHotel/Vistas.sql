create view vw_BuscaPais
as
    select P_Nombre Nombre
    from Pais
go
create view vw_BuscaTipoHab
as
	select Tipo tipo
    from Tipo_Habitacion
go
create view vw_BuscaCiudad
as
	select C_Nombre Nombre
    from Ciudad
	go
create view vw_BuscaUsuario
as
	select Nombre_Comp Nombre
    from Usuario
	go
create view vw_BuscaServicio
as
	select S_Nombre Nombre
    from Servicio