using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investing.Infrastructure.Entities
{
    public class Asset : Base
    {
        [Required]
        public string AssetClassId { get; set; }

        [Required]
        public string SectorId { get; set; }

        [Required, MaxLength(10)]
        public string Ticker { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(300)]
        public string LogoUrl { get; set; }

        [Required]
        public double Percentage { get; set; }

        [ForeignKey("AssetClassId")]
        public virtual AssetClass AssetClassIdNavigation { get; set; }

        [ForeignKey("SectorId")]
        public virtual Sector SectorIdNavigation { get; set; }
    }
}
