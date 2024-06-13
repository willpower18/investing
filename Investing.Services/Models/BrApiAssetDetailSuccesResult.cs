using Investing.Shared.GlobalEntities;
using System.Text.Json.Serialization;

namespace Investing.Services.Models
{
    internal class BrApiAssetDetailSuccesResult
    {
        [JsonPropertyName("results")]
        public List<AssetDetail> Results { get; set; }
    }
}
