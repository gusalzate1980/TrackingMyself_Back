CREATE TABLE [dbo].[Budget](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTime] [int] NOT NULL,
	[Income] [int] NOT NULL,
	[Available] [int] NOT NULL,
	[Decription] [varchar](50) NULL, 
    CONSTRAINT [PK_Budget] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Budget_Time] FOREIGN KEY ([IdTime]) REFERENCES [Time]([Id]))