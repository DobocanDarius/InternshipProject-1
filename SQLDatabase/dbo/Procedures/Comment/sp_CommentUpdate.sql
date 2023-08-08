CREATE PROCEDURE [dbo].[sp_CommentUpdate]
		@Text nvarchar(MAX),
		@Id int
AS
begin
	update dbo.[Comment] 
	set Text = @Text
	where Id = @Id;
end
