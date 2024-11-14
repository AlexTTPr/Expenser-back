using Domain.Transactions;

using Infrastructure.Common;

namespace Infrastructure.Models.Transactions;
internal class TransactionRepository(AppDbContext context) : GenericRepository<Transaction, Guid>(context), ITransactionRepository
{
}
