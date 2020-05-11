CREATE PROCEDURE [dbo].[spWeapon_All]

AS

begin
	SET nocount on;
	SELECT [Id], [Typ], [MagicalValue]
	FROM dbo.Weapon;
end
