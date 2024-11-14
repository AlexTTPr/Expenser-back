using MediatR;

namespace Application.Transactions.GetTransactionById;
// Include properties to be used as input for the query
public record GetTransactionByIdQuery(Guid Id) : IRequest<GetTransactionByIdQueryQueryResponse>;
