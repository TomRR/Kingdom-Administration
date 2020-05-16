CREATE PROCEDURE [dbo].[spTribe_Insert]
	@Name nvarchar(50),
	@ExistSince nvarchar(50),
	@LeaderId int,
	@Id int output

AS
begin
	
	set nocount on;

	insert into dbo.[Tribe]([Name], [ExistSince], [LeaderId])
	values (@Name, @ExistSince, @LeaderId);

	set @Id = SCOPE_IDENTITY();

end
