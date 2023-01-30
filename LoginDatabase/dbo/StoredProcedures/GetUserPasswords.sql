CREATE PROCEDURE [dbo].[GetUserPasswords]
	@userID int = 0
AS
Begin
	SELECT [UserID], [QuestionID], [Answer]
	From dbo.UserPassword
	Where [UserID] = @userID;
End
