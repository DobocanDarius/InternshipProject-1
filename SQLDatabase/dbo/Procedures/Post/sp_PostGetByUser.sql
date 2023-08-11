CREATE PROCEDURE [dbo].[sp_PostGetByUser]
	@Id int
AS
begin
	select Id, Title, Body, UpVotes
	from dbo.[Post]
	where UserId = @Id;
end
