-- <Migration ID="dad45d4f-580f-4676-bd23-a23cdbc8696c" />
GO

PRINT N'Creating [dbo].[Organization]'
GO
CREATE TABLE [dbo].[Organization]
(
[Id] [uniqueidentifier] NOT NULL,
[Code] [nvarchar] (50) NOT NULL,
[Name] [nvarchar] (50) NOT NULL,
[ParentId] [uniqueidentifier] NULL
)
GO
PRINT N'Creating primary key [PK_Organization] on [dbo].[Organization]'
GO
ALTER TABLE [dbo].[Organization] ADD CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Organization_Position]'
GO
CREATE TABLE [dbo].[Organization_Position]
(
[Id] [uniqueidentifier] NOT NULL,
[OrganizationId] [uniqueidentifier] NOT NULL,
[PositionId] [uniqueidentifier] NOT NULL
)
GO
PRINT N'Creating primary key [PK_Organization_Position] on [dbo].[Organization_Position]'
GO
ALTER TABLE [dbo].[Organization_Position] ADD CONSTRAINT [PK_Organization_Position] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Position]'
GO
CREATE TABLE [dbo].[Position]
(
[Id] [uniqueidentifier] NOT NULL,
[Code] [nvarchar] (50) NOT NULL,
[Name] [nvarchar] (50) NOT NULL
)
GO
PRINT N'Creating primary key [PK_Position] on [dbo].[Position]'
GO
ALTER TABLE [dbo].[Position] ADD CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Position_User]'
GO
CREATE TABLE [dbo].[Position_User]
(
[Id] [uniqueidentifier] NOT NULL,
[UserId] [uniqueidentifier] NOT NULL,
[PositionId] [uniqueidentifier] NOT NULL
)
GO
PRINT N'Creating primary key [PK_Position_User] on [dbo].[Position_User]'
GO
ALTER TABLE [dbo].[Position_User] ADD CONSTRAINT [PK_Position_User] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[User]'
GO
CREATE TABLE [dbo].[User]
(
[Id] [uniqueidentifier] NOT NULL,
[Username] [nvarchar] (500) NOT NULL,
[Password] [nvarchar] (500) NOT NULL
)
GO
PRINT N'Creating primary key [PK_User] on [dbo].[User]'
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Organization_Position]'
GO
ALTER TABLE [dbo].[Organization_Position] ADD CONSTRAINT [FK_Organization_Position_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[Organization_Position] ADD CONSTRAINT [FK_Organization_Position_Position] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Position] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Position_User]'
GO
ALTER TABLE [dbo].[Position_User] ADD CONSTRAINT [FK_Position_User_Position] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Position_User] ADD CONSTRAINT [FK_Position_User_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
