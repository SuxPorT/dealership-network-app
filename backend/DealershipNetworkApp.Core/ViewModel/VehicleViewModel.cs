namespace DealershipNetworkApp.Core.ViewModel
{
    public class VehicleViewModel : BaseViewModel
    {
        public string ChassisNumber { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public decimal Mileage { get; set; }
        public string SystemVersion { get; set; }
        public string OwnerCpfCnpj { get; set; }
    }
}
