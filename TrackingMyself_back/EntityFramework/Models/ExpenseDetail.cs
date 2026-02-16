using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class ExpenseDetail
{
    public int Id { get; set; }

    public int IdExpenseType { get; set; }

    public int IdBudget { get; set; }

    public DateOnly ExpenseDate { get; set; }

    public DateTime ExpenseInserted { get; set; }

    public int Ammount { get; set; }

    public string Description { get; set; } = null!;

    public virtual ExpenseType IdExpenseTypeNavigation { get; set; } = null!;
}
