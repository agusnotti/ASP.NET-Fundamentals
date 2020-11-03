USE [db_agenda]
GO

INSERT INTO [dbo].[yes_no]([ID],[value]) VALUES (0,'No');
INSERT INTO [dbo].[yes_no]([ID],[value]) VALUES (1,'Si');

-- INSERT INTO [dbo].[area]([name]) VALUES ('Marketing');
-- INSERT INTO [dbo].[area]([name]) VALUES ('RRHH');
-- INSERT INTO [dbo].[area]([name]) VALUES ('Finanzas');
-- INSERT INTO [dbo].[area]([name]) VALUES ('Operaciones');

INSERT INTO [dbo].[country]([name]) VALUES ('Argentina');
INSERT INTO [dbo].[country]([name]) VALUES ('Brasil');
INSERT INTO [dbo].[country]([name]) VALUES ('Chile');
INSERT INTO [dbo].[country]([name]) VALUES ('Uruguay');
INSERT INTO [dbo].[country]([name]) VALUES ('Espa�a');
INSERT INTO [dbo].[country]([name]) VALUES ('Paraguay');

INSERT INTO [dbo].[user_agenda]([username], [password]) VALUES ('admin', '123456');

GO


