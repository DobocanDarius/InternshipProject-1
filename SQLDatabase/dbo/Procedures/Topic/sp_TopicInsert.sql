CREATE PROCEDURE [dbo].[sp_TopicInsert]
		@Text nvarchar(50)
AS
begin
	insert into dbo.[Topic] (Text)
	values (@Text);
end
