CREATE PROCEDURE [dbo].[spWeapon_UpdateMagicalValue]
	@Id int,
	@MagicalValue int
AS

begin

	set nocount on;

	update dbo.[Weapon]
	set MagicalValue = @MagicalValue
	where Id = @Id;

end
