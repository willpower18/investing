namespace Investing.WebApp.Models
{
    public class SectorConfiguration
    {
        public int AssetClassId { get; set; }
        public int SectorId { get; set; }
        public int Line { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }
    }
}
