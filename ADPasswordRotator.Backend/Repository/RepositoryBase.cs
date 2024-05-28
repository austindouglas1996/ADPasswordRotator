using EFRepository;

namespace ADPasswordRotator.Backend.Repository
{
    public abstract class RepositoryBase<TKey,TEntity>(ADWorker worker) : Repository<ADContext, ADWorker, TKey, TEntity>(worker)
        where TEntity : class,IEntity<TKey>
    {
    }
}
