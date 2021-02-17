CREATE DATABASE testeproway;
USE testeproway;

CREATE TABLE Alunos(
Id_Aluno INTEGER IDENTITY(1,1) PRIMARY KEY,
Nome VARCHAR(50),
Sobrenome VARCHAR(100)
);

CREATE TABLE Salas(
Id_Sala INTEGER IDENTITY(1,1) PRIMARY KEY,
Nome VARCHAR(50),
Capacidade INTEGER
);
CREATE TABLE EtapaSala(
Etapa BIT,
Id_Aluno INTEGER,
Id_Sala INTEGER,
FOREIGN KEY (Id_Aluno) REFERENCES Alunos(Id_Aluno),
FOREIGN KEY (Id_Sala) REFERENCES Salas(Id_Sala)
);
CREATE TABLE Cafeteria(
Id_Cafeteria INTEGER IDENTITY(1,1) PRIMARY KEY,
Nome VARCHAR(50)
);
CREATE TABLE TurnoCafeteria (
Turno BIT,
Id_Aluno INTEGER,
Id_Cafeteria INTEGER,
FOREIGN KEY (Id_Aluno) REFERENCES Alunos(Id_Aluno),
FOREIGN KEY (Id_Cafeteria) REFERENCES Cafeteria(Id_Cafeteria)
);

