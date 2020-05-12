CREATE PROCEDURE [dbo].[spWeapon_Delete]
	@Id int 
AS
begin

	set nocount on;

	delete
	from dbo.[Weapon]
	where id = @Id;
end
