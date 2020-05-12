CREATE TABLE [dbo].[Citizen]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NULL, 
    [Age] INT NULL, 
    [HairLength] DECIMAL NULL, 
    [LeaderSince] INT NULL, 
    [Tax] MONEY NULL, 
    [TribeId] INT NULL, 
)
