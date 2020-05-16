CREATE PROCEDURE [dbo].[spCitizen_Insert]
	@Name nvarchar(50),
	@Age int,
	@HairLength decimal(18,0),
	@LeaderSince int,
	@Tax money,
	@TribeId int,
	@Id int output


AS
begin
	
	set nocount on;

	insert into dbo.[Citizen]([Name], [Age], [HairLength], [LeaderSince], [Tax], [TribeId])
	values (@Name, @Age, @HairLength, @LeaderSince, @Tax, @TribeId)

	set @Id = SCOPE_IDENTITY();

end
