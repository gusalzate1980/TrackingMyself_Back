using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Time
{
    public int Id { get; set; }

    public int Year { get; set; }

    public int Month { get; set; }

    public int TimeTense { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}
