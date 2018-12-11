-- ////////////////////////////////////////////////////////////////////////////////////////
-- /// OBS: EXECUTAR NESSA ORDEM PARA QUE NAO HAJA ERROS DE FOREIGN KEY ///////////////////
-- ////////////////////////////////////////////////////////////////////////////////////////
 
-- APAGA O BANCO DE DADOS
DROP DATABASE DBCarros_Teste;
 
-- CRIA O BANCO DE DADOS
CREATE DATABASE DBCarros_Teste;

-- USA O BANCO DE DADOS CRIADO
USE DBCarros_Teste;

-- DELETA TABELAS
DROP TABLE [dbo].[Marca]
DROP TABLE [dbo].[Modelo]
DROP TABLE [dbo].[Documento]
DROP TABLE [dbo].[Carro]

-- CRIA TABELA DE MARCAS
CREATE TABLE [dbo].[Marca] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (50) NOT NULL,
    [DataCriacao] DATE         NOT NULL,
    [Cnpj]        CHAR (18)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- CRIA TABELA DE MODELOS
CREATE TABLE [dbo].[Modelo] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Nome]    VARCHAR (50) NOT NULL,
    [MarcaId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Modelo_Marca] FOREIGN KEY ([MarcaId]) REFERENCES [dbo].[Marca] ([Id])
);

-- CRIA TABELA DE DOCUMENTOS
CREATE TABLE [dbo].[Documento] (
    [Renavam]		 BIGINT  NOT NULL,
    [Categoria]      INT  NOT NULL,
    [DataFabricacao] DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Renavam] ASC)
);

-- CRIA TABELA DE CARROS
CREATE TABLE [dbo].[Carro] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [MarcaId]     INT          NOT NULL,
    [Placa]       CHAR (8)     NOT NULL,
    [Ano]         INT          NULL,
    [Esportivo]   BIT          NULL,
    [Combustivel] INT          NULL,
    [Descricao]   VARCHAR (50) NULL,
    [Renavam]     BIGINT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Carro_Documento] FOREIGN KEY ([Renavam]) REFERENCES [dbo].[Documento] ([Renavam]),
    CONSTRAINT [FK_Carro_Marca] FOREIGN KEY ([MarcaId]) REFERENCES [dbo].[Marca] ([Id])
);


-- /// INSERTS PARA MARCAS ////////////////////////////////////////////////////////////////
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('BMW', '01/08/1999', '73.596.855/0001-09');
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('Ford', '02/08/1999', '63.914.288/0001-20');
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('Honda', '03/08/1999', '54.556.833/0001-62');
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('Toyota', '04/08/1999', '28.447.387/0001-48');
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('Hyundai', '05/08/1999', '86.323.209/0001-01');
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('Renault', '06/08/1999', '38.537.109/0001-35');
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('Jaguar', '07/08/1999', '56.025.472/0001-53');
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('Chevrolet', '08/08/1999', '53.560.183/0001-66');
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('Dodge', '09/08/1999', '77.770.186/0001-92');
INSERT INTO Marca (Nome, DataCriacao, Cnpj)
VALUES ('Ferrari', '10/08/1999', '79.367.855/0001-05');
 
 
-- /// INSERTS PARA MODELOS ///////////////////////////////////////////////////////////////
INSERT INTO Modelo (Nome, MarcaId) VALUES ('X1', 1);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('X3', 1);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('M4', 1);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('X6 M', 1);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Ka', 2);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Fiesta', 2);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Focus', 2);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Fusion', 2);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Fit', 3);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('CR-V', 3);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('City', 3);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Civic', 3);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Corolla', 4);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Hilux', 4);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Etios', 4);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Prius', 4);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('IX35', 5);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('HB20', 5);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Veloster', 5);
INSERT INTO Modelo (Nome, MarcaId) VALUES ('Azera', 5);
 
 
-- /// INSERTS PARA DOCUMENTOS E CARROS ///////////////////////////////////////////////////
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (75179665083, 1, '01/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (1, 2017, 'BMW-2017', 'True', 1, 'BMW Etanol', 75179665083);
 
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (90816211529, 3, '02/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (1, 2018, 'BMW-2018', 'False', 2, 'BMW Gasolina', 90816211529);
 
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (17232869639, 5, '03/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (1, 2019, 'BMW-2019', 'True', 3, 'BMW Gnv', 17232869639);
 
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (36457966611, 2, '04/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (2, 2016, 'FRD-2016', 'False', 4, 'Ford Diesel', 36457966611);
 
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (75328471366, 4, '05/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (2, 2017, 'FRD-2017', 'True', 5, 'Ford Flex', 75328471366);
 
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (53838484698, 1, '06/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (2, 2018, 'FRD-2018', 'False', 1, 'Ford Etanol', 53838484698);
 
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (53194748686, 3, '07/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (2, 2019, 'FRD-2019', 'True', 2, 'Ford Gasolina', 53194748686);
 
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (63339569156, 5, '08/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (3, 2017, 'HND-2017', 'False', 3, 'Honda Gnv', 63339569156);
 
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (42265849328, 2, '09/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (3, 2018, 'HND-2018', 'True', 4, 'Honda Diesel', 42265849328);
 
INSERT INTO Documento (Renavam, Categoria, DataFabricacao)
VALUES (21813030407, 4, '10/11/2019');
INSERT INTO Carro (MarcaId, Ano, Placa, Esportivo, Combustivel, Descricao, Renavam)
VALUES (3, 2019, 'HND-2019', 'False', 5, 'Honda Flex', 21813030407);