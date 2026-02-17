using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Budget
{
    public int Id { get; set; }

    public int IdTime { get; set; }

    public int Income { get; set; }

    public int Available { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<BudgetExecution> BudgetExecutions { get; set; } = new List<BudgetExecution>();

    public virtual Time IdTimeNavigation { get; set; } = null!;
}
