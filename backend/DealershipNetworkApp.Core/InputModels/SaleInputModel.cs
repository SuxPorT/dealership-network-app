using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DealershipNetworkApp.Core.Entities;

namespace DealershipNetworkApp.Core.InputModels
{
    public class SaleInputModel : BaseInputModel
    {
        [Required(ErrorMessage = "The \"price\" field is required")]
        public decimal Price { get; set; }

        [ForeignKey("VehicleChassisNumber")]
        [Required(ErrorMessage = "The \"vehicleChassisNumber\" field is required")]
        [MaxLength(17, ErrorMessage = "The vehicle chassis number must have a maximum of 17 characters")]
        public string VehicleChassisNumber { get; set; }

        [Required(ErrorMessage = "The \"sellerId\" field is required")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
