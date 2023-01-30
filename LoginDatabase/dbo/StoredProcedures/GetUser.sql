CREATE PROCEDURE [dbo].[GetUser]
	@userName nvarchar(128)
AS
Begin
	SELECT [UserName], [UserID]
	FROM dbo.[Users]
	Where UserName = @userName;
End
