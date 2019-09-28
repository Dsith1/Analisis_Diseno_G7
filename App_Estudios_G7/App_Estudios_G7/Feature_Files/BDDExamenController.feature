Feature: BDDExamenController
	Conexion con la base de datos, creara examenes cuando inicie sesion
	se podra editar examenes eliminar examenes

@mytag
Scenario: Examen
	Given La conexion a la base de datos Sistema_estudios
	And Hago las verificaciones de los diferentes roles
	When verifico la fecha de los examenes
	Then Creara examenes
	When El examen existe
	Then Editara examenes
	Then Eliminara examenes
