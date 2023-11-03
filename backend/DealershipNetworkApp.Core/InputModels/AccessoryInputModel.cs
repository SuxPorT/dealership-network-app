using System.ComponentModel.DataAnnotations;

namespace DealershipNetworkApp.Core.InputModels
{
    public class AccessoryInputModel : BaseInputModel
    {
        [Required(ErrorMessage = "The \"description\" field is required")]
        [MaxLength(50, ErrorMessage = "The description must have a maximum of 50 characters")]
        public string Description { get; set; }
    }
}
