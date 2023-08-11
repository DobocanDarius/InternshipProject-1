CREATE PROCEDURE [dbo].[sp_PostDelete]
	@Id int
AS
begin
	delete
	from dbo.[Post]
	where Id = @Id;
end
