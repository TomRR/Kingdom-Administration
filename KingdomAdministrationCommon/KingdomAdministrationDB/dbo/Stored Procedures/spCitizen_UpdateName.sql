CREATE PROCEDURE [dbo].[spCitizen_UpdateName]
	@Id int,
	@CitizenName nvarchar(50)
AS

begin

	set nocount on;

	update dbo.Citizen
	set CitizenName = @CitizenName
	where Id = @Id;

end
