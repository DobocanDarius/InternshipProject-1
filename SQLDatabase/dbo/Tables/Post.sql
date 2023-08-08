CREATE TABLE [dbo].[Post]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(MAX) NULL, 
    [Body] NVARCHAR(MAX) NULL, 
    [UpVotes] INT NULL, 
    [CreatedAt] DATETIME NULL, 
    [UserId] INT NULL, 
    [TopicId] INT NULL,
    CONSTRAINT [FK_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]) 
)
