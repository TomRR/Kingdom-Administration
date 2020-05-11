CREATE PROCEDURE [dbo].[spTribe_All]

AS
begin
	SET nocount on;
	SELECT [Id], [Name], [ExistSince], [LeaderID]
	FROM dbo.Tribe;

end
