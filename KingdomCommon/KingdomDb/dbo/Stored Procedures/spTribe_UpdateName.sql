CREATE PROCEDURE [dbo].[spTribe_UpdateName]
	@Id int,
	@Name nvarchar(50)
AS

begin

	set nocount on;

	update dbo.[Tribe]
	set Name = @Name
	where Id = @Id;

end
