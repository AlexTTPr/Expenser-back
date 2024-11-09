using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared;
public interface IRepository<TEntity, TEntityId> where TEntity : BaseEntity<TEntityId>
{
	Task AddAsync(TEntity entity);

	Task UpdateAsync(TEntity entity);

	Task RemoveAsync(TEntity id);
	Task RemoveAsync(TEntityId id);

	Task<TEntity> GetById(TEntityId id);

	Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true);
	Task<ICollection<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true);
}