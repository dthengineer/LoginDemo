CREATE TABLE [dbo].[Users] (
    [UserName]     NVARCHAR(128)        NOT NULL,
    [UserID]       INT IDENTITY(1, 1) NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserID])
);

