using System.ComponentModel.DataAnnotations;

namespace FabricAPP.DBModels
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }

        public Address Address { get; set; }
    }
}
