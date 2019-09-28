Feature: Curso, será el encargado de poder llevar el control del panel de curso
	Se podra crear listar los cursos, crear cursos, se podra ver tambien
	el detalle de los cursos. Cuando se crear un curso se podrá ver
	el contenido del curso. Cuando sea necesario se dejarán examenes,
	creacion de tareas y actividades

@mytag
Scenario: Curso
	Given La conexion a la base de datos Sistema_estudios
	And Hago las verificaciones de los diferentes roles
	When estos datos son correctos
	Then Creara Cursos, Contenido de cursos, detalles de cursos.
	Then Creara examenes, actividades y tareas
	Then Se podrá modificar, eliminar cursos.