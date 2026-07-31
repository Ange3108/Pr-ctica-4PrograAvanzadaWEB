Create database Practica4

use Practica4
GO

Create table Estudiante(
	Id int primary key identity(1,1),
	Nombre varchar (50) not null,
	Apellido varchar (50) not null,
	Edad int not null,
	Grado varchar (30) not null,
	Genero varchar(30)not null
)
GO

insert into Estudiante(Nombre,Apellido,Edad,Grado,Genero)
values ('Juana','Arcos',15,'Décimo','F')

insert into Estudiante(Nombre,Apellido,Edad,Grado,Genero)
values ('Francisco','Ruíz',8,'segundo','M')



