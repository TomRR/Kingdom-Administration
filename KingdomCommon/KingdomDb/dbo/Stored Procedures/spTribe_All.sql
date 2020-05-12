CREATE PROCEDURE [dbo].[spTribe_All]
AS

begin
	SET nocount on;
	select [Id], [Name], [ExistSince], [LeaderId]
	from dbo.[Tribe]
end
