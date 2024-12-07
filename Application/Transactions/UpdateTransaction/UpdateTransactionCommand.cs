using Domain.Shared;
using Domain.Transactions;

using MediatR;

namespace Application.Transactions.UpdateTransaction;
// Include properties to be used as input for the command
public record UpdateTransactionCommand(Guid UserId, Guid TransactionId, DateTime TransactionDate, TransactionType Type, Money Money, Guid CategoryId, IList<Guid> TagsIds) : IRequest<UpdateTransactionCommandResponse>;