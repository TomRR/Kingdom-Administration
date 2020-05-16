CREATE PROCEDURE [dbo].[spCitizen_GetById]
	@Id int
AS

begin
	set nocount on;

	select [Id], [Name], [Age], [HairLength], [LeaderSince], [Tax], [TribeId]
	from dbo.[Citizen]
	where Id = @Id;
end
