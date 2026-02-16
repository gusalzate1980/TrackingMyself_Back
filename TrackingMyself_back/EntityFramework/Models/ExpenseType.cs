using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class ExpenseType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<ExpenseDetail> ExpenseDetails { get; set; } = new List<ExpenseDetail>();
}
