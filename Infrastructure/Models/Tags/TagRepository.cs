using Domain.Transactions;

using Infrastructure.Common;

namespace Infrastructure.Models.Tags;
internal class TagRepository(AppDbContext context) : GenericRepository<Tag, Guid>(context), ITagRepository
{
}
