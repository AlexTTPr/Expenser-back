using FluentValidation;

namespace Application.Transactions.DeleteTransaction;
public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
{
	public DeleteTransactionCommandValidator()
	{
		// Add validation rules here
	}
}
