CREATE TABLE [dbo].[Time](
	[Id] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Month] [int] NOT NULL, 
    [TimeTense] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Time] PRIMARY KEY ([Id]))