namespace DealershipNetworkApp.Core.ViewModel
{
    public class OwnerViewlModel : BaseViewModel
    {
        public string CpfCnpj { get; set; }
        public string HiringType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}
