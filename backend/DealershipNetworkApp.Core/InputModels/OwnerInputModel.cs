using System.ComponentModel.DataAnnotations;

namespace DealershipNetworkApp.Core.InputModels
{
    public class OwnerInputModel : BaseInputModel
    {
        [Required(ErrorMessage = "The \"cpfCnpj\" field is required")]
        [MaxLength(20, ErrorMessage = "The CPF/CNPJ must have a maximum of 20 characters")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "The \"hiringType\" field is required")]
        [MaxLength(1, ErrorMessage = "The field must indicate \"F\" (Físico) or \"J\" (Jurídico)")]
        public string HiringType { get; set; }

        [Required(ErrorMessage = "The \"name\" field is requried")]
        [MaxLength(50, ErrorMessage = "The name must have a maximum of 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The \"email\" field is required")]
        [MaxLength(50, ErrorMessage = "The email must have a maximum of 50 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The \"birthDate\" field is required")]
        public DateTime BirthDate { get; set; }

        [MaxLength(50, ErrorMessage = "The city must have a maximum of 50 characters")]
        public string City { get; set; }

        [MaxLength(40, ErrorMessage = "The UF must have a maximum of 50 characters")]
        public string UF { get; set; }

        [MaxLength(10, ErrorMessage = "The CEP must have a maximum of 50 characters")]
        public string CEP { get; set; }
    }
}
