CREATE PROCEDURE [dbo].[spCitizen_All]
AS

begin
	SET nocount on;
	select [Id], [Name], [Age], [HairLength], [LeaderSince], [Tax], [TribeId]
	from dbo.[Citizen]
end
