using Investing.Domain.Entities;
using Investing.Shared.Repositories;

namespace Investing.Domain.Repositories
{
    public interface ISectorRepository : IRepository<Sector>
    {
        Task<IEnumerable<Sector>> GetByAssetClassId(Guid assetClassId, CancellationToken cancellationToken = default);
    }
}
