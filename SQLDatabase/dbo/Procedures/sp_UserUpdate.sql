CREATE PROCEDURE [dbo].[sp_UserUpdate]
		@UserName nvarchar(MAX),
		@Password nvarchar(50),
		@Id int
AS
begin
	update dbo.[User] 
	set UserName = @UserName, Password = @Password
	where Id = @Id;
end
