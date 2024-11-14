using MediatR;

namespace Application.Transactions.DeleteTransaction;
// Include properties to be used as input for the command
public record DeleteTransactionCommand(Guid Id) : IRequest;