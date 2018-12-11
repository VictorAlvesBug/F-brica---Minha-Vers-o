CREATE TABLE [dbo].[Aluno]
(
	[Rm] INT NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(255) NOT NULL, 
    [Senha] NVARCHAR(255) NOT NULL, 
    [Sexo] INT NOT NULL, 
    [Rg] CHAR(9) NOT NULL, 
    [Cpf] CHAR(11) NOT NULL, 
    [Endereco] NVARCHAR(255) NOT NULL
)
