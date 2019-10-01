Feature: BDDIniciarSesion
	Este BDD nos indicará como iniciar sesion
	dentro de nuestra plataforma

@mytag
Scenario: Iniciar Sesion
	Given La conexion a la base de datos Sistema_estudios
	And Hago las verificaciones de los diferentes roles
	When estos datos son correctos
	Then Se redirije a la pagina que le corresponda.


@loginUsuarioCorrecto
Scenario: Login_con_datos_correctos
	Given I have entered an user 'admin'
	And I have also entered a password 'admin'
	And I have also enntered a rol 'Administrador'
	When I press login
	Then the result should be home view

@loginUsuarioIncorrecto
Scenario: Login_usuario_incorrecto
	Given I have entered an incorrect user 'admin'
	And I have also entered a password 'admin'
	And I have also entered a rol 'Administrador'
	When I press login
	Then the result should be Error Message

@loginPasswordIncorrecto
Scenario: Login_password_incorrecto
	Given I have entered an correct user 'admin'
	And I have also entered an incorrect password 'admin'
	And I have also entered a rol 'Administrador'
	When I press login
	Then the result should be Error Message
