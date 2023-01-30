CREATE TABLE [dbo].[Questions] (
    [Question]    NVARCHAR (128)    NOT NULL,
    [QuestionID]  INT IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([QuestionID] ASC)
);

