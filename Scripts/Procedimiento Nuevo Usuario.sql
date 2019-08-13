CREATE PROCEDURE NUEVO_USER(
@Nuevo_Nick	varchar(20),
@Nuevo_nombre_1	varchar(20),
@Nuevo_nombre_2	varchar(20),
@Nuevo_apellido_1	varchar(20),
@Nuevo_apellido_2	varchar(20),
@Nuevo_edad	int,
@Nuevo_correo	varchar(20)
)
AS 
	SET NOCOUNT ON;
    INSERT INTO USUARIO VALUES (@Nuevo_Nick,@Nuevo_nombre_1,@Nuevo_nombre_2,@Nuevo_apellido_1,@Nuevo_apellido_2,@Nuevo_edad,@Nuevo_correo);

GO
