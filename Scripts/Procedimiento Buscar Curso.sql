CREATE PROCEDURE BUSCAR_CURSO
    @name nvarchar(20)
AS   

   SET NOCOUNT ON;  
   SELECT C.id_curso, C.nombre, U.nombre_1, U.apellido_1
   FROM USUARIO U, CURSO C
   WHERE C.creador=U.id_usuario 
   AND C.nombre = @name;  
   
GO 