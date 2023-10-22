using FabricAPP.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FabricAPP.Models
{

    public class Address : IAddress
    {
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Street nr is required")]
        public string StreetNr { get; set; }

        [Required(ErrorMessage = "House nr is required")]
        public string HouseNr { get; set; }

        [Required(ErrorMessage = "Zip code name is required")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Contact number must have 5 character.")]
        public string Zip { get; set; }
    }
}
