CREATE PROCEDURE [dbo].[sp_UserGet]
	@Id int
AS
begin
	select Id, UserName, Password
	from dbo.[User]
	where Id = @Id;
end
