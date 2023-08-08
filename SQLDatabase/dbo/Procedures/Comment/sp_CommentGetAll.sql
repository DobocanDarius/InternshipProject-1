CREATE PROCEDURE [dbo].[sp_CommentGetAll]
AS
begin
	select Id, Text, UpVotes, UserId, PostId, CreatedAt
	From dbo.[Comment];
end
