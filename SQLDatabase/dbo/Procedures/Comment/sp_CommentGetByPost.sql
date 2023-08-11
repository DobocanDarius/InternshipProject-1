CREATE PROCEDURE [dbo].[sp_CommentGetByPost]
	@Id int
AS
begin
	select Text, UpVotes
	from dbo.[Comment]
	where PostId = @Id;
end
