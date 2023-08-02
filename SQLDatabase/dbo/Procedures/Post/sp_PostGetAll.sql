CREATE PROCEDURE [dbo].[sp_PostGetAll]
AS
begin
	select Title, Body, UpVotes, UserId
	From dbo.[Post];
end
