using System.ComponentModel.DataAnnotations;

namespace FabricAPP.DBModels
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
