CREATE TABLE [dbo].[Weapon]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Typ] NVARCHAR(50) NULL, 
    [MagicalValue] INT NULL, 
    [CitizenId] INT NULL
)
