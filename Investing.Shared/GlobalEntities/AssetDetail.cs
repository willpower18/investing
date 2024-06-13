using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Investing.Shared.GlobalEntities
{
    public class AssetDetail
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        
        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }
        
        [JsonPropertyName("longName")]
        public string LongName { get; set; }
        
        [JsonPropertyName("logourl")]
        public string LogoUrl { get; set; }
        
        [JsonPropertyName("regularMarketPrice")]
        public double RegularMarketPrice { get; set; }
        
        [JsonPropertyName("regularMarketTime")]
        public DateTime RegularMarketTime { get; set; }
    }
}
