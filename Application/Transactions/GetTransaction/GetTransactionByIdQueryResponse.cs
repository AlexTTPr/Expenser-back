using Domain.Shared;
using Domain.Transactions;

namespace Application.Transactions.GetTransaction;

public record class GetTransactionByIdQueryResponse(
	Guid UserId,
	Money Money,
	TransactionType Type,
	TransactionCategory Category,
	IList<Tag> Tags);
