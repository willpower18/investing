using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investing.Shared.GlobalEntities
{
    public class AssetDetail
    {
        public string Symbol { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string LogoUrl { get; set; }
        public double RegularMarketPrice { get; set; }
        public DateTime RegularMarketTime { get; set; }
    }
}
