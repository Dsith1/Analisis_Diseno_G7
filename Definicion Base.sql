Create Table USUARIO(

	id_usuario int primary key,
	nombre_1 varchar(20) not null,
	nombre_2 varchar(20),
	apellido_1 varchar(20),
	apellido_2 varchar(20) not null,
	edad int not null,
	correo	varchar(20) not null

);

Create Table CURSO(

	id_curso int primary key,
	nombre varchar(20) not null,
	creador int not null,
	foreign key(creador) references USUARIO(id_usuario);
	
);


Create Table ASIGNACION(

	id_curso int,
	id_usuario int,
	primary key(id_curso,id_usuario),
	foreign key(id_curso) references CURSO(id_curso),
	foreign key(id_usuario) references USUARIO(id_usuario)
);

Create Table TAREA(
	
	id_tarea int primary key,
	--campos para preguntas o algo asi
	Entrega datetime not null,
	curso int not null,	
	foreign key(curso) references CURSO(id_curso)
	
);

Create Table Nota_Tarea(
	
	estudiante int,
	tarea int,
	nota int not null default 0,
	primary key(estudiante,tarea),
	foreign key(tarea) references TAREA(id_tarea),
	foreign key(estudiante) references USUARIO(estudiante)

)