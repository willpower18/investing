using Investing.Domain.Entities;
using Investing.Shared.Repositories;

namespace Investing.Domain.Repositories
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        Task<IEnumerable<Wallet>> GetByAssetClassId(Guid assetClassId, CancellationToken cancellationToken = default);
    }
}
