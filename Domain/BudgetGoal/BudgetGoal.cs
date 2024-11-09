using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Shared;

namespace Domain.BudgetGoal;
public class BudgetGoal : BaseEntity<Guid>
{
	public Guid UserId { get; init; }
    public Money DesiredAmount { get; init; }
	public Money CurrentAmount { get; init; }
}
