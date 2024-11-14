using Domain.Shared;
using Domain.Transactions;

namespace Application.Transactions.GetTransactionById;

public record class GetTransactionByIdQueryQueryResponse(
	Guid UserId,
	Money Money,
	TransactionType Type,
	TransactionCategory Category,
	IList<Tag> Tags);
