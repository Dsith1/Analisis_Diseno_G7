CREATE PROCEDURE OBTENER_CURSOS
AS    
   SET NOCOUNT ON;  
   SELECT C.id_curso, C.nombre, U.nombre_1, U.apellido_1
   FROM USUARIO U, CURSO C
   WHERE C.creador=U.id_usuario;
   
GO