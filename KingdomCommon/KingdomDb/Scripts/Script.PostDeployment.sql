/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

go
    insert into dbo.Weapon([Typ], [MagicalValue], [CitizenId])
    values ('Axe', 12, 1),
           ('Sword', 15, 1),
           ('Axe', 17, 2),
           ('Wand', 45, 3),
           ('War Hammer', 15, 3)
go
    insert into dbo.Citizen([Name], [Age], [HairLength], [LeaderSince],[Tax], [TribeId])
    values ('Gimli', 140, null, 25, null, 1),
           ('Zwingli', 70, null, null, null, 1),
           ('Gumli', 163, null, null, null, 2),
           ('Elidyr', 318, 53.34, null, null, 3),
           ('Lefyr', 214, 84, 12, null, 3),
           ('Vulas', 96, 23, null, null, 3),
           ('Malon', 592, 145, 104, null, 4)

--go 
--    insert into dbo.Tribe([Name], [ExistSince], [LeaderId])
--    values ('Altobarden', '1247 ndk', 1 ),
--           ('ElbKnechte', '1023 ndk', null ),
--           ('Murkpeak', null, 5),
--           ('Montzieu', null, 7 )

