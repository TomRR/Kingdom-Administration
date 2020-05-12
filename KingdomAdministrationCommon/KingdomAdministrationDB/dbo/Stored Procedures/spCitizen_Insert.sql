CREATE PROCEDURE [dbo].[spCitizen_Insert]
	@CitizenName nvarchar(50),
	@Age int,
	@HairLength decimal(18,0),
	@Height decimal(18,0),
	@LeaderSince int,
	@Tax decimal(18,0),
	@TribeId int,
	@Id int output

AS

begin
	SET nocount on;

	INSERT INTO dbo.[Citizen](CitizenName, Age, HairLength, LeaderSince, Tax, TribeId)
	VALUES(@CitizenName, @Age, @HairLength, @Height, @LeaderSince, @Tax, @TribeId);

	SET @Id = SCOPE_IDENTITY();
end