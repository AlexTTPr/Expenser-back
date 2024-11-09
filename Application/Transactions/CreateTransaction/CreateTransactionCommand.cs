using Domain.Shared;
using Domain.Transactions;

using MediatR;

namespace Application.Transactions.CreateTransaction;
public record class CreateTransactionCommand(DateTime TransactionDate, TransactionType Type, TransactionCategory Category, Money Money, IList<Tag> Tags)
	: IRequest<CreateTransactionCommandResponse>;
