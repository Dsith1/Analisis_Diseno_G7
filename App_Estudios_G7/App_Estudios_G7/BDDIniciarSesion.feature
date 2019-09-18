Feature: BDDIniciarSesion
	Este BDD nos indicará como iniciar sesion
	dentro de nuestra plataforma

@mytag
Scenario: Iniciar Sesion
	Given La conexion a la base de datos Sistema_estudios
	And Hago las verificaciones de los diferentes roles
	When estos datos son correctos
	Then Se redirije a la pagina que le corresponda.
