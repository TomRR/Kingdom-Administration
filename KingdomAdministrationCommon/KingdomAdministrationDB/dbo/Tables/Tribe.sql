﻿CREATE TABLE [dbo].[Tribe]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TribeName] NVARCHAR(50) NULL, 
    [ExistSince] NVARCHAR(50) NOT NULL, 
    [LeaderID] INT NULL
)