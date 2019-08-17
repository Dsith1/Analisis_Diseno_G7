CREATE PROCEDURE INSERTAR_CURSO
    @name nvarchar(20),
	@autor int
AS   

   SET NOCOUNT ON;  
   INSERT INTO CURSO values(@name,@autor);
   
GO 