using System.ComponentModel.DataAnnotations;

namespace FabricAPP.DBModels
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string StreetNr { get; set; }
        public string HouseNr { get; set; }
        public int Zip { get; set; }

        public int EmployeeID {get; set;}
        public Employee Employee { get; set; }
    }
}
