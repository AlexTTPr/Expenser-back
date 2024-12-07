using Domain.Transactions;

using MediatR;

namespace Application.Transactions.DeleteTransaction;
public sealed class DeleteTransactionCommandHandler(ITransactionRepository transactionRepository) : IRequestHandler<DeleteTransactionCommand>
{

	public Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
	{
		return transactionRepository.RemoveAsync(request.Id);
	}
}