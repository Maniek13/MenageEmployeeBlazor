using FabricAPP.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FabricAPP.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Login must be set")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password must be set")]
        public string Password { get; set; }
    }
}
