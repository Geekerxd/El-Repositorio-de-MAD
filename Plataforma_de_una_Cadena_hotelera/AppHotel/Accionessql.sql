

--===================================



insert into Usuario values('pass','Santiago perez','78','19990501','super calle 15','12345678',NULL)

insert into Usuario values('dsa','dsa perez','79','19980501','super calle 15','12345678',NULL)
select *from Usuario


CREATE PROCEDURE sp_Insert_User
@Contrasena        char(8),
@Nombre_Comp    varchar(80),
@No_nomina        int,
@Fecha_nacimiento    datetime,
@Domicilio        varchar(100),
@Telefono        char(10)
AS
BEGIN
    insert into Usuario
    values (@Contrasena, @Nombre_Comp, @No_nomina, @Fecha_nacimiento, @Domicilio, @Telefono, null);
END



exec sp_Insert_User 'aas','David A. B.','45','19950118','calleee','456791'














CREATE PROCEDURE sp_Insert_User1

@Nombre_Comp    varchar(80)
AS
BEGIN
    insert into Usuario (Nombre_Comp)
    values ( @Nombre_Comp);
END



--exec sp_Insert_User 'aas','David A. B.','45','19950118','calleee','456791'
