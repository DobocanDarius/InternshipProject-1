CREATE PROCEDURE [dbo].[sp_PostGetAll]
AS
begin
	select Id, Title, Body, UpVotes, CreatedAt, UserId
	From dbo.[Post];
end
