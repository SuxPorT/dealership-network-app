using System.ComponentModel.DataAnnotations;

namespace DealershipNetworkApp.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; } = null;

        [Required]
        public bool? IsActive { get; set; } = true;
    }
}
