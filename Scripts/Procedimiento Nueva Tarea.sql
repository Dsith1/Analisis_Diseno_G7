CREATE PROCEDURE INSERTAR_TAREA
    @enunciado nvarchar(300),
	@entrega datetime,
	@curso int,
	@ponderacion decimal(5,2)
AS   

   SET NOCOUNT ON;  
   INSERT INTO TAREA(Enunciado,Entrega,curso,Ponderacion) 
   values(@enunciado,@entrega,@curso,@ponderacion);
   
GO 