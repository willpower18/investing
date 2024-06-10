namespace Investing.WebApp.Models
{
    public class WalletPercentage
    {
        public int AssetClassId { get; set; }
        public int Line { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }
    }
}
