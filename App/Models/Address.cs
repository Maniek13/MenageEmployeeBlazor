using FabricAPP.Interfaces;

namespace FabricAPP.Models
{
    public class Address : IAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string HouseNr { get; set; }
        public string Zip { get; set; }
    }
}
