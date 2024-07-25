using Investing.Domain.Entities;
using Investing.Shared.DataTransferObjects;
using Investing.Shared.Repositories;

namespace Investing.Domain.Repositories
{
    public interface ISectorRepository : IRepository<Sector>
    {
        Task<IEnumerable<Sector>> GetByAssetClassId(Guid assetClassId, CancellationToken cancellationToken = default);
        Task<IEnumerable<SectorWithAssetClassDTO>> GetActiveSectorsWithAssetClass(CancellationToken cancellationToken = default);
    }
}
