using System.Linq.Expressions;

using Domain.Shared;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;
public abstract class GenericRepository<TEntity, TEntityId> : IRepository<TEntity, TEntityId> where TEntity : BaseEntity<TEntityId>
{
	public virtual AppDbContext Context { get; init; }

	protected readonly DbSet<TEntity> _set;

	public GenericRepository(AppDbContext context)
	{
		Context = context;
		_set = Context.Set<TEntity>();
	}

	public virtual async Task AddAsync(TEntity entity)
	{
		await _set.AddAsync(entity);

		await Context.SaveChangesAsync();
	}

	public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true)
	{
		IQueryable<TEntity> query = _set;
		if(filter != null)
		{
			query = query.Where(filter);
		}
		if(!tracked)
		{
			query = query.AsNoTracking();
		}
		return await query.FirstOrDefaultAsync();
	}

	public virtual async Task<ICollection<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true)
	{
		IQueryable<TEntity> query = _set;
		if(filter != null)
		{
			query = query.Where(filter);
		}
		if(!tracked)
		{
			query = query.AsNoTracking();
		}
		return await query.ToListAsync();
	}

	public virtual async Task<TEntity?> GetByIdAsync(TEntityId id)
	{
		return await _set.FindAsync(id);
	}

	public virtual async Task RemoveAsync(TEntityId id)
	{
		var count = await _set.Where(e => e.Id!.Equals(id)).ExecuteDeleteAsync();

		if(count == 0)
			throw new ArgumentException("No entities with specified Id to remove");

		await Context.SaveChangesAsync();
	}

	public virtual async Task UpdateAsync(TEntity entity)
	{
		_set.Update(entity);

		await Context.SaveChangesAsync();
	}
}
