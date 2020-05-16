CREATE PROCEDURE [dbo].[spTribe_Delete]
	@Id int 
AS
begin

	set nocount on;

	delete
	from dbo.[Tribe]
	where id = @Id;
end
