using System.ComponentModel.DataAnnotations;

namespace Investing.Infrastructure.Entities
{
    public class AssetClass : Base
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Description { get; set; }
    }
}
