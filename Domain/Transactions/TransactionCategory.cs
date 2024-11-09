using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Transactions;
public struct TransactionCategory
{
	public string Name { get; init; }
	public TransactionType TransactionType { get; init; }
	//TODO: add corresponding image
}
