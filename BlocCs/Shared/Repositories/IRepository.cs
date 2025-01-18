using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.Shared.Repositories;

public interface IRepository<TModel>
{
    Task<List<TModel>> ListAsync(CancellationToken cancellationToken = default);

    Task<List<TModel>> ListAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default);

    Task<TModel?> FindAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;

    Task<TModel?> FirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default);
    Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default);
    Task<int> DeleteAsync(TModel model, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);
}