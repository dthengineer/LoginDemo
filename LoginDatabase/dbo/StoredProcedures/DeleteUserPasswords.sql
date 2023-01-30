CREATE PROCEDURE [dbo].[DeleteUserPasswords]
	@userID int = 0
AS
Begin
	Delete 
	From dbo.[UserPassword]
	where [UserID] = @userID;
End
