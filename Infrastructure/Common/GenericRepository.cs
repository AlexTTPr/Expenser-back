using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Domain.Shared;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;
public class GenericRepository<TEntity, TEntityId> : IRepository<TEntity, TEntityId> where TEntity : BaseEntity<TEntityId>
{
    public AppDbContext Context { get; init; }

    protected readonly DbSet<TEntity> _set;

    public GenericRepository(AppDbContext context)
    {
        Context = context;
        _set = Context.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true)
    {
        IQueryable<TEntity> query = _set;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (!tracked)
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

	public virtual async Task<TEntity> GetById(TEntityId id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task RemoveAsync(TEntity id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task RemoveAsync(TEntityId id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
