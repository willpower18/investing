using Investing.Shared.GlobalEntities;

namespace Investing.Shared.Repositories
{
    public interface IRepository<T> where T : DefaultEntity
    {
        Task Create(T entity, CancellationToken cancellationToken = default);
        Task Update(T entity, CancellationToken cancellationToken = default);
        Task Inactivate(T entity, CancellationToken cancellationToken = default);
        Task<T> GetById(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetActiveRecords(CancellationToken cancellationToken = default);
    }
}
