create database ControleDeAlunos
go

use ControleDeAlunos
go

Create Table Aluno(
AlunoId int identity not null,
Nome varchar(20) not null,
Matricula int not null,
TurmaId int null
)
go


Create Table Turma(
TurmaID int identity not null,
Descricao varchar(20) not null
)

Alter Table Turma
Add Constraint PK_Turma primary key(TurmaId)
go

Alter Table Aluno
Add Constraint PK_Aluno primary key(AlunoId)
go

Alter Table Aluno
Add Constraint FK_ALUNO_Turma Foreign Key(TurmaId)
References Turma (TurmaId)
go

Create Table Usuario(
UsuarioId int identity not null,
Nome varchar(20) not null,
NomeLogin varchar(20) not null,
Email varchar(50) not null,
Password varchar(255) not null,
)
go

Alter Table Usuario
Add Constraint PK_Usuario primary key(UsuarioId)
go

insert into Usuario(Nome, NomeLogin, Email, Password) values ('Leandro','admin','lucasDo@gmail.com', 'admin123')
insert into Turma(Descricao) values ('Inglês básico')
insert into Turma(Descricao) values ('Inglês intermediário')
insert into Turma(Descricao) values ('Inglês avançado')