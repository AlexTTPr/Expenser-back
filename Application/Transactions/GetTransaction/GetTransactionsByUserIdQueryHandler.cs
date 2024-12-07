using Domain.Transactions;

using MediatR;

namespace Application.Transactions.GetTransaction;
public sealed class GetTransactionsByUserIdQueryHandler(ITransactionRepository transactionRepository) : IRequestHandler<GetTransactionsByUserIdQuery, GetTransactionsByUserIdQueryResponse>
{
	public async Task<GetTransactionsByUserIdQueryResponse> Handle(GetTransactionsByUserIdQuery request, CancellationToken cancellationToken)
	{
		var transactions = await transactionRepository.GetManyAsync((e) => e.UserId == request.UserId, false);

		return new GetTransactionsByUserIdQueryResponse(transactions);
	}
}
