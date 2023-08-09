CREATE PROCEDURE [dbo].[sp_PostGetAll]
AS
begin
	select Id, Title, Body, UpVotes, UserId
	From dbo.[Post];
end
