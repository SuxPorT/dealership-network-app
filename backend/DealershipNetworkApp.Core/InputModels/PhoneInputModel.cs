using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealershipNetworkApp.Core.InputModels
{
    public class PhoneInputModel : BaseInputModel
    {
        [Required(ErrorMessage = "The \"number\" field is required")]
        [MinLength(9, ErrorMessage = "The phone number must have at least 9 characters")]
        [MaxLength(20, ErrorMessage = "The phone number must have a maximum of 20 characters")]
        public string Number { get; set; }

        [ForeignKey("OwnerCpfCnpj")]
        [Required(ErrorMessage = "The \"ownerCpfCnpj\" field is required")]
        public string OwnerCpfCnpj { get; set; }
    }
}
