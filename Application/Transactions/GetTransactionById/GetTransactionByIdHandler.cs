using Domain.Transactions;

using MediatR;

namespace Application.Transactions.GetTransactionById;
internal sealed class GetTransactionByIdHandler(ITransactionRepository transactionRepository) : IRequestHandler<GetTransactionByIdQuery, GetTransactionByIdQueryResponse>
{
	public async Task<GetTransactionByIdQueryResponse> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
	{
		var transaction = await transactionRepository.GetByIdAsync(request.Id);

		return new GetTransactionByIdQueryResponse(transaction.UserId, transaction.Money, transaction.Type, transaction.Category, transaction.Tags.ToList());
	}
}
