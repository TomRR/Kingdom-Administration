﻿CREATE TABLE [dbo].[Citizen]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CitizenName] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [HairLength] DECIMAL NULL,
    [LeaderSince] INT NULL, 
    [Tax] DECIMAL NULL, 
    [TribeId] INT NULL
)
