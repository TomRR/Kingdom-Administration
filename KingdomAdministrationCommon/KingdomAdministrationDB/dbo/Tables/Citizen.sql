CREATE TABLE [dbo].[Citizen]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CitizenName] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [HairLength] DECIMAL NOT NULL, 
    [Height] DECIMAL NOT NULL, 
    [LeaderSince] INT NOT NULL, 
    [Tax] DECIMAL NULL, 
    [TribeId] INT NULL
)
