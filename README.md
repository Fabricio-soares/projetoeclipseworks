# projetoeclipseworks

#Dicionario de informações :

Nivel de prioridade (tarefa e projetos)
Baixo = 0
Medio = 1
Alto = 2

Status da tarefa ou Projeto 
Pendente = 0
Em Andamento = 1
Finalizado = 1
 

 # Script da bando de dados esta sendo anexado no e-mail e no git 
 CREATE DATABASE projetoeclipseworks;

USE projetoeclipseworks;

CREATE TABLE Tarefas (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nome NVARCHAR(255) NOT NULL,
    Nivel INT,
    Finalizada BIT,
    ProjetoId UNIQUEIDENTIFIER,
    UsuarioResponsavelId UNIQUEIDENTIFIER,
    DataConclusao DATETIME,
    CONSTRAINT FK_Tarefa_Projeto FOREIGN KEY (ProjetoId) REFERENCES Projetos(Id)
);

CREATE TABLE Projetos (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nome NVARCHAR(255) NOT NULL,
    Nivel INT,
    Status INT,
);

CREATE TABLE Comentarios (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Descricao NVARCHAR(MAX),
    IdTarefa UNIQUEIDENTIFIER,
    CONSTRAINT FK_Comentario_Tarefa FOREIGN KEY (IdTarefa) REFERENCES Tarefas(Id)
);

CREATE TABLE HistoricoAlteracoes (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    TarefaId UNIQUEIDENTIFIER,
    DataAlteracao DATETIME,
    Alteracao NVARCHAR(MAX),
    CONSTRAINT FK_Historico_Tarefa FOREIGN KEY (TarefaId) REFERENCES Tarefas(Id)
);


 
