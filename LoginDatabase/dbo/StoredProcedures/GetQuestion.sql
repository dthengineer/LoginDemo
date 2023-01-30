CREATE PROCEDURE [dbo].[GetQuestion]
	@questionID int = 0
AS
begin
	SELECT [Question], [QuestionID] 
	From dbo.[Questions]
	Where [QuestionID] = @questionID;
end
