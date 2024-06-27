using Investing.Domain.Entities;
using Investing.Shared.Repositories;

namespace Investing.Domain.Repositories
{
    public interface ISectorConfigurationRepository : IRepository<SectorConfiguration>
    {
        Task<IEnumerable<SectorConfiguration>> GetByAssetClassId(Guid assetClassId, CancellationToken cancellationToken = default);
        Task<IEnumerable<SectorConfiguration>> GetBySectorId(Guid sectorId, CancellationToken cancellationToken = default);
        Task<IEnumerable<SectorConfiguration>> GetByAssetClassAndSectorId(Guid assetClassId, Guid sectorId, CancellationToken cancellationToken = default);
    }
}
