CREATE PROCEDURE [dbo].[spTribe_All]

AS
begin
	SET nocount on;
	SELECT [Id], [TribeName], [ExistSince]
	FROM dbo.Tribe;

end
