using System.Text.Json.Serialization;

namespace Investing.Services.Models
{
    internal class BrApiListAssetsSuccessResult
    {
        [JsonPropertyName("stocks")]
        public List<BrStockAssetList> Stocks { get; set; }
    }
}
