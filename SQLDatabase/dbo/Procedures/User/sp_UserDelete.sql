CREATE PROCEDURE [dbo].[sp_UserDelete]
	@Id int
AS
begin
	delete
	from dbo.[User]
	where Id = @Id;
end
