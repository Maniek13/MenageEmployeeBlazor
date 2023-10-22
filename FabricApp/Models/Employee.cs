using FabricAPP.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FabricAPP.Models
{
    public class Employee : IEmployee
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Contact number must have between 9 and 15 character in length.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [ValidateComplexType]
        public Address Address { get; set; }
    }
}
