using System.Text.Json.Serialization;

namespace Investing.Services.Models
{
    internal class BrStockAssetList
    {
        [JsonPropertyName("stock")]
        public string Stock { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("close")]
        public double Close { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("logo")]
        public string Logo { get; set; }
    }
}
