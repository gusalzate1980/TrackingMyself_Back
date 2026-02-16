using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class BudgetExecution
{
    public int Id { get; set; }

    public int IdBudget { get; set; }

    public int IdExpense { get; set; }

    public int BudgetedAmount { get; set; }

    public int ActualAmount { get; set; }

    public virtual Budget IdBudgetNavigation { get; set; } = null!;
}
