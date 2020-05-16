CREATE PROCEDURE [dbo].[spWeapon_Insert]
	@Typ nvarchar(50),
	@MagicalValue int,
	@CitizenId int,
	@Id int output

AS
begin
	
	set nocount on;

	insert into dbo.[Weapon](Typ, MagicalValue, CitizenId)
	values (@Typ, @MagicalValue, @CitizenId);

	set @Id = SCOPE_IDENTITY();

end
