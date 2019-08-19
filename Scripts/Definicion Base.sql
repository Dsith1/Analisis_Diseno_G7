Create DATABASE Sistema_estudios;
Use Sistema_estudios;


Create Table USUARIO(

	id_usuario int identity primary key,
	nick varchar(20) not null unique,
	contra varchar(20) not null,
	nombre_1 varchar(20) not null,
	nombre_2 varchar(20),
	apellido_1 varchar(20),
	apellido_2 varchar(20) not null,
	edad int not null,
	correo	varchar(20) not null

);

Create Table CURSO(

	id_curso int identity primary key,
	nombre varchar(20) not null,
	creador int not null,
	foreign key(creador) references USUARIO(id_usuario)
	
);


Create Table ASIGNACION(

	id_curso int,
	id_usuario int,
	primary key(id_curso,id_usuario),
	foreign key(id_curso) references CURSO(id_curso),
	foreign key(id_usuario) references USUARIO(id_usuario)
);

Create Table TAREA(
	
	id_tarea int identity primary key,
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
	foreign key(estudiante) references USUARIO(id_usuario)

)

Create Table EXAMEN(
	
	id_examen int identity primary key,
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
	primary key(estudiante,examen),
	foreign key(examen) references EXAMEN(id_examen),
	foreign key(estudiante) references USUARIO(id_usuario)

)

Create Table ACTIVIDAD(

	id_Actividad int identity primary key,
	tipo int not null default 1,--1 Tarea 2 EXAMEN
	id_evento int not null,--aqui irá el codigo del examen o de la tarea se buscara dependiendo del tipo
	curso int not null,
	foreign key(curso) references CURSO(id_curso)
);

Create Table PUBLICACION(

	id_publicacon int identity primary key,
	info varchar(max),
	curso int not null,
	foreign key(curso) references CURSO(id_curso)
)

Create Table COMENTARIO(

	id_Comentario int identity primary key,
	info varchar(max),
	curso int not null,
	estudiante int,
	foreign key(curso) references CURSO(id_curso),
	foreign key(estudiante) references USUARIO(id_usuario)

)

create Table RES_EXAMEN(
	examen int,
	estudiante int,
	respuestas varchar(max),
	foreign key(examen) references CURSO(id_examen),
	foreign key(estudiante) references EXAMEN(id_usuario)
);
