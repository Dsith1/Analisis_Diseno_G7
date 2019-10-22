CREATE PROCEDURE BUSCAR_CURSO_INDIVIDUAL
    @curso int
AS   

   SET NOCOUNT ON;  
   SELECT *
   FROM CURSO
   WHERE id_curso=@curso;  
   
GO 