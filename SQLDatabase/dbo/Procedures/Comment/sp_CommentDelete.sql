CREATE PROCEDURE [dbo].[sp_CommentDelete]
	@Id int
AS
begin
	delete
	from dbo.[Comment]
	where Id = @Id;
end
