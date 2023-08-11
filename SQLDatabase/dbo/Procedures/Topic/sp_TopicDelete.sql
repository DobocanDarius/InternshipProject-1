CREATE PROCEDURE [dbo].[sp_TopicDelete]
	@Id int
AS
begin
	delete
	from dbo.[Topic]
	where Id = @Id;
end

