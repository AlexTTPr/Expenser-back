using Domain.Transactions;

using Infrastructure.Common;

namespace Infrastructure.Models.Categories;
internal class CategoryRepository(AppDbContext context) : GenericRepository<TransactionCategory, Guid>(context), ICategoryRepository
{
}
