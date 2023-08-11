CREATE PROCEDURE [dbo].[sp_UserGetAll]
AS
begin
	select Id, UserName, Password
	From dbo.[User];
end
