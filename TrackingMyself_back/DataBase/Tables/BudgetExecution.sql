CREATE TABLE [dbo].[BudgetExecution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBudget] [int] NOT NULL,
	[IdExpense] [int] NOT NULL,
	[BudgetedAmount] [int] NOT NULL,
	[ActualAmount] [int] NOT NULL, 
    CONSTRAINT [PK_BudgetExecution] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_BudgetExecution_Budget] FOREIGN KEY ([IdBudget]) REFERENCES [Budget]([Id]))