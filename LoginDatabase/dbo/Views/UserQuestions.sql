CREATE VIEW [dbo].[UserQuestions]
	AS 
	SELECT [u].[UserName], [q].[Question], [up].[Answer]
	from dbo.Users u, dbo.Questions q
	left join dbo.UserPassword up on UserID = up.UserID
	where u.UserID = up.UserID and q.QuestionID = up.QuestionID
