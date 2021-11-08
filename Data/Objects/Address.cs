using FabricAPP.Interfaces;

namespace FabricAPP.Objects
{
    public class Address : IAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string HouseNr { get; set; }
        public int Zip { get; set; }
    }
}
