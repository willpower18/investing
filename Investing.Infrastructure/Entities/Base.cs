using System.ComponentModel.DataAnnotations;

namespace Investing.Infrastructure.Entities
{
    public abstract class Base
    {
        [Key, Required, MaxLength(36)]
        public string Id { get; set; }

        [Required]
        public int Active { get; set; }
    }
}
