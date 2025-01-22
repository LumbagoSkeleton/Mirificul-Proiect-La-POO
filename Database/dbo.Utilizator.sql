CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nume] NVARCHAR(20) NOT NULL , 
    [Prenume] NVARCHAR(20) NOT NULL , 
    [Varsta] INT NOT NULL DEFAULT 1, 
    [Adresa de email] NVARCHAR(20) NOT NULL , 
    [Parola] NVARCHAR(20) NOT NULL, 
    [Rol] NVARCHAR(20) NULL 
)
