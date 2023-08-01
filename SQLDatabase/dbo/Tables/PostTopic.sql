CREATE TABLE [dbo].[PostTopic]
(
	[PostId] INT NOT NULL , 
    [TopicId] INT NOT NULL, 
    PRIMARY KEY ([PostId], [TopicId]), 
    CONSTRAINT [FK_Post] FOREIGN KEY ([PostId]) REFERENCES [Post]([Id]), 
    CONSTRAINT [FK_Topic] FOREIGN KEY ([TopicId]) REFERENCES [Topic]([Id]) 
)
