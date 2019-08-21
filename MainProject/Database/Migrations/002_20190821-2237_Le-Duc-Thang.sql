-- <Migration ID="feda0af2-fa86-4454-9f15-64e6018ed4a3" />
GO

PRINT N'Dropping foreign keys from [dbo].[Organization_Position]'
GO
ALTER TABLE [dbo].[Organization_Position] DROP CONSTRAINT [FK_Organization_Position_Organization]
GO
ALTER TABLE [dbo].[Organization_Position] DROP CONSTRAINT [FK_Organization_Position_Position]
GO
PRINT N'Dropping foreign keys from [dbo].[Position_User]'
GO
ALTER TABLE [dbo].[Position_User] DROP CONSTRAINT [FK_Position_User_Position]
GO
PRINT N'Dropping constraints from [dbo].[Organization_Position]'
GO
ALTER TABLE [dbo].[Organization_Position] DROP CONSTRAINT [PK_Organization_Position]
GO
PRINT N'Dropping constraints from [dbo].[Position]'
GO
ALTER TABLE [dbo].[Position] DROP CONSTRAINT [PK_Position]
GO
PRINT N'Dropping [dbo].[Organization_Position]'
GO
DROP TABLE [dbo].[Organization_Position]
GO
PRINT N'Rebuilding [dbo].[Position]'
GO
CREATE TABLE [dbo].[RG_Recovery_1_Position]
(
[Id] [uniqueidentifier] NOT NULL,
[Code] [nvarchar] (50) NOT NULL,
[Name] [nvarchar] (50) NOT NULL,
[OrganizationId] [uniqueidentifier] NOT NULL
)
GO
INSERT INTO [dbo].[RG_Recovery_1_Position]([Id], [Code], [Name]) SELECT [Id], [Code], [Name] FROM [dbo].[Position]
GO
DROP TABLE [dbo].[Position]
GO
EXEC sp_rename N'[dbo].[RG_Recovery_1_Position]', N'Position', N'OBJECT'
GO
PRINT N'Creating primary key [PK_Position] on [dbo].[Position]'
GO
ALTER TABLE [dbo].[Position] ADD CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Position]'
GO
ALTER TABLE [dbo].[Position] ADD CONSTRAINT [FK_Position_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Position_User]'
GO
ALTER TABLE [dbo].[Position_User] ADD CONSTRAINT [FK_Position_User_Position] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Position] ([Id])
GO
