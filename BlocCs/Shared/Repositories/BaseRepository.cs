using System.Linq.Expressions;
using BlocCs.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BlocCs.Shared.Repositories;

public class BaseRepository<TModel> : IRepository<TModel> where TModel : class
{
    protected readonly ApplicationDbContext DbContext;

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public virtual async Task<List<TModel>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<List<TModel>> ListAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<TModel?> FindAsync<TId>(TId id,
        CancellationToken cancellationToken = default) where TId : notnull
    {
        var site = await DbContext.Set<TModel>().FindAsync([id], cancellationToken);
        if (site == null) return null;

        DbContext.Entry(site).State = EntityState.Detached;
        return site;
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().AnyAsync(predicate, cancellationToken);
    }

    public virtual async Task<TModel?> FirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().CountAsync(cancellationToken);
    }

    public virtual async Task<int> CountAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().CountAsync(predicate, cancellationToken);
    }

    public virtual async Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TModel>().Add(model);

        await DbContext.SaveChangesAsync(cancellationToken);

        return query.Entity;
    }

    public virtual async Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TModel>().Update(model);
        await DbContext.SaveChangesAsync(cancellationToken);
        return query.Entity;
    }

    public virtual async Task<int> DeleteAsync(TModel model, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TModel>().Remove(model);

        return await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.SaveChangesAsync(cancellationToken);
    }
}