namespace DealershipNetworkApp.Core.Entities
{
    public class AccessoryVehicle : BaseEntity
    {
        public int AccessoryId { get; set; }
        public Accessory Accessory { get; set; }

        public string VehicleChassisNumber { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
