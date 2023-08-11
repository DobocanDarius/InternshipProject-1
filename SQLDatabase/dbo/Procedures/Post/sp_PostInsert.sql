CREATE PROCEDURE [dbo].[sp_PostInsert]
		@Title nvarchar(MAX),
		@Body nvarchar(MAX),
		@UserId int,
		@UpVotes int,
		@CreatedAt DateTime,
		@TopicId int
AS
begin
	insert into dbo.[Post] (Title, Body, UserId, UpVotes, CreatedAt, TopicId)
	values (@Title, @Body, @UserId, @UpVotes, @CreatedAt, @TopicId);
end
