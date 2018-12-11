CREATE TABLE [dbo].[Carro]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MarcaId] INT NOT NULL,
    [ModeloId] INT NOT NULL, 
	[Placa] CHAR(8) NOT NULL,
    [Ano] INT NULL, 
    [Esportivo] BIT NULL, 
    [Combustivel] INT NULL, 
    [Descricao] VARCHAR(50) NULL, 
    [Renavam] BIGINT NOT NULL, 
    CONSTRAINT [FK_Carro_Documento] FOREIGN KEY ([Renavam]) REFERENCES [Documento]([Renavam]), 
    CONSTRAINT [FK_Carro_Marca] FOREIGN KEY ([MarcaId]) REFERENCES [Marca]([Id]), 
    CONSTRAINT [FK_Carro_Modelo] FOREIGN KEY ([ModeloId]) REFERENCES [Modelo]([Id])
)
