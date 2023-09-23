namespace FabricAPP.Interfaces
{
    interface IAddress
    {
        string City { get; set; }
        string Street { get; set; }
        string StreetNr { get; set; }
        string HouseNr { get; set; }
        int Zip { get; set; }
    }
}
