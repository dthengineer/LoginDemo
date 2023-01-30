CREATE TABLE [dbo].[UserPassword] (
    [UserID]     INT NOT NULL,
    [QuestionID] INT NOT NULL,
    [Answer]     NVARCHAR (128)   NOT NULL,
    CONSTRAINT [PK_UserPassword] PRIMARY KEY CLUSTERED ([UserID], [QuestionID]), 
    CONSTRAINT [FK_UserPassword_ToUsers] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID]) ON DELETE CASCADE
);

