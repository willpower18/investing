using Investing.Domain.Entities;
using Investing.Shared.Repositories;

namespace Investing.Domain.Repositories
{
    public interface IAssetRepository : IRepository<Asset>
    {
        Task<Asset> GetByTicker(string ticker, CancellationToken cancellationToken = default);
        Task<IEnumerable<Asset>> GetByAssetClassId(Guid assetClassId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Asset>> GetBySectorId(Guid sectorId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Asset>> GetByAssetClassAndSectorId(Guid assetClassId, Guid sectorId, CancellationToken cancellationToken = default);
    }
}
