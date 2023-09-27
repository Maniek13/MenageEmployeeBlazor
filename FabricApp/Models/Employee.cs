using FabricAPP.Interfaces;

namespace FabricAPP.Models
{
    public class Employee : IEmployee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
