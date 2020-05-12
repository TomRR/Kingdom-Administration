CREATE PROCEDURE [dbo].[spWeapon_All]
AS

begin
	SET nocount on;
	select [Id], [Typ], [MagicalValue], [CitizenId]
	from dbo.[Weapon]
end
