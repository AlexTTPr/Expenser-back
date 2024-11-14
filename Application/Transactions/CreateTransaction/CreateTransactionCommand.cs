using Domain.Shared;
using Domain.Transactions;

using MediatR;

namespace Application.Transactions.CreateTransaction;
public record class CreateTransactionCommand(Guid CreatorId, DateTime TransactionDate, TransactionType Type, Money Money, Guid CategoryId, IList<Guid> TagsIds)
	: IRequest<CreateTransactionCommandResponse>;
