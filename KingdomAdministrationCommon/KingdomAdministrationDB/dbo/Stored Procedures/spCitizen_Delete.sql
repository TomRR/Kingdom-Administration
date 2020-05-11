CREATE PROCEDURE [dbo].[spCitizen_Delete]
	@Id int
AS

begin
	
	SET nocount on;
	DELETE
	FROM dbo.[Citizen]
	WHERE id = @Id;

end
