using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investing.Infrastructure.Entities
{
    public class Sector : Base
    {
        [Required]
        public string AssetClassId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("AssetClassId")]
        public virtual AssetClass AssetClassIdNavigation { get; set; }
    }
}
