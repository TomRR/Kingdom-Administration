CREATE PROCEDURE [dbo].[spWeapon_Delete]
	@Id int
AS

begin
	
	SET nocount on;
	DELETE
	FROM dbo.[Weapon]
	WHERE id = @Id;

end
