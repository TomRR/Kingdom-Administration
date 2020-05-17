CREATE PROCEDURE [dbo].[spCitizen_UpdateName]
	@Id int,
	@Name int
AS

begin

	set nocount on;

	update dbo.[Citizen]
	set [Name] = @Name
	where Id = @Id;

end
