using System.ComponentModel.DataAnnotations;

namespace DealershipNetworkApp.Core.InputModels
{
    public class SellerInputModel : BaseInputModel
    {
        [Required(ErrorMessage = "The \"name\" field is required")]
        [MaxLength(50, ErrorMessage = "The name must have a maximum of 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The \"baseSalary\" field is required")]
        [Range(1200, 6000, ErrorMessage = "The base salary must be between R$1200.00 and R$6000.00")]
        public decimal BaseSalary { get; set; }
    }
}
