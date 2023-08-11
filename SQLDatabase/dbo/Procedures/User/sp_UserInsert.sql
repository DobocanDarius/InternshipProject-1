CREATE PROCEDURE [dbo].[sp_UserInsert]
		@UserName nvarchar(MAX),
		@Password nvarchar(50)
AS
begin
	insert into dbo.[User] (UserName, Password)
	values (@UserName, @Password);
end
