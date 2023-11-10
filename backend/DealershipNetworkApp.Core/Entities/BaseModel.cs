using System.ComponentModel.DataAnnotations;

namespace DealershipNetworkApp.Core.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime? ModifiedAt { get; set; }

        [Required]
        public virtual bool? IsActive { get; set; }
    }
}
