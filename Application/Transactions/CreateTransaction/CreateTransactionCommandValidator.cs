using FluentValidation;

namespace Application.Transactions.CreateTransaction;
public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
	public CreateTransactionCommandValidator()
	{
		RuleFor(e => e.Money.Amount).GreaterThanOrEqualTo(0);
	}
}
