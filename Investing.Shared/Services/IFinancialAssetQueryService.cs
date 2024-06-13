using Investing.Shared.GlobalEntities;
using Investing.Shared.GlobalEnumerators;

namespace Investing.Shared.Services
{
    public interface IFinancialAssetQueryService
    {
        Task<AssetDetail> GetAssetDetailsBySymbol(string symbol, CancellationToken cancellationToken = default);
        Task<IEnumerable<AssetDetail>> GetAssetsDetailsBySymbols(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
        Task<IEnumerable<AssetDetail>> GetAssetsByType(EAssetType assetType, CancellationToken cancellationToken = default);
    }
}
