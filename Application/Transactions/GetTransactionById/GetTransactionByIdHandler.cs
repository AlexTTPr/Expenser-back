using Domain.Transactions;

using Mapster;

using MediatR;

namespace Application.Transactions.GetTransactionById;
internal sealed class GetTransactionByIdHandler(ITransactionRepository transactionRepository) : IRequestHandler<GetTransactionByIdQuery, GetTransactionByIdQueryQueryResponse>
{
	public async Task<GetTransactionByIdQueryQueryResponse> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
	{
		var transaction = await transactionRepository.GetByIdAsync(request.Id);

		return transaction.Adapt<GetTransactionByIdQueryQueryResponse>();
	}
}
