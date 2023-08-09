CREATE PROCEDURE [dbo].[sp_PostGetByTopic]
	@Id int
AS
begin
	select Id, Title, Body, UpVotes
	from dbo.[Post]
	where TopicId = @Id;
end
