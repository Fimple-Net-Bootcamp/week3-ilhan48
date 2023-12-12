using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Common.Persistence.Repositories;

public interface IAsyncRepository<TEntity, TEntityId> : IQuery<TEntity>
    where TEntity : BaseEntity<TEntityId>
{
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TEntity> AddAsync(TEntity entity);
}
