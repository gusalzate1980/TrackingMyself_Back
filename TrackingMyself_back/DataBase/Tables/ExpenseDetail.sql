CREATE TABLE [dbo].[ExpenseDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdExpenseType] [int] NOT NULL,
	[IdBudget] [int] NOT NULL,
	[ExpenseDate] [date] NOT NULL,
	[ExpenseInserted] [datetime] NOT NULL,
	[Ammount] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL, 
    CONSTRAINT [PK_ExpenseDetail] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_ExpenseDetail_ExpenseType] FOREIGN KEY (IdExpenseType) REFERENCES [ExpenseType]([Id]))