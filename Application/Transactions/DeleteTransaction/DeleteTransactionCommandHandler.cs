using Domain.Transactions;

using MediatR;

namespace Application.Transactions.DeleteTransaction;
internal sealed class DeleteTransactionCommandHandler(ITransactionRepository transactionRepository) : IRequestHandler<DeleteTransactionCommand, DeleteTransactionCommandResponse>
{
	private readonly ITransactionRepository _transactionRepository = transactionRepository;

	public Task<DeleteTransactionCommandResponse> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
	{
		// Implement your logic here
		throw new NotImplementedException();
	}
}