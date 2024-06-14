using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investing.Infrastructure.Entities
{
    public class Wallet : Base
    {
        [Required]
        public string AssetClassId { get; set; }

        [Required]
        public double Percentage { get; set; }

        [ForeignKey("AssetClassId")]
        public virtual AssetClass AssetClassIdNavigation { get; set; }
    }
}
