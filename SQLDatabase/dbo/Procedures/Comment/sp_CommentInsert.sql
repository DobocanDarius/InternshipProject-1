CREATE PROCEDURE [dbo].[sp_CommentInsert]
		@Text nvarchar(MAX),
		@UserId int,
		@PostId int,
		@UpVotes int,
		@CreatedAt datetime
AS
begin
	insert into dbo.[Comment] (Text, UserId, PostId, UpVotes,CreatedAt)
	values (@Text, @UserId, @PostId , @UpVotes, @CreatedAt);
end
