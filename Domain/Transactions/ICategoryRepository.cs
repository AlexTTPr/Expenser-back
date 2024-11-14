using Domain.Shared;

namespace Domain.Transactions;
public interface ICategoryRepository : IRepository<TransactionCategory, Guid>
{
}
