namespace DealershipNetworkApp.Core.ViewModel
{
    public class SaleViewModel : BaseViewModel
    {
        public decimal Price { get; set; }
        public string VehicleChassisNumber { get; set; }
        public string OwnerCpfCnpj { get; set; }
        public int SellerId { get; set; }
    }
}
