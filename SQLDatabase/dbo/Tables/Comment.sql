CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Text] NVARCHAR(MAX) NULL, 
    [UserId] INT NOT NULL, 
    [PostId] INT NOT NULL, 
    [UpVotes] INT NULL, 
    [CreatedAt] DATETIME NULL, 
    CONSTRAINT [FK_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post]([Id])
)
