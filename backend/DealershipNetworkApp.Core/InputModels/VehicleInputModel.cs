using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealershipNetworkApp.Core.InputModels
{
    public class VehicleInputModel : BaseInputModel
    {
        [MaxLength(17, ErrorMessage = "The chassis number must have a maximum of 50 characters")]
        public string ChassisNumber { get; set; }

        [Required(ErrorMessage = "The \"model\" field is required")]
        [MaxLength(50, ErrorMessage = "The model must have a maximum of 50 characters")]
        public string Model { get; set; }

        [Required(ErrorMessage = "The \"year\" field is required")]
        public int Year { get; set; }

        [MaxLength(30, ErrorMessage = "The \"color\" field is required")]
        public string Color { get; set; }

        [Required(ErrorMessage = "The \"price\" field is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The \"mileage\" field is required")]
        public decimal Mileage { get; set; }

        [MaxLength(10, ErrorMessage = "The \"systemVersion\" field is required")]
        public string SystemVersion { get; set; }

        [ForeignKey("OwnerCpfCnpj")]
        [Required(ErrorMessage = "The \"ownerCpfCnpj\" field is required")]
        public string OwnerCpfCnpj { get; set; }
    }
}
