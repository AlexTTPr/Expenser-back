using FluentValidation;

namespace Application.Transactions.UpdateTransaction;
public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
{
	public UpdateTransactionCommandValidator()
	{
		// Add validation rules here
	}
}
