using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Application.Transactions.CreateTransaction;
public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
	//UNDONE: time time time time time time time
	public CreateTransactionCommandValidator()
	{
		RuleFor(c => c.TransactionDate)
			.LessThanOrEqualTo(c => DateTime.Now);
	}
}
