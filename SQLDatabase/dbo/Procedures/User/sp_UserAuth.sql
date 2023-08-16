CREATE PROCEDURE [dbo].[sp_UserAuth]
	@UserName nvarchar(MAX),
	@Password nvarchar(50)
AS
begin
	select Id, UserName, Password
	from dbo.[User]
	where UserName = @UserName and  Password = @Password
end
