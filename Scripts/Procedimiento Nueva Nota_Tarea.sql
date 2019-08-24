
CREATE PROCEDURE INSERTAR_NOTA_TAREA
    @estudiante int,
	@tarea int
AS   

   SET NOCOUNT ON;  
   INSERT INTO NOTA_TAREA values(@estudiante,@tarea,0);
   
GO 
