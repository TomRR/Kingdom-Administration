CREATE PROCEDURE [dbo].[spTribe_GetById]
	@Id int
AS

begin
	set nocount on;

	select [Id], [Name], [ExistSince], [LeaderId]
	from dbo.[Tribe]
	where Id = @Id;
end
