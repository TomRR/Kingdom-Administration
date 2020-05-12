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
if not exists (select * from dbo.Weapon)
begin
    insert into dbo.Weapon([Typ], [MagicalValue], [CitizenId])
    values ('Axe', 12, 1),
           ('Sword', 15, 1),
           ('Axe', 17, 2),
           ('Wand', 45, 3),
           ('War Hammer', 15, 3)
end