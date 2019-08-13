Create DATABASE Sistema_estudios 

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
	Enunciado varchar (20) not null,
	Entrega datetime not null,
	curso int not null,	
	foreign key(curso) references CURSO(id_curso)
	
);

Create Table NOTA_TAREA(
	
	estudiante int,
	tarea int,
	nota int not null default 0,
	primary key(estudiante,tarea),
	foreign key(tarea) references TAREA(id_tarea),
	foreign key(estudiante) references USUARIO(estudiante)

)

Create Table EXAMEN(
	
	id_examen int primary key,
	--un varchar enorme en donde se separan las preguntas por medio de 2 puntos y comas ;;
	preguntas varchar(max),
	Fecha datetime not null,
	minutos int not null,
	curso int not null,	
	foreign key(curso) references CURSO(id_curso)
	
);

Create Table NOTA_EXAMEN(
	
	estudiante int,
	examen int,
	nota int not null default 0,
	primary key(estudiante,tarea),
	foreign key(examen) references EXAMEN(id_examen),
	foreign key(estudiante) references USUARIO(estudiante)

)