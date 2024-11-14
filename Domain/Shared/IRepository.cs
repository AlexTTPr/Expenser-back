using System.Linq.Expressions;

namespace Domain.Shared;
public interface IRepository<TEntity, TEntityId> where TEntity : BaseEntity<TEntityId>
{
	Task AddAsync(TEntity entity);

	Task UpdateAsync(TEntity entity);

	Task RemoveAsync(TEntityId id);

	Task<TEntity?> GetByIdAsync(TEntityId id);

	Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true);
	Task<ICollection<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true);
}