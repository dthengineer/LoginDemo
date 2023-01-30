CREATE PROCEDURE [dbo].[GetQuestions]
AS
Begin
	SELECT [Question], [QuestionID] 
	From dbo.[Questions];
End
