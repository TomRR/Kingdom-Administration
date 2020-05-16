CREATE PROCEDURE [dbo].[spWeapon_GetById]
	@Id int
AS

begin
	set nocount on;

	select [Id], [Typ], [MagicalValue], [CitizenId]
	from dbo.[Weapon]
	where Id = @Id;
end
