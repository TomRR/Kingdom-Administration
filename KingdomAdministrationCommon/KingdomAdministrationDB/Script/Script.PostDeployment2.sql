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
if not exists (select * from dbo.Tribe)
begin
    insert into dbo.Tribe([TribeName], [ExistSince], [LeaderID])
    values ('Altobarden', '1247 ndk', 1),
           ('Elbknechte', '1023 ndk', null),
           ('Murkpeak', null, 5),
           ('Montzien', null, 7)
end
