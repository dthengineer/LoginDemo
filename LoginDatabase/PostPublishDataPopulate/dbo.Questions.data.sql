if not exists (select * from Questions where QuestionID = 1)
Begin
SET IDENTITY_INSERT [dbo].[Questions] ON
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'What was the make of your first car?', 1)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'What is your favorite album?', 2)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'Where did you meet your spouse?', 3)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'Who is your favorite actor / actress?', 4)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'What high school did you attend?', 5)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'What is your favorite meal?', 6)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'What was your favorite toy as a child?', 7)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'What is the name of your favorite pet?', 8)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'What is your mother''s maiden name?', 9)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'What was the mascot of your high school?', 10)
INSERT INTO [dbo].[Questions] ([Question], [QuestionID]) VALUES (N'In what city were you born?', 11)
SET IDENTITY_INSERT [dbo].[Questions] OFF
End

if not exists (select * from Users where UserName = 'DemoUser')
Begin
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserName], [UserID]) VALUES (N'DemoUser', 1)
INSERT INTO [dbo].[Users] ([UserName], [UserID]) VALUES (N'User2', 2)
INSERT INTO [dbo].[Users] ([UserName], [UserID]) VALUES (N'User3', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
End

if not exists (select * from UserPassword where UserID = 1)
Begin
INSERT INTO [dbo].[UserPassword] ([UserID], [QuestionID], [Answer]) VALUES (1, 1, N'First Car Answer')
INSERT INTO [dbo].[UserPassword] ([UserID], [QuestionID], [Answer]) VALUES (1, 3, N'Meet Spouse Answer')
INSERT INTO [dbo].[UserPassword] ([UserID], [QuestionID], [Answer]) VALUES (1, 10, N'Mascot Answer')
INSERT INTO [dbo].[UserPassword] ([UserID], [QuestionID], [Answer]) VALUES (2, 1, N'u2car')
INSERT INTO [dbo].[UserPassword] ([UserID], [QuestionID], [Answer]) VALUES (2, 3, N'u2spouse')
INSERT INTO [dbo].[UserPassword] ([UserID], [QuestionID], [Answer]) VALUES (2, 4, N'u2actor')
INSERT INTO [dbo].[UserPassword] ([UserID], [QuestionID], [Answer]) VALUES (2, 5, N'u2highschool')
INSERT INTO [dbo].[UserPassword] ([UserID], [QuestionID], [Answer]) VALUES (2, 6, N'u2meal')
INSERT INTO [dbo].[UserPassword] ([UserID], [QuestionID], [Answer]) VALUES (2, 11, N'u2city')
End
