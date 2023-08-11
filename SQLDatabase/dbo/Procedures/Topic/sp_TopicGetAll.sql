CREATE PROCEDURE [dbo].[sp_TopicGetAll]
	AS
begin
	select Id, Text
	From dbo.[Topic];
end
