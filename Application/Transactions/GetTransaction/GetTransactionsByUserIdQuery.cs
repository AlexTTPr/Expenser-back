using MediatR;

namespace Application.Transactions.GetTransaction;
// Include properties to be used as input for the query
public record GetTransactionsByUserIdQuery(Guid UserId) : IRequest<GetTransactionsByUserIdQueryResponse>;
