﻿CREATE TABLE [dbo].[Tribe]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [ExistSince] NVARCHAR(50) NULL, 
    [LeaderId] INT NULL
)
