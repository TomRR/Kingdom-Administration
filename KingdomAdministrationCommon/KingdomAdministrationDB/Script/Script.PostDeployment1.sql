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
if not exists (select * from dbo.Citizen)
begin
    insert into dbo.Food([Id], [CitizenName], [Age], [HairLength], [Height], [LeaderSince], [Tax], [TribeId])
    values ('Cheeseburger Meal', 'A cheeseburger, fries and a drink', 7.95),
           ('Chili Dog Meal', 'Two Chili Dogs, fries and a drink', 5.95),
           ('Vegan Meal', 'A large Tofu Burger, fries and a drink', 3.95)
end