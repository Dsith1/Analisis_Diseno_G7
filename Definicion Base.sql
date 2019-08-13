Create Table CURSO(

	id_curso int primary key,
	nombre varchar(20) not null
	
);

Create Table Usuario(

	id_usuario int primary key,
	nombre_1 varchar(20) not null,
	nombre_2 varchar(20),
	apellido_1 varchar(20),
	apellido_2 varchar(20) not null,
	edad int not null,
	correo	varchar(20) not null

);

Create Table Asignacion(

	id_curso int,
	id_usuario int,
	primary key(id_curso,id_usuario)

);