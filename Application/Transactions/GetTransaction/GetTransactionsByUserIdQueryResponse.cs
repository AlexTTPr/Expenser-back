
using Domain.Transactions;

namespace Application.Transactions.GetTransaction;

public record GetTransactionsByUserIdQueryResponse(ICollection<Transaction> Transactions);
