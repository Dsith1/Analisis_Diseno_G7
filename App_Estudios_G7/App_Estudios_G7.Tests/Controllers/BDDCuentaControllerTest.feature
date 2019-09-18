Feature: BDDCuentaControllerTest
	En la vista de login se ingresa
	el usuario y la contraseña del usuario que
	desea ingresar al sistema


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