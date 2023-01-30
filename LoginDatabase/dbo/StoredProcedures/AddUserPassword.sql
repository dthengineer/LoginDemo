CREATE PROCEDURE [dbo].[AddUserPassword]
	@userID int = 0,
	@questionID int = 0,
	@answer nvarchar(128)
AS
Begin
	Insert Into dbo.[UserPassword] (UserID, QuestionID, Answer)
	Values (@userID, @questionID, @answer);
End	
RETURN 0
