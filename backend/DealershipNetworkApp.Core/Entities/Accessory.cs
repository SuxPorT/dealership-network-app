using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealershipNetworkApp.Core.Entities
{
    public class Accessory : BaseEntity
    {
        [Required(ErrorMessage = "The \"description\" field is required")]
        [MaxLength(50, ErrorMessage = "The description must have a maximum of 50 characters")]
        public string Description { get; set; }

        [ForeignKey("VehicleChassisNumber")]
        [Required(ErrorMessage = "The \"vehicleChassisNumber\" field is required")]
        [MaxLength(17, ErrorMessage = "The chassis number must have a maximum of 17 characters")]
        public string VehicleChassisNumber { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
