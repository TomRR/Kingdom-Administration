CREATE TABLE [dbo].[Weapon]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Typ] NVARCHAR(50) NOT NULL, 
    [MagicalValue] INT NOT NULL, 
    [CitizenId] INT NOT NULL, 
)
