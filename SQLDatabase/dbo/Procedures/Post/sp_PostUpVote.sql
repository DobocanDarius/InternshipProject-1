CREATE PROCEDURE [dbo].[sp_PostUpVote]
		@Id int
AS
begin
	update dbo.[Post] 
	set UpVotes += 1
	where Id = @Id;
end
