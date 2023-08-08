CREATE PROCEDURE [dbo].[sp_PostUpdate]
		@Title nvarchar(MAX),
		@Body nvarchar(Max),
		@Id int
AS
begin
	update dbo.[Post] 
	set Title = @Title, Body = @Body
	where Id = @Id;
end
