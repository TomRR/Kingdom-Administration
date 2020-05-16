CREATE PROCEDURE [dbo].[spCitizen_Delete]
	@Id int 
AS
begin

	set nocount on;

	delete
	from dbo.[Citizen]
	where id = @Id;
end
