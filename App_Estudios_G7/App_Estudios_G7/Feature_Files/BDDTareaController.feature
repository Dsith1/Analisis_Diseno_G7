Feature: BDDTareaController
	Se listaran las tareas ya creadas
	Luego de esto se podran crear nuevas tareas y se publicaran


@mytag
Scenario: Tarea
	Given La conexion a la base de datos Sistema_estudios
	And Hago las verificaciones de los diferentes roles
	When listo la cantidad de tareas
	Then Creara nuevas tareas
	Then Se publican las tareas
