CREATE TABLE [dbo].[Marca]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [DataCriacao] DATE NOT NULL, 
    [Cnpj] CHAR(18) NOT NULL
)
