using System.ComponentModel.DataAnnotations;

namespace DealershipNetworkApp.Core.Entities
{
    public class Accessory : BaseEntity
    {
        [Required(ErrorMessage = "The \"description\" field is required")]
        [MaxLength(20, ErrorMessage = "The description must have a maximum of 50 characters")]
        public string Description { get; set; }

        public ICollection<AccessoryVehicle> AccessoriesVehicles { get; set; }
    }
}
