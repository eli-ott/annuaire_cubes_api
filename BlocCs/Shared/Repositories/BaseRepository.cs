using System.Linq.Expressions;
using BlocCs.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BlocCs.Shared.Repositories;

/// <summary>
/// The base repository
/// </summary>
/// <typeparam name="TModel"></typeparam>
public class BaseRepository<TModel> : IRepository<TModel> where TModel : class
{
    /// <summary>
    /// The application database context
    /// </summary>
    protected readonly ApplicationDbContext DbContext;

    /// <summary>
    /// The base repository constructor
    /// </summary>
    /// <param name="dbContext">An instance of <see cref="ApplicationDbContext"/></param>
    /// <exception cref="ArgumentNullException"></exception>
    protected BaseRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// List all the elements from the db
    /// </summary>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<List<TModel>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().AsNoTracking().ToListAsync(cancellationToken);
    }

    /// <summary>
    /// List all the elements from the db
    /// </summary>
    /// <param name="predicate">An instance of <see cref="Expression"/></param>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<List<TModel>> ListAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Find an element from the db
    /// </summary>
    /// <param name="id">The id to find</param>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<TModel?> FindAsync<TId>(TId id,
        CancellationToken cancellationToken = default) where TId : notnull
    {
        var site = await DbContext.Set<TModel>().FindAsync([id], cancellationToken);
        if (site == null) return null;

        DbContext.Entry(site).State = EntityState.Detached;
        return site;
    }

    /// <summary>
    /// Find any element from the db
    /// </summary>
    /// <param name="predicate">An instance of <see cref="Expression"/></param>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().AnyAsync(predicate, cancellationToken);
    }

    /// <summary>
    /// Get the first element or the default value from the db
    /// </summary>
    /// <param name="predicate">An instance of <see cref="Expression"/></param>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<TModel?> FirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    /// <summary>
    /// Count elements from the db
    /// </summary>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().CountAsync(cancellationToken);
    }

    /// <summary>
    /// Count elements from the db
    /// </summary>
    /// <param name="predicate">An instance of <see cref="Expression"/></param>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<int> CountAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TModel>().CountAsync(predicate, cancellationToken);
    }

    /// <summary>
    /// Add an element from the db
    /// </summary>
    /// <param name="model">An instance of <see cref="Expression"/></param>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TModel>().Add(model);

        await DbContext.SaveChangesAsync(cancellationToken);

        return query.Entity;
    }

    /// <summary>
    /// Update an element from the db
    /// </summary>
    /// <param name="model">An instance of <see cref="Expression"/></param>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TModel>().Update(model);
        await DbContext.SaveChangesAsync(cancellationToken);
        return query.Entity;
    }

    /// <summary>
    /// Delete an element from the db
    /// </summary>
    /// <param name="model">An instance of <see cref="Expression"/></param>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<int> DeleteAsync(TModel model, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TModel>().Remove(model);

        return await DbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Saves the changes from the db
    /// </summary>
    /// <param name="cancellationToken">An instance of <see cref="CancellationToken"/></param>
    /// <returns>A tasked list</returns>
    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.SaveChangesAsync(cancellationToken);
    }
}